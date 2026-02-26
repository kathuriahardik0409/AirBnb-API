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
    }
}