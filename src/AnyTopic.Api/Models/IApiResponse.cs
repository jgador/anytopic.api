using Microsoft.AspNetCore.Mvc;

namespace AnyTopic.Api.Models
{
    public interface IApiResponse
    {
        JsonResult? JsonResult { get; set; }
    }
}
