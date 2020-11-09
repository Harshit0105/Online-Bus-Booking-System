using BusBooking.Data;
using BusBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        IEnumerable<Bus> IBusRepository.GetAllBuses()
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
        IEnumerable<SelectListItem> IBusRepository.getSourceCity()
        {
            List<SelectListItem> source = this.context.Buses.AsNoTracking()
                .OrderBy(n => n.Souce_City)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Souce_City.ToString(),
                    Text=n.Souce_City.ToString(),
                }).ToList();
            var soucetip = new SelectListItem()
            {
                Value = null,
                Text = "Select Source City",
            };
            source.Insert(0, soucetip);
            return new SelectList(source, "Value", "Text");
        }
        IEnumerable<SelectListItem> IBusRepository.getDestinationCity()
        {
            List<SelectListItem> source = this.context.Buses.AsNoTracking()
           .OrderBy(n => n.Destination_City)
           .Select(n =>
           new SelectListItem
           {
               Value = n.Destination_City.ToString(),
               Text = n.Destination_City.ToString(),
           }).ToList();
            var soucetip = new SelectListItem()
            {
                Value = null,
                Text = "Select Destination City",
            };
            source.Insert(0, soucetip);
            return new SelectList(source, "Value", "Text");
        }
    }
}
