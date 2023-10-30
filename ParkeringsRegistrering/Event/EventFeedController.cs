using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ParkeringsRegistrering.Event
{
    [Route("/events")]
    public class EventFeedController : ControllerBase
    {
        private readonly IEventstore eventstore;
        public EventFeedController(IEventstore eventStore) => this.eventstore = eventStore;
        [HttpGet("")]
        public Event[] Get([FromQuery] long start, [FromQuery] long end = long.MaxValue) =>
        this.eventstore.GetEvents(start, end).ToArray();
    }
}
