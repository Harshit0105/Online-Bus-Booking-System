using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Models
{
    public class Ticket
    {
        [Key]
        [Required]
        public int Ticket_Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public ApplicationUser applicationuser { get; set; }

        [ForeignKey("Bus_Id")]
        [Required]
        public int Bus_Id { get; set; }
        public Bus Bus { get; set; }

        [Required]
        public DateTime Travel_Date { get; set; }

        [Required]
        public string Seat_Id { get; set; }

        [Required]
        public float Amount { get; set; }
    }
}
