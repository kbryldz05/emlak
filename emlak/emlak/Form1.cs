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
    public enum KayitDurum
    {
        Insert,
        Update
    }
    public partial class Form1 : Form
    {
        public KayitDurum durum = KayitDurum.Insert;
        public int id;
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void btnKaydet_Click(object sender, EventArgs e)
        {
            using (var ctx = new EmlakContext())
            {
                switch (durum)
                {
                    case KayitDurum.Insert:
                        var ogr = new emlak { OdaSayisi = int.Parse(txtOdaSayisi.Text.Trim()), Metrekare = int.Parse(txtM2.Text.Trim()), Fiyat = int.Parse(txtFiyat.Text.Trim()), Sehir = txtSehir.Text.Trim() };
                        ctx.Emlaklar.Add(ogr);
                        break;
                    case KayitDurum.Update:
                        var emlak = ctx.Emlaklar.Find(id);
                        if (emlak != null)
                        {
                            emlak.OdaSayisi = int.Parse(txtOdaSayisi.Text.Trim());
                            emlak.Metrekare = int.Parse(txtM2.Text.Trim());
                            emlak.Fiyat = int.Parse(txtFiyat.Text.Trim());
                            emlak.Sehir = txtSehir.Text.Trim();
                            durum = KayitDurum.Insert;
                        }
                        break;
                    default:
                        break;
                }
                int sonuc = ctx.SaveChanges();
                if (sonuc > 0)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    Clean();
                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız");
                }
            }
        }

        void Clean()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = String.Empty;
                }
            }
        }

        public void btnBul_Click(object sender, EventArgs e)
        {
            frmBul frm = new frmBul(this);
            frm.ShowDialog();
        }
    }
    }

