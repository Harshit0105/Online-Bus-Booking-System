using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Models;

namespace BusBooking.Repository
{
    public interface ISeatRepository
    {
        Seat GetSeat(int Id);

        Seat Add(Seat seat);

        Seat Delete(int Id);

        Seat Update(Seat seatChanges);

        IEnumerable<Seat> GetAllSeats();
        IEnumerable<int> GetSeatsUsingDateAndBus(DateTime date,int bus_id);
    }
}
