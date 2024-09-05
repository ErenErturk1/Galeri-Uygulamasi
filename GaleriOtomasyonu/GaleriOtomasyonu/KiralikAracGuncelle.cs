using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class KiralikAracGuncelle : Form
    {
        public KiralikAracGuncelle()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (txtAra.Text == "")
            {
                MessageBox.Show("Lütfen Bilgilerini Güncellemek İstediğiniz Aracı İlk Önce Plaka Bilgisi İle Arayın.");
            }
            else
            {
                if ((txtHasar.Text != "" || radioButton2.Checked == true) && txtKM.Text != "" && txtModel.Text != "" && txtPlaka.Text != "" && txtRenk.Text != "")
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        SqlCommand komut = new SqlCommand("UPDATE KiralananAracBilgileri SET marka=@marka, model=@model, renk=@renk, plaka=@plaka, km=@km, hasar=@hasar Where plaka=@plaka2", connection);
                        if (txtHasar.Visible == true)
                        {
                            komut.Parameters.AddWithValue("@hasar", txtHasar.Text);
                        }
                        else
                        {
                            komut.Parameters.AddWithValue("@hasar", radioButton2.Text);
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
                            SqlCommand komut2 = new SqlCommand("Select * From KiralananAracBilgileri", connection);
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
                    txtHasar.Text = "";
                    txtKM.Text = "";
                    txtModel.Text = "";
                    txtPlaka.Text = "";
                    txtRenk.Text = "";
                    cbMarka.Text = "";
                }
                else
                    MessageBox.Show("Lütfen Boşluk Bırakmadan Devam Edin.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            KiralikAracHizmetleri kiralik = new KiralikAracHizmetleri();
            kiralik.Show();
            this.Hide();
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
                SqlCommand komut = new SqlCommand("Select * From KiralananAracBilgileri Where plaka=@plaka", connection);
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

        private void KiralikAracGuncelle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.AracMarkalari' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aracMarkalariTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.AracMarkalari);
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.KiralananAracBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kiralananAracBilgileriTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.KiralananAracBilgileri);
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAra.Text = "";
            txtHasar.Text = "";
            txtKM.Text = "";
            txtModel.Text = "";
            txtPlaka.Text = "";
            txtRenk.Text = "";
            cbMarka.Text = "";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            txtHasar.Visible = true;
            radioButton1.Visible = false;
            txtHasar.Focus();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            txtHasar.Visible = false;
        }
    }
}
