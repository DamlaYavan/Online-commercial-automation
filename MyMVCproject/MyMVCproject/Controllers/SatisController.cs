using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;
namespace WebApplication2.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis

        Context baglan=new Context();
        public ActionResult Index()
        {
            var degerler=baglan.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {   List <SelectListItem> urunler=(from x in baglan.Uruns.ToList()
                                       where x.Durum==true
                                       select new SelectListItem
                                       {
                                           Text = x.UrunAd,
                                           Value= x.UrunId.ToString()
                                       }).ToList();
            ViewBag.urunler=urunler;
            List<SelectListItem> cariler = (from x in baglan.Carilers.ToList()
                                            where x.Durum==true
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd +" "+ x.CariSoyad,
                                                Value = x.CariId.ToString()
                                            }).ToList();
            ViewBag.cariler = cariler;
            List<SelectListItem> personeller = (from x in baglan.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAd +" "+ x.PersonelSoyad,
                                                Value = x.PersonelId.ToString()
                                            }).ToList();
            ViewBag.personeller = personeller;
            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());  //o anki tarihi alsın.
            baglan.SatisHarekets.Add(satis);
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urunler = (from x in baglan.Uruns.ToList()
                                            where x.Durum == true
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunId.ToString()
                                            }).ToList();
            ViewBag.urunler = urunler;
            List<SelectListItem> cariler = (from x in baglan.Carilers.ToList()
                                            where x.Durum == true
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariId.ToString()
                                            }).ToList();
            ViewBag.cariler = cariler;
            List<SelectListItem> personeller = (from x in baglan.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelId.ToString()
                                                }).ToList();
            ViewBag.personeller = personeller;
            var deger = baglan.SatisHarekets.Find(id);
            return View("Satisgetir",deger);
        }

        public ActionResult SatisGuncelle(SatisHareket satis)
        {
            var newSatis = baglan.SatisHarekets.Find(satis.SatisId);
            newSatis.SatisId= satis.SatisId;
            newSatis.UrunId= satis.UrunId;
            newSatis.CariId= satis.CariId;
            newSatis.PersonelId= satis.PersonelId;
            newSatis.Adet= satis.Adet;
            newSatis.Fiyat= satis.Fiyat;
            newSatis.ToplamTutar= satis.ToplamTutar;
            newSatis.Tarih= DateTime.Parse(DateTime.Now.ToShortDateString());
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler=baglan.SatisHarekets.Where(x=>x.SatisId==id).ToList();
            return View(degerler);
        }
    }
}



