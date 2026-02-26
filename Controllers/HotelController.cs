using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using AirBNB.Data;
using AirBNB.Models.Domain;
using AirBNB.Models.DTO;
using AirBNB.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AirBNB.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        //API to get all Hotels
        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var allHotelsDomain = await hotelRepository.GetAllHotels();

            List<HotelDto> hotelDtos = new List<HotelDto>();

            foreach (var hotel in allHotelsDomain)
            {
                hotelDtos.Add(new HotelDto
                {
                    Id = hotel.Id,
                    City = hotel.City,
                    Amenities = hotel.Amenities.Select(a => a.Name).ToList(),
                    ContactInfo = hotel.ContactInfo
                });
            }

            return Ok(hotelDtos);
        }

        //Get Hotel By Id
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetHotelById(long id)
        {
            var hotel = await hotelRepository.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            var hotelDto = new HotelDto
            {
                Id = hotel.Id,
                City = hotel.City,
                Amenities = hotel.Amenities.Select(a => a.Name).ToList(),
                ContactInfo = hotel.ContactInfo
            };

            return Ok(hotelDto);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteHotel(long id)
        {
            var hotel = await hotelRepository.DeleteHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPatch]
        [Route("{id:long}")]
        public async Task<IActionResult> ActivateHotel(long id)
        {
            var hotel = await hotelRepository.ActivateHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateHotel([FromRoute] long id, [FromBody] UpdateHotelDto updateHotelDto)
        {
            var hotelDomain = await hotelRepository.UpdateHotel(id , updateHotelDto);

            if (hotelDomain == null)
            {
                return NotFound();
            }

            
            var hotelDto = new HotelDto
            {
                Id = hotelDomain.Id,
                City = hotelDomain.City,
                Amenities = hotelDomain.Amenities.Select(a => a.Name).ToList(),
                ContactInfo = hotelDomain.ContactInfo
            };

            return Ok(hotelDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDto createHotelDto)
        {
            var hotelDomain = await hotelRepository.CreateHotel(createHotelDto);

            if (hotelDomain == null)
            {
                return BadRequest("Failed to Create Hotel");
            }
            
            var hotelDto = new HotelDto
            {
                Id = hotelDomain.Id,
                City = hotelDomain.City,
                Amenities = hotelDomain.Amenities.Select(a => a.Name).ToList(),
            };

            return Ok(hotelDto);
        }

    }
}