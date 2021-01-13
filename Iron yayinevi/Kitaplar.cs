using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iron_yayinevi
{
    [FirestoreData]
    class Kitaplar
    {
        [FirestoreProperty]
        public string kitap_adi { get; set; }
        [FirestoreProperty]
        public string kitap_yazari { get; set; }
        [FirestoreProperty]
        public string kitap_aciklama { get; set; }
        [FirestoreProperty]
        public string kitap_sayfa_sayisi { get; set; }
        [FirestoreProperty]
        public string kitap_kategori { get; set; }
        [FirestoreProperty]
        public string kitap_fiyat { get; set; }
        [FirestoreProperty]
        public string kitap_stok_adet { get; set; }
        [FirestoreProperty]
        public string kitap_foto_urt { get; set; }
    }
}
