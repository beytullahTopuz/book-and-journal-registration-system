using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iron_yayinevi
{
    public partial class UserControlItem : UserControl
    {
        public string kitap_id { get; set; }
        public string dergi_id { get; set; }


        #region Properties
        public UserControlItem()
        {
            InitializeComponent();
        }

        private string _baslik;
        private string _icerik;
        private string _fiyat;
        private Image _image;

        [Category("Custom Props")]
        public string labeBasli
        {
            get { return _baslik; }
            set { _baslik = value; labelBaslik.Text = value; }
        }

        [Category("Custom Props")]
        public string labelIceriktext
        {
            get { return _icerik; }
            set { _icerik = value; labelIcerik.Text = value; }
        }
        [Category("Custom Props")]
        public string fiyatLabel
        {
            get { return _fiyat; }
            set { _fiyat = value; labelFiyat.Text = value; }
        }
        [Category("Custom Props")]
        public Image image
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = value; }
        }

        #endregion

        private void tiklama(object sender, EventArgs e)
        {
            // yeni sayfaya geç .....
            // kitap - dergi detay sayfasina geç
            Kitap_Dergi_detay_form kitap_Dergi_Detay_Form = new Kitap_Dergi_detay_form();
            kitap_Dergi_Detay_Form.kitap_id = kitap_id;
            kitap_Dergi_Detay_Form.dergi_id = dergi_id;
            kitap_Dergi_Detay_Form.ShowDialog();
        }
    }
}
