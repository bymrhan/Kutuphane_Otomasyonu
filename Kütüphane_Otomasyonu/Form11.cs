using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Kütüphane_Otomasyonu
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = @"\Yedekler\";
                saveFileDialog1.DefaultExt = "mdb";
                saveFileDialog1.Filter = "mdb Dosyaları|*.mdb";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    

                    if (System.IO.File.Exists(saveFileDialog1.FileName))
                    {
                        System.IO.File.Delete(saveFileDialog1.FileName);
                    }

                
                   
                    System.IO.File.Copy(Application.StartupPath.ToString() + "\\KütüphaneBilgileri.mdb", saveFileDialog1.FileName);
                    textBox1.Text = saveFileDialog1.FileName;
                    MessageBox.Show("Yedek alma işlemi tamamlandı !");
                    label1.Text = "Son Başarılı Yedekleme Zamanı  : " + File.GetLastAccessTime(textBox1.Text).ToString();
                }
                else
                {
                    MessageBox.Show("Yedekle işlemi iptal edildi !");
                }

   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(Application.StartupPath.ToString() + "\\KütüphaneBilgileri.mdb"))
                {
                    System.IO.File.Delete(Application.StartupPath.ToString() + "\\KütüphaneBilgileri.mdb");
                }
                System.IO.File.Copy(openFileDialog1.FileName, Application.StartupPath.ToString() + "\\KütüphaneBilgileri.mdb");
                MessageBox.Show("Geri yükleme işlemi tamamlandı !");
            }
            else
            {
                MessageBox.Show("Geri yükleme işlemi iptal edildi !");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintDialog yazdir = new PrintDialog();
            yazdir.Document = printDocument1;
            yazdir.UseEXDialog = true;
            if (yazdir.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        
        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
