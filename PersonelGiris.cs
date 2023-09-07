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

namespace PersonelSQL
{
    public partial class PersonelGiris : Form
    {
        public PersonelGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=FURKAN\\FURKA;Initial Catalog=PersonelVT;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * from tblgiris where kullaniciad=@p1 and sifre=@p2", baglantı);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader rd = komut.ExecuteReader();
            if(rd.Read())
            {
                Form1 frm= new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglantı.Close();
        }
    }
}
