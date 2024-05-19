using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfirstproject.Models.siniflar
{
    public class Faturalar
    {
        [Key]  //id kendi kendine arttıracak
        public int FaturaId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string  FaturaSeriNo { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string  FaturaSıraNo { get; set; }
        public DateTime  Tarih { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(60)]
        public string VergiDairesi   { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat   { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimEden   { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimAlan   { get; set; }

        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; } //bir gfaturanın birden fazla kalemi oalbilir

    }
}
