using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models.siniflar;
using myfirstproject.Models.siniflar;
using System.Security.Cryptography;
using System.Data.Entity.Core.Objects;

namespace WebApplication2.Controllers
{
    public class UrunController : Controller
    {

        // GET: Urun
        Context baglan = new Context();
        public ActionResult Index()
        {
            var urunler = baglan.Uruns.Where(x=>x.Durum==true).ToList(); //Linq sorgusu sadece durumu true olanları getir
            return View(urunler);
        }

        [HttpGet] //Get metodu bu form yüklendiğinde 
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in baglan.Kategoris.ToList()   //Linq sorgusu ile html dropdown kutusu listesi  için 
                                           select new SelectListItem
                                           {  //x her bir kategoris kaydını temsil eder.
                                               Text = x.KategoriAd, //gözükecek ad
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;  //ViewBag controlller tarafında view tarafına veri değer taşımak için kullanılır. deger1 in değeri dgr1 adlı bir değişken oluşturuyoryz onun içine atandı .     
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {   u.Durum= true;
            baglan.Uruns.Add(u);
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = baglan.Uruns.Find(id);
            deger.Durum = false;
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in baglan.Kategoris.ToList()   //Linq sorgusu ile html dropdown kutusu listesi  için 
                                           select new SelectListItem
                                           {  //x her bir kategoris kaydını temsil eder.
                                               Text = x.KategoriAd, //gözükecek ad
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urundeger=baglan.Uruns.Find(id);
            return View("UrunGetir",urundeger); //urun getirdeki degerlerle beraber viewa götürcek
        }

       
        public ActionResult UrunGuncelle(Urun urun)
        {
            var newurun = baglan.Uruns.Find(urun.UrunId);
            newurun.UrunAd = urun.UrunAd;
            newurun.UrunGorsel = urun.UrunGorsel;
            newurun.AlisFiyat = urun.AlisFiyat;
            newurun.SatisFiyat = urun.SatisFiyat;
            newurun.SatisHarekets = urun.SatisHarekets;
            newurun.Marka = urun.Marka;
            newurun.Stok = urun.Stok;
            newurun.KategoriId = urun.KategoriId;
            newurun.Durum = urun.Durum;
            baglan.SaveChanges();
            return RedirectToAction("Index"); //güncelleme işleminden sonra kategori Index sayfasına dön. 


        }

    }

  


}