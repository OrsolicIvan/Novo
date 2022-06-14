using APARTMENTS.Dtos;
using APARTMENTS.Interfaces;
using APARTMENTS.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APARTMENTS.Controller
{
    
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("registerMember")]
        public async Task<ActionResult<UserDto>> RegisterMem(RegisterDTO registerDto)
        {
            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Korisnicko ime je zauzeto");
            }
            var user = _mapper.Map<User>(registerDto);
          
            user.UserName = registerDto.Username.ToLower();

            


            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);
            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };

        }
        [HttpPost("registerModerator")]
        public async Task<ActionResult<UserDto>> RegisterMod(RegisterDTO registerDto)
        {
            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Korisnicko ime je zauzeto");
            }
            
            var user = _mapper.Map<User>(registerDto);

            user.UserName = registerDto.Username.ToLower();




            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            if (registerDto.Username == "Admin")
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
                if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);
            }
            else {
                var roleResult = await _userManager.AddToRoleAsync(user, "Moderator");
                if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);
            }
            
            
            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };

        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
             .FirstOrDefaultAsync(x => x.UserName== loginDto.Username.ToLower()); 

            if (user == null) return Unauthorized("Lose korisnicko ime");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
    }


        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(ECKeyXmlFormat => ECKeyXmlFormat.UserName == username.ToLower());
        }


    }
}
