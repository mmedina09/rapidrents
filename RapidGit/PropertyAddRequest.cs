using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rapid.Web.Models.Requests.Properties
{
    public class PropertyAddRequest
    {
        [Required]
        public int TypeId { get; set; }

        [Required]
        public int NumberOfUnits { get; set; }
        
        [Required]
        [Range(1700,2030)]
        public int YearBuilt { get; set; }

        public bool HasRentControl { get; set; }

        [Required]
        public string AssessorParcelNumber { get; set; }

        [Required]
        public bool HasDetached { get; set; }

    }
}
