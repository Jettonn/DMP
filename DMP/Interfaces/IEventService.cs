using DMP.Dtos;
using DMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMP.Interfaces
{
    public interface IEventService
    {
        Task EnrichEvent(EventDto eventDto, Event eventData);
    }
}
