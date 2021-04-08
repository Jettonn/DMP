using System;
using System.ComponentModel.DataAnnotations;
namespace DMP.Models
{
    public class Organization
    {
        [Key]
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationInformation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}