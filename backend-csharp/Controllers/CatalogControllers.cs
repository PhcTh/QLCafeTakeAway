using backend_csharp.Models;
using backend_csharp.Security;
using backend_csharp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_csharp.Controllers;

[ApiController] // Đánh dấu đây là API controller, giúp ASP.NET Core tự động xử lý các yêu cầu HTTP và trả về dữ liệu JSON
[Route("api/loai-do-uong")] // url gốc của controller
[Authorize]
public sealed class LoaiDoUongController : ControllerBase
{
    private readonly CatalogService _service; //service để gọi các hàm xử lý nghiệp vụ

    public LoaiDoUongController(CatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        return Ok(ApiPaging.Shape(await _service.GetLoaiDoUongAsync(keyword), page, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LoaiDoUongDto>> GetById(string id)
    {
        var item = await _service.GetLoaiDoUongByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Create(UpsertLoaiDoUongRequest request)
    {
        try
        {
            await _service.CreateLoaiDoUongAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.MaLdu }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpPut("{id}")]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Update(string id, UpsertLoaiDoUongRequest request)
    {
        try
        {
            return await _service.UpdateLoaiDoUongAsync(id, request) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            return await _service.DeleteLoaiDoUongAsync(id) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }
}

[ApiController]
[Route("api/do-uong")]
[Authorize]
public sealed class DoUongController : ControllerBase
{
    private readonly CatalogService _service;

    public DoUongController(CatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        return Ok(ApiPaging.Shape(await _service.GetDoUongAsync(keyword), page, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoUongDto>> GetById(string id)
    {
        var item = await _service.GetDoUongByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Create(UpsertDoUongRequest request)
    {
        try
        {
            await _service.CreateDoUongAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.MaDu }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpPut("{id}")]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Update(string id, UpsertDoUongRequest request)
    {
        try
        {
            return await _service.UpdateDoUongAsync(id, request) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            return await _service.DeleteDoUongAsync(id) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }
}

[ApiController]
[Route("api/nguyen-lieu")]
[Authorize]
public sealed class NguyenLieuController : ControllerBase
{
    private readonly CatalogService _service;

    public NguyenLieuController(CatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        return Ok(ApiPaging.Shape(await _service.GetNguyenLieuAsync(keyword), page, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NguyenLieuDto>> GetById(string id)
    {
        var item = (await _service.GetNguyenLieuAsync(id)).FirstOrDefault(x => x.MaNl == id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Create(UpsertNguyenLieuRequest request)
    {
        try
        {
            await _service.CreateNguyenLieuAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.MaNl }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpPut("{id}")]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Update(string id, UpsertNguyenLieuRequest request)
    {
        try
        {
            return await _service.UpdateNguyenLieuAsync(id, request) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = AuthorizationPolicies.ManageCatalog)]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            return await _service.DeleteNguyenLieuAsync(id) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }
}

[ApiController]
[Route("api/khach-hang")]
[Authorize]
public sealed class KhachHangController : ControllerBase
{
    private readonly CatalogService _service;

    public KhachHangController(CatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        return Ok(ApiPaging.Shape(await _service.GetKhachHangAsync(keyword), page, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<KhachHangDto>> GetById(string id)
    {
        var item = (await _service.GetKhachHangAsync(id)).FirstOrDefault(x => x.MaKh == id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UpsertKhachHangRequest request)
    {
        try
        {
            await _service.CreateKhachHangAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.MaKh }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpsertKhachHangRequest request)
    {
        try
        {
            return await _service.UpdateKhachHangAsync(id, request) ? NoContent() : NotFound();
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
            return await _service.DeleteKhachHangAsync(id) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }
}

[ApiController]
[Route("api/nha-cung-cap")]
[Authorize]
public sealed class NhaCungCapController : ControllerBase
{
    private readonly CatalogService _service;

    public NhaCungCapController(CatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        return Ok(ApiPaging.Shape(await _service.GetNhaCungCapAsync(keyword), page, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NhaCungCapDto>> GetById(string id)
    {
        var item = (await _service.GetNhaCungCapAsync(id)).FirstOrDefault(x => x.MaNcc == id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UpsertNhaCungCapRequest request)
    {
        try
        {
            await _service.CreateNhaCungCapAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.MaNcc }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpsertNhaCungCapRequest request)
    {
        try
        {
            return await _service.UpdateNhaCungCapAsync(id, request) ? NoContent() : NotFound();
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
            return await _service.DeleteNhaCungCapAsync(id) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }
}

[ApiController]
[Route("api/nguoi-dung")]
[Authorize(Policy = AuthorizationPolicies.AdminOnly)]
public sealed class NguoiDungController : ControllerBase
{
    private readonly CatalogService _service;

    public NguoiDungController(CatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] int? page, [FromQuery] int? pageSize)
    {
        return Ok(ApiPaging.Shape(await _service.GetNguoiDungAsync(keyword), page, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NguoiDungDto>> GetById(string id)
    {
        var item = (await _service.GetNguoiDungAsync(id)).FirstOrDefault(x => x.MaNd == id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UpsertNguoiDungRequest request)
    {
        try
        {
            await _service.CreateNguoiDungAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.MaNd }, request);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpsertNguoiDungRequest request)
    {
        try
        {
            return await _service.UpdateNguoiDungAsync(id, request) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message, status = 400 });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return await _service.DeleteNguoiDungAsync(id) ? NoContent() : NotFound();
    }
}

[ApiController]
[Route("api/nhom-nguoi-dung")]
[Authorize(Policy = AuthorizationPolicies.AdminOnly)]
public sealed class NhomNguoiDungController : ControllerBase
{
    private readonly CatalogService _service;

    public NhomNguoiDungController(CatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<NhomNguoiDungDto>>> GetAll([FromQuery] string? keyword)
    {
        return Ok(await _service.GetNhomNguoiDungAsync(keyword));
    }
}

internal static class ApiPaging
{
    public static object Shape<T>(IReadOnlyList<T> items, int? page, int? pageSize)
    {
        return page.HasValue || pageSize.HasValue
            ? Pagination.Create(items, page ?? 1, pageSize ?? 10)
            : items;
    }
}
