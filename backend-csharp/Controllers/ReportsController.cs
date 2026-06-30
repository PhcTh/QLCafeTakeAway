using backend_csharp.Models;
using backend_csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_csharp.Controllers;

[ApiController]
[Route("api/bao-cao")]
public sealed class ReportsController : ControllerBase
{
    private readonly ReportService _service;

    public ReportsController(ReportService service)
    {
        _service = service;
    }

    [HttpGet("doanh-thu-ngay")]
    public async Task<ActionResult<DoanhThuNgayReport>> GetDoanhThuNgay([FromQuery] DateOnly ngay)
    {
        return Ok(await _service.GetDoanhThuNgayAsync(ngay));
    }

    [HttpGet("do-uong-ban-chay")]
    public async Task<ActionResult<DoUongBanChayReport>> GetDoUongBanChay([FromQuery] int thang, [FromQuery] int nam)
    {
        try
        {
            return Ok(await _service.GetDoUongBanChayAsync(thang, nam));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
