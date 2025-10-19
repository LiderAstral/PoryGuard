namespace PoryGuard
{
    partial class PoryGuard
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PoryGuard));
            this.cbxInicioAutomatico = new System.Windows.Forms.CheckBox();
            this.lblOpacidade = new System.Windows.Forms.Label();
            this.tcbOpacidade = new System.Windows.Forms.TrackBar();
            this.nudOpacidade = new System.Windows.Forms.NumericUpDown();
            this.lblQuadrantes = new System.Windows.Forms.Label();
            this.tcbQuadrantes = new System.Windows.Forms.TrackBar();
            this.nudQuadrantes = new System.Windows.Forms.NumericUpDown();
            this.lblLuminosidadeQuadrante = new System.Windows.Forms.Label();
            this.tcbLuminosidadeQuadrante = new System.Windows.Forms.TrackBar();
            this.nudLuminosidadeQuadrante = new System.Windows.Forms.NumericUpDown();
            this.lblLuminosidadeTela = new System.Windows.Forms.Label();
            this.tcbLuminosidadeTela = new System.Windows.Forms.TrackBar();
            this.nudLuminosidadeTela = new System.Windows.Forms.NumericUpDown();
            this.nudVermelhoCritico = new System.Windows.Forms.NumericUpDown();
            this.tcbVermelhoCritico = new System.Windows.Forms.TrackBar();
            this.lblVermelhoCritico = new System.Windows.Forms.Label();
            this.lblMaximo = new System.Windows.Forms.Label();
            this.nudMaximo = new System.Windows.Forms.NumericUpDown();
            this.cbxLigado = new System.Windows.Forms.CheckBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel_tcbOpacidade = new System.Windows.Forms.Panel();
            this.max_tcbOpacidade = new System.Windows.Forms.Label();
            this.min_tcbOpacidade = new System.Windows.Forms.Label();
            this.panel_tcbQuadrantes = new System.Windows.Forms.Panel();
            this.max_tcbQuadrantes = new System.Windows.Forms.Label();
            this.min_tcbQuadrantes = new System.Windows.Forms.Label();
            this.panel_tcbLuminosidadeQuadrante = new System.Windows.Forms.Panel();
            this.max_tcbLuminosidadeQuadrante = new System.Windows.Forms.Label();
            this.min_tcbLuminosidadeQuadrante = new System.Windows.Forms.Label();
            this.panel_tcbLuminosidadeTela = new System.Windows.Forms.Panel();
            this.max_tcbLuminosidadeTela = new System.Windows.Forms.Label();
            this.min_tcbLuminosidadeTela = new System.Windows.Forms.Label();
            this.lblIntervaloFlash = new System.Windows.Forms.Label();
            this.tlpIntervalo = new System.Windows.Forms.TableLayoutPanel();
            this.lblMinimo = new System.Windows.Forms.Label();
            this.nudMinimo = new System.Windows.Forms.NumericUpDown();
            this.panel_tcbVermelhoCritico = new System.Windows.Forms.Panel();
            this.max_tcbVermelhoCritico = new System.Windows.Forms.Label();
            this.min_tcbVermelhoCritico = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblAviso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tcbOpacidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbQuadrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuadrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbLuminosidadeQuadrante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuminosidadeQuadrante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbLuminosidadeTela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuminosidadeTela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVermelhoCritico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbVermelhoCritico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximo)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.panel_tcbOpacidade.SuspendLayout();
            this.panel_tcbQuadrantes.SuspendLayout();
            this.panel_tcbLuminosidadeQuadrante.SuspendLayout();
            this.panel_tcbLuminosidadeTela.SuspendLayout();
            this.tlpIntervalo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimo)).BeginInit();
            this.panel_tcbVermelhoCritico.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxInicioAutomatico
            // 
            resources.ApplyResources(this.cbxInicioAutomatico, "cbxInicioAutomatico");
            this.cbxInicioAutomatico.Checked = true;
            this.cbxInicioAutomatico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInicioAutomatico.ForeColor = System.Drawing.Color.Black;
            this.cbxInicioAutomatico.Name = "cbxInicioAutomatico";
            this.cbxInicioAutomatico.UseVisualStyleBackColor = true;
            // 
            // lblOpacidade
            // 
            resources.ApplyResources(this.lblOpacidade, "lblOpacidade");
            this.lblOpacidade.AutoEllipsis = true;
            this.lblOpacidade.ForeColor = System.Drawing.Color.Black;
            this.lblOpacidade.Name = "lblOpacidade";
            this.lblOpacidade.Click += new System.EventHandler(this.lblOpacidade_Click);
            // 
            // tcbOpacidade
            // 
            resources.ApplyResources(this.tcbOpacidade, "tcbOpacidade");
            this.tcbOpacidade.Maximum = 100;
            this.tcbOpacidade.Minimum = 10;
            this.tcbOpacidade.Name = "tcbOpacidade";
            this.tcbOpacidade.TickFrequency = 10;
            this.tcbOpacidade.Value = 30;
            this.tcbOpacidade.Scroll += new System.EventHandler(this.tcbOpacidade_Scroll);
            // 
            // nudOpacidade
            // 
            resources.ApplyResources(this.nudOpacidade, "nudOpacidade");
            this.nudOpacidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(162)))));
            this.nudOpacidade.ForeColor = System.Drawing.Color.White;
            this.nudOpacidade.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudOpacidade.Name = "nudOpacidade";
            this.nudOpacidade.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudOpacidade.ValueChanged += new System.EventHandler(this.nudOpacidade_ValueChanged);
            // 
            // lblQuadrantes
            // 
            resources.ApplyResources(this.lblQuadrantes, "lblQuadrantes");
            this.lblQuadrantes.AutoEllipsis = true;
            this.lblQuadrantes.ForeColor = System.Drawing.Color.Black;
            this.lblQuadrantes.Name = "lblQuadrantes";
            // 
            // tcbQuadrantes
            // 
            resources.ApplyResources(this.tcbQuadrantes, "tcbQuadrantes");
            this.tcbQuadrantes.Maximum = 50;
            this.tcbQuadrantes.Minimum = 10;
            this.tcbQuadrantes.Name = "tcbQuadrantes";
            this.tcbQuadrantes.TickFrequency = 5;
            this.tcbQuadrantes.Value = 30;
            this.tcbQuadrantes.Scroll += new System.EventHandler(this.tcbQuadrantes_Scroll);
            // 
            // nudQuadrantes
            // 
            resources.ApplyResources(this.nudQuadrantes, "nudQuadrantes");
            this.nudQuadrantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(162)))));
            this.nudQuadrantes.ForeColor = System.Drawing.Color.White;
            this.nudQuadrantes.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudQuadrantes.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudQuadrantes.Name = "nudQuadrantes";
            this.nudQuadrantes.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudQuadrantes.ValueChanged += new System.EventHandler(this.nudQuadrantes_ValueChanged);
            // 
            // lblLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.lblLuminosidadeQuadrante, "lblLuminosidadeQuadrante");
            this.lblLuminosidadeQuadrante.AutoEllipsis = true;
            this.lblLuminosidadeQuadrante.ForeColor = System.Drawing.Color.Black;
            this.lblLuminosidadeQuadrante.Name = "lblLuminosidadeQuadrante";
            // 
            // tcbLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.tcbLuminosidadeQuadrante, "tcbLuminosidadeQuadrante");
            this.tcbLuminosidadeQuadrante.Maximum = 80;
            this.tcbLuminosidadeQuadrante.Minimum = 5;
            this.tcbLuminosidadeQuadrante.Name = "tcbLuminosidadeQuadrante";
            this.tcbLuminosidadeQuadrante.TickFrequency = 5;
            this.tcbLuminosidadeQuadrante.Value = 20;
            this.tcbLuminosidadeQuadrante.Scroll += new System.EventHandler(this.tcbLuminosidadeQuadrante_Scroll);
            // 
            // nudLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.nudLuminosidadeQuadrante, "nudLuminosidadeQuadrante");
            this.nudLuminosidadeQuadrante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(162)))));
            this.nudLuminosidadeQuadrante.ForeColor = System.Drawing.Color.White;
            this.nudLuminosidadeQuadrante.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudLuminosidadeQuadrante.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLuminosidadeQuadrante.Name = "nudLuminosidadeQuadrante";
            this.nudLuminosidadeQuadrante.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLuminosidadeQuadrante.ValueChanged += new System.EventHandler(this.nudLuminosidadeQuadrante_ValueChanged);
            // 
            // lblLuminosidadeTela
            // 
            resources.ApplyResources(this.lblLuminosidadeTela, "lblLuminosidadeTela");
            this.lblLuminosidadeTela.ForeColor = System.Drawing.Color.Black;
            this.lblLuminosidadeTela.Name = "lblLuminosidadeTela";
            // 
            // tcbLuminosidadeTela
            // 
            resources.ApplyResources(this.tcbLuminosidadeTela, "tcbLuminosidadeTela");
            this.tcbLuminosidadeTela.Maximum = 80;
            this.tcbLuminosidadeTela.Minimum = 5;
            this.tcbLuminosidadeTela.Name = "tcbLuminosidadeTela";
            this.tcbLuminosidadeTela.TickFrequency = 5;
            this.tcbLuminosidadeTela.Value = 20;
            this.tcbLuminosidadeTela.Scroll += new System.EventHandler(this.tcbLuminosidadeTela_Scroll);
            // 
            // nudLuminosidadeTela
            // 
            resources.ApplyResources(this.nudLuminosidadeTela, "nudLuminosidadeTela");
            this.nudLuminosidadeTela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(162)))));
            this.nudLuminosidadeTela.ForeColor = System.Drawing.Color.White;
            this.nudLuminosidadeTela.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudLuminosidadeTela.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLuminosidadeTela.Name = "nudLuminosidadeTela";
            this.nudLuminosidadeTela.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLuminosidadeTela.ValueChanged += new System.EventHandler(this.nudLuminosidadeTela_ValueChanged);
            // 
            // nudVermelhoCritico
            // 
            resources.ApplyResources(this.nudVermelhoCritico, "nudVermelhoCritico");
            this.nudVermelhoCritico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(162)))));
            this.nudVermelhoCritico.ForeColor = System.Drawing.Color.White;
            this.nudVermelhoCritico.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudVermelhoCritico.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudVermelhoCritico.Name = "nudVermelhoCritico";
            this.nudVermelhoCritico.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudVermelhoCritico.ValueChanged += new System.EventHandler(this.nudVermelhoCritico_ValueChanged);
            // 
            // tcbVermelhoCritico
            // 
            this.tcbVermelhoCritico.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.tcbVermelhoCritico, "tcbVermelhoCritico");
            this.tcbVermelhoCritico.Maximum = 80;
            this.tcbVermelhoCritico.Minimum = 5;
            this.tcbVermelhoCritico.Name = "tcbVermelhoCritico";
            this.tcbVermelhoCritico.TickFrequency = 5;
            this.tcbVermelhoCritico.Value = 20;
            this.tcbVermelhoCritico.Scroll += new System.EventHandler(this.tcbVermelhoCritico_Scroll);
            // 
            // lblVermelhoCritico
            // 
            resources.ApplyResources(this.lblVermelhoCritico, "lblVermelhoCritico");
            this.lblVermelhoCritico.ForeColor = System.Drawing.Color.Black;
            this.lblVermelhoCritico.Name = "lblVermelhoCritico";
            // 
            // lblMaximo
            // 
            resources.ApplyResources(this.lblMaximo, "lblMaximo");
            this.lblMaximo.ForeColor = System.Drawing.Color.Black;
            this.lblMaximo.Name = "lblMaximo";
            // 
            // nudMaximo
            // 
            this.nudMaximo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(208)))), ((int)(((byte)(218)))));
            resources.ApplyResources(this.nudMaximo, "nudMaximo");
            this.nudMaximo.ForeColor = System.Drawing.Color.White;
            this.nudMaximo.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudMaximo.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMaximo.Name = "nudMaximo";
            this.nudMaximo.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudMaximo.ValueChanged += new System.EventHandler(this.nudMaximo_ValueChanged);
            // 
            // cbxLigado
            // 
            resources.ApplyResources(this.cbxLigado, "cbxLigado");
            this.cbxLigado.Checked = true;
            this.cbxLigado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxLigado.ForeColor = System.Drawing.Color.Black;
            this.cbxLigado.Name = "cbxLigado";
            this.cbxLigado.UseVisualStyleBackColor = true;
            this.cbxLigado.CheckedChanged += new System.EventHandler(this.cbxLigado_CheckedChanged);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.cbxLigado);
            this.panelHeader.Controls.Add(this.cbxInicioAutomatico);
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.ForeColor = System.Drawing.Color.Black;
            this.panelHeader.Name = "panelHeader";
            // 
            // tlpMain
            // 
            resources.ApplyResources(this.tlpMain, "tlpMain");
            this.tlpMain.Controls.Add(this.panel_tcbOpacidade, 1, 5);
            this.tlpMain.Controls.Add(this.panel_tcbQuadrantes, 1, 4);
            this.tlpMain.Controls.Add(this.panel_tcbLuminosidadeQuadrante, 1, 3);
            this.tlpMain.Controls.Add(this.panel_tcbLuminosidadeTela, 1, 2);
            this.tlpMain.Controls.Add(this.lblIntervaloFlash, 0, 0);
            this.tlpMain.Controls.Add(this.tlpIntervalo, 1, 0);
            this.tlpMain.Controls.Add(this.nudOpacidade, 2, 5);
            this.tlpMain.Controls.Add(this.nudVermelhoCritico, 2, 1);
            this.tlpMain.Controls.Add(this.lblLuminosidadeTela, 0, 2);
            this.tlpMain.Controls.Add(this.lblOpacidade, 0, 5);
            this.tlpMain.Controls.Add(this.nudQuadrantes, 2, 4);
            this.tlpMain.Controls.Add(this.nudLuminosidadeTela, 2, 2);
            this.tlpMain.Controls.Add(this.lblLuminosidadeQuadrante, 0, 3);
            this.tlpMain.Controls.Add(this.nudLuminosidadeQuadrante, 2, 3);
            this.tlpMain.Controls.Add(this.lblQuadrantes, 0, 4);
            this.tlpMain.Controls.Add(this.lblVermelhoCritico, 0, 1);
            this.tlpMain.Controls.Add(this.panel_tcbVermelhoCritico, 1, 1);
            this.tlpMain.Name = "tlpMain";
            // 
            // panel_tcbOpacidade
            // 
            resources.ApplyResources(this.panel_tcbOpacidade, "panel_tcbOpacidade");
            this.panel_tcbOpacidade.Controls.Add(this.tcbOpacidade);
            this.panel_tcbOpacidade.Controls.Add(this.max_tcbOpacidade);
            this.panel_tcbOpacidade.Controls.Add(this.min_tcbOpacidade);
            this.panel_tcbOpacidade.Name = "panel_tcbOpacidade";
            // 
            // max_tcbOpacidade
            // 
            resources.ApplyResources(this.max_tcbOpacidade, "max_tcbOpacidade");
            this.max_tcbOpacidade.ForeColor = System.Drawing.Color.Black;
            this.max_tcbOpacidade.Name = "max_tcbOpacidade";
            // 
            // min_tcbOpacidade
            // 
            resources.ApplyResources(this.min_tcbOpacidade, "min_tcbOpacidade");
            this.min_tcbOpacidade.ForeColor = System.Drawing.Color.Black;
            this.min_tcbOpacidade.Name = "min_tcbOpacidade";
            // 
            // panel_tcbQuadrantes
            // 
            resources.ApplyResources(this.panel_tcbQuadrantes, "panel_tcbQuadrantes");
            this.panel_tcbQuadrantes.Controls.Add(this.tcbQuadrantes);
            this.panel_tcbQuadrantes.Controls.Add(this.max_tcbQuadrantes);
            this.panel_tcbQuadrantes.Controls.Add(this.min_tcbQuadrantes);
            this.panel_tcbQuadrantes.Name = "panel_tcbQuadrantes";
            // 
            // max_tcbQuadrantes
            // 
            resources.ApplyResources(this.max_tcbQuadrantes, "max_tcbQuadrantes");
            this.max_tcbQuadrantes.ForeColor = System.Drawing.Color.Black;
            this.max_tcbQuadrantes.Name = "max_tcbQuadrantes";
            // 
            // min_tcbQuadrantes
            // 
            resources.ApplyResources(this.min_tcbQuadrantes, "min_tcbQuadrantes");
            this.min_tcbQuadrantes.ForeColor = System.Drawing.Color.Black;
            this.min_tcbQuadrantes.Name = "min_tcbQuadrantes";
            // 
            // panel_tcbLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.panel_tcbLuminosidadeQuadrante, "panel_tcbLuminosidadeQuadrante");
            this.panel_tcbLuminosidadeQuadrante.Controls.Add(this.tcbLuminosidadeQuadrante);
            this.panel_tcbLuminosidadeQuadrante.Controls.Add(this.max_tcbLuminosidadeQuadrante);
            this.panel_tcbLuminosidadeQuadrante.Controls.Add(this.min_tcbLuminosidadeQuadrante);
            this.panel_tcbLuminosidadeQuadrante.Name = "panel_tcbLuminosidadeQuadrante";
            // 
            // max_tcbLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.max_tcbLuminosidadeQuadrante, "max_tcbLuminosidadeQuadrante");
            this.max_tcbLuminosidadeQuadrante.ForeColor = System.Drawing.Color.Black;
            this.max_tcbLuminosidadeQuadrante.Name = "max_tcbLuminosidadeQuadrante";
            // 
            // min_tcbLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.min_tcbLuminosidadeQuadrante, "min_tcbLuminosidadeQuadrante");
            this.min_tcbLuminosidadeQuadrante.ForeColor = System.Drawing.Color.Black;
            this.min_tcbLuminosidadeQuadrante.Name = "min_tcbLuminosidadeQuadrante";
            // 
            // panel_tcbLuminosidadeTela
            // 
            resources.ApplyResources(this.panel_tcbLuminosidadeTela, "panel_tcbLuminosidadeTela");
            this.panel_tcbLuminosidadeTela.Controls.Add(this.tcbLuminosidadeTela);
            this.panel_tcbLuminosidadeTela.Controls.Add(this.max_tcbLuminosidadeTela);
            this.panel_tcbLuminosidadeTela.Controls.Add(this.min_tcbLuminosidadeTela);
            this.panel_tcbLuminosidadeTela.Name = "panel_tcbLuminosidadeTela";
            // 
            // max_tcbLuminosidadeTela
            // 
            resources.ApplyResources(this.max_tcbLuminosidadeTela, "max_tcbLuminosidadeTela");
            this.max_tcbLuminosidadeTela.ForeColor = System.Drawing.Color.Black;
            this.max_tcbLuminosidadeTela.Name = "max_tcbLuminosidadeTela";
            // 
            // min_tcbLuminosidadeTela
            // 
            resources.ApplyResources(this.min_tcbLuminosidadeTela, "min_tcbLuminosidadeTela");
            this.min_tcbLuminosidadeTela.ForeColor = System.Drawing.Color.Black;
            this.min_tcbLuminosidadeTela.Name = "min_tcbLuminosidadeTela";
            // 
            // lblIntervaloFlash
            // 
            resources.ApplyResources(this.lblIntervaloFlash, "lblIntervaloFlash");
            this.lblIntervaloFlash.ForeColor = System.Drawing.Color.Black;
            this.lblIntervaloFlash.Name = "lblIntervaloFlash";
            // 
            // tlpIntervalo
            // 
            resources.ApplyResources(this.tlpIntervalo, "tlpIntervalo");
            this.tlpIntervalo.Controls.Add(this.lblMinimo, 0, 0);
            this.tlpIntervalo.Controls.Add(this.nudMinimo, 0, 1);
            this.tlpIntervalo.Controls.Add(this.lblMaximo, 1, 0);
            this.tlpIntervalo.Controls.Add(this.nudMaximo, 1, 1);
            this.tlpIntervalo.Name = "tlpIntervalo";
            // 
            // lblMinimo
            // 
            resources.ApplyResources(this.lblMinimo, "lblMinimo");
            this.lblMinimo.ForeColor = System.Drawing.Color.Black;
            this.lblMinimo.Name = "lblMinimo";
            // 
            // nudMinimo
            // 
            this.nudMinimo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(208)))), ((int)(((byte)(218)))));
            resources.ApplyResources(this.nudMinimo, "nudMinimo");
            this.nudMinimo.ForeColor = System.Drawing.Color.White;
            this.nudMinimo.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudMinimo.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMinimo.Name = "nudMinimo";
            this.nudMinimo.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMinimo.ValueChanged += new System.EventHandler(this.nudMinimo_ValueChanged);
            // 
            // panel_tcbVermelhoCritico
            // 
            resources.ApplyResources(this.panel_tcbVermelhoCritico, "panel_tcbVermelhoCritico");
            this.panel_tcbVermelhoCritico.Controls.Add(this.tcbVermelhoCritico);
            this.panel_tcbVermelhoCritico.Controls.Add(this.max_tcbVermelhoCritico);
            this.panel_tcbVermelhoCritico.Controls.Add(this.min_tcbVermelhoCritico);
            this.panel_tcbVermelhoCritico.Name = "panel_tcbVermelhoCritico";
            // 
            // max_tcbVermelhoCritico
            // 
            resources.ApplyResources(this.max_tcbVermelhoCritico, "max_tcbVermelhoCritico");
            this.max_tcbVermelhoCritico.ForeColor = System.Drawing.Color.Black;
            this.max_tcbVermelhoCritico.Name = "max_tcbVermelhoCritico";
            // 
            // min_tcbVermelhoCritico
            // 
            resources.ApplyResources(this.min_tcbVermelhoCritico, "min_tcbVermelhoCritico");
            this.min_tcbVermelhoCritico.ForeColor = System.Drawing.Color.Black;
            this.min_tcbVermelhoCritico.Name = "min_tcbVermelhoCritico";
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.lblAviso);
            resources.ApplyResources(this.panelFooter, "panelFooter");
            this.panelFooter.ForeColor = System.Drawing.Color.Red;
            this.panelFooter.Name = "panelFooter";
            // 
            // lblAviso
            // 
            resources.ApplyResources(this.lblAviso, "lblAviso");
            this.lblAviso.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAviso.Name = "lblAviso";
            // 
            // PoryGuard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.panelHeader);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PoryGuard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PoryGuard_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tcbOpacidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbQuadrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuadrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbLuminosidadeQuadrante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuminosidadeQuadrante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbLuminosidadeTela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuminosidadeTela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVermelhoCritico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbVermelhoCritico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximo)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.panel_tcbOpacidade.ResumeLayout(false);
            this.panel_tcbOpacidade.PerformLayout();
            this.panel_tcbQuadrantes.ResumeLayout(false);
            this.panel_tcbQuadrantes.PerformLayout();
            this.panel_tcbLuminosidadeQuadrante.ResumeLayout(false);
            this.panel_tcbLuminosidadeQuadrante.PerformLayout();
            this.panel_tcbLuminosidadeTela.ResumeLayout(false);
            this.panel_tcbLuminosidadeTela.PerformLayout();
            this.tlpIntervalo.ResumeLayout(false);
            this.tlpIntervalo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimo)).EndInit();
            this.panel_tcbVermelhoCritico.ResumeLayout(false);
            this.panel_tcbVermelhoCritico.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxInicioAutomatico;
        private System.Windows.Forms.Label lblOpacidade;
        private System.Windows.Forms.TrackBar tcbOpacidade;
        private System.Windows.Forms.NumericUpDown nudOpacidade;
        private System.Windows.Forms.Label lblQuadrantes;
        private System.Windows.Forms.TrackBar tcbQuadrantes;
        private System.Windows.Forms.NumericUpDown nudQuadrantes;
        private System.Windows.Forms.Label lblLuminosidadeQuadrante;
        private System.Windows.Forms.TrackBar tcbLuminosidadeQuadrante;
        private System.Windows.Forms.NumericUpDown nudLuminosidadeQuadrante;
        private System.Windows.Forms.Label lblLuminosidadeTela;
        private System.Windows.Forms.TrackBar tcbLuminosidadeTela;
        private System.Windows.Forms.NumericUpDown nudLuminosidadeTela;
        private System.Windows.Forms.NumericUpDown nudVermelhoCritico;
        private System.Windows.Forms.TrackBar tcbVermelhoCritico;
        private System.Windows.Forms.Label lblVermelhoCritico;
        private System.Windows.Forms.Label lblMaximo;
        private System.Windows.Forms.NumericUpDown nudMaximo;
        private System.Windows.Forms.CheckBox cbxLigado;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblIntervaloFlash;
        private System.Windows.Forms.TableLayoutPanel tlpIntervalo;
        private System.Windows.Forms.Label lblMinimo;
        private System.Windows.Forms.NumericUpDown nudMinimo;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Panel panel_tcbVermelhoCritico;
        private System.Windows.Forms.Label min_tcbVermelhoCritico;
        private System.Windows.Forms.Label max_tcbVermelhoCritico;
        private System.Windows.Forms.Panel panel_tcbOpacidade;
        private System.Windows.Forms.Label max_tcbOpacidade;
        private System.Windows.Forms.Label min_tcbOpacidade;
        private System.Windows.Forms.Panel panel_tcbQuadrantes;
        private System.Windows.Forms.Label max_tcbQuadrantes;
        private System.Windows.Forms.Label min_tcbQuadrantes;
        private System.Windows.Forms.Panel panel_tcbLuminosidadeQuadrante;
        private System.Windows.Forms.Label max_tcbLuminosidadeQuadrante;
        private System.Windows.Forms.Label min_tcbLuminosidadeQuadrante;
        private System.Windows.Forms.Panel panel_tcbLuminosidadeTela;
        private System.Windows.Forms.Label max_tcbLuminosidadeTela;
        private System.Windows.Forms.Label min_tcbLuminosidadeTela;
    }
}

