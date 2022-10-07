using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand :IRequest<CreateOperationClaimDto>
    {
        public string Name { get; set; }
        public class CreateOperationClaimCommandHandler: IRequestHandler<CreateOperationClaimCommand, CreateOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }


            public async Task<CreateOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(operationClaim);
                CreateOperationClaimDto result = _mapper.Map<CreateOperationClaimDto>(createdOperationClaim);
                return result;
            }
        }
    }
}
