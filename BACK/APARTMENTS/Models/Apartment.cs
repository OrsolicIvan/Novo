using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APARTMENTS.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string ApartmentDescription { get; set; }
        public int NumberOfRooms { get; set; }
        public int MonthlyPrice { get; set; }
        public ICollection<Adress> Adress { get; set; }
        public User Renter { get; set; }
        public int? RenterId { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public List<Photo> Photos { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
