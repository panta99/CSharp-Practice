using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer.Dto
{
    public class ServiceTypeDto : BaseDto
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
