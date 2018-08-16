using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloASP.Controllers
{
    public class HelloController : Controller
    {
        // Inputs
        // localhost:5000/
        
        [HttpGet("")]
        // Outputs/ Action
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("clickme")]
        public IActionResult Redirecting()
        {
            return RedirectToAction("SomewhereElse", new {other = "else"});
        }

        [HttpGet("somewhere/{other}")]
        public IActionResult SomewhereElse(string other)
        {
            if(other == "else")
                return RedirectToAction("Index");

            return Json("some json response");
        }
        
    }
}