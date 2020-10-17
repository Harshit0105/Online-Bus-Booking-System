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
            return View();
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
                return RedirectToAction();
            }
            return View();
        }
    }
}
