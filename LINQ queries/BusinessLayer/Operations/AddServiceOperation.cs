using Primer1.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer.Operations
{
    public class AddServiceOperation : EfOperation
    {
        public int VechileID { get; set; }
        public int ServisId { get; set; }
        public DateTime datum { get; set; }

        public override OperationResult Execute()
        {
            var schedule = new ServiceSchedule()
            {
                VehicleId = this.VechileID,
                ServiceTypeId = this.ServisId,
                ScheduledFor = this.datum
            };
            Entities.ServiceSchedules.Add(schedule);
            Entities.SaveChanges();

            return new OperationResult();
        }
    }
}
