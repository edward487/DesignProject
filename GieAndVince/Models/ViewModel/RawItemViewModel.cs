using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GieAndVince.Models.ViewModel
{
    public class RawItemViewModel
    {
        [Key]
        public int RawID { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Name")]
        public string RIName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Description")]
        public string RIDescription { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Price")]
        public int RIPrice { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Quantity")]
        public int RIQuantity { get; set; }
    }
}