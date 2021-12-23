using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kütüphane_Otomasyonu
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();

        }

        static string baglantiYolu = "Data Source=WIN-03MQN6HB3DG;Integrated Security=SSPI;Initial Catalog=KütüphaneBilgileri";
        static SqlConnection baglanti = new SqlConnection(baglantiYolu);

      
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
            SqlDataAdapter adaptor = new SqlDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string kullanici = Form7.gonderilecekveri;
            string veriuye = "select * from Üyeler where Üye_kadi like '%" + kullanici + "%'";
            SqlCommand komutuye = new SqlCommand(veriuye, baglanti);
            SqlDataAdapter adaptoruye = new SqlDataAdapter(komutuye);
            SqlDataReader dr;
            dr = komutuye.ExecuteReader();
            while (dr.Read())
            {
                uyeno = dr["ÜyeNo"].ToString();

            }
            
            baglanti.Close();
            baglanti.Open();
            veri = "SELECT * FROM Emanetler where ÜyeNo ="+uyeno;
            SqlCommand komut = new SqlCommand(veri, baglanti);
            adaptor = new SqlDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
            baglanti.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            string KitapAdı = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            DateTime dt = DateTime.Now;
            string TeslimTarihi = dt.ToLongDateString();
            button2.Text = TeslimTarihi;
            
            baglanti.Open();

            string veri = "update Emanetler set TeslimTarihi=@trh where KitapAdı ="+ KitapAdı + "";
            SqlCommand komut = new SqlCommand(veri, baglanti);

            komut.Parameters.AddWithValue("@trh", TeslimTarihi);
            
            baglanti.Close();


        }
    }
}
