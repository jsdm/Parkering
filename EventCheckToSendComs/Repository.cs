using System.Text.Json.Serialization;

namespace EventCheckToSendComs
{
    public record class Repository(
    [property: JsonPropertyName("name")] string Name);
}
