﻿using AutoMapper;
using CourseLibrary.Api.Helpers;

namespace CourseLibrary.Api.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
            CreateMap<Models.AuthorForCreationDto, Entities.Author>();
        }
    }
}