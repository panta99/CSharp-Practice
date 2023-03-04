using Primer1.BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer.Operations
{
    public class GetVechileOperation : EfOperation
    {
        public override OperationResult Execute()
        {
            return new OperationResult
            {
                Data = Entities.Vehicles.Select(x => new VechileDto
                {
                    Id = x.Id,
                    Registration = x.Registrations.Any() ? x.Registrations.OrderByDescending(y => y.IssuedAt).FirstOrDefault().RegistrationPlate.RegistrationPlate1 : x.Label
                }).ToList()
            };
        }
    }
}
