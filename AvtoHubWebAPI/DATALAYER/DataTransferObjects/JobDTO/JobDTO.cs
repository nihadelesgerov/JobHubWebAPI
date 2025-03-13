namespace JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO
{
    // JobDTO is used for Entity Framework Performance tuning when we use filtering and sorting
    // I want EF Core don't filter/sort anything after server side loading done ( don't play with data in client )
    public class JobDTO
    {
        public int JobId { get; set; }
        public string Title { get; set; } 
        public int Salary { get; set;}
        public DateTime JobPostedAt { get; set; }
        public string Location { get; set; }
        public string CompanyName { get; set; }
    }
}
