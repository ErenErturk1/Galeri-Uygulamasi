using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class YonetimEkrani : Form
    {
        public YonetimEkrani()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGeri_Click(object sender, EventArgs e)
        {
            string userRole = Program.CurrentUserRole;

            if (userRole == "Patron")
            {
                YoneticiMenuEkrani ekran = new YoneticiMenuEkrani();
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

        private void YonetimEkrani_Load(object sender, EventArgs e)
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string userRole = Program.CurrentUserRole;

            if (userRole == "Patron")
            {
                YonetimCalisanEkle ekran = new YonetimCalisanEkle();
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string userRole = Program.CurrentUserRole;

            if (userRole == "Patron")
            {
                YonetimCalisanGuncelle ekran = new YonetimCalisanGuncelle();
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

        private void btnListele_Click(object sender, EventArgs e)
        {
            string userRole = Program.CurrentUserRole;

            if (userRole == "Patron")
            {
                YonetimCalisanListele ekran = new YonetimCalisanListele();
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            string userRole = Program.CurrentUserRole;

            if (userRole == "Patron")
            {
                YonetimCalisanAra ekran = new YonetimCalisanAra();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            string userRole = Program.CurrentUserRole;

            if (userRole == "Patron")
            {
                YonetimCalisanSil ekran = new YonetimCalisanSil();
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

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
