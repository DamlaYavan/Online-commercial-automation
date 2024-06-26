﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myfirstproject.Models.siniflar
{
    public class Mesaj
    {
        [Key]
        public int MesajId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string Gönderen { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Icerik { get; set; }

        public bool Durum { get; set; }

        public DateTime Tarih { get; set; }


    }
}