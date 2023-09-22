using FoodAPI.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("DELIVERER")]
    [Index(nameof(Email), nameof(PhoneNumber), Name = "Index_Deliverer")]
    public class Deliverer
    {
        public Deliverer()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Column("d_id")]
        public virtual Guid? Id { get; set; }

        [Column("d_name")]
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }

        [Column("d_email")]
        [Required]
        [MaxLength(255)]
        public virtual String Email { get; set; }

        [Column("d_password")]
        [Required]
        [MaxLength(60)]
        public virtual String Password { get; set; }

        [Column("d_cnh")]
        [Required]
        [MaxLength(10)]
        public virtual String CNH { get; set; }

        [Column("d_cpf")]
        [Required]
        [MaxLength(11)]
        public virtual String CPF { get; set; }

        [Column("d_birthday")]
        [Required]
        public virtual DateTime Birthday { get; set; }

        [Column("d_phonenumber")]
        [Required]
        [MaxLength(11)]
        public virtual String PhoneNumber { get; set; }

        [Column("d_cep")]
        [Required]
        [MaxLength(8)]
        public virtual String CEP { get; set; }

        [Column("d_street")]
        [Required]
        [MaxLength(255)]
        public virtual String Street { get; set; }

        [Column("d_addressnumber")]
        [Required]
        public virtual int AddressNumber { get; set; }

        [Column("d_complement")]
        [Required]
        [MaxLength(255)]
        public virtual String? Complement { get; set; }

        [Column("d_status")]
        [Required]
        public virtual DelivererEnum Status { get; set; }

        [Column("d_vehicle")]
        [Required]
        public virtual DelivererVehicleEnum DelivererVehicle { get; set; }
        public virtual String? Error { get; set; }

    }
}
