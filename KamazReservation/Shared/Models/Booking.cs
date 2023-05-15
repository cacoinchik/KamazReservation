
namespace KamazReservation.Shared.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int ParkingSpaceId { get; set; }
        public int PlaceNumber { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
       
    }
}
