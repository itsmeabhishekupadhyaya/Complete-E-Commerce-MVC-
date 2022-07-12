using eTicketNew.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Please enter Profile Picture URL")]
        public string ProfilePrictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Please enter Name")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name should not be less than 3 characters")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Please enter Biography")]
        public string Bio { get; set; }

        //Relationships

        public List<Movie> Movies { get; set; }
    }
}
