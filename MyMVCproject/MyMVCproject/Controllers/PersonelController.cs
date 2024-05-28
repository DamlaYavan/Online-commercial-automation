using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;
namespace WebApplication2.Controllers
{
    [Authorize]
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
            if(Request.Files.Count>0) // isteklerin arasında bi dosya varsa 
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName); //dosyanın adını alıyoruz
                string uzanti = Path.GetExtension(Request.Files[0].FileName);  //uzantıyı alıyoruz
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel="/Image/"+dosyaadi+uzanti; //personelin görselini bu url yaptık.
            }
            baglan.Personels.Add(personel);
            baglan.SaveChanges();
            return RedirectToAction("PersonelList");
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

            if (personel.PersonelGorsel!= null) // isteklerin arasında bi dosya varsa 
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName); //dosyanın adını alıyoruz
                string uzanti = Path.GetExtension(Request.Files[0].FileName);  //uzantıyı alıyoruz
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/Image/" + dosyaadi + uzanti; //personelin görselini bu url yaptık.
                newpersonel.PersonelGorsel = personel.PersonelGorsel;

            }
            newpersonel.PersonelAd = personel.PersonelAd;
            newpersonel.PersonelSoyad = personel.PersonelSoyad;
            newpersonel.PersonelMail = personel.PersonelMail;
            newpersonel.Departmanid = personel.Departmanid;
            baglan.SaveChanges();
            return RedirectToAction("PersonelList");
        }


        public ActionResult PersonelList()
        {
            var degerler = baglan.Personels.ToList();
            return View(degerler);
        }

        public ActionResult PersonelSil(int id)
        {
            var newcari = baglan.Personels.Find(id);
            baglan.Personels.Remove(newcari);
            baglan.SaveChanges();
            return RedirectToAction("PersonelList");

        }
    }
}