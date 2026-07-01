# Backend PHP - QLBH Take Away

Folder này là backend PHP tối giản để đáp ứng yêu cầu project có 02 backend khác nhau.

- C# backend: đồ uống, loại đồ uống, nguyên liệu, nghiệp vụ và báo cáo.
- PHP backend: khách hàng và nhà cung cấp.

## Cách chạy nhanh để demo

Máy chỉ cần có PHP trong PATH. Backend PHP sẽ chạy ở port `8093`.

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
php -S 127.0.0.1:8093 -t T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
```

Tren may hien tai da co san script:

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
.\start_php.ps1
```

Test:

```text
http://127.0.0.1:8093/api.php?route=/api/health
http://127.0.0.1:8093/api.php?route=/api/khach-hang
http://127.0.0.1:8093/api.php?route=/api/nha-cung-cap
```

Lưu ý: nếu máy chưa bật extension `pdo_sqlsrv`, backend PHP sẽ tự chuyển tiếp request khách hàng/nhà cung cấp sang backend C# ở `http://localhost:5155/api`. Như vậy vẫn demo được luồng `Vue -> PHP backend -> C# backend -> SQL Server`.

## Yêu cầu nếu muốn PHP kết nối SQL Server trực tiếp

Máy cần có thêm:

- PHP 8 trở lên.
- Microsoft Drivers for PHP for SQL Server.
- Extension `pdo_sqlsrv` được bật.
- SQL Server đang có database `QLBH_TAKEAWAY`.

Trong máy hiện tại của Codex, lệnh `php` chưa có trong PATH nên mình không chạy test PHP trực tiếp được. Source vẫn sẵn sàng để chạy trên máy có PHP.

## Cấu hình database

Mặc định API dùng:

```text
Server: DESKTOP-392TCLG\SQLEXPRESS01
Database: QLBH_TAKEAWAY
User: sa
Password: 123456
```

Nếu máy khác tên SQL Server, có thể set biến môi trường trước khi chạy:

```powershell
$env:DB_SERVER="localhost"
$env:DB_DATABASE="QLBH_TAKEAWAY"
$env:DB_USER="sa"
$env:DB_PASSWORD="123456"
php -S 127.0.0.1:8093 -t T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
```

## Endpoint

Khách hàng:

- `GET /api/khach-hang`
- `GET /api/khach-hang?keyword=...`
- `GET /api/khach-hang/{maKh}`
- `POST /api/khach-hang`
- `PUT /api/khach-hang/{maKh}`
- `DELETE /api/khach-hang/{maKh}`

Nhà cung cấp:

- `GET /api/nha-cung-cap`
- `GET /api/nha-cung-cap?keyword=...`
- `GET /api/nha-cung-cap/{maNcc}`
- `POST /api/nha-cung-cap`
- `PUT /api/nha-cung-cap/{maNcc}`
- `DELETE /api/nha-cung-cap/{maNcc}`

## Endpoint tuong thich ban Laravel trong `QLBH_TAKEAWAY.rar`

File RAR cua nhom ban co mot Laravel app day du voi controller cho khach hang, nha cung cap, nguoi dung, nhom nguoi dung va dang nhap. De khong lam hong luong demo hien tai, project nay khong copy `vendor`, `node_modules`, cache/session hay thay proxy bang Laravel full app. Thay vao do, `api.php` ho tro them cac route tuong thich va van proxy sang C#:

- `POST /api/dang-nhap`
- `GET /api/khach-hang/ma-moi`
- `GET /api/nha-cung-cap/ma-moi`
- `GET /api/nguoi-dung`
- `GET /api/nguoi-dung/ma-moi`
- `GET /api/nguoi-dung/nhom`
- `GET /api/nhom-nguoi-dung`
- `GET /api/nhom-nguoi-dung/ma-moi`

Proxy chap nhan ca ten field kieu Laravel cu nhu `ma_kh`, `tenkhachhang`, `tennhacungcap`, `ma_nd`, `usr`, `pwd_hash` va tu chuyen sang payload C# hien tai. Cac thao tac yeu cau dang nhap/quyen van can header `Authorization: Bearer <token>` nhu backend C#.
