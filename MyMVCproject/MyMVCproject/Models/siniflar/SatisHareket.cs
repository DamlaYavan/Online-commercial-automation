using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myfirstproject.Models.siniflar
{
    public class SatisHareket
    {

        [Key]
        public int SatisId { get; set; }
        //ürün
        //cari-müsteri
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; } //kasaya aktarılacak

        public Urun Urun { get; set; }
        public Cariler Cariler { get; set; }
        public Personel Personel { get; set; }

    }
}
