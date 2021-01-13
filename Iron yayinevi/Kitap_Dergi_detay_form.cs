using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iron_yayinevi
{
    public partial class Kitap_Dergi_detay_form : Form
    { 
        public string kitap_id { get; set; }
        public string dergi_id { get; set; }

        private FirabaseIslemler firabaseIslemler = new FirabaseIslemler();
        private Dergiler dergi = new Dergiler();
        private Kitaplar kitap = new Kitaplar();

        public Kitap_Dergi_detay_form()
        {
            InitializeComponent();
        }

        private void Kitap_Dergi_detay_form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            if (dergi_id != null)
            {
                dergi_getr(dergi_id.ToString());
            }
            if (kitap_id != null)
            {
                kitap_getr(kitap_id.ToString());
            }
        }

        private void dergi_getr(string id)
        {
            try
            {
                dergi = firabaseIslemler.getDergi(id);
                if(dergi != null)
                {
                    // label2.Text = dergi.dergi_adi;
                    kitapORdergi.Text = "Dergi";
                    label_basim_tarihi_OR_yazari.Text = "Basım Tarihi :";

                    textBox_ad.Text = dergi.dergi_adi;
                    textBox_yazar_or_basim_tarihi.Text = dergi.dergi_basim_tarihi;
                    textBox_aciklama.Text = dergi.dergi_aciklama;
                    textBox_sayfa_sayisi.Text = dergi.dergi_sayfa_sayisi;
                    textBox_kategori.Text = dergi.dergi_kategori;
                    textBox_fiyat.Text = dergi.degi_fiyat;
                    textBox_stok_adet.Text = dergi.dergi_stok_adet;
                    textBox_foto_url.Text = dergi.dergi_foto_url;

                }
                
            }
            catch
            {
             //   label2.Text = "HATA";
            }
            
        }
        private void kitap_getr(string id)
        {
            try
            {
                kitap = firabaseIslemler.getKitap(id);
                if (kitap != null)
                {
                   
                    kitapORdergi.Text = "Kitap";
                    label_basim_tarihi_OR_yazari.Text = "Yazarı :";

                    textBox_ad.Text = kitap.kitap_adi;
                    textBox_yazar_or_basim_tarihi.Text = kitap.kitap_yazari;
                    textBox_aciklama.Text = kitap.kitap_aciklama;
                    textBox_sayfa_sayisi.Text = kitap.kitap_sayfa_sayisi;
                    textBox_kategori.Text = kitap.kitap_kategori;
                    textBox_fiyat.Text = kitap.kitap_fiyat;
                    textBox_stok_adet.Text = kitap.kitap_stok_adet;
                    textBox_foto_url.Text = kitap.kitap_foto_urt;
                }

            }
            catch
            {
              //  label2.Text = "HATA";
            }

        }

        private void button_sil_Click(object sender, EventArgs e)
        {
           
            if (isTexBoxesIsEmpty())
            {
                MessageBox.Show("Boş bilgiler silinemez");
            }
            else
            {
                //silme işlemini başlat
                try
                {
                    FirabaseIslemler firabaseIslemler = new FirabaseIslemler();
                    if (dergi_id != null)
                    {
                        firabaseIslemler.degiSil(dergi_id);
                        MessageBox.Show("işlem başarılı");
                        this.Close();
                    }
                    if (kitap_id != null)
                    {
                        firabaseIslemler.kitapSil(kitap_id);
                        MessageBox.Show("işlem başarılı");
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("hata oluştu");
                }
            }
        }

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            // güncelleme işlemini başlat
            if (isTexBoxesIsEmpty())
            {
                MessageBox.Show("Bilgiler boş bırakılamaz");
            }
            else
            {
                try
                {
                    if (kitap_id != null)
                    {
                        kitap.kitap_adi = textBox_ad.Text;
                        kitap.kitap_yazari = textBox_yazar_or_basim_tarihi.Text;
                        kitap.kitap_aciklama = textBox_aciklama.Text;
                        kitap.kitap_sayfa_sayisi = textBox_sayfa_sayisi.Text;
                        kitap.kitap_kategori = textBox_kategori.Text;
                        kitap.kitap_fiyat = textBox_fiyat.Text;
                        kitap.kitap_stok_adet = textBox_stok_adet.Text;
                        kitap.kitap_foto_urt = textBox_foto_url.Text;

                       
                       _ = firabaseIslemler.Kitap_ekleAsync(kitap , "kitap_guncelle",kitap_id);
                    }
                    if (dergi_id != null)
                    {
                        dergi.dergi_adi = textBox_ad.Text;
                        dergi.dergi_basim_tarihi = textBox_yazar_or_basim_tarihi.Text;
                        dergi.dergi_aciklama = textBox_aciklama.Text;
                        dergi.dergi_sayfa_sayisi = textBox_sayfa_sayisi.Text;
                        dergi.dergi_kategori = textBox_kategori.Text;
                        dergi.degi_fiyat = textBox_fiyat.Text;
                        dergi.dergi_stok_adet = textBox_stok_adet.Text;
                        dergi.dergi_foto_url = textBox_foto_url.Text;

                        _ = firabaseIslemler.Dergi_ekleAsync(dergi,"guncelleme",Int32.Parse(dergi_id));
                    }
                    MessageBox.Show("Güncelleme Başarılı..");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Hata Oluştu..");
                    this.Close();
                }
            }
        }

        private bool isTexBoxesIsEmpty()
        {// false degeri texbox içlerinin dolu olduğunu gösterir

            if (textBox_ad.Text == "" || textBox_yazar_or_basim_tarihi.Text == "" || textBox_aciklama.Text == "" || textBox_sayfa_sayisi.Text == "" ||
                textBox_kategori.Text == "" || textBox_fiyat.Text == "" || textBox_stok_adet.Text == "" || textBox_foto_url.Text == "")
            {
                // MessageBox.Show("Bilgiler boş bırakılamaz...");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
