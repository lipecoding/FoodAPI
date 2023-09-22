using FoodAPI.ENUM;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("USER")]
    [Index(nameof(PhoneNumber), nameof(Email), Name = "Index_User")]
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        [Column("u_id")]
        [Key]
        public virtual Guid? Id { get; set; }

        [Column("u_name")]
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }

        [Column("u_email")]
        [Required]
        [MaxLength(255)]
        public virtual String Email { get; set; }

        [Column("u_password")]
        [Required]
        [MaxLength(60)]
        public virtual String Password { get; set; }

        [Column("u_phonenumber")]
        [Required]
        [MaxLength(11)]
        public virtual String PhoneNumber { get; set; }

        [Column("u_birthday")]
        [Required]
        public virtual DateTime Birthday { get; set; }

        [Column("u_cpf")]
        [Required]
        [MaxLength(11)]
        public virtual String CPF { get; set; }

        [Column("u_premium")]
        [Required]
        public virtual PremiumEnum Premium { get; set; }
        public virtual String? Error { get; set; }
    }
}
