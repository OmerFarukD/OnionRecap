using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim,CreateUserOperationClaimCommand>()
                .ForMember(c=>c.OperationClaimId,opt=>opt.MapFrom(c=>c.OperationClaim))
                .ForMember(c=>c.UserId,opt=>opt.MapFrom(c=>c.User))
                .ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimDto>()
                .ForMember(c => c.OperationClaimId, opt => opt.MapFrom(c => c.OperationClaim))
                .ForMember(c => c.UserId, opt => opt.MapFrom(c => c.User))
                .ReverseMap();

            CreateMap<UserOperationClaim, UserOperationClaimListDto>()
                .ForMember(c => c.OperationClaimId, opt => opt.MapFrom(c => c.OperationClaim))
                .ForMember(c => c.UserId, opt => opt.MapFrom(c => c.User))
                .ReverseMap();
        }
    }
}
