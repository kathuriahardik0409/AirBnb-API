using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNB.Models.DTO
{
    public class CreateHotelDto
    {
        [Required]
        public string City{get;set;}

        [Required]
        public long ContactInfoId{get;set;}

        [Required]
        public List<long> AmenityIds { get; set; }

        [Required]
        public bool Active{get;set;}

        [Required]
        public string? Address {get;set;}

        [Required]
        public string? Location{get;set;}

        [Required]
        public string? Email{get;set;}

        [Required]
        public string? PhoneNumber{get;set;}
    }
}