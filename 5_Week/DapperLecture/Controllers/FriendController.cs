using System;
using System.Collections.Generic;
using DapperLecture.Factories;
using DapperLecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperLecture.Controllers
{
    public class FriendController : Controller
    {
        private FriendFactory friendFactory;

        public FriendController()
        {
            friendFactory = new FriendFactory();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(friendFactory.GetAll());
        }
        
        [HttpGet("{friendId}")]
        public IActionResult Show(int friendId)
        {
            Friend friendModel = friendFactory.GetFriendById(friendId);

            return View(friendModel);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Friend friend)
        {
            if(ModelState.IsValid)
            {
                bool nameExists = friendFactory.NameExists(friend.Name);
                if(!nameExists)
                {
                    friendFactory.Create(friend);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Name", "Name exists, choose new name!");
                return View("New");

            }
            return View("New");
        }

        
    }
}