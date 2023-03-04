using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer.Operations
{
    public class FinishServiceOperation : EfOperation
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string AdditionalInfo { get; set; }

        public override OperationResult Execute()
        {
            var serviceSchedule = Entities.ServiceSchedules.Find(Id);

            if(serviceSchedule.FinishedAt != null)
            {
                return new OperationResult
                {
                    Greske = new List<string> { "Nije mogue zavrsiti servis, jer je vec zavrsen" }
                };
            }
            serviceSchedule.FinishedAt = DateTime.UtcNow;
            serviceSchedule.Price = Price;
            serviceSchedule.AdditionalInfo = AdditionalInfo;
            Entities.SaveChanges();
            return new OperationResult();
        }
    }
}
