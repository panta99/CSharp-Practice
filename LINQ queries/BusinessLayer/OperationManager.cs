using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer
{
    public class OperationManager
    {
        public static OperationManager _manager;
        public static OperationManager Instance
        {
            get
            {
                if(_manager == null)
                {
                    _manager = new OperationManager();
                }
                return _manager;
            }
        }
        public OperationResult Exec(Operation o)
        {
            try
            {
                var result = o.Execute();
                return result;
            }
            catch(Exception e)
            {
                var guid = Guid.NewGuid().ToString();
                var msg = "Doslo je do greske, kod " + guid;
                return new OperationResult
                {
                    Greske = new List<string> { msg }
                };
            }
        }
    }
}
