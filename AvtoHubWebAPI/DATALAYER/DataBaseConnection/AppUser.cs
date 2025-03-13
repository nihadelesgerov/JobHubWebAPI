using JobHubWebAPI.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobHubWebAPI.DataLayer.DataBaseConnection
{
    public class AppUser : IdentityUser
    {
        //navigation properties
        public Company CompanyProfile { get; set; }
        public string RefreshToken { get; set;}
    }
}
