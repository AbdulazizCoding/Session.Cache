using Microsoft.AspNetCore.Mvc;

namespace Session.Cashe.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : Controller
{
    public string SessionKey = ".request.count";
    
    [HttpPost]
    public IActionResult SetSession()
    {
        int.TryParse(HttpContext.Session.GetString(SessionKey), out var Counter);
        HttpContext.Session.SetString(SessionKey, $"{++Counter}");
        return Accepted();
    }
}