using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APARTMENTS.Models;
using APARTMENTS.Interfaces;
using APARTMENTS.Dtos;
using AutoMapper;
using APARTMENTS.DtosPhoto;
using APARTMENTS.DtosUser;
using AutoMapper.QueryableExtensions;
using APARTMENTS.DtosComment;
using APARTMENTS.DtosApartment;

namespace APARTMENTS.Controller
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IPhotoService _photoService;

        public UsersController(IUserRepository userRepository, IMapper mapper, Context context, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
            _photoService = photoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers()
        {
            return await _context.Users.ProjectTo<GetUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

        }
        [HttpGet("apartments")]
        public async Task<ActionResult<IEnumerable<GetApDto>>> GetAps()
        {
            return await _context.Apartments.ProjectTo<GetApDto>(_mapper.ConfigurationProvider).Where(i => i.RenterId == 0).ToListAsync();
        }
        [HttpGet("{RenterId}Rent")]
        public async Task<ActionResult<IEnumerable<GetApDto>>> GetReAps(int RenterId)
        {
            return await _context.Apartments.ProjectTo<GetApDto>(_mapper.ConfigurationProvider).Where(i => i.RenterId == RenterId).ToListAsync();  
        }

        [HttpGet("{OwnerId}")]
        public async Task<ActionResult<IEnumerable<GetApDto>>> GetApsById(int OwnerId)
        {
            return await _context.Apartments.ProjectTo<GetApDto>(_mapper.ConfigurationProvider).Where(x => x.OwnerId == OwnerId).ToListAsync(); 
        }
        [HttpGet("{ApartmentId}Comments")]
        public async Task<ActionResult<IEnumerable<GetCommentDto>>> GetComById(int ApartmentId) {
            return await _context.Comments.ProjectTo<GetCommentDto>(_mapper.ConfigurationProvider).Where(x => x.ApartmentId == ApartmentId).ToListAsync();
        }
        



        
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await _context.Users.Where(i => i.Id == id).Include(p => p.Photos).Include(oa => oa.OwnedApartments).Include(c => c.RentedApartments).ThenInclude(ap => ap.Apartment).SingleOrDefaultAsync();

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}
        //[HttpGet("{username}", Name = "GetUser")]
        //public async Task<ActionResult<MemberDto>> GetUSer(string username) 
        //{
        //    return await _userRepository.GetMemberAsync(username);
        //}




        [HttpPut("UserDetails")]
        public async Task<ActionResult<User>> AddDetails(UserDetailDto userDetail)
        {
            var user = await _context.Users.Where(i => i.Id == userDetail.Id).SingleOrDefaultAsync();
                if (user != null)
                {
                    user.Email = userDetail.Email;
                    user.PhoneNumber = userDetail.PhoneNumber;
                    await _context.SaveChangesAsync();
                }
                else return NotFound();
                return Ok(user);
        }



        [HttpPost("ApartmentAdress")]
        public async Task<ActionResult<Adress>> AddAdressToApartment(CreateAdressDto adress)
        {
            var apartment = await _context.Apartments
                .Include(x => x.Adress)
                .SingleOrDefaultAsync(x => x.Id == adress.ApartmentId);
            if (apartment == null) 
                return NotFound();
            var newAdress = new Adress
            {
                City = adress.City,
                Apartment = apartment,
                BuildingNumber = adress.BuildingNumber,
                ApartmentNumber = adress.ApartmentNumber,
                ApartmentId = adress.ApartmentId,
                StreetName = adress.StreetName
            };
            
            apartment.Adress.Add(newAdress);
            _context.Adresses.Add(newAdress);
            await _context.SaveChangesAsync();

            return Ok();
        }
        //HttpPost metoda kojom osoba koja je vlasnik stan taj stan objavi 
        [HttpPost("OwnedApartment")]
        public async Task<ActionResult<User>> AddOwnedApartment(CreateApDto ownedApartment)
        {
            var user = await _context.Users
                .Include(x => x.OwnedApartments)
                .SingleOrDefaultAsync(x => x.Id == ownedApartment.OwnerId);
            
            if (user == null)
                return NotFound();
            var newApartment = new Apartment
            {
                ApartmentDescription = ownedApartment.ApartmentDescription,
                Owner = user,
                NumberOfRooms = ownedApartment.NumberOfRooms,
                MonthlyPrice = ownedApartment.MonthlyPrice,
                
            };
            
            user.OwnedApartments.Add(newApartment);
            _context.Apartments.Add(newApartment);
            
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("RentedApartment")]
        public async Task<ActionResult<User>> AddRentedApartment(int apartmentId ,RentApDto rentedApartment)
        {
            var user = await _context.Users
                .Include(x => x.RentedApartments)
                .Where(x => x.Id == rentedApartment.RenterId)
                .SingleOrDefaultAsync();
            var apartment = await _context.Apartments
                .Where(i => i.Id == apartmentId)
                .SingleOrDefaultAsync();
            if (user == null)
                return NotFound();
            if (apartment != null)
            {
                apartment.RenterId= apartment.RenterId;
                apartment.Renter = user;
            }
            else return BadRequest();
            user.RentedApartments.Add(apartment);
            _context.Entry(apartment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
            
        }
        [HttpPut("UpdateApartment")]
        public async Task<ActionResult<User>> UpdateApartment(int apartmentId, UpdateApartmentDto OwnedApartment)
        {
            var user = await _context.Users
                .Include(x => x.OwnedApartments)
                .FirstOrDefaultAsync();
            var apartment = await _context.Apartments
                .Where(i => i.Id == apartmentId)
                .FirstOrDefaultAsync();
            if (user == null)
                return NotFound();
            if (apartment != null)
            {
                apartment.ApartmentDescription = OwnedApartment.ApartmentDescription;
                apartment.MonthlyPrice = OwnedApartment.MonthlyPrice;
                apartment.NumberOfRooms = OwnedApartment.NumberOfRooms;
            }
            else return BadRequest();
            //user.OwneApartments.(apartment);
            _context.Entry(apartment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpPut("CancelRent")]
        public async Task<ActionResult<User>> CancelRentedApartment(int apartmentId, RentApDto rentedApartment)
        {
            var user = await _context.Users
                .Include(x => x.RentedApartments)
                .Where(x => x.Id == rentedApartment.RenterId)
                .SingleOrDefaultAsync();
            var apartment = await _context.Apartments
                .Where(i => i.Id == apartmentId)
                .SingleOrDefaultAsync();
            if (user == null)
                return NotFound();
            if (apartment != null)
            {
                apartment.RenterId = apartment.RenterId;
                apartment.Renter = user;
            }
            else return BadRequest();
            user.RentedApartments.Remove(apartment);
            _context.Entry(apartment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();

        }

       
        [HttpPost("add-comment")]
        public async Task<ActionResult<CreateCommentDto>> AddComment(CreateCommentDto comment)
        {
            var apartment = await _context.Apartments.Include(i => i.Comments).SingleOrDefaultAsync(ir => ir.Id == comment.ApartmentId);
            if (apartment == null) return NotFound();
            var newcomment = new Comment
            {
                OwnerComment = comment.OwnerComment,
                ApartmentComment = comment.ApartmentComment,
                ApartmentId = comment.ApartmentId,
                Apartment = apartment
            };
            apartment.Comments.Add(newcomment);
            _context.Comments.Add(newcomment);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("add-photo")]
        public async Task<ActionResult<List<PhotoDto>>> AddPhoto(int id,IFormFile file)
        {
            var apartment = await _userRepository.GetApByIdAsync(id);
            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);
            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

           
                apartment.Photos.Clear();
                apartment.Photos.Add(photo);
                await _userRepository.SaveAllAsync();
                return Ok("");
        }



    }
}
