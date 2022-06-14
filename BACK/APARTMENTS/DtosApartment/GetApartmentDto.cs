using APARTMENTS.DtosComment;
using APARTMENTS.DtosPhoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Dtos
{
    public class GetApartmentDto
    { 
        public int Id { get; set; }
        public string ApartmentDescription { get; set; }
        public int NumberOfRooms { get; set; }
        public int MonthlyPrice { get; set; }
        public int RenterId { get; set; }
        public int OwnerId { get; set; }
    }
}
