# Huong dan backend C# - QLBH Take Away

## Vai tro phan C#

Backend C# la ASP.NET Core Web API ket noi SQL Server database `QLBH_TAKEAWAY`.
Phan nay phu trach cac API nghiep vu chinh trong bao cao:

- Dang nhap nguoi dung va lay nhom/quyen.
- CRUD danh muc: loai do uong, do uong, nguyen lieu, khach hang, nha cung cap.
- Nghiep vu ban hang: phieu goi do uong, hoa don ban do uong.
- Nghiep vu nguyen lieu: don nguyen lieu mua, phieu nhap hang, phieu kiem ke.
- Bao cao: doanh thu ngay, do uong ban chay theo thang.

## Cach chay

1. Mo terminal tai `backend-csharp`.
2. Kiem tra connection string trong `appsettings.json`.
   Mac dinh:

```json
"Server=DESKTOP-392TCLG\\SQLEXPRESS01;Database=QLBH_TAKEAWAY;User Id=sa;Password=123456;TrustServerCertificate=True;Encrypt=False"
```

3. Build:

```powershell
dotnet build
```

4. Chay API:

```powershell
dotnet run --urls http://localhost:5155
```

5. Test:

```powershell
Invoke-RestMethod http://localhost:5155/api/health
```

## Dung database

Script da duoc copy vao:

- `database/taobang.sql`
- `database/taodulieu.sql`

Co 2 cach dung:

- Cach an toan: mo SSMS, chay `taobang.sql`, sau do chay `taodulieu.sql`.
- Cach qua API: chay backend roi goi `POST /api/database/recreate`.

Luu y: `POST /api/database/recreate` se drop va tao lai database `QLBH_TAKEAWAY`.

## Cach debug de giai thich voi thay

Vi du debug API khach hang:

1. Dat breakpoint trong `Controllers/CatalogControllers.cs`, ham `KhachHangController.GetAll`.
2. Chay Debug.
3. Goi `GET /api/khach-hang`.
4. Khi dung o controller, bam F11 xuong `CatalogService.GetKhachHangAsync`.
5. Giai thich:
   - Controller nhan HTTP request.
   - Service mo ket noi SQL Server bang `DbConnectionFactory`.
   - SQL query doc bang `K_H`.
   - `SqlDataReader` map tung dong sang `KhachHangDto`.
   - Controller tra JSON ve frontend.

Vi du debug API hoa don:

1. Dat breakpoint trong `HoaDonController.Create`.
2. Goi `POST /api/hoa-don`.
3. F11 vao `SalesService.CreateHoaDonAsync`.
4. Giai thich:
   - Kiem tra du lieu bat buoc.
   - Neu request khong gui chi tiet, service lay chi tiet tu `C_T_PGDU`.
   - Lay don gia tu bang `DU`.
   - Tinh `thanhtien = soluongban * dongia`.
   - Mo transaction.
   - Insert header vao `HD_BDUONG`.
   - Insert detail vao `C_T_HDBDU`.
   - Thanh cong thi commit, loi thi rollback.

## Cac loi 5 phut de tap sua

- Doi cong thuc thanh tien trong `SalesService.CreateHoaDonAsync`.
- Them dieu kien tim kiem trong `CatalogService.GetKhachHangAsync`.
- Them validation so dien thoai trong `CatalogService.CreateKhachHangAsync`.
- Doi sap xep bao cao ban chay trong `ReportService.GetDoUongBanChayAsync`.
- Them endpoint moi trong controller va goi service tuong ung.
