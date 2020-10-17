using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBooking.Models
{
    public class Seat
    {
        [Key]
        [Required]
        public int SeatId { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int Seat_No { get; set; }

        [ForeignKey("Bus_Id")]
        [Required]
        public Bus Bus { get; set; }
        
        [Required]
        [ForeignKey("UserId")]
        public ApplicationUser applicationuser { get; set; }
    }
}
