using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class SifirAracListele : Form
    {
        public SifirAracListele()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void SifirAracListele_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.SifirAracBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sifirAracBilgileriTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.SifirAracBilgileri);
            try
            {

                SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
                connection.Open();
                SqlCommand komut = new SqlCommand("Select * From SifirAracBilgileri", connection);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            SifirAracIslemleri islem = new SifirAracIslemleri();
            islem.Show();
            this.Hide();
        }
    }
}
