using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;


[ApiController]
[Route("api/[controller]")]
public class CacheController : ControllerBase
{
    private readonly IDatabase _db;
    
    

    public CacheController(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    [HttpPost]
    public async Task<IActionResult> CreateVideo([FromBody]VideoRequest request)
    {
       
        try
        {
            var sequence = await _db.StringIncrementAsync("video:sequence");
            var id = $"video-{sequence:D3}";
            var createdVideo = await _db.StringSetAsync(id, request.Url);
            if(!createdVideo) return StatusCode(500, "Erro ao salvar vídeo no cache");
            return Ok(new
            {
                status = "Criado com sucesso",
                id = id,
            });
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Erro de conexão ao salvar, tente novamente");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVideo(string id)
    {
        try
        {
            var value = await _db.StringGetAsync(id);
            if(value.IsNullOrEmpty) return NotFound();
            return Ok(new{
                id = id,
                Url = value.ToString()
            }); 
        }
        catch (System.Exception)
        {
           return StatusCode(500, "Erro de conexão ao buscar dado");
        }
    }
}