using eTicketNew.Data.ViewModel;
using eTicketNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Data.Services
{
   public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        public Task<Movie> GetMoviesByIdAsync(int id);

      public   Task<NewMovieDropdownVM> GetMovieDropdownValue();

        Task AddNewMovieAsync(NewMovieVM newMovieVM);

        Task UpdateMovieAsync(NewMovieVM newMovieVM);
    }
}
