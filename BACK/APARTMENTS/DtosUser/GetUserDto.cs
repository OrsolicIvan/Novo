using APARTMENTS.DtosApartment;
using APARTMENTS.DtosPhoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        
        public List<GetApartmentDto> RentedApartments { get; set; }
        public List<GetApartmentDto> OwnedApartments { get; set; }
        
    }
}
