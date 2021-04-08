using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMP.Dtos
{
    public class EventDto
    {
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
        public DateTime ClientDateTime { get; set; }
        public DateTime ClientDateTimeUTC { get; set; }
        public string Url { get; set; }
        public string Referrer { get; set; }
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
        public string DeviceLanguage { get; set; }
        public string DeviceScreenResolution { get; set; }
    }
}
