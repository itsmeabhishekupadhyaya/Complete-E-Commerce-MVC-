using eTicketNew.Data.ViewModel;
using eTicketNew.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
     

        public MoviesService(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM newMovieVM)
        {
            var newmovie = new Movie()
            {
                Name = newMovieVM.Name,
                Description = newMovieVM.Description,
                Price = newMovieVM.Price,
                CinemaId = newMovieVM.CinemaId,
                ProducerId = newMovieVM.ProducerId,
                StartDate = newMovieVM.StartDate,
                EndDate = newMovieVM.EndDate,
                ImageUrl = newMovieVM.ImageUrl,
                MovieCategory = newMovieVM.MovieCategory
               
            };
            await _context.Movies.AddAsync(newmovie);
            await _context.SaveChangesAsync();
            //save Actors_movies data
            foreach( var actorid in newMovieVM.ActorIds)
            {
                var actormovies = new Actor_Movie()
                {
                    MovieId = newmovie.Id,
                    ActorId = actorid
                };
                await _context.Actors_Movies.AddAsync(actormovies);
            }
            await _context.SaveChangesAsync();

        }


        public async Task<NewMovieDropdownVM> GetMovieDropdownValue()
        {
            var response = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()

            };


            return response;
        }

        public async Task<Movie> GetMoviesByIdAsync(int id)
        {
            var moviesDetails = await _context.Movies
                                .Include(c => c.Cinema)
                                .Include(p => p.Producer)
                                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(x => x.Id == id);

            return moviesDetails;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie  = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.ImageUrl = data.ImageUrl;
                dbMovie.MovieCategory = data.MovieCategory;



             }
               
                await _context.SaveChangesAsync();

            //remove existing actor

            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id);
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();
                //save Actors_movies data
                foreach (var actorid in data.ActorIds)
                {
                    var actormovies = new Actor_Movie()
                    {
                        MovieId = data.Id,
                        ActorId = actorid
                    };
                    await _context.Actors_Movies.AddAsync(actormovies);
                }
                await _context.SaveChangesAsync();
            } 
           
        }
    }

