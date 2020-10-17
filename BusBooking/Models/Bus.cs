using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Models
{
    public class Bus
    {
        [Required]
        [Key]
        public int Bus_Id { get; set; }
        [Required]
        public string Souce_City { set; get; }
        [Required]
        public string Destination_City { get; set; }
        [Required]
        public int Number_Of_Seats { get; set; }
        [Required]
        public DateTime Source_Time{get;set;}
        [Required]
        public DateTime Destination_Time { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public Boolean Available { get; set; }
        [Required]
        public B_Type Bus_Type { get; set; }
        public enum B_Type
        {
            Seeting,
            Sleeping,
            SeetingAC,
            SleepingAC
        }
    }
}
