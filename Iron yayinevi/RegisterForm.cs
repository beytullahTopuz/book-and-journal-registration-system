using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iron_yayinevi
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void kayitOl_Click(object sender, EventArgs e)
        {
            string ad, soyad, tel, adres, mail, sifre, sifre2;
            ad = textBoxAd.Text;
            soyad = textBoxSoyad.Text;
            tel = textBoxTel.Text;
            adres = textBoxAdres.Text;
            mail = textBoxMail.Text;
            sifre = textBoxSifre.Text;
            sifre2 = textBoxSifreTekrar.Text;

            if(ad == "" || soyad == "" || mail == "" || sifre == "" || sifre2 == "")
            {
                MessageBox.Show("Adınız, Soyadınız , mail ve şifre alanları boş bırakılamaz. Bu alanları dolurup tekrar deneyiniz");
            }
            else
            {
                if(sifre != sifre2)
                {
                    MessageBox.Show("Uyarı: Şifreler aynı değil");
                }
                else
                {
                  //  MessageBox.Show("Kayıt işlemine geçebilirsdiniz....");
                    Kullanicilar tempUser = new Kullanicilar();

                    tempUser.kullanici_adi = ad;
                    tempUser.kullanici_soyad = soyad;
                    tempUser.kullanici_telefon = tel;
                    tempUser.kullanici_adres = adres;
                    tempUser.kullanici_kitap_sayisi = "0";
                    tempUser.kullanici_dergi_abone_sayisi = "0";
                    tempUser.kullanici_mail = mail;
                    tempUser.kullanici_sifre = sifre;

                    _register(tempUser);
                }
            }
        }

        private void _register(Kullanicilar myUser)
        {
            FirabaseIslemler firabaseIslemler = new FirabaseIslemler();
            _ = firabaseIslemler.Kullanici_ekleAsync(myUser);
            MessageBox.Show("kayıt başarıyla oluşturuldu ");
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
