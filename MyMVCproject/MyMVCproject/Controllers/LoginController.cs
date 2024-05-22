using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        Context baglan=new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult KayitOl()  //partialView
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult KayitOl(Cariler cari)  //partialView
        {
        //    if (!ModelState.IsValid)  //validasyon kontrolü
        //    {
        //        return View("CariEkle"); //validasyon işlemleri doğru değilse ekleme ekranına geri dön 
        //    }
            cari.Durum = true; // ilk eklendiğinde true yap 
            baglan.Carilers.Add(cari);
            baglan.SaveChanges();
            return PartialView();
        }
    }
}