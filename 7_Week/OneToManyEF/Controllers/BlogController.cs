using System.Linq;
using LoginRegEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginRegEF.Controllers
{
    [Route("blogs")]
    public class BlogController : Controller
    {
        private MyContext dbContext;
        public BlogController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Blogs = dbContext.Blogs.Include(b => b.Author);
            ViewBag.LoggedInUser = HttpContext.Session.GetInt32("userid");

            // find user who wrote the newest blog
            // first find newest blog
            Blog newest = dbContext.Blogs
                .Include(b => b.Author)
                .FirstOrDefault(b => b.created_at == dbContext.Blogs.Max(b2 => b2.created_at));
            
            MyUser userWithNewest = (newest == null) 
                ? default(MyUser) 
                : dbContext.Users.Include(u => u.Blogs)
                    .FirstOrDefault(u => u.Blogs.Any(b => b.blog_id == newest.blog_id));


            return View();
        }
        
        [HttpGet("new")]
        public IActionResult New()
        {
            ViewBag.LoggedIn = HttpContext.Session.GetInt32("userid");
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Blog newBlog)
        {
            if(ModelState.IsValid)
            {
                // add a new blog to context
                dbContext.Blogs.Add(newBlog);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }
        [HttpGet("{blogId}/delete")]
        public IActionResult Delete(int blogId)
        {
            // query for blog with blogId
            var toDelete = dbContext.Blogs.FirstOrDefault(b => b.blog_id == blogId);
            // make sure this blogs.user_id is in session!
            if(toDelete == null || toDelete.user_id != HttpContext.Session.GetInt32("userid"))
            {
                return RedirectToAction("Index");
            }
            dbContext.Blogs.Remove(toDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}