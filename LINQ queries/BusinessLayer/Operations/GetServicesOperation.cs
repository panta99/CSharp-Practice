using Primer1.BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer.Operations
{
    public class GetServicesOperation : EfOperation
    {
        public int? Id { get; set; }
        public string Keyword { get; set; }
        public override OperationResult Execute()
        {
            var query = Entities.ServiceSchedules.AsQueryable() ;

            if (Id.HasValue)
            {
                query = query.Where(x => x.ServiceTypeId == Id);
            }
            if (!string.IsNullOrEmpty(Keyword))
            {
                query = query.Where(x => x.Vehicle.Label.Contains(Keyword) ||
                                        x.Vehicle.Model.Name.Contains(Keyword) ||
                                        x.Vehicle.Model.Manufacturer.Name.Contains(Keyword));
            }
            return new OperationResult
            {
                Data = query.Select(x => new ServisiDto
                {
                    Id = x.Id,
                    AdditionalInfo = x.AdditionalInfo,
                    FinishedAt = x.FinishedAt,
                    Price = x.Price,
                    ServiceDate = x.ScheduledFor,
                    VehicleLabel = x.Vehicle.Label ?? (x.Vehicle.Registrations.Any() ? x.Vehicle.Registrations.FirstOrDefault().RegistrationPlate.RegistrationPlate1 : "N/A"),
                    Model = x.Vehicle.Model.Name,
                    Manufacturer = x.Vehicle.Model.Manufacturer.Name,
                    ServiceType = x.ServiceType.Name,
                    Registration = x.Vehicle.Registrations.Any() ?
                                   x.Vehicle.Registrations.OrderByDescending(y => y.IssuedAt)
                                   .FirstOrDefault().RegistrationPlate.RegistrationPlate1
                                   : "N/A"
                }).ToList()
            };
        }
    }
}
