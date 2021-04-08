using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DMP.Models
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        public string EventType { get; set; }
        public string ContentID { get; set; }
        public string ContentName { get; set; }
        public string ContentType { get; set; }
        public string ContentDescription { get; set; }
        public string ContentImage { get; set; }
        public string ContentValue { get; set; }
        public string ContentAuthor { get; set; }
        public string UserId { get; set; }
        public Guid UserDmpId { get; set; }
        public Guid OrganizationId { get; set; }
        public string PageDomain { get; set; }
        public string PageUrl { get; set; }
        public string PageReferrer { get; set; }
        public string PageSource { get; set; }
        public DateTime ClientDateTime { get; set; }
        public DateTime ClientDateTimeUTC { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public string DeviceType { get; set; }
        public string DeviceFamily { get; set; }
        public string DeviceOperatingSystem { get; set; }
        public string DeviceOperatingSystemVersion { get; set; }
        public string DeviceLanguage { get; set; }
        public string DeviceScreenResolution { get; set; }
        public string IpAddress { get; set; }
        public string Country { get; set; }
        public int Asn { get; set; }
        public string Aso { get; set; }
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
    }
}
