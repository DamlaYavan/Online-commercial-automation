using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myfirstproject.Models.siniflar
{
    public class Urun
    {


        [Key]
        public int UrunId { get; set; }

        [Column(TypeName ="VarChar")]
        [StringLength(30)] 
        public  string UrunAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Marka {get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }  //ürün durumu kritik seviyo kontrolü

        [Column(TypeName = "VarChar")]
        [StringLength(250)] //limk uzun olabilir
        public string UrunGorsel { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }    //özelliklerin virtual olarak işaretlenmesi,
                                                          //tembel yükleme (lazy loading) özelliğinin
                                                          //etkinleşmesine neden olur. sadece özelliğe erişildiğinde
                                                          //kategori ye bağlanır. 

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}
