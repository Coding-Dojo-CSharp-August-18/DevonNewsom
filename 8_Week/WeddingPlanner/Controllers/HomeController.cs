using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext dbContext;
        public HomeController(WeddingContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("login")]
        public IActionResult LoginView()
        {
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(MyUser user)
        {
            if(ModelState.IsValid)
            {
                // check existing email
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("email", "email exists!");
                    return View("Index");
                }
                // hash pw, stor on user
                PasswordHasher<MyUser> hasher = new PasswordHasher<MyUser>();
                user.Password = hasher.HashPassword(user, user.Password);

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("LoginView");
            }
            // do other stuff
            return View("Index");
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                //do stuff
                // verify email exists in db
                MyUser fromDb = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

                // check if user with supplied email exists
                if(fromDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("LoginView");
                }

                // check password
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, fromDb.Password, user.Password);
                if(result == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");
                    return View("LoginView");
                }

                // store user_id in session!
                HttpContext.Session.SetInt32("userid", fromDb.UserId);

                // verify password
                return RedirectToAction("Index", "Wedding");
            }
            return View("LoginView");
        }
       
    }
}