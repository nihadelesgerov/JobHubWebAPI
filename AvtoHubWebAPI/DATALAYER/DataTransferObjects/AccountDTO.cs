using JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO;
using JobHubWebAPI.DataLayer.Entities;

namespace JobHubWebAPI.DATALAYER.DataTransferObjects
{
    public class AccountDTO
    {
        public string Id{ get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public string CompanyPhoneAdress { get; set; }
        public string CompanyEmailAdress { get; set; }
        public string CompanyDescription{ get; set; }
        public ICollection<Job> JobsOfCompany{ get; set; }
    }
}
