using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfirstproject.Models.siniflar
{
    public class Admin
    {

        [Key]  //otomatik artan olarak gelcek altındaki özellik
        public int AdminId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Sifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)] 
        public string Yetki { get; set; } //adminin hangi sayfaaları görmeye yetkisi var
    }
}
