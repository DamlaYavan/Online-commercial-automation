using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.groupsiniflar;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context baglan =new Context();
        public ActionResult Index()
        {
            var deger1 = baglan.Personels.Count().ToString();
            ViewBag.d1=deger1;
            var deger2=baglan.Uruns.Count().ToString();
            ViewBag.d2=deger2;
            var deger3 = baglan.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = baglan.Departmans.Count().ToString();
            ViewBag.d4 = deger4;

            var yapilacaklar = baglan.Yapilacaks.ToList();
            return View(yapilacaklar);           

        }

        [HttpGet]
        public ActionResult ekle()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ekle(Yapilacak not)
        {         

            baglan.Yapilacaks.Add(not);
            baglan.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}