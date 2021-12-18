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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= KütüphaneBilgileri.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form9 kapat = new Form9();
            kapat.Close();
            Form2 ac = new Form2();
            ac.Show();
            this.Hide();

            
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string veri = "select*from Kitap";
            OleDbDataAdapter adaptor = new OleDbDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            label7.Text = ds.Tables[0].Rows.Count.ToString();




            string veri2 = "select*from Üyeler";
            OleDbDataAdapter adaptor2 = new OleDbDataAdapter(veri2, baglanti);
            DataSet ds2 = new DataSet();
            adaptor2.Fill(ds2);
            label8.Text = ds2.Tables[0].Rows.Count.ToString();

            string veri3 = "select*from Emanetler";
            OleDbDataAdapter adaptor3 = new OleDbDataAdapter(veri3, baglanti);
            DataSet ds3 = new DataSet();
            adaptor3.Fill(ds3);
            label9.Text = ds3.Tables[0].Rows.Count.ToString();

            string veri4 = "select*from Admin";
            OleDbDataAdapter adaptor4 = new OleDbDataAdapter(veri4, baglanti);
            DataSet ds4 = new DataSet();
            adaptor4.Fill(ds4);
            label10.Text = ds4.Tables[0].Rows.Count.ToString();


        }
    }
}
