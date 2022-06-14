using APARTMENTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APARTMENTS.Dtos
{
    public class CreateApDto
    {
        public string ApartmentDescription { get; set; }
        public int NumberOfRooms { get; set; }
        public int MonthlyPrice { get; set; }
        public int OwnerId { get; set; }

        
    }
};