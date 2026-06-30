# Giải thích toàn bộ project QLBH Take Away

Tài liệu này dùng để bạn học lại project theo đúng cách thầy có thể hỏi: hiểu nghiệp vụ, hiểu luồng frontend - backend - database, biết debug, và có thể sửa một tác vụ nhỏ trong khoảng 5 phút.

## 1. Bức tranh tổng thể

Project đang chia thành các phần chính:

- `frontend-vue`: giao diện Vue. Người dùng bấm menu, nhập form, bấm lưu/xóa/tìm kiếm. Vue gọi API C# bằng `fetch`.
- `backend-csharp`: ASP.NET Core Web API. Đây là phần của bạn. Backend nhận request từ Vue, kiểm tra dữ liệu, truy vấn SQL Server, rồi trả JSON về frontend.
- `backend-laravel`: phần PHP/Laravel để bạn cùng nhóm làm. Trong workspace hiện tại folder này chưa có file source đáng kể.
- `database`: chứa script tạo bảng và dữ liệu mẫu SQL Server.
- `docs`: tài liệu hướng dẫn.
- `_codex_analysis`: file phân tích/phụ trợ đã sinh trong quá trình đọc báo cáo, không phải source chạy chính.

Luồng chạy quan trọng nhất:

```text
Người dùng trên trình duyệt
  -> Vue page, ví dụ DoUong.vue
  -> csharpApi.js gọi fetch("http://localhost:5155/api/do-uong")
  -> DoUongController nhận request
  -> CatalogService xử lý nghiệp vụ
  -> DbConnectionFactory mở kết nối SQL Server
  -> SqlHelpers chạy SELECT/INSERT/UPDATE/DELETE
  -> SQL Server trả dữ liệu
  -> C# map dữ liệu thành DTO
  -> Controller trả JSON
  -> Vue nhận JSON và hiển thị bảng
```

Khi thầy hỏi "frontend và backend liên kết như thế nào", bạn trả lời theo luồng trên.

## 2. Database

### `database/taobang.sql`

File này tạo database và các bảng. Một số bảng quan trọng:

- `LDU`: loại đồ uống. Ví dụ cà phê, trà, đá xay.
- `DU`: đồ uống. Có khóa ngoại `ma_ldu` liên kết sang `LDU`.
- `NL`: nguyên liệu. Ví dụ sữa, đường, cà phê hạt.
- `K_H`: khách hàng.
- `NCC`: nhà cung cấp.
- `P_G_DU`: phiếu gọi đồ uống.
- `C_T_PGDU`: chi tiết phiếu gọi đồ uống.
- `HD_BDUONG`: hóa đơn bán đồ uống.
- `C_T_HDBDU`: chi tiết hóa đơn.
- `D_NLM`: đơn nguyên liệu mua.
- `C_T_DNLMUA`: chi tiết đơn nguyên liệu mua.
- `P_NH`: phiếu nhập hàng.
- `C_T_PNH`: chi tiết phiếu nhập hàng.
- `P_KK`: phiếu kiểm kê.
- `C_T_PKK`: chi tiết phiếu kiểm kê.
- `NGUOIDUNG`, `NHOMND`, `QUYEN`, `ND_NHOM`, `PHANQUYEN`: tài khoản, nhóm quyền, phân quyền.

Bạn đang phụ trách rõ nhất 3 bảng:

- `LDU`: loại đồ uống.
- `DU`: đồ uống.
- `NL`: nguyên liệu.

Quan hệ chính của phần bạn:

```text
LDU (ma_ldu)
  1 - n
DU (ma_du, ma_ldu)

NL (ma_nl)
  dùng trong các nghiệp vụ mua/nhập/kiểm kê nguyên liệu
```

### `database/taodulieu.sql`

File này thêm dữ liệu mẫu. Khi bạn chạy project mà bảng có sẵn dữ liệu, dữ liệu đó đến từ file này.

Khi demo với thầy:

- Nếu API trả danh sách đồ uống, dữ liệu lấy từ `DU` join với `LDU`.
- Nếu API trả danh sách loại đồ uống, dữ liệu lấy từ `LDU`.
- Nếu API trả danh sách nguyên liệu, dữ liệu lấy từ `NL`.

## 3. Backend C#

Backend C# nằm trong `backend-csharp`.

### `backend-csharp/backend-csharp.csproj`

Đây là file cấu hình project C#.

```xml
<TargetFramework>net8.0</TargetFramework>
```

Nghĩa là project chạy bằng .NET 8.

```xml
<Nullable>enable</Nullable>
<ImplicitUsings>enable</ImplicitUsings>
```

- `Nullable`: C# kiểm tra biến có thể null tốt hơn.
- `ImplicitUsings`: tự thêm một số namespace phổ biến.

```xml
<PackageReference Include="Microsoft.Data.SqlClient" Version="5.2.2" />
```

Package này giúp C# kết nối SQL Server.

### `backend-csharp/appsettings.json`

File cấu hình chính.

```json
"DefaultConnection": "Server=DESKTOP-392TCLG\\SQLEXPRESS01;Database=QLBH_TAKEAWAY;User Id=sa;Password=123456;TrustServerCertificate=True;Encrypt=False"
```

Đây là chuỗi kết nối SQL Server:

- `Server`: tên SQL Server instance trên máy.
- `Database`: database đang dùng.
- `User Id`: tài khoản SQL Server.
- `Password`: mật khẩu.
- `TrustServerCertificate=True;Encrypt=False`: tránh lỗi chứng chỉ khi chạy local.

```json
"DatabaseScripts": {
  "Schema": "../database/taobang.sql",
  "Seed": "../database/taodulieu.sql"
}
```

Hai đường dẫn này được `DatabaseSetupService` dùng nếu gọi API tạo lại database.

### `backend-csharp/appsettings.Development.json`

File cấu hình riêng cho môi trường development. Hiện chủ yếu cấu hình mức log:

- Log mặc định: `Information`.
- Log của ASP.NET Core: `Warning`.

### `backend-csharp/Program.cs`

Đây là điểm khởi động backend.

```csharp
var builder = WebApplication.CreateBuilder(args);
```

Tạo builder để đăng ký service và cấu hình app.

```csharp
builder.Services.AddControllers();
```

Cho phép project dùng controller kiểu `[ApiController]`.

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
```

CORS cho phép frontend Vue gọi API C#. Vì Vue chạy port khác, ví dụ `5173` hoặc `5174`, backend chạy `5155`, nếu không bật CORS thì trình duyệt sẽ chặn.

```csharp
builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CatalogService>();
builder.Services.AddScoped<SalesService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<DatabaseSetupService>();
```

Đây là Dependency Injection:

- `DbConnectionFactory`: tạo kết nối SQL.
- `AuthService`: đăng nhập.
- `CatalogService`: danh mục như đồ uống, loại đồ uống, nguyên liệu.
- `SalesService`: phiếu gọi đồ uống, hóa đơn.
- `InventoryService`: nghiệp vụ nguyên liệu.
- `ReportService`: báo cáo.
- `DatabaseSetupService`: chạy script tạo dữ liệu.

```csharp
app.UseCors("VueFrontend");
app.MapGet("/api/health", ...);
app.MapControllers();
app.Run();
```

- `UseCors`: bật chính sách CORS.
- `/api/health`: endpoint kiểm tra backend đang chạy.
- `MapControllers`: kích hoạt các route trong controller.
- `Run`: chạy web server.

Nếu thầy hỏi "backend bắt đầu từ đâu", câu trả lời là `Program.cs`.

## 4. Backend Data Layer

### `backend-csharp/Data/DbConnectionFactory.cs`

File này chuyên tạo kết nối SQL Server.

```csharp
private readonly string _connectionString;
```

Biến lưu connection string đọc từ `appsettings.json`.

```csharp
_connectionString = configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Missing DefaultConnection.");
```

Nếu thiếu connection string thì báo lỗi ngay, tránh backend chạy nhưng không có database.

```csharp
public SqlConnection Create()
{
    return new SqlConnection(_connectionString);
}
```

Tạo kết nối tới database `QLBH_TAKEAWAY`.

```csharp
public SqlConnection CreateMasterConnection()
```

Tạo kết nối tới database `master`. Hàm này dùng khi cần drop/create database từ script.

### `backend-csharp/Data/SqlHelpers.cs`

Đây là file helper để giảm lặp code khi truy vấn SQL.

```csharp
public static void AddParam(this SqlCommand command, string name, object? value)
{
    command.Parameters.AddWithValue(name, value ?? DBNull.Value);
}
```

Thêm parameter vào SQL. Dùng parameter giúp tránh SQL injection và xử lý null đúng cách.

Ví dụ:

```csharp
cmd.AddParam("@ma_du", request.MaDu);
```

Thay vì ghép chuỗi SQL nguy hiểm:

```csharp
"WHERE ma_du = '" + id + "'"
```

Các hàm đọc dữ liệu:

```csharp
GetString(...)
GetNullableString(...)
GetInt(...)
GetDecimal(...)
GetDateOnly(...)
GetTimeOnly(...)
```

Những hàm này đọc dữ liệu từ `SqlDataReader` rồi đổi về kiểu C# phù hợp.

Hàm quan trọng nhất:

```csharp
public static async Task<List<T>> QueryAsync<T>(
    SqlConnection connection,
    string sql,
    Action<SqlCommand>? bind,
    Func<SqlDataReader, T> map,
    SqlTransaction? transaction = null)
```

Ý nghĩa:

- `connection`: kết nối SQL.
- `sql`: câu SELECT.
- `bind`: đoạn thêm parameter.
- `map`: cách biến từng dòng SQL thành object C#.
- `transaction`: nếu đang chạy trong transaction thì truyền vào.

Ví dụ tư duy:

```text
Chạy SELECT
  -> đọc từng dòng
  -> map dòng đó thành DTO
  -> thêm DTO vào List
  -> trả List về service
```

Hàm ghi dữ liệu:

```csharp
ExecuteAsync(...)
```

Dùng cho `INSERT`, `UPDATE`, `DELETE`. Trả về số dòng bị ảnh hưởng.

Hàm lấy một giá trị:

```csharp
ScalarAsync<T>(...)
```

Dùng khi cần lấy 1 số hoặc 1 giá trị duy nhất, ví dụ tổng tiền.

## 5. Backend Models

Các file trong `backend-csharp/Models` định nghĩa dữ liệu vào/ra của API.

C# dùng `record` vì dữ liệu dạng DTO thường chỉ cần chứa thông tin, không cần nhiều hành vi.

### `backend-csharp/Models/CatalogModels.cs`

File này phục vụ danh mục.

```csharp
public sealed record LoaiDoUongDto(
    string MaLdu,
    string TenLoaiDoUong,
    string? MoTa);
```

DTO trả về cho frontend khi lấy loại đồ uống.

```csharp
public sealed record UpsertLoaiDoUongRequest(
    string MaLdu,
    string TenLoaiDoUong,
    string? MoTa);
```

Request frontend gửi lên khi thêm/sửa loại đồ uống. `Upsert` nghĩa là dùng chung cho thêm mới và cập nhật.

```csharp
public sealed record DoUongDto(
    string MaDu,
    string MaLdu,
    string TenLoaiDoUong,
    string TenDoUong,
    decimal DonGia);
```

DTO đồ uống có cả `TenLoaiDoUong` vì API join bảng `DU` với `LDU`.

```csharp
public sealed record NguyenLieuDto(
    string MaNl,
    string TenNguyenLieu,
    string DonViTinh);
```

DTO nguyên liệu.

File này còn có:

- `KhachHangDto`, `UpsertKhachHangRequest`.
- `NhaCungCapDto`, `UpsertNhaCungCapRequest`.
- `NguoiDungDto`.

Phần khách hàng và nhà cung cấp là phần bạn cùng nhóm có thể làm tiếp.

### `backend-csharp/Models/AuthModels.cs`

```csharp
public sealed record LoginRequest(string Username, string Password);
```

Frontend gửi username/password.

```csharp
public sealed record LoginResponse(...)
```

Backend trả thông tin người dùng, nhóm, quyền.

### `backend-csharp/Models/SalesModels.cs`

File này phục vụ nghiệp vụ bán hàng.

Nhóm phiếu gọi đồ uống:

- `PhieuGoiDoUongDto`: dữ liệu trả về, gồm thông tin phiếu và danh sách chi tiết.
- `ChiTietPhieuGoiDto`: từng dòng đồ uống trong phiếu.
- `CreatePhieuGoiRequest`: request tạo/sửa phiếu.
- `CreateChiTietPhieuGoiRequest`: chi tiết gửi lên khi tạo phiếu.

Nhóm hóa đơn:

- `HoaDonDto`: hóa đơn trả về.
- `ChiTietHoaDonDto`: chi tiết hóa đơn.
- `CreateHoaDonRequest`: request tạo hóa đơn.
- `CreateChiTietHoaDonRequest`: chi tiết đồ uống bán.

Điểm nghiệp vụ cần nhớ:

```text
Phiếu gọi đồ uống là bước khách gọi món.
Hóa đơn là bước thanh toán.
Hóa đơn có thể lấy chi tiết từ phiếu gọi đồ uống.
```

### `backend-csharp/Models/InventoryModels.cs`

File này phục vụ nghiệp vụ nguyên liệu:

- `DonNguyenLieuMuaDto`: đơn đề nghị mua nguyên liệu.
- `ChiTietDonNguyenLieuMuaDto`: từng nguyên liệu trong đơn mua.
- `PhieuNhapHangDto`: phiếu nhập khi nhà cung cấp giao hàng.
- `ChiTietPhieuNhapHangDto`: chi tiết nguyên liệu nhập.
- `PhieuKiemKeDto`: phiếu kiểm kê tồn/đếm nguyên liệu.
- `ChiTietPhieuKiemKeDto`: chi tiết kiểm kê.

Đây là nhóm nghiệp vụ liên quan trực tiếp tới phần nguyên liệu của bạn.

### `backend-csharp/Models/ReportModels.cs`

File này phục vụ báo cáo:

- `DoanhThuNgayReport`: báo cáo doanh thu theo ngày.
- `DoanhThuNgayItem`: từng dòng chi tiết trong báo cáo ngày.
- `DoUongBanChayReport`: báo cáo đồ uống bán chạy theo tháng.
- `DoUongBanChayItem`: từng đồ uống trong bảng xếp hạng.

## 6. Backend Controllers

Controller là nơi nhận HTTP request.

Mẫu chung:

```csharp
[ApiController]
[Route("api/do-uong")]
public sealed class DoUongController : ControllerBase
{
    private readonly CatalogService _service;
}
```

- `[ApiController]`: đánh dấu đây là API controller.
- `[Route("api/do-uong")]`: URL gốc của controller.
- `_service`: service xử lý logic thật.

Controller không nên viết SQL trực tiếp. Controller chỉ nhận request, gọi service, trả response.

### `backend-csharp/Controllers/CatalogControllers.cs`

File này chứa nhiều controller danh mục:

- `LoaiDoUongController`: `/api/loai-do-uong`
- `DoUongController`: `/api/do-uong`
- `NguyenLieuController`: `/api/nguyen-lieu`
- `KhachHangController`: `/api/khach-hang`
- `NhaCungCapController`: `/api/nha-cung-cap`
- `NguoiDungController`: `/api/nguoi-dung`

Ví dụ `DoUongController`:

```csharp
[HttpGet]
public async Task<ActionResult<IReadOnlyList<DoUongDto>>> GetAll([FromQuery] string? keyword)
{
    return Ok(await _service.GetDoUongAsync(keyword));
}
```

Ý nghĩa:

- Nhận request `GET /api/do-uong`.
- Nếu URL có `?keyword=...` thì nhận vào biến `keyword`.
- Gọi `CatalogService.GetDoUongAsync(keyword)`.
- Trả HTTP 200 kèm JSON.

```csharp
[HttpGet("{id}")]
public async Task<ActionResult<DoUongDto>> GetById(string id)
```

Nhận request `GET /api/do-uong/DU001`.

```csharp
[HttpPost]
public async Task<IActionResult> Create(UpsertDoUongRequest request)
```

Nhận request thêm mới từ frontend. Body JSON được map vào `UpsertDoUongRequest`.

```csharp
[HttpPut("{id}")]
public async Task<IActionResult> Update(string id, UpsertDoUongRequest request)
```

Nhận request cập nhật.

```csharp
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(string id)
```

Nhận request xóa.

Đoạn try/catch:

```csharp
try
{
    await _service.CreateDoUongAsync(request);
    return CreatedAtAction(...);
}
catch (ArgumentException ex)
{
    return BadRequest(new { message = ex.Message });
}
```

Nếu service phát hiện dữ liệu sai, ví dụ thiếu tên đồ uống, controller trả HTTP 400 để frontend hiện lỗi.

### `backend-csharp/Controllers/AuthController.cs`

Route gốc: `/api/auth`.

```csharp
[HttpPost("login")]
public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
```

Nhận request `POST /api/auth/login`. Nếu đúng tài khoản thì trả thông tin người dùng, nếu sai trả `Unauthorized`.

### `backend-csharp/Controllers/SalesControllers.cs`

File này có:

- `PhieuGoiDoUongController`: `/api/phieu-goi-do-uong`
- `HoaDonController`: `/api/hoa-don`

Các endpoint chính:

- `GET`: lấy danh sách.
- `GET /{id}`: lấy một phiếu/hóa đơn.
- `POST`: tạo mới.
- `PUT`: cập nhật phiếu gọi đồ uống.
- `DELETE`: xóa.

### `backend-csharp/Controllers/InventoryControllers.cs`

File này có:

- `DonNguyenLieuMuaController`: `/api/don-nguyen-lieu-mua`
- `PhieuNhapHangController`: `/api/phieu-nhap-hang`
- `PhieuKiemKeController`: `/api/phieu-kiem-ke`

Đây là phần bạn có thể chọn làm nghiệp vụ liên quan nguyên liệu.

Gợi ý chọn 1-2 nghiệp vụ để demo:

- Lập đơn nguyên liệu mua.
- Lập phiếu nhập hàng.
- Hoặc báo cáo/kiểm kê nguyên liệu nếu muốn nâng cao hơn.

### `backend-csharp/Controllers/ReportsController.cs`

Route gốc: `/api/bao-cao`.

```csharp
[HttpGet("doanh-thu-ngay")]
```

URL:

```text
GET /api/bao-cao/doanh-thu-ngay?ngay=2026-06-01
```

```csharp
[HttpGet("do-uong-ban-chay")]
```

URL:

```text
GET /api/bao-cao/do-uong-ban-chay?thang=6&nam=2026
```

### `backend-csharp/Controllers/DatabaseController.cs`

Route:

```text
POST /api/database/recreate
```

Controller này gọi `DatabaseSetupService` để chạy lại script tạo bảng và dữ liệu.

Lưu ý rất quan trọng: endpoint này có thể drop/tạo lại database, chỉ dùng khi bạn muốn reset dữ liệu demo.

## 7. Backend Services

Service là nơi xử lý nghiệp vụ thật.

### `backend-csharp/Services/CatalogService.cs`

Đây là file quan trọng nhất cho phần của bạn.

Constructor:

```csharp
private readonly DbConnectionFactory _db;

public CatalogService(DbConnectionFactory db)
{
    _db = db;
}
```

Service nhận `DbConnectionFactory` qua Dependency Injection để mở SQL connection.

#### Lấy danh sách loại đồ uống

```csharp
public async Task<IReadOnlyList<LoaiDoUongDto>> GetLoaiDoUongAsync(string? keyword)
```

Ý nghĩa: trả danh sách loại đồ uống, có thể tìm kiếm theo từ khóa.

```csharp
await using var connection = _db.Create();
await connection.OpenAsync();
```

Mở kết nối SQL Server.

```sql
SELECT ma_ldu, tenloaidouong, mota
FROM LDU
WHERE @keyword IS NULL
   OR ma_ldu LIKE @like
   OR tenloaidouong LIKE @like
ORDER BY ma_ldu
```

Nếu không có keyword thì lấy tất cả. Nếu có keyword thì tìm theo mã hoặc tên loại.

```csharp
reader => new LoaiDoUongDto(
    reader.GetString("ma_ldu"),
    reader.GetString("tenloaidouong"),
    reader.GetNullableString("mota"))
```

Map một dòng SQL thành object C#.

#### Thêm loại đồ uống

```csharp
public async Task CreateLoaiDoUongAsync(UpsertLoaiDoUongRequest request)
```

```csharp
EnsureRequired(request.MaLdu, nameof(request.MaLdu));
EnsureRequired(request.TenLoaiDoUong, nameof(request.TenLoaiDoUong));
```

Kiểm tra mã loại và tên loại không được rỗng.

```sql
INSERT INTO LDU (ma_ldu, tenloaidouong, mota)
VALUES (@ma_ldu, @tenloaidouong, @mota)
```

Thêm dữ liệu vào bảng `LDU`.

#### Cập nhật loại đồ uống

```csharp
public async Task<bool> UpdateLoaiDoUongAsync(string id, UpsertLoaiDoUongRequest request)
```

Chỉ cập nhật tên loại và mô tả, không đổi mã loại.

```sql
UPDATE LDU
SET tenloaidouong = @tenloaidouong,
    mota = @mota
WHERE ma_ldu = @ma_ldu
```

```csharp
return affected > 0;
```

Nếu có dòng được cập nhật thì trả `true`, không có mã đó thì trả `false`.

#### Xóa loại đồ uống

```csharp
public Task<bool> DeleteLoaiDoUongAsync(string id)
{
    return DeleteByIdAsync("DELETE FROM LDU WHERE ma_ldu = @id", id);
}
```

Gọi helper `DeleteByIdAsync`. Nếu loại đồ uống đang được đồ uống sử dụng, SQL Server có thể báo lỗi khóa ngoại.

#### Lấy danh sách đồ uống

```csharp
public async Task<IReadOnlyList<DoUongDto>> GetDoUongAsync(string? keyword)
```

SQL:

```sql
SELECT du.ma_du, du.ma_ldu, ldu.tenloaidouong, du.tendouong, du.dongia
FROM DU du
INNER JOIN LDU ldu ON ldu.ma_ldu = du.ma_ldu
WHERE @keyword IS NULL
   OR du.ma_du LIKE @like
   OR du.tendouong LIKE @like
   OR ldu.tenloaidouong LIKE @like
ORDER BY du.ma_du
```

Điểm cần nói với thầy: đồ uống join với loại đồ uống để hiển thị tên loại, không chỉ hiển thị mã loại.

#### Thêm đồ uống

```csharp
EnsureRequired(request.MaDu, nameof(request.MaDu));
EnsureRequired(request.MaLdu, nameof(request.MaLdu));
EnsureRequired(request.TenDoUong, nameof(request.TenDoUong));
EnsurePositive(request.DonGia, nameof(request.DonGia));
```

Kiểm tra mã đồ uống, mã loại, tên đồ uống và đơn giá.

```sql
INSERT INTO DU (ma_du, ma_ldu, tendouong, dongia)
VALUES (@ma_du, @ma_ldu, @tendouong, @dongia)
```

#### Cập nhật đồ uống

```sql
UPDATE DU
SET ma_ldu = @ma_ldu,
    tendouong = @tendouong,
    dongia = @dongia
WHERE ma_du = @ma_du
```

Cho phép đổi loại đồ uống, tên, đơn giá. Không đổi mã đồ uống khi sửa.

#### Nguyên liệu

Các hàm nguyên liệu giống mẫu CRUD:

- `GetNguyenLieuAsync`: SELECT từ `NL`.
- `CreateNguyenLieuAsync`: INSERT vào `NL`.
- `UpdateNguyenLieuAsync`: UPDATE `tennguyenlieu`, `donvitinh`.
- `DeleteNguyenLieuAsync`: DELETE theo `ma_nl`.

SQL lấy nguyên liệu:

```sql
SELECT ma_nl, tennguyenlieu, donvitinh
FROM NL
WHERE @keyword IS NULL
   OR ma_nl LIKE @like
   OR tennguyenlieu LIKE @like
ORDER BY ma_nl
```

#### Các helper cuối file

```csharp
private static void BindKeyword(SqlCommand cmd, string? keyword)
```

Chuẩn hóa keyword:

- Rỗng thì truyền `null`.
- Có chữ thì thêm `%keyword%` để dùng với `LIKE`.

```csharp
private static void EnsureRequired(string? value, string name)
```

Nếu chuỗi rỗng thì ném `ArgumentException`.

```csharp
private static void EnsurePositive(decimal value, string name)
```

Đơn giá không được âm.

### `backend-csharp/Services/AuthService.cs`

File này xử lý đăng nhập.

```sql
SELECT ma_nd, tennd, usr, vitri
FROM NGUOIDUNG
WHERE usr = @usr AND pwd_hash = @pwd AND trangthai = 1
```

Tìm người dùng đang hoạt động.

Sau đó lấy nhóm:

```sql
SELECT n.tennhom
FROM ND_NHOM nn
INNER JOIN NHOMND n ON n.ma_nhom = nn.ma_nhom
WHERE nn.ma_nd = @ma_nd
```

Sau đó lấy quyền:

```sql
SELECT DISTINCT q.tenquyen
FROM ND_NHOM nn
INNER JOIN PHANQUYEN pq ON pq.ma_nhom = nn.ma_nhom
INNER JOIN QUYEN q ON q.ma_quyen = pq.ma_quyen
WHERE nn.ma_nd = @ma_nd
```

Lưu ý: hiện tại mật khẩu đang so sánh trực tiếp với `pwd_hash` theo dữ liệu mẫu. Nếu thầy hỏi bảo mật, bạn nói đây là bản demo học phần; thực tế nên hash mật khẩu bằng BCrypt/ASP.NET Identity.

### `backend-csharp/Services/SalesService.cs`

File này xử lý bán hàng.

Các hàm phiếu gọi đồ uống:

- `GetPhieuGoiAsync`: lấy danh sách số phiếu, sau đó gọi `GetPhieuGoiByIdAsync` để lấy đủ header + chi tiết.
- `GetPhieuGoiByIdAsync`: lấy một phiếu.
- `CreatePhieuGoiAsync`: tạo phiếu gọi đồ uống.
- `UpdatePhieuGoiAsync`: cập nhật phiếu, xóa chi tiết cũ rồi insert chi tiết mới.
- `DeletePhieuGoiAsync`: xóa chi tiết trước, xóa header sau.

Vì sao phải dùng transaction?

```text
Một phiếu gồm header và nhiều dòng chi tiết.
Nếu insert header thành công nhưng insert chi tiết lỗi, dữ liệu sẽ bị lệch.
Transaction giúp lỗi thì rollback toàn bộ.
```

Mẫu transaction:

```csharp
await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();
try
{
    // insert/update nhiều bảng
    await transaction.CommitAsync();
}
catch
{
    await transaction.RollbackAsync();
    throw;
}
```

Các hàm hóa đơn:

- `GetHoaDonAsync`: lấy danh sách hóa đơn.
- `GetHoaDonByIdAsync`: lấy header hóa đơn và chi tiết.
- `CreateHoaDonAsync`: tạo hóa đơn.
- `DeleteHoaDonAsync`: xóa hóa đơn.

Nghiệp vụ quan trọng trong `CreateHoaDonAsync`:

```text
Nếu request có chi tiết thì dùng chi tiết đó.
Nếu request không có chi tiết thì lấy chi tiết từ phiếu gọi đồ uống.
Lấy đơn giá đồ uống từ bảng DU.
Tính thành tiền = số lượng bán * đơn giá.
Insert hóa đơn và chi tiết hóa đơn trong transaction.
```

Đây là chỗ thầy rất dễ hỏi vì nó là nghiệp vụ thật.

### `backend-csharp/Services/InventoryService.cs`

File này xử lý nghiệp vụ nguyên liệu.

Nhóm đơn nguyên liệu mua:

- `GetDonNguyenLieuMuaAsync`
- `GetDonNguyenLieuMuaByIdAsync`
- `CreateDonNguyenLieuMuaAsync`
- `DeleteDonNguyenLieuMuaAsync`

Ý nghĩa nghiệp vụ:

```text
Khi quán cần mua nguyên liệu, nhân viên lập đơn đề nghị mua.
Một đơn có nhiều nguyên liệu: mã nguyên liệu, số lượng đề nghị, đơn giá dự kiến.
```

Nhóm phiếu nhập hàng:

- `GetPhieuNhapHangAsync`
- `GetPhieuNhapHangByIdAsync`
- `CreatePhieuNhapHangAsync`
- `DeletePhieuNhapHangAsync`

Ý nghĩa nghiệp vụ:

```text
Sau khi nhà cung cấp giao hàng, nhân viên lập phiếu nhập.
Phiếu nhập ghi nhà cung cấp, đơn mua liên quan, người giao, người nhận, nguyên liệu giao.
```

Nhóm phiếu kiểm kê:

- `GetPhieuKiemKeAsync`
- `GetPhieuKiemKeByIdAsync`
- `CreatePhieuKiemKeAsync`
- `DeletePhieuKiemKeAsync`

Ý nghĩa nghiệp vụ:

```text
Kiểm kê so sánh số lượng theo sổ và số lượng thực tế.
Chênh lệch = số lượng thực tế - số lượng theo kiểm kê.
```

Đoạn tính chênh lệch:

```csharp
var chenhlech = detail.SoLuongThucTe - detail.SoLuongTheoKiemKe;
```

Nếu bạn chọn nghiệp vụ liên quan nguyên liệu để demo, mình khuyên chọn:

- Lập đơn nguyên liệu mua.
- Phiếu kiểm kê nguyên liệu.

Hai nghiệp vụ này dễ giải thích và liên quan trực tiếp bảng `NL`.

### `backend-csharp/Services/ReportService.cs`

File này xử lý báo cáo.

#### Doanh thu ngày

```csharp
public async Task<DoanhThuNgayReport> GetDoanhThuNgayAsync(DateOnly ngay)
```

SQL join:

```sql
HD_BDUONG
  -> C_T_HDBDU
  -> DU
```

Sau khi lấy chi tiết, service tính:

```csharp
items.Select(x => x.SoHoaDon).Distinct().Count()
items.Sum(x => x.SoLuongBan)
items.Sum(x => x.ThanhTien)
```

Nghĩa là:

- Tổng số hóa đơn.
- Tổng số lượng đồ uống.
- Tổng doanh thu.

#### Đồ uống bán chạy

```sql
SELECT ct.ma_du, du.tendouong,
       SUM(ct.soluongban) AS tongsoluongban,
       SUM(ct.thanhtien) AS tongdoanhthu
FROM HD_BDUONG hd
INNER JOIN C_T_HDBDU ct ON ct.so_hdbdu = hd.so_hdbdu
INNER JOIN DU du ON du.ma_du = ct.ma_du
WHERE MONTH(hd.ngaylaphoadon) = @thang
  AND YEAR(hd.ngaylaphoadon) = @nam
GROUP BY ct.ma_du, du.tendouong
ORDER BY SUM(ct.soluongban) DESC, SUM(ct.thanhtien) DESC
```

Điểm nghiệp vụ: group theo đồ uống, tính tổng số lượng bán, sắp xếp bán nhiều nhất lên đầu.

### `backend-csharp/Services/DatabaseSetupService.cs`

File này chạy script SQL.

```csharp
var batches = Regex.Split(script, @"^\s*GO\s*;?\s*$", ...)
```

SQL Server script thường tách bằng `GO`. C# không chạy nguyên file có `GO` trực tiếp được, nên phải tách thành từng batch.

```csharp
await using var connection = _db.CreateMasterConnection();
```

Dùng database `master` vì khi drop/create database thì không nên đang kết nối trực tiếp vào database bị drop.

## 8. Backend file test API

### `backend-csharp/backend-csharp.http`

File này để test API trong Visual Studio/VS Code REST Client.

Ví dụ:

```http
GET {{backend_csharp_HostAddress}}/api/health
```

Test backend có chạy không.

```http
GET {{backend_csharp_HostAddress}}/api/do-uong?keyword=ca
```

Test tìm đồ uống.

```http
POST {{backend_csharp_HostAddress}}/api/database/recreate
```

Reset database. Cẩn thận vì có thể xóa/tạo lại database.

## 9. Frontend Vue

Frontend nằm trong `frontend-vue`.

### `frontend-vue/package.json`

File khai báo project frontend.

```json
"scripts": {
  "dev": "vite",
  "build": "vite build",
  "preview": "vite preview"
}
```

Lệnh quan trọng:

- `npm run dev`: chạy frontend để demo.
- `npm run build`: kiểm tra frontend build được không.
- `npm run preview`: xem bản build.

```json
"dependencies": {
  "vue": "...",
  "vue-router": "..."
}
```

- `vue`: framework giao diện.
- `vue-router`: chuyển trang theo route.

### `frontend-vue/package-lock.json`

File khóa phiên bản dependency. Bạn không cần học từng dòng. Khi chạy `npm install`, npm dùng file này để cài đúng phiên bản package.

### `frontend-vue/vite.config.js`

File cấu hình Vite.

```js
plugins: [
  vue(),
  vueDevTools(),
]
```

Bật plugin Vue và Vue DevTools.

```js
alias: {
  '@': fileURLToPath(new URL('./src', import.meta.url)),
}
```

Cho phép import bằng `@/...` thay vì đường dẫn dài. Hiện code của mình vẫn dùng đường dẫn tương đối.

### `frontend-vue/index.html`

File HTML gốc.

```html
<div id="app"></div>
<script type="module" src="/src/main.js"></script>
```

Vue sẽ mount app vào thẻ `#app`.

### `frontend-vue/src/main.js`

Điểm khởi động frontend.

```js
import './assets/css/style.css'
```

Import CSS chung.

```js
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
```

Import Vue, component gốc, router.

```js
createApp(App)
  .use(router)
  .mount('#app')
```

Tạo app Vue, gắn router, render vào `#app`.

### `frontend-vue/src/App.vue`

Component gốc của giao diện.

```vue
<SidebarMenu />
<router-view />
```

- `SidebarMenu`: thanh menu bên trái.
- `router-view`: nơi hiển thị page hiện tại theo URL.

Ví dụ:

- URL `/do-uong` thì `router-view` hiển thị `DoUong.vue`.
- URL `/nguyen-lieu` thì hiển thị `NguyenLieu.vue`.

### `frontend-vue/src/router/index.js`

File khai báo route.

```js
import DoUong from '../pages/quanlydanhmuc/DoUong.vue'
import LoaiDoUong from '../pages/quanlydanhmuc/LoaiDoUong.vue'
import NguyenLieu from '../pages/quanlydanhmuc/NguyenLieu.vue'
```

Import các page.

```js
const routes = [
  { path: '/', component: TrangChu },
  { path: '/do-uong', component: DoUong },
  { path: '/loai-do-uong', component: LoaiDoUong },
  { path: '/nguyen-lieu', component: NguyenLieu },
  { path: '/khach-hang', component: KhachHang }
]
```

Mỗi route gồm:

- `path`: đường dẫn trên trình duyệt.
- `component`: page sẽ hiển thị.

```js
const router = createRouter({
  history: createWebHistory(),
  routes: routes
})
```

Tạo router kiểu history, URL đẹp không có `#`.

### `frontend-vue/src/components/SidebarMenu.vue`

Menu bên trái.

```vue
<router-link to="/do-uong" class="muc-con">Đồ uống</router-link>
```

`router-link` chuyển trang mà không reload trình duyệt.

Các mục của bạn:

- `/do-uong`
- `/loai-do-uong`
- `/nguyen-lieu`

Các mục nghiệp vụ hiện vẫn là thẻ `<a href="#">`, tức là chưa có page thật.

### `frontend-vue/src/assets/css/style.css`

CSS chung của giao diện.

Các class chính:

- `.khung-trang`: layout ngang gồm sidebar và nội dung.
- `.thanh-ben`: sidebar màu đỏ.
- `.noi-dung-chinh`: vùng nội dung bên phải.
- `.duong-dan`: dòng tiêu đề module.
- `.hop-noi-dung`: khung trắng chứa nội dung.
- `.tieu-de-trang`: tiêu đề giữa trang.
- `.thanh-cong-cu`: thanh tìm kiếm và nút thêm/làm mới.
- `.form-danh-muc`: form nhập liệu dạng grid.
- `.bang-du-lieu`: bảng dữ liệu.
- `.thong-bao`: thông báo thành công/lỗi.

Đoạn này làm menu đang chọn nổi bật:

```css
.muc-con.router-link-active {
  background-color: #6b000c;
  border-left: 4px solid white;
  padding-left: 31px;
}
```

Khi route hiện tại trùng với `router-link`, Vue tự thêm class `router-link-active`.

Responsive:

```css
@media (max-width: 1000px) { ... }
@media (max-width: 720px) { ... }
```

Giúp form và layout co lại khi màn hình nhỏ.

### `frontend-vue/src/api/csharpApi.js`

Đây là cầu nối giữa Vue và backend C#.

```js
const API_BASE_URL = import.meta.env.VITE_CSHARP_API_URL || 'http://localhost:5155/api'
```

Nếu có biến môi trường `VITE_CSHARP_API_URL` thì dùng biến đó. Nếu không, mặc định gọi backend C# ở `http://localhost:5155/api`.

Hàm gốc:

```js
async function request(path, options = {}) {
  response = await fetch(`${API_BASE_URL}${path}`, {
    headers: {
      'Content-Type': 'application/json',
      ...(options.headers || {})
    },
    ...options
  })
}
```

Ý nghĩa:

- Ghép base URL với path.
- Thêm header JSON.
- Gọi `fetch`.

Nếu backend không chạy, `fetch` ném lỗi. Đây là lỗi bạn từng thấy: `Failed to fetch`.

```js
if (!response.ok) {
  ...
  throw new Error(message)
}
```

Nếu backend trả lỗi HTTP như 400/404/500 thì frontend tạo lỗi để hiển thị lên màn hình.

```js
if (response.status === 204) {
  return null
}
```

HTTP 204 nghĩa là thành công nhưng không có body, thường dùng cho update/delete.

API đồ uống:

```js
getDoUong(keyword = '') {
  return request(`/do-uong${buildQuery(keyword)}`)
}

createDoUong(data) {
  return request('/do-uong', {
    method: 'POST',
    body: JSON.stringify(data)
  })
}
```

Các hàm còn lại tương tự:

- `getLoaiDoUong`, `createLoaiDoUong`, `updateLoaiDoUong`, `deleteLoaiDoUong`.
- `getDoUong`, `createDoUong`, `updateDoUong`, `deleteDoUong`.
- `getNguyenLieu`, `createNguyenLieu`, `updateNguyenLieu`, `deleteNguyenLieu`.

```js
function buildQuery(keyword) {
  const value = keyword.trim()
  return value ? `?keyword=${encodeURIComponent(value)}` : ''
}
```

Nếu ô tìm kiếm có chữ, tạo query string `?keyword=...`. Nếu rỗng thì không thêm gì.

### `frontend-vue/src/pages/quanlydanhmuc/DoUong.vue`

Đây là page CRUD đồ uống.

File Vue có 2 phần:

- `<template>`: HTML giao diện.
- `<script setup>`: JavaScript xử lý dữ liệu và gọi API.

#### Template

```vue
<input v-model="tuKhoa" type="text" placeholder="...">
<button @click="taiDuLieu">Tìm kiếm</button>
```

- `v-model="tuKhoa"`: ô input liên kết 2 chiều với biến `tuKhoa`.
- `@click="taiDuLieu"`: bấm nút thì gọi hàm tải dữ liệu.

```vue
<div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">
  {{ thongBao }}
</div>
```

Nếu có thông báo thì hiển thị. Nếu `coLoi = true` thì thêm class `loi`.

```vue
<form class="form-danh-muc" @submit.prevent="luuDuLieu">
```

Khi submit form, gọi `luuDuLieu`. `.prevent` ngăn trình duyệt reload trang.

```vue
<input v-model="form.maDu" :readonly="dangSua" maxlength="10" required>
```

Mã đồ uống:

- Thêm mới thì nhập được.
- Đang sửa thì readonly để không đổi khóa chính.

```vue
<select v-model="form.maLdu" required>
  <option v-for="loai in dsLoaiDoUong" :key="loai.maLdu" :value="loai.maLdu">
    {{ loai.maLdu }} - {{ loai.tenLoaiDoUong }}
  </option>
</select>
```

Dropdown loại đồ uống lấy từ API `/api/loai-do-uong`.

```vue
<tr v-for="du in dsDoUong" :key="du.maDu">
```

Duyệt danh sách đồ uống để hiển thị bảng.

```vue
<button class="nut-bang" @click="batDauSua(du)">Sửa</button>
<button class="nut-bang nut-xoa" @click="xoaDuLieu(du.maDu)">Xóa</button>
```

Nút sửa đưa dữ liệu lên form. Nút xóa gọi API DELETE.

#### Script

```js
import { onMounted, reactive, ref } from 'vue'
import { csharpApi } from '../../api/csharpApi'
```

- `ref`: biến reactive đơn giản.
- `reactive`: object reactive.
- `onMounted`: chạy sau khi component hiển thị lần đầu.
- `csharpApi`: file gọi backend.

```js
const dsDoUong = ref([])
const dsLoaiDoUong = ref([])
const tuKhoa = ref('')
const thongBao = ref('')
const coLoi = ref(false)
const dangSua = ref(false)
```

Các biến trạng thái của page.

```js
const form = reactive({
  maDu: '',
  maLdu: '',
  tenDoUong: '',
  donGia: 0
})
```

Object dữ liệu form. Tên field phải khớp JSON backend cần:

- `maDu` -> C# nhận vào `MaDu`.
- `maLdu` -> C# nhận vào `MaLdu`.
- `tenDoUong` -> C# nhận vào `TenDoUong`.
- `donGia` -> C# nhận vào `DonGia`.

```js
onMounted(async () => {
  await taiLoaiDoUong()
  await taiDuLieu()
})
```

Khi mở page:

1. Tải loại đồ uống để có dropdown.
2. Tải danh sách đồ uống.

```js
async function taiDuLieu() {
  dsDoUong.value = await csharpApi.getDoUong(tuKhoa.value)
}
```

Gọi API, gán kết quả vào `dsDoUong`, bảng tự cập nhật.

```js
function batDauSua(du) {
  dangSua.value = true
  ganForm(du)
}
```

Chuyển sang chế độ sửa và đưa dữ liệu dòng được chọn lên form.

```js
async function luuDuLieu() {
  const duLieu = { ...form, donGia: Number(form.donGia) }

  if (dangSua.value) {
    await csharpApi.updateDoUong(form.maDu, duLieu)
  } else {
    await csharpApi.createDoUong(duLieu)
  }
}
```

Nếu đang sửa thì gọi PUT. Nếu thêm mới thì gọi POST.

```js
async function xoaDuLieu(maDu) {
  if (!confirm(`Xóa đồ uống ${maDu}?`)) return
  await csharpApi.deleteDoUong(maDu)
}
```

Xác nhận trước khi xóa, sau đó gọi DELETE.

```js
function ganForm(du = null) {
  form.maDu = du?.maDu || ''
  form.maLdu = du?.maLdu || ''
  form.tenDoUong = du?.tenDoUong || ''
  form.donGia = du?.donGia || 0
}
```

Nếu có dữ liệu thì đổ vào form, nếu không thì reset form.

### `frontend-vue/src/pages/quanlydanhmuc/LoaiDoUong.vue`

Page này giống `DoUong.vue` nhưng đơn giản hơn vì không cần dropdown.

Dữ liệu:

```js
const form = reactive({
  maLdu: '',
  tenLoaiDoUong: '',
  moTa: ''
})
```

Các hàm chính:

- `taiDuLieu`: gọi `csharpApi.getLoaiDoUong`.
- `luuDuLieu`: nếu sửa thì gọi `updateLoaiDoUong`, nếu thêm thì gọi `createLoaiDoUong`.
- `xoaDuLieu`: gọi `deleteLoaiDoUong`.
- `ganForm`: reset hoặc đổ dữ liệu lên form.

Khi thầy hỏi code lại page danh mục, bạn có thể lấy page này làm mẫu dễ nhất.

### `frontend-vue/src/pages/quanlydanhmuc/NguyenLieu.vue`

Page này CRUD nguyên liệu.

Dữ liệu form:

```js
const form = reactive({
  maNl: '',
  tenNguyenLieu: '',
  donViTinh: ''
})
```

Các hàm:

- `taiDuLieu`: gọi `getNguyenLieu`.
- `luuDuLieu`: gọi `createNguyenLieu` hoặc `updateNguyenLieu`.
- `xoaDuLieu`: gọi `deleteNguyenLieu`.
- `ganForm`: đổ dữ liệu hoặc reset.

Mapping frontend - backend - database:

```text
form.maNl          -> C# MaNl          -> SQL ma_nl
form.tenNguyenLieu -> C# TenNguyenLieu -> SQL tennguyenlieu
form.donViTinh    -> C# DonViTinh     -> SQL donvitinh
```

### `frontend-vue/src/pages/quanlydanhmuc/KhachHang.vue`

Page này hiện đang là dữ liệu tĩnh trong frontend:

```js
const dsKhachHang = ref([
  { ma_kh: 'KH001', ... }
])
```

Nghĩa là chưa gọi backend thật như `DoUong.vue`. Phần này bạn cùng nhóm có thể sửa theo mẫu:

- Thêm API trong `csharpApi.js` hoặc API PHP.
- Gọi API trong `onMounted`.
- Thêm form CRUD.

### `frontend-vue/src/pages/TrangChu.vue`

Trang chủ đơn giản. Chỉ hiển thị tiêu đề hệ thống.

### `frontend-vue/src/assets/base.css`, `main.css`, `logo.svg`, `components/icons/*`

Đây là file mặc định khi tạo Vue project. Hiện `main.js` đang import `style.css`, nên các file này không phải trọng tâm demo. Có thể giữ lại, không ảnh hưởng nhiều.

### `frontend-vue/public/favicon.ico`

Icon nhỏ trên tab trình duyệt.

## 10. Luồng CRUD đồ uống từ đầu đến cuối

Ví dụ bạn bấm "Tìm kiếm" trong page đồ uống.

```text
DoUong.vue
  taiDuLieu()
    -> csharpApi.getDoUong(tuKhoa.value)
      -> fetch("http://localhost:5155/api/do-uong?keyword=...")
        -> DoUongController.GetAll(keyword)
          -> CatalogService.GetDoUongAsync(keyword)
            -> SELECT DU JOIN LDU
              -> map SqlDataReader thành DoUongDto
          -> Controller trả Ok(list)
      -> Vue nhận list
    -> dsDoUong.value = list
  -> table tự render lại
```

Ví dụ bạn bấm "Lưu" khi thêm đồ uống.

```text
DoUong.vue
  luuDuLieu()
    -> createDoUong(form)
      -> POST /api/do-uong body JSON
        -> DoUongController.Create(request)
          -> CatalogService.CreateDoUongAsync(request)
            -> validate dữ liệu
            -> INSERT INTO DU
          -> trả HTTP 201 Created
    -> taiDuLieu()
    -> bảng cập nhật
```

Ví dụ bạn bấm "Sửa".

```text
DoUong.vue
  batDauSua(du)
    -> dangSua = true
    -> ganForm(du)
  Người dùng sửa tên/loại/đơn giá
  luuDuLieu()
    -> updateDoUong(form.maDu, form)
      -> PUT /api/do-uong/{maDu}
        -> CatalogService.UpdateDoUongAsync
          -> UPDATE DU
```

Ví dụ bạn bấm "Xóa".

```text
DoUong.vue
  xoaDuLieu(maDu)
    -> confirm
    -> DELETE /api/do-uong/{maDu}
      -> CatalogService.DeleteDoUongAsync
        -> DELETE FROM DU WHERE ma_du = @id
```

## 11. Cách tự code lại một chức năng danh mục

Giả sử thầy yêu cầu thêm/sửa một danh mục mới.

### Bước 1: Xác định bảng SQL

Ví dụ bảng `NL`:

```text
ma_nl
tennguyenlieu
donvitinh
```

### Bước 2: Tạo model C#

Trong `Models/CatalogModels.cs`:

```csharp
public sealed record NguyenLieuDto(string MaNl, string TenNguyenLieu, string DonViTinh);
public sealed record UpsertNguyenLieuRequest(string MaNl, string TenNguyenLieu, string DonViTinh);
```

### Bước 3: Viết service

Trong `CatalogService.cs`:

- `Get...Async`
- `Create...Async`
- `Update...Async`
- `Delete...Async`

Mẫu:

```csharp
await using var connection = _db.Create();
await connection.OpenAsync();
await SqlHelpers.ExecuteAsync(connection, sql, cmd =>
{
    cmd.AddParam("@ma_nl", request.MaNl);
});
```

### Bước 4: Viết controller

Trong `CatalogControllers.cs`:

```csharp
[ApiController]
[Route("api/nguyen-lieu")]
public sealed class NguyenLieuController : ControllerBase
```

Thêm các endpoint `GET`, `POST`, `PUT`, `DELETE`.

### Bước 5: Thêm hàm API frontend

Trong `csharpApi.js`:

```js
getNguyenLieu(keyword = '') { ... }
createNguyenLieu(data) { ... }
updateNguyenLieu(id, data) { ... }
deleteNguyenLieu(id) { ... }
```

### Bước 6: Tạo page Vue

Tạo file trong `src/pages/quanlydanhmuc`.

Mẫu biến:

```js
const danhSach = ref([])
const tuKhoa = ref('')
const dangSua = ref(false)
const form = reactive({...})
```

Mẫu hàm:

- `taiDuLieu`
- `batDauThem`
- `batDauSua`
- `luuDuLieu`
- `xoaDuLieu`
- `ganForm`

### Bước 7: Thêm route

Trong `router/index.js`:

```js
import NguyenLieu from '../pages/quanlydanhmuc/NguyenLieu.vue'
{ path: '/nguyen-lieu', component: NguyenLieu }
```

### Bước 8: Thêm menu

Trong `SidebarMenu.vue`:

```vue
<router-link to="/nguyen-lieu" class="muc-con">Nguyên liệu</router-link>
```

## 12. Cách debug khi không hiện dữ liệu

Nếu frontend báo `Failed to fetch` hoặc không hiện dữ liệu, kiểm tra theo thứ tự:

### 1. Backend có chạy không

Mở:

```text
http://localhost:5155/api/health
```

Nếu không mở được, chạy:

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-csharp
dotnet run --urls http://localhost:5155
```

### 2. API có trả dữ liệu không

Mở trực tiếp:

```text
http://localhost:5155/api/do-uong
http://localhost:5155/api/loai-do-uong
http://localhost:5155/api/nguyen-lieu
```

Nếu có JSON là backend ổn.

### 3. Frontend gọi đúng port không

Frontend có thể chạy:

```text
http://127.0.0.1:5173
```

hoặc nếu 5173 bận:

```text
http://127.0.0.1:5174
```

Điều này bình thường. Backend vẫn là `5155`.

### 4. Kiểm tra Console/Network trong trình duyệt

Nhấn F12:

- Tab Console: xem lỗi JavaScript.
- Tab Network: xem request `/api/do-uong` trả status nào.

### 5. Kiểm tra tên field JSON

C# record `MaDu` khi trả JSON sẽ thành `maDu`. Vue phải dùng:

```vue
{{ du.maDu }}
```

Không dùng:

```vue
{{ du.ma_du }}
```

Trừ khi API trả đúng kiểu snake_case.

## 13. Cách demo với thầy

### Chạy backend

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-csharp
dotnet build
dotnet run --urls http://localhost:5155
```

Nói với thầy:

```text
Backend C# chạy ASP.NET Core Web API ở port 5155, kết nối SQL Server database QLBH_TAKEAWAY.
```

### Chạy frontend

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\frontend-vue
npm run dev
```

Mở URL Vite in ra, ví dụ:

```text
http://127.0.0.1:5173
```

Nếu Vite báo port bận và dùng `5174`, mở `5174`.

### Demo chức năng của bạn

Thứ tự demo hợp lý:

1. Mở Loại đồ uống.
2. Thêm một loại mới, ví dụ `LDU99`.
3. Mở Đồ uống.
4. Thêm một đồ uống thuộc loại vừa tạo.
5. Sửa đơn giá đồ uống.
6. Tìm kiếm đồ uống.
7. Xóa dữ liệu vừa thêm.
8. Mở Nguyên liệu.
9. Thêm/sửa/xóa một nguyên liệu.

Khi demo, nói rõ:

```text
Mỗi thao tác trên giao diện sẽ gọi API C#.
API C# validate dữ liệu, chạy SQL Server, rồi trả kết quả về Vue để render lại bảng.
```

## 14. Các câu thầy dễ hỏi và câu trả lời ngắn

### Vì sao project có 2 backend?

Vì yêu cầu tích hợp nhiều công nghệ. Nhóm chia backend C# và backend PHP/Laravel. Frontend Vue là giao diện chung, có thể gọi API từ cả hai backend.

### Phần C# của em làm gì?

Phần C# phụ trách API kết nối SQL Server cho danh mục đồ uống, loại đồ uống, nguyên liệu và các nghiệp vụ liên quan như đơn nguyên liệu mua, phiếu nhập, kiểm kê, hóa đơn/báo cáo nếu cần demo.

### Controller khác Service thế nào?

Controller nhận HTTP request và trả HTTP response. Service xử lý nghiệp vụ, validate, chạy SQL, tính toán.

### DTO là gì?

DTO là object trung gian dùng để nhận/trả dữ liệu API. Ví dụ `DoUongDto` trả dữ liệu đồ uống về frontend.

### Vì sao dùng parameter SQL?

Để tránh SQL injection và xử lý dữ liệu an toàn.

### Vì sao cần transaction?

Vì nghiệp vụ có nhiều bảng header/detail. Nếu một bước lỗi thì rollback toàn bộ để dữ liệu không bị lệch.

### Vì sao xóa loại đồ uống có thể lỗi?

Vì bảng `DU` đang dùng `ma_ldu`. Nếu còn đồ uống thuộc loại đó, SQL Server chặn xóa để bảo vệ khóa ngoại.

### Vì sao frontend không hiện dữ liệu?

Thường do backend chưa chạy, sai port, lỗi CORS, API trả lỗi, hoặc frontend dùng sai tên field JSON.

## 15. Bài tập 5 phút để bạn luyện

Bạn nên tự tập các sửa nhỏ này:

1. Đổi thông báo sau khi thêm đồ uống thành câu khác.
2. Thêm điều kiện không cho đơn giá bằng 0 trong `EnsurePositive(decimal value, string name)`.
3. Thêm tìm kiếm nguyên liệu theo đơn vị tính trong `GetNguyenLieuAsync`.
4. Thêm cột mô tả cho nguyên liệu nếu database có cột.
5. Đổi sắp xếp đồ uống theo tên thay vì mã.
6. Thêm nút "Hủy" reset cả thông báo.
7. Thêm endpoint `GET /api/do-uong/theo-loai/{maLdu}`.

Ví dụ bài 3, sửa SQL:

```sql
WHERE @keyword IS NULL
   OR ma_nl LIKE @like
   OR tennguyenlieu LIKE @like
   OR donvitinh LIKE @like
```

Đây là dạng sửa thầy có thể yêu cầu ngay tại lớp.

## 16. Thứ tự học khuyến nghị

1. Học `database/taobang.sql`: hiểu bảng `LDU`, `DU`, `NL`.
2. Học `CatalogModels.cs`: hiểu request/response.
3. Học `CatalogService.cs`: hiểu SELECT/INSERT/UPDATE/DELETE.
4. Học `CatalogControllers.cs`: hiểu route API.
5. Học `csharpApi.js`: hiểu Vue gọi API.
6. Học 3 page `LoaiDoUong.vue`, `DoUong.vue`, `NguyenLieu.vue`.
7. Tập debug từ Vue tới C#.
8. Sau đó mới học nghiệp vụ `InventoryService.cs` hoặc `SalesService.cs`.

Nếu bạn thuộc được luồng CRUD của `DoUong`, bạn có thể code lại được `LoaiDoUong` và `NguyenLieu` vì cùng một mẫu.
