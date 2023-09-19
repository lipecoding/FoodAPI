using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("ADRESS")]
    public class Adress
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("a_id")]
        public virtual Guid Id { get; set; }

        [Column("a_cep")]
        [Required]
        [MaxLength(8)]
        public virtual String CEP { get; set; }

        [Column("a_street")]
        [Required]
        [MaxLength(255)]
        public virtual String Street { get; set; }

        [Column("a_adress_number")]
        [Required]
        [MaxLength(6)]
        public virtual int AdressNumber { get; set; }

        [Column("a_complement")]
        [Required]
        [MaxLength(255)]
        public virtual String? Complement { get; set; }

        [Column("a_receiver_name")]
        [Required]
        [MaxLength(255)]
        public virtual String ReceiverName { get; set; }

        [Column("a_user_id")]
        [Required]
        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
