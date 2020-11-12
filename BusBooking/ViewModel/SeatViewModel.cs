using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Models;

namespace BusBooking.ViewModel
{
    public class SeatViewModel
    {
        public Bus bus { get; set; }
        public IEnumerable<BusBooking.Models.Seat> seats { get; set; }
        public DateTime dateToTravel { get; set; }
    }
}
