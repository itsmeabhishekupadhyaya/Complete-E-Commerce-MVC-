﻿using eTicketNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Data.ViewModel
{
    public class NewMovieDropdownVM
    {
        public NewMovieDropdownVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();

        }
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
