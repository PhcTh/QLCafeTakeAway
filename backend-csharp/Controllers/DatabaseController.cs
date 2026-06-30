using backend_csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_csharp.Controllers;

[ApiController]
[Route("api/database")]
public sealed class DatabaseController : ControllerBase
{
    private readonly DatabaseSetupService _service;

    public DatabaseController(DatabaseSetupService service)
    {
        _service = service;
    }

    [HttpPost("recreate")]
    public async Task<IActionResult> Recreate()
    {
        var executed = await _service.RecreateAndSeedAsync();
        return Ok(new
        {
            message = "Database QLBH_TAKEAWAY was recreated and seeded.",
            executed
        });
    }
}
