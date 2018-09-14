using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoLeague.Models;
using DojoLeague.Factories;

namespace DojoLeague.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaFactory _ninjaFactory;
        private readonly DojoFactory _dojoFactory;
        public NinjaController(NinjaFactory nFactory, DojoFactory dFactory)
        {
            _ninjaFactory = nFactory;
            _dojoFactory = dFactory;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(new NinjaIndex()
            {
                Ninjas = _ninjaFactory.AllNinjas(),
                Dojos = _dojoFactory.AllDojos()
            });
        }
        [HttpPost("create")]
        public IActionResult Create(NinjaIndex model)
        {
            Ninja ninja = model.NewNinja;
            if(ModelState.IsValid)
            {
                _ninjaFactory.AddNinja(ninja);
                return RedirectToAction("Index");
            }
            return View("Index", new NinjaIndex(){
                Ninjas = _ninjaFactory.AllNinjas(),
                Dojos = _dojoFactory.AllDojos(),
                NewNinja = ninja
            });
        }
        [HttpGet("banish/{ninja_id}/{dojo_id}")]
        public IActionResult Banish(int ninja_id, int dojo_id)
        {
            _ninjaFactory.BanishNinja(ninja_id);
            return RedirectToAction("Show", "Dojo", new {id=dojo_id});
        }
        [HttpGet("recruit/{ninja_id}/{dojo_id}")]
        public IActionResult Recruit(int ninja_id, int dojo_id)
        {
            _ninjaFactory.RecruitNinja(ninja_id, dojo_id);
            return RedirectToAction("Show", "Dojo", new {id=dojo_id});
        }
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            return View(_ninjaFactory.GetNinjaById(id));
        }
    }
}
