using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rapid.Web.Domain
{
    public class MaintenanceRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Unit_No { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int UrgencyId { get; set; }
        

        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public int Status { get; set; }

        public int AddressId { get; set; }
    }
}
