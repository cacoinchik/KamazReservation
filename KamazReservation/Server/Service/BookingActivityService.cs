using KamazReservation.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace KamazReservation.Server.Service
{
    public class BookingActivityService : BackgroundService
    {
        private readonly ILogger<BookingActivityService> logger;
        private readonly AppDbContext db;
        public BookingActivityService(ILogger<BookingActivityService> logger, IServiceProvider provider)
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
                    var bookings = db.Bookings.ToList();
                    foreach (var booking in bookings)
                    {
                        if (booking.EndTime < DateTime.Now || booking.Status!=null)
                        {
                            booking.IsActive = false;
                            booking.Status = "Завершено";
                        }
                        else
                        {
                            booking.IsActive = true;
                        }
                        db.Bookings.Update(booking);
                    }
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error");
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
