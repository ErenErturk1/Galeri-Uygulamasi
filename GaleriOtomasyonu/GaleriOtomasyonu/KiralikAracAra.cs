using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class KiralikAracAra : Form
    {
        public KiralikAracAra()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGeri_Click(object sender, EventArgs e)
        {
            KiralikAracHizmetleri islem = new KiralikAracHizmetleri();
            islem.Show();
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
                    MessageBox.Show("Aradığınız Araç Bulunamadı.", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Aradığınız Araç Bulundu.", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Arama İşlemi Başarısız.", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KiralikAracAra_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.KiralananAracBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kiralananAracBilgileriTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.KiralananAracBilgileri);
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
        }
    }
}
