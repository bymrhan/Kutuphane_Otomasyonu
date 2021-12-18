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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public static string gonderilecekveri;
        public static string gonderilecekveri2;
        private void button1_Click(object sender, EventArgs e)
        {
            string KullaniciAdi = textBox1.Text;
            int Sifre = Convert.ToInt16(textBox2.Text);

            bool sonuc = B10.Admin(KullaniciAdi, Sifre);

            if (sonuc == false)
            {
                MessageBox.Show("Kullanıcı adı yada şifre yanlış!!!");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                Form1 kapat = new Form1();
                kapat.Close();
                gonderilecekveri = textBox1.Text;
                gonderilecekveri2 = textBox2.Text;

                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form6 kapat = new Form6();
            kapat.Close();
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
