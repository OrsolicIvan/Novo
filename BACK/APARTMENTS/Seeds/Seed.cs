using APARTMENTS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APARTMENTS.Seeds
{
    public class Seed
    {

        public static async Task SeedUsers(RoleManager<AppRole> roleManager) 
        {
            // SEED za roles, ovdje definiramo koliko i koje cemo rolove imati te se ova
            // funkcija koristi u PROGRAM gdje se pokrece i podatci se ubacuju u bazu podataka
            var roles = new List<AppRole>
            {
            new AppRole{Name = "Member"},
            new AppRole{Name = "Admin" },
            new AppRole{Name = "Moderator" } 
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}
