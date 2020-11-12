using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusBooking.Models;
using BusBooking.ViewModel;
using Microsoft.AspNetCore.Authorization;
using BusBooking.Repository;
using Microsoft.AspNetCore.Http;

namespace BusBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusRepository _busRepo;
        private readonly ISeatRepository _seatRepo;

        public HomeController(ILogger<HomeController> logger,IBusRepository busrepo, ISeatRepository seatrepo)
        {
            this._logger = logger;
            this._busRepo = busrepo;
            this._seatRepo = seatrepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ViewResult SearchBus()
        {
            var sourceCity = this._busRepo.getSourceCity();
            var destinationCity = this._busRepo.getDestinationCity();
            var busSearch = new BusSearchViewModel()
            {
                SourceCity = sourceCity,
                DestinationCity=destinationCity,
            };
            Console.WriteLine(sourceCity);
            return View(busSearch);
        }
        [HttpPost]
        public IActionResult SearchBus(BusSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var busFound = this._busRepo.GetBusesByCity(model.SelectedSourceCity, model.SelectedDestinationCity);
                var busFoundModel =new BusFoundViewModel();
                busFoundModel.busFound = busFound;
                busFoundModel.dateToTravel = model.DateToTravel;
                return View("BusFound",busFoundModel);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult BusFound()
        {
            return View();
        }
        [HttpGet]
        public IActionResult BusSelected(string date,int id)
        {
            SeatViewModel seats = new SeatViewModel();
            var dateToTravel = Convert.ToDateTime(date);
            var seatForDate = this._seatRepo.GetSeatsUsingDateAndBus(dateToTravel, id);
            seats.seats = seatForDate;
            seats.dateToTravel = dateToTravel;
            seats.bus = this._busRepo.GetBus(id);
            return View(seats);
        }
        [HttpPost]
        public IActionResult BusSelected(FormCollection form)
        {
            foreach(var i in form.Keys)
            {
                Console.WriteLine(i);
            }
            return View("Index");
        }
    }
}
