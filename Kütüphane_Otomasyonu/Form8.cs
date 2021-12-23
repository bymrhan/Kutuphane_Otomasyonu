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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form8 kapat = new Form8();
            kapat.Close();
            Form7 yeni = new Form7();
            yeni.Show();
            this.Close();
           
        }
    }
}
