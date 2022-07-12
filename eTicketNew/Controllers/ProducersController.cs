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
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            this._service = service;
        }
        public async Task<IActionResult> Index()
        {
             var allproducers = await _service.GetAllAsync();
            return View(allproducers);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return View("NotFound");
            }

            return View(result);
        }


        public  IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePrictureUrl,Bio") ]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);

            return RedirectToAction("Index");
        }



        public async Task<IActionResult>Edit(int id)
        {
            var producerdetails = await _service.GetByIdAsync(id);

            if (producerdetails == null)
            {
                return View("NotFound");
            }
            return View(producerdetails);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

           
            await _service.UpdateAsync(id,producer);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerdetails = await _service.GetByIdAsync(id);

            if (producerdetails == null)
            {
                return View("NotFound");
            }
            return View(producerdetails);

        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Confirmed(int id)
        {

            var producerdetails = await _service.GetByIdAsync(id);

            if (producerdetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction("Index");
        }


    }
}
