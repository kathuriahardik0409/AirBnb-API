using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirBNB.Data;
using AirBNB.Models.Domain;
using AirBNB.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AirBNB.Repository
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly AppDbContext context;

        public ContactInfoRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ContactInfo?> CreateContactInfo([FromBody] CreateContactInfoDto createContactInfoDto)
        {
            var contactInfo = new ContactInfo
            {
                Address = createContactInfoDto.Address,
                Location = createContactInfoDto.Location,
                Email = createContactInfoDto.Email,
                Phone = createContactInfoDto.Phone
            };

            await context.AddAsync(contactInfo);
            await context.SaveChangesAsync();

            return contactInfo;
        }
    }
}