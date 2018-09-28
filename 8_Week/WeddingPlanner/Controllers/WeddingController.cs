using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    [Route("weddings")]
    public class WeddingController : Controller
    {
        private WeddingContext dbContext;
        public WeddingController(WeddingContext context)
        {
            dbContext = context;
        }
        // localhost:5000/weddings
        [HttpGet("")]
        public IActionResult Index()
        {
            // TODO: Check session for userid
            // if no key in session, redirect back to Home->Index
            var weddings = dbContext.Weddings
                .Include(w => w.Responses)
                .OrderByDescending(w => w.Date);
            ViewBag.UserId = HttpContext.Session.GetInt32("userid");
            return View(weddings);
        }
    }
}