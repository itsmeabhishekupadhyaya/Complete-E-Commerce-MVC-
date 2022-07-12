using eTicketNew.Data;
using eTicketNew.Data.Services;
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
    }
}
