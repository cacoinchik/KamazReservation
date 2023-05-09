using KamazReservation.Server.Data;
using KamazReservation.Shared.Models;
using KamazReservation.Shared.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamazReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly AppDbContext db;
        public ParkingController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetPs()
        {
            ParkingViewModels models = new ParkingViewModels();
            models.parkingSpaces = await db.ParkingSpaces.ToListAsync();
            models.bookings = await db.Bookings.ToListAsync();
            return Ok(models);
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(BookingViewModel model)
        {
            var booking = new Booking
            {
                PlaceNumber = model.PlaceNumber,
                Name = model.Name,
                LastName = model.LastName,
                CarBrand = model.CarBrand,
                CarModel = model.CarModel,
                CarNumber = model.CarNumber,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };

            booking.ParkingSpaceId = db.ParkingSpaces.FirstOrDefault(x => x.Number == booking.PlaceNumber).Id;

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
