using eTicketNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Data.Services
{
   public interface IActorsService
    {
        public  Task<IEnumerable<Actor>> GetAll();
        public Actor GetById(int id);

        public void Add(Actor actor);
        public Actor Update(int id, Actor newactor);

        public void Delete(int id);

    }
}
