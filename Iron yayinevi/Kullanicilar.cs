using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Iron_yayinevi
{
    [FirestoreData]
    class Kullanicilar
    {
        [FirestoreProperty]
        public String kullanici_adi { get; set; }
        [FirestoreProperty]
        public String kullanici_adres { get; set; }
        [FirestoreProperty]
        public String kullanici_dergi_abone_sayisi { get; set; }
        [FirestoreProperty]
        public String kullanici_kitap_sayisi { get; set; }
        [FirestoreProperty]
        public String kullanici_mail { get; set; }
        [FirestoreProperty]
        public String kullanici_sifre { get; set; }
        [FirestoreProperty]
        public String kullanici_soyad { get; set; }
        [FirestoreProperty]
        public String kullanici_telefon { get; set; }

        public static implicit operator Kullanicilar(ArrayList v)
        {
            throw new NotImplementedException();
        }


    }
}
