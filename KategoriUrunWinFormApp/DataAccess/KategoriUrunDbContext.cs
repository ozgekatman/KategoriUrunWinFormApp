using KategoriUrunWinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace KategoriUrunWinFormApp
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base(@"Data Source=.;Initial Catalog=KategoriUrunDB;User ID=sa;Password=1234")
        {
            Database.SetInitializer<ModelContext>(new DBInitializer<ModelContext>());
        }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().ToTable("Kategoriler");
            modelBuilder.Entity<Urun>().ToTable("Urunler");
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DBInitializer<T> : DropCreateDatabaseAlways<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            List<Kategori> kategoriler = new List<Kategori>();
            kategoriler.Add(new Kategori() { KategoriAdi = "Kitap" });
            kategoriler.Add(new Kategori() { KategoriAdi = "Kalem" });
            kategoriler.Add(new Kategori() { KategoriAdi = "Boya" });
            foreach (Kategori kategori in kategoriler)
            {
                context.Kategoriler.Add(kategori);
            }

            List<Urun> urunler = new List<Urun>();
            urunler.Add(new Urun() { UrunAdi = "Kürk Mantolu Madonna", Fiyat = 45, UreticiFirma = "Can Yayýnlarý", KategoriId = 1});
            urunler.Add(new Urun() { UrunAdi = "Son Kuþlar", Fiyat = 30, UreticiFirma = "Ýþ Bankasý Yayýnlarý", KategoriId = 1});
            urunler.Add(new Urun() { UrunAdi = "Budala", Fiyat = 40, UreticiFirma = "Zafer Yayýnlarý", KategoriId = 1 });
            urunler.Add(new Urun() { UrunAdi = "Faber Castelle", Fiyat = 55, UreticiFirma = "D&R", KategoriId = 2 });
            urunler.Add(new Urun() { UrunAdi = "Stabilo", Fiyat = 30, UreticiFirma = "Sedef", KategoriId = 2});
            urunler.Add(new Urun() { UrunAdi = "Nokia", Fiyat = 10, UreticiFirma = "Cezayirliler", KategoriId = 2});
            urunler.Add(new Urun() { UrunAdi = "Kalem Boya", Fiyat = 55, UreticiFirma = "D&R", KategoriId = 3});
            urunler.Add(new Urun() { UrunAdi = "Guaj Boya", Fiyat = 70, UreticiFirma = "Sedef", KategoriId = 3});
            urunler.Add(new Urun() { UrunAdi = "Sulu Boya", Fiyat = 50, UreticiFirma = "Cezayirliler", KategoriId = 3});
            foreach (Urun urun in urunler)
            {
                context.Urunler.Add(urun);
            }

            base.Seed(context);
        }
    }
}