using System.Buffers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Session.Cashe.Controllers;

[ApiController]
[Route("[controller]")]
public class CacheController : Controller
{
    private readonly IMemoryCache _memoryCache;

    public CacheController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public IActionResult GetOrCreateCache()
    {
        var cacheResult = _memoryCache.GetOrCreate("currentTime", entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(10);
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
            return DateTime.UtcNow;
        });
        return Accepted(cacheResult);
    }
}