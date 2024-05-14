using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using  MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari

        Context Baglan = new Context();
        public ActionResult Index()
        {
            var degerler = Baglan.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler cari)
        {
            if (!ModelState.IsValid)  //validasyon kontrolü
            {
                return View("CariEkle"); //validasyon işlemleri doğru değilse ekleme ekranına geri dön 
            }
            cari.Durum = true; // ilk eklendiğinde true yap 
            Baglan.Carilers.Add(cari);
            Baglan.SaveChanges();
            return RedirectToAction("Index");
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
            if (!ModelState.IsValid)  //validasyon kontrolü
            {
                return View("CariGetir"); //validasyon işlemleri doğru değilse güncelleme ekranına geri dön 
            }
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