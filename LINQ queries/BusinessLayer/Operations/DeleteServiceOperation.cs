using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer.Operations
{
    public class DeleteServiceOperation : EfOperation
    {
        public int Id { get; set; }
        public override OperationResult Execute()
        {
            var brisanje = Entities.ServiceSchedules.Find(Id);
            Entities.ServiceSchedules.Remove(brisanje);
            Entities.SaveChanges();
            return new OperationResult();
        }
    }
}
