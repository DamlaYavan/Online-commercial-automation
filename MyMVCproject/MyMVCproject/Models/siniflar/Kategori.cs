using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace myfirstproject.Models.siniflar
{
    public class Kategori   //kategori tablosu
    {
        // bire çok ilişki olcak bir ürün bir kategoride olucak ama bir kategoride bir sürü ürün oalbilir
        [Key] //üzerinde bulunduğu özelliği pk  yapar
        public int KategoriId { get; set; }  //proporty oluşturma 

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; } //her kategoride birden fazla ürün olabilir

    }

}
