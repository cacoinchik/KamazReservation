using KamazReservation.Shared.Models;

namespace KamazReservation.Shared
{
    public class ParkingInfo : ParkingSpace
    {
        public bool IsFree { get; set; }
        public bool IsWithBooking { get; set; }
        public bool IsOccupied { get; set; }

        public static List<ParkingInfo> DrawParking(IEnumerable<ParkingSpace> parkingSpaces, IEnumerable<Booking> bookings, DateTime? selectDay)
        {
            List<ParkingInfo> parking = new List<ParkingInfo>();
            foreach (var parkingSpace in parkingSpaces)
            {
                var pd = new ParkingInfo
                {
                    Id = parkingSpace.Id,
                    Number = parkingSpace.Number,
                    Row=parkingSpace.Row,
                    IsFree = true
                };

                parking.Add(pd);
            }
            foreach (var booking in bookings)
            {
                if (booking.StartTime.Date == selectDay)
                {
                    var p = parking.FirstOrDefault(x => x.Id == booking.ParkingSpaceId);
                    if (p != null)
                    {
                        p.IsWithBooking = true;
                        p.IsFree = false;
                    }
                }
            }
            return parking;
        }
    }
}
