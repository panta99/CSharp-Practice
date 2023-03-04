using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer
{
    public class OperationResult
    {
        public bool Uspesno => Greske.Count == 0;
        public List<string> Greske { get; set; } = new List<string>();
        public string PrvaGreska => Greske.FirstOrDefault();
        public IEnumerable<BaseDto> Data { get; set; }
    }
}
