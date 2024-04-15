using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        
        public int Id {get;set;}

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage = "Username must be between 3 and 50 characters")]
        public string? Username{get;set;}

        [Required(ErrorMessage = "password is required")]
        [StringLength(200,MinimumLength =6,ErrorMessage = "Password must be between 6 and 200 characters")]
        public string HasedPassword{get;set;}

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email{get;set;}
    }
}