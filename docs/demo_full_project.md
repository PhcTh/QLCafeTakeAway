# Huong dan demo project QLBH Take Away

## 1. Phan da hoan thien

Project hien co 2 backend va 1 frontend Vue:

- Backend C# ASP.NET Core: `backend-csharp`
- Backend PHP: `backend-laravel`
- Frontend Vue: `frontend-vue`

Phan C# dang phu trach:

- Loai do uong
- Do uong
- Nguyen lieu
- Don nguyen lieu mua
- Bao cao doanh thu ngay
- Do uong ban chay trong thang

Phan PHP dang phu trach:

- Khach hang
- Nha cung cap

Frontend Vue goi ca 2 backend:

- `src/api/csharpApi.js`: goi C# o `http://localhost:5155/api`
- `src/api/phpApi.js`: goi PHP o `http://127.0.0.1:8093/api.php`

## 2. Chay SQL Server

Database can co ten:

```text
QLBH_TAKEAWAY
```

Neu can tao lai database:

1. Mo SSMS.
2. Chay `database/taobang.sql`.
3. Chay `database/taodulieu.sql`.

Khong goi API `POST /api/database/recreate` neu khong muon reset database.

## 3. Chay backend C#

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-csharp
dotnet run --urls http://localhost:5155
```

Test:

```text
http://localhost:5155/api/health
http://localhost:5155/api/do-uong
http://localhost:5155/api/nguyen-lieu
http://localhost:5155/api/don-nguyen-lieu-mua
http://localhost:5155/api/bao-cao/do-uong-ban-chay?thang=6&nam=2026
```

## 4. Chay backend PHP

May hien tai can cai PHP truoc. Khi da co PHP, chay:

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
php -S 127.0.0.1:8093 -t T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
```

Test:

```text
http://127.0.0.1:8093/api.php?route=/api/health
http://127.0.0.1:8093/api.php?route=/api/khach-hang
http://127.0.0.1:8093/api.php?route=/api/nha-cung-cap
```

Neu chua cai `pdo_sqlsrv`, backend PHP se proxy sang backend C# o `http://localhost:5155/api`. Cach nay van demo duoc luong 2 backend:

```text
Vue -> PHP backend port 8093 -> C# backend port 5155 -> SQL Server
```

Neu ten SQL Server khac, set bien moi truong:

```powershell
$env:DB_SERVER="localhost"
$env:DB_DATABASE="QLBH_TAKEAWAY"
$env:DB_USER="sa"
$env:DB_PASSWORD="123456"
php -S 127.0.0.1:8093 -t T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
```

## 5. Chay frontend Vue

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\frontend-vue
npm run dev -- --host 127.0.0.1 --port 5173
```

Mo:

```text
http://127.0.0.1:5173/
```

## 6. Luong demo de an diem

### Demo backend C#

1. Mo `Loai do uong`.
2. Them/sua/xoa mot loai do uong demo.
3. Mo `Do uong`.
4. Them do uong moi, chon loai do uong tu dropdown.
5. Sua don gia, tim kiem theo ten.
6. Mo `Nguyen lieu`.
7. Them/sua/xoa mot nguyen lieu.

Noi voi thay:

```text
Ba man hinh nay goi backend C# qua csharpApi.js. Controller nhan request, CatalogService truy van SQL Server, tra JSON ve Vue.
```

### Demo 2 backend

1. Mo `Khach hang (PHP)`.
2. Them/sua/xoa khach hang.
3. Mo `Nha cung cap (PHP)`.
4. Them/sua/xoa nha cung cap.

Noi voi thay:

```text
Hai man hinh nay goi backend PHP qua phpApi.js o port 8093. Backend PHP sau do proxy sang C# de lay du lieu SQL Server. Day la phan tich hop backend thu hai cua project.
```

### Demo nghiep vu lien quan phan cua ban

1. Mo `Lap don nguyen lieu mua`.
2. Chon nha cung cap tu PHP.
3. Chon nguyen lieu tu C#.
4. Nhap so luong, don gia du kien.
5. Bam `Luu don`.

Noi voi thay:

```text
Man hinh nay tich hop ca 2 backend trong cung mot quy trinh: nha cung cap lay tu PHP, nguyen lieu va don mua luu bang C#.
```

### Demo bao cao

1. Mo `Bao cao doanh thu ngay`.
2. Chon ngay `2026-06-01`.
3. Mo `Do uong ban chay trong thang`.
4. Chon thang `6`, nam `2026`.

Noi voi thay:

```text
Bao cao duoc tinh tu bang hoa don va chi tiet hoa don. Backend C# dung SQL join, sum, group by de tra ket qua.
```

## 7. Diem debug de giai thich

### Debug C# CRUD do uong

Dat breakpoint:

- `Controllers/CatalogControllers.cs`, ham `DoUongController.GetAll`
- `Services/CatalogService.cs`, ham `GetDoUongAsync`

Giai thich:

```text
Frontend goi GET /api/do-uong.
Controller nhan request.
Service mo ket noi SQL Server.
SQL join DU voi LDU de lay ten loai.
SqlHelpers map tung dong thanh DoUongDto.
Controller tra JSON ve Vue.
```

### Debug PHP khach hang

Mo file:

```text
backend-laravel/api.php
```

Giai thich:

```text
PHP doc REQUEST_METHOD va REQUEST_URI de biet endpoint.
Neu endpoint la /api/khach-hang thi chay handle_khach_hang.
Ham nay dung PDO SQL Server de SELECT/INSERT/UPDATE/DELETE bang K_H.
Sau do map cot SQL sang JSON camelCase cho Vue.
```

### Debug Vue

Mo F12 tren trinh duyet:

- Tab Console: loi JavaScript.
- Tab Network: xem request dang goi C# hay PHP.

Neu loi `Khong ket noi duoc backend C#`:

```powershell
cd backend-csharp
dotnet run --urls http://localhost:5155
```

Neu loi `Khong ket noi duoc backend PHP`:

```powershell
cd backend-laravel
php -S 127.0.0.1:8093 -t T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
```

## 8. Cac loi thầy co the yeu cau sua nhanh

1. Them dieu kien tim kiem do uong theo ten loai:
   - Sua SQL trong `CatalogService.GetDoUongAsync`.

2. Khong cho don gia bang 0:
   - Sua `EnsurePositive(decimal value, string name)` trong `CatalogService.cs`.

3. Them cot don vi tinh vao bang hien thi:
   - Sua template `NguyenLieu.vue`.

4. Doi sap xep do uong ban chay theo doanh thu:
   - Sua `ORDER BY` trong `ReportService.GetDoUongBanChayAsync`.

5. Doi backend PHP sang SQL Server khac:
   - Sua bien moi truong `DB_SERVER`.

## 9. Lenh da kiem tra

Da build thanh cong:

```powershell
cd backend-csharp
dotnet build
```

```powershell
cd frontend-vue
npm run build
```

Luu y: `dotnet build` co canh bao `NU1900` do khong tai duoc thong tin vulnerability tu NuGet. Day khong phai loi code va khong anh huong demo.
