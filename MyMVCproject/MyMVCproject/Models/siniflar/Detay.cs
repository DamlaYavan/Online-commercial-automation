using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myfirstproject.Models.siniflar
{
    public class Detay
    {
        [Key] 
        public int DetayId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(2500)]
        public string UrunBilgi { get; set; }



    }
}