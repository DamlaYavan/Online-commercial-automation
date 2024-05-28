using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {


        // GET: Departman
        Context baglan=new Context();
        public ActionResult Index() 
        {
            var degerler = baglan.Departmans.Where(x=>x.Durum==true).ToList(); //durumu true olan departmanları getir
            return View(degerler);
        }


        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            departman.Durum = true;
            baglan.Departmans.Add(departman);
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var newdep = baglan.Departmans.Find(id);
            newdep.Durum = false;
            baglan.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DepartmanGetir(int id) //Güncelleme işlemi için seçilen departmanı getiricek
        {
            var newdepartman = baglan.Departmans.Find(id);
            return View("DepartmanGetir",newdepartman);
            
        }

        public ActionResult DepartmanGuncelle(Departman departman) //DepartmanGetir Viewdan gelen departman
        {
            var newdepartman = baglan.Departmans.Find(departman.DepartmanId);
            newdepartman.DepartmanAd = departman.DepartmanAd;
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id) 
        {
            var degerler = baglan.Personels.Where(x => x.Departmanid == id).ToList();
            var NewDptAd=baglan.Departmans.Where(x=> x.DepartmanId==id).
                Select(y=>y.DepartmanAd).
                FirstOrDefault(); //tek değer çek first or default 
            ViewBag.DptAd=NewDptAd;
            return View(degerler);
        }

        public ActionResult DptPersonelSatis(int id)
        {
            var degerler = baglan.SatisHarekets.Where(p=>p.PersonelId==id).ToList();
            var NewPrsnelAd=baglan.Personels.Where(x=>x.PersonelId==id).
                Select(y => y.PersonelAd + " "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.PersonelAd=NewPrsnelAd;
            return View(degerler);
        }
    }
}