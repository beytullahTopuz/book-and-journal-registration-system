using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iron_yayinevi
{
    public partial class DergiEkle : Form
    {
        public DergiEkle()
        {
            InitializeComponent();
        }

        private void button_kaydi_tamamla_Click(object sender, EventArgs e)
        {
            
            string d_adi, d_aciklama, d_basim_tarihi, d_kategori, d_sayfa_sayisi, d_stok_adeti, d_fiyat, d_foto_url;

            d_adi = textBox_adi.Text;
            d_aciklama = textBox_aciklama.Text;
            d_basim_tarihi = textBox_tarih.Text;
            d_kategori = textBox_kategori.Text;
            d_sayfa_sayisi = textBox_sayfa_sayisi.Text;
            d_stok_adeti = textBox_stok_adeti.Text;
            d_fiyat = textBox_fiyat.Text;
            d_foto_url = textBox_foto_url.Text;

            if(d_adi == "" || d_aciklama == "" || d_basim_tarihi == "" || d_kategori == "" || d_sayfa_sayisi == "" || d_stok_adeti == "" || d_fiyat == "" || d_foto_url == "")
            {
                MessageBox.Show("Bilgiler Boş Bırakılamaz!! Bilgileri eksiksiz doldurup tekrar deneyiniz");
            }
            else
            {
                Dergiler currentDergi = new Dergiler();
                

                currentDergi.dergi_adi = d_adi;
                currentDergi.dergi_aciklama = d_aciklama;
                currentDergi.dergi_basim_tarihi = d_basim_tarihi;
                currentDergi.dergi_kategori = d_kategori;
                currentDergi.dergi_sayfa_sayisi = d_sayfa_sayisi;
                currentDergi.dergi_stok_adet = d_stok_adeti;
                currentDergi.degi_fiyat = d_fiyat;
                currentDergi.dergi_foto_url = d_foto_url;

                _dergi_ekle(currentDergi);
            }      

        }

        private void _dergi_ekle(Dergiler d)
        {
            FirabaseIslemler firabaseIslemler = new FirabaseIslemler();
            _ = firabaseIslemler.Dergi_ekleAsync(d, "dergi_ekle",9999);
            MessageBox.Show("Derginiz başarıyla eklenmiştir");

            this.Close();
            
        }
    }
}
