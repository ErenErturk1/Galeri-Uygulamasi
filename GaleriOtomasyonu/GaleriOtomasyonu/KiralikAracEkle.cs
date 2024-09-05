using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class KiralikAracEkle : Form
    {
        public KiralikAracEkle()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();

        private void KiralikAracEkle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.AracMarkalari' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.aracMarkalariTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.AracMarkalari);
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            connection.Open();
            txtHasar.Visible = false;
            SqlCommand komut = new SqlCommand("Select sirketIsmi From CalisanBilgileri", connection);

            SqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {
                string sirketIsmi = read["sirketIsmi"].ToString();

                lblSirket.Text = sirketIsmi;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KiralikAracHizmetleri kiralik = new KiralikAracHizmetleri();
            kiralik.Show();
            this.Hide();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtHasar.Text = "";
            txtKM.Text = "";
            txtModel.Text = "";
            txtPlaka.Text = "";
            txtRenk.Text = "";
            cbMarka.Text = "";
            radioButton2.Checked = false;
            radioButton1.Checked = false;
        }

        private void btnKiralaKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if ((txtHasar.Text != "" || radioButton2.Checked) && txtKM.Text != "" && txtModel.Text != "" && txtPlaka.Text != "" && txtRenk.Text != "" && cbMarka.Text != "")
            {
                try
                {

                    SqlCommand komut = new SqlCommand("Insert Into KiralananAracBilgileri(marka,renk,plaka,model,km,hasar) values (@marka,@renk,@plaka,@model,@km,@hasar)", connection);
                    if (txtHasar.Visible == true)
                    {
                        komut.Parameters.AddWithValue("@hasar", txtHasar.Text);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@hasar", radioButton2.Text);
                    }
                    komut.Parameters.AddWithValue("@marka", cbMarka.Text);
                    komut.Parameters.AddWithValue("@renk", txtRenk.Text);
                    komut.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                    komut.Parameters.AddWithValue("@model", txtModel.Text);
                    komut.Parameters.AddWithValue("@km", txtKM.Text);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Ekleme İşlemi Başarılı", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Kayıt Ekleme İşlemi Başarısız!", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtHasar.Text = "";
                txtKM.Text = "";
                txtModel.Text = "";
                txtPlaka.Text = "";
                txtRenk.Text = "";
                cbMarka.Text = "";
                radioButton2.Checked = false;
                radioButton1.Checked = false;
            }
            else
                MessageBox.Show("Lütfen Boş Bırakmadan Tekrar Deneyin!", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtHasar.Visible = true;
            radioButton1.Visible = false;
            txtHasar.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            txtHasar.Visible = false;
        }
    }
}
