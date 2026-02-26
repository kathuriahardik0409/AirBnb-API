using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNB.Models.Domain
{
    public class ContactInfo
    {
        [Key]
        public long Id{get;set;}

        public string Address{get;set;}

        public String? Location{ get; set;}

        public String? Email{ get; set;}

        public String? Phone{ get; set;}
    }
}