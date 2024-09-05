using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class KiralikAracHizmetleri : Form
    {
        public KiralikAracHizmetleri()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KiralikAracEkle ekle = new KiralikAracEkle();
            ekle.Show();
            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            KiralikAracGuncelle guncelle = new KiralikAracGuncelle();
            guncelle.Show();
            this.Hide();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            KiralikAracListele listele = new KiralikAracListele();
            listele.Show();
            this.Hide();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            KiralikAracAra ara = new KiralikAracAra();
            ara.Show();
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            KiralikAracSil sil = new KiralikAracSil();
            sil.Show();
            this.Hide();
        }

        private void btnKiralananKisiEkle_Click(object sender, EventArgs e)
        {
            KiralananKisiEkle ekle2 = new KiralananKisiEkle();
            ekle2.Show();
            this.Hide();
        }

        private void btnKiralananKisiGuncelle_Click(object sender, EventArgs e)
        {
            KiralananKisiGuncelle guncelle2 = new KiralananKisiGuncelle();
            guncelle2.Show();
            this.Hide();
        }

        private void btnKiralananKisiListele_Click(object sender, EventArgs e)
        {
            KiralananKisiListele listele2 = new KiralananKisiListele();
            listele2.Show();
            this.Hide();
        }

        private void btnKiralananKisiAra_Click(object sender, EventArgs e)
        {
            KiralananKisiAra ara2 = new KiralananKisiAra();
            ara2.Show();
            this.Hide();
        }

        private void btnKiralananKisiSil_Click(object sender, EventArgs e)
        {
            KiralananKisiSil sil2 = new KiralananKisiSil();
            sil2.Show();
            this.Hide();
        }

        private void KiralikAracHizmetleri_Load(object sender, EventArgs e)
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
    }
}
