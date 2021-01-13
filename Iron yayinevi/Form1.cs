using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Cloud.Firestore;



/* 
    beytullah topuz 1180505035 
    görsel programlama proje ödevi 
    kitap ve dergi kayıtkarı otomasyon sistemi, google firabese veri tabanı ile... 
 */
namespace Iron_yayinevi
{
    public partial class Form1 : Form
    {
        public string _username { get; set; }

       
    

        FirabaseIslemler firabaseIslemler = new FirabaseIslemler();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            getusermethod();

        }
        async void getusermethod()
        {
            FirabaseIslemler firabaseIslemler = new FirabaseIslemler();
            Kullanicilar k1 = new Kullanicilar();
            k1 = await firabaseIslemler.getuser("2");
            /*
           if(k1 != null)
            {
              
            }
           */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            string path = AppDomain.CurrentDomain.BaseDirectory + @"ironheadcsharp-firebase-adminsdk-rfuz8-254703e7d6.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("ironheadcsharp");
            MessageBox.Show("veritabanina baglati başarili uygulamaya geiniz");
            */

            this.FormBorderStyle = FormBorderStyle.None;

             label_user.Text = _username;
          
           

        }

   

        private void kullanici_ekle_Click(object sender, EventArgs e)
        {// artık işlevi dergi ekleme denmeleri

            // dergi ekleme sayfasina git 

            DergiEkle dergiEkle = new DergiEkle();
            dergiEkle.Show();
        
            
        }

        private void show_all_users_Click(object sender, EventArgs e)
        {
            butunUsersSayisi();
        }

        private async void butunUsersSayisi()
        {
            ArrayList usersList = new ArrayList();
            int len = await firabaseIslemler.kullanici_sayisi();

        }

        private void login_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
          //  this.Hide();
        }

        private void register_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            
        }

        public void dergileri_ekranda_goster()
        {
            List<Dergiler> dergilers = new List<Dergiler>();
            FirabaseIslemler firabaseIslemler = new FirabaseIslemler();

            dergilers = firabaseIslemler.butunDergileriGoster();



            UserControlItem[] controlItem = new UserControlItem[dergilers.Count];

           

                for (int i = 0; i< controlItem.Length; i++)
                {

                try
                {
                    controlItem[i] = new UserControlItem();

                    controlItem[i].dergi_id = (i+1).ToString();
                    controlItem[i].labeBasli = dergilers[i].dergi_adi;
                    controlItem[i].labelIceriktext = dergilers[i].dergi_aciklama;
                    controlItem[i].fiyatLabel = dergilers[i].degi_fiyat;

                    var request = WebRequest.Create(dergilers[i].dergi_foto_url);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        controlItem[i].image = Bitmap.FromStream(stream);
                    }

                    flowLayoutPanel1.Controls.Add(controlItem[i]);
                }
                catch { }
                
                
                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                {
                    flowLayoutPanel1.Controls.Add(controlItem[i]);
                }
            }
        }

        public void kitaplari_ekranda_goster()
        {
            List<Kitaplar> kitaplars = new List<Kitaplar>();
            FirabaseIslemler firabaseIslemler = new FirabaseIslemler();

            kitaplars = firabaseIslemler.butunKitaplariGoster();



            UserControlItem[] controlItem = new UserControlItem[kitaplars.Count];

            for (int i = 0; i < controlItem.Length; i++)
            {

                try
                {
                    controlItem[i] = new UserControlItem();

                    controlItem[i].kitap_id = (i + 1).ToString();
                    controlItem[i].labeBasli = kitaplars[i].kitap_adi;
                    controlItem[i].labelIceriktext = kitaplars[i].kitap_aciklama;
                    controlItem[i].fiyatLabel = kitaplars[i].kitap_fiyat;

                    var request = WebRequest.Create(kitaplars[i].kitap_foto_urt);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        controlItem[i].image = Bitmap.FromStream(stream);
                    }

                    flowLayoutPanel2.Controls.Add(controlItem[i]);
                }
                catch {
                
                }


                if (flowLayoutPanel2.Controls.Count < 0)
                {
                    flowLayoutPanel2.Controls.Clear();
                }
                else
                {
                    flowLayoutPanel2.Controls.Add(controlItem[i]);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            dergileri_ekranda_goster();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void button_kitap_ekle_Click(object sender, EventArgs e)
        {
            Kitap_ekle kitap_Ekle = new Kitap_ekle();
            kitap_Ekle.Show();
        }

        private void button_kullanici_goster_Click(object sender, EventArgs e)
        {// kitap gösterme kullanici değil

            flowLayoutPanel2.Controls.Clear();
            kitaplari_ekranda_goster();
        }

        private void button_sign_out_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            List<string> ss = new List<string>();
            ss = firabaseIslemler.getIdKitaplar();

            MessageBox.Show("id bulma çalışmaları : \n" + ss[0]);
        }
    }
}
