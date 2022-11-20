using System.Text.Json.Serialization;

namespace AnyTopic.Api.Models
{
    public class NewRoomDto : IWriteDto<NewRoomDto>
    {
        [JsonPropertyName("roomName")]
        public string? Name { get; set; }
    }
}
