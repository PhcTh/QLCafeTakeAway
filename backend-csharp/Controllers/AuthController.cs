using backend_csharp.Models;
using backend_csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_csharp.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly AuthService _service;

    public AuthController(AuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var result = await _service.LoginAsync(request);
        return result is null ? Unauthorized(new { message = "Tên đăng nhập hoặc mật khẩu không đúng." }) : Ok(result);
    }
}
