using JobHubWebAPI.DataLayer.Entities;

namespace JobHubWebAPI.DataLayer.DataTransferObjects
{
    public class JobDTOItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public int Salary { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;
        public DateTime ApplicationDeadline { get; set; }

        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
    }
}
