using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Models;

namespace BusBooking.Repository
{
    public interface ITicketRepository
    {
        Ticket GetTicket(int Id);

        Ticket Add(Ticket ticket);

        Ticket Delete(int Id);

        Ticket Update(Ticket ticketChanges);

        IEnumerable<Ticket> GetAllTickets();

    }
}
