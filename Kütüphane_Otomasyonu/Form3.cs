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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        static string baglantiYolu = "Data Source=WIN-03MQN6HB3DG;Integrated Security=SSPI;Initial Catalog=KütüphaneBilgileri";
        static SqlConnection baglanti = new SqlConnection(baglantiYolu);

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dataSet1.Kitap' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kitapTableAdapter1.Fill(this.dataSet1.Kitap);
            comboBox1.SelectedIndex = 0;
            groupBox2.Visible = true;
            button4.Enabled = false;


        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mENÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 kapat = new Form3();
            kapat.Close();
            Form2 ac = new Form2();
            ac.Show();
            this.Hide();
        }

        private void kİTAPEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
        }

        public void kitapListele()
        {
            string veri = "select*from Kitap";
            SqlDataAdapter adaptor = new SqlDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void tÜMKİTAPLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string KitapAdı = textBox1.Text;
            int SayfaNo =Convert.ToInt32(textBox2.Text);
            string Yazar = textBox3.Text;
            string BasımEvi = textBox4.Text;
            B10.KitapEkle(KitapAdı, SayfaNo, Yazar, BasımEvi);
            MessageBox.Show("KİTAP SİSTEME BAŞARIYLA EKLENDİ...");
            button1.Enabled = false;
            kitapListele();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string KitapAdı = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string SayfaNo=dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string Yazar= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string BasımEvi= dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            textBox1.Text = KitapAdı;
            textBox2.Text = SayfaNo.ToString();
            textBox3.Text = Yazar;
            textBox4.Text = BasımEvi;
            kitapListele();
        }

        private void kİTAPSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            MessageBox.Show("Silmek İsteğin Kitabın İsmini Gir!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string KitapAdı = textBox1.Text;
            B10.KitapSil(KitapAdı);
            MessageBox.Show("İstenilen Kitap Başarıyla Silindi...");
            textBox1.Clear();
            kitapListele();
            button2.Enabled = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
        }

        private void kİTAPBİLGİLERİGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

        private void kİTAPARAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            button1.Visible = false;          
            button2.Visible = false;
            button3.Enabled = true;
            button4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            MessageBox.Show("Arama Türünü Seçin !!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (comboBox1.Text == "Kitap Adı")
            { 
                string veri = "select * from Kitap where KitapAdı like '%" + textBox5.Text + "%'";
                SqlCommand komut = new SqlCommand(veri, baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataSet DS = new DataSet();
                adaptor.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            if (comboBox1.Text == "Yazar")
            {
                string veri = "select * from Kitap where Yazar like '%" + textBox5.Text + "%'";
                SqlCommand komut = new SqlCommand(veri, baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataSet DS = new DataSet();
                adaptor.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            if (comboBox1.Text == "Basım Evi")
            {
                string veri = "select * from Kitap where BasımEvi like '%" + textBox5.Text + "%'";
                SqlCommand komut = new SqlCommand(veri, baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataSet DS = new DataSet();
                adaptor.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
       
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string veri = "select*from Kitap";
            SqlDataAdapter adaptor = new SqlDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = comboBox1.Text + " :";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string KitapAdı = textBox1.Text;
            int SayfaNo = Convert.ToInt32(textBox2.Text);
            string Yazar = textBox3.Text;
            string BasımEvi = textBox4.Text;
            B10.KitapGuncelle(KitapAdı, SayfaNo, Yazar, BasımEvi);
            MessageBox.Show("SEÇİLEN KİTAP BAŞARIYLA GÜNCELLENDİ...");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            kitapListele();
        }
    }
}
