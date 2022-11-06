using Microsoft.AspNetCore.Mvc;

namespace AnyTopic.Api.Models
{
    public interface IApiResponse
    {
        IActionResult? ActionResult { get; set; }
    }
}
