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
            var model = dbContext.Blogs.Include(b => b.Author).Include(a => a.Votes);
            ViewBag.LoggedInUser = HttpContext.Session.GetInt32("userid");

            return View(model);
        }

        [HttpGet("{blogId}")]
        public IActionResult Show(int blogId)
        {
            var model = dbContext.Blogs
                .Include(b => b.Votes)
                    .ThenInclude(v => v.Voter)
                .FirstOrDefault(b => b.blog_id == blogId);

            return View(model);
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

        [HttpGet("vote/{blogId}/{isUpvote}")]
        public IActionResult Vote(int blogId, int isUpvote)
        {
            bool upvote = (isUpvote == 0) ? false : true;
            Vote newVote = new Vote()
            {
                blog_id = blogId,
                user_id = (int)HttpContext.Session.GetInt32("userid"),
                is_upvote = upvote
            };
            dbContext.Votes.Add(newVote);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}