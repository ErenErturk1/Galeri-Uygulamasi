using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class YonetimCalisanGuncelle : Form
    {
        public YonetimCalisanGuncelle()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGeri_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            string userRole = Program.CurrentUserRole;

            if (userRole == "Patron")
            {
                YonetimEkrani ekran = new YonetimEkrani();
                ekran.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Yetkisiz Giriş.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void YonetimCalisanGuncelle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet.CalisanYetkileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.calisanYetkileriTableAdapter.Fill(this.galeriOtomasyonuDataSet.CalisanYetkileri);
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet.CalisanBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.calisanBilgileriTableAdapter.Fill(this.galeriOtomasyonuDataSet.CalisanBilgileri);
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
            txtAra.Text = "";
            txtIsim.Text = "";
            txtSifre.Text = "";
            txtSirket.Text = "";
            txtSoyisim.Text = "";
            txtTC.Text = "";
            txtTel.Text = "";
            cbYetki.Text = "";
            dtpDTarihi.Text = "";
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
                SqlCommand komut = new SqlCommand("Select * From CalisanBilgileri Where tc Like " + txtAra.Text, connection);
                SqlDataAdapter adap = new SqlDataAdapter(komut);

                DataTable tablo = new DataTable();

                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;

                if (dataGridView1.CurrentCell == null)
                {
                    MessageBox.Show("Aradığınız Kişi Bulunamadı", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Aradığınız Kişi Bulundu", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Arama İşleminde Hata!", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (txtAra.Text == "")
            {
                MessageBox.Show("Lütfen Bilgilerini Güncellemek İstediğiniz Çalışanı İlk Önce T.C No Bilgisi İle Arama Yapın", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtIsim.Text != "" && txtSoyisim.Text != "" && txtSifre.Text != "" && txtSirket.Text != "" && txtTC.Text != "" && txtTel.Text != "")
                {
                    DateTime dogum = Convert.ToDateTime(dtpDTarihi.Text.ToString());
                    DateTime simdi = DateTime.Now;
                    if (simdi.Year - dogum.Year >= 18)
                    {

                        try
                        {
                            if (connection.State == ConnectionState.Closed)
                            {
                                connection.Open();
                            }
                            SqlCommand komut = new SqlCommand("UPDATE CalisanBilgileri SET ad=@ad, soyad=@soyad, tc=@tc, tel=@tel, dogumTarihi=@dogumTarihi, sirketIsmi=@sirketIsmi, yetki=@yetki, sifre=@sifre  Where tc=@tc2", connection);
                            komut.Parameters.AddWithValue("@ad", txtIsim.Text);
                            komut.Parameters.AddWithValue("@soyad", txtSoyisim.Text);
                            komut.Parameters.AddWithValue("@tc", txtTC.Text);
                            komut.Parameters.AddWithValue("@tel", txtTel.Text);
                            komut.Parameters.AddWithValue("@dogumTarihi", dtpDTarihi.Text);
                            komut.Parameters.AddWithValue("@tc2", txtAra.Text);
                            komut.Parameters.AddWithValue("@sirketIsmi", txtSirket.Text);
                            komut.Parameters.AddWithValue("@yetki", cbYetki.Text);
                            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);

                            komut.ExecuteNonQuery();

                            DialogResult sonuc = new DialogResult();
                            sonuc = MessageBox.Show("Güncelleme İşlemi Başarılı.", "Güncelleme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (DialogResult.OK == sonuc)
                            {
                                SqlCommand komut2 = new SqlCommand("Select * From CalisanBilgileri", connection);
                                SqlDataAdapter adap = new SqlDataAdapter(komut2);
                                DataTable tablo = new DataTable();

                                adap.Fill(tablo);
                                dataGridView1.DataSource = tablo;
                            }
                            txtAra.Text = "";
                            txtIsim.Text = "";
                            txtSifre.Text = "";
                            txtSirket.Text = "";
                            txtSoyisim.Text = "";
                            txtTC.Text = "";
                            txtTel.Text = "";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Güncelleme İşlemi Başarısız.", "Güncelleme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Lütfen Doğum Tarihinize Dikkat Edin. (Çalışabilmek İçin 18 Yaşında veya Daha Büyük Olmanız Gerekmekte.)", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Lütfen Boşluk Bırakmadan Tekrar Deneyin.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
