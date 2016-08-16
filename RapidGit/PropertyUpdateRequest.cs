using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests.Properties
{
    public class PropertyUpdateRequest : PropertyAddRequest
    {
       [Required]
        public int Id { get; set; }
    }
}