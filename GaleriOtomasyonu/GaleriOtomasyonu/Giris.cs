using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();
        private void button2_Click(object sender, EventArgs e)
        {
            KayitEkrani kayit = new KayitEkrani();
            kayit.Show();
            this.Hide();
        }
       
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text != "" && txtTC.Text != "")
            {
                SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand komut = new SqlCommand("Select yetki,tc From CalisanBilgileri Where tc=@tc and sifre=@sifre", connection);
                komut.Parameters.AddWithValue("@tc", txtTC.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);

                SqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Giriş İşlemi Başarılı", "Giriş İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string yetki = reader["yetki"].ToString();
                    string tc = reader["tc"].ToString();

                    Program.CurrentUserRole = yetki;
                    Program.CurrentUserTC = tc;


                    if (yetki == "Patron")
                    {
                        YoneticiMenuEkrani ekran = new YoneticiMenuEkrani();
                        ekran.Show();
                        this.Hide();
                    }
                    else if (yetki == "Çalışan")
                    {
                        CalisanMenuEkrani ekran = new CalisanMenuEkrani();
                        ekran.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Giriş Bilgileri Yanlış!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                }
            }
            else
                MessageBox.Show("Lütfen Tüm Bilgileri Doldurunuz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnKayit_Click(object sender, EventArgs e)
        {
            KayitEkrani ekran = new KayitEkrani();
            ekran.Show();
            this.Hide();
        }


        private void Giris_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            connection.Open();

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(basePath, "Gorseller\\gozAcik.png");
            btnGoster.BackgroundImage = Image.FromFile(imagePath);
            btnGoster.BackgroundImageLayout = ImageLayout.Zoom;

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtSifre.Text = "";
            txtTC.Text = "";
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
