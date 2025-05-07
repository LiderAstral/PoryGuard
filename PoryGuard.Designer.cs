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
            this.SuspendLayout();
            // 
            // cbxLigado
            // 
            this.cbxLigado.AutoSize = true;
            this.cbxLigado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLigado.Location = new System.Drawing.Point(41, 29);
            this.cbxLigado.Name = "cbxLigado";
            this.cbxLigado.Size = new System.Drawing.Size(126, 24);
            this.cbxLigado.TabIndex = 0;
            this.cbxLigado.Text = "Em Execução";
            this.cbxLigado.UseVisualStyleBackColor = true;
            this.cbxLigado.CheckedChanged += new System.EventHandler(this.cbxLigado_CheckedChanged);
            // 
            // PoryGuard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxLigado);
            this.Name = "PoryGuard";
            this.Text = "PoryGuard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxLigado;
    }
}

