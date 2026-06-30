using backend_csharp.Models;
using backend_csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_csharp.Controllers;

[ApiController]
[Route("api/don-nguyen-lieu-mua")]
public sealed class DonNguyenLieuMuaController : ControllerBase
{
    private readonly InventoryService _service;

    public DonNguyenLieuMuaController(InventoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DonNguyenLieuMuaDto>>> GetAll([FromQuery] string? keyword)
    {
        return Ok(await _service.GetDonNguyenLieuMuaAsync(keyword));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DonNguyenLieuMuaDto>> GetById(string id)
    {
        var item = await _service.GetDonNguyenLieuMuaByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDonNguyenLieuMuaRequest request)
    {
        try
        {
            await _service.CreateDonNguyenLieuMuaAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.SoDnlm }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, CreateDonNguyenLieuMuaRequest request)
    {
        try
        {
            return await _service.UpdateDonNguyenLieuMuaAsync(id, request) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            return await _service.DeleteDonNguyenLieuMuaAsync(id) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

[ApiController]
[Route("api/phieu-nhap-hang")]
public sealed class PhieuNhapHangController : ControllerBase
{
    private readonly InventoryService _service;

    public PhieuNhapHangController(InventoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PhieuNhapHangDto>>> GetAll([FromQuery] string? keyword)
    {
        return Ok(await _service.GetPhieuNhapHangAsync(keyword));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PhieuNhapHangDto>> GetById(string id)
    {
        var item = await _service.GetPhieuNhapHangByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePhieuNhapHangRequest request)
    {
        try
        {
            await _service.CreatePhieuNhapHangAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.SoPnh }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return await _service.DeletePhieuNhapHangAsync(id) ? NoContent() : NotFound();
    }
}

[ApiController]
[Route("api/phieu-kiem-ke")]
public sealed class PhieuKiemKeController : ControllerBase
{
    private readonly InventoryService _service;

    public PhieuKiemKeController(InventoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PhieuKiemKeDto>>> GetAll([FromQuery] string? keyword)
    {
        return Ok(await _service.GetPhieuKiemKeAsync(keyword));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PhieuKiemKeDto>> GetById(string id)
    {
        var item = await _service.GetPhieuKiemKeByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePhieuKiemKeRequest request)
    {
        try
        {
            await _service.CreatePhieuKiemKeAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.SoPkk }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return await _service.DeletePhieuKiemKeAsync(id) ? NoContent() : NotFound();
    }
}
