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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace KolSan_SatisTakip
{
    public partial class Form3 : Form
    {

        
        SqlConnection baglanti = new SqlConnection("Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False");
        void temizle()
        {
            textlogref.Text = "";
            mtextTC.Text = "";
            textad.Text = "";
            textsoyad.Text = "";
            mtextno.Text = "";
            textmail.Text = "";
            textmail.Text = "";
            textdt.Text = "";
            combosehir.Text = "";
            rtextadres.Text = "";
            textbul.Text = "";
        }

        public Form3()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.k_CUSTOMERTableAdapter.Fill(this.kOLSANDataSet.K_CUSTOMER);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        
            this.k_CUSTOMERTableAdapter.Fill(this.kOLSANDataSet.K_CUSTOMER);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Komut = new SqlCommand("Insert into K_CUSTOMER (TC,FIRST_NAME,SURNAME,NUMBER,MAIL,DATE_OF_BIRTH,CITY,OPEN_ADDRESS) values (@m1,@m2,@m3,@m4,@m5,@m6,@m7,@m8)", baglanti);
            Komut.Parameters.AddWithValue("@m1", mtextTC.Text);
            Komut.Parameters.AddWithValue("@m2", textad.Text);
            Komut.Parameters.AddWithValue("@m3", textsoyad.Text);
            Komut.Parameters.AddWithValue("@m4", mtextno.Text);
            Komut.Parameters.AddWithValue("@m5", textmail.Text);
            Komut.Parameters.AddWithValue("@m6", textdt.Text);
            Komut.Parameters.AddWithValue("@m7", combosehir.Text);
            Komut.Parameters.AddWithValue("@m8", rtextadres.Text);

            Komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Eklendi");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete from K_CUSTOMER where LOGREF=@m1", baglanti);
            sil.Parameters.AddWithValue("@m1", textlogref.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("müşteri silindi");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update K_CUSTOMER Set TC=@m1, FIRST_NAME=@m2, SURNAME=@m3, NUMBER=@m4, MAIL=@m5, DATE_OF_BIRTH=@m6, CITY=@m7, OPEN_ADDRESS=@m8 where LOGREF=@m9", baglanti);
            guncelle.Parameters.AddWithValue("m1", mtextTC.Text);
            guncelle.Parameters.AddWithValue("m2", textad.Text);
            guncelle.Parameters.AddWithValue("m3", textsoyad.Text);
            guncelle.Parameters.AddWithValue("m4", mtextno.Text);
            guncelle.Parameters.AddWithValue("m5", textmail.Text);
            guncelle.Parameters.AddWithValue("m6", textdt.Text);
            guncelle.Parameters.AddWithValue("m7", combosehir.Text);
            guncelle.Parameters.AddWithValue("m8", rtextadres.Text);
            guncelle.Parameters.AddWithValue("m9", textlogref.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("müşteri güncellendi");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temizle();
        }

        //database 
        private void button7_Click(object sender, EventArgs e)
        {
            string aramaMetni = textbul.Text;
            DataTable dt = new DataTable();
            string connectionString = "Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM K_CUSTOMER WHERE TC LIKE @AraMetni";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AraMetni", "%" + aramaMetni + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textlogref.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            mtextTC.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textsoyad.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            mtextno.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textmail.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            textdt.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            combosehir.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
            rtextadres.Text = dataGridView1.Rows[secim].Cells[8].Value.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 KolSan = new Form5();
            KolSan.Show();
            this.Hide();
        }
    }
}
