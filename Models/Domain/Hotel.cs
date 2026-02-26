using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNB.Models.Domain
{
    public class Hotel
    {
        [Key]
        public long Id{get;set;}

        public string City{get;set;}
        
        public long ContactInfoId{get;set;}
        public DateTime CreatedAt{ get; set;}
        public DateTime UpdatedAt{ get; set;}

        public bool Active{get;set;}
        public List<Amenities> Amenities{get;set;}

        //Navigation Property
        public ContactInfo ContactInfo{get;set;}
    }
}