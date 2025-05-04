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
using MySql.Data.MySqlClient;

namespace Kerem_Cepni_230211019
{
    public partial class Form1 : Form
    {
        MySqlConnection baglanti = new MySqlConnection("server=localhost ; Database = kurs ; Uid = root ; pwd=1221");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand login = new MySqlCommand("Select * From admin Where kullanici_adi = @k1 and sifre = @k2", baglanti);
            login.Parameters.AddWithValue("@k1", textBox1.Text);
            login.Parameters.AddWithValue("@k2", textBox2.Text);
            MySqlDataReader reader = login.ExecuteReader();
            if (reader.Read())
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();   
            frm3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
