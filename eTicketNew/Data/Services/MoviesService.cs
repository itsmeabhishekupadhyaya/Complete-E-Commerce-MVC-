using eTicketNew.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>,IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context): base(context)
        {
            this._context = context;
        }

        public async Task<Movie> GetMoviesByIdAsync(int id)
        {
            var moviesDetails = await _context.Movies
                                .Include(c => c.Cinema)
                                .Include(p => p.Producer)
                                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(x => x.Id == id);

            return  moviesDetails;
        }

     
    }
}
