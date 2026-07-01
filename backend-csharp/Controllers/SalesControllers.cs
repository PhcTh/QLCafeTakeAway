using backend_csharp.Models;
using backend_csharp.Security;
using backend_csharp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_csharp.Controllers;

[ApiController]
[Route("api/phieu-goi-do-uong")]
[Authorize(Policy = AuthorizationPolicies.CreateDrinkOrder)]
public sealed class PhieuGoiDoUongController : ControllerBase
{
    private readonly SalesService _service;

    public PhieuGoiDoUongController(SalesService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PhieuGoiDoUongDto>>> GetAll([FromQuery] string? keyword)
    {
        return Ok(await _service.GetPhieuGoiAsync(keyword));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PhieuGoiDoUongDto>> GetById(string id)
    {
        var item = await _service.GetPhieuGoiByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePhieuGoiRequest request)
    {
        try
        {
            await _service.CreatePhieuGoiAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.SoPgdu }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, CreatePhieuGoiRequest request)
    {
        try
        {
            return await _service.UpdatePhieuGoiAsync(id, request) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return await _service.DeletePhieuGoiAsync(id) ? NoContent() : NotFound();
    }
}

[ApiController]
[Route("api/hoa-don")]
[Authorize(Policy = AuthorizationPolicies.CreateInvoice)]
public sealed class HoaDonController : ControllerBase
{
    private readonly SalesService _service;

    public HoaDonController(SalesService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<HoaDonDto>>> GetAll([FromQuery] string? keyword)
    {
        return Ok(await _service.GetHoaDonAsync(keyword));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HoaDonDto>> GetById(string id)
    {
        var item = await _service.GetHoaDonByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHoaDonRequest request)
    {
        try
        {
            await _service.CreateHoaDonAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.SoHdbdu }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return await _service.DeleteHoaDonAsync(id) ? NoContent() : NotFound();
    }
}

 