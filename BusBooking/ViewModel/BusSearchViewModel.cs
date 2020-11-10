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
        [Required]
        [Display(Name = "From")]
        public string SelectedSourceCity { get; set; }
        public IEnumerable<SelectListItem> SourceCity { get; set; }


        [Required]
        [Display(Name = "To")]
        public string SelectedDestinationCity { get; set; }
        public IEnumerable<SelectListItem> DestinationCity { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime? DateToTravel { get; set; }
    }
}
