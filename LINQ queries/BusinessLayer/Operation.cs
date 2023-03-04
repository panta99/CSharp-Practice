using Primer1.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer
{
    public abstract class Operation 
    {
        public abstract OperationResult Execute();
    }
    public abstract class EfOperation : Operation
    {
        public EfOperation()
        {
            Entities = new CsLabEntities();
        }
        public CsLabEntities Entities{ get; set; }
    }
}
