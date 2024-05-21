using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myfirstproject.Models.siniflar
{
    public class Class1
    {
        public IEnumerable<Urun> Deger1 { get; set; }  //urunden gelen degerleri koleksiyon olarak tutuyo olacak
        public IEnumerable<Detay> Deger2 { get; set; }  //detaydan gelen değerleri koleksiyon oalrak tutuyo olucak

    }
}