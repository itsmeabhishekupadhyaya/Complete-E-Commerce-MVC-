using eTicketNew.Data;
using eTicketNew.Data.Services;
using eTicketNew.Models;
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

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newMovieVM)
        {

            if (!ModelState.IsValid)
            {
                var moviedata = await _service.GetMovieDropdownValue();

                ViewBag.Cinemas = new SelectList(moviedata.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviedata.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviedata.Actors, "Id", "FullName");
                return View();
            }
            await _service.AddNewMovieAsync(newMovieVM);
            
            return RedirectToAction(nameof(Index));
        }

        //  //Movies/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var moviedata = await _service.GetMovieDropdownValue();

            ViewBag.Cinemas = new SelectList(moviedata.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(moviedata.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviedata.Actors, "Id", "FullName");
            var moviedetails = await _service.GetMoviesByIdAsync(id);
            if (moviedetails == null)
            {
                return View("NotFound");
            }

            var movieVm = new NewMovieVM()
            {
                Name = moviedetails.Name,
                Price = moviedetails.Price,
                StartDate = moviedetails.StartDate,
                EndDate = moviedetails.EndDate,
                Description = moviedetails.Description,
                CinemaId = moviedetails.CinemaId,
                ProducerId = moviedetails.ProducerId,
                ImageUrl = moviedetails.ImageUrl,
                MovieCategory = moviedetails.MovieCategory,
                ActorIds = moviedetails.Actors_Movies.Select(n => n.ActorId).ToList()
                
            };
           
            return View(movieVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movieVM)
        {
            if (id != movieVM.Id) 
                return View("NotFound");

            if (!ModelState.IsValid)
            {
                var moviedata = await _service.GetMovieDropdownValue();

                ViewBag.Cinemas = new SelectList(moviedata.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviedata.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviedata.Actors, "Id", "FullName");
                return View(movieVM);
            }

            


            await _service.UpdateMovieAsync(movieVM);

            return RedirectToAction("Index");
        }
    }
}
