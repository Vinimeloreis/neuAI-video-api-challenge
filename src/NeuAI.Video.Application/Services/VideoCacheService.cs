using NeuAI.Video.Application.Interfaces;
using NeuAI.Video.Domain.Entities;

namespace NeuAI.Video.Application.Services;

public class VideoCacheService
{
    private readonly IVideoCacheRepo _repo;

    public VideoCacheService(IVideoCacheRepo repository)
    {
        _repo = repository;
    }

    public Task<bool> CreateAsync(string id, string url)
    {
        var video = new CacheVideo(id, url);
        return _repo.SaveAsync(video);
    }

    public Task<CacheVideo?> GetByIdAsync(string id)
    {
        return _repo.GetByIdAsync(id);
    }
}