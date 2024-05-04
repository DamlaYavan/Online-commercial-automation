using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    public class DepartmanController : Controller
    {


        // GET: Departman
        Context baglan=new Context();
        public ActionResult Index()
        {
            var degerler = baglan.Departmans.ToList(); //departmanları getir
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
            baglan.Departmans.Add(departman);
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}