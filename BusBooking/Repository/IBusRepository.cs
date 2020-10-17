using BusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
    public interface IBusRepository
    {
        Bus GetBus(int Id);

        IEnumerable<Bus> GetBuses();

        Bus Add(Bus bus);

        Bus Update(Bus busChanges);

        Bus Delete(int Id);
    }
}
