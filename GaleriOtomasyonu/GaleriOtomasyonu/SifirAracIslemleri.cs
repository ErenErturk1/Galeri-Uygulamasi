using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class SifirAracIslemleri : Form
    {
        public SifirAracIslemleri()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void SifirAracIslemleri_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            connection.Open();
            SqlCommand komut = new SqlCommand("Select ad,soyad,sirketIsmi From CalisanBilgileri", connection);

            SqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {
                string ad = read["ad"].ToString();
                string soyad = read["soyad"].ToString();
                string sirketIsmi = read["sirketIsmi"].ToString();

                lblSirket.Text = sirketIsmi;
                lblName.Text = "Hoşgeldiniz " + ad + " " + soyad + ".";
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SifirAracEkle ekle = new SifirAracEkle();
            ekle.Show();
            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SifirAracGuncelle guncelle = new SifirAracGuncelle();
            guncelle.Show();
            this.Hide();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            SifirAracListele listele = new SifirAracListele();
            listele.Show();
            this.Hide();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SifirAracAra ara = new SifirAracAra();
            ara.Show();
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SifirAracSil sil = new SifirAracSil();
            sil.Show();
            this.Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            string userRole = Program.CurrentUserRole;

            if (userRole == "Patron")
            {
                YoneticiMenuEkrani ekran = new YoneticiMenuEkrani();
                ekran.Show();
                this.Hide();
            }
            else if (userRole == "Çalışan")
            {
                CalisanMenuEkrani ekran = new CalisanMenuEkrani();
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
    }
}
