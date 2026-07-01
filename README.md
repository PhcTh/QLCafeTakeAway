# QLBH Take Away

Hệ thống quản lý bán hàng Take Away cho mô hình quán cà phê/đồ uống, gồm frontend Vue, backend C# ASP.NET Core, backend PHP proxy và cơ sở dữ liệu SQL Server.

## Chức năng chính

- Đăng nhập bằng JWT, lưu phiên đăng nhập ở frontend.
- Phân quyền theo nhóm người dùng: phục vụ, thu ngân, pha chế, quản trị.
- Quản lý danh mục: đồ uống, loại đồ uống, nguyên liệu, khách hàng, nhà cung cấp.
- Phân trang 5 dòng/trang và bộ lọc cơ bản cho các màn hình danh mục.
- Quản lý nghiệp vụ: lập đơn nguyên liệu mua, cập nhật trạng thái, nhập hàng, kiểm kê.
- Báo cáo: doanh thu ngày, đồ uống bán chạy.
- Quản trị hệ thống: quản lý tài khoản và nhóm quyền.
- Backend PHP đóng vai trò proxy tương thích với phần Laravel/PHP và chuyển tiếp dữ liệu sang backend C#.

## Công nghệ sử dụng

| Thành phần | Công nghệ |
|---|---|
| Frontend | Vue 3, Vue Router, Vite |
| Backend chính | C# ASP.NET Core Web API |
| Backend PHP | PHP proxy API |
| Database | SQL Server |
| Xác thực | JWT, PBKDF2 password hashing |

## Cấu trúc thư mục

```text
QLBH_TAKEAWAY/
|-- backend-csharp/      # ASP.NET Core Web API
|-- backend-laravel/     # PHP proxy API
|-- database/            # Script tạo bảng và dữ liệu mẫu
|-- docs/                # Tài liệu demo, debug, giải thích code
|-- frontend-vue/        # Giao diện Vue
|-- start_demo.bat       # Chạy nhanh 3 phần backend/frontend
`-- README.md
```

## Chuẩn bị database

1. Cài SQL Server hoặc SQL Server Express.
2. Tạo database `QLBH_TAKEAWAY`.
3. Chạy lần lượt các script:

```text
database/taobang.sql
database/taodulieu.sql
```

Nếu máy khác tên SQL Server, cập nhật connection string tại:

```text
backend-csharp/appsettings.json
```

## Cách chạy nhanh

Có thể chạy toàn bộ bằng file:

```bat
start_demo.bat
```

File này sẽ mở 3 cửa sổ:

- C# API
- PHP API
- Vue frontend

Sau đó truy cập:

```text
http://127.0.0.1:5173/
```

## Cách chạy thủ công

### 1. Backend C#

```powershell
cd backend-csharp
dotnet run --urls http://localhost:5155
```

API mặc định:

```text
http://localhost:5155/api
```

### 2. Backend PHP

```powershell
cd backend-laravel
php -S 127.0.0.1:8093 -t .
```

API PHP mặc định:

```text
http://127.0.0.1:8093/api.php
```

### 3. Frontend Vue

```powershell
cd frontend-vue
npm install
npm run dev -- --host 127.0.0.1 --port 5173
```

Frontend:

```text
http://127.0.0.1:5173/
```

## Tài khoản demo

| Tài khoản | Mật khẩu | Vai trò |
|---|---|---|
| `phucvu01` | `123456` | Nhân viên phục vụ |
| `phucvu02` | `123456` | Nhân viên phục vụ |
| `thungan01` | `123456` | Nhân viên thu ngân |
| `phache01` | `123456` | Nhân viên pha chế |
| `quantri01` | `123456` | Người quản trị |

## Phân quyền chính

| Nhóm | Quyền chính |
|---|---|
| Nhân viên phục vụ | Lập phiếu gọi đồ uống, cập nhật trạng thái phục vụ |
| Nhân viên thu ngân | Lập hóa đơn, lập đơn nguyên liệu mua, xem báo cáo |
| Nhân viên pha chế | Cập nhật menu, nhập hàng, kiểm kê |
| Người quản trị | Toàn bộ quyền trong hệ thống |

## Tài liệu thêm

Một số tài liệu trong thư mục `docs/`:

- `docs/demo_full_project.md`: hướng dẫn demo toàn bộ project.
- `docs/project_code_walkthrough.md`: giải thích luồng code chính.
- `docs/csharp_backend_guide.md`: hướng dẫn backend C#.
- `docs/offline_preflight_check.md`: checklist kiểm tra trước khi demo.

## Ghi chú

Project dùng dữ liệu mẫu để phục vụ học tập và demo. Khi chạy trên máy khác, cần kiểm tra lại SQL Server, connection string, port backend và biến môi trường frontend nếu có thay đổi.
