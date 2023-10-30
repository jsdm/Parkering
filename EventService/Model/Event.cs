namespace EventService.Model
{
    public record Event(
        long SequenceNumber,
        DateTimeOffset OccuredAt,
        string name,
        object Content);
}
