﻿using eTicketNew.Data;
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
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
             var allproducers = await _context.Producers.ToListAsync();
            return View();
        }
    }
}
