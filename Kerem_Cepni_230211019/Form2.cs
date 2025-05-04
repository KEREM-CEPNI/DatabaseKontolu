using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kerem_Cepni_230211019
{
    public partial class Form2 : Form
    {
        MySqlConnection baglanti = new MySqlConnection("server = localhost ; Database = kurs ; Uid = root ; pwd = 1221");
        MySqlDataAdapter adapter;
        DataTable dt; 
        
        public Form2()
        {
            InitializeComponent();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            string secilendeger = "";


            if (radioButton1.Checked == true)
            {
                secilendeger = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                secilendeger = radioButton2.Text;
            }

            string zaman = "";
            if (checkBox1.Checked == true)
            {
                zaman = checkBox1.Text;
            }
            else if (checkBox1.Checked==true)
            {
                zaman = checkBox2.Text;
            }


            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Insert Into ogrenci(id,ad,soyad,tckimlik,adres,cinsiyet,kurstipi,kurszamani) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) ", baglanti);
            komut.Parameters.AddWithValue("@p1",txtId.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p4", txtTC.Text);
            komut.Parameters.AddWithValue("@p5", txtAdres.Text);
            komut.Parameters.AddWithValue("@p6",secilendeger);
            komut.Parameters.AddWithValue("@p7",comboBox1.Text);
            komut.Parameters.AddWithValue("@p8",zaman);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Kaydı başarıyla sağlandı...");
            veriGetir();
        }

        void veriGetir()
        {
            dt = new DataTable();
            baglanti.Open();
            adapter = new MySqlDataAdapter("Select * From ogrenci ", baglanti);
            dataGridView1.DataSource = dt;
            adapter.Fill(dt);
            baglanti.Close();

            txtad.Clear();
            txtTC.Clear();
            txtsoyad.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("Delete From ogrenci where ad=@s1", baglanti);
            sil.Parameters.AddWithValue("@s1", txtad.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Kaydı başarıyla silindi...");
            veriGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtAdres.Text=dataGridView1.CurrentRow.Cells[4].Value.ToString();

                comboBox1.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();

            }
            catch
            {
                throw;
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string secilendeger = "";
            if (radioButton1.Checked == true)
            {
                secilendeger = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                secilendeger = radioButton2.Text;
            }

            string kurszamani = "";
            if (checkBox1.Checked == true)
            {
                kurszamani = checkBox1.Text;
            }
            else if (checkBox2.Checked)
            {
                kurszamani = checkBox2.Text;
            }



            baglanti.Open();
            MySqlCommand güncelle = new MySqlCommand("Update ogrenci Set ad = @a1 , soyad = @a2,tckimlik=@a3,adres=@a4,cinsiyet = @a5,kurstipi=@a6,kurszamani=@a7", baglanti);
            güncelle.Parameters.AddWithValue("@a1", txtad.Text);
            güncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            güncelle.Parameters.AddWithValue("@a3", txtTC.Text);
            güncelle.Parameters.AddWithValue("@a4", txtAdres.Text);
            güncelle.Parameters.AddWithValue("@a5", secilendeger);
            güncelle.Parameters.AddWithValue("@a6",comboBox1.Text);
            güncelle.Parameters.AddWithValue("@a7",kurszamani);
            güncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Kaydı Güncellendi....");
            veriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            veriGetir();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "ad  LIKE '" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }
           else if (radioButton3.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "soyad  LIKE '" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }

            else if (radioButton3.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "tckimlik  LIKE '" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (radioButton3.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "adres  LIKE '" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (radioButton3.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "cinsiyet  LIKE '" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else if (radioButton3.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "kurstipi  LIKE '" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }


        }
    }
}
