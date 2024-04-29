using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace myfirstproject.Models.siniflar
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public Decimal Tutar { get; set; }

       
    }
}
