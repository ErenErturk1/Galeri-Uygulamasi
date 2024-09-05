using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class IkinciElAracGuncelle : Form
    {
        public IkinciElAracGuncelle()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGeri_Click(object sender, EventArgs e)
        {
            IkinciElIslemleri islem = new IkinciElIslemleri();
            islem.Show();
            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (txtAra.Text == "")
            {
                MessageBox.Show("Lütfen Önce Bilgilerini Güncellemek İstediğiniz Aracı Plakası İle Arama Yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((txtHasar.Text != "" || hasarsizButton.Checked == true) && txtKM.Text != "" && txtModel.Text != "" && txtPlaka.Text != "" && txtRenk.Text != "")
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        SqlCommand komut = new SqlCommand("UPDATE IkinciElAracBilgileri SET marka=@marka, model=@model, renk=@renk, plaka=@plaka, km=@km, hasar=@hasar Where plaka=@plaka2", connection);
                        if (txtHasar.Visible == true)
                        {
                            komut.Parameters.AddWithValue("@hasar", txtHasar.Text);
                        }
                        else
                        {
                            komut.Parameters.AddWithValue("@hasar", hasarsizButton.Text);
                        }
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
                            SqlCommand komut2 = new SqlCommand("Select * From IkinciElAracBilgileri", connection);
                            SqlDataAdapter adap = new SqlDataAdapter(komut2);
                            DataTable tablo = new DataTable();

                            adap.Fill(tablo);
                            dataGridView1.DataSource = tablo;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Güncelleme İşlemi Başarısız.", "Güncelleme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    txtAra.Text = "";
                    txtKM.Text = "";
                    txtModel.Text = "";
                    txtPlaka.Text = "";
                    txtRenk.Text = "";
                    txtHasar.Text = "";
                    cbMarka.Text = "";
                }
                else
                    MessageBox.Show("Lütfen Boşluk Bırakmayan Devam Ediniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void IkinciElAracGuncelle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet.AracMarkalari' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aracMarkalariTableAdapter.Fill(this.galeriOtomasyonuDataSet.AracMarkalari);
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet.IkinciElAracBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ikinciElAracBilgileriTableAdapter.Fill(this.galeriOtomasyonuDataSet.IkinciElAracBilgileri);
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            connection.Open();

            txtHasar.Visible = false;

            SqlCommand komut = new SqlCommand("Select sirketIsmi From CalisanBilgileri", connection);

            SqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {
                string sirketIsmi = read["sirketIsmi"].ToString();

                lblSirket.Text = sirketIsmi;
            }
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
                SqlCommand komut = new SqlCommand("Select * From IkinciElAracBilgileri Where plaka=@plaka", connection);
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAra.Text = "";
            txtKM.Text = "";
            txtModel.Text = "";
            txtPlaka.Text = "";
            txtRenk.Text = "";
            txtHasar.Text = "";
            cbMarka.Text = "";
        }

        private void hasarliButton_CheckedChanged(object sender, EventArgs e)
        {
            txtHasar.Visible = true;
            hasarliButton.Visible = false;
            txtHasar.Focus();
        }

        private void hasarsizButton_CheckedChanged(object sender, EventArgs e)
        {
            hasarliButton.Visible = true;
            txtHasar.Visible = false;
        }
    }
}
