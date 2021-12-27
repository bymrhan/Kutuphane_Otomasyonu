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
            Init_Data();
        }
        public static string gonderilecekveri;
        public static string gonderilecekveri2;
        private void button1_Click(object sender, EventArgs e)
        {
            Save_Data();
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

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void Init_Data()
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    textBox1.Text = Properties.Settings.Default.UserName;
                    textBox2.Text = Properties.Settings.Default.sifre;
                    chcRememberMe.Checked = true;
                }
                else
                {
                    textBox1.Text = Properties.Settings.Default.UserName;
                    textBox2.Text = Properties.Settings.Default.sifre;
                }
            }
        }

        private void Save_Data()
        {
            if (chcRememberMe.Checked)
            {
                Properties.Settings.Default.UserName = textBox1.Text.Trim();
                Properties.Settings.Default.sifre = textBox2.Text.Trim();
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.sifre = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
