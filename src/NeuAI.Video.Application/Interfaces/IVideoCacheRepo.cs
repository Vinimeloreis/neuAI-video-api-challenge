using NeuAI.Video.Domain.Entities;

namespace NeuAI.Video.Application.Interfaces;

public interface IVideoCacheRepo
{
    Task<bool> SaveAsync(CacheVideo video);
    Task<CacheVideo?> GetByIdAsync(string id);
}