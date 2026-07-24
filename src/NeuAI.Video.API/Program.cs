using NeuAI.Video.Application.Interfaces;
using NeuAI.Video.Application.Services;
using NeuAI.Video.Infrastructure.Cache;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));
builder.Services.AddScoped<IVideoCacheRepo, RedisCache>();
builder.Services.AddScoped<VideoCacheService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();