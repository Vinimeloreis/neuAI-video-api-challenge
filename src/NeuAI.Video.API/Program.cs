using NeuAI.Video.Application.Interfaces;
using NeuAI.Video.Application.Services;
using NeuAI.Video.Infrastructure.Cache;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));
builder.Services.AddScoped<IVideoCacheRepo, RedisCache>();
builder.Services.AddScoped<VideoCacheService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();