using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;
using myfirstproject.Models.groupsiniflar;

namespace WebApplication2.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik

        Context baglan = new Context();
        public ActionResult Index()
        {
            var ToplamCari=baglan.Carilers.Count().ToString();
            ViewBag.ToplamCari=ToplamCari;

            var ToplamPersonel = baglan.Personels.Count().ToString();
            ViewBag.ToplamPersonel = ToplamPersonel;

            var ToplamDepartman = baglan.Departmans.Count().ToString();
            ViewBag.ToplamDepartman = ToplamDepartman;

            var ToplamKategori = baglan.Kategoris.Count().ToString();
            ViewBag.ToplamKategori = ToplamKategori;

            var ToplamUrun = baglan.Uruns.Count().ToString();
            ViewBag.ToplamUrun = ToplamUrun;

            var ToplamStok = baglan.Uruns.Sum(x=>x.Stok).ToString(); //Urunler tablosundaki Tüm ürünlerin stok toplamı
            ViewBag.ToplamStok = ToplamStok;

            var KritikSeviye=baglan.Uruns.Count(x=>x.Stok <= 15).ToString(); //stok sayısı 15 den az olan ürünler kritik seviyede 
            ViewBag.KritikSeviye = KritikSeviye;

            var MarkaSayisi = (from x in baglan.Uruns 
                               select x.Marka
                               ).Distinct().Count().ToString();  //Distinct tekrarsız say bir marka bir sayım
            ViewBag.MarkaSayisi = MarkaSayisi;

            var KasadakiTutar = baglan.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.KasadakiTutar = KasadakiTutar;

            DateTime bugun = DateTime.Today;
            var BugunSatis = baglan.SatisHarekets.Count(x => x.Tarih==bugun).ToString();  //Bugün ki satış sayisi
            ViewBag.BugunSatis = BugunSatis;

            //Satış Sayısı 0 sa kasada sıfırdır
            if (Convert.ToInt32(BugunSatis) !=0) 
            {
                var BugunKasa = baglan.SatisHarekets.Where(x => x.Tarih == bugun).Sum(x => x.ToplamTutar).ToString();
                ViewBag.BugunKasa = BugunKasa;
            }
            else { ViewBag.BugunKasa = BugunSatis; }


            var EnCokSatan = from SatisHareket in baglan.SatisHarekets
                             join Urun in baglan.Uruns on SatisHareket.UrunId equals Urun.UrunId
                             group SatisHareket by SatisHareket.Urun.UrunAd into grup
                             select new
                             {
                                 UrunAd = grup.Key,
                                 Adet = grup.Sum(x => x.Adet)
                             };
            ViewBag.EnCokSatan = EnCokSatan.OrderByDescending(x => x.Adet).ToList().FirstOrDefault().UrunAd;

            ////En fazla ürünü olan marka 
            // var enmarka=baglan.Uruns.GroupBy(x=>x.Marka).OrderByDescending(z=>z.Count()
            // ).Select(y=>y.Key).FirstOrDefault();
            ////Belirli bir üründen kaç çeşit var
            //var BuzdolabiSayisi = baglan.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ////Max fiyatli Ürünü bulmak istersek. // min istersek descending yerine ascending(z den a)
            //var MaxFiyatUruns = (from x in baglan.Uruns
            //                     orderby x.SatisFiyat descending
            //                     select x.UrunAd).FirstOrDefault();


            return View();
        }

        // End İstatik


        // Hızlı tablolar başlangıç
        public ActionResult BasicTables()  //kolay incelenebilir tablolar  
        {
            var Sorgu = from x in baglan.Carilers     //Müşteri Şeir tablosunu partial olarak yapılmadı
                        group x by x.CariSehir into g  //g grup içine dahil olucak alan
                        select new TabloGrup
                        {
                            Sehir = g.Key,  // o grubun alanı string 
                            Sayi = g.Count()  //Şehire bağlı müşteri sayısı

                        };
            return View(Sorgu.ToList());
        }

        public PartialViewResult DeprtmnPersnlPartial()
        {
            var Sorgu2 = from x in baglan.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new TabloGrup2
                        {
                            Departman = g.Key,
                            PersonelSayisi = g.Count()  
                        };
            return PartialView(Sorgu2.ToList());
        }

        public PartialViewResult CarilerPartial()
        {
            var Sorgu3 = baglan.Carilers.Where(x=>x.Durum==true).ToList();
            return PartialView(Sorgu3);
        }

        public PartialViewResult UrunlerPartial()
        {
            var Sorgu4 = baglan.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(Sorgu4);
        }

        public PartialViewResult UrunMarkaPartial()
        {
            var Sorgu5 = from x in baglan.Uruns
                         group x by x.Marka into g
                         select new TabloGrup3
                         {
                             Marka = g.Key,
                             Sayi = g.Count()  //Markadaki ürün sayısı
                         };
            return PartialView(Sorgu5.ToList());
        }

        public PartialViewResult UrunKategoriPartial()
        {
            var Sorgu6 = from x in baglan.Uruns
                         group x by x.Kategori.KategoriAd into g
                         select new TabloGrup4
                         {
                             Kategori = g.Key,
                             UrunSayisi = g.Count()
                         };
            return PartialView(Sorgu6.ToList());
        }
        //Hızlı tablolar bitiş
    }
}