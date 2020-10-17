using BusBooking.Data;
using BusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
    public class SQLSeatRepository : ISeatRepository
    {
        private readonly ApplicationDbContext context;
        public SQLSeatRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        Seat ISeatRepository.Add(Seat seat)
        {
            context.Seats.Add(seat);
            context.SaveChanges();
            return seat;

        }

        Seat ISeatRepository.Delete(int Id)
        {
            Seat seat = context.Seats.Find(Id);
            if (seat != null)
            {
                context.Seats.Remove(seat);
                context.SaveChanges();
            }
            return seat;
        }


        Seat ISeatRepository.GetSeat(int Id)
        {
            return context.Seats.Find(Id);
        }

        IEnumerable<Seat> ISeatRepository.GetAllSeats()
        {
            return context.Seats;
        }

        Seat ISeatRepository.Update(Seat seatChanges)
        {
            var seat = context.Seats.Attach(seatChanges);
            seat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return seatChanges;
        }
    }
}
