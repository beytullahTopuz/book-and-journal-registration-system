using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iron_yayinevi
{
    public partial class Kitap_ekle : Form
    {
        public Kitap_ekle()
        {
            InitializeComponent();
        }

        private void button_kitap_kayit_Click(object sender, EventArgs e)
        {
            string kitap_adi, kitap_yazari, kitap_aciklama, kitap_sayfa_sayisi, kitap_kategori, kitap_fiyat, kitap_stok_adet, kitap_foto_urt;

            kitap_adi = textBox_kitap_adi.Text;
            kitap_aciklama = textBox_kitap_aciklama.Text;
            kitap_yazari = textBox_kitap_yazari.Text;
            kitap_sayfa_sayisi = textBox_kitap_sayfa_sayisi.Text;
            kitap_kategori = textBoxkitap_kategori.Text;
            kitap_fiyat = textBox_kitap_fiyat.Text;
            kitap_stok_adet = textBox_kitap_stok.Text;
            kitap_foto_urt = textBox_kitap_foto_url.Text;

            if(kitap_adi == "" || kitap_aciklama == "" || kitap_yazari == "" || kitap_sayfa_sayisi == "" || kitap_kategori == "" || kitap_fiyat == "" || kitap_stok_adet == "" || kitap_foto_urt == "")
            {
                MessageBox.Show("Kitap bilgilerini boş bırakamazsınız...");
            }
            else
            {
                Kitaplar kt = new Kitaplar();

                kt.kitap_adi = kitap_adi;
                kt.kitap_aciklama = kitap_aciklama;
                kt.kitap_yazari = kitap_yazari;
                kt.kitap_sayfa_sayisi = kitap_sayfa_sayisi;
                kt.kitap_kategori = kitap_kategori;
                kt.kitap_fiyat = kitap_fiyat;
                kt.kitap_stok_adet = kitap_stok_adet;
                kt.kitap_foto_urt = kitap_foto_urt;

                _kitapEkle(kt);
            }
        }

        private void _kitapEkle(Kitaplar kt)
        {
            FirabaseIslemler firabaseIslemler = new FirabaseIslemler();

            try
            {
                _ = firabaseIslemler.Kitap_ekleAsync(kt, "kitap_ekle" , "9999");

                MessageBox.Show("Ekleme işlemi başarılı");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hata oluştu");
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Kitap_ekle_Load(object sender, EventArgs e)
        {

        }
    }
}
