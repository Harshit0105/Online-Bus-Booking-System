using System;
using BusBooking.Data;
using BusBooking.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
    public class SQLTicketRepository: ITicketRepository
    {
        private readonly ApplicationDbContext context;

        public SQLTicketRepository(ApplicationDbContext context)
        {
            this.context= context;
        }

        Ticket ITicketRepository.Add(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
            return ticket;
        }

        Ticket ITicketRepository.GetTicket(int Id)
        {
            return context.Tickets.Find(Id);
        }
        Ticket ITicketRepository.Delete(int Id)
        {
            Ticket ticket = context.Tickets.Find(Id);
            if (ticket != null)
            {
                context.Tickets.Remove(ticket);
                context.SaveChanges();
            }
            return ticket;
        }

        Ticket ITicketRepository.Update(Ticket ticketChanges) 
        {
            var ticket = context.Tickets.Attach(ticketChanges);
            ticket.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return ticketChanges;
        }

        IEnumerable<Ticket> ITicketRepository.GetAllTickets()
        {
            return context.Tickets;
        }
    }
}
