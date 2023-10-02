using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("DELIVERER_STATUS")]
    public class DelivererStatus
    {
        public DelivererStatus()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("ds_id")]
        public virtual Guid Id { get; set; }
        [Column("ds_name")]
        [Required]
        public virtual String Name { get; set; }
    }
}
