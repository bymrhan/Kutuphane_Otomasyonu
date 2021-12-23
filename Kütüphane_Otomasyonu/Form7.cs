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
        public static string gonderilecekveri;
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
                gonderilecekveri = textBox1.Text;
                Form10 yeni = new Form10();
                yeni.Show();
                this.Hide();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form7 kapat = new Form7();
            kapat.Close();
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            yeni.Show();
            this.Hide();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
