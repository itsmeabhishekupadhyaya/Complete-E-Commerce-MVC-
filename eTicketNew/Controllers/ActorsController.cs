﻿using eTicketNew.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Controllers
{
    public class ActorsController : Controller
    {

        private readonly AppDbContext _context;


        public ActorsController(AppDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Actors.ToList();
            return View();
        }
    }
}
