﻿using FoodAPI.Enum;

namespace FoodAPI.Model
{
    public class DelivererModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CNH { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public int AdressNumber { get; set; }
        public string? Complement { get; set; }
        public DelivererEnum Status { get; set; }
        public string? Error { get; set; }
    }
}