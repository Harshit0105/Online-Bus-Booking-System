using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BusBooking.ViewModel
{
    public class BusSearchViewModel
    {
        [Required(ErrorMessage ="Please Select Source City")]
        [Display(Name = "From")]
        public string SelectedSourceCity { get; set; }
      
        public IEnumerable<SelectListItem> SourceCity { get; set; }


        [Required(ErrorMessage = "Please Select Destination City")]
        [Display(Name = "To")]
        //[Compare(nameof(SelectedSourceCity),ErrorMessage ="Source City and destination city cannot be match.")]
        public string SelectedDestinationCity { get; set; }
       
        public IEnumerable<SelectListItem> DestinationCity { get; set; }

        [Required(ErrorMessage = "Please Select Date for travel")]
        [Display(Name = "Date")]
        public DateTime DateToTravel { get; set; }
    }
}
