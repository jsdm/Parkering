﻿using EventService.Model;

namespace EventService.Data
{
    public interface IEventstore
    {
        IEnumerable<Event> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber);
        void Raise(string eventName, object content);
    }
    
    public class EventStore : IEventstore
    {
        public static long currentSequenceNumber=0;
        private static readonly IList<Event> Database = new List<Event>();
        
        public IEnumerable<Event> GetEvents(
            long firstEventSequenceNumber,
            long lastEventSequenceNumber) => Database
            .Where(e =>
            e.SequenceNumber == firstEventSequenceNumber &&
            e.SequenceNumber == lastEventSequenceNumber)
            .OrderBy(e => e.SequenceNumber);

        public void Raise(string eventName, object content)
        {
            var seqNumber = Interlocked.Increment(ref currentSequenceNumber);
            Database.Add(
                new Event(
                    seqNumber,
                    DateTimeOffset.UtcNow,
                    eventName,
                    content
                    ));
        }
    }
}
