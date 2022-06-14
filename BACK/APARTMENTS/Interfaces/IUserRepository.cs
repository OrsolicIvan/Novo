using APARTMENTS.Dtos;
using APARTMENTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);
        void Create(User user);

        Task<bool> SaveAllAsync();
        Task<IEnumerable<User>> GetUserAsync();
        
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>>  GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);
        Task<Apartment> GetApByIdAsync(int id);
         
    }
}
