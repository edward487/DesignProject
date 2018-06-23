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


        // for changing password
        [DataType(DataType.Password)]
        [DisplayName("Current Password")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "Password do not match.")]
        public string ConfirmNewPassword { get; set; }

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

        public IList<Account> Accounts { get; set; }
    }
}