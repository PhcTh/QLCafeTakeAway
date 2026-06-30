USE QLBH_TAKEAWAY;
GO

/* =========================================================
   1. DỮ LIỆU NGƯỜI DÙNG - PHÂN QUYỀN
   ========================================================= */

INSERT INTO NGUOIDUNG
(ma_nd, tennd, sdt, usr, pwd_hash, vitri, trangthai)
VALUES
('ND001', N'Nguyễn Văn An', '0981111111', 'phucvu01', '123456', N'Nhân viên phục vụ', 1),
('ND002', N'Trần Thị Bình', '0982222222', 'thungan01', '123456', N'Nhân viên thu ngân', 1),
('ND003', N'Lê Văn Cường', '0983333333', 'phache01', '123456', N'Nhân viên pha chế', 1),
('ND004', N'Phạm Thị Dung', '0984444444', 'quantri01', '123456', N'Người quản trị', 1),
('ND005', N'Hoàng Văn Em', '0985555555', 'phucvu02', '123456', N'Nhân viên phục vụ', 1);
GO

/* Theo tài liệu chỉ có 4 nhóm người dùng N01-N04 nên giữ đúng 4 nhóm */
INSERT INTO NHOMND
(ma_nhom, tennhom, mota, trangthai)
VALUES
('N01', N'Nhân viên phục vụ', N'Lập phiếu gọi đồ uống, phục vụ khách hàng', 1),
('N02', N'Nhân viên thu ngân', N'Lập hóa đơn, thanh toán, thống kê doanh thu', 1),
('N03', N'Nhân viên pha chế', N'Cập nhật menu, pha chế, nhập hàng, kiểm kê', 1),
('N04', N'Người quản trị', N'Quản lý tài khoản, phân quyền, sao lưu dữ liệu', 1);
GO

INSERT INTO QUYEN
(ma_quyen, tenquyen)
VALUES
('Q01', N'Lập phiếu gọi đồ uống'),
('Q02', N'Cập nhật trạng thái phục vụ'),
('Q03', N'Lập hóa đơn bán đồ uống'),
('Q04', N'Lập đơn nguyên liệu mua'),
('Q05', N'Lập thống kê doanh thu ngày'),
('Q06', N'Lập biên bản đối soát doanh thu'),
('Q07', N'Lập thống kê đồ uống bán chạy'),
('Q08', N'Cập nhật menu'),
('Q09', N'Lập phiếu nhập hàng'),
('Q10', N'Lập phiếu kiểm kê');
GO

INSERT INTO ND_NHOM
(ma_nd, ma_nhom)
VALUES
('ND001', 'N01'),
('ND002', 'N02'),
('ND003', 'N03'),
('ND004', 'N04'),
('ND005', 'N01');
GO

INSERT INTO PHANQUYEN
(ma_nhom, ma_quyen)
VALUES
('N01', 'Q01'),
('N01', 'Q02'),
('N02', 'Q03'),
('N02', 'Q04'),
('N02', 'Q05'),
('N02', 'Q06'),
('N02', 'Q07'),
('N03', 'Q08'),
('N03', 'Q09'),
('N03', 'Q10'),
('N04', 'Q01'),
('N04', 'Q02'),
('N04', 'Q03'),
('N04', 'Q04'),
('N04', 'Q05'),
('N04', 'Q06'),
('N04', 'Q07'),
('N04', 'Q08'),
('N04', 'Q09'),
('N04', 'Q10');
GO


/* =========================================================
   2. DỮ LIỆU DANH MỤC
   ========================================================= */

INSERT INTO LDU
(ma_ldu, tenloaidouong, mota)
VALUES
('LDU001', N'Cà phê', N'Các loại cà phê pha máy, pha phin'),
('LDU002', N'Trà sữa', N'Các loại trà sữa take away'),
('LDU003', N'Trà trái cây', N'Trà đào, trà vải, trà chanh'),
('LDU004', N'Đá xay', N'Các món đá xay, frappe'),
('LDU005', N'Nước ép', N'Nước ép trái cây tươi');
GO

INSERT INTO NL
(ma_nl, tennguyenlieu, donvitinh)
VALUES
('NL001', N'Cà phê hạt', N'Kg'),
('NL002', N'Sữa tươi', N'Lít'),
('NL003', N'Đường', N'Kg'),
('NL004', N'Trà đen', N'Kg'),
('NL005', N'Đào ngâm', N'Hộp'),
('NL006', N'Trân châu', N'Kg'),
('NL007', N'Bột cacao', N'Kg'),
('NL008', N'Cam tươi', N'Kg');
GO

INSERT INTO K_H
(ma_kh, tenkhachhang, sodienthoai, diachi, gioitinh)
VALUES
('KH001', N'Nguyễn Minh Anh', '0901000001', N'Cao Lãnh, Đồng Tháp', N'Nữ'),
('KH002', N'Trần Quốc Bảo', '0901000002', N'Cao Lãnh, Đồng Tháp', N'Nam'),
('KH003', N'Lê Thị Chi', '0901000003', N'Lấp Vò, Đồng Tháp', N'Nữ'),
('KH004', N'Phạm Hoàng Duy', '0901000004', N'Sa Đéc, Đồng Tháp', N'Nam'),
('KH005', N'Võ Thanh Hà', '0901000005', N'Tam Nông, Đồng Tháp', N'Nữ');
GO

INSERT INTO NCC
(ma_ncc, tennhacungcap, diachincc, sodienthoaincc)
VALUES
('NCC001', N'Công ty Cà phê Việt', N'TP. Hồ Chí Minh', '0911111111'),
('NCC002', N'Nhà cung cấp Sữa An Bình', N'Cần Thơ', '0922222222'),
('NCC003', N'Đại lý Nguyên liệu Pha Chế Miền Tây', N'Đồng Tháp', '0933333333'),
('NCC004', N'Công ty Trà Xanh Việt', N'Lâm Đồng', '0944444444'),
('NCC005', N'Vựa Trái Cây Tươi Cao Lãnh', N'Đồng Tháp', '0955555555');
GO

INSERT INTO DU
(ma_du, ma_ldu, tendouong, dongia)
VALUES
('DU001', 'LDU001', N'Cà phê đen', 20000),
('DU002', 'LDU001', N'Cà phê sữa', 25000),
('DU003', 'LDU002', N'Trà sữa truyền thống', 30000),
('DU004', 'LDU003', N'Trà đào cam sả', 35000),
('DU005', 'LDU004', N'Cacao đá xay', 40000),
('DU006', 'LDU005', N'Nước ép cam', 30000),
('DU007', 'LDU003', N'Trà vải', 32000),
('DU008', 'LDU002', N'Trà sữa trân châu', 35000),
('DU009', 'LDU004', N'Cà phê đá xay', 42000),
('DU010', 'LDU005', N'Nước ép dưa hấu', 28000);
GO

INSERT INTO DU_NL
(ma_nl, ma_du)
VALUES
('NL001', 'DU001'),
('NL001', 'DU002'),
('NL002', 'DU002'),
('NL004', 'DU003'),
('NL002', 'DU003'),
('NL006', 'DU008'),
('NL004', 'DU004'),
('NL005', 'DU004'),
('NL007', 'DU005'),
('NL008', 'DU006');
GO


/* =========================================================
   3. PHIẾU GỌI ĐỒ UỐNG
   ========================================================= */

INSERT INTO P_G_DU
(so_pgdu, ma_kh, ngaygoiduong, thoigiangoiduong, tenkhachhang, tennd, ma_nd)
VALUES
('PG001', 'KH001', '2026-06-01', '08:15:00', N'Nguyễn Minh Anh', N'Nguyễn Văn An', 'ND001'),
('PG002', 'KH002', '2026-06-01', '09:20:00', N'Trần Quốc Bảo', N'Hoàng Văn Em', 'ND005'),
('PG003', 'KH003', '2026-06-01', '10:05:00', N'Lê Thị Chi', N'Nguyễn Văn An', 'ND001'),
('PG004', 'KH004', '2026-06-02', '14:30:00', N'Phạm Hoàng Duy', N'Hoàng Văn Em', 'ND005'),
('PG005', 'KH005', '2026-06-02', '16:45:00', N'Võ Thanh Hà', N'Nguyễn Văn An', 'ND001');
GO

INSERT INTO C_T_PGDU
(ma_du, so_pgdu, size, soluonggoi, yeucaudacbiet)
VALUES
('DU001', 'PG001', N'M', 1, N'Ít đá'),
('DU003', 'PG001', N'L', 1, N'Ít đường'),
('DU002', 'PG002', N'M', 2, N'Bình thường'),
('DU004', 'PG003', N'L', 1, N'Thêm đào'),
('DU005', 'PG004', N'M', 1, N'Không kem'),
('DU006', 'PG004', N'M', 2, N'Không đường'),
('DU008', 'PG005', N'L', 1, N'Thêm trân châu'),
('DU007', 'PG005', N'M', 1, N'Ít đá');
GO


/* =========================================================
   4. HÓA ĐƠN BÁN ĐỒ UỐNG
   ========================================================= */

INSERT INTO HD_BDUONG
(so_hdbdu, ma_khachhang, so_pgdu, ngaylaphoadon, thoigianthanhtoan,
 hinhthucthanhtoan, trangthai, ghichu, nguoilaphoadon,
 ma_du, soluongban, tendouong, thanhtien, tennd, ma_nd)
VALUES
('HD001', 'KH001', 'PG001', '2026-06-01', '08:30:00',
 N'Tiền mặt', N'Đã thanh toán', N'Khách nhận đủ đồ uống', N'Trần Thị Bình',
 'DU001', 1, N'Cà phê đen', 20000, N'Trần Thị Bình', 'ND002'),

('HD002', 'KH002', 'PG002', '2026-06-01', '09:35:00',
 N'Chuyển khoản', N'Đã thanh toán', N'Đã đối chiếu chuyển khoản', N'Trần Thị Bình',
 'DU002', 2, N'Cà phê sữa', 50000, N'Trần Thị Bình', 'ND002'),

('HD003', 'KH003', 'PG003', '2026-06-01', '10:20:00',
 N'Tiền mặt', N'Đã thanh toán', N'Không ghi chú', N'Trần Thị Bình',
 'DU004', 1, N'Trà đào cam sả', 35000, N'Trần Thị Bình', 'ND002'),

('HD004', 'KH004', 'PG004', '2026-06-02', '14:50:00',
 N'Tiền mặt', N'Đã thanh toán', N'Mua mang đi', N'Trần Thị Bình',
 'DU005', 1, N'Cacao đá xay', 40000, N'Trần Thị Bình', 'ND002'),

('HD005', 'KH005', 'PG005', '2026-06-02', '17:00:00',
 N'Chuyển khoản', N'Đã thanh toán', N'Khách quen', N'Trần Thị Bình',
 'DU008', 1, N'Trà sữa trân châu', 35000, N'Trần Thị Bình', 'ND002');
GO

INSERT INTO C_T_HDBDU
(so_hdbdu, ma_du, size, soluongban, thanhtien)
VALUES
('HD001', 'DU001', N'M', 1, 20000),
('HD001', 'DU003', N'L', 1, 30000),
('HD002', 'DU002', N'M', 2, 50000),
('HD003', 'DU004', N'L', 1, 35000),
('HD004', 'DU005', N'M', 1, 40000),
('HD004', 'DU006', N'M', 2, 60000),
('HD005', 'DU008', N'L', 1, 35000),
('HD005', 'DU007', N'M', 1, 32000);
GO


/* =========================================================
   5. ĐƠN NGUYÊN LIỆU MUA
   ========================================================= */

INSERT INTO D_NLM
(so_dnlm, ngaylapdon, nhacungcap, diachi, sodienthoai, bophan,
 ghichu, nguoilapdon, quanly, tennd, ma_nd)
VALUES
('DN001', '2026-06-01', N'Công ty Cà phê Việt', N'TP. Hồ Chí Minh', '0911111111',
 N'Bộ phận thu ngân', N'Mua bổ sung cà phê hạt', N'Trần Thị Bình', N'Phạm Thị Dung',
 N'Trần Thị Bình', 'ND002'),

('DN002', '2026-06-01', N'Nhà cung cấp Sữa An Bình', N'Cần Thơ', '0922222222',
 N'Bộ phận thu ngân', N'Mua sữa tươi', N'Trần Thị Bình', N'Phạm Thị Dung',
 N'Trần Thị Bình', 'ND002'),

('DN003', '2026-06-02', N'Đại lý Nguyên liệu Pha Chế Miền Tây', N'Đồng Tháp', '0933333333',
 N'Bộ phận thu ngân', N'Mua đường và trân châu', N'Trần Thị Bình', N'Phạm Thị Dung',
 N'Trần Thị Bình', 'ND002'),

('DN004', '2026-06-02', N'Công ty Trà Xanh Việt', N'Lâm Đồng', '0944444444',
 N'Bộ phận thu ngân', N'Mua trà đen', N'Trần Thị Bình', N'Phạm Thị Dung',
 N'Trần Thị Bình', 'ND002'),

('DN005', '2026-06-03', N'Vựa Trái Cây Tươi Cao Lãnh', N'Đồng Tháp', '0955555555',
 N'Bộ phận thu ngân', N'Mua cam tươi', N'Trần Thị Bình', N'Phạm Thị Dung',
 N'Trần Thị Bình', 'ND002');
GO

INSERT INTO C_T_DNLMUA
(ma_nl, so_dnlm, soluongdenghi, dongiadukien)
VALUES
('NL001', 'DN001', 10, 120000),
('NL002', 'DN002', 20, 30000),
('NL003', 'DN003', 15, 25000),
('NL006', 'DN003', 10, 45000),
('NL004', 'DN004', 8, 150000),
('NL008', 'DN005', 30, 20000);
GO


/* =========================================================
   6. PHIẾU NHẬP HÀNG
   ========================================================= */

INSERT INTO P_NH
(so_pnh, ma_ncc, so_dnlm, ngaygiao, thoigiangiaohang,
 tenkhachhang, nguoigiaohang, nguoinhanhang,
 ma_nl, soluonggiao, tennguyenlieu, thanhtien, tennd, ma_nd)
VALUES
('PN001', 'NCC001', 'DN001', '2026-06-02', '08:00:00',
 N'Thuận Coffee Take Away', N'Lê Văn Giao', N'Lê Văn Cường',
 'NL001', 10, N'Cà phê hạt', 1200000, N'Lê Văn Cường', 'ND003'),

('PN002', 'NCC002', 'DN002', '2026-06-02', '09:30:00',
 N'Thuận Coffee Take Away', N'Nguyễn Văn Hùng', N'Lê Văn Cường',
 'NL002', 20, N'Sữa tươi', 600000, N'Lê Văn Cường', 'ND003'),

('PN003', 'NCC003', 'DN003', '2026-06-03', '10:15:00',
 N'Thuận Coffee Take Away', N'Trần Văn Hải', N'Lê Văn Cường',
 'NL003', 15, N'Đường', 375000, N'Lê Văn Cường', 'ND003'),

('PN004', 'NCC004', 'DN004', '2026-06-03', '13:45:00',
 N'Thuận Coffee Take Away', N'Phạm Văn Sơn', N'Lê Văn Cường',
 'NL004', 8, N'Trà đen', 1200000, N'Lê Văn Cường', 'ND003'),

('PN005', 'NCC005', 'DN005', '2026-06-04', '07:30:00',
 N'Thuận Coffee Take Away', N'Võ Văn Phúc', N'Lê Văn Cường',
 'NL008', 30, N'Cam tươi', 600000, N'Lê Văn Cường', 'ND003');
GO

INSERT INTO C_T_PNH
(so_pnh, ma_nl, soluonggiao, tinhtrang, ghichu)
VALUES
('PN001', 'NL001', 10, N'Đạt', N'Hàng còn nguyên bao bì'),
('PN002', 'NL002', 20, N'Đạt', N'Đủ số lượng'),
('PN003', 'NL003', 15, N'Đạt', N'Không rách bao'),
('PN003', 'NL006', 10, N'Đạt', N'Trân châu mới'),
('PN004', 'NL004', 8, N'Đạt', N'Hạn sử dụng còn dài'),
('PN005', 'NL008', 30, N'Đạt', N'Cam tươi');
GO


/* =========================================================
   7. PHIẾU KIỂM KÊ
   ========================================================= */

INSERT INTO P_KK
(so_pkk, ma_ncc, ngaykiemke, thoigiankiemke,
 nguoithuchienkiemke, nguoigiamsat, tennd, ma_nd)
VALUES
('KK001', 'NCC001', '2026-06-02', '09:00:00', N'Lê Văn Cường', N'Phạm Thị Dung', N'Lê Văn Cường', 'ND003'),
('KK002', 'NCC002', '2026-06-02', '10:00:00', N'Lê Văn Cường', N'Phạm Thị Dung', N'Lê Văn Cường', 'ND003'),
('KK003', 'NCC003', '2026-06-03', '11:00:00', N'Lê Văn Cường', N'Phạm Thị Dung', N'Lê Văn Cường', 'ND003'),
('KK004', 'NCC004', '2026-06-03', '14:30:00', N'Lê Văn Cường', N'Phạm Thị Dung', N'Lê Văn Cường', 'ND003'),
('KK005', 'NCC005', '2026-06-04', '08:00:00', N'Lê Văn Cường', N'Phạm Thị Dung', N'Lê Văn Cường', 'ND003');
GO

INSERT INTO C_T_PKK
(so_pkk, ma_nl, soluongtheokiemke, soluongthucte, chenhlech,
 hansudung, tinhtrangchatluong, ghichu)
VALUES
('KK001', 'NL001', 10, 10, 0, '2027-06-01', N'Đạt', N'Đủ số lượng'),
('KK002', 'NL002', 20, 20, 0, '2026-07-01', N'Đạt', N'Bảo quản lạnh'),
('KK003', 'NL003', 15, 14, -1, '2027-01-01', N'Đạt', N'Thiếu 1 kg'),
('KK003', 'NL006', 10, 10, 0, '2026-09-01', N'Đạt', N'Đủ số lượng'),
('KK004', 'NL004', 8, 8, 0, '2027-03-01', N'Đạt', N'Đủ số lượng'),
('KK005', 'NL008', 30, 28, -2, '2026-06-10', N'Đạt', N'Hao hụt 2 kg');
GO


/* =========================================================
   8. SAO LƯU - LỊCH SỬ - NHẬT KÝ
   ========================================================= */

INSERT INTO SAOLUUDULIEU
(ma_saoluu, thoigiansaoluu, tenfile, duongdanfile, trangthai, ghichu, ma_nd)
VALUES
('SL001', '2026-06-01 22:00:00', N'backup_20260601.bak', N'D:\Backup\backup_20260601.bak', 1, N'Sao lưu cuối ngày', 'ND004'),
('SL002', '2026-06-02 22:00:00', N'backup_20260602.bak', N'D:\Backup\backup_20260602.bak', 1, N'Sao lưu cuối ngày', 'ND004'),
('SL003', '2026-06-03 22:00:00', N'backup_20260603.bak', N'D:\Backup\backup_20260603.bak', 1, N'Sao lưu cuối ngày', 'ND004'),
('SL004', '2026-06-04 22:00:00', N'backup_20260604.bak', N'D:\Backup\backup_20260604.bak', 1, N'Sao lưu cuối ngày', 'ND004'),
('SL005', '2026-06-05 22:00:00', N'backup_20260605.bak', N'D:\Backup\backup_20260605.bak', 1, N'Sao lưu cuối ngày', 'ND004');
GO

INSERT INTO LICHSUTRUYCAP
(ma_ls, ma_nd, thoigiandangnhap, thoigiandangxuat, trangthai)
VALUES
('LS001', 'ND001', '2026-06-01 07:30:00', '2026-06-01 16:30:00', N'Đăng xuất'),
('LS002', 'ND002', '2026-06-01 07:45:00', '2026-06-01 17:00:00', N'Đăng xuất'),
('LS003', 'ND003', '2026-06-01 08:00:00', '2026-06-01 17:30:00', N'Đăng xuất'),
('LS004', 'ND004', '2026-06-01 09:00:00', '2026-06-01 18:00:00', N'Đăng xuất'),
('LS005', 'ND005', '2026-06-02 07:30:00', '2026-06-02 16:30:00', N'Đăng xuất');
GO

INSERT INTO NHATKYHOATDONG
(ma_nk, thoigian, noidung, ttcu, ttmoi, ma_ls)
VALUES
('NK001', '2026-06-01 08:16:00', N'Lập phiếu gọi đồ uống PG001', NULL, N'PG001 được tạo', 'LS001'),
('NK002', '2026-06-01 08:31:00', N'Lập hóa đơn bán đồ uống HD001', NULL, N'HD001 được tạo', 'LS002'),
('NK003', '2026-06-01 10:00:00', N'Cập nhật menu đồ uống', N'Giá cũ', N'Giá mới', 'LS003'),
('NK004', '2026-06-02 08:05:00', N'Lập phiếu nhập hàng PN001', NULL, N'PN001 được tạo', 'LS003'),
('NK005', '2026-06-02 09:05:00', N'Lập phiếu kiểm kê KK001', NULL, N'KK001 được tạo', 'LS003');
GO