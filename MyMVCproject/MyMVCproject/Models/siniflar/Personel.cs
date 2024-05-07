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

        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }  //özelliklerin virtual olarak işaretlenmesi,
                                                          //tembel yükleme (lazy loading) özelliğinin
                                                          //etkinleşmesine neden olur. sadece özelliğe erişildiğinde
                                                          //departmana bağlanır. 
        public ICollection<SatisHareket> SatisHarekets { get; set; }


    }
}
