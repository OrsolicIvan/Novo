using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url{ get; set; }
        public bool IsMain{ get; set; }
        public string PublicId { get; set; }
        public Apartment apartment{ get; set; }
        public int ApId { get; set; }

    }
}
