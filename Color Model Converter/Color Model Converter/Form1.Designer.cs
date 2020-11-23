namespace Color_Model_Converter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBox_rgb1 = new System.Windows.Forms.PictureBox();
            this.btn_buscar_imagem = new System.Windows.Forms.Button();
            this.btn_achar_assinatura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_rgb1)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox_rgb1
            // 
            this.picBox_rgb1.Location = new System.Drawing.Point(198, 69);
            this.picBox_rgb1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBox_rgb1.Name = "picBox_rgb1";
            this.picBox_rgb1.Size = new System.Drawing.Size(309, 310);
            this.picBox_rgb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_rgb1.TabIndex = 0;
            this.picBox_rgb1.TabStop = false;
            // 
            // btn_buscar_imagem
            // 
            this.btn_buscar_imagem.AutoSize = true;
            this.btn_buscar_imagem.Location = new System.Drawing.Point(18, 19);
            this.btn_buscar_imagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_buscar_imagem.Name = "btn_buscar_imagem";
            this.btn_buscar_imagem.Size = new System.Drawing.Size(172, 42);
            this.btn_buscar_imagem.TabIndex = 2;
            this.btn_buscar_imagem.TabStop = false;
            this.btn_buscar_imagem.Text = "Buscar imagem";
            this.btn_buscar_imagem.UseVisualStyleBackColor = true;
            this.btn_buscar_imagem.Click += new System.EventHandler(this.btn_buscar_imagem_Click);
            // 
            // btn_achar_assinatura
            // 
            this.btn_achar_assinatura.AutoSize = true;
            this.btn_achar_assinatura.Location = new System.Drawing.Point(198, 19);
            this.btn_achar_assinatura.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_achar_assinatura.Name = "btn_achar_assinatura";
            this.btn_achar_assinatura.Size = new System.Drawing.Size(309, 42);
            this.btn_achar_assinatura.TabIndex = 8;
            this.btn_achar_assinatura.TabStop = false;
            this.btn_achar_assinatura.Text = "Achar assinatura";
            this.btn_achar_assinatura.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 412);
            this.Controls.Add(this.btn_achar_assinatura);
            this.Controls.Add(this.btn_buscar_imagem);
            this.Controls.Add(this.picBox_rgb1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBox_rgb1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_rgb1;
        private System.Windows.Forms.Button btn_buscar_imagem;
        private System.Windows.Forms.Button btn_achar_assinatura;
    }
}

