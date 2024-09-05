using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class KiralananKisiEkle : Form
    {
        public KiralananKisiEkle()
        {
            InitializeComponent();
        }
        BaglantiAdresi baglantiAdresi = new BaglantiAdresi();
        private void button2_Click(object sender, EventArgs e)
        {
            KiralikAracHizmetleri hizmet = new KiralikAracHizmetleri();
            hizmet.Show();
            this.Hide();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtUcret.Text = "";
            dtpBasTarih.Text = "";
            dtpBitTarih.Text = "";
            txtIsim.Text = "";
            txtSoyisim.Text = "";
            txtTC.Text = "";
            txtTel.Text = "";
            dtpDTarihi.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (dtpBasTarih.Text != "" && dtpBitTarih.Text != "" && txtIsim.Text != "" && txtSoyisim.Text != "" && txtTC.Text != "" && txtTel.Text != "" && txtUcret.Text != "")
            {
                DateTime bitis = Convert.ToDateTime(dtpBitTarih.Text.ToString());
                DateTime baslangic = Convert.ToDateTime(dtpBasTarih.Text.ToString());
                DateTime dogum = Convert.ToDateTime(dtpDTarihi.Text.ToString());
                DateTime simdi = DateTime.Now;
                if (baslangic <= bitis)
                {
                    if (simdi.Year - dogum.Year >= 18)
                    {
                        try
                        {

                            SqlCommand komut = new SqlCommand("Insert Into KiralananKisiBilgileri(adi,soyadi,tc,tel,dogumTarihi,baslangic,bitis,ucret) values (@adi,@soyadi,@tc,@tel,@dogumTarihi,@baslangic,@bitis,@ucret)", connection);
                            komut.Parameters.AddWithValue("@adi", txtIsim.Text);
                            komut.Parameters.AddWithValue("@soyadi", txtSoyisim.Text);
                            komut.Parameters.AddWithValue("@tc", txtTC.Text);
                            komut.Parameters.AddWithValue("@tel", txtTel.Text);
                            komut.Parameters.AddWithValue("@dogumTarihi", dtpDTarihi.Text);
                            komut.Parameters.AddWithValue("@baslangic", dtpBasTarih.Text);
                            komut.Parameters.AddWithValue("@bitis", dtpBitTarih.Text);
                            komut.Parameters.AddWithValue("@ucret", txtUcret.Text);

                            komut.ExecuteNonQuery();

                            MessageBox.Show("Kayıt Ekleme İşlemi Başarılı", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kayıt Ekleme İşlemi Başarısız!" + ex, "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        dtpBasTarih.Text = "";
                        dtpBitTarih.Text = "";
                        txtIsim.Text = "";
                        txtSoyisim.Text = "";
                        txtTC.Text = "";
                        txtTel.Text = "";
                        txtUcret.Text = "";
                        dtpDTarihi.Text = "";
                    }
                    else
                        MessageBox.Show("Lütfen Doğum Tarihinizi Kontrol Edin. (Kiralama İşlemi İçin 18 Yaşında veya 18 Yaşından Büyük Olmalısınız.)", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show("Lütfen Tarihleri Kontrol Edin. (Başlangıç Tarihi Bitiş Tarihinden Büyük Olamaz)", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("Lütfen Boş Bırakmadan Tekrar Deneyin!", "Kayıt Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void KiralananKisiEkle_Load(object sender, EventArgs e)
        {
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
    }
}
