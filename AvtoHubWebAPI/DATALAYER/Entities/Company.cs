using JobHubWebAPI.DataLayer.DataBaseConnection;
using System.ComponentModel.DataAnnotations;

namespace JobHubWebAPI.DataLayer.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Company Name is required.")]
        [StringLength(100, ErrorMessage = "Company Name cannot exceed 100 characters.")]
        public string? CompanyName { get; set; } = string.Empty;

        public string? CompanyAdress { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? CompanyPhoneAdress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string CompanyEmailAdress { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "CompanyDescription cannot exceed 500 characters.")]
        public string? CompanyDescription { get; set; } = string.Empty;
        
        public ICollection<Job> JobsList { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        // there will be second relation from AppUser => Company => Job :)
    }
}
