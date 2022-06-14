using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Models
{
    public class AppUserRole: IdentityUserRole<int>
    {
        
        public User User { get; set; }
        public AppRole Role { get; set; }
    }
}
