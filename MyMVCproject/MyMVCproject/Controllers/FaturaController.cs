using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura

        Context baglan = new Context();
        public ActionResult Index()
        {
            var degerler = baglan.Faturalars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar fatura)
        {
            baglan.Faturalars.Add(fatura);
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult FaturaGetir(int id)
        {
            var fatura=baglan.Faturalars.Find(id);
            return View("Faturagetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar fatura)
        {
            var newFatura = baglan.Faturalars.Find(fatura.FaturaId);
            newFatura.FaturaSeriNo= fatura.FaturaSeriNo;
            newFatura.FaturaSıraNo = fatura.FaturaSıraNo;
            newFatura.Saat= fatura.Saat;
            newFatura.Tarih= fatura.Tarih;
            newFatura.TeslimAlan= fatura.TeslimAlan;
            newFatura.TeslimEden= fatura.TeslimEden;
            newFatura.VergiDairesi= fatura.VergiDairesi;
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id) 
        {
            var fatura = baglan.Faturalars.Find(id);
            ViewBag.FtrSıraNo=fatura.FaturaSıraNo.ToString();
            ViewBag.FtrId=fatura.FaturaId;
            var degerler = baglan.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem(int id)
        {
            ViewBag.FtrId = id;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturakalem)
        {
            baglan.FaturaKalems.Add(faturakalem);
            baglan.SaveChanges();
            return RedirectToAction("FaturaDetay",new { id = faturakalem.FaturaId });
        }
    }
}