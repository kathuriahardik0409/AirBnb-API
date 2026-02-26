using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirBNB.Models.Domain;

namespace AirBNB.Models.DTO
{
    public class HotelDto
    {
        public long Id { get; set; }
        public string City { get; set; }
        public IEnumerable<string> Amenities { get; set; }

        public ContactInfo ContactInfo { get; set; }
    }
}