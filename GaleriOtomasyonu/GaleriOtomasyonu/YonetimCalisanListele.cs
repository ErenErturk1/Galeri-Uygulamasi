using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class YonetimCalisanListele : Form
    {
        public YonetimCalisanListele()
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

        private void YonetimCalisanListele_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.CalisanBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.calisanBilgileriTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.CalisanBilgileri);
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * From CalisanBilgileri", connection);

            SqlDataAdapter adap = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();

            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;

            SqlCommand komut2 = new SqlCommand("Select sirketIsmi From CalisanBilgileri", connection);

            SqlDataReader read = komut2.ExecuteReader();
            if (read.Read())
            {
                string sirketIsmi = read["sirketIsmi"].ToString();

                lblSirket.Text = sirketIsmi;
            }
        }
    }
}
