using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer
{
    public abstract class BaseDto
    {
        [Browsable(false)]
        public int Id { get; set; }
    }
}
