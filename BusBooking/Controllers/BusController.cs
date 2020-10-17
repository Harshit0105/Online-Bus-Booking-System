using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Models;
using BusBooking.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusRepository _busRepo;

        public BusController(IBusRepository busRepo)
        {
            _busRepo = busRepo;
        }
        public IActionResult Index()
        {
            var model = _busRepo.GetAllBuses();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Bus bus = _busRepo.GetBus(id);
            if (bus == null)
                return RedirectToAction("index");
            return View(bus);
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Bus bus = _busRepo.GetBus(id);
            Bus newBus = new Bus
            {
                Bus_Id = bus.Bus_Id,
                Souce_City=bus.Souce_City,
                Destination_City = bus.Destination_City,
                Number_Of_Seats = bus.Number_Of_Seats,
                Source_Time = bus.Source_Time,
                Destination_Time = bus.Destination_Time,
                Price = bus.Price,
                Available = bus.Available,
                Bus_Type = bus.Bus_Type
            };
            return View(newBus);
        }

        [HttpPost]
        public IActionResult Edit(Bus model)
        {
            if (ModelState.IsValid)
            {
                Bus bus = _busRepo.GetBus(model.Bus_Id);
                    bus.Souce_City = model.Souce_City;
                    bus.Destination_City = model.Destination_City;
                    bus.Number_Of_Seats = model.Number_Of_Seats;
                    bus.Source_Time = model.Source_Time;
                    bus.Destination_Time = model.Destination_Time;
                    bus.Price = model.Price;
                    bus.Available = model.Available;
                    bus.Bus_Type = model.Bus_Type;
                Bus updatedBus = _busRepo.Update(bus);
                return RedirectToAction();
            }
            return View(model);
        } 
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bus model)
        {
            if(ModelState.IsValid)
            {
                Bus newBus = new Bus
                {
                    Souce_City = model.Souce_City,
                    Destination_City = model.Destination_City,
                    Number_Of_Seats = model.Number_Of_Seats,
                    Source_Time = model.Source_Time,
                    Destination_Time = model.Destination_Time,
                    Price = model.Price,
                    Available = model.Available,
                    Bus_Type = model.Bus_Type
                };
                _busRepo.Add(newBus);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Bus bus = _busRepo.GetBus(id);
            if (bus == null)
            {
                return RedirectToAction("index");
            }
            return View(bus);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteBus(int id)
        {
            Console.WriteLine(id);
            var bus = _busRepo.GetBus(id);
            if(bus!=null)
                _busRepo.Delete(bus.Bus_Id);
            return RedirectToAction("index");
        }
    }
}
