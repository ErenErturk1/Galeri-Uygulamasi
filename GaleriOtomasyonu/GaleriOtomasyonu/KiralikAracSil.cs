using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class KiralikAracSil : Form
    {
        public KiralikAracSil()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void btnGeri_Click(object sender, EventArgs e)
        {
            KiralikAracHizmetleri kiralik = new KiralikAracHizmetleri();
            kiralik.Show();
            this.Hide();
        }

        private void KiralikAracSil_Load(object sender, EventArgs e)
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Silme İşlemi Başarısız. " + txtAra.Text + " Plakalı Araç Bulunamadı", "Silme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                SqlCommand komut = new SqlCommand("Delete From KiralananAracBilgileri Where plaka=@plaka", connection);
                komut.Parameters.AddWithValue("@plaka", txtAra.Text);

                komut.ExecuteNonQuery();

                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Silme İşlemi Başarılı.", "Silme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (DialogResult.OK == sonuc)
                {
                    SqlCommand komut2 = new SqlCommand("Select * From KiralananAracBilgileri", connection);
                    SqlDataAdapter adap = new SqlDataAdapter(komut2);
                    DataTable tablo = new DataTable();

                    adap.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Silme İşlemi Başarısız.", "Silme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtAra.Text = "";
        }
    }
}
