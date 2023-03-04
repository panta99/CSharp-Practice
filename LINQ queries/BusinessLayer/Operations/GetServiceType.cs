using Primer1.BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer.Operations
{
    public class GetServiceType : EfOperation
    {
        public override OperationResult Execute()
        {
            return new OperationResult
            {
                Data = Entities.ServiceTypes.Select(x => new ServiceTypeDto 
                { 
                 Id = x.Id,
                  Name = x.Name
                }).ToList()
            };
        }
    }
}
