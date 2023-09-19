using FoodAPI.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("ORDER")]
    [Index(nameof(UserId), Name = "Index_Order")]
    public class Order
    {
        [Column("o_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        [Column("o_user_id")]
        [Required]
        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Column("o_company_id")]
        [Required]
        public virtual Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Column("o_coupon_id")]
        [Required]
        public virtual Guid CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }

        [Column("o_deliverer_id")]
        [Required]
        public virtual Guid DelivererId { get; set; }
        public virtual Deliverer Deliverer { get; set; }

        [Column("o_adress_id")]
        [Required]
        public virtual Guid AdressId { get; set; }
        public virtual Adress Adress { get; set; }

        [Column("o_value")]
        [Required]
        public virtual double Value { get; set; }

        [Column("o_date")]
        [Required]
        public virtual DateTime Date { get; set; }

        public virtual List<Item> Itens { get; set; }

        [Column("o_status")]
        [Required]
        public OrderStatusEnum Status { get; set; }
        public virtual String? Error { get; set; }
    }
}
