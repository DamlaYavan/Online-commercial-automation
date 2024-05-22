using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;
namespace WebApplication2.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context baglan = new Context();
        //public ActionResult Index()
        //{
        //    var degerler = baglan.Personels.ToList();
        //    return View(degerler);
        //}

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in baglan.Departmans.ToList()   //Linq sorgusu ile html dropdown kutusu listesi  için 
                                           where x.Durum==true  //departman durumu true olanlar 
                                           select new SelectListItem
                                           {  //x her bir departman kaydını temsil eder.
                                               Text = x.DepartmanAd, //gözükecek ad
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;  //ViewBag controlller tarafında view tarafına veri değer taşımak için kullanılır. deger1 in değeri dgr1 adlı bir değişken oluşturuyoryz onun içine atandı .     
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            baglan.Personels.Add(personel);
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelGetir(int id) //Güncelleme işlemi için seçilen personeli getiricek
        {
            List<SelectListItem> deger1 = (from x in baglan.Departmans.ToList()   //Linq sorgusu ile html dropdown kutusu listesi  için 
                                           where x.Durum == true  //departman durumu true olanlar 
                                           select new SelectListItem
                                           {  //x her bir departman kaydını temsil eder.
                                               Text = x.DepartmanAd, //gözükecek ad
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;  //ViewBag controlller tarafında view tarafına veri değer taşımak için kullanılır. deger1 in değeri dgr1 adlı bir değişken oluşturuyoryz onun içine atandı .     
            var personel = baglan.Personels.Find(id);
            return View("PersonelGetir", personel);

        }

        public ActionResult PersonelGuncelle(Personel personel) //CariGetir Viewdan gelen departman
        {
            var newpersonel = baglan.Personels.Find(personel.PersonelId);
            newpersonel.PersonelAd = personel.PersonelAd;
            newpersonel.PersonelSoyad = personel.PersonelSoyad;
            newpersonel.PersonelGorsel = personel.PersonelGorsel;
            newpersonel.Departmanid = personel.Departmanid;
            baglan.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelList()
        {
            var degerler = baglan.Personels.ToList();
            return View(degerler);
        }
    }
}