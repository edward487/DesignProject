//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GieAndVince.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class MenuRecipe
    {
        [Key]
        public int MIRID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Name")]
        public string MIRName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Price")]
        public Nullable<double> MIRPrice { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Category")]
        public string MIRCategory { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Size")]
        public string MIRSize { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Recipe")]
        public string MIRRecipe { get; set; }
    }
}
