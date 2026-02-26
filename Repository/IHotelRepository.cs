using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirBNB.Models.Domain;
using AirBNB.Models.DTO;

namespace AirBNB.Repository
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();

        Task<Hotel?> GetHotelById(long id);

        Task<Hotel?> DeleteHotel(long id);

        Task<Hotel?> ActivateHotel(long id);

        Task<Hotel?> UpdateHotel(long id , UpdateHotelDto updateHotelDto);

        Task<Hotel?> CreateHotel(CreateHotelDto createHotelDto);
        
        
    }
}