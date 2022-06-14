using APARTMENTS.Dtos;
using APARTMENTS.DtosComment;
using APARTMENTS.DtosPhoto;
using System.Collections.Generic;

namespace APARTMENTS.DtosApartment
{
    public class GetApDto
    {
        public int Id { get; set; }
        public string ApartmentDescription { get; set; }
        public int NumberOfRooms { get; set; }
        public int MonthlyPrice { get; set; }
        public int OwnerId { get; set; }
        public int RenterId { get; set; }
        public ICollection<GetPhotoDto> Photos { get; set; }
        public ICollection<GetAdressDto> Adress { get; set; }
        public ICollection<GetCommentDto> Comments { get; set; }
    }
}
