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
        public int UrunId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Personel Personel { get; set; }

    }
}
