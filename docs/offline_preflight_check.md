# Offline pre-flight check

Ngay truoc khi ngat mang, da kiem tra cac muc sau.

## Da san sang

### Backend C#

Da build thanh cong:

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-csharp
dotnet build
```

Da test API thanh cong:

```text
http://localhost:5155/api/health
http://localhost:5155/api/do-uong
http://localhost:5155/api/don-nguyen-lieu-mua
http://localhost:5155/api/bao-cao/doanh-thu-ngay?ngay=2026-06-01
http://localhost:5155/api/bao-cao/do-uong-ban-chay?thang=6&nam=2026
```

Da test tao/xoa thu mot `Don nguyen lieu mua` qua API C# thanh cong.

Khi offline nen chay:

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-csharp
dotnet run --no-restore --urls http://localhost:5155
```

### Frontend Vue

Da build thanh cong:

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\frontend-vue
npm run build
```

Da test frontend dev server tra HTTP 200:

```text
http://127.0.0.1:5173/
```

Khi offline nen chay:

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\frontend-vue
npm run dev -- --host 127.0.0.1 --port 5173
```

## Diem can xu ly neu muon demo du 2 backend

### Backend PHP

Source PHP da co:

```text
T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel\api.php
```

May hien tai chua co lenh `php` trong PATH. Da kiem tra:

- `where php`: khong thay.
- `C:\xampp\php\php.exe`: khong thay.
- `C:\laragon\bin\php`: khong thay.
- `C:\Program Files\PHP\php.exe`: khong thay.
- `choco`: khong co.
- `scoop`: khong co.
- `winget`: khong chay duoc trong phien hien tai.

Da bo sung che do demo nhanh: neu may co PHP nhung chua co driver `pdo_sqlsrv`, backend PHP se proxy request sang backend C# o `http://localhost:5155/api`.

Vi vay de demo du 2 backend toi thieu, chi can cai PHP runtime truoc khi offline.

Chay:

```powershell
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
php -S 127.0.0.1:8093 -t T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-laravel
```

Neu muon PHP ket noi SQL Server truc tiep, can cai them:

- PHP 8.x
- Microsoft Drivers for PHP for SQL Server
- Bat extension `pdo_sqlsrv`

Test:

```text
http://127.0.0.1:8093/api.php?route=/api/health
http://127.0.0.1:8093/api.php?route=/api/khach-hang
http://127.0.0.1:8093/api.php?route=/api/nha-cung-cap
```

## Cach demo neu chua cai PHP kip

Neu khong cai PHP kip truoc khi offline, van demo tot phan C# cua ban:

1. Loai do uong
2. Do uong
3. Nguyen lieu
4. Lap don nguyen lieu mua
5. Bao cao doanh thu ngay
6. Do uong ban chay trong thang

Khi thay hoi 2 backend, noi ro:

```text
Nhom da co source backend PHP trong folder backend-laravel de phu trach khach hang va nha cung cap. May demo chay PHP port 8093 va PHP proxy sang C# port 5155.
```

Tot nhat van nen cai PHP truoc ngay demo de tranh bi tru diem phan tich hop 2 backend.
