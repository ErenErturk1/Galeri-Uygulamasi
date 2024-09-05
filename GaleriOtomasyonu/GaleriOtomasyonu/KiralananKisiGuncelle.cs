using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaleriOtomasyonu
{
    public partial class KiralananKisiGuncelle : Form
    {
        public KiralananKisiGuncelle()
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(baglantiAdresi.adres);
            if (txtAra.Text == "")
            {
                MessageBox.Show("Lütfen Bilgilerini Güncellemek İstediğiniz Kişiyi İlk Önce T.C No Bilgisi İle Arama Yapın", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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
                                if (connection.State == ConnectionState.Closed)
                                {
                                    connection.Open();
                                }
                                SqlCommand komut = new SqlCommand("UPDATE KiralananKisiBilgileri SET adi=@adi, soyadi=@soyadi, tc=@tc, tel=@tel, dogumTarihi=@dogumTarihi, baslangic=@baslangic, bitis=@bitis, ucret=@ucret  Where tc=@tc2", connection);
                                komut.Parameters.AddWithValue("@adi", txtIsim.Text);
                                komut.Parameters.AddWithValue("@soyadi", txtSoyisim.Text);
                                komut.Parameters.AddWithValue("@tc", txtTC.Text);
                                komut.Parameters.AddWithValue("@tel", txtTel.Text);
                                komut.Parameters.AddWithValue("@dogumTarihi", dtpDTarihi.Text);
                                komut.Parameters.AddWithValue("@baslangic", dtpBasTarih.Text);
                                komut.Parameters.AddWithValue("@bitis", dtpBitTarih.Text);
                                komut.Parameters.AddWithValue("@ucret", txtUcret.Text);
                                komut.Parameters.AddWithValue("@tc2", txtAra.Text);

                                komut.ExecuteNonQuery();

                                DialogResult sonuc = new DialogResult();
                                sonuc = MessageBox.Show("Güncelleme İşlemi Başarılı.", "Güncelleme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (DialogResult.OK == sonuc)
                                {
                                    SqlCommand komut2 = new SqlCommand("Select * From KiralananKisiBilgileri", connection);
                                    SqlDataAdapter adap = new SqlDataAdapter(komut2);
                                    DataTable tablo = new DataTable();

                                    adap.Fill(tablo);
                                    dataGridView1.DataSource = tablo;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Güncelleme İşlemi Başarısız.", "Güncelleme İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            txtUcret.Text = "";
                            dtpBasTarih.Text = "";
                            dtpBitTarih.Text = "";
                            txtIsim.Text = "";
                            txtSoyisim.Text = "";
                            txtTC.Text = "";
                            txtTel.Text = "";
                            dtpDTarihi.Text = "";
                            txtAra.Text = "";
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
        }

        private void KiralananKisiGuncelle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'galeriOtomasyonuDataSet1.KiralananKisiBilgileri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kiralananKisiBilgileriTableAdapter1.Fill(this.galeriOtomasyonuDataSet1.KiralananKisiBilgileri);

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
            txtUcret.Text = "";
            dtpBasTarih.Text = "";
            dtpBitTarih.Text = "";
            txtIsim.Text = "";
            txtSoyisim.Text = "";
            txtTC.Text = "";
            txtTel.Text = "";
            dtpDTarihi.Text = "";
            txtAra.Text = "";
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
                SqlCommand komut = new SqlCommand("Select * From KiralananKisiBilgileri Where tc=@tc", connection);
                komut.Parameters.AddWithValue("@tc", txtAra.Text);
                SqlDataAdapter adap = new SqlDataAdapter(komut);

                DataTable tablo = new DataTable();

                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;

                if (dataGridView1.CurrentCell == null)
                {
                    MessageBox.Show("Aradığınız Kişi Bulunamadı", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Aradığınız Kişi Bulundu", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Arama İşleminde Hata!", "Arama İşlemi Durumu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
