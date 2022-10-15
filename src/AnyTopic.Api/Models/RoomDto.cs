using System.Text.Json.Serialization;

namespace AnyTopic.Api.Models
{
    public class RoomDto
    {
        [JsonPropertyName("roomId")]
        public int Id { get; set; }

        [JsonPropertyName("roomName")]
        public string? Name { get; set; }

        [JsonPropertyName("roomAdminId")]
        public int AdminId { get; set; }
    }
}
