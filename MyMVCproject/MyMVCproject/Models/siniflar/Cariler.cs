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
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz!")]
        public string CariAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        public string CariMail { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(15)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Sifre { get; set; }

        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}
