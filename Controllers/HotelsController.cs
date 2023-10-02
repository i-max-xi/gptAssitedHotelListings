using gptAssitedAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gptAssistedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly List<Hotel> _hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Name = "Hotel A", Address = "123 Main St", PricePerNight = 100.0 },
            new Hotel { Id = 2, Name = "Hotel B", Address = "456 Elm St", PricePerNight = 150.0 },
            new Hotel { Id = 3, Name = "Hotel C", Address = "789 Oak St", PricePerNight = 120.0 }
        };

        // GET: api/Hotels
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return _hotels;
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotel != null)
            {
                return hotel;
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Hotels
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel hotel)
        {
            hotel.Id = _hotels.Count + 1;
            _hotels.Add(hotel);
            return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hotel updatedHotel)
        {
            var existingHotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (existingHotel != null)
            {
                existingHotel.Name = updatedHotel.Name;
                existingHotel.Address = updatedHotel.Address;
                existingHotel.PricePerNight = updatedHotel.PricePerNight;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotelToDelete = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotelToDelete != null)
            {
                _hotels.Remove(hotelToDelete);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
