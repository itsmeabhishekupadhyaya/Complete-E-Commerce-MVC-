using eTicketNew.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketNew.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }



        [Display(Name ="Logo")]
        public string Logo { get; set; }



        [Display(Name ="Name")]
        [Required(ErrorMessage ="Please enter Name")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="Name should not be less than 5 characters")]
        public string Name { get; set; }



        [Display(Name ="Description")]
        [Required(ErrorMessage ="Please enter Description")]
        public string Description { get; set; }

        //Relationship

        public List<Movie> Movies { get; set; }

       
    }
}
