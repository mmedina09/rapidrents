using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rapid.Web.Models.Requests.Properties
{
    public class PropertyUpdateRequest : PropertyAddRequest
    {
       [Required]
        public int Id { get; set; }
    }
}
