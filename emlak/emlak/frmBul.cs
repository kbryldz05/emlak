using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace emlak
{
    public partial class frmBul : Form
    {
        Form1 frm;
        public frmBul(Form1 frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            using (var ctx = new EmlakContext())
            {
                var sonuc = from o in ctx.Emlaklar
                            where o.Fiyat == int.Parse(txtFiyat.Text.Trim())
                            select o; //LINQ- Language INtegrated Query
                var ogr = sonuc.FirstOrDefault();
                if (ogr != null)
                {
                    frm.txtOdaSayisi.Text = ogr.OdaSayisi.ToString();
                    frm.txtM2.Text = ogr.Metrekare.ToString();
                    frm.txtSehir.Text = ogr.Sehir;
                    frm.txtFiyat.Text=ogr.Fiyat.ToString();
                    frm.id = ogr.id;
                    frm.durum = KayitDurum.Update;
                    frm.btnKaydet.Text = "GÜNCELLE";
                  //  frm.btnVazgec.Visible = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Öğrenci Bulunamadı!");
                }
            }
        }
    }
}
