using eTicketNew.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Models
{
    public class NewMovieVM 
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }


        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public double Price { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "Image URL is required")]
        public string ImageUrl { get; set; }


        [Display(Name = "Movie Start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie End date")]
        [Required(ErrorMessage = "Start End is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Movie Category is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Movie Actor(s)")]
        [Required(ErrorMessage = "Movie Actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Movie Actor(s)")]
        [Required(ErrorMessage = "Movie Cinema is required")]
        public int CinemaId { get; set; }


        [Display(Name = "Movie Producer(s)")]
        [Required(ErrorMessage = "Movie Producer is required")]
        public int ProducerId { get; set; }
        


    }
}
