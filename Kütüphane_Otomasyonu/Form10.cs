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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();

        }
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= KütüphaneBilgileri.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);
        OleDbDataReader dr;
        OleDbDataReader drr;
        string uyeno;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form10 kapat = new Form10();
            kapat.Close();
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
            
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            label3.Text += Form7.gonderilecekveri;
            baglanti.Open();
            string veri = "select*from Kitap";
            OleDbDataAdapter adaptor = new OleDbDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string kullanici = Form7.gonderilecekveri;
            string veriuye = "select * from Üyeler where Üye_kadi like '%" + kullanici + "%'";
            OleDbCommand komutuye = new OleDbCommand(veriuye, baglanti);
            OleDbDataAdapter adaptoruye = new OleDbDataAdapter(komutuye);
            komutuye.ExecuteNonQuery();
            dr = komutuye.ExecuteReader();
            while (dr.Read())
            {
                uyeno = dr["ÜyeNo"].ToString();

            }

            string veriuyee = "select * from Emanetler where ÜyeNo like '%" + uyeno + "%'";
            OleDbCommand komutuyee = new OleDbCommand(veriuyee, baglanti);
            OleDbDataAdapter adaptoruyee = new OleDbDataAdapter(komutuyee);
            DataSet dss = new DataSet();
            adaptoruyee.Fill(dss);
            dataGridView2.DataSource = dss.Tables[0];
        }
    }
}
