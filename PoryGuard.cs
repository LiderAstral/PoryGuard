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

namespace PoryGuard
{
    public partial class PoryGuard: Form
    {
        CapturaDeTela capturaDeTela;
        private const string configPath = "ConfiguraçãoPersistente.json";
        public PoryGuard()
        {
            InitializeComponent();
            IniciaExecucao();
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

            nudMinimo.Value = config.FlashMinimo;
            nudMaximo.Value = config.FlashMaximo;
            tcbLuminosidadeTela.Value = config.LuminosidadeTela;
            nudLuminosidadeTela.Value = config.LuminosidadeTela;
            tcbLuminosidadeQuadrante.Value = config.LuminosidadeQuadrante;
            nudLuminosidadeQuadrante.Value = config.LuminosidadeQuadrante;
            tcbQuadrantes.Value = config.Quadrantes;
            nudQuadrantes.Value = config.Quadrantes;
            tcbVermelhoCritico.Value = config.VermelhoCritico;
            nudVermelhoCritico.Value = config.VermelhoCritico;

        }
        private void SalvarConfiguracoes()
        {
            var config = new ConfiguracaoPersistente
            {
                FlashMinimo = (int)nudMinimo.Value,
                FlashMaximo = (int)nudMaximo.Value,
                LuminosidadeTela = (int)nudLuminosidadeTela.Value,
                LuminosidadeQuadrante = (int)nudLuminosidadeQuadrante.Value,
                Quadrantes = (int)nudQuadrantes.Value,
                VermelhoCritico = (int)nudVermelhoCritico.Value

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
            if (cbxLigado.Checked)
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

        private void nudMinimo_ValueChanged(object sender, EventArgs e)
        {
            if(nudMinimo.Value > nudMaximo.Value)
                nudMinimo.Value = nudMaximo.Value;
        }
        private void nudMaximo_ValueChanged(object sender, EventArgs e)
        {
            if (nudMaximo.Value < nudMinimo.Value)
                nudMaximo.Value = nudMinimo.Value;
        }

        private void tcbVermelhoCritico_Scroll(object sender, EventArgs e)
        {
            nudVermelhoCritico.Value = tcbVermelhoCritico.Value;
        }

        private void nudVermelhoCritico_ValueChanged(object sender, EventArgs e)
        {
            tcbVermelhoCritico.Value = (int)nudVermelhoCritico.Value;
        }

        private void tcbLuminosidadeTela_Scroll(object sender, EventArgs e)
        {
            nudLuminosidadeTela.Value = tcbLuminosidadeTela.Value;
        }
        private void nudLuminosidadeTela_ValueChanged(object sender, EventArgs e)
        {
            tcbLuminosidadeTela.Value = (int)nudLuminosidadeTela.Value;
        }

        private void tcbLuminosidadeQuadrante_Scroll(object sender, EventArgs e)
        {
            nudLuminosidadeQuadrante.Value = tcbLuminosidadeQuadrante.Value;
        }
        private void nudLuminosidadeQuadrante_ValueChanged(object sender, EventArgs e)
        {
            tcbLuminosidadeQuadrante.Value = (int)nudLuminosidadeQuadrante.Value;
        }

        private void tcbQuadrantes_Scroll(object sender, EventArgs e)
        {
            nudQuadrantes.Value = tcbQuadrantes.Value;
        }
        private void nudQuadrantes_ValueChanged(object sender, EventArgs e)
        {
            tcbQuadrantes.Value = (int)nudQuadrantes.Value;
        }
        private void AtivarInterface(bool ativar)
        {
            nudMinimo.Enabled = ativar;
            nudMaximo.Enabled = ativar;
            tcbLuminosidadeTela.Enabled = ativar;
            nudLuminosidadeTela.Enabled = ativar;
            tcbLuminosidadeQuadrante.Enabled = ativar;
            nudLuminosidadeQuadrante.Enabled = ativar;
            tcbQuadrantes.Enabled = ativar;
            nudQuadrantes.Enabled = ativar;
            tcbVermelhoCritico.Enabled = ativar;
            nudVermelhoCritico.Enabled = ativar;
        }

    }
    public class ConfiguracaoPersistente
    {
        public int FlashMinimo { get; set; } 
        public int FlashMaximo { get; set; }
        public int LuminosidadeTela { get; set; }
        public int LuminosidadeQuadrante { get; set; }
        public int Quadrantes { get; set; }
        public int VermelhoCritico { get; set; }

    }

}
