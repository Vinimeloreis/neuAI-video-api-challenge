using Microsoft.AspNetCore.Mvc;
using NeuAI.Video.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class CacheController : ControllerBase
{
    private readonly VideoCacheService _service;

    public CacheController(VideoCacheService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateVideo([FromBody] VideoRequest request)
    {
        try
        {
            var createdVideo = await _service.CreateAsync(request.Id, request.Url);

            if (!createdVideo)
                return StatusCode(500, "Erro ao salvar vídeo no cache");

            return Ok(new
            {
                status = "Criado com sucesso",
                id = request.Id,
                url = request.Url
            });
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro de conexão ao salvar, tente novamente");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVideo(string id)
    {
        try
        {
            var video = await _service.GetByIdAsync(id);

            if (video is null)
                return NotFound();

            return Ok(new
            {
                id = video.Id,
                url = video.Url
            });
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro de conexão ao buscar dado");
        }
    }
}