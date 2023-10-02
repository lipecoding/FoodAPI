using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("DELIVERER_VEHICLE")]
    public class DelivererVehicle
    {
        public DelivererVehicle() 
        { 
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("dv_id")]
        public virtual Guid Id { get; set; }
        [Column("dv_name")]
        [Required]
        public virtual String Name { get; set; }
    }
}
