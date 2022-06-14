using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APARTMENTS.Models
{
    public class User : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public List<AppUserRole> UserRoles { get; set; }
        public List<Apartment> RentedApartments { get; set; }
        public List<Apartment> OwnedApartments { get; set; }

      
    }
}
 