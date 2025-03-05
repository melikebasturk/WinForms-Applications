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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace KolSan_SatisTakip
{

    public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False");


        void temizle()
        {
            textlogref.Text = "";
            textmodel.Text = "";
            ckategori.Text = "";
            cturu.Text = "";
            cboyut.Text = "";
            crenk.Text = "";
            textafiyat.Text = "";
            textstok.Text = "";
            textbul.Text = "";
        }
        
        public Form4()
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            this.k_PRODUCTTableAdapter.Fill(this.kOLSANDataSet1.K_PRODUCT);
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.k_PRODUCTTableAdapter.Fill(this.kOLSANDataSet1.K_PRODUCT);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand Komut = new SqlCommand("Insert Into K_PRODUCT(MODEL,CATEGORY,TYPEE,DIMENSION,COLOUR,PIECE_PRICE,STOCK) values (@u1,@u2,@u3,@u4,@u5,@u6,@u7)", baglanti);
            Komut.Parameters.AddWithValue("@u1", textmodel.Text);
            Komut.Parameters.AddWithValue("@u2", ckategori.Text);
            Komut.Parameters.AddWithValue("@u3", cturu.Text);
            Komut.Parameters.AddWithValue("@u4", cboyut.Text);
            Komut.Parameters.AddWithValue("@u5", crenk.Text);
            Komut.Parameters.AddWithValue("@u6", textafiyat.Text);
            Komut.Parameters.AddWithValue("@u7", textstok.Text);

            Komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ürün Eklendi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete from K_PRODUCT where LOGREF=@u1", baglanti);
            sil.Parameters.AddWithValue("@u1", textlogref.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün silindi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update  K_PRODUCT Set MODEL=@u1, CATEGORY=@u2, TYPEE=@u3, DIMENSION=@u4, COLOUR=@u5, PIECE_PRICE=@u6, STOCK=@u7 where LOGREF=@u8", baglanti);
            guncelle.Parameters.AddWithValue("u1", textmodel.Text);
            guncelle.Parameters.AddWithValue("u2", ckategori.Text);
            guncelle.Parameters.AddWithValue("u3", cturu.Text);
            guncelle.Parameters.AddWithValue("u4", cboyut.Text);
            guncelle.Parameters.AddWithValue("u5", crenk.Text);
            guncelle.Parameters.AddWithValue("u6", textafiyat.Text);
            guncelle.Parameters.AddWithValue("u7", textstok.Text);
            guncelle.Parameters.AddWithValue("u8", textlogref.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün güncellendi");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string aramaMetni = textbul.Text;
            DataTable dt = new DataTable();
            string connectionString = "Data Source=<VERİTABANI_SUNUCU_ADI>;Initial Catalog=<VERİTABANI_ADI>;Integrated Security=True;Encrypt=False";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM K_PRODUCT WHERE MODEL LIKE @AraMetni";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AraMetni", "%" + aramaMetni + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            dataGridView1.DataSource = dt;
        }

        private void textlogref_TextChanged(object sender, EventArgs e)
        {

        }

        private void textmodel_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textlogref.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textmodel.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            ckategori.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            cturu.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            cboyut.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            crenk.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            textafiyat.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            textstok.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Form5 KolSan = new Form5();
            KolSan.Show();
            this.Hide();
        }
    }
}
