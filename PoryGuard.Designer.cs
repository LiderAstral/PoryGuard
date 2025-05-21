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
            this.cbxLigado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMinimo = new System.Windows.Forms.NumericUpDown();
            this.nudMaximo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tcbVermelhoCritico = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudVermelhoCritico = new System.Windows.Forms.NumericUpDown();
            this.nudLuminosidadeTela = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tcbLuminosidadeTela = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.nudLuminosidadeQuadrante = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tcbLuminosidadeQuadrante = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.nudQuadrantes = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tcbQuadrantes = new System.Windows.Forms.TrackBar();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbVermelhoCritico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVermelhoCritico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuminosidadeTela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbLuminosidadeTela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuminosidadeQuadrante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbLuminosidadeQuadrante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuadrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbQuadrantes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxLigado
            // 
            this.cbxLigado.AutoSize = true;
            this.cbxLigado.Checked = true;
            this.cbxLigado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxLigado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLigado.Location = new System.Drawing.Point(71, 58);
            this.cbxLigado.Name = "cbxLigado";
            this.cbxLigado.Size = new System.Drawing.Size(126, 24);
            this.cbxLigado.TabIndex = 0;
            this.cbxLigado.Text = "Em Execução";
            this.cbxLigado.UseVisualStyleBackColor = true;
            this.cbxLigado.CheckedChanged += new System.EventHandler(this.cbxLigado_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Intervalo de Flash:";
            // 
            // nudMinimo
            // 
            this.nudMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinimo.Location = new System.Drawing.Point(212, 123);
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
            this.nudMinimo.Size = new System.Drawing.Size(50, 22);
            this.nudMinimo.TabIndex = 3;
            this.nudMinimo.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMinimo.ValueChanged += new System.EventHandler(this.nudMinimo_ValueChanged);
            // 
            // nudMaximo
            // 
            this.nudMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaximo.Location = new System.Drawing.Point(297, 123);
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
            this.nudMaximo.Size = new System.Drawing.Size(49, 22);
            this.nudMaximo.TabIndex = 4;
            this.nudMaximo.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudMaximo.ValueChanged += new System.EventHandler(this.nudMaximo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mín.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(302, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Máx.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(104, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Limiar de Vermelho Crítico:";
            // 
            // tcbVermelhoCritico
            // 
            this.tcbVermelhoCritico.Location = new System.Drawing.Point(297, 195);
            this.tcbVermelhoCritico.Maximum = 80;
            this.tcbVermelhoCritico.Minimum = 5;
            this.tcbVermelhoCritico.Name = "tcbVermelhoCritico";
            this.tcbVermelhoCritico.Size = new System.Drawing.Size(195, 45);
            this.tcbVermelhoCritico.TabIndex = 8;
            this.tcbVermelhoCritico.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbVermelhoCritico.Value = 20;
            this.tcbVermelhoCritico.Scroll += new System.EventHandler(this.tcbVermelhoCritico_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(303, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "5%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(452, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "80%";
            // 
            // nudVermelhoCritico
            // 
            this.nudVermelhoCritico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudVermelhoCritico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nudVermelhoCritico.Location = new System.Drawing.Point(498, 193);
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
            this.nudVermelhoCritico.Size = new System.Drawing.Size(35, 22);
            this.nudVermelhoCritico.TabIndex = 11;
            this.nudVermelhoCritico.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudVermelhoCritico.ValueChanged += new System.EventHandler(this.nudVermelhoCritico_ValueChanged);
            // 
            // nudLuminosidadeTela
            // 
            this.nudLuminosidadeTela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLuminosidadeTela.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nudLuminosidadeTela.Location = new System.Drawing.Point(498, 268);
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
            this.nudLuminosidadeTela.Size = new System.Drawing.Size(35, 22);
            this.nudLuminosidadeTela.TabIndex = 16;
            this.nudLuminosidadeTela.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLuminosidadeTela.ValueChanged += new System.EventHandler(this.nudLuminosidadeTela_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(452, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "80%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(303, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "5%";
            // 
            // tcbLuminosidadeTela
            // 
            this.tcbLuminosidadeTela.Location = new System.Drawing.Point(297, 270);
            this.tcbLuminosidadeTela.Maximum = 80;
            this.tcbLuminosidadeTela.Minimum = 5;
            this.tcbLuminosidadeTela.Name = "tcbLuminosidadeTela";
            this.tcbLuminosidadeTela.Size = new System.Drawing.Size(195, 45);
            this.tcbLuminosidadeTela.TabIndex = 13;
            this.tcbLuminosidadeTela.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbLuminosidadeTela.Value = 20;
            this.tcbLuminosidadeTela.Scroll += new System.EventHandler(this.tcbLuminosidadeTela_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(65, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(236, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Limiar de Luminosidade da Tela:";
            // 
            // nudLuminosidadeQuadrante
            // 
            this.nudLuminosidadeQuadrante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLuminosidadeQuadrante.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nudLuminosidadeQuadrante.Location = new System.Drawing.Point(498, 344);
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
            this.nudLuminosidadeQuadrante.Size = new System.Drawing.Size(35, 22);
            this.nudLuminosidadeQuadrante.TabIndex = 21;
            this.nudLuminosidadeQuadrante.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLuminosidadeQuadrante.ValueChanged += new System.EventHandler(this.nudLuminosidadeQuadrante_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(452, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 20;
            this.label10.Text = "80%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(303, 373);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 18);
            this.label11.TabIndex = 19;
            this.label11.Text = "5%";
            // 
            // tcbLuminosidadeQuadrante
            // 
            this.tcbLuminosidadeQuadrante.Location = new System.Drawing.Point(297, 346);
            this.tcbLuminosidadeQuadrante.Maximum = 80;
            this.tcbLuminosidadeQuadrante.Minimum = 5;
            this.tcbLuminosidadeQuadrante.Name = "tcbLuminosidadeQuadrante";
            this.tcbLuminosidadeQuadrante.Size = new System.Drawing.Size(195, 45);
            this.tcbLuminosidadeQuadrante.TabIndex = 18;
            this.tcbLuminosidadeQuadrante.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbLuminosidadeQuadrante.Value = 20;
            this.tcbLuminosidadeQuadrante.Scroll += new System.EventHandler(this.tcbLuminosidadeQuadrante_Scroll);
            // 
            // label12
            // 
            this.label12.AutoEllipsis = true;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(57, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(244, 40);
            this.label12.TabIndex = 17;
            this.label12.Text = "Limiar de Luminosidade \ndo Quadrante de Monitoramento:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nudQuadrantes
            // 
            this.nudQuadrantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuadrantes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nudQuadrantes.Location = new System.Drawing.Point(498, 420);
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
            this.nudQuadrantes.Size = new System.Drawing.Size(35, 22);
            this.nudQuadrantes.TabIndex = 26;
            this.nudQuadrantes.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudQuadrantes.ValueChanged += new System.EventHandler(this.nudQuadrantes_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(465, 444);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 18);
            this.label13.TabIndex = 25;
            this.label13.Text = "50";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(302, 444);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 18);
            this.label14.TabIndex = 24;
            this.label14.Text = "10";
            // 
            // tcbQuadrantes
            // 
            this.tcbQuadrantes.Location = new System.Drawing.Point(297, 422);
            this.tcbQuadrantes.Maximum = 50;
            this.tcbQuadrantes.Minimum = 10;
            this.tcbQuadrantes.Name = "tcbQuadrantes";
            this.tcbQuadrantes.Size = new System.Drawing.Size(195, 45);
            this.tcbQuadrantes.TabIndex = 23;
            this.tcbQuadrantes.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbQuadrantes.Value = 30;
            this.tcbQuadrantes.Scroll += new System.EventHandler(this.tcbQuadrantes_Scroll);
            // 
            // label15
            // 
            this.label15.AutoEllipsis = true;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 420);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(294, 20);
            this.label15.TabIndex = 22;
            this.label15.Text = "Quadrantes na Maior Dimensão da Tela:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PoryGuard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.nudQuadrantes);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tcbQuadrantes);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nudLuminosidadeQuadrante);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tcbLuminosidadeQuadrante);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudLuminosidadeTela);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tcbLuminosidadeTela);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudVermelhoCritico);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tcbVermelhoCritico);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudMaximo);
            this.Controls.Add(this.nudMinimo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxLigado);
            this.Name = "PoryGuard";
            this.Text = "PoryGuard";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbVermelhoCritico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVermelhoCritico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuminosidadeTela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbLuminosidadeTela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuminosidadeQuadrante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbLuminosidadeQuadrante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuadrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbQuadrantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxLigado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMinimo;
        private System.Windows.Forms.NumericUpDown nudMaximo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tcbVermelhoCritico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudVermelhoCritico;
        private System.Windows.Forms.NumericUpDown nudLuminosidadeTela;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tcbLuminosidadeTela;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudLuminosidadeQuadrante;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar tcbLuminosidadeQuadrante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudQuadrantes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar tcbQuadrantes;
        private System.Windows.Forms.Label label15;
    }
}

