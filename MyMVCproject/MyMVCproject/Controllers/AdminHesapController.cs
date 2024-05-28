using myfirstproject.Models.siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;
namespace WebApplication2.Controllers
{
    public class AdminHesapController : Controller
    {
        // GET: AdminHesap
        Context baglan =new Context();
        public ActionResult Hesabim()
        {
            var kullaniciad = (string)Session["KullaniciAd"];
            var admn=baglan.Admins.Where(x=>x.KullaniciAd==kullaniciad).FirstOrDefault();
            ViewBag.d1=admn.KullaniciAd.ToString();
            var degerler = baglan.Mesajs.Where(x => x.Alici == "Magaza@gmail.com" && x.Durum==true).ToList();         
            return View(degerler);         
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["KullaniciAd"];
            var id = baglan.Admins.Where(x => x.KullaniciAd == mail).Select(y => y.AdminId).FirstOrDefault();
            var adminbul = baglan.Admins.Find(id);
            return PartialView("Partial1", adminbul);
        }

        public ActionResult AdminBilgiGuncelle(Admin ad)
        {
            var admn = baglan.Admins.Find(ad.AdminId);
            admn.KullaniciAd =ad.KullaniciAd;
            admn.Sifre =ad.Sifre;
            baglan.SaveChanges();
            return RedirectToAction("Hesabim");
        }
    }
}