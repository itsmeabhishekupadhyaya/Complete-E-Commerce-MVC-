﻿using eTicketNew.Data;
using eTicketNew.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Controllers
{
    public class MoviesController : Controller
    {
       
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            
            this._service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n=>n.Cinema);
            return View(data);
        }


        public async Task<IActionResult> Details(int id)
        {
            var moviedetails = await _service.GetMoviesByIdAsync(id);

            if (moviedetails == null)
            {
                return View("NotFound");
            }
            return View(moviedetails);
        }


        public async Task<IActionResult> Create()
        {
            var moviedata = await _service.GetMovieDropdownValue();

            ViewBag.Cinemas = new SelectList(moviedata.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(moviedata.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviedata.Actors, "Id", "FullName");

            return  View();
        }
    }
}
