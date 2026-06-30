# Giải thích bản cập nhật giao diện form nổi và cột Thao tác

File này thay cho bản giải thích cũ. Bản mới phản ánh đúng giao diện hiện tại: danh sách luôn hiển thị, còn Thêm/Sửa/Xem mở bằng hộp thoại nổi.

## 1. Ý tưởng sửa giao diện

Trước đây khi bấm `Thêm` hoặc `Sửa`, trang chuyển sang một màn khác nên bảng danh sách bị mất. Bản mới đổi sang cách làm thông minh hơn:

- Bảng danh sách luôn nằm trên màn hình.
- Bấm `Thêm`, `Sửa`, `Xem` thì mở một hộp thoại nổi ở giữa màn hình.
- Đóng hộp thoại thì quay lại bảng ngay, không cần load lại page khác.
- Các cột `Xem`, `Sửa`, `Xóa`, `In` được gộp thành một cột `Thao tác`.
- Nút có icon nhỏ bên trái để nhìn dễ hơn.
- Bỏ các dòng mô tả thừa dưới tiêu đề để giao diện sạch hơn.

## 2. Các file đã sửa

### `frontend-vue/src/pages/quanlydanhmuc/LoaiDoUong.vue`

Màn quản lý loại đồ uống đã đổi sang modal.

Các biến quan trọng:

```js
const hopThoaiDangMo = ref('')
const dangSua = ref(false)
const dongDangXem = ref(null)
```

Ý nghĩa:

- `hopThoaiDangMo = ''`: không mở hộp thoại nào.
- `hopThoaiDangMo = 'form'`: mở form thêm/sửa.
- `hopThoaiDangMo = 'detail'`: mở hộp thoại xem chi tiết.
- `dangSua`: phân biệt đang thêm mới hay đang sửa.
- `dongDangXem`: lưu dòng đang xem chi tiết.

Các hàm chính:

- `batDauThem()`: reset form, đặt `dangSua = false`, mở modal form.
- `batDauSua(loai)`: đổ dữ liệu loại đồ uống vào form, đặt `dangSua = true`, mở modal form.
- `xemChiTiet(loai)`: đưa dữ liệu vào `dongDangXem`, mở modal chi tiết.
- `dongHopThoai()`: đóng modal, reset form và trạng thái.
- `luuDuLieu()`: nếu đang sửa thì gọi `updateLoaiDoUong`, nếu thêm thì gọi `createLoaiDoUong`.

Điểm cần nhớ khi tự code lại:

```js
hopThoaiDangMo.value = 'form'
```

Dòng này chính là lệnh mở form nổi. Không còn chuyển sang một page khác nữa.

### `frontend-vue/src/pages/quanlydanhmuc/NguyenLieu.vue`

Màn nguyên liệu dùng cùng cách làm với loại đồ uống.

Form gồm:

- `maNl`: mã nguyên liệu.
- `tenNguyenLieu`: tên nguyên liệu.
- `donViTinh`: đơn vị tính.

Bảng đã gộp thao tác:

```html
<th class="cot-thao-tac">Thao tác</th>
```

Trong mỗi dòng có nhóm nút:

```html
<div class="nhom-thao-tac">
  <button> Xem </button>
  <button> Sửa </button>
  <button> Xóa </button>
</div>
```

CSS sẽ tự căn các nút gọn trong cùng một cột.

### `frontend-vue/src/pages/quanlydanhmuc/DoUong.vue`

Màn đồ uống cũng đổi sang modal và gộp cột thao tác.

Điểm khác so với hai màn trên:

- Có thêm `dsLoaiDoUong` để đổ vào combobox loại đồ uống.
- Khi mở trang, frontend gọi cả:
  - `taiLoaiDoUong()`
  - `taiDuLieu()`

Form đồ uống gửi các trường:

```js
{
  maDu,
  maLdu,
  tenDoUong,
  donGia
}
```

Khi bấm `Sửa`, hàm `ganForm(du)` đưa dữ liệu dòng đang chọn vào form:

```js
form.maDu = du?.maDu || ''
form.maLdu = du?.maLdu || ''
form.tenDoUong = du?.tenDoUong || ''
form.donGia = du?.donGia || 0
```

### `frontend-vue/src/pages/quanlynghiepvu/DonNguyenLieuMua.vue`

Đây là phần nghiệp vụ chính.

Bản mới có:

- Danh sách đơn luôn hiển thị.
- Bấm `Lập đơn` mở modal form rộng.
- Bấm `Sửa` mở lại modal form và đổ dữ liệu đơn vào.
- Bấm `Xem` mở modal chi tiết đơn.
- Bấm `In` xuất mẫu biểu MB.05.
- Cột thao tác gộp 4 nút: `Xem`, `Sửa`, `In`, `Xóa`.

Các biến chính:

```js
const hopThoaiDangMo = ref('')
const dangSua = ref(false)
const donDangXem = ref(null)
```

Luồng thêm đơn:

1. Bấm `Lập đơn`.
2. `batDauThem()` chạy.
3. Hàm reset form bằng `ganFormMacDinh()`.
4. Đặt `hopThoaiDangMo.value = 'form'`.
5. Người dùng nhập đơn trong modal.
6. Bấm `Lưu đơn`.
7. `luuDuLieu()` gọi `csharpApi.createDonNguyenLieuMua(payload)`.
8. Lưu xong thì tải lại danh sách và đóng modal.

Luồng sửa đơn:

1. Bấm `Sửa`.
2. `batDauSua(don)` chạy.
3. `ganFormTuDon(don)` đưa dữ liệu đơn vào form.
4. Đặt `dangSua = true`.
5. Bấm `Cập nhật`.
6. `luuDuLieu()` gọi `csharpApi.updateDonNguyenLieuMua(form.soDnlm, payload)`.

Luồng xem đơn:

1. Bấm `Xem`.
2. `xemChiTiet(don)` chạy.
3. Dữ liệu được gán vào `donDangXem`.
4. Modal chi tiết hiển thị thông tin đơn và bảng nguyên liệu.

Luồng xuất mẫu:

1. Bấm `In` ở bảng hoặc `Xuất mẫu` trong chi tiết.
2. Hàm `xuatMauBieu(don)` tạo HTML mẫu MB.05.
3. Mở cửa sổ mới bằng `window.open`.
4. Gọi `window.print()`.

## 3. CSS đã thêm/sửa

Đường dẫn: `frontend-vue/src/assets/css/style.css`

Các class quan trọng:

### `.lop-phu`

Lớp phủ toàn màn hình khi mở form hoặc chi tiết.

```css
.lop-phu {
  position: fixed;
  inset: 0;
  z-index: 1000;
}
```

Ý nghĩa:

- `fixed`: modal luôn nằm trên màn hình.
- `inset: 0`: phủ toàn bộ màn hình.
- `z-index: 1000`: nổi lên trên các phần khác.

### `.hop-thoai`

Khung hộp thoại form hoặc chi tiết.

```css
.hop-thoai {
  width: min(820px, 96vw);
  background-color: white;
}
```

Màn lập đơn dùng thêm class:

```html
class="hop-thoai hop-thoai-rong"
```

vì form lập đơn có nhiều trường và bảng chi tiết.

### `.dau-hop-thoai`

Thanh tiêu đề của hộp thoại.

Nó chứa:

- Tên form, ví dụ `Thêm đồ uống`.
- Nút đóng `×`.

### `.cot-thao-tac` và `.nhom-thao-tac`

Hai class này dùng để gom các nút thao tác vào một cột.

```css
.nhom-thao-tac {
  display: flex;
  gap: 7px;
  flex-wrap: wrap;
}
```

Ý nghĩa:

- Các nút nằm cùng hàng nếu đủ chỗ.
- Nếu màn nhỏ, nút tự xuống hàng.

### `.icon-nut`

Tạo icon nhỏ bên trái chữ trong button.

Ví dụ:

```html
<button><span class="icon-nut">+</span>Thêm</button>
```

Bạn có thể đổi ký hiệu trong `span` nếu muốn:

- `+`: thêm
- `✎`: sửa
- `×`: xóa hoặc đóng
- `i`: xem
- `⎙`: in
- `↻`: làm mới
- `✓`: lưu

## 4. Vì sao cách này đúng ý hơn

Cách cũ:

- Bấm thêm thì bảng biến mất.
- Người dùng không còn nhìn được dữ liệu hiện tại.
- Cảm giác như chuyển page dù vẫn là cùng component.

Cách mới:

- Bảng vẫn nằm nguyên.
- Form chỉ nổi lên để nhập dữ liệu.
- Đóng form là thấy lại danh sách ngay.
- Trông giống phần mềm quản lý hơn.

## 5. Cách demo với thầy

Demo danh mục:

1. Vào `Loại đồ uống`.
2. Bấm `Thêm`.
3. Chỉ ra rằng form nổi lên, bảng phía sau vẫn còn.
4. Nhập dữ liệu và lưu.
5. Bấm `Xem`, `Sửa`, `Xóa` trong cột `Thao tác`.

Demo nguyên liệu:

1. Vào `Nguyên liệu`.
2. Bấm `Thêm`, lưu nguyên liệu.
3. Bấm `Sửa` để cập nhật đơn vị tính.
4. Bấm `Xem` để xem chi tiết.

Demo đồ uống:

1. Vào `Đồ uống`.
2. Bấm `Thêm`.
3. Chọn `Loại đồ uống` trong combobox.
4. Nhập giá bán và lưu.

Demo nghiệp vụ:

1. Vào `Lập đơn nguyên liệu mua`.
2. Bấm `Lập đơn`.
3. Chọn nhà cung cấp từ PHP hoặc nhập thủ công.
4. Thêm nguyên liệu vào bảng chi tiết.
5. Lưu đơn bằng backend C#.
6. Bấm `Xem` để mở chi tiết.
7. Bấm `In` để xuất mẫu MB.05.

## 6. Chỗ thầy có thể hỏi để sửa nhanh

### Đổi chữ cột `Thao tác`

Mở file Vue cần sửa, tìm:

```html
<th class="cot-thao-tac">Thao tác</th>
```

Đổi thành chữ thầy yêu cầu.

### Thêm nút mới vào cột thao tác

Thêm một button trong:

```html
<div class="nhom-thao-tac">
```

Ví dụ thêm nút Nhân bản:

```html
<button class="nut-bang"><span class="icon-nut">+</span>Nhân bản</button>
```

### Đổi modal rộng hơn

Mở `style.css`, sửa:

```css
.hop-thoai-rong {
  width: min(1180px, 96vw);
}
```

### Bắt buộc đơn giá lớn hơn 0

Trong `DonNguyenLieuMua.vue`, tìm:

```js
ct.donGiaDuKien < 0
```

Đổi thành:

```js
ct.donGiaDuKien <= 0
```

## 7. Kiểm tra sau khi sửa

Cần chạy:

```bash
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\frontend-vue
npm run build
```

Nếu build thành công thì Vue không lỗi cú pháp.

Khi demo:

```bash
cd T:\QLBH_TAKEAWAY\QLBH_TAKEAWAY\frontend-vue
npm run dev
```

Mở:

```text
http://localhost:5173/
```
