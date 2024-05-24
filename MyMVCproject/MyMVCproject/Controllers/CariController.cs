using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using  MyProject.Models.siniflar;
using PagedList;

namespace WebApplication2.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari

        Context Baglan = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            var degerler = Baglan.Carilers.Where(x => x.CariAd.Contains(p) || p == null && x.Durum==true).ToList().ToPagedList(sayfa, 4); //kaçıncı sayfadan başlayacak , Hersayfada kaç değer olucak 
            return View(degerler);  //geriye degerleri döndür
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler cari)
        {
            cari.Sifre = "0000";
            cari.Durum = true; // ilk eklendiğinde true yap 
            Baglan.Carilers.Add(cari);
            Baglan.SaveChanges();
            return RedirectToAction("Index", new {p=""});
        }

        public ActionResult CariSil(int id)
        {
            var newcari = Baglan.Carilers.Find(id);
            newcari.Durum = false;
            Baglan.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult CariGetir(int id) //Güncelleme işlemi için seçilen departmanı getiricek
        {
            var newCari = Baglan.Carilers.Find(id);
            return View("CariGetir", newCari);

        }

        public ActionResult CariGuncelle(Cariler cari) //CariGetir Viewdan gelen departman
        {
            var newcari = Baglan.Carilers.Find(cari.CariId);
            newcari.CariAd = cari.CariAd;
            newcari.CariSoyad = cari.CariSoyad;
            newcari.CariMail = cari.CariMail;
            newcari.CariSehir = cari.CariSehir;
            Baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatis(int id)
        {
            var degerler=Baglan.SatisHarekets.Where(x=>x.CariId==id).ToList();
            var NewCariAd = Baglan.Carilers.Where(x => x.CariId == id).
                Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.CariAd = NewCariAd; //htmle deger taşıma
            return View(degerler);
        }


    }
}