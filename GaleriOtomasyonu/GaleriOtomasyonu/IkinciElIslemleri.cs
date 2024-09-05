using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class IkinciElIslemleri : Form
    {
        public IkinciElIslemleri()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            IkinciElAracSil sil = new IkinciElAracSil();
            sil.Show();
            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            IkinciElAracGuncelle guncelle = new IkinciElAracGuncelle();
            guncelle.Show();
            this.Hide();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            IkinciElAracListele listele = new IkinciElAracListele();
            listele.Show();
            this.Hide();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            IkinciElAracAra ara = new IkinciElAracAra();
            ara.Show();
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            IkinciElAracEkle ekle = new IkinciElAracEkle();
            ekle.Show();
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

        private void IkinciElIslemleri_Load(object sender, EventArgs e)
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
