using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace myfirstproject.Models.siniflar
{
    public class Departman
    {

        [Key]
        public int DepartmanId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}
