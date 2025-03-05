using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolSan_SatisTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }
        // giriş bilgileri
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "kolsan" && textBox2.Text == "1")
            {
                Form2 KolSan = new Form2();
                KolSan.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre yanlış",
                    "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
