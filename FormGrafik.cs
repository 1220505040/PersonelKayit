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
    public partial class FormGrafik : Form
    {
        public FormGrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=FURKAN\\FURKA;Initial Catalog=PersonelVT;Integrated Security=True");

        private void FormGrafik_Load(object sender, EventArgs e)
        {
            //Şehir personel tablosu
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select perSehir,count(*) from tblpersonel group by perSehir", baglantı);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehir"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglantı.Close();

            //Meslek Maaş tablosu
            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("Select permeslek,avg(Permaas) from tblpersonel group by permeslek",baglantı);
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);

            }
            baglantı.Close() ;
                
        }
    }
}
