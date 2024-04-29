using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace myfirstproject.Models.siniflar
{
    public class Personel
    {
        [Key] 
        public int PersonelId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public String PersonelAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public String PersonelSoyad { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)] //uzun link olabilir 
        public String PersonelGorsel { get; set; }  //görselin sadece yolunu tutucaz o yüzden string 

        public Departman Departman { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }


    }
}
