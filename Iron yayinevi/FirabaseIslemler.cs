using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace Iron_yayinevi
{
    class FirabaseIslemler
    {
        //public FirestoreDb database;
        

        public async Task<string> Kullanici_ekleAsync(Kullanicilar kl)
        {
          
            int len = Convert.ToInt32(await kullanici_sayisi());
            len++;

            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            DocumentReference col = database.Collection("kullanicilar").Document(len.ToString());

            string result = col.SetAsync(kl).ToString();
            return result;

        }

        public async Task<Kullanicilar> getuser(string id)
        {
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            DocumentReference documentReference = database.Collection("kullanicilar")
               .Document(id);
            DocumentSnapshot snap = await documentReference.GetSnapshotAsync();

            if (snap.Exists)
            {
                Kullanicilar k1 = snap.ConvertTo<Kullanicilar>();
                return k1;
            }
            return null;
        }

     
        public List<Kullanicilar> butunKullanicilariGoster()
        {
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            List<Kullanicilar> kullanicilarList = new List<Kullanicilar>();
            Query Qref = database.Collection("kullanicilar");
            QuerySnapshot snap = Qref.GetSnapshotAsync().Result;

            foreach (DocumentSnapshot snapshot in snap)
            {
                Kullanicilar kullanici = snapshot.ConvertTo<Kullanicilar>();

                kullanicilarList.Add(kullanici);

            }

            return kullanicilarList;
        }

        public async Task<int> kullanici_sayisi()
        {
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            Query Qref = database.Collection("kullanicilar");
            QuerySnapshot snap = await Qref.GetSnapshotAsync();

            int len = snap.Count;
         

            return len;
        }

        public List<Dergiler> butunDergileriGoster()
        {
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
           
            List<Dergiler> dergilerlist = new List<Dergiler>();
            Query Qref = database.Collection("dergiler");
            QuerySnapshot snap = Qref.GetSnapshotAsync().Result;

            foreach (DocumentSnapshot snapshot in snap)
            {
                Dergiler dergi = snapshot.ConvertTo<Dergiler>();

                dergilerlist.Add(dergi);

            }

            return dergilerlist;
        }

        public async Task<string> Dergi_ekleAsync(Dergiler drg, string islem, int id)
        {
            int len;
            
            if (islem == "dergi_ekle")
            {
                len = Convert.ToInt32(await dergi_sayisi());
                len++;
            }
            else// dergi guncelleme işlemi
            {
                len = id;
            }

           
              

           FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            DocumentReference col = database.Collection("dergiler").Document(len.ToString());

            string result = col.SetAsync(drg).ToString();
            return result;

        }

        public async Task<int> dergi_sayisi()
        {
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            Query Qref = database.Collection("dergiler");
            QuerySnapshot snap = await Qref.GetSnapshotAsync();

            int len = snap.Count;

            return len;
        }

        public Dergiler getDergi(string id)
        {
          
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            DocumentReference documentReference = database.Collection("dergiler")
               .Document(id);
            DocumentSnapshot snap =  documentReference.GetSnapshotAsync().Result;

            if (snap.Exists)
            {
                Dergiler dr = snap.ConvertTo<Dergiler>();
                return dr;
            }
            return null;
        }


        public async Task<string> Kitap_ekleAsync(Kitaplar kitap, string islem , string id)
        {
             int len;
            
            if (islem == "kitap_ekle")
            {
                len = Convert.ToInt32(await kitap_sayisi());
                len++;
            }
            else// kitap guncelleme işlemi
            {
                len = int.Parse(id);
            }

           FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            DocumentReference col = database.Collection("kitaplar").Document(len.ToString());

            string result = col.SetAsync(kitap).ToString();
            return result;

        }

        public async Task<int> kitap_sayisi()
        {
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            Query Qref = database.Collection("kitaplar");
            QuerySnapshot snap = await Qref.GetSnapshotAsync();

            int len = snap.Count;

            return len;
        }

        public List<Kitaplar> butunKitaplariGoster()
        {
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");

            List<Kitaplar> kitapsList = new List<Kitaplar>();
            Query Qref = database.Collection("kitaplar");
            QuerySnapshot snap = Qref.GetSnapshotAsync().Result;

            foreach (DocumentSnapshot snapshot in snap)
            {
                Kitaplar kitap = snapshot.ConvertTo<Kitaplar>();

                kitapsList.Add(kitap);

            }

            return kitapsList;
        }

        public Kitaplar getKitap(string id)
        {


            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            DocumentReference documentReference = database.Collection("kitaplar")
               .Document(id);
            DocumentSnapshot snap = documentReference.GetSnapshotAsync().Result;

            if (snap.Exists)
            {
                Kitaplar kr = snap.ConvertTo<Kitaplar>();
                return kr;
            }
            return null;
        }

        public void kitapSil(string id)
        {
            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            DocumentReference col = database.Collection("kitaplar").Document(id);

            _ = col.DeleteAsync();
        }

        public void degiSil(string id)
        {
           FirestoreDb database = FirestoreDb.Create("ironheadcsharp");
            DocumentReference col = database.Collection("dergiler").Document(id);

            _ = col.DeleteAsync();
        }

        public List<string> getIdKitaplar()
        {
            List<string> sList = new List<string>();

            FirestoreDb database = FirestoreDb.Create("ironheadcsharp");

            List<Kitaplar> kitapsList = new List<Kitaplar>();
            Query Qref = database.Collection("kitaplar");
            QuerySnapshot snap = Qref.GetSnapshotAsync().Result;

            foreach (DocumentSnapshot snapshot in snap)
            {
                Kitaplar kitap = snapshot.ConvertTo<Kitaplar>();

                kitapsList.Add(kitap);
                sList.Add(snap.GetType().ToString());
            }

            return sList;
        }


    }
}
