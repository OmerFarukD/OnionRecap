using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaimDynamic
{
    public class GetListUserOperationClaimDynamicQuery :IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetListUserOperationClaimDynamicQueryHandler: IRequestHandler<GetListUserOperationClaimDynamicQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimsRepository _userOperationClaimsRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimDynamicQueryHandler(IUserOperationClaimsRepository userOperationClaimsRepository, IMapper mapper)
            {
                _userOperationClaimsRepository = userOperationClaimsRepository;
                _mapper = mapper;
            }
            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<UserOperationClaim> claims = await _userOperationClaimsRepository.GetListByDynamicAsync(
                    index: request.PageRequest.Page
                    , size: request.PageRequest.PageSize, dynamic: request.Dynamic,include:m=>m.Include(u=>u.User).Include(o=>o.OperationClaim));

                UserOperationClaimListModel result = _mapper.Map<UserOperationClaimListModel>(claims);
                return result;
            }
        }
    }
}
