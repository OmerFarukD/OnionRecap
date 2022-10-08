using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim,CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, GetOperationClaimListDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, GetOperationClaimModel>().ReverseMap();
            CreateMap<OperationClaim, GetByIdOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, GetByIdOperationClaimQuery>().ReverseMap();

        }
    }
}
