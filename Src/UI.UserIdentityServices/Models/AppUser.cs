using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.UserIdentityServices.Models
{
    public class AppUser:IdentityUser
    {
        public string ZipCode { get; set; }
        
        public string Name { get; set; }
        
        public string LastName { get; set; }
    }
}
