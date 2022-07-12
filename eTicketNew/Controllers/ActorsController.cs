using eTicketNew.Data;
using eTicketNew.Data.Services;
using eTicketNew.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;


        public ActorsController(IActorsService service)
        {
            this._service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Actors/Create/1
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePrictureUrl,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
           await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorsdetails = await _service.GetByIdAsync(id);
            if(actorsdetails == null)
            {
                return View("NotFound");
            }
            return View(actorsdetails);
        }

        //  //Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorsdetails = await _service.GetByIdAsync(id);
            if (actorsdetails == null)
            {
                return View("NotFound");
            }
            return View(actorsdetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePrictureUrl,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }
        //Actors/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var actorsdetails = await _service.GetByIdAsync(id);
            if (actorsdetails == null)
            {
                return View("NotFound");
            }
            return View(actorsdetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if (actordetails == null)
            {
                return View("NotFound");
            }
           
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
