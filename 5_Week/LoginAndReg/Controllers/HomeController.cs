using System.Collections.Generic;
using System.Linq;
using LoginFun.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginFun.Controllers
{
    
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Register(RegistrationUser user)
        {
            // Check ModelState for Model-defined validations
            if(ModelState.IsValid)
            {
                // Verify unique email
                var result = DbConnector.Query($"SELECT * FROM users WHERE email = '{user.email}'");
                var numUsers = result.Count;
                if(numUsers > 0)
                {
                    ModelState.AddModelError("email", "Email already in use.");
                    return View("Registration");
                }

                // Hash PW if email is unique
                PasswordHasher<RegistrationUser> hasher = new PasswordHasher<RegistrationUser>();
                string hashedPw = hasher.HashPassword(user, user.password);

                // Store user info in DB
                string insert = 
                $@"
                    INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                    VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedPw}', NOW(), NOW())
                ";

                DbConnector.Execute(insert);

                // string update = $"UPDATE users SET first_name = 'Gary' WHERE user_id = {1};";

                return RedirectToAction("Login");
            }

            return View("Registration");
        }

        [HttpPost("login")]
        public IActionResult PerformLogin(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                // Validate existing email
                var result = DbConnector.Query($"SELECT * FROM users WHERE email = '{user.email}'");
                var numUsers = result.Count;
                if(numUsers == 0)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");
                    return View("Login");
                }

                // grab first item in list, access data at key of "password", cast to string
                string hashedPWInDB = (string)result[0]["password"];

                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                PasswordVerificationResult vResult = hasher.VerifyHashedPassword(user, hashedPWInDB, user.password);

                if(vResult == 0)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");
                    return View("Login");
                }


                // grab first item in list, access data at key of "user_id", cast to int
                int userIdInDB = (int)result[0]["user_id"];

                // store user's id in session
                HttpContext.Session.SetInt32("userid", userIdInDB);
                
                return RedirectToAction("Dashboard");
            }
            

            return View("Login");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            // Check to make sure user is logged in
            int? userMaybe = HttpContext.Session.GetInt32("userid");
            if(userMaybe == null)
            {
                return RedirectToAction("Login");
            }
            return Json("If you see this, you should be logged in");
        }       
    }
}