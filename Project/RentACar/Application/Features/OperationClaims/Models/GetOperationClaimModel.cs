using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Models
{
    public class GetOperationClaimModel :BasePageableModel
    {
        public IList<OperationClaim> Items { get; set; }
    }
}
