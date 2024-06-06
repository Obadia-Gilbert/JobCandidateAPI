using System;
using System.ComponentModel.DataAnnotations;

namespace JobCandidateHubAPI.Model
{
	public class Candidate
	{
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [EnumDataType(typeof(CallTimeInterval))]
        public string CallTimeInterval { get; set; }

        [Url]
        public string LinkedInProfileUrl { get; set; }

        [Url]
        public string GitHubProfileUrl { get; set; }

        [Required]
        public string Comments { get; set; }
        
    }


    public enum CallTimeInterval
    {
        Morning,
        Afternoon,
        Evening
    }
}

