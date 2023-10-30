namespace ParkeringsRegistrering.Event
{
    public record Event(
        long SequenceNumber,
        DateTimeOffset OccuredAt,
        string name,
        object Content);
}
