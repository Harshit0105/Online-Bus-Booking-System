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
using Microsoft.AspNetCore.Identity;

namespace BusBooking.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IBusRepository _busRepo;
        private readonly ISeatRepository _seatRepo;
        private readonly ITicketRepository _ticketRepo;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(ITicketRepository ticketRepo,ILogger<HomeController> logger,IBusRepository busrepo, ISeatRepository seatrepo, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this._logger = logger;
            this._busRepo = busrepo;
            this._seatRepo = seatrepo;
            this._ticketRepo = ticketRepo;
            this.signInManager = signInManager;
            this.userManager = userManager;
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
                busFoundModel.SourceCity = model.SelectedSourceCity;
                busFoundModel.DestinationCity = model.SelectedDestinationCity;
                /*if(busFoundModel.SourceCity.Equals(busFoundModel.DestinationCity)
                    {
                    ErrorMessage = "Source City and Destination city cannot be same";
                }
                else
                {*/
                    return View("BusFound", busFoundModel);
                //}
               
            }
            else
            {
                return View(model);
            }
           
        }
        [HttpGet]
        public IActionResult BusFound(string Scity, string Dcity)
        {
            BusFoundViewModel busFound = new BusFoundViewModel();
            busFound.SourceCity = Scity;
            busFound.DestinationCity = Dcity;
          
            return View(busFound);
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
        public async Task<IActionResult> BusSelected(IFormCollection form)
        {
            var user = await userManager.GetUserAsync(User);
            var bus_id = Convert.ToInt32(form["bus_id"]);
            var date = Convert.ToDateTime(form["date"]);
            var bus = this._busRepo.GetBus(bus_id);
            List<int> seats = new List<int>();
            var ticketViewModel = new TicketConfirmViewModel();
            ticketViewModel.bus = bus;
            foreach (var i in form["checkbox"])
            {
                seats.Add(Convert.ToInt32(i));
            }
            foreach (var seatNo in seats)
            {
                var newSeat = new Seat()
                {
                    Seat_No = seatNo,
                    date = date,
                    Bus = bus,
                    applicationuser = user,
                };
               ticketViewModel.seats.Add(newSeat);
                this._seatRepo.Add(newSeat);
            }
            Ticket ticket = new Ticket()
            {
                applicationuser = user,
                Bus = bus,
                Bus_Id=bus.Bus_Id,
                Travel_Date = date,
                Amount = seats.Count() * bus.Price,
                Seat_Id = string.Join(",", seats),
            };
            //  ticketViewModel.ticket = ticket;
            this._ticketRepo.Add(ticket);
            return View("ViewTicket", ticket);
        }
        [HttpGet]
        public IActionResult DeleteTicket(int id)
        {
            Ticket t = this._ticketRepo.GetTicket(id);
            this._seatRepo.DeleteSeats(t);
            return View("Index");
        }
        [HttpGet]
        public IActionResult SeatSelected()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewTicket()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AllTicket()
        {
            TicketListViewModel ticketListViewModel = new TicketListViewModel();
            IEnumerable<Ticket> tickets = new List<Ticket>();
            ApplicationUser user = await userManager.GetUserAsync(User);
            tickets = this._ticketRepo.GetAllTicketsByUser(user);
            ticketListViewModel.tickets = (List<Ticket>)tickets;
            foreach(var i in tickets)
            {
                Bus bus = this._busRepo.GetBus(i.Bus_Id);
                ticketListViewModel.buses.Add(bus);
            }
            return View(ticketListViewModel);
        }
    }
}
