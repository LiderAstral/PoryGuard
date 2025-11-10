using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using PoryGuard.Controller;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace PoryGuard
{
    public partial class PoryGuard : MaterialForm
    {
        private NotifyIcon notifyIcon = new NotifyIcon();
        CapturaDeTela capturaDeTela;
        private const string configPath = "ConfiguraçãoPersistente.json";
        private bool iniciarMinimizado = false;

        // Flags para evitar loops de eventos
        private bool estaAtualizandoControles = false;
        private bool estaProcessandoMudanca = false;

        public PoryGuard()
        {
            VerificarArgumentosInicio();
            InitializeComponent();
            this.Load += PoryGuard_Load;
            IniciaExecucao();

            // Configurar bandeja
            notifyIcon.Icon = this.Icon;
            notifyIcon.Text = "PoryGuard";
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += (s, e) => { Show(); WindowState = FormWindowState.Normal; };

            // Menu de contexto
            var menu = new ContextMenuStrip();
            menu.Items.Add("Abrir", null, (s, e) => { Show(); WindowState = FormWindowState.Normal; });
            menu.Items.Add("Encerrar Aplicação", null, (s, e) => { notifyIcon.Visible = false; Environment.Exit(0); });
            notifyIcon.ContextMenuStrip = menu;

            // Configura o MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // Tema claro

            // Define a paleta de cores
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green50,       // Barra de título
                Primary.Grey100,       // Barra de status
                Primary.Grey200,       // Cor primária mais clara
                Accent.Cyan700,       // Cor de ACENTO
                TextShade.BLACK       // Cor do texto principal
            );

            AplicarCoresPory();

        private void VerificarArgumentosInicio()
        {
            string[] args = Environment.GetCommandLineArgs();
            iniciarMinimizado = args.Any(arg =>
            {
                string normalized = arg.Trim().ToLower().Replace("-", "");
                return normalized == "minimized";
            });
        }

        private void PoryGuard_Load(object sender, EventArgs e)
        {
            if (iniciarMinimizado)
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void AplicarCoresPorygon()
        {
            Color rosaPory = Color.FromArgb(230, 88, 88);
            Color vermelhoAlerta = Color.FromArgb(192, 57, 43);
            Color textoPrincipal = Color.Black;
            Color azulPory = Color.FromArgb(0, 184, 212);
            Color trilhoCinza = Color.FromArgb(224, 224, 224);

            mtbLuminosidadeTela.BackColor = azulPorygon;
            rngIntervaloFlash.VisualStyle = Syncfusion.Windows.Forms.Tools.RangeSlider.RangeSliderStyle.Metro;
            rngIntervaloFlash.ThemeName = "";
            rngIntervaloFlash.ChannelHeight = 4;
            rngIntervaloFlash.SliderSize = new System.Drawing.Size(7, 25);
            rngIntervaloFlash.ThemeStyle.ChannelColor = trilhoCinza;
            rngIntervaloFlash.ThemeStyle.RangeColor = azulPory;
            rngIntervaloFlash.ThemeStyle.ThumbColor = azulPory;
            rngIntervaloFlash.ThemeStyle.ThumbHoverColor = azulPory;
            rngIntervaloFlash.ThemeStyle.PressedThumbColor = azulPory;


            mlblTituloOtimizacao.ForeColor = rosaPory;
            mlblTituloSensibilidade.ForeColor = rosaPory;
            mlblTituloAjustes.ForeColor = rosaPory;
            mlblTituloOtimizacao.BackColor = Color.White;
            mlblTituloSensibilidade.BackColor = Color.White;
            mlblTituloAjustes.BackColor = Color.White;
            mlblAviso.ForeColor = vermelhoAlerta;
            mlblAviso.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
        }

        private void IniciaExecucao()
        {
            CarregarConfiguracoes();
            VerificaLigado();
        }

        private void CarregarConfiguracoes()
        {
            if (!File.Exists(configPath))
                return;

            var json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<ConfiguracaoPersistente>(json);
            mswAtivo.Checked = config.Ligado;
            mcbInicioAutomatico.Checked = config.InicioAutomatico;
            rngIntervaloFlash.SliderMin = config.FlashMinimo;
            rngIntervaloFlash.SliderMax = config.FlashMaximo;
            tcbVermelhoCritico.Value = config.VermelhoCritico;
            mtbVermelhoCritico.Text = config.VermelhoCritico.ToString();
            tcbLuminosidadeTela.Value = config.LuminosidadeTela;
            mtbLuminosidadeTela.Text = config.LuminosidadeTela.ToString();
            tcbLuminosidadeQuadrante.Value = config.LuminosidadeQuadrante;
            mtbLuminosidadeQuadrante.Text = config.LuminosidadeQuadrante.ToString();
            tcbQuadrantes.Value = config.Quadrantes;
            mtbQuadrantes.Text = config.Quadrantes.ToString();
            tcbOpacidade.Value = config.Opacidade;
            mtbOpacidade.Text = config.Opacidade.ToString();
        }

        private void SalvarConfiguracoes()
        {
            var config = new ConfiguracaoPersistente
            {
                FlashMinimo = rngIntervaloFlash.SliderMin,
                FlashMaximo = rngIntervaloFlash.SliderMax,
                VermelhoCritico = ParseEValidar(mtbVermelhoCritico.Text, tcbVermelhoCritico.Minimum, tcbVermelhoCritico.Maximum),
                LuminosidadeTela = ParseEValidar(mtbLuminosidadeTela.Text, tcbLuminosidadeTela.Minimum, tcbLuminosidadeTela.Maximum),
                LuminosidadeQuadrante = ParseEValidar(mtbLuminosidadeQuadrante.Text, tcbLuminosidadeQuadrante.Minimum, tcbLuminosidadeQuadrante.Maximum),
                Quadrantes = ParseEValidar(mtbQuadrantes.Text, tcbQuadrantes.Minimum, tcbQuadrantes.Maximum),
                Opacidade = ParseEValidar(mtbOpacidade.Text, tcbOpacidade.Minimum, tcbOpacidade.Maximum),
                Ligado = mswAtivo.Checked,
                InicioAutomatico = mcbInicioAutomatico.Checked
            };

            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configPath, json);
        }

        private void PoryGuard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                notifyIcon.ShowBalloonTip(2000, "PoryGuard", "Em execução em segundo plano", ToolTipIcon.Info);
                return;
            }

            // Limpar recursos antes de fechar
            if (capturaDeTela != null)
            {
                capturaDeTela.PararCaptura();
                capturaDeTela = null;
            }

            SalvarConfiguracoes();
        }

        private void VerificaLigado()
        {
            if (estaProcessandoMudanca)
                return;

            try
            {
                estaProcessandoMudanca = true;

                if (mswAtivo.Checked)
                {
                    // Parar captura anterior se existir
                    if (capturaDeTela != null)
                    {
                        capturaDeTela.PararCaptura();
                        capturaDeTela = null;
                    }

                    SalvarConfiguracoes();
                    AtivarInterface(false);
                    capturaDeTela = new CapturaDeTela();
                }
                else
                {
                    capturaDeTela?.PararCaptura();
                    capturaDeTela = null;
                    AtivarInterface(true);
                }
            }
            finally
            {
                estaProcessandoMudanca = false;
            }
        }


        private void tcbVermelhoCritico_Scroll(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            estaAtualizandoControles = true;
            mtbVermelhoCritico.Text = tcbVermelhoCritico.Value.ToString();
            estaAtualizandoControles = false;
        }

        private void mtbVermelhoCritico_TextChanged(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            bool ehValido = ValidarTextBoxNumerico(mtbVermelhoCritico, tcbVermelhoCritico);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbVermelhoCritico.Text);

                if (tcbVermelhoCritico.Value != valorValido)
                {
                    estaAtualizandoControles = true;
                    tcbVermelhoCritico.Value = valorValido;
                    estaAtualizandoControles = false;
                }
            }
        }

        private void tcbLuminosidadeTela_Scroll(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            estaAtualizandoControles = true;
            mtbLuminosidadeTela.Text = tcbLuminosidadeTela.Value.ToString();
            estaAtualizandoControles = false;
        }

        private void mtbLuminosidadeTela_TextChanged(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            bool ehValido = ValidarTextBoxNumerico(mtbLuminosidadeTela, tcbLuminosidadeTela);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbLuminosidadeTela.Text);

                if (tcbLuminosidadeTela.Value != valorValido)
                {
                    estaAtualizandoControles = true;
                    tcbLuminosidadeTela.Value = valorValido;
                    estaAtualizandoControles = false;
                }
            }
        }

        private void tcbLuminosidadeQuadrante_Scroll(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            estaAtualizandoControles = true;
            mtbLuminosidadeQuadrante.Text = tcbLuminosidadeQuadrante.Value.ToString();
            estaAtualizandoControles = false;
        }

        private void mtbLuminosidadeQuadrante_TextChanged(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            bool ehValido = ValidarTextBoxNumerico(mtbLuminosidadeQuadrante, tcbLuminosidadeQuadrante);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbLuminosidadeQuadrante.Text);

                if (tcbLuminosidadeQuadrante.Value != valorValido)
                {
                    estaAtualizandoControles = true;
                    tcbLuminosidadeQuadrante.Value = valorValido;
                    estaAtualizandoControles = false;
                }
            }
        }

        private void tcbQuadrantes_Scroll(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            estaAtualizandoControles = true;
            mtbQuadrantes.Text = tcbQuadrantes.Value.ToString();
            estaAtualizandoControles = false;
        }

        private void mtbQuadrantes_TextChanged(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            bool ehValido = ValidarTextBoxNumerico(mtbQuadrantes, tcbQuadrantes);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbQuadrantes.Text);

                if (tcbQuadrantes.Value != valorValido)
                {
                    estaAtualizandoControles = true;
                    tcbQuadrantes.Value = valorValido;
                    estaAtualizandoControles = false;
                }
            }
        }

        private void tcbOpacidade_Scroll(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            estaAtualizandoControles = true;
            mtbOpacidade.Text = tcbOpacidade.Value.ToString();
            estaAtualizandoControles = false;
        }

        private void mtbOpacidade_TextChanged(object sender, EventArgs e)
        {
            if (estaAtualizandoControles) return;

            bool ehValido = ValidarTextBoxNumerico(mtbOpacidade, tcbOpacidade);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbOpacidade.Text);

                if (tcbOpacidade.Value != valorValido)
                {
                    estaAtualizandoControles = true;
                    tcbOpacidade.Value = valorValido;
                    estaAtualizandoControles = false;
                }
            }
        }

        private void AtivarInterface(bool ativar)
        {
            rngIntervaloFlash.Enabled = ativar;
            tcbVermelhoCritico.Enabled = ativar;
            mtbVermelhoCritico.Enabled = ativar;
            tcbLuminosidadeTela.Enabled = ativar;
            mtbLuminosidadeTela.Enabled = ativar;
            tcbLuminosidadeQuadrante.Enabled = ativar;
            mtbLuminosidadeQuadrante.Enabled = ativar;
            tcbQuadrantes.Enabled = ativar;
            mtbQuadrantes.Enabled = ativar;
            tcbOpacidade.Enabled = ativar;
            mtbOpacidade.Enabled = ativar;
        }

        private int ParseEValidar(string texto, int min, int max)
        {
            if (!int.TryParse(texto, out int valor))
            {
                return min;
            }

            if (valor < min) return min;
            if (valor > max) return max;

            return valor;
        }

        private bool ValidarTextBoxNumerico(MaterialTextBox2 textBox, Syncfusion.Windows.Forms.Tools.TrackBarEx trackBar)
        {
            int min = trackBar.Minimum;
            int max = trackBar.Maximum;

            if (!int.TryParse(textBox.Text, out int valor))
            {
                errorProvider1.SetError(textBox, "Deve ser um número válido.");
                return false;
            }

            if (valor < min || valor > max)
            {
                errorProvider1.SetError(textBox, $"O valor deve estar entre {min} e {max}.");
                return false;
            }

            errorProvider1.SetError(textBox, null);
            return true;
        }

        private void mtbVermelhoCritico_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidarTextBoxNumerico(mtbVermelhoCritico, tcbVermelhoCritico))
            {
                e.Cancel = true;
            }
        }

        private void mtbLuminosidadeTela_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidarTextBoxNumerico(mtbLuminosidadeTela, tcbLuminosidadeTela))
            {
                e.Cancel = true;
            }
        }

        private void mtbLuminosidadeQuadrante_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidarTextBoxNumerico(mtbLuminosidadeQuadrante, tcbLuminosidadeQuadrante))
            {
                e.Cancel = true;
            }
        }

        private void mtbQuadrantes_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidarTextBoxNumerico(mtbQuadrantes, tcbQuadrantes))
            {
                e.Cancel = true;
            }
        }

        private void mtbOpacidade_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidarTextBoxNumerico(mtbOpacidade, tcbOpacidade))
            {
                e.Cancel = true;
            }
        }

        private void ConfigurarInicioAutomatico(bool ativar)
        {
            string appName = "PoryGuard";
            string exePath = Application.ExecutablePath;
            string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string lnkPath = Path.Combine(startupFolder, "PoryGuard.lnk");

            try
            {
                if (ativar)
                {
                    CriarAtalho(lnkPath, exePath, "--minimized", "PoryGuard - Iniciar minimizado");
                }
                else
                {
                    if (File.Exists(lnkPath))
                        File.Delete(lnkPath);

                    try
                    {
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(
                            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                        {
                            key?.DeleteValue(appName, false);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao configurar início automático:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CriarAtalho(string caminhoAtalho, string caminhoAlvo, string argumentos, string descricao)
        {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"));
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                var shortcut = shell.CreateShortcut(caminhoAtalho);
                shortcut.TargetPath = caminhoAlvo;
                shortcut.Arguments = argumentos;
                shortcut.Description = descricao;
                shortcut.WorkingDirectory = Path.GetDirectoryName(caminhoAlvo);
                shortcut.WindowStyle = 7;
                shortcut.Save();
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(shell);
            }
        }

        private void mcbInicioAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurarInicioAutomatico(mcbInicioAutomatico.Checked);
            SalvarConfiguracoes();
        }

        private void btnResetarPadroes_Click(object sender, EventArgs e)
        {
            ResetarPadroes();
        }
        private void ResetarPadroes()
        {
            mswAtivo.Checked = false;
            rngIntervaloFlash.SliderMin = 3;
            rngIntervaloFlash.SliderMax = 30;
            tcbVermelhoCritico.Value = 7;
            tcbLuminosidadeTela.Value = 10;
            tcbLuminosidadeQuadrante.Value = 10;
            tcbQuadrantes.Value = 30;
            tcbOpacidade.Value = 90;
        }

        private void mswAtivo_CheckedChanged(object sender, EventArgs e)
        {
            if (estaProcessandoMudanca)
                return;

            VerificaLigado();
            SalvarConfiguracoes();
        }
    }

    public class ConfiguracaoPersistente
    {
        public bool Ligado { get; set; }
        public bool InicioAutomatico { get; set; }
        public int FlashMinimo { get; set; }
        public int FlashMaximo { get; set; }
        public int LuminosidadeTela { get; set; }
        public int LuminosidadeQuadrante { get; set; }
        public int Quadrantes { get; set; }
        public int VermelhoCritico { get; set; }
        public int Opacidade { get; set; }
    }
}