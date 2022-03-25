using KategoriUrunWinFormApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KategoriUrunWinFormApp
{
    public partial class Form1 : Form
    {
        ModelContext db = new ModelContext();
        protected int secimId = -1;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            ComboDoldur();
        }
        private void ComboDoldur()
        {
            var kategori = db.Kategoriler.ToList();
            comboBox1.DataSource = kategori;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "KategoriAdi";
            comboBox1.SelectedIndex = -1;
        }
        public void Listele()
        {
            dataGridView2.Rows.Clear();
            int i = 0, sira = 1;
            var urunler = (from s in db.Urunler
                           select new
                           {
                               Id = s.Id,
                               UrunAdi = s.UrunAdi,
                               Fiyat = s.Fiyat,
                               UreticiFirma = s.UreticiFirma,
                               KategoriAdi = s.Kategori.KategoriAdi
                           }).ToList();
            foreach (var k in urunler)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = k.Id;
                dataGridView2.Rows[i].Cells[1].Value = sira;
                dataGridView2.Rows[i].Cells[2].Value = k.UrunAdi;
                dataGridView2.Rows[i].Cells[3].Value = k.Fiyat;
                dataGridView2.Rows[i].Cells[4].Value = k.UreticiFirma;
                dataGridView2.Rows[i].Cells[5].Value = k.KategoriAdi;
                i++;
                sira++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Ekle();
        }
        private void Ekle()
        {
            Urun urun = new Urun();
            urun.UrunAdi = textBox1.Text;
            urun.Fiyat = Convert.ToInt32(textBox2.Text);
            urun.UreticiFirma = textBox3.Text;
            urun.KategoriId = (int)comboBox1.SelectedValue;
            db.Urunler.Add(urun);
            db.SaveChanges();
            MessageBox.Show(@"Kayıt basarili");
            Listele();
            Temizle();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Sil();
        }
        private void Sil()
        {
            Urun urun = db.Urunler.Find(secimId);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            MessageBox.Show(@"Silme basarili");
            Listele();
            Temizle();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Guncelle();
        }
        private void Guncelle()
        {
            Urun urun = db.Urunler.Find(secimId);
            urun.UrunAdi = textBox1.Text;
            urun.Fiyat = Convert.ToInt32(textBox2.Text);
            urun.UreticiFirma = textBox3.Text;
            urun.KategoriId = (int)comboBox1.SelectedValue;
            db.SaveChanges();
            MessageBox.Show(@"Güncelleme basarili");
            Listele();
            Temizle();
        }
        public void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            secimId = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            Ac(secimId);
        }
        private void Ac(int secimId)
        {
            Urun urun = db.Urunler.Find(secimId);
            textBox1.Text = urun.UrunAdi;
            textBox2.Text = urun.Fiyat.ToString();
            textBox3.Text = urun.UreticiFirma;
            comboBox1.Text = urun.Kategori.KategoriAdi;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
        }
    }
}