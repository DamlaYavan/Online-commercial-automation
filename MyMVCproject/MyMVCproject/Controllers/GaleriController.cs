using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    public class GaleriController : Controller
    {

        // GET: Galeri
        Context baglan=new Context();
        public ActionResult Index()
        {
            var degerler=baglan.Uruns.ToList();
            return View(degerler);
        }
    }
}