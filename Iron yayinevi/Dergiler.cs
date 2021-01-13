using System;
using System.Collections.Generic;
using System.Text;

using Google.Cloud.Firestore;

namespace Iron_yayinevi
{
    [FirestoreData]
    class Dergiler
    {
        [FirestoreProperty]
        public string dergi_aciklama { get; set; }
        [FirestoreProperty]
        public string dergi_adi { get; set; }
        [FirestoreProperty]
        public string dergi_basim_tarihi { get; set; }
        [FirestoreProperty]
        public string degi_fiyat { get; set; }
        [FirestoreProperty]
        public string dergi_foto_url { get; set; }
        [FirestoreProperty]
        public string dergi_kategori { get; set; }
        [FirestoreProperty]
        public string dergi_sayfa_sayisi { get; set; }
        [FirestoreProperty]
        public string dergi_stok_adet { get; set; }
    }
}
