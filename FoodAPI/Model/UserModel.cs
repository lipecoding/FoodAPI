﻿using FoodAPI.ENUM;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Model
{
    [Index(nameof(PhoneNumber), nameof(Email), Name = "Index_User")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public PremiumEnum Premium { get; set; }
        public string? Error { get; set; }
    }
}
