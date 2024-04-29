using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfirstproject.Models.siniflar
{
    public class FaturaKalem
    {

        [Key]
        public int FaturaKalemId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public Faturalar Faturalar { get; set; }
    }
}
