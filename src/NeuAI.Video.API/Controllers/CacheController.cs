using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CacheController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateVideo([FromBody]VideoRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id}")]
    public IActionResult GetVideo(string id)
    {
        return Ok(id);
    }
}