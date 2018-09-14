using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloEF.Models;
using Microsoft.AspNetCore.Hosting;

namespace HelloEF.Controllers
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
            ViewBag.Friends = dbContext.Friends;

            return View();
        }
        // Show
        [HttpGet("{friendId}")]
        public IActionResult Show(int friendId)
        {
            // Get One Friend by id
            Friend myFriend = dbContext.Friends
                .SingleOrDefault(f => f.FriendId == friendId);


            return View(myFriend);
        }
        // Create
        [HttpPost("create")]
        public IActionResult Create(Friend friend)
        {
            if(ModelState.IsValid)
            {
                // check for unique Name
                if(dbContext.Friends.Any(f => f.Name == friend.Name))
                {
                    ModelState.AddModelError("Name", "Name exists already!");
                    return View("Index");
                }

                // Create a friend
                dbContext.Friends.Add(friend);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            
            return View("Index");
        }
        // Update
        [HttpPost("update/{friendId}")]    
        public IActionResult Update(Friend friend, int friendId)
        {
            if(ModelState.IsValid)
            {
                // Update a friend
                
                // query for friend with id
                Friend toUpdate = dbContext.Friends.SingleOrDefault(f => f.FriendId == friendId);

                // update the things we want
                toUpdate.Name = friend.Name;
                toUpdate.UpdatedAt = DateTime.Now;

                dbContext.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return View("Show");
        }
        // Delete
        [HttpGet("delete/{friendId}")]
        public IActionResult Delete(int friendId)
        {
            // delete a friend
                // query for friend with id
            Friend toDelete = dbContext.Friends.SingleOrDefault(f => f.FriendId == friendId);
            dbContext.Friends.Remove(toDelete);

            dbContext.SaveChanges();
          
            return RedirectToAction("Index");
        }
    }
}
