using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string KullaniciAdi = textBox1.Text;
            int Sifre = Convert.ToInt16(textBox2.Text);

            bool sonuc = B10.Üye(KullaniciAdi, Sifre);

            if (sonuc == false)
            {
                MessageBox.Show("Kullanıcı adı yada şifre yanlış!!!");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                Form7 kapat = new Form7();
                kapat.Close();
                Form2 yeni = new Form2();
                yeni.Show();
                this.Hide();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            yeni.Show();
            this.Hide();
        }
    }
}
