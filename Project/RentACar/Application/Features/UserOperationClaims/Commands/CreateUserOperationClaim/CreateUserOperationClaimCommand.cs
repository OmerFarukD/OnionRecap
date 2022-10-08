using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand :IRequest<CreateUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public class CreateUserOperationClaimCommandHandler:IRequestHandler<CreateUserOperationClaimCommand, CreateUserOperationClaimDto>
        {
            private readonly IUserOperationClaimsRepository _userOperationClaimsRepository;
            private readonly IMapper _mapper;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimsRepository userOperationClaimsRepository, IMapper mapper)
            {
                _userOperationClaimsRepository = userOperationClaimsRepository;
                _mapper = mapper;
            }
            public async Task<CreateUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim createdUserOperationClaim = await _userOperationClaimsRepository.AddAsync(userOperationClaim);
                CreateUserOperationClaimDto result = _mapper.Map<CreateUserOperationClaimDto>(createdUserOperationClaim);
                return result;
            }
        }
    }
}
