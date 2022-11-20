using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnyTopic.Api.Models
{
    public interface IWriteDto<TDto>
        where TDto : IWriteDto<TDto>
    {
        [JsonIgnore]
        TDto Dto { get => (TDto)this; }
    }
}
