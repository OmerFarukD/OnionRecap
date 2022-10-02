using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetListBrand;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateedBrandDto>().ReverseMap();
            CreateMap<Brand,CreateBrandCommand>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<Brand, BrandGetByIdDto>().ReverseMap();
            CreateMap<Brand, DeletedBrandDto>().ReverseMap();
            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdatedBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
        }
    }
}
