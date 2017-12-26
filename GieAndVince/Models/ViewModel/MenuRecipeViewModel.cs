using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GieAndVince.Models.ViewModel
{
    public class MenuRecipeViewModel
    {
        [Key]
        public int MIRID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Name")]
        public string MIRName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Recipe")]
        public string MIRRecipe { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Price")]
        public decimal MIRPrice { get; set; }
    }
}