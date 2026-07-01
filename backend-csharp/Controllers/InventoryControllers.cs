using backend_csharp.Models;
using backend_csharp.Security;
using backend_csharp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_csharp.Controllers;

[ApiController]
[Route("api/don-nguyen-lieu-mua")]
[Authorize(Policy = AuthorizationPolicies.PurchaseOrder)]
public sealed class DonNguyenLieuMuaController : ControllerBase
{
    private readonly InventoryService _service;

    public DonNguyenLieuMuaController(InventoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        return Ok(ApiPaging.Shape(await _service.GetDonNguyenLieuMuaAsync(keyword), page, pageSize));
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
            return BadRequest(new { message = ex.Message, status = 400 });
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
            return BadRequest(new { message = ex.Message, status = 400 });
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
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpPut("{id}/trang-thai")]
    public async Task<IActionResult> UpdateTrangThai(string id, UpdateTrangThaiDonNguyenLieuMuaRequest request)
    {
        try
        {
            return await _service.UpdateTrangThaiDonNguyenLieuMuaAsync(id, request) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }
}

[ApiController]
[Route("api/phieu-nhap-hang")]
[Authorize(Policy = AuthorizationPolicies.ReceiveInventory)]
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
            return BadRequest(new { message = ex.Message, status = 400 });
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
[Authorize(Policy = AuthorizationPolicies.InventoryCheck)]
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
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return await _service.DeletePhieuKiemKeAsync(id) ? NoContent() : NotFound();
    }
}
