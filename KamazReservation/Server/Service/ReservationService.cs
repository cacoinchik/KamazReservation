using KamazReservation.Server.Data;

namespace KamazReservation.Server.Service
{
    public class ReservationService : BackgroundService
    {
        private readonly ILogger<ReservationService> logger;
        private readonly AppDbContext db;

        public ReservationService(ILogger<ReservationService> logger, IServiceProvider provider)
        {
            this.logger = logger;
            db = provider.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var dateNow = DateTime.Now;

                    var bookings = db.Bookings.ToList();

                    foreach (var booking in bookings)
                    {
                        if (booking.StartTime < dateNow && booking.EndTime > dateNow)
                        {
                            db.ParkingSpaces.FirstOrDefault(x => x.Id == booking.ParkingSpaceId).IsOccupied = true;
                        }
                        else
                        {
                            db.ParkingSpaces.FirstOrDefault(x => x.Id == booking.ParkingSpaceId).IsOccupied = false;
                        }
                    }

                    await db.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error");
                }

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }
    }
}

