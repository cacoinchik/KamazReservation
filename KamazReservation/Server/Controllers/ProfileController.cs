using KamazReservation.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamazReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext db;

        public ProfileController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(await db.Users.FirstOrDefaultAsync(x=>x.UserName==User.Identity.Name));
            }
            else
            {
                return Ok();
            }
        }
    }
}
