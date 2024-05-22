using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myfirstproject.Models.siniflar
{
    public class Yapilacak
    {

        [Key]
        public int YapilacakId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public String Baslik { get; set; }
        public bool Durum { get; set; }  //tabloda tik atımı için 

    }
}