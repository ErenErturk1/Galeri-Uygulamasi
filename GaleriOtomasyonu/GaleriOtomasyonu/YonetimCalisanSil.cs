using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class YonetimCalisanSil : Form
    {
        public YonetimCalisanSil()
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

        private void YonetimCalisanSil_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet.CalisanBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.calisanBilgileriTableAdapter.Fill(this.galeriOtomasyonuDataSet.CalisanBilgileri);
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
        string tcNo = string.Empty;
        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Silme İşlemi Başarısız. " + txtAra.Text + " Kimlik Numaralı Çalışan Bulunamadı", "Silme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                SqlCommand komut = new SqlCommand("Delete From CalisanBilgileri Where tc=@tc", connection);
                komut.Parameters.AddWithValue("@tc", txtAra.Text);

                tcNo = Convert.ToString(Program.CurrentUserTC);

                komut.ExecuteNonQuery();

                DialogResult sonuc = new DialogResult();
                sonuc = MessageBox.Show("Silme İşlemi Başarılı.", "Silme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txtAra.Text == tcNo)
                {
                    MessageBox.Show("Hesabınızdan Çıkış Yapılıyor...", "Hesap Durumu", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Giris giris = new Giris();
                    giris.Show();
                    this.Hide();
                }
                if (DialogResult.OK == sonuc)
                {
                    SqlCommand komut2 = new SqlCommand("Select * From CalisanBilgileri", connection);
                    SqlDataAdapter adap = new SqlDataAdapter(komut2);
                    DataTable tablo = new DataTable();

                    adap.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme İşlemi Başarısız." + ex, "Silme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtAra.Text = "";

        }
    }
}
