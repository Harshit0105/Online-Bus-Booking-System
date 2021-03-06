﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Models;
using BusBooking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Controllers
{
    [Authorize(Roles ="Admin")]
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
                Bus_Type = bus.Bus_Type,
                Bus_Name=bus.Bus_Name,
                Bus_No=bus.Bus_No
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
                    bus.Bus_Name = model.Bus_Name;
                    bus.Bus_No = model.Bus_No;
                Bus updatedBus = _busRepo.Update(bus);
                return RedirectToAction("index");
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
                    Souce_City = model.Souce_City.ToUpper(),
                    Destination_City = model.Destination_City.ToUpper(),
                    Number_Of_Seats = model.Number_Of_Seats,
                    Source_Time = model.Source_Time,
                    Destination_Time = model.Destination_Time,
                    Price = model.Price,
                    Available = model.Available,
                    Bus_Type = model.Bus_Type,
                    Bus_No=model.Bus_No,
                    Bus_Name=model.Bus_Name
                };
                _busRepo.Add(newBus);
             /*   Bus newBus2 = new Bus
                {
                    Souce_City = model.Destination_City.ToUpper(),
                    Destination_City = model.Souce_City.ToUpper(),
                    Number_Of_Seats = model.Number_Of_Seats,
                    Source_Time = model.Source_Time.AddHours(1),
                    Destination_Time = model.Destination_Time.AddHours(1),
                    Price = model.Price,
                    Available = model.Available,
                    Bus_Type = model.Bus_Type,
                    Bus_No = model.Bus_No,
                    Bus_Name = model.Bus_Name
                };
                _busRepo.Add(newBus2);*/
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
