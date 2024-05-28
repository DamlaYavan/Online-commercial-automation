using myfirstproject.Models.groupsiniflar;
using myfirstproject.Models.siniflar;
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
    public class MesajController : Controller
    {
        // GET: Mesaj

        Context baglan=new Context();
       
        public ActionResult GelenMesajlar()
        {
            var mesajlar = baglan.Mesajs.Where(x => x.Alici == "Magaza@gmail.com" && x.Durum == true).OrderByDescending(x => x.MesajId).ToList();
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d2 = gidensayisi;
            var silinen = baglan.Mesajs.Count(x =>x.Durum == false).ToString();
            ViewBag.d3 = silinen;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mesajlar = baglan.Mesajs.Where(x => x.Gönderen == "Magaza@gmail.com" && x.Durum == true).OrderByDescending(z => z.MesajId).ToList();
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d2 = gidensayisi;
            var silinen = baglan.Mesajs.Count(x => x.Durum == false).ToString();
            ViewBag.d3 = silinen;
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d2 = gidensayisi;
            var silinen = baglan.Mesajs.Count(x => x.Durum == false).ToString();
            ViewBag.d3 = silinen;
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesaj m)
        {
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gönderen = "Magaza@gmail.com";
            m.Durum = true;
            baglan.Mesajs.Add(m);
            baglan.SaveChanges();
            return View();
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = baglan.Mesajs.Where(x => x.MesajId == id).ToList();
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d2 = gidensayisi;
            var silinen = baglan.Mesajs.Count(x => x.Durum == false).ToString();
            ViewBag.d3 = silinen;
            return View(degerler);
        }
        public ActionResult CopKutusu()
        {
            var gnd = baglan.Mesajs.Where(x => x.Gönderen == "Magaza@gmail.com" && x.Durum == false).OrderByDescending(z => z.MesajId).ToList();
            var aln = baglan.Mesajs.Where(x => x.Alici == "Magaza@gmail.com" && x.Durum == false).OrderByDescending(z => z.MesajId).ToList();
            var gelensayisi = baglan.Mesajs.Count(x => x.Alici == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = baglan.Mesajs.Count(x => x.Gönderen == "Magaza@gmail.com" && x.Durum == true).ToString();
            ViewBag.d2 = gidensayisi;
            var silinen = baglan.Mesajs.Count(x => x.Durum == false).ToString();
            ViewBag.d3 = silinen;
            var viewModel = new Copkutusu
            {
                GonderilenMesajlar = gnd,
                AlinanMesajlar = aln
            };
            return View(viewModel);

        }

        public ActionResult MesajSil(int id)
        {
            var msj = baglan.Mesajs.Where(x => x.MesajId == id).FirstOrDefault();
            msj.Durum = false;
            baglan.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }

    }
}