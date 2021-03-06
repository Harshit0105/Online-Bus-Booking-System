﻿using BusBooking.Data;
using BusBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
    public class SQLSeatRepository : ISeatRepository
    {
        private readonly ApplicationDbContext context;
        public SQLSeatRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        Seat ISeatRepository.Add(Seat seat)
        {
            context.Seats.Add(seat);
            context.SaveChanges();
            return seat;

        }
        Seat ISeatRepository.Delete(int Id)
        {
            Seat seat = context.Seats.Find(Id);
            if (seat != null)
            {
                context.Seats.Remove(seat);
                context.SaveChanges();
            }
            return seat;
        }

        void ISeatRepository.DeleteSeats(Ticket t)
        {
            List<string> seatNo=t.Seat_Id.Split(',').ToList();
            List<Seat> seats = this.context.Seats.AsNoTracking()
                .Where(s => s.date == t.Travel_Date && s.Bus.Bus_Id == t.Bus_Id)
                .Select(s => s).ToList();
            foreach(var s in seats)
            {
                if (seatNo.Contains(s.Seat_No.ToString()))
                {
                    Seat seat = context.Seats.Find(s.SeatId);
                    if (seat != null)
                    {
                        context.Seats.Remove(seat);
                        context.SaveChanges();
                    }
                }
            }
        }


        Seat ISeatRepository.GetSeat(int Id)
        {
            return context.Seats.Find(Id);
        }

        IEnumerable<Seat> ISeatRepository.GetAllSeats()
        {
            return context.Seats;
        }

        Seat ISeatRepository.Update(Seat seatChanges)
        {
            var seat = context.Seats.Attach(seatChanges);
            seat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return seatChanges;
        }

        IEnumerable<int> ISeatRepository.GetSeatsUsingDateAndBus(DateTime date, int bus_id)
        {
            var seats = this.context.Seats.AsNoTracking()
                .Where(n => n.Bus.Bus_Id == bus_id && n.date == date)
                .Select(n => n.Seat_No)
                .ToList();
            return seats;
        }
    }
}
