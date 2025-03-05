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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace KolSan_SatisTakip
{
    public partial class Form6 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False");
        void temizle()
        {
            textBox7.Text = "";
        }

        void satis_temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox7.Text = "";
            textBox3.Text = "";
            textBox8.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox1.Text = "";
            textBox9.Text = "";
        }

        public Form6()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

       
        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 KolSan = new Form5();
            KolSan.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = textBox7.Text + "\n" + dateTimePicker1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

           
          
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form6_Load_1(object sender, EventArgs e)
        {
           
            this.k_SALESTableAdapter1.Fill(this.kOLSANDataSet3.K_SALES);
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox3.Text, out double adet) && double.TryParse(textBox8.Text, out double afiyat))
            {
                double toplam = adet * afiyat;
                textBox4.Text = toplam.ToString();
            }
            else
            {
                textBox4.Text = "Geçerli sayılar giriniz.";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox4.Text, out double fiyat) && double.TryParse(comboBox1.Text, out double indirim))
            {
                double borc = fiyat - (fiyat * indirim)/100 ;
                textBox5.Text = borc.ToString();
            }
            else
            {
                textBox5.Text = "Geçerli sayılar giriniz.";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.k_SALESTableAdapter1.Fill(this.kOLSANDataSet3.K_SALES);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Satis = new SqlCommand("Insert Into K_SALES(K_CUSTOMERLOGREF,K_PRODUCTLOGREF,CREATE_DATE,PIECE,PIECE_PRICE,PRICE,DISCOUNT,DEBT,EMPLOYEE,EXPLANATION) values (@s1,@s2,@s3,@s4,@s5,@s6,@s7,@s8,@s9,@s10)", baglanti);
            Satis.Parameters.AddWithValue("@s1", textBox1.Text);
            Satis.Parameters.AddWithValue("@s2", textBox2.Text);
            Satis.Parameters.AddWithValue("@s3", textBox7.Text);
            Satis.Parameters.AddWithValue("@s4", textBox3.Text);
            Satis.Parameters.AddWithValue("@s5", textBox8.Text);
            Satis.Parameters.AddWithValue("@s6", textBox4.Text);
            Satis.Parameters.AddWithValue("@s7", comboBox1.Text);
            Satis.Parameters.AddWithValue("@s8", textBox5.Text);
            Satis.Parameters.AddWithValue("@s9", textBox6.Text);
            Satis.Parameters.AddWithValue("@s10", richTextBox1.Text);

            Satis.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Satış Yapıldı");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            satis_temizle();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string aramaMetni = textBox9.Text;
            DataTable dt = new DataTable();
            string connectionString = "Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM K_SALES WHERE LOGREF LIKE @AraMetni";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AraMetni", "%" + aramaMetni + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
