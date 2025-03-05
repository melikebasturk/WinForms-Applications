using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KolSan_SatisTakip
{
    public partial class Form5 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False");
        public Form5()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 KolSan = new Form2();
            KolSan.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string musteriMetni = textmıd.Text;
            DataTable dt = new DataTable();
            string connectionString = "Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM K_CUSTOMER WHERE TC LIKE @AraMetni";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AraMetni", "%" + musteriMetni + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            dataGridView1.DataSource = dt;
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 KolSan = new Form3();
            KolSan.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string urunMetni = textuıd.Text;
            DataTable dt = new DataTable();
            string connectionString = "Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM K_PRODUCT WHERE MODEL LIKE @AraMetni";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AraMetni", "%" + urunMetni + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            dataGridView2.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 KolSan = new Form4();
            KolSan.Show();
            this.Hide();
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 KolSan = new Form6();
            KolSan.Show();
            this.Hide();
        }
    }
}
