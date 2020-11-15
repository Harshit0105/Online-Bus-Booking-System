using BusBooking.Data;
using BusBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                    Value = n.Souce_City.ToString().ToUpper(),
                    Text=n.Souce_City.ToString().ToUpper(),
                }).ToList();
            var soucetip = new SelectListItem()
            {
                Value = null,
                Text = "Select Source City",
            };
            source.Insert(0, soucetip);
            source = source.GroupBy(x => x.Text).Select(x=>x.First()).ToList();
            return new SelectList(source, "Value", "Text");
        }
        IEnumerable<SelectListItem> IBusRepository.getDestinationCity()
        {
            List<SelectListItem> destination = this.context.Buses.AsNoTracking()
           .OrderBy(n => n.Destination_City)
           .Select(n =>
           new SelectListItem
           {
               Value = n.Destination_City.ToString().ToUpper(),
               Text = n.Destination_City.ToString().ToUpper(),
           }).ToList();
            var destinationtip = new SelectListItem()
            {
                Value = null,
                Text = "Select Destination City",
            };
            destination.Insert(0, destinationtip);
            destination = destination.GroupBy(x => x.Text).Select(x => x.First()).ToList();
            return new SelectList(destination, "Value", "Text");
        }

        IEnumerable<Bus> IBusRepository.GetBusesByCity(string source, string destination)
        {
            List<Bus> buses = this.context.Buses.AsNoTracking()
                .Where(n => (n.Souce_City.Equals(source) && n.Destination_City.Equals(destination)) && (n.Available==true))
                .Select(n => n)
                .ToList();
            return buses;
        }
    }
}
