using DMP.Dtos;
using DMP.Enrichers;
using DMP.Interfaces;
using DMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMP.Services
{
    public class EventService : IEventService
    {
        public async Task EnrichEvent(EventDto eventDto, Event eventData)
        {
            eventData.EventType = eventDto.EventType;
            eventData.ContentID = eventDto.ContentID;
            eventData.ContentName = eventDto.ContentName;
            eventData.ContentType = eventDto.ContentType;
            eventData.ContentDescription = eventDto.ContentDescription;
            eventData.ContentImage = eventDto.ContentImage;
            eventData.ContentValue = eventDto.ContentValue;
            eventData.ContentAuthor = eventDto.ContentAuthor;
            eventData.UserId = eventDto.UserId;
            eventData.UserDmpId = eventDto.UserDmpId;
            eventData.OrganizationId = eventDto.OrganizationId;
            eventData.PageDomain = DomainParser.DomainParseFromURL(eventDto.Url);
            eventData.PageUrl = eventDto.Url;
            eventData.PageReferrer = DomainParser.DomainParseFromURL(eventDto.Referrer);
            eventData.PageSource = eventDto.Referrer;
            eventData.ClientDateTime = eventDto.ClientDateTime;
            eventData.ClientDateTimeUTC = eventDto.ClientDateTimeUTC;
            eventData.DeviceLanguage = eventDto.DeviceLanguage;
            eventData.DeviceScreenResolution = eventDto.DeviceScreenResolution;
            eventData.IpAddress = eventDto.IpAddress;
            UserAgentInfo.UserAgent(eventDto, eventData);
            await GeoLocation.GeoLocationInfo(eventDto, eventData);
        }
    }
}
