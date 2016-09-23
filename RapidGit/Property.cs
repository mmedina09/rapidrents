namespace Rapid.Web.Domain
{
    public class Property
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int? NumberOfUnits { get; set; }
        public int? YearBuilt { get; set; } 
        public bool? HasRentControl { get; set; }
        public string AssessorParcelNumber { get; set; }
        public bool? HasDetached { get; set; }
    }
}
