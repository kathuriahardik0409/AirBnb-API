using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using AirBNB.Data;
using AirBNB.Models.Domain;
using AirBNB.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext context;


        //Constructor
        public HotelRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Hotel?> ActivateHotel(long id)
        {
            var hotel = await context.Hotels.FirstOrDefaultAsync(x => x.Id == id);

            if (hotel != null)
            {
                hotel.Active = true;
                await context.SaveChangesAsync();
            }

            return hotel;
        }

        public async Task<Hotel?> CreateHotel(CreateHotelDto createHotelDto)
        {
            var amenities = await context.Amenities.Where(a => createHotelDto.AmenityIds.Contains(a.Id)).ToListAsync();

            if (amenities.Count != createHotelDto.AmenityIds.Count)
            {
                return null;
            }

            var hotel = new Hotel
            {
                City = createHotelDto.City,
                ContactInfoId = createHotelDto.ContactInfoId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Amenities = amenities,
                Active = createHotelDto.Active,
            };

            await context.Hotels.AddAsync(hotel);
            await context.SaveChangesAsync();

            return hotel;
        }

        public async Task<Hotel?> DeleteHotel(long id)
        {
            var hotelDomain = await context.Hotels.FindAsync(id);

            if (hotelDomain != null)
            {
                context.Hotels.Remove(hotelDomain);
                await context.SaveChangesAsync();
            }

            return hotelDomain;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await context.Hotels.Include(h => h.Amenities).Include(h => h.ContactInfo).ToListAsync();
        }

        public async Task<Hotel?> GetHotelById(long id)
        {
            var hotel = await context.Hotels.Include(h => h.Amenities).Include(h => h.ContactInfo).FirstOrDefaultAsync(x => x.Id == id);
            return hotel;
        }

        public async Task<Hotel?> UpdateHotel(long id, UpdateHotelDto updateHotelDto)
        {
            var hotelDomain = await context.Hotels.Include(h => h.Amenities).Include(h => h.ContactInfo).FirstOrDefaultAsync(x => x.Id == id);

            if (hotelDomain != null)
            {
                hotelDomain.City = updateHotelDto.City;
                hotelDomain.ContactInfoId = updateHotelDto.ContactInfoId;
                hotelDomain.UpdatedAt = updateHotelDto.UpdatedAt;
                hotelDomain.Active = updateHotelDto.Active;

                await context.SaveChangesAsync();
            }

            return hotelDomain;

        }
    }
}