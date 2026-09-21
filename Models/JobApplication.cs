namespace PlacementTracker.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string JobRole { get; set; }
        public string Status { get; set; } // Applied, Interview, Selected, Rejected
        public DateTime AppliedDate { get; set; }
        public string Notes { get; set; }
    }
}