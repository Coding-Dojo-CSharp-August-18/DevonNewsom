using System;
using Microsoft.AspNetCore.Mvc;

namespace ViewModels
{
    public class HomeController : Controller
    {
        
        [HttpGet("")]
        public IActionResult Index()
        {

            // string[] fruit = new string[]
            // {
            //     "Apple", "Orange", "Banana"
            // };
            Random rand = new Random();
            Fruit[] fruits = Fruit.BuildSomeFruits();

            IndexViewModel model = new IndexViewModel()
            {
                MyFruits = fruits,
                Message = "Here are some fruits for ya!",
                TheFruit = fruits[rand.Next(fruits.Length)]
            };

            ViewBag.Message = "sdfds";

            return View(model);
        }

        [HttpGet("other/view")]
        public IActionResult Other()
        {
            string[] fruit = new string[]
            {
                "Cherries", "Mango", "Banana"
            };
            return View("Index", fruit);
        }

        [HttpPost("create")]
        public IActionResult Create(Fruit fruit)
        {
            return Json(fruit);
        }
    }
}