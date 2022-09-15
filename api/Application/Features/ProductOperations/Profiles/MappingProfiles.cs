﻿using Application.Features.ProductOperations.Command;
using Application.Features.ProductOperations.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ProductOperations.Profiles;

public class MappingProfiles : Profile
{
     public MappingProfiles()
     {
          CreateMap<Product, GetProductsQueryResponse>().ReverseMap();

          CreateMap<Product, GetProductDetailQueryResponse>()
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
               .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
               .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
               .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName))
               .ReverseMap();

          CreateMap<Product, CreateProductCommandRequest>().ReverseMap();


          #region Test Specifications

          CreateMap<Product, GetSpecificationsTestQueryResponse>()
               .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
               .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
               .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name))
               .ReverseMap();

          #endregion
     }
}

