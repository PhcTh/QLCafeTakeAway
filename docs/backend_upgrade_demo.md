# Backend C# Upgrade Demo

## Chay demo

Backend:

```powershell
cd backend-csharp
dotnet run --urls http://localhost:5155
```

Swagger:

```text
http://localhost:5155/swagger
```

Frontend:

```powershell
cd frontend-vue
npm run dev
```

## Tai khoan demo

```text
thungan01 / 123456
quantri01 / 123456
```

Seed hien van de `123456` dang plain text de khong lam hong du lieu cu. Backend ho tro login legacy va se tu rehash mat khau bang PBKDF2 sau lan login thanh cong dau tien. Tai khoan tao/sua trong man hinh quan ly tai khoan se luu password dang hash.

## Lay JWT trong Postman

`POST http://localhost:5155/api/auth/login`

```json
{
  "username": "quantri01",
  "password": "123456"
}
```

Copy truong `token` trong response. Vao tab Authorization cua Postman hoac nut Authorize trong Swagger:

```text
Bearer <token>
```

Neu token sai/het han, API tra `401`. Neu user khong co quyen, API tra `403`.

## Endpoint demo

`GET /api/do-uong?page=1&pageSize=10&keyword=`

Response phan trang:

```json
{
  "items": [],
  "page": 1,
  "pageSize": 10,
  "totalItems": 0,
  "totalPages": 0
}
```

`POST /api/do-uong`

```json
{
  "maDu": "DU011",
  "maLdu": "LDU001",
  "tenDoUong": "Ca phe muoi",
  "donGia": 35000
}
```

`DELETE /api/do-uong/{id}`

Thao tac nay soft delete bang cach cap nhat `trangthai = 0`, khong xoa cung du lieu lich su.

`GET /api/don-nguyen-lieu-mua?page=1&pageSize=10&keyword=`

`PUT /api/don-nguyen-lieu-mua/{id}/trang-thai`

```json
{
  "trangThai": "DaGuiNCC"
}
```

Gia tri hop le: `MoiLap`, `DaGuiNCC`, `DaNhapHang`, `DaHuy`. Don da `DaNhapHang` khong duoc sua/xoa. Khi lap phieu nhap hang co `soDnlm`, backend tu cap nhat don lien quan thanh `DaNhapHang`.

Bao cao:

```text
GET /api/bao-cao/doanh-thu-ngay?ngay=2026-06-01
GET /api/bao-cao/do-uong-ban-chay?thang=6&nam=2026
```

## Quyen demo

- `N04`: quan tri he thong, duoc tat ca policy quan trong.
- `Q04`: lap don nguyen lieu mua.
- `Q05`: bao cao doanh thu ngay.
- `Q07`: do uong ban chay.
- `Q08`: cap nhat danh muc do uong/nguyen lieu.
- GET danh muc can dang nhap; POST/PUT/DELETE do uong, loai do uong, nguyen lieu can `Q08` hoac `N04`. Cach nay giu man hinh lap don mua doc duoc danh sach nguyen lieu khi user co `Q04`.

## SQL cho database hien co

Neu tao DB moi bang `database/taobang.sql` va `database/taodulieu.sql` thi cac cot moi da co san.

Neu dang dung DB hien co, khong can recreate database. Chay ALTER sau mot lan:

```sql
USE QLBH_TAKEAWAY;
GO

ALTER TABLE LDU ADD trangthai BIT NOT NULL CONSTRAINT DF_LDU_TRANGTHAI DEFAULT 1 WITH VALUES;
ALTER TABLE DU ADD trangthai BIT NOT NULL CONSTRAINT DF_DU_TRANGTHAI DEFAULT 1 WITH VALUES;
ALTER TABLE NL ADD trangthai BIT NOT NULL CONSTRAINT DF_NL_TRANGTHAI DEFAULT 1 WITH VALUES;
ALTER TABLE K_H ADD trangthai BIT NOT NULL CONSTRAINT DF_K_H_TRANGTHAI DEFAULT 1 WITH VALUES;
ALTER TABLE NCC ADD trangthai BIT NOT NULL CONSTRAINT DF_NCC_TRANGTHAI DEFAULT 1 WITH VALUES;
GO

ALTER TABLE D_NLM ADD trangthai NVARCHAR(20) NOT NULL CONSTRAINT DF_D_NLM_TRANGTHAI DEFAULT N'MoiLap' WITH VALUES;
GO

UPDATE D_NLM
SET trangthai = N'DaNhapHang'
WHERE EXISTS (
    SELECT 1
    FROM P_NH
    WHERE P_NH.so_dnlm = D_NLM.so_dnlm
);
GO

ALTER TABLE D_NLM ADD CONSTRAINT CK_D_NLM_TRANGTHAI
CHECK (trangthai IN (N'MoiLap', N'DaGuiNCC', N'DaNhapHang', N'DaHuy'));
GO
```

Khong can chay SQL rieng cho password hash. Backend se hash khi login thanh cong hoac khi tao/cap nhat tai khoan.
