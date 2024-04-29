using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfirstproject.Models.siniflar
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}
