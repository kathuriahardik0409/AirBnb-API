using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirBNB.Models.Domain;

namespace AirBNB.Models.DTO
{
    public class UpdateHotelDto
    {
        public string City{get;set;}
        public long ContactInfoId{get;set;}
        public DateTime UpdatedAt{ get; set;} = DateTime.Now;
        public bool Active{get;set;}
    }
}