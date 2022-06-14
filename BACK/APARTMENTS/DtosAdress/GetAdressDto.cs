using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Dtos
{
    public class GetAdressDto
    {
        public string City { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public int ApartmentId { get; set; }
    }
}
