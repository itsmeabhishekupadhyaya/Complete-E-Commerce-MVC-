using eTicketNew.Data;
using eTicketNew.Data.Services;
using eTicketNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            this._service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result==null)
            {
                return View("NotFound");
            }
            return View(result);
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return View("NotFound");
            }
            return View(result);

        }
        
        [HttpPost]
        public async Task<IActionResult> Update(int id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }


            await _service.UpdateAsync(id, cinema);

            return RedirectToAction("Index");
        }

            public  IActionResult Create()
        {
            
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
           
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));


        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return View("NotFound");
            }
            return View(result);

        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
