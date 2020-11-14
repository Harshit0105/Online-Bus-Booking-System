using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.ViewModel
{
    public class BusFoundViewModel
    {
        public IEnumerable<BusBooking.Models.Bus> busFound { get; set; }
        public DateTime dateToTravel { get; set; }
    }
}
