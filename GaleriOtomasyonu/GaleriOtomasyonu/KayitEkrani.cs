using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class KayitEkrani : Form
    {
        public KayitEkrani()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void KayitEkrani_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.CalisanYetkileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.calisanYetkileriTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.CalisanYetkileri);

            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            connection.Open();
            
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(basePath, "Gorseller\\gozAcik.png");
            btnGoster.BackgroundImage = Image.FromFile(imagePath);
            btnGoster.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (txtIsim.Text != "" && txtSifre.Text != "" && txtSirket.Text != "" && txtSoyisim.Text != "" && txtTC.Text != "" && txtTel.Text != "" && cbYetki.Text != "")
            {
                DateTime dogum = Convert.ToDateTime(dtpDTarihi.Text.ToString());
                DateTime simdi = DateTime.Now;
                if (simdi.Year - dogum.Year >= 18)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        SqlCommand komut = new SqlCommand("Insert Into CalisanBilgileri(ad,soyad,tc,tel,dogumTarihi,sirketIsmi,yetki,sifre) values (@ad,@soyad,@tc,@tel,@dogumTarihi,@sirketIsmi,@yetki,@sifre)", connection);
                        komut.Parameters.AddWithValue("@ad", txtIsim.Text);
                        komut.Parameters.AddWithValue("@soyad", txtSoyisim.Text);
                        komut.Parameters.AddWithValue("@tc", txtTC.Text);
                        komut.Parameters.AddWithValue("@tel", txtTel.Text);
                        komut.Parameters.AddWithValue("@dogumTarihi", dtpDTarihi.Text);
                        komut.Parameters.AddWithValue("@sirketIsmi", txtSirket.Text);
                        komut.Parameters.AddWithValue("@yetki", cbYetki.Text);
                        komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                        if (txtSifre.TextLength < 5)
                        {
                            MessageBox.Show("Lütfen Güvenli Bir Şifre Oluşturun. (Şifreniz 5 Haneden Büyük Olmalı)", "Kayıt İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            komut.ExecuteNonQuery();

                            MessageBox.Show("Kayıt Başarıyla Oluşturulmuştur.", "Kayıt İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Giris giris = new Giris();
                            giris.Show();
                            this.Hide();

                            txtIsim.Text = "";
                            txtSifre.Text = "";
                            txtSirket.Text = "";
                            txtSoyisim.Text = "";
                            txtTC.Text = "";
                            txtTel.Text = "";
                            cbYetki.Text = "";
                            dtpDTarihi.Text = "";
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Kayıt Ekleme İşlemi Başarısızlıkla Sonuçlandı.", "Kayıt İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Lütfen Doğum Tarihinize Dikkat Edin. (Çalışabilmek İçin 18 Yaşında veya Daha Büyük Olmanız Gerekmekte.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("Lütfen Tüm Bilgileri Doldurunuz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtIsim.Text = "";
            txtSifre.Text = "";
            txtSirket.Text = "";
            txtSoyisim.Text = "";
            txtTC.Text = "";
            txtTel.Text = "";
            cbYetki.Text = "";
            dtpDTarihi.Text = "";
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            if (txtSifre.PasswordChar == '*')
            {
                txtSifre.PasswordChar = '\0';
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(basePath, "Gorseller\\gozKapali.png");
                btnGoster.BackgroundImage = Image.FromFile(imagePath);
                btnGoster.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                txtSifre.PasswordChar = '*';
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(basePath, "Gorseller\\gozAcik.png");
                btnGoster.BackgroundImage = Image.FromFile(imagePath);
                btnGoster.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }
    }
}
