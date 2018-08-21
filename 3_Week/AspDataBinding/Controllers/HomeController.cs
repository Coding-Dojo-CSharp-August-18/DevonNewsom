using Microsoft.AspNetCore.Mvc;

namespace AspDataBinding
{
    public class HomeController : Controller
    {
        // localhost:5000/
        [HttpGet("")]
        public ViewResult Index()
        {
            // Views/Home/Index.cshtml
            // Views/Shared/Index.cshtml
            string[] myItems = new string[]
            {
                "Apple", "Backpack", "Pizza", "One"
            };

            ViewBag.Items = myItems;

            return View();
        }

        // localhost:5000/other
        [HttpGet("other")]
        public ViewResult Other()
        {
           
            string[] myOtherItems = new string[]
            {
                "Orange", "Ladder", "Random", "HAHA"
            };

            ViewBag.Items = myOtherItems;
            return View("Index");
        }

        [HttpPost("submit")]
        public IActionResult ProccessForm(string Fruit, string IsCool, string MaritalStatus, string Item, int NumThings)
        {
            object mySubmission = new
            {
                tehFruit = Fruit, 
                isThisCool =  (IsCool == "on"),
                status = MaritalStatus, 
                anItem = Item, 
                numberOfThings = NumThings
            };
            return Json(mySubmission);
        }
    }
}