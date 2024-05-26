using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using myfirstproject.Models.groupsiniflar;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context baglan = new Context();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GrafikOlustur()
        //{
        //    var grafikciz = new Chart(600, 600);
        //    grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").
        //        AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" },
        //        yValues: new[] { 85, 66, 98 }).Write();
        //    return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        //}

        public ActionResult VisualizeUrunResult()
        { 
            return Json(Urunlistesi(),JsonRequestBehavior.AllowGet); //google chartlara ulaşabilmemiz için gerekli
        }

        public List<UrunStok> Urunlistesi()
        {
             List<UrunStok> urunler=new List<UrunStok>();
             urunler= baglan.Uruns.Select(x=>new UrunStok
             {
                  urunad=x.UrunAd,
                  stok=x.Stok

             } ).ToList();

            return urunler;
        }
    }
}