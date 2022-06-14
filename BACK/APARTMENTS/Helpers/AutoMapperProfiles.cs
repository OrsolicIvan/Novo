using APARTMENTS.Dtos;
using APARTMENTS.DtosApartment;
using APARTMENTS.DtosComment;
using APARTMENTS.DtosPhoto;
using APARTMENTS.Extensions;
using APARTMENTS.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APARTMENTS.Helpers
{ 
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Adress, GetAdressDto>();


            CreateMap<User, RegisterDTO>();
            CreateMap<RegisterDTO, User>();
            CreateMap<MemberDto, User>();
            CreateMap<User, GetUserDto>();
            //Kalkuliranje Datuma rodjenja za korisnika
            CreateMap<User, MemberDto>().ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

           

            CreateMap<Adress, GetAdressDto>().ReverseMap();

            CreateMap<Apartment, GetApartmentDto>().ReverseMap();
            CreateMap<GetApDto, Apartment>().ReverseMap();
            CreateMap<GetCommentDto, Comment>();
            CreateMap<Comment, GetCommentDto>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>();
            CreateMap<Photo, GetPhotoDto>();
            CreateMap<UpdateApartmentDto, Apartment>().ReverseMap();
        }
    }
}
