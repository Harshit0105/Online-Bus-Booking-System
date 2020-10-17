using BusBooking.Data;
using BusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
    public class SQLBusRepository : IBusRepository
    {
        private readonly ApplicationDbContext context;

        public SQLBusRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        Bus IBusRepository.Add(Bus bus)
        {
            context.Buses.Add(bus);
            context.SaveChanges();
            return bus;
             
        }
         
       Bus IBusRepository.Delete(int Id)
       {
            Bus bus = context.Buses.Find(Id);
            if(bus!=null)
            {
                context.Buses.Remove(bus);
                context.SaveChanges();
            }
            return bus;
       }


        Bus IBusRepository.GetBus(int Id)
        {
            return context.Buses.Find(Id);
        }

        IEnumerable<Bus> IBusRepository.GetBuses()
        {
            return context.Buses;
        }

        Bus IBusRepository.Update(Bus busChanges)
        {
            var bus = context.Buses.Attach(busChanges);
            bus.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return busChanges;
        }
    }
}
