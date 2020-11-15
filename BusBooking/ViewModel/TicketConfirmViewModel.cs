using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Models;

namespace BusBooking.ViewModel
{
    public class TicketConfirmViewModel
    {
        public TicketConfirmViewModel()
        {
            this.seats = new List<Seat>();
        }
        public List<Seat> seats { get; set; }
        public Ticket ticket { get; set; }
        public Bus bus { get; set; }
    }
}
