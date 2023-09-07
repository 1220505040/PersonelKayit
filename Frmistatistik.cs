using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PersonelSQL
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti1 = new SqlConnection("Data Source=FURKAN\\FURKA;Initial Catalog=PersonelVT;Integrated Security=True");


        private void Frmistatistik_Load(object sender, EventArgs e)
        { //Toplam Personel
            baglanti1.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) from TblPersonel", baglanti1);
            SqlDataReader d1= komut1.ExecuteReader();
            while (d1.Read())
            {
                Lbltoplampers.Text= d1[0].ToString();
            }
            baglanti1.Close();

            //Evli Personel
            baglanti1.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) from tblpersonel where perdurum=1 ",baglanti1);
            SqlDataReader d2= komut2.ExecuteReader();
            while (d2.Read())
            {
                lblevli.Text= d2[0].ToString();
            }

            baglanti1.Close();

            //Bekar Personel
            baglanti1.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) from tblpersonel where perdurum=0",baglanti1);
            SqlDataReader d3= komut3.ExecuteReader();
            while (d3.Read()) 
            { 
            lblbekar.Text= d3[0].ToString();
            
            }
            baglanti1.Close();

            //Şehir Sayısı
            baglanti1.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(Persehir)) from tblpersonel", baglanti1);
            SqlDataReader dr4= komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehir.Text= dr4[0].ToString();
            }
            baglanti1.Close(); 

            //Toplam Maaş

            baglanti1.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(permaas) from tblpersonel", baglanti1);
            SqlDataReader d5 = komut5.ExecuteReader();
            while (d5.Read())
            {
                lbltopmaas.Text= d5[0].ToString();
            }
            baglanti1.Close();

            //Ortalama Maaş
            baglanti1.Open ();
            SqlCommand komut6 = new SqlCommand("select avg(permaas) from tblpersonel", baglanti1);
            SqlDataReader d6= komut6.ExecuteReader();
            while (d6.Read())
            {
                labelortmaas.Text = d6[0].ToString();
            }
            baglanti1.Close();

        }
    }
}
