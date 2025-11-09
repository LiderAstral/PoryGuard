using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using PoryGuard.Controller;
using System.Text.Json;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace PoryGuard
{
    public partial class PoryGuard: MaterialForm
    {
        CapturaDeTela capturaDeTela;
        private const string configPath = "ConfiguraçãoPersistente.json";
        public PoryGuard()
        {
            InitializeComponent();

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
                TextShade.BLACK            // Cor do texto principal
            );

            AplicarCoresPorygon();

            IniciaExecucao();
        }

        private void AplicarCoresPorygon()
        {
            // Defina cores Porygon customizadas
            Color rosaPorygon = Color.FromArgb(197, 57, 90);
            Color azulPorygon = Color.FromArgb(8, 172, 213);
            Color vermelhoAlerta = Color.FromArgb(192, 57, 43);
            Color textoPrincipal = Color.Black;

            mtbLuminosidadeTela.BackColor = azulPorygon;
            //nudLuminosidadeQuadrante.BackColor = azulPorygon;
            //nudQuadrantes.BackColor = azulPorygon;
            //nudOpacidade.BackColor = azulPorygon;

            mlblTituloOtimizacao.ForeColor = rosaPorygon;
            mlblTituloSensibilidade.ForeColor = rosaPorygon;
            mlblTituloAjustes.ForeColor = rosaPorygon;
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
            SalvarConfiguracoes();
        }
        private void VerificaLigado()
        {
            if (mswAtivo.Checked)
            {
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
        private void cbxLigado_CheckedChanged(object sender, EventArgs e)
        {
            VerificaLigado();
        }

        private void tcbVermelhoCritico_Scroll(object sender, EventArgs e)
        {
            mtbVermelhoCritico.Text = tcbVermelhoCritico.Value.ToString();
        }
        private void mtbVermelhoCritico_TextChanged(object sender, EventArgs e)
        {
            bool ehValido = ValidarTextBoxNumerico(mtbVermelhoCritico, tcbVermelhoCritico);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbVermelhoCritico.Text);

                if (tcbVermelhoCritico.Value != valorValido)
                {
                    tcbVermelhoCritico.Value = valorValido;
                }
            }
        }

        private void tcbLuminosidadeTela_Scroll(object sender, EventArgs e)
        {
            mtbLuminosidadeTela.Text = tcbLuminosidadeTela.Value.ToString();
        }
        private void mtbLuminosidadeTela_TextChanged(object sender, EventArgs e)
        {
            bool ehValido = ValidarTextBoxNumerico(mtbLuminosidadeTela, tcbLuminosidadeTela);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbLuminosidadeTela.Text);

                if (tcbLuminosidadeTela.Value != valorValido)
                {
                    tcbLuminosidadeTela.Value = valorValido;
                }
            }
        }

        private void tcbLuminosidadeQuadrante_Scroll(object sender, EventArgs e)
        {
            mtbLuminosidadeQuadrante.Text = tcbLuminosidadeQuadrante.Value.ToString();
        }
        private void mtbLuminosidadeQuadrante_TextChanged(object sender, EventArgs e)
        {
            bool ehValido = ValidarTextBoxNumerico(mtbLuminosidadeQuadrante, tcbLuminosidadeQuadrante);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbLuminosidadeQuadrante.Text);

                if (tcbLuminosidadeQuadrante.Value != valorValido)
                {
                    tcbLuminosidadeQuadrante.Value = valorValido;
                }
            }
        }

        private void tcbQuadrantes_Scroll(object sender, EventArgs e)
        {
            mtbQuadrantes.Text = tcbQuadrantes.Value.ToString();
        }
        private void mtbQuadrantes_TextChanged(object sender, EventArgs e)
        {
            bool ehValido = ValidarTextBoxNumerico(mtbQuadrantes, tcbQuadrantes);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbQuadrantes.Text);

                if (tcbQuadrantes.Value != valorValido)
                {
                    tcbQuadrantes.Value = valorValido;
                }
            }
        }

        private void tcbOpacidade_Scroll(object sender, EventArgs e)
        {
            mtbOpacidade.Text = tcbOpacidade.Value.ToString();
        }
        private void mtbOpacidade_TextChanged(object sender, EventArgs e)
        {
            bool ehValido = ValidarTextBoxNumerico(mtbOpacidade, tcbOpacidade);

            if (ehValido)
            {
                int valorValido = int.Parse(mtbOpacidade.Text);

                if (tcbOpacidade.Value != valorValido)
                {
                    tcbOpacidade.Value = valorValido;
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
