using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaims
{
    public class GetListUserOperationClaimQuery :IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserOperationClaimQueryHandler: IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimsRepository _userOperationClaimsRepository;
            private IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimsRepository userOperationClaimsRepository, IMapper mapper)
            {
                _userOperationClaimsRepository = userOperationClaimsRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> claims = await _userOperationClaimsRepository.GetListAsync(index:request.PageRequest.Page,
                    size:request.PageRequest.PageSize,
                    include:o=>o.Include(u=>u.User).Include(o=>o.OperationClaim)
                );
                UserOperationClaimListModel model = _mapper.Map<UserOperationClaimListModel>(claims);
                return model;
            }
        }
    }
}
