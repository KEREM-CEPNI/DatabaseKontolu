using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kerem_Cepni_230211019
{
    public partial class Form3 : Form
    {
        MySqlConnection baglanti = new MySqlConnection("server = localhost ; Database = kurs ; Uid = root ; pwd = 1221");

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand kayit = new MySqlCommand("Insert Into admin(ad,soyad,kullanici_adi,sifre) values (@p1,@p2,@p3,@p4)",baglanti);
            kayit.Parameters.AddWithValue("@p1",textBox1.Text);
            kayit.Parameters.AddWithValue("@p2",textBox2.Text);
            kayit.Parameters.AddWithValue("@p3",textBox3.Text);
            kayit.Parameters.AddWithValue("@p4",textBox4.Text);
            kayit.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kullanıcı Kaydı Başarı İle Sağlandı...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
