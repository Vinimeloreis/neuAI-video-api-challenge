using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VideoController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateVideo([FromBody]VideoRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id}")]
    public IActionResult GetVideo(string id)
    {
        return Ok();
    }
}