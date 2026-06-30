# Cập nhật báo cáo và quản trị hệ thống

## 1. Mẫu MB.05 - Đơn nguyên liệu mua

Đã chỉnh lại mẫu in trong:

`frontend-vue/src/pages/quanlynghiepvu/DonNguyenLieuMua.vue`

Các trường đã khớp lại theo báo cáo:

- Số đơn.
- Ngày lập đơn.
- Nhà cung cấp.
- Địa chỉ nhà cung cấp.
- Số điện thoại nhà cung cấp.
- Bộ phận.
- Tên nguyên liệu.
- Đơn vị tính.
- Số lượng đề nghị.
- Đơn giá dự kiến.
- Thành tiền nguyên liệu dự kiến.
- Tổng giá trị đơn dự kiến.
- Ghi chú.
- Người lập đơn.
- Quản lý.

Backend cũng đã bổ sung `donViTinh` cho chi tiết đơn nguyên liệu mua:

- `backend-csharp/Models/InventoryModels.cs`
- `backend-csharp/Services/InventoryService.cs`

## 2. Mẫu MB.08 - Báo cáo doanh thu theo ngày

Đã hoàn thiện màn:

`frontend-vue/src/pages/quanlynghiepvu/DoanhThuNgay.vue`

Các phần đã thêm:

- Nút `In mẫu`.
- Mẫu in MB.08 khổ A4.
- Người lập báo cáo.
- Mã hóa đơn.
- Thời gian thanh toán.
- Hình thức thanh toán.
- Mã đồ uống.
- Tên đồ uống.
- Đơn vị tính.
- Số lượng bán.
- Đơn giá.
- Thành tiền.
- Ghi chú.
- Tổng số lượng đồ uống bán ra.
- Tổng doanh thu trong ngày.

Backend đã bổ sung thêm trường cho báo cáo:

- `nguoiLapBaoCao`
- `donViTinh`
- `ghiChu`

## 3. Mẫu MB.10 - Báo cáo đồ uống bán chạy trong tháng

Đã hoàn thiện màn:

`frontend-vue/src/pages/quanlynghiepvu/DoUongBanChay.vue`

Các phần đã thêm:

- Nút `In mẫu`.
- Mẫu in MB.10 khổ A4.
- Tháng/năm báo cáo.
- Mã đồ uống.
- Tên đồ uống.
- Đơn vị tính.
- Tổng số lượng bán.
- Tổng doanh thu.
- Xếp hạng đồ uống bán chạy.

Backend đã bổ sung:

- `tongSoLuongBan`
- `tongDoanhThu`
- `donViTinh`

## 4. Quản trị hệ thống

Đã thêm màn:

`frontend-vue/src/pages/quantrihethong/QuanLyTaiKhoan.vue`

Đã nối route:

`/quan-ly-tai-khoan`

Đã nối vào sidebar:

`Quản trị hệ thống -> Quản lý tài khoản người dùng`

Chức năng hiện có:

- Tìm kiếm tài khoản.
- Thêm tài khoản.
- Sửa tài khoản.
- Xem chi tiết tài khoản.
- Khóa tài khoản.
- Chọn nhóm người dùng.
- Đổi trạng thái hoạt động/khóa.

Backend đã hoàn thiện:

- `GET /api/nguoi-dung`
- `POST /api/nguoi-dung`
- `PUT /api/nguoi-dung/{id}`
- `DELETE /api/nguoi-dung/{id}`
- `GET /api/nhom-nguoi-dung`

Lưu ý: thao tác `DELETE` đang khóa tài khoản bằng cách cập nhật `trangthai = 0`, không xóa cứng khỏi CSDL. Cách này an toàn hơn vì tài khoản có thể đang được tham chiếu bởi hóa đơn, đơn nguyên liệu mua hoặc các chứng từ khác.

## 5. Lệnh kiểm tra

Đã chạy thành công:

```bash
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\frontend-vue
npm run build
```

```bash
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-csharp
dotnet build -o .\bin\VerifyBuild
```

Nếu đang có C# API cũ chạy, cần dừng rồi chạy lại:

```bash
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\backend-csharp
dotnet run
```

Sau đó frontend mới gọi được các endpoint quản trị và các trường báo cáo mới.
