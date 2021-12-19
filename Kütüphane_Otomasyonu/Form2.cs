using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kütüphane_Otomasyonu
{
    public partial class Form2 : Form
    {
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= KütüphaneBilgileri.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            label2.Text = "Hoşgeldiniz sayın " + Form6.gonderilecekveri;
            
           
        }

 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form4 yeni = new Form4();
            yeni.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form5 yeni = new Form5();
            yeni.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }
    }
}
