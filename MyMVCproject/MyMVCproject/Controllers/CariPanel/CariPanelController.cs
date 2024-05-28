using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using myfirstproject.Models.groupsiniflar;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;
namespace WebApplication2.Controllers.CariPanel
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context baglan =new Context();
        public ActionResult Index()  //Profilim bölümü
        {
            var mail = (string)Session["CariMail"];
            var cari=baglan.Carilers.Where(x=>x.CariMail==mail).FirstOrDefault();
            ViewBag.carisehir = cari.CariSehir;
            

            var degerler = baglan.Mesajs.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid = baglan.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = baglan.SatisHarekets.Where(x => x.CariId == mailid).Count().ToString();
            ViewBag.toplamsatis = toplamsatis;
            //Satış Sayısı 0 sa kasada sıfırdır
            if (Convert.ToInt32(toplamsatis) != 0)
            {
                var toplamtutar = baglan.SatisHarekets.Where(x => x.CariId == mailid).Sum(y => y.ToplamTutar);
                ViewBag.toplamtutar = toplamtutar;
                var toplamurunsayisi = baglan.SatisHarekets.Where(x => x.CariId == mailid).Sum(y => y.Adet);
                ViewBag.toplamurunsayisi = toplamurunsayisi;
            }
            else {
                ViewBag.toplamtutar = 0;
                ViewBag.toplamurunsayisi = 0;
            }
            
            var adsoyad = baglan.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id=baglan.Carilers.Where(x=>x.CariMail==mail.ToString()).
                Select(y=>y.CariId).FirstOrDefault();
            var degerler = baglan.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = baglan.Mesajs.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajId).ToList();
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = gidensayisi;         
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = baglan.Mesajs.Where(x => x.Gönderen == mail ).OrderByDescending(z => z.MesajId).ToList();
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = gidensayisi;          
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = baglan.Mesajs.Where(x => x.MesajId == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == mail ).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = gidensayisi;
            
            return View(degerler);
        }


       
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = gidensayisi;   
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesaj m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gönderen = mail;
            baglan.Mesajs.Add(m);
            baglan.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            var k = from x in baglan.Kargos select x;
            k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());
        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = baglan.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = baglan.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            var caribul = baglan.Carilers.Find(id);
            return PartialView("Partial1", caribul);
        }

        public ActionResult CariBilgiGuncelle(Cariler cr)
        {
            var cari = baglan.Carilers.Find(cr.CariId);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.Sifre = cr.Sifre;
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

       

    }
}