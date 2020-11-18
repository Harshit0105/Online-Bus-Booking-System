using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Models;

namespace BusBooking.ViewModel
{
    public class TicketListViewModel
    {
        public TicketListViewModel()
        {
           this.buses = new List<Bus>();
            this.tickets = new List<Ticket>();
        }
        public List<Ticket> tickets { get; set; }
        public List<Bus> buses { get; set; }
    }
}
