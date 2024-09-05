using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class SifirAracGuncelle : Form
    {
        public SifirAracGuncelle()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (txtAra.Text == "")
            {
                MessageBox.Show("Lütfen Önce Güncellemek İstediğiniz Aracın Plaka Bilgisini Arayın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    SqlCommand komut = new SqlCommand("UPDATE SifirAracBilgileri SET marka=@marka, model=@model, renk=@renk, plaka=@plaka, km=@km Where plaka=@plaka2", connection);
                    komut.Parameters.AddWithValue("@marka", cbMarka.Text);
                    komut.Parameters.AddWithValue("@model", txtModel.Text);
                    komut.Parameters.AddWithValue("@renk", txtRenk.Text);
                    komut.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                    komut.Parameters.AddWithValue("@km", txtKM.Text);
                    komut.Parameters.AddWithValue("@plaka2", txtAra.Text);

                    komut.ExecuteNonQuery();

                    DialogResult sonuc = new DialogResult();
                    sonuc = MessageBox.Show("Güncelleme İşlemi Başarılı.", "Güncelleme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (DialogResult.OK == sonuc)
                    {
                        SqlCommand komut2 = new SqlCommand("Select * From SifirAracBilgileri", connection);
                        SqlDataAdapter adap = new SqlDataAdapter(komut2);
                        DataTable tablo = new DataTable();

                        adap.Fill(tablo);
                        dataGridView1.DataSource = tablo;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme İşlemi Başarısız." + ex, "Güncelleme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                txtModel.Text = "";
                txtKM.Text = "";
                txtPlaka.Text = "";
                txtRenk.Text = "";
                cbMarka.Text = "";
                txtAra.Text = "";
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            SifirAracIslemleri islem = new SifirAracIslemleri();
            islem.Show();
            this.Hide();
        }

        private void SifirAracGuncelle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.SifirAracBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sifirAracBilgileriTableAdapter.Fill(this.galeriOtomasyonuDataSet1.SifirAracBilgileri);
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
            txtAra.Text = "";
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand komut = new SqlCommand("Select * From SifirAracBilgileri Where plaka=@plaka", connection);
                komut.Parameters.AddWithValue("@plaka", txtAra.Text);
                SqlDataAdapter adap = new SqlDataAdapter(komut);

                DataTable tablo = new DataTable();

                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;

                if (dataGridView1.CurrentCell == null)
                {
                    MessageBox.Show("Aradığınız Araç Bulunamadı", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Aradığınız Araç Bulundu", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Arama İşleminde Hata!", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
