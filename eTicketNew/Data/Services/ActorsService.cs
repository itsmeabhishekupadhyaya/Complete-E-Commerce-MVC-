﻿using eTicketNew.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService

    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context) :base(context)
        {
            
        }
       

    }
}
