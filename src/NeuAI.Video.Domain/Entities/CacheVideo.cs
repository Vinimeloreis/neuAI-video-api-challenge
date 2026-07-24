namespace NeuAI.Video.Domain.Entities;

public class CacheVideo
{
    public string Id { get; }
    public string Url { get; }

    public CacheVideo(string id, string url)
    {
        Id = id;
        Url = url;
    }
}