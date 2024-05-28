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
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context baglan = new Context(); //tablolarımız tutuluyor 
        public ActionResult Index(string p ,int sayfa=1)
        {
            var degerler = baglan.Kategoris.Where(x=>x.KategoriAd.Contains(p) || p==null) .ToList(). ToPagedList(sayfa, 4); //kaçıncı sayfadan başlayacak , Hersayfada kaç değer olucak 
            return View(degerler);  //geriye degerleri döndür
        }

        [HttpGet]
        public ActionResult KategoriEkle()  //bu form yüklendiğinde sadece boş bi buton get metodu
        {
            return View();
        }


        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)   //bu butona tıklandığında ekleme yapması için  post metodu
        {
            baglan.Kategoris.Add(k); //k view tarafında gönderilcek parametreleri tutup kategoriye ekleyecek
            baglan.SaveChanges();   //değişiklikleri tabloda kaydet (entity framework yapısı)
            return RedirectToAction("Index");   //ekleme işlemini görebileceği tekrar ındex  sayfaya yönlendirildi.
        }


        public ActionResult KategoriSil(int id)
        {
            var k = baglan.Kategoris.Find(id);  //gelen id bul 
            baglan.Kategoris.Remove(k);   //bulunan kategori sil
            baglan.SaveChanges();
            return RedirectToAction("Index"); //geri aynı sayfaya döndür
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = baglan.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var k = baglan.Kategoris.Find(kategori.KategoriId);
            k.KategoriAd = kategori.KategoriAd;
            baglan.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}