using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;
namespace WebApplication2.Controllers.CariPanel
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context baglan =new Context();
        public ActionResult Index()  //Profilim bölümü
        {
            var mail = (string)Session["CariMail"];
            var degerler = baglan.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.carimail = mail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id=baglan.Carilers.Where(x=>x.CariMail==mail.ToString()).
                Select(y=>y.CariId).FirstOrDefault();
            var degerler = baglan.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
    }
}