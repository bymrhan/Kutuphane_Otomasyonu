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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlDataAdapter dr;
        SqlDataAdapter drr;

        static string baglantiYolu = "Data Source=WIN-03MQN6HB3DG;Integrated Security=SSPI;Initial Catalog=KütüphaneBilgileri";
        static SqlConnection baglanti = new SqlConnection(baglantiYolu);

        public void emanetListele()
        {
            string veri = "select*from Emanetler";
            SqlDataAdapter adaptor = new SqlDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mENÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 kapat = new Form4();
            kapat.Close();
            Form2 ac = new Form2();
            ac.Show();
            this.Hide();
        }

        private void tÜMEMANETLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emanetListele();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            emanetListele();

            baglanti.Open();
            string veri = "select * from Kitap ";
            SqlCommand komut = new SqlCommand(veri, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;  
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["KitapAdı"]);
            }
            dr.Close();

            baglanti.Close();
           
            SqlCommand komutuye = new SqlCommand();
            komutuye.CommandText = "SELECT *FROM Üyeler";
            komutuye.Connection = baglanti;
            komutuye.CommandType = CommandType.Text;

            SqlDataReader druye;
            baglanti.Open();
            druye = komutuye.ExecuteReader();
            
            while (druye.Read())
            {
                comboBox2.Items.Add(druye["Üye_kadi"]);
            }
            baglanti.Close();
            
          
        }

        private void eMANETKİTAPEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string KitapAdı = comboBox1.Text;
            int KitapNo =Convert.ToInt32(textBox2.Text);
            string ÜyeAdı = comboBox2.Text;
            int ÜyeNo = Convert.ToInt32(textBox4.Text);
            string AldığıTarih = dateTimePicker1.Text;
            B10.emanetEkle(KitapAdı, KitapNo, ÜyeAdı, ÜyeNo, AldığıTarih);
            MessageBox.Show("İSTENİLEN KİTAP EMANETLER LİSTESİNE BAŞARIYLA EKLENDİ...");
            button1.Enabled = false;
            emanetListele();
            comboBox1.Text = "";
            textBox2.Clear();
            comboBox2.Text = "";
            textBox4.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string KitapAdı = comboBox1.Text;
            B10.emanetSil(KitapAdı);
            MessageBox.Show("İSTENİLEN KİTAP BAŞARIYLA SİLİNDİ...");
            //comboBox1.Clear();
            emanetListele();
            button2.Enabled = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox2.Visible = true;
            comboBox2.Visible = true;
            textBox4.Visible = true;
            dateTimePicker1.Visible = true;
        }

        private void eMANETKİTAPSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            comboBox2.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
            MessageBox.Show("Silmek İsteğin Emanet Kitabın İsmini Gir!!!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string KitapAdı = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            int  KitapNo=Convert.ToInt32(dataGridView1.Rows[secilen].Cells[2].Value);
            string ÜyeAdı = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            int ÜyeNo =Convert.ToInt32(dataGridView1.Rows[secilen].Cells[4].Value);
            string AldığıTarih = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string TeslimTarih = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            comboBox1.Text = KitapAdı;
            textBox2.Text = KitapNo.ToString();
            comboBox2.Text = ÜyeAdı;
            textBox4.Text = ÜyeNo.ToString();
            dateTimePicker1.Text = AldığıTarih;
            dateTimePicker2.Text = TeslimTarih;
            emanetListele();
        }

        private void eMANETKİTAPGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtime1 = dateTimePicker1.Value;
            DateTime dtime2 = dateTimePicker2.Value;
            DateTime simdikizaman = DateTime.Now;
            int sonuc = DateTime.Compare(dtime1, dtime2);

            if (sonuc == 1)

            {
                MessageBox.Show("Emanet Geri Alma Tarihi Emanet Vermeden Önce Olamaz");
            }

            else
            {
                string KitapAdı = comboBox1.Text;
                int KitapNo = Convert.ToInt32(textBox2.Text);
                string ÜyeAdı = comboBox2.Text;
                int ÜyeNo = Convert.ToInt32(textBox4.Text);
                string AldığıTarih = dateTimePicker1.Text;
                string TeslimTarih = dateTimePicker2.Text;
                B10.emanetGuncelle(KitapAdı, KitapNo, ÜyeAdı, ÜyeNo, AldığıTarih, TeslimTarih);
                MessageBox.Show("SEÇİLEN EMANET BAŞARIYLA GÜNCELLENDİ...");
                comboBox1.Text = "";
                textBox2.Clear();
                comboBox2.Text = "";
                textBox4.Clear();
                dateTimePicker1.ResetText();
                dateTimePicker2.ResetText();
                emanetListele();
            }
        }

        private void eMANETKİTAPARAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            comboBox2.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
            MessageBox.Show("Aramak İsteğiniz Kitabın İsmini Girin!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string veri = "select * from Emanetler where KitapAdı like '%" + comboBox1.Text + "%'";
            SqlCommand komut = new SqlCommand(veri, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komutk = new SqlCommand();
            komutk.CommandText = "select * from Kitap where KitapAdı  like '%" + comboBox1.Text + "%'";
            komutk.Connection = baglanti;
            komutk.CommandType = CommandType.Text;

            SqlDataReader drk;
            baglanti.Open();
            drk = komutk.ExecuteReader();
            
            while (drk.Read())
            {
                textBox2.Text = drk["KitapNumarası"].ToString();
            }
            drk.Close();
            baglanti.Close();

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            string veriuye = "select * from Üyeler where Üye_kadi like '%" + comboBox2.Text + "%'";
            SqlCommand komutuye = new SqlCommand(veriuye, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(komutuye);
            komutuye.ExecuteNonQuery();
            SqlDataReader dr;
            dr = komutuye.ExecuteReader();
            while (dr.Read())
            {
                textBox4.Text = dr["ÜyeNo"].ToString();

            }
            baglanti.Close();
        }
    }
}
