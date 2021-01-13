using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iron_yayinevi
{
    public partial class LoginForm : Form
    {
        FirabaseIslemler firabaseIslemler = new FirabaseIslemler();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            string path = AppDomain.CurrentDomain.BaseDirectory + @"ironheadcsharp-firebase-adminsdk-rfuz8-254703e7d6.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("ironheadcsharp");
           // MessageBox.Show("veritabanina baglati başarili uygulamaya geiniz");
        }

        private Kullanicilar _login(string mail, string sifre)
        {
            FirabaseIslemler firabaseIslemler = new FirabaseIslemler();
         
            List<Kullanicilar> kullanicilaArrayList = new List<Kullanicilar>();
            kullanicilaArrayList = firabaseIslemler.butunKullanicilariGoster();

           for(int i = 0; i< kullanicilaArrayList.Count; i++)
            {
                if(kullanicilaArrayList[i].kullanici_mail == mail && kullanicilaArrayList[i].kullanici_sifre == sifre)
                {
                    return kullanicilaArrayList[i];
                }
            }
            return null;
        }

        private void girisYap_Click(object sender, EventArgs e)
        {
            string kullanici_adi, sifre;
            kullanici_adi = kullanicitextBox.Text;
            sifre = sifretextBox.Text;
            if(kullanici_adi == "" || sifre == "")
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre bilgileri boş bırakılamaz...");
            }
            else
            {
                Kullanicilar giris_yailanLullaniciTask = _login(kullanici_adi, sifre);
                if (giris_yailanLullaniciTask != null)
                {
                    Kullanicilar giris_yailanLullanici = giris_yailanLullaniciTask;
                    Form1 form1 = new Form1();
                      form1._username = giris_yailanLullanici.kullanici_adi;

                    form1.Show();
                    this.Hide();
                 
                }
                else
                {
                    MessageBox.Show("Giriş başarısız mail ya da şifre yanlış");
                }
              
               
            }
        }

        private void label_kayitol_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
