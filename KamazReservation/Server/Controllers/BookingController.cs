using KamazReservation.Server.Data;
using KamazReservation.Shared.Models;
using KamazReservation.Shared.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamazReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext db;
        public BookingController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            return Ok(await db.Bookings.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(BookingViewModel model)
        {
            var booking = new Booking
            {
                PlaceNumber = model.PlaceNumber,
                UserName = model.UserName,
                Name = model.Name,
                LastName = model.LastName,
                CarBrand = model.CarBrand,
                CarModel = model.CarModel,
                CarNumber = model.CarNumber,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };

            TimeSpan duration = model.EndTime - model.StartTime;

            if (model.StartTime < DateTime.Now
                || model.EndTime <= model.StartTime
                || duration.TotalHours < 1
                || duration.TotalHours > 8)
            {
                return BadRequest();
            }

            booking.ParkingSpaceId = db.ParkingSpaces.FirstOrDefault(x => x.Number == booking.PlaceNumber).Id;

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> CancelBooking(Booking booking)
        {
            db.Entry(booking).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return NoContent();
        }

    }
}
