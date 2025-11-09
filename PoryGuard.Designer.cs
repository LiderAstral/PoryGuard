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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PoryGuard));
            this.mswAtivo = new MaterialSkin.Controls.MaterialSwitch();
            this.mcbInicioAutomatico = new MaterialSkin.Controls.MaterialCheckbox();
            this.cardSensibilidade = new MaterialSkin.Controls.MaterialCard();
            this.tblSensibilidade = new System.Windows.Forms.TableLayoutPanel();
            this.mtbQuadrantes = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbVermelhoCritico = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbLuminosidadeQuadrante = new MaterialSkin.Controls.MaterialTextBox2();
            this.tcbQuadrantes = new Syncfusion.Windows.Forms.Tools.TrackBarEx(10, 50);
            this.mtbLuminosidadeTela = new MaterialSkin.Controls.MaterialTextBox2();
            this.tcbLuminosidadeQuadrante = new Syncfusion.Windows.Forms.Tools.TrackBarEx(5, 80);
            this.tcbVermelhoCritico = new Syncfusion.Windows.Forms.Tools.TrackBarEx(5, 80);
            this.tcbLuminosidadeTela = new Syncfusion.Windows.Forms.Tools.TrackBarEx(5, 80);
            this.lbQuadrantes = new MaterialSkin.Controls.MaterialLabel();
            this.lbVermelhoCritico = new MaterialSkin.Controls.MaterialLabel();
            this.lbLuminosidadeTela = new MaterialSkin.Controls.MaterialLabel();
            this.lbLuminosidadeQuadrante = new MaterialSkin.Controls.MaterialLabel();
            this.mlblTituloSensibilidade = new MaterialSkin.Controls.MaterialLabel();
            this.cardAjustes = new MaterialSkin.Controls.MaterialCard();
            this.tblAjustes = new System.Windows.Forms.TableLayoutPanel();
            this.mtbOpacidade = new MaterialSkin.Controls.MaterialTextBox2();
            this.tcbOpacidade = new Syncfusion.Windows.Forms.Tools.TrackBarEx(10, 100);
            this.lbOpacidade = new MaterialSkin.Controls.MaterialLabel();
            this.mlblTituloAjustes = new MaterialSkin.Controls.MaterialLabel();
            this.mlblAviso = new MaterialSkin.Controls.MaterialLabel();
            this.mlblTituloOtimizacao = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rngIntervaloFlash = new Syncfusion.Windows.Forms.Tools.RangeSlider();
            this.cardOtimizacao = new MaterialSkin.Controls.MaterialCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnResetarPadroes = new MaterialSkin.Controls.MaterialButton();
            this.cardSensibilidade.SuspendLayout();
            this.tblSensibilidade.SuspendLayout();
            this.cardAjustes.SuspendLayout();
            this.tblAjustes.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.cardOtimizacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mswAtivo
            // 
            resources.ApplyResources(this.mswAtivo, "mswAtivo");
            this.mswAtivo.Depth = 0;
            this.mswAtivo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mswAtivo.MouseState = MaterialSkin.MouseState.HOVER;
            this.mswAtivo.Name = "mswAtivo";
            this.mswAtivo.Ripple = true;
            this.mswAtivo.UseVisualStyleBackColor = true;
            this.mswAtivo.CheckedChanged += new System.EventHandler(this.cbxLigado_CheckedChanged);
            // 
            // mcbInicioAutomatico
            // 
            resources.ApplyResources(this.mcbInicioAutomatico, "mcbInicioAutomatico");
            this.mcbInicioAutomatico.Depth = 0;
            this.mcbInicioAutomatico.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mcbInicioAutomatico.MouseState = MaterialSkin.MouseState.HOVER;
            this.mcbInicioAutomatico.Name = "mcbInicioAutomatico";
            this.mcbInicioAutomatico.ReadOnly = false;
            this.mcbInicioAutomatico.Ripple = true;
            this.mcbInicioAutomatico.UseVisualStyleBackColor = true;
            this.mcbInicioAutomatico.CheckedChanged += new System.EventHandler(this.cbxLigado_CheckedChanged);
            // 
            // cardSensibilidade
            // 
            resources.ApplyResources(this.cardSensibilidade, "cardSensibilidade");
            this.cardSensibilidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardSensibilidade.Controls.Add(this.tblSensibilidade);
            this.cardSensibilidade.Controls.Add(this.mlblTituloSensibilidade);
            this.cardSensibilidade.Depth = 0;
            this.cardSensibilidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardSensibilidade.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardSensibilidade.Name = "cardSensibilidade";
            // 
            // tblSensibilidade
            // 
            resources.ApplyResources(this.tblSensibilidade, "tblSensibilidade");
            this.tblSensibilidade.Controls.Add(this.mtbQuadrantes, 2, 3);
            this.tblSensibilidade.Controls.Add(this.mtbVermelhoCritico, 2, 0);
            this.tblSensibilidade.Controls.Add(this.mtbLuminosidadeQuadrante, 2, 2);
            this.tblSensibilidade.Controls.Add(this.tcbQuadrantes, 1, 3);
            this.tblSensibilidade.Controls.Add(this.mtbLuminosidadeTela, 2, 1);
            this.tblSensibilidade.Controls.Add(this.tcbLuminosidadeQuadrante, 1, 2);
            this.tblSensibilidade.Controls.Add(this.tcbVermelhoCritico, 1, 0);
            this.tblSensibilidade.Controls.Add(this.tcbLuminosidadeTela, 1, 1);
            this.tblSensibilidade.Controls.Add(this.lbQuadrantes, 0, 3);
            this.tblSensibilidade.Controls.Add(this.lbVermelhoCritico, 0, 0);
            this.tblSensibilidade.Controls.Add(this.lbLuminosidadeTela, 0, 1);
            this.tblSensibilidade.Controls.Add(this.lbLuminosidadeQuadrante, 0, 2);
            this.tblSensibilidade.Name = "tblSensibilidade";
            // 
            // mtbQuadrantes
            // 
            resources.ApplyResources(this.mtbQuadrantes, "mtbQuadrantes");
            this.mtbQuadrantes.AnimateReadOnly = false;
            this.mtbQuadrantes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbQuadrantes.Depth = 0;
            this.mtbQuadrantes.HideSelection = false;
            this.errorProvider1.SetIconPadding(this.mtbQuadrantes, ((int)(resources.GetObject("mtbQuadrantes.IconPadding"))));
            this.mtbQuadrantes.LeadingIcon = null;
            this.mtbQuadrantes.MaxLength = 32767;
            this.mtbQuadrantes.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbQuadrantes.Name = "mtbQuadrantes";
            this.mtbQuadrantes.PasswordChar = '\0';
            this.mtbQuadrantes.ReadOnly = false;
            this.mtbQuadrantes.SelectedText = "";
            this.mtbQuadrantes.SelectionLength = 0;
            this.mtbQuadrantes.SelectionStart = 0;
            this.mtbQuadrantes.ShortcutsEnabled = false;
            this.mtbQuadrantes.TabStop = false;
            this.mtbQuadrantes.Tag = "";
            this.mtbQuadrantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbQuadrantes.TrailingIcon = null;
            this.mtbQuadrantes.UseSystemPasswordChar = false;
            this.mtbQuadrantes.TextChanged += new System.EventHandler(this.mtbQuadrantes_TextChanged);
            this.mtbQuadrantes.Validating += new System.ComponentModel.CancelEventHandler(this.mtbQuadrantes_Validating);
            // 
            // mtbVermelhoCritico
            // 
            resources.ApplyResources(this.mtbVermelhoCritico, "mtbVermelhoCritico");
            this.mtbVermelhoCritico.AnimateReadOnly = false;
            this.mtbVermelhoCritico.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbVermelhoCritico.Depth = 0;
            this.mtbVermelhoCritico.HideSelection = false;
            this.errorProvider1.SetIconPadding(this.mtbVermelhoCritico, ((int)(resources.GetObject("mtbVermelhoCritico.IconPadding"))));
            this.mtbVermelhoCritico.LeadingIcon = null;
            this.mtbVermelhoCritico.MaxLength = 32767;
            this.mtbVermelhoCritico.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbVermelhoCritico.Name = "mtbVermelhoCritico";
            this.mtbVermelhoCritico.PasswordChar = '\0';
            this.mtbVermelhoCritico.ReadOnly = false;
            this.mtbVermelhoCritico.SelectedText = "";
            this.mtbVermelhoCritico.SelectionLength = 0;
            this.mtbVermelhoCritico.SelectionStart = 0;
            this.mtbVermelhoCritico.ShortcutsEnabled = false;
            this.mtbVermelhoCritico.TabStop = false;
            this.mtbVermelhoCritico.Tag = "";
            this.mtbVermelhoCritico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbVermelhoCritico.TrailingIcon = null;
            this.mtbVermelhoCritico.UseSystemPasswordChar = false;
            this.mtbVermelhoCritico.TextChanged += new System.EventHandler(this.mtbVermelhoCritico_TextChanged);
            this.mtbVermelhoCritico.Validating += new System.ComponentModel.CancelEventHandler(this.mtbVermelhoCritico_Validating);
            // 
            // mtbLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.mtbLuminosidadeQuadrante, "mtbLuminosidadeQuadrante");
            this.mtbLuminosidadeQuadrante.AnimateReadOnly = false;
            this.mtbLuminosidadeQuadrante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbLuminosidadeQuadrante.Depth = 0;
            this.mtbLuminosidadeQuadrante.HideSelection = false;
            this.errorProvider1.SetIconPadding(this.mtbLuminosidadeQuadrante, ((int)(resources.GetObject("mtbLuminosidadeQuadrante.IconPadding"))));
            this.mtbLuminosidadeQuadrante.LeadingIcon = null;
            this.mtbLuminosidadeQuadrante.MaxLength = 32767;
            this.mtbLuminosidadeQuadrante.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbLuminosidadeQuadrante.Name = "mtbLuminosidadeQuadrante";
            this.mtbLuminosidadeQuadrante.PasswordChar = '\0';
            this.mtbLuminosidadeQuadrante.ReadOnly = false;
            this.mtbLuminosidadeQuadrante.SelectedText = "";
            this.mtbLuminosidadeQuadrante.SelectionLength = 0;
            this.mtbLuminosidadeQuadrante.SelectionStart = 0;
            this.mtbLuminosidadeQuadrante.ShortcutsEnabled = false;
            this.mtbLuminosidadeQuadrante.TabStop = false;
            this.mtbLuminosidadeQuadrante.Tag = "";
            this.mtbLuminosidadeQuadrante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbLuminosidadeQuadrante.TrailingIcon = null;
            this.mtbLuminosidadeQuadrante.UseSystemPasswordChar = false;
            this.mtbLuminosidadeQuadrante.TextChanged += new System.EventHandler(this.mtbLuminosidadeQuadrante_TextChanged);
            this.mtbLuminosidadeQuadrante.Validating += new System.ComponentModel.CancelEventHandler(this.mtbLuminosidadeQuadrante_Validating);
            // 
            // tcbQuadrantes
            // 
            resources.ApplyResources(this.tcbQuadrantes, "tcbQuadrantes");
            this.tcbQuadrantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tcbQuadrantes.BeforeTouchSize = new System.Drawing.Size(424, 44);
            this.tcbQuadrantes.CanApplyTheme = false;
            this.tcbQuadrantes.DecreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbQuadrantes.IncreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbQuadrantes.Name = "tcbQuadrantes";
            this.tcbQuadrantes.SliderSize = new System.Drawing.Size(10, 20);
            this.tcbQuadrantes.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Metro;
            this.tcbQuadrantes.ThemeName = "Metro";
            this.tcbQuadrantes.ThemeStyle.ShowDivider = false;
            this.tcbQuadrantes.TimerInterval = 100;
            this.tcbQuadrantes.Transparent = true;
            this.tcbQuadrantes.Value = 10;
            this.tcbQuadrantes.Scroll += new System.EventHandler(this.tcbQuadrantes_Scroll);
            // 
            // mtbLuminosidadeTela
            // 
            resources.ApplyResources(this.mtbLuminosidadeTela, "mtbLuminosidadeTela");
            this.mtbLuminosidadeTela.AnimateReadOnly = false;
            this.mtbLuminosidadeTela.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbLuminosidadeTela.Depth = 0;
            this.mtbLuminosidadeTela.HideSelection = false;
            this.errorProvider1.SetIconPadding(this.mtbLuminosidadeTela, ((int)(resources.GetObject("mtbLuminosidadeTela.IconPadding"))));
            this.mtbLuminosidadeTela.LeadingIcon = null;
            this.mtbLuminosidadeTela.MaxLength = 32767;
            this.mtbLuminosidadeTela.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbLuminosidadeTela.Name = "mtbLuminosidadeTela";
            this.mtbLuminosidadeTela.PasswordChar = '\0';
            this.mtbLuminosidadeTela.ReadOnly = false;
            this.mtbLuminosidadeTela.SelectedText = "";
            this.mtbLuminosidadeTela.SelectionLength = 0;
            this.mtbLuminosidadeTela.SelectionStart = 0;
            this.mtbLuminosidadeTela.ShortcutsEnabled = false;
            this.mtbLuminosidadeTela.TabStop = false;
            this.mtbLuminosidadeTela.Tag = "";
            this.mtbLuminosidadeTela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbLuminosidadeTela.TrailingIcon = null;
            this.mtbLuminosidadeTela.UseSystemPasswordChar = false;
            this.mtbLuminosidadeTela.TextChanged += new System.EventHandler(this.mtbLuminosidadeTela_TextChanged);
            this.mtbLuminosidadeTela.Validating += new System.ComponentModel.CancelEventHandler(this.mtbLuminosidadeTela_Validating);
            // 
            // tcbLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.tcbLuminosidadeQuadrante, "tcbLuminosidadeQuadrante");
            this.tcbLuminosidadeQuadrante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tcbLuminosidadeQuadrante.BeforeTouchSize = new System.Drawing.Size(424, 44);
            this.tcbLuminosidadeQuadrante.CanApplyTheme = false;
            this.tcbLuminosidadeQuadrante.DecreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbLuminosidadeQuadrante.IncreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbLuminosidadeQuadrante.Name = "tcbLuminosidadeQuadrante";
            this.tcbLuminosidadeQuadrante.SliderSize = new System.Drawing.Size(10, 20);
            this.tcbLuminosidadeQuadrante.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Metro;
            this.tcbLuminosidadeQuadrante.ThemeName = "Metro";
            this.tcbLuminosidadeQuadrante.ThemeStyle.ShowDivider = false;
            this.tcbLuminosidadeQuadrante.TimerInterval = 100;
            this.tcbLuminosidadeQuadrante.Transparent = true;
            this.tcbLuminosidadeQuadrante.Value = 5;
            this.tcbLuminosidadeQuadrante.Scroll += new System.EventHandler(this.tcbLuminosidadeQuadrante_Scroll);
            // 
            // tcbVermelhoCritico
            // 
            resources.ApplyResources(this.tcbVermelhoCritico, "tcbVermelhoCritico");
            this.tcbVermelhoCritico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tcbVermelhoCritico.BeforeTouchSize = new System.Drawing.Size(424, 44);
            this.tcbVermelhoCritico.CanApplyTheme = false;
            this.tcbVermelhoCritico.DecreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbVermelhoCritico.IncreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbVermelhoCritico.Name = "tcbVermelhoCritico";
            this.tcbVermelhoCritico.SliderSize = new System.Drawing.Size(10, 20);
            this.tcbVermelhoCritico.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Metro;
            this.tcbVermelhoCritico.ThemeName = "Metro";
            this.tcbVermelhoCritico.ThemeStyle.ShowDivider = false;
            this.tcbVermelhoCritico.TimerInterval = 100;
            this.tcbVermelhoCritico.Transparent = true;
            this.tcbVermelhoCritico.Value = 5;
            this.tcbVermelhoCritico.Scroll += new System.EventHandler(this.tcbVermelhoCritico_Scroll);
            // 
            // tcbLuminosidadeTela
            // 
            resources.ApplyResources(this.tcbLuminosidadeTela, "tcbLuminosidadeTela");
            this.tcbLuminosidadeTela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tcbLuminosidadeTela.BeforeTouchSize = new System.Drawing.Size(424, 44);
            this.tcbLuminosidadeTela.CanApplyTheme = false;
            this.tcbLuminosidadeTela.DecreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbLuminosidadeTela.IncreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbLuminosidadeTela.Name = "tcbLuminosidadeTela";
            this.tcbLuminosidadeTela.SliderSize = new System.Drawing.Size(10, 20);
            this.tcbLuminosidadeTela.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Metro;
            this.tcbLuminosidadeTela.ThemeName = "Metro";
            this.tcbLuminosidadeTela.ThemeStyle.ShowDivider = false;
            this.tcbLuminosidadeTela.TimerInterval = 100;
            this.tcbLuminosidadeTela.Transparent = true;
            this.tcbLuminosidadeTela.Value = 5;
            this.tcbLuminosidadeTela.Scroll += new System.EventHandler(this.tcbLuminosidadeTela_Scroll);
            // 
            // lbQuadrantes
            // 
            resources.ApplyResources(this.lbQuadrantes, "lbQuadrantes");
            this.lbQuadrantes.Depth = 0;
            this.lbQuadrantes.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbQuadrantes.Name = "lbQuadrantes";
            // 
            // lbVermelhoCritico
            // 
            resources.ApplyResources(this.lbVermelhoCritico, "lbVermelhoCritico");
            this.lbVermelhoCritico.Depth = 0;
            this.lbVermelhoCritico.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbVermelhoCritico.Name = "lbVermelhoCritico";
            // 
            // lbLuminosidadeTela
            // 
            resources.ApplyResources(this.lbLuminosidadeTela, "lbLuminosidadeTela");
            this.lbLuminosidadeTela.Depth = 0;
            this.lbLuminosidadeTela.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbLuminosidadeTela.Name = "lbLuminosidadeTela";
            // 
            // lbLuminosidadeQuadrante
            // 
            resources.ApplyResources(this.lbLuminosidadeQuadrante, "lbLuminosidadeQuadrante");
            this.lbLuminosidadeQuadrante.Depth = 0;
            this.lbLuminosidadeQuadrante.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbLuminosidadeQuadrante.Name = "lbLuminosidadeQuadrante";
            // 
            // mlblTituloSensibilidade
            // 
            resources.ApplyResources(this.mlblTituloSensibilidade, "mlblTituloSensibilidade");
            this.mlblTituloSensibilidade.BackColor = System.Drawing.Color.White;
            this.mlblTituloSensibilidade.Depth = 0;
            this.mlblTituloSensibilidade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mlblTituloSensibilidade.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.mlblTituloSensibilidade.ForeColor = System.Drawing.Color.Black;
            this.mlblTituloSensibilidade.HighEmphasis = true;
            this.mlblTituloSensibilidade.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlblTituloSensibilidade.Name = "mlblTituloSensibilidade";
            // 
            // cardAjustes
            // 
            resources.ApplyResources(this.cardAjustes, "cardAjustes");
            this.cardAjustes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardAjustes.Controls.Add(this.tblAjustes);
            this.cardAjustes.Controls.Add(this.mlblTituloAjustes);
            this.cardAjustes.Depth = 0;
            this.cardAjustes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardAjustes.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardAjustes.Name = "cardAjustes";
            // 
            // tblAjustes
            // 
            resources.ApplyResources(this.tblAjustes, "tblAjustes");
            this.tblAjustes.Controls.Add(this.mtbOpacidade, 2, 0);
            this.tblAjustes.Controls.Add(this.tcbOpacidade, 1, 0);
            this.tblAjustes.Controls.Add(this.lbOpacidade, 0, 0);
            this.tblAjustes.Name = "tblAjustes";
            // 
            // mtbOpacidade
            // 
            resources.ApplyResources(this.mtbOpacidade, "mtbOpacidade");
            this.mtbOpacidade.AnimateReadOnly = false;
            this.mtbOpacidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbOpacidade.Depth = 0;
            this.mtbOpacidade.HideSelection = false;
            this.errorProvider1.SetIconPadding(this.mtbOpacidade, ((int)(resources.GetObject("mtbOpacidade.IconPadding"))));
            this.mtbOpacidade.LeadingIcon = null;
            this.mtbOpacidade.MaxLength = 32767;
            this.mtbOpacidade.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbOpacidade.Name = "mtbOpacidade";
            this.mtbOpacidade.PasswordChar = '\0';
            this.mtbOpacidade.ReadOnly = false;
            this.mtbOpacidade.SelectedText = "";
            this.mtbOpacidade.SelectionLength = 0;
            this.mtbOpacidade.SelectionStart = 0;
            this.mtbOpacidade.ShortcutsEnabled = false;
            this.mtbOpacidade.TabStop = false;
            this.mtbOpacidade.Tag = "";
            this.mtbOpacidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbOpacidade.TrailingIcon = null;
            this.mtbOpacidade.UseSystemPasswordChar = false;
            this.mtbOpacidade.TextChanged += new System.EventHandler(this.mtbOpacidade_TextChanged);
            this.mtbOpacidade.Validating += new System.ComponentModel.CancelEventHandler(this.mtbOpacidade_Validating);
            // 
            // tcbOpacidade
            // 
            resources.ApplyResources(this.tcbOpacidade, "tcbOpacidade");
            this.tcbOpacidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tcbOpacidade.BeforeTouchSize = new System.Drawing.Size(424, 44);
            this.tcbOpacidade.CanApplyTheme = false;
            this.tcbOpacidade.DecreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbOpacidade.IncreaseButtonSize = new System.Drawing.Size(30, 30);
            this.tcbOpacidade.Name = "tcbOpacidade";
            this.tcbOpacidade.SliderSize = new System.Drawing.Size(10, 20);
            this.tcbOpacidade.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Metro;
            this.tcbOpacidade.ThemeName = "Metro";
            this.tcbOpacidade.ThemeStyle.ShowDivider = false;
            this.tcbOpacidade.TimerInterval = 100;
            this.tcbOpacidade.Transparent = true;
            this.tcbOpacidade.Value = 10;
            this.tcbOpacidade.Scroll += new System.EventHandler(this.tcbOpacidade_Scroll);
            // 
            // lbOpacidade
            // 
            resources.ApplyResources(this.lbOpacidade, "lbOpacidade");
            this.lbOpacidade.Depth = 0;
            this.lbOpacidade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbOpacidade.Name = "lbOpacidade";
            // 
            // mlblTituloAjustes
            // 
            resources.ApplyResources(this.mlblTituloAjustes, "mlblTituloAjustes");
            this.mlblTituloAjustes.BackColor = System.Drawing.Color.White;
            this.mlblTituloAjustes.Depth = 0;
            this.mlblTituloAjustes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mlblTituloAjustes.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.mlblTituloAjustes.ForeColor = System.Drawing.Color.Black;
            this.mlblTituloAjustes.HighEmphasis = true;
            this.mlblTituloAjustes.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlblTituloAjustes.Name = "mlblTituloAjustes";
            // 
            // mlblAviso
            // 
            resources.ApplyResources(this.mlblAviso, "mlblAviso");
            this.mlblAviso.Depth = 0;
            this.mlblAviso.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mlblAviso.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.mlblAviso.ForeColor = System.Drawing.Color.IndianRed;
            this.mlblAviso.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlblAviso.Name = "mlblAviso";
            // 
            // mlblTituloOtimizacao
            // 
            resources.ApplyResources(this.mlblTituloOtimizacao, "mlblTituloOtimizacao");
            this.mlblTituloOtimizacao.BackColor = System.Drawing.Color.White;
            this.mlblTituloOtimizacao.Depth = 0;
            this.mlblTituloOtimizacao.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mlblTituloOtimizacao.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.mlblTituloOtimizacao.HighEmphasis = true;
            this.mlblTituloOtimizacao.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlblTituloOtimizacao.Name = "mlblTituloOtimizacao";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.rngIntervaloFlash, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // rngIntervaloFlash
            // 
            this.rngIntervaloFlash.BeforeTouchSize = new System.Drawing.Size(824, 55);
            this.rngIntervaloFlash.CanApplyTheme = false;
            this.rngIntervaloFlash.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.rngIntervaloFlash, "rngIntervaloFlash");
            this.rngIntervaloFlash.ForeColor = System.Drawing.Color.Black;
            this.rngIntervaloFlash.HighlightedThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.rngIntervaloFlash.Maximum = 30;
            this.rngIntervaloFlash.Minimum = 3;
            this.rngIntervaloFlash.Name = "rngIntervaloFlash";
            this.rngIntervaloFlash.PushedThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(86)))), ((int)(((byte)(148)))));
            this.rngIntervaloFlash.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.rngIntervaloFlash.ShowLabels = true;
            this.rngIntervaloFlash.SliderMax = 30;
            this.rngIntervaloFlash.SliderMin = 3;
            this.rngIntervaloFlash.SliderSize = new System.Drawing.Size(8, 21);
            this.rngIntervaloFlash.ThemeName = "Metro";
            this.rngIntervaloFlash.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.rngIntervaloFlash.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.rngIntervaloFlash.VisualStyle = Syncfusion.Windows.Forms.Tools.RangeSlider.RangeSliderStyle.Metro;
            // 
            // cardOtimizacao
            // 
            resources.ApplyResources(this.cardOtimizacao, "cardOtimizacao");
            this.cardOtimizacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardOtimizacao.Controls.Add(this.materialLabel1);
            this.cardOtimizacao.Controls.Add(this.tableLayoutPanel3);
            this.cardOtimizacao.Controls.Add(this.mlblTituloOtimizacao);
            this.cardOtimizacao.Depth = 0;
            this.cardOtimizacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardOtimizacao.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardOtimizacao.Name = "cardOtimizacao";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // materialLabel1
            // 
            resources.ApplyResources(this.materialLabel1, "materialLabel1");
            this.materialLabel1.Depth = 0;
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.SubtleEmphasis;
            this.errorProvider1.SetIconAlignment(this.materialLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("materialLabel1.IconAlignment"))));
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            // 
            // btnResetarPadroes
            // 
            resources.ApplyResources(this.btnResetarPadroes, "btnResetarPadroes");
            this.btnResetarPadroes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnResetarPadroes.Depth = 0;
            this.btnResetarPadroes.HighEmphasis = true;
            this.btnResetarPadroes.Icon = null;
            this.btnResetarPadroes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnResetarPadroes.Name = "btnResetarPadroes";
            this.btnResetarPadroes.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnResetarPadroes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnResetarPadroes.UseAccentColor = true;
            this.btnResetarPadroes.UseVisualStyleBackColor = true;
            // 
            // PoryGuard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnResetarPadroes);
            this.Controls.Add(this.mlblAviso);
            this.Controls.Add(this.cardAjustes);
            this.Controls.Add(this.cardSensibilidade);
            this.Controls.Add(this.cardOtimizacao);
            this.Controls.Add(this.mcbInicioAutomatico);
            this.Controls.Add(this.mswAtivo);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.MaximizeBox = false;
            this.Name = "PoryGuard";
            this.Sizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PoryGuard_FormClosing);
            this.cardSensibilidade.ResumeLayout(false);
            this.cardSensibilidade.PerformLayout();
            this.tblSensibilidade.ResumeLayout(false);
            this.tblSensibilidade.PerformLayout();
            this.cardAjustes.ResumeLayout(false);
            this.cardAjustes.PerformLayout();
            this.tblAjustes.ResumeLayout(false);
            this.tblAjustes.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.cardOtimizacao.ResumeLayout(false);
            this.cardOtimizacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSwitch mswAtivo;
        private MaterialSkin.Controls.MaterialCheckbox mcbInicioAutomatico;
        private MaterialSkin.Controls.MaterialCard cardSensibilidade;
        private MaterialSkin.Controls.MaterialCard cardAjustes;
        private MaterialSkin.Controls.MaterialLabel mlblTituloSensibilidade;
        private MaterialSkin.Controls.MaterialLabel mlblTituloAjustes;
        private System.Windows.Forms.TableLayoutPanel tblSensibilidade;
        private System.Windows.Forms.TableLayoutPanel tblAjustes;
        private MaterialSkin.Controls.MaterialLabel mlblAviso;
        private MaterialSkin.Controls.MaterialLabel lbVermelhoCritico;
        private MaterialSkin.Controls.MaterialLabel lbLuminosidadeTela;
        private MaterialSkin.Controls.MaterialLabel lbLuminosidadeQuadrante;
        private MaterialSkin.Controls.MaterialLabel lbQuadrantes;
        private MaterialSkin.Controls.MaterialLabel lbOpacidade;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx tcbLuminosidadeTela;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx tcbLuminosidadeQuadrante;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx tcbVermelhoCritico;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx tcbOpacidade;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx tcbQuadrantes;
        private MaterialSkin.Controls.MaterialTextBox2 mtbVermelhoCritico;
        private MaterialSkin.Controls.MaterialLabel mlblTituloOtimizacao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Syncfusion.Windows.Forms.Tools.RangeSlider rngIntervaloFlash;
        private MaterialSkin.Controls.MaterialCard cardOtimizacao;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialTextBox2 mtbQuadrantes;
        private MaterialSkin.Controls.MaterialTextBox2 mtbLuminosidadeQuadrante;
        private MaterialSkin.Controls.MaterialTextBox2 mtbLuminosidadeTela;
        private MaterialSkin.Controls.MaterialTextBox2 mtbOpacidade;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btnResetarPadroes;
    }
}

