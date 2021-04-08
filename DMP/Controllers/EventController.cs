using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DMP.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DMP.Interfaces;
using DMP.Dtos;
using System.Threading.Tasks;

namespace DMP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private MyContext myContext;
        private IEventService iEventService;
        public EventController(MyContext _myContext, IEventService _iEventService)
        {
            myContext = _myContext;
            iEventService = _iEventService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Event> events = myContext.Events.ToList();
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventDto eventDto)
        {
            Event eventData = new Event();
            await iEventService.EnrichEvent(eventDto, eventData);
            var addedEvent = myContext.Events.Add(eventData);
            myContext.SaveChanges();
            return Ok(addedEvent.Entity);
        }
    }
}