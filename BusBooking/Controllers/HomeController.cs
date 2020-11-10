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

namespace BusBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusRepository _busRepo;

        public HomeController(ILogger<HomeController> logger,IBusRepository busrepo)
        {
            _logger = logger;
            _busRepo = busrepo;
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
                return View("BusFound",busFound);
            }
            return View(model);
            var sourceCity = this._busRepo.getSourceCity();
            var destinationCity = this._busRepo.getDestinationCity();
            var busSearch = new BusSearchViewModel()
            {
                SourceCity = sourceCity,
                DestinationCity = destinationCity,
            };
            Console.WriteLine(sourceCity);
            return View(busSearch);
        }
        [HttpGet]
        public IActionResult BusFound()
        {
            return View();
        }
    }
}
