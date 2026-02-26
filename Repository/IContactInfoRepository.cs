using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirBNB.Models.Domain;
using AirBNB.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AirBNB.Repository
{
    public interface IContactInfoRepository
    {
        public Task<ContactInfo?> CreateContactInfo([FromBody] CreateContactInfoDto createContactInfoDto);
    }
}