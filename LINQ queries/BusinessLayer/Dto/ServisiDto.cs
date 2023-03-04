using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer1.BusinessLayer.Dto
{
    public class ServisiDto : BaseDto
    {
        [DisplayName("Oznaka vozila")]
        public string VehicleLabel { get; set; }
        [DisplayName("Tablica")]
        public string Registration { get; set; }
        public string Model { get; set; }
        [DisplayName("Marka")]
        public string Manufacturer { get; set; }
        [DisplayName("Tip servisa")]
        public string ServiceType { get; set; }
        [DisplayName("Datum zakazivanja")]
        public DateTime ServiceDate { get; set; }
        [DisplayName("Datum završetka")]
        public DateTime? FinishedAt { get; set; }
        [DisplayName("Cena")]
        public decimal? Price { get; set; }
        [DisplayName("Dodatne informacije")]
        public string AdditionalInfo { get; set; }
    }
}
