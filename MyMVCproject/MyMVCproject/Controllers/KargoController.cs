using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;
using PagedList;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class KargoController : Controller
    {
        // GET: Kargo

        Context baglan = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            var degerler = baglan.Kargos.Where(x => x.TakipKodu.Contains(p) || p == null).ToList().ToPagedList(sayfa, 4); //kaçıncı sayfadan başlayacak , Hersayfada kaç değer olucak 
            return View(degerler);  //geriye degerleri döndür
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            List<SelectListItem> cariler = (from x in baglan.Carilers.ToList()
                                            where x.Durum == true
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariAd + " " + x.CariSoyad
                                            }).ToList();
            ViewBag.cariler = cariler;
            List<SelectListItem> personeller = (from x in baglan.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelAd + " " + x.PersonelSoyad
                                                }).ToList();
            ViewBag.personeller = personeller;

            Random rnd= new Random(); //random sayı oluşturuyoruz
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4); //0-4 arası değerler alabilir
            k2 = rnd.Next(0, 4); //0-4 arası değerler alabilir
            k3 = rnd.Next(0, 4); //0-4 arası değerler alabilir
            int s1, s2, s3;
            s1= rnd.Next(100,1000); //3 karaktek gelicek
            s2= rnd.Next(10,99); //2 karakter
            s3= rnd.Next(10,99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(Kargo kargo)
        {
            baglan.Kargos.Add(kargo);
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        { 
            var degerler = baglan.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            ViewBag.kod = id;
            return View(degerler);
        }
    }
}