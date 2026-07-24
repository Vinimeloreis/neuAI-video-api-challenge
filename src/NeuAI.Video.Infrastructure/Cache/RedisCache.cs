using NeuAI.Video.Application.Interfaces;
using NeuAI.Video.Domain.Entities;
using StackExchange.Redis;

namespace NeuAI.Video.Infrastructure.Cache;

public class RedisCache : IVideoCacheRepo
{
    private readonly IDatabase _db;

    public RedisCache(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public Task<bool> SaveAsync(CacheVideo video)
    {
        return _db.StringSetAsync(video.Id, video.Url);
    }

    public async Task<CacheVideo?> GetByIdAsync(string id)
    {
        var value = await _db.StringGetAsync(id);

        if (value.IsNullOrEmpty)
            return null;

        return new CacheVideo(id, value.ToString());
    }
}