using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("ORDER_STATUS")]
    public class OrderStatus
    {
        public OrderStatus() 
        { 
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("os_id")]
        public virtual Guid Id { get; set; }
        [Required]
        [Column("os_name")]
        public virtual String Name { get; set; }
    }
}
