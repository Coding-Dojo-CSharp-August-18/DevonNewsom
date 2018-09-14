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
    public class DojoController : Controller
    {
        private readonly DojoFactory _dojoFactory;
        private readonly NinjaFactory _ninjaFactory;
        public DojoController(NinjaFactory nFactory, DojoFactory dFactory)
        {
            _dojoFactory = dFactory;
            _ninjaFactory = nFactory;
        }
        [HttpGet("dojo")]
        public IActionResult Index()
        {
            return View(new DojoIndex()
            {
                Dojos = _dojoFactory.AllDojos()
            });
        }
        [HttpGet("dojo/{id}")]
        public IActionResult Show(int id)
        {
            return View(new ShowDojo(){
                Dojo = _dojoFactory.GetDojoById(id),
                RogueNinjas = _ninjaFactory.RogueNinjas()
            });
        }
        [HttpPost("dojo/create")]
        public IActionResult Create(DojoIndex model)
        {
            Dojo dojo = model.NewDojo;
            if(ModelState.IsValid)
            {
                _dojoFactory.AddDojo(dojo);
                return RedirectToAction("Index");
            }
            return View("Index", new DojoIndex(){
                Dojos = _dojoFactory.AllDojos(),
                NewDojo = dojo
            });
        }
    }
}
