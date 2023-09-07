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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=FURKAN\\FURKA;Initial Catalog=PersonelVT;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.tblPersonelTableAdapter.Fill(this.personelVTDataSet.TblPersonel);
        }
public void temizle()
        {
            TxtPerAd.Text = "";
            TxtPersoyad.Text = "";
            TxtPerid.Text = "";
            TxtMeslek.Text = "";
            TxtMaas.Text = "";
            cmbSehir.Text = "";
            rdiaEvli.Checked= false;
            rdiabekar.Checked = false;
            TxtPerAd.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into TblPersonel (PerAd,PerSoyad,Persehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglantı);
            komut.Parameters.AddWithValue("@p1",TxtPerAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPersoyad.Text);
            komut.Parameters.AddWithValue("@p3",cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4",TxtMaas.Text );
            komut.Parameters.AddWithValue("@p5",TxtMeslek.Text );
            komut.Parameters.AddWithValue("@p6", label8.Text);


            komut.ExecuteNonQuery();

            baglantı.Close();

            MessageBox.Show("Personel Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void rdiaEvli_CheckedChanged(object sender, EventArgs e)
        { if (rdiaEvli.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void rdiabekar_CheckedChanged(object sender, EventArgs e)
        { if (rdiabekar.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtPerid.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
         TxtPerAd.Text=   dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtPersoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtMaas.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                rdiaEvli.Checked= true;
            }
            if(label8.Text == "False")
            {
                rdiabekar.Checked= true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutsil = new SqlCommand("Delete from TblPersonel where Perid=@k1", baglantı);
            komutsil.Parameters.AddWithValue("@k1",TxtPerid.Text);
            komutsil.ExecuteNonQuery();


            baglantı.Close();

            MessageBox.Show("Personel Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutgüncelle = new SqlCommand("Update TblPersonel set PerAd=@f1,PerSoyad=@f2,PerSehir=@f3,PerMaas=@f4,PerMeslek=@f5,PerDurum=@f6 where Perid=@f7",baglantı);
            komutgüncelle.Parameters.AddWithValue("@f1", TxtPerAd.Text);
            komutgüncelle.Parameters.AddWithValue("@f2", TxtPersoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@f3", cmbSehir.Text);
            komutgüncelle.Parameters.AddWithValue("@f4", TxtMaas.Text);
            komutgüncelle.Parameters.AddWithValue("@f5", TxtMeslek.Text);
            komutgüncelle.Parameters.AddWithValue("@f6", label8.Text);
            komutgüncelle.Parameters.AddWithValue("@f7", TxtPerid.Text);
            komutgüncelle.ExecuteNonQuery() ;

            baglantı.Close();
            MessageBox.Show("Personel Güncellendi","Bilgilendirme",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frmistatistik frm= new Frmistatistik();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormGrafik frm3 = new FormGrafik();
            frm3.Show();
        }
    }
}
