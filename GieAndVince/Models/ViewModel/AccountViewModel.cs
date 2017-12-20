using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GieAndVince.Models.Db;

namespace GieAndVince.Models.ViewModel
{
    public class AccountViewModel
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        //[StringLength(50,MinimumLength=8, ErrorMessage="Password must 8 characters long")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
    }
}