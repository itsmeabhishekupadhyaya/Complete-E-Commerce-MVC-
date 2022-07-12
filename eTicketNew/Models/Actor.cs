using eTicketNew.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Pricture URL")]
        [Required(ErrorMessage ="Please enter Profile Pricture Url")]

        public string ProfilePrictureUrl { get; set; }
        [Display(Name = "Actor Name")]
        [Required(ErrorMessage = "Please enter Full Name")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Length must be between 3 to 50")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Please enter Biography")]
        public string Bio { get; set; }

        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
