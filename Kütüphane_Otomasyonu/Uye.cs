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
    public partial class Uye : UserControl
    {
        public Uye()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        public static string Üyek_kadi ;
        public void button1_Click(object sender, EventArgs e)
        {
            string Üyek_kadi = textBox5.Text;
            string Üyek_sifre = textBox6.Text;
            string ÜyeAdı = textBox1.Text;
            string ÜyeSoyadı = textBox2.Text;
            string Meslek = textBox3.Text;
            int TelNo = Convert.ToInt32(textBox4.Text);

            B10.üyeEkle(Üyek_kadi,Üyek_sifre, ÜyeAdı, ÜyeSoyadı, Meslek, TelNo);
            MessageBox.Show("ÜYE KAYDI  BAŞARILI...");
            button1.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
