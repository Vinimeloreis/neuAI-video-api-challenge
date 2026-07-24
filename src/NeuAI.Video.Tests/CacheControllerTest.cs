using NeuAI.Video.Application.Interfaces;
using NeuAI.Video.Application.Services;
using NeuAI.Video.Domain.Entities;

namespace NeuAI.Video.Tests;

public class VideoCacheServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldSaveVideo()
    {
        var repository = new FakeVideoCacheRepo();
        var service = new VideoCacheService(repository);

        var result = await service.CreateAsync("video-1", "https://video.com/aula");

        Assert.True(result);
        Assert.NotNull(repository.SavedVideo);
        Assert.Equal("video-1", repository.SavedVideo.Id);
        Assert.Equal("https://video.com/aula", repository.SavedVideo.Url);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnVideo()
    {
        var expectedVideo = new CacheVideo("video-1", "https://video.com/aula");
        var repository = new FakeVideoCacheRepo(expectedVideo);
        var service = new VideoCacheService(repository);

        var result = await service.GetByIdAsync("video-1");

        Assert.NotNull(result);
        Assert.Equal("video-1", result.Id);
        Assert.Equal("https://video.com/aula", result.Url);
    }

    private class FakeVideoCacheRepo : IVideoCacheRepo
    {
        private readonly CacheVideo? _video;

        public FakeVideoCacheRepo(CacheVideo? video = null)
        {
            _video = video;
        }

        public CacheVideo? SavedVideo { get; private set; }

        public Task<bool> SaveAsync(CacheVideo video)
        {
            SavedVideo = video;
            return Task.FromResult(true);
        }

        public Task<CacheVideo?> GetByIdAsync(string id)
        {
            return Task.FromResult(_video);
        }
    }
}