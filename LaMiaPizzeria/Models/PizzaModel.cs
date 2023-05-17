using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeria.Models
{
    public class PizzaModel
    {
        public int id { get; set; }
        
        [MaxLength(40)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        [Column(TypeName = "text")]
        public string Description { get; set; }
        
        [MaxLength(300)]
        public string imgSource { get; set; }
        public float Price { get; set; }


    }
}
