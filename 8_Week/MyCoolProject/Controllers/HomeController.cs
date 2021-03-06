using System.Linq;
using LoginRegEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginRegEF.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
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
                if(dbContext.users.Any(u => u.email == user.email))
                {
                    ModelState.AddModelError("email", "email exists!");
                    return View("Index");
                }
                // hash pw, stor on user
                PasswordHasher<MyUser> hasher = new PasswordHasher<MyUser>();
                user.password = hasher.HashPassword(user, user.password);

                dbContext.users.Add(user);
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
                MyUser fromDb = dbContext.users.FirstOrDefault(u => u.email == user.email);

                // check if user with supplied email exists
                if(fromDb == null)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");
                    return View("LoginView");
                }

                // check password
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, fromDb.password, user.password);
                if(result == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");
                    return View("LoginView");
                }

                // store user_id in session!
                HttpContext.Session.SetInt32("userid", fromDb.user_id);

                // verify password
                return RedirectToAction("Index", "Blog");
            }
            return View("LoginView");
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            int? userIdCheck = HttpContext.Session.GetInt32("userid");
            if(userIdCheck == null)
                return RedirectToAction("Index");

            MyUser loggedInUser = dbContext.users.FirstOrDefault(u => u.user_id == userIdCheck);

            ViewBag.User = loggedInUser;
            return View();
        }
        [HttpGet("{userId}")]
        public IActionResult Show(int userId)
        {
            var userToShow = dbContext.users
                .Include(u => u.Blogs)
                .FirstOrDefault(u => u.user_id == userId);
            
            return View(userToShow);
            
        }
    }
}