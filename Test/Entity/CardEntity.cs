using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Test.Entity
{
    [Table("Product")]
    public class CardEntity : Entity
    {
        [StringLength(50)]
        public string CardName { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "Money")]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        public int Discount { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
