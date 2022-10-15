using System.Text.Json.Serialization;

namespace AnyTopic.Api.Models
{
    public class NewRoomDto
    {
        [JsonPropertyName("roomName")]
        public string? Name { get; set; }
    }
}
