using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class CalisanMenuEkrani : Form
    {
        public CalisanMenuEkrani()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSifir_Click(object sender, EventArgs e)
        {
            SifirAracIslemleri islem = new SifirAracIslemleri();
            islem.Show();
            this.Hide();
        }

        private void btnIkinci_Click(object sender, EventArgs e)
        {
            IkinciElIslemleri ikinci = new IkinciElIslemleri();
            ikinci.Show();
            this.Hide();
        }

        private void btnKiralama_Click(object sender, EventArgs e)
        {
            KiralikAracHizmetleri kira = new KiralikAracHizmetleri();
            kira.Show();
            this.Hide();
        }

        private void CalisanMenuEkrani_Load(object sender, EventArgs e)
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
