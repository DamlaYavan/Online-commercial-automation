using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context baglan=new Context();
        public ActionResult Index()
        {
            Class1 cs=new Class1();
            //var degerler=baglan.Uruns.Where(x=>x.UrunId==3).ToList();
            cs.Deger1=baglan.Uruns.Where(x => x.UrunId == 1).ToList();
            cs.Deger2=baglan.Detays.Where(y => y.DetayId == 1).ToList();
            return View(cs);
        }
    }
}