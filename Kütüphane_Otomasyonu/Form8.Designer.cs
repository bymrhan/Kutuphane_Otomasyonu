
namespace Kütüphane_Otomasyonu
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.uye1 = new Kütüphane_Otomasyonu.Uye();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Forte", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(114, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 52);
            this.label7.TabIndex = 30;
            this.label7.Text = "Üye Ol";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Kütüphane_Otomasyonu.Properties.Resources.close;
            this.pictureBox4.Location = new System.Drawing.Point(267, 419);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 31;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // uye1
            // 
            this.uye1.BackColor = System.Drawing.SystemColors.Control;
            this.uye1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uye1.BackgroundImage")));
            this.uye1.Location = new System.Drawing.Point(17, 12);
            this.uye1.Name = "uye1";
            this.uye1.Size = new System.Drawing.Size(365, 427);
            this.uye1.TabIndex = 0;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kütüphane_Otomasyonu.Properties.Resources.dd64da585bc57cb05e5fd4d8ce873f57;
            this.ClientSize = new System.Drawing.Size(394, 470);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.uye1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form8";
            this.Text = "Üye Ol";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Uye uye1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}