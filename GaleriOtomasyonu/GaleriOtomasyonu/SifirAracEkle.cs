using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class SifirAracEkle : Form
    {
        public SifirAracEkle()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGeri_Click(object sender, EventArgs e)
        {
            SifirAracIslemleri islem = new SifirAracIslemleri();
            islem.Show();
            this.Hide();
        }

        private void SifirAracEkle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.AracMarkalari' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aracMarkalariTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.AracMarkalari);
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            connection.Open();

            SqlCommand komut = new SqlCommand("Select sirketIsmi From CalisanBilgileri", connection);
            SqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {
                string sirketIsmi = read["sirketIsmi"].ToString();
                lblSirket.Text = sirketIsmi;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

            txtModel.Text = "";
            txtKM.Text = "";
            txtPlaka.Text = "";
            txtRenk.Text = "";
            cbMarka.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (txtKM.Text != "" && txtModel.Text != "" && txtPlaka.Text != "" && txtRenk.Text != "" && cbMarka.Text != "")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("Insert Into SifirAracBilgileri(marka,model,renk,plaka,km) values (@marka,@model,@renk,@plaka,@km)", connection);
                    komut.Parameters.AddWithValue("@marka", cbMarka.Text);
                    komut.Parameters.AddWithValue("@model", txtModel.Text);
                    komut.Parameters.AddWithValue("@renk", txtRenk.Text);
                    komut.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                    komut.Parameters.AddWithValue("@km", txtKM.Text);


                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt Ekleme İşlemi Başarılı", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception E)
                {
                    MessageBox.Show("Kayıt Ekleme İşlemi Başarısız!" + E, "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtKM.Text = "";
                txtModel.Text = "";
                txtPlaka.Text = "";
                txtRenk.Text = "";

                cbMarka.Text = "";
            }
            else
                MessageBox.Show("Lütfen Boş Bırakmadan Tekrar Deneyin!", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
