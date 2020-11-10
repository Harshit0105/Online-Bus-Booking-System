using BusBooking.Models;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
    public interface IBusRepository
    {
        Bus GetBus(int Id);
        IEnumerable<Bus> GetBusesByCity(string source,string  destination);
        IEnumerable<Bus> GetAllBuses();
        IEnumerable<SelectListItem> getSourceCity();
        IEnumerable<SelectListItem> getDestinationCity();
        Bus Add(Bus bus);

        Bus Update(Bus busChanges);

        Bus Delete(int Id);
    }
}
