using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace GaleriOtomasyonu
{
    public partial class KiralikAracListele : Form
    {
        public KiralikAracListele()
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

        private void KiralikAracListele_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.KiralananAracBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kiralananAracBilgileriTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.KiralananAracBilgileri);
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            connection.Open();

            SqlCommand komut = new SqlCommand("Select * From KiralananAracBilgileri", connection);

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
