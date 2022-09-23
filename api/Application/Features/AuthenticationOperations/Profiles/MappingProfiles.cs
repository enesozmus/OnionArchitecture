﻿using Application.Features.AuthenticationOperations.Command;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.AuthenticationOperations.Profiles;

public class MappingProfiles : Profile
{
     public MappingProfiles()
     {
          CreateMap<AppUser, RegisterCommandRequest>().ReverseMap();
     }
}

