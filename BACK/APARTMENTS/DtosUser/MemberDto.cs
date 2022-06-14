using APARTMENTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Dtos
{
    public class MemberDto
    {
        public int  Id {get;set;}
        public string UserName { get; set; }
        public int Age { get; set; }

        public int PhoneNumber { get; set; }
       
    }
}
