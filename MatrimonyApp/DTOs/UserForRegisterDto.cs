using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatrimonyApp.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password should be atleast 4 and maximun 8 characters long")]
        public string Password { get; set; }
    }
}
