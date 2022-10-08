using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimListModel :BasePageableModel
    {
        public List<UserOperationClaimListDto> Items { get; set; }
    }
}
