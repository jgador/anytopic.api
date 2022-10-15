using AnyTopic.Api.Models;
using AnyTopic.Data.Entities;
using EntityToDto;

namespace AnyTopic.Api.Mapping
{
    public class RoomMapper : DtoMapVisitor<RoomDto, Room>
    {
        public override void Visit(IdentityMap<RoomDto, Room> map)
        {
            map.Dto.Id = map.Entity.Id;
        }

        public override void Visit(PrimitiveMap<RoomDto, Room> map)
        {
            map.Dto.Name = map.Entity.Name;
            map.Dto.AdminId = map.Entity.AdminId;
        }

        public override void Visit(ComplexTypeMap<RoomDto, Room> map)
        {
        }
    }
}
