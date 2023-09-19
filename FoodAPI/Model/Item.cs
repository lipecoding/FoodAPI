using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodAPI.Model
{
    [Table("ORDER_ITEM")]
    public class Item
    {
        [Column("oi_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        [Column("oi_menu_id")]
        [Required]
        public virtual Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        [Column("oi_amount")]
        [Required]
        [MaxLength(2)]
        public virtual int Amount { get; set; }

        [Column("oi_value")]
        [Required]
        public virtual double Value { get; set; }

        [Column("oi_order_id")]
        [Required]
        public virtual Guid OrderId { get; set; }
        [JsonIgnore]
        public virtual Order? Order { get; set; }
    }
}
