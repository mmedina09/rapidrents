using System;
using System.ComponentModel.DataAnnotations;

namespace Sabio.Web.Models.Requests.Properties
{
    public class AddImportedProperties
    {
        
        public string Apn { get; set; }

        
        public DateTime RegisteredDate { get; set; }

        
        public string PropertyType { get; set; }

        
        public string PropertyAddress { get; set; }

        
        public string PropertyCity { get; set; }

        
        public string PropertyState { get; set;}

        
        public int? PropertyZip { get; set; }

        
        public int? CouncilDistrict { get; set; }

        
        public string Lender { get; set; }

        
        public string LenderContact { get; set; }


        
        public string LenderContactPhone { get; set; }

       
        public string PropertyManagement { get; set; }

        
        public string PropertyManagementContact { get; set; }

        
        public string PropertyManagementAddress { get; set; }

        
        public string PropertyMgmtContactPhone { get; set; }





    }
}