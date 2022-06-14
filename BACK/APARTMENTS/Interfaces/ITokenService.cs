using APARTMENTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    
    
    }
}
