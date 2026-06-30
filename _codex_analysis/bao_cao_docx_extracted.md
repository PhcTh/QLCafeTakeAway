# Extracted text: 24_2_TranMinhThuan_QLBH_takeaway.docx

HỌC VIỆN KỸ THUẬT QUÂN SỰ
VIỆN CÔNG NGHỆ THÔNG TIN VÀ TRUYỀN THÔNG
24 – Trần Minh Thuận
ĐTH K58
BÀI TẬP HỌC PHẦN
PHÂN TÍCH THIẾT KẾ HỆ THỐNG
02 – Quản lý bán hàng quán cà phê take away
HÀ NỘI, 05/2026
HỌC VIỆN KỸ THUẬT QUÂN SỰ
VIỆN CÔNG NGHỆ THÔNG TIN VÀ TRUYỀN THÔNG
24 – Trần Minh Thuận
ĐTH K58
BÀI TẬP HỌC PHẦN
PHÂN TÍCH THIẾT KẾ HỆ THỐNG
02 – Quản lý bán hàng quán cà phê take away
Giáo viên phụ trách: Nguyễn Hoài Anh
HÀ NỘI, 05/2026
## LỜI NÓI ĐẦU
Trong thực tiễn hiện nay, mô hình kinh doanh cà phê take away ngày càng phổ biến do phù hợp với nhịp sống nhanh của nhiều khách hàng, đặc biệt là học sinh, sinh viên và nhân viên văn phòng. Với đặc điểm phục vụ nhanh, số lượng đơn hàng có thể phát sinh liên tục trong ngày, cửa hàng cần quản lý chính xác các thông tin như món uống, giá bán, hóa đơn, nhân viên, thanh toán và doanh thu. Tuy nhiên, nếu các công việc này được thực hiện thủ công bằng sổ sách hoặc ghi chép đơn giản thì rất dễ xảy ra nhầm lẫn trong quá trình nhận order, tính tiền, cập nhật số lượng sản phẩm cũng như thống kê doanh thu cuối ngày.
Bên cạnh đó, việc quản lý thủ công còn gây mất thời gian, khó tra cứu thông tin khi cần thiết và làm giảm hiệu quả phục vụ khách hàng, đặc biệt vào những thời điểm đông khách. Chủ cửa hàng cũng gặp khó khăn trong việc theo dõi tình hình kinh doanh, kiểm soát doanh thu theo ngày, theo ca làm việc hoặc theo từng sản phẩm bán ra. Chính từ thực tiễn đó, em lựa chọn đề tài “Quản lý bán hàng cà phê take away” nhằm xây dựng một hệ thống hỗ trợ quá trình bán hàng được nhanh chóng, chính xác và khoa học hơn. Hệ thống giúp nhân viên dễ dàng tiếp nhận đơn hàng, xử lý thanh toán, quản lý hóa đơn, đồng thời hỗ trợ chủ cửa hàng theo dõi hoạt động kinh doanh và nâng cao hiệu quả quản lý.
Báo cáo được chia thành 3 chương chính:
Chương 1: Khảo sát hệ thống
Chương 2: Phân tích hệ thống
Chương 3: Thiết kế hệ thống
Trong quá trình thực hiện đề tài, do thời gian và kinh nghiệm còn hạn chế nên hệ thống vẫn còn một số thiếu sót nhất định. Một số chức năng có thể chưa được xây dựng đầy đủ hoặc chưa thật sự tối ưu, giao diện còn đơn giản và khả năng xử lý dữ liệu chưa đáp ứng được hết các tình huống thực tế phát sinh. Bên cạnh đó, việc phân tích yêu cầu và thiết kế hệ thống có thể vẫn chưa bao quát toàn bộ quy trình quản lý bán hàng. Vì vậy, đề tài cần được tiếp tục nghiên cứu, hoàn thiện và mở rộng thêm trong tương lai để hệ thống hoạt động hiệu quả và phù hợp hơn với thực tế.
## QUY TẮC ĐÁNH MÃ

### [TABLE 1]
| STT | Mã | Ý nghĩa |
| 1. | MTN | Môi trường ngoài |
| 2. | MTT | Môi trường trong |
| 3. | BP | Bộ phận |
| 4. | QT | Quy trình nghiệp vụ |
| 5. | MB | Mẫu biểu |
| 6. | K | Kho dữ liệu |
| 7. | B | Bảng quan hệ |
| 8. | N | Nhóm người dùng |
| 9. | C | Đơn chọn ngang |

MỤC LỤC
LỜI NÓI ĐẦU 3
QUY TẮC ĐÁNH MÃ 4
TÓM TẮT ĐỀ TÀI 7
NỘI DUNG CHÍNH 14
Chương 1. KHẢO SÁT HỆ THỐNG 14
1.1. Mô tả hệ thống 14
1.1.1. Nhiệm vụ cơ bản 14
1.1.2. Cơ cấu tổ chức 14
1.1.3. Quy trình xử lý và quy tắc quản lý 15
1.1.4. Mẫu biểu 19
1.2. Mô hình hóa hệ thống 30
1.2.1. Mô hình tiến trình nghiệp vụ (TTNV) 30
1.2.2. Biểu đồ hoạt động 33
Chương 2. PHÂN TÍCH HỆ THỐNG 44
2.1. Phân tích chức năng nghiệp vụ 44
2.1.1. Mô hình hóa chức năng nghiệp vụ 44
2.1.2. Mô hình hóa tiến trình nghiệp vụ 62
2.1.3. Đặc tả tiến trình nghiệp vụ 69
2.2. Phân tích dữ liệu nghiệp vụ 76
2.2.1. Mô hình dữ liệu ban đầu 76
2.2.2. Chuẩn hóa dữ liệu 81
2.2.3. Đặc tả dữ liệu 95
Chương 3. THIẾT KẾ HỆ THỐNG 103
3.1. Thiết kế tổng thể 103
3.1.1. Xác định tiến trình hệ thống 103
3.1.2. Xác định kho dữ liệu hệ thống 116
3.1.3. DFD hệ thống 123
3.2. Thiết kế kiểm soát 124
3.2.1. Xác định nhóm người dùng 124
3.2.2. Phân định quyền hạn nhóm người dùng 125
3.3. Thiết kế cơ sở dữ liệu 143
3.3.1. Đánh giá nhu cầu bảo mật 143
3.3.2. Đánh giá nhu cầu cải thiện tính hiệu quả 147
3.3.3. Mô hình dữ liệu hệ thống 154
3.3.4. Đặc tả bảng dữ liệu 155
3.4. Thiết kế giao diện người – máy 173
3.4.1. Thiết kế hệ thống đơn chọn 173
3.4.2. Thiết kế form nhập liệu cho danh mục 175
3.4.3. Thiết kế form xử lý nghiệp vụ 193
3.4.4. Thiết kế báo cáo 223
ĐÁNH GIÁ CÔNG VIỆC VÀ KẾT LUẬN 231
TÀI LIỆU THAM KHẢO 232
## TÓM TẮT ĐỀ TÀI
Phần 1. Tóm tắt thành phần đánh mã
Môi trường

### [TABLE 2]
| STT | Mã môi trường | Tên môi trường |
| 1 | MTN.01 | Khách hàng |
| 2 | MTN.02 | Nhà cung cấp |
| 3 | MTT.01 | Người quản lý |

Bộ phận

### [TABLE 3]
| STT | Mã bộ phận | Tên bộ phận |
| 1 | BP.01 | Bộ phận phục vụ |
| 2 | BP.02 | Bộ phận thu ngân |
| 3 | BP.03 | Bộ phận pha chế |

Quy trình nghiệp vụ

### [TABLE 4]
| STT | Mã quy trình | Tên quy trình |
| 1 | QT.01 | Gọi đồ uống |
| 2 | QT.02 | Thanh toán cho khách |
| 3 | QT.03 | Nhập hàng hoá, nguyên liệu pha chế |
| 4 | QT.04 | Báo cáo doanh thu ngày |
| 5 | QT.05 | Báo cáo đồ uống bán chạy trong tháng |

Mẫu biểu

### [TABLE 5]
| STT | Mã mẫu biểu | Tên mẫu biểu |
| 1 | MB.01 | Menu |
| 2 | MB.02 | Phiếu gọi đồ uống |
| 3 | MB.03 | Phiếu tạm tính |
| 4 | MB.04 | Hóa đơn bán đồ uống |
| 5 | MB.05 | Đơn nguyên liệu mua |
| 6 | MB.06 | Phiếu nhập hàng |
| 7 | MB.07 | Phiếu kiểm kê |
| 8 | MB.08 | Báo cáo doanh thu ngày theo ngày |
| 9 | MB.09 | Biên bản đối soát doanh thu |
| 10 | MB.10 | Báo cáo đồ uống bán chạy trong tháng |

Kho dữ liệu

### [TABLE 6]
| STT | Mã kho | Tên kho |
| 1 | K.01 | Đồ uống |
| 2 | K.02 | Nguyên liệu |
| 3 | K.03 | Phiếu gọi đồ uống |
| 4 | K.04 | Hóa đơn bán đồ uống |
| 5 | K.05 | Đơn nguyên liệu mua |
| 6 | K.06 | Phiếu nhập hàng |
| 7 | K.07 | Phiểu kiểm kê |

Bảng dữ liệu

### [TABLE 7]
| STT | Mã bảng | Tên bảng |
| 1 | B02 | NL |
| 2 | B03 B03.1 | DU DU_NL |
| 3 | B04 | K_H |
| 4 | B05 | NCC |
| 5 | B06 B06.1 | P_G_DU C_T_PGĐU |
| 6 | B07 B07.1 | HD_BDU C_T_HDBĐU |
| 7 | B08 B08.1 | D_NLM C_T_ĐNLM |
| 8 | B09 B09.1 | P_NH C_T_PNH |
| 9 | B10 B10.1 | P_KK C_T_PKK |
| 10 | B01 | LDU |

7. Nhóm người dùng

### [TABLE 8]
| STT | Mã nhóm | Tên nhóm |
| 1 | N01 | Nhân viên phục vụ |
| 2 | N02 | Nhân viên thu ngân |
| 3 | N03 | Nhân viên pha chế |
| 4 | N04 | Người quản trị |

8. Hệ thống đơn chọn

### [TABLE 9]
| STT | Mã đơn chọn | Tên đơn chọn |
| 1 | C01 | Nhân viên phục vụ |
| 2 | C02 | Nhân viên thu ngân |
| 3 | C03 | Nhân viên pha chế |
| 4 | C04 | Người quản trị |

Phần 2. Mối liên quan giữa các thành phần đánh mã
Môi trường

### [TABLE 10]
| STT | Khảo sát | PT chức năng | PT dữ liệu |
| 1 | MTN.01. Khách hàng |  | B04 |
| 2 | MTN.02. Nhà cung cấp |  | B05 |
| 3 | MTT.01. Người quản lý |  |  |

Bộ phận

### [TABLE 11]
| STT | Khảo sát | PT chức năng | Nhóm người dùng |
| 1 | BP.01. Bộ phận phục vụ | 01. Quản lý bán hàng | N01. Nhân viên phục vụ |
| 2 | BP.02. Bộ phận thu ngân | 02. Quản lý thu chi | N02. Nhân viên thu ngân |
| 3 | BP.03. Bộ phận pha chế | 03. Quản lý nguyên liệu và pha chế | N03. Nhân viên pha chế |

Quy trình nghiệp vụ

### [TABLE 12]
| STT | Khảo sát | PT chức năng | Hệ thống đơn chọn | PT dữ liệu |
| 1 | QT.01.Gọi đồ uống | 01.01. Lập phiếu gọi đồ uống | C01.01. Lập phiếu gọi đồ uống | B03. DU (*) B03.1. DU_NL B04. K_H (*) B06. P_G_DU B06.1. C_T_PGĐU |
| 1 | QT.01.Gọi đồ uống | 01.02. Cập nhật trạng thái phục vụ đồ uống | C01.01. Lập phiếu gọi đồ uống C01.02. Cập nhật trạng thái phục vụ đồ uống | B03. DU B03.1. DU_NL B04. K_H B06. P_G_DU B06.1. C_T_PGĐU |
| 1 | QT.01.Gọi đồ uống | 03.01. Cập nhật trạng thái pha chế (*) | C01.01. Lập phiếu gọi đồ uống C03.01. Cập nhật trạng thái pha chế | B03. DU B03.1. DU_NL B04. K_H B06. P_G_DU B06.1. C_T_PGĐU |
| 1 | QT.01.Gọi đồ uống | 03.02. Cập nhật Menu | C03.02. Cập nhật Menu | B03. DU B03.1. DU_NL B01. LDU |
| 2 | QT.02.Thanh toán cho khách | 01.01. Lập phiếu gọi đồ uống | C01.01. Lập phiếu gọi đồ uống | B03. DU B03.1. DU_NL B04. K_H B06. P_G_DU B06.1. C_T_PGĐU |
| 2 | QT.02.Thanh toán cho khách | 02.01. Lập hóa đơn bán đồ uống (*) | C02.01.Lập hóa đơn bán đồ uống | B03. DU B03.1. DU_NL B04. K_H B07. HD_BDU B07.1. C_T_HDBĐU |
| 3 | QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp | 02.02. Lập đơn nguyên liệu mua | C02.02.Lập đơn nguyên liệu mua | B02. NL B05. NCC B08. D_NLM B08.1. C_T_ĐNLM |
| 3 | QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp | 03.03. Lập phiếu nhập hàng | C03.03.Lập phiếu nhập hàng | B02. NL B05. NCC B09. P_NH B09.1. C_T_PNH |
| 3 | QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp | 03.04. Lập phiếu kiểm kê | C03.04. Lập phiếu kiểm kê | B02. NL B05. NCC B10. P_KK B10.1. C_T_PKK |
|  |  | 03.05. Cập nhật nguyên liệu | C03.05. Cập nhật nguyên liệu | B02. NL B05. NCC B10. P_KK B10.1. C_T_PKK |
| 4 | QT.04. Báo cáo doanh thu ngày | 02.03. Lập Thống kê doanh thu ngày | C02.03. Lập Thống kê doanh thu ngày | B03. DU B03.1. DU_NL B07. HD_BDU B07.1. C_T_HDBĐU |
| 4 | QT.04. Báo cáo doanh thu ngày | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | C02.04. Lập biên bản đối soát chênh lệch doanh thu | B03. DU B03.1. DU_NL B07. HD_BDU B07.1. C_T_HDBĐU |
| 5 | QT.05. Báo cáo đồ uống bán chạy trong tháng | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | C02.05. Lập thống kê đồ uống bán chạy trong tháng | B03. DU B03.1. DU_NL B07. HD_BDU B07.1. C_T_HDBĐU |

Mẫu biểu

### [TABLE 13]
| STT | Khảo sát | PT chức năng | PT dữ liệu | Hệ thống đơn chọn |
| 1 | MB.01. Menu |  |  | C03.02. Cập nhật Menu |
| 2 | MB.02. Phiếu gọi đồ uống | K.03. Phiếu gọi đồ uống | B06. P_G_DU B06.1. C_T_PGĐU | C01.01. Lập phiếu gọi đồ uống |
| 3 | MB.03. Phiếu tạm tính |  | B03. DU B03.1. DU_NL B04. K_H | C01.02. Cập nhật trạng thái phục vụ đồ uống |
| 4 | MB.04. Hóa đơn bán đồ uống (*) | K.04. Hóa đơn bán đồ uống | B07. HD_BDU B07.1. C_T_HDBĐU | C02.01. Lập hóa đơn bán đồ uống |
| 5 | MB.05. Đơn nguyên liệu mua | K.05. Đơn nguyên liệu mua | B08. D_NLM B08.1. C_T_ĐNLM | C02.02. Lập đơn nguyên liệu mua |
| 6 | MB.06. Phiếu nhập hàng | K.06. Phiếu nhập hàng | B09. P_NH B09.1. C_T_PNH | C03.03. Lập phiếu nhập hàng |
| 7 | MB.07. Phiếu kiểm kê | K.07. Phiếu kiểm kê | B10. P_KK B10.1. C_T_PKK | C03.04. Lập phiếu kiểm kê |
| 8 | MB.08. Báo cáo doanh thu theo ngày |  |  | C02.03. Lập Thống kê doanh thu ngày |
| 9 | MB.09. Biên bản đối soát doanh thu |  |  | C02.04. Lập biên bản đối soát chênh lệch doanh thu |
| 10 | MB.10. Báo cáo đồ uống bán chạy trong tháng (*) |  |  | C02.05. Lập thống kê đồ uống bán chạy trong tháng |

## NỘI DUNG CHÍNH
### Chương 1. KHẢO SÁT HỆ THỐNG
#### 1.1. Mô tả hệ thống
##### 1.1.1. Nhiệm vụ cơ bản
- Xử lý yêu cầu bán đồ uống cho khách hàng (MTN.01).
- Xử lý yêu cầu thanh toán tiền đồ uống với khách hàng (MTN.01).
- Xử lý yêu cầu nhập nguyên liệu pha chế từ nhà cung cấp (MTN.02).
- Xử lý yêu cầu thanh toán tiền nguyên liệu với nhà cung cấp (MTN.02)
##### 1.1.2. Cơ cấu tổ chức

### [TABLE 14]
| STT | Bộ phận | Chức năng chính | Quy trình tham gia |
| 1 | BP.01.Bộ phận phục vụ | Lập phiếu gọi đồ uống Cập nhật trạng thái phục vụ đồ uống | QT.01, QT.02 |
| 2 | BP.02. Bộ phận thu ngân | Lập hóa đơn bán đồ uống Lập đơn nguyên liệu mua Lập thống kê doanh thu ngày Lập biên bản Đối soát chênh lệch doanh thu Lập Thống kê đồ uống bán chạy trong tháng | QT.01, QT.02, QT.03, QT.04, QT.05 |
| 3 | BP.03. Bộ phận pha chế | Cập nhật trạng thái pha chế Cập nhật Menu Lập phiếu nhập hàng Lập phiếu kiểm kê Cập nhật nguyên liệu | QT.01, QT.03 |

##### 1.1.3. Quy trình xử lý và quy tắc quản lý
(1) Bảng 1. Bảng tổng hợp quy trình nghiệp vụ

### [TABLE 15]
| STT | Quy trình | Mẫu biểu sử dụng | Môi trường tham gia | Bộ phận tham gia |
| 1 | QT.01. Gọi đồ uống | MB.01, MB.02 | MTN.01 | BP.01, BP.02, BP.03 |
| 2 | QT.02. Thanh toán cho khách | MB.03, MB.04 | MTN.01 | BP.01, BP.02 |
| 3 | QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp | MB.05, MB.06, MB.07 | MTN.02 | BP.02, BP.03 |
| 4 | QT.04. Báo cáo doanh thu ngày | MB.04, MB.08, MB.09 | MTT.01 | BP.02 |
| 5 | QT.05. Báo cáo đồ uống bán chạy trong tháng | MB.04, MB10 | MTT.01 | BP.02 |

(2) Nội dung chi tiết của quy trình nghiệp vụ
QT.01. Gọi đồ uống :
Bộ phận phục vụ hướng dẫn gọi đồ uống(1) cho khách hàng.
Bộ phận phục vụ yêu cầu khách hàng gọi đồ uống (2).
Bộ phận phục vụ theo Menu (MB.01) rồi lập Phiếu gọi đồ uống (MB.02) (3) của khách.
Bộ phận phục vụ xác nhận Phiếu gọi đồ uống (MB.02) với khách hàng (4).
Kiểm tra yêu cầu khách hàng (5):
Nếu thay đổi: bộ phận phục vụ điều chỉnh Phiếu gọi đồ uống (MB.02) (6).
Nếu không thay đổi: bộ phận phục vụ chuyển Phiếu gọi đồ uống (MB.02) (7) cho bộ phận thu ngân.
Bộ phận thu ngân xác nhận phiếu gọi đồ uống (8) rồi chuyển Phiếu gọi đồ uống (MB.02)(9) cho bộ phận pha chế.
Bộ phận pha chế tiếp nhận Phiếu gọi đồ uống (MB.02) (10) và kiểm tra số lượng nguyên liệu (11) còn lại:
Nếu hết nguyên liệu: bộ phận pha chế thông báo thay đổi đồ uống (12) cho bộ phận phục vụ. Bộ phận phục vụ yêu cầu khách đổi đồ uống khác(13), đồng thời thông báo trạng thái nguyên liệu (14) và cập nhật Menu(MB.01) (15).
Nếu khách đồng ý, bộ phận phục vụ sửa Phiếu gọi đồ uống (MB.02) (16) và chuyển cho khách hàng xác nhận (17), sau đó bộ phận phục chuyển Phiếu gọi đồ uống (MB.02) (18) cho bộ phận pha chế.
Nếu khách không đồng ý, kết thúc.
Nếu đủ nguyên liệu: bộ phận pha chế pha chế theo Phiếu gọi đồ uống (MB.02) (19). Sau đó, trả đồ uống đã pha chế (20) và cập nhật trạng thái pha chế (21).
Bộ phận thu ngân nhận thông báo pha chế hoàn tất (22) sau đó nhận đồ uống (23) từ bộ phận pha chế và đối chiếu với Phiếu gọi đồ uống (MB.02) (24) của khách hàng.
Nếu chưa đúng yêu cầu, yêu cầu pha chế lại (25) với bộ phận pha chế rồi nhận đồ uống (26) từ bộ phận pha chế và chuyển đồ uống (27) cho bộ phận phục vụ để giao đồ uống (28) cho khách hàng
Nếu đúng yêu cầu, bộ phận thu ngân chuyển đồ uống (29) cho bộ phận phục vụ và bộ phận phục vụ sẽ giao đồ uống (30) cho khách.
QT.02. Thanh toán cho khách :
Bộ phận phục vụ kiểm tra hình thức thanh toán khách hàng (31)
Nếu chuyển khoản: bộ phận phục vụ yêu cầu đối chiếu thông tin chuyển khoản (32) kèm với chuyển yêu cầu lập Phiếu tạm tính (MB.03) (33).
Nếu tiền mặt/khác: yêu cầu lập Phiếu tạm tính (MB.03) (34) với bộ phận thu ngân.
Bộ phận thu ngân tiếp nhận yêu cầu (35), yêu cầu thông tin khách hàng (36) rồi lập Phiếu tạm tính (MB.03). (37)
Bộ phận phục vụ tiếp nhận Phiếu tạm tính (MB.03) (38) và chuyển Phiếu tạm tính (MB.03) cho khách hàng xác nhận. (39)
Nếu chưa chính xác: bộ phận phục vụ yêu cầu chỉnh sửa lại thông tin trên phiếu tạm tính (MB.03) (40). Bộ phận thu ngân tiếp nhận yêu cầu (41) rồi chỉnh sửa Phiếu tạm tính (MB.03) (42).
Bộ phận phục vụ tiếp nhận Phiếu tạm tính (MB.03) đã ký (43) của khách hàng rồi chuyển Phiếu tạm tính (MB.03) đã ký (44) cho bộ phận phục vụ và yêu cầu lập Hóa đơn bán đồ uống (MB.04) (45) với bộ phận thu ngân.
Bộ phận thu ngân kiểm tra thông tin Phiếu tạm tính (MB.03) (46) rồi lập Hóa đơn bán đồ uống (MB.04) (47) và chuyển Hóa đơn bán đồ uống (MB.04) (48) cho bộ phận phục vụ.
Bộ phận phục vụ tiếp nhận Hóa đơn bán đồ uống (MB.04) (49) và chuyển hóa đơn cho khách. (50)
QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp :
Bộ phận pha chế kiểm tra tình trạng nguyên liệu của quán (51) và yêu cầu nguyên liệu cần bổ sung (52) với bộ phận thu ngân.
Bộ phận thu ngân sẽ lập Đơn nguyên liệu mua (MB.05) (53) và chuyển Đơn nguyên liệu mua (MB.05) (54) cho nhà cung cấp.
Nếu không đủ nguyên liệu: bộ phận thu ngân điều chỉnh Đơn nguyên liệu mua (MB.05). (55)
Bộ phận thu ngân lập Phiếu nhập hàng (MB.06)(56) sau đó, kiểm tra nguyên liệu (57) và chuyển nguyên liệu (58) đến bộ phận pha chế.
Bộ phận pha chế kiểm tra nguyên liệu (59) và lập Phiếu kiểm kê (MB.07).(60)
Nếu nguyên liệu lỗi/thiếu: Bộ phận pha chế chuyển Phiếu kiểm kê (MB.07) (61) cho bộ phận thu ngân và yêu cầu kiểm tra Phiếu kiểm kê (MB.07) (62) và yêu cầu thay đổi, bổ sung nguyên liệu (63).
Nếu nguyên liệu đạt chuẩn: bộ phận pha chế xác nhận nguyên liệu đạt yêu cầu (64), sắp xếp nguyên liệu (65) rồi cập nhật thông tin nguyên liệu pha chế (66).
QT.04. Báo cáo doanh thu ngày :
Cuối ngày, bộ phận thu ngân thống kê doanh thu ngày (67).
Bộ phận thu ngân kiểm tra thực tế số tiền thu được (68) và đối chiếu với dữ liệu hệ thống (69).
Nếu chênh lệch với hóa đơn: bộ phận thu ngân lập Biên bản đối soát doanh thu (MB.08) (70).
Nếu không chênh lệch: bộ phận thu ngân lập Báo cáo doanh thu ngày (MB.09). (71)
Người quản lý kiểm tra và đưa ra kết luận.
Nếu phát hiện vi phạm (có chênh lệch bất thường): người quản lý đưa ra biện pháp xử lý. Bộ phận thu ngân thực hiện biện pháp xử lý chênh lệch doanh thu (72).
QT.05. Báo cáo đồ uống bán chạy trong tháng :
Vào cuối tháng, bộ phận thu ngân tổng hợp Hóa đơn bán đồ uống (MB.04) trong tháng (73) để thu thập thông tin bán ra của từng đồ uống (74).
Bộ phận thu ngân kiểm tra đồ uống số lượng bán ra nhiều nhất (75) và sắp xếp theo thứ tự từ trên xuống (76) theo số lượng.
Dựa trên số liệu đã sắp xếp, bộ phận thu ngân lập Báo cáo đồ uống bán chạy trong tháng (MB.10) (77) và gửi người quản lý.
##### 1.1.4. Mẫu biểu
(1) Bảng 2. Bảng tổng hợp mẫu biểu

### [TABLE 16]
| STT | Mẫu biểu | Quy trình sử dụng | Bộ phận tạo ra | Là kiểu thực thể | Vai trò |
| 1 | MB.01. Menu | QT.01 | BP.03 |  |  |
| 2 | MB.02. Phiếu gọi đồ uống | QT.01 | BP.01 | 1 | K03.B06.1 |
| 3 | MB.03. Phiếu tạm tính | QT.02 | BP.02 |  |  |
| 4 | MB.04. Hóa đơn bán đồ uống | QT.02, QT.04, QT.05 | BP.02 | 2 | K04.B07.1 |
| 6 | MB.05. Đơn nguyên liệu mua | QT.03 | BP.02 | 3 | K05.B08.1 |
| 7 | MB.06. Phiếu nhập hàng | QT.03 | BP.03 | 4 | K06.B09.1 |
| 8 | MB.07. Phiếu kiểm kê | QT.03 | BP.03 | 5 | K07.B10.1 |
| 9 | MB.08. Báo cáo doanh thu theo ngày | QT.04 | BP.02 |  |  |
| 10 | MB.09. Biên bản đối soát doanh thu | QT.04 | BP.02 |  |  |
| 11 | MB.10. Báo cáo đồ uống bán chạy trong tháng | QT.05 | BP.02 |  |  |

(2) Chi tiết mẫu biểu
MB.01. Menu
MB.02. Phiếu gọi đồ uống
MB.03. Phiếu tạm tính
MB.04. Hóa đơn bán đồ uống
MB.05. Đơn nguyên liệu mua
MB.06. Phiếu nhập hàng
MB.07. Phiếu kiểm kê
MB.08. Báo cáo doanh thu theo ngày
MB.09. Biên bản đối soát doanh thu
MB.10. Báo cáo đồ uống bán chạy trong tháng
#### 1.2. Mô hình hóa hệ thống
##### 1.2.1. Mô hình tiến trình nghiệp vụ (TTNV)
(1) Giải thích kí hiệu
Ký hiệu sử dụng

### [TABLE 17]
| <Tên bộ phận> (<Mã bộ phận>) |
| <Chức năng 1> |
| <Chức năng 2> |
| … |

Bộ phận bên trong hệ thống:
Tác nhân tác động vào hệ thống:
Luồng thông tin:
(2) Bảng 3. Bảng tổng hợp thông tin mô hình TTNV

### [TABLE 18]
| Thành phần | Thành phần | Nội dung chi tiết | Nội dung chi tiết | Nội dung chi tiết |
| Tác nhân | Tác nhân | - MTN: MTN.01. Khách hàng MTN.02. Nhà cung cấp - MTT: MTT.01. Người quản lý | - MTN: MTN.01. Khách hàng MTN.02. Nhà cung cấp - MTT: MTT.01. Người quản lý | - MTN: MTN.01. Khách hàng MTN.02. Nhà cung cấp - MTT: MTT.01. Người quản lý |
| Bộ phận | Bộ phận | - BP.01. Bộ phận phục vụ - BP.02. Bộ phận thu ngân - BP.03. Bộ phận pha chế | - BP.01. Bộ phận phục vụ - BP.02. Bộ phận thu ngân - BP.03. Bộ phận pha chế | - BP.01. Bộ phận phục vụ - BP.02. Bộ phận thu ngân - BP.03. Bộ phận pha chế |
| Mẫu biểu đưa vào | Mẫu biểu đưa vào |  |  |  |
| Mẫu biểu tạo ra | Mẫu biểu tạo ra | Mẫu biểu tạo ra | Mẫu biểu tạo ra | Mẫu biểu tạo ra |
| STT | Mã MB | Tên mẫu biểu | BP tạo ra | Nơi sử dụng |
| 1 | MB.01 | Menu | BP.03 | MTN.01, BP.01, BP.02, BP.03 |
| 2 | MB.02 | Phiếu gọi đồ uống | BP.01 | MTN.01, BP.01, BP.02, BP.03 |
| 3 | MB.03 | Phiếu tạm tính | BP.02 | MTN.01, BP.01, BP.02 |
| 4 | MB.04 | Hóa đơn bán đồ uống | BP.02 | MTN.01, BP.01, BP.02 |
| 5 | MB.05 | Đơn nguyên liệu mua | BP.02 | MTN.01, BP02 |
| 6 | MB.06 | Phiếu nhập hàng | BP.03 | MTN.02, BP.02 |
| 7 | MB.07 | Phiếu kiểm kê | BP.03 | BP.02, BP.03 |
| 8 | MB.08 | Báo cáo doanh thu ngày theo ngày | BP.02 | MTT.01, BP.02 |
| 9 | MB.09 | Biên bản đối soát doanh thu | BP.02 | MTT.01, BP.02 |
| 10 | MB.10 | Báo cáo đồ uống bán chạy trong tháng | BP.02 | MTT.01, BP.02 |

(3) Mô hình tiến trình nghiệp vụ
##### 1.2.2. Biểu đồ hoạt động
(1) Giải thích kí hiệu
Điểm bắt đầu:
Điểm kết thúc:
Công việc nghiệp vụ:
Kho dữ liệu:
Điều kiện lựa chọn:
Mẫu biểu:
Luồng công việc:
Luồng dữ liệu:
(2) Biểu đồ hoạt động
QT.01. Gọi đồ uống
Bảng 4.1. Bảng tổng hợp thông tin biểu đồ hoạt động QT.01

### [TABLE 19]
| Thành phần | Nội dung chi tiết |
| Đường bơi | - Tác nhân: MTN.01. Khách hàng - Bộ phận: BP.01. Bộ phận phục vụ BP.02. Bộ phận thu ngân BP.03. Bộ phận pha chế |
| Đối tượng kích hoạt | - MTN.01. Khách hàng |
| Mẫu biểu liên quan | - MB.01. Menu - MB.02. Phiếu gọi đồ uống |
| Kho dữ liệu liên quan | - Nghiệp vụ: K03. Phiếu gọi đồ uống - Tài sản: K.01. Đồ uống K.02. Nguyên liệu |
| Điều kiện rẽ nhánh | 1. Đồng ý thay đổi? 2. Thay đổi yêu cầu? 3. Đồng ý? 4. Đồ uống hết? 5. Đúng yêu cầu? 6. Còn nguyên liệu? |

Biểu đồ hoạt động QT.01
QT02. Thanh toán khách hàng
Bảng 4.2. Bảng tổng hợp thông tin biểu đồ hoạt động QT.02

### [TABLE 20]
| Thành phần | Nội dung chi tiết |
| Đường bơi | - Tác nhân: MTN.01 Khách hàng - Bộ phận: BP.01. Bộ phận phục vụ BP.02. Bộ phận thu ngân |
| Đối tượng kích hoạt | - MTN.01. Khách hàng |
| Mẫu biểu liên quan | - MB.03. Phiếu tạm tính - MB.04. Hóa đơn bán đồ uống |
| Kho dữ liệu liên quan | - Nghiệp vụ: K.04. Hóa đơn bán đồ uống - Tài sản: K.01. Đồ uống |
| Điều kiện rẽ nhánh | 1. Thanh toán thành công? 2. Thông tin chính xác? |

Biểu đồ hoạt động QT.02
QT03. Nhập nguyên liệu pha chế từ nhà cung cấp
Bảng 4.3. Bảng tổng hợp thông tin biểu đồ hoạt động QT.03

### [TABLE 21]
| Thành phần | Nội dung chi tiết |
| Đường bơi | - Tác nhân: MTN.02. Nhà cung cấp - Bộ phận: BP.02. Bộ phận thu ngân BP.03. Bộ phận pha chế |
| Đối tượng kích hoạt | - BP.03. Bộ phận pha chế |
| Mẫu biểu liên quan | - MB.05. Đơn nguyên liệu mua - MB.06. Phiếu nhập hàng - MB.07. Phiếu kiểm kê |
| Kho dữ liệu liên quan | - Nghiệp vụ: K.05. Đơn nguyên liệu mua K.06. Phiếu nhập hàng K.07. Phiếu kiểm kê - Tài sản: K.02. Nguyên liệu |
| Điều kiện rẽ nhánh | 1. Đủ nguyên liệu? 2. Đạt chất lượng? 3. Hết nguyên liệu? 4. Nguyên liệu đạt chuẩn? |

Biểu đồ hoạt động QT.03
QT.04. Thống kê doanh thu ngày
Bảng 4.4. Bảng tổng hợp thông tin biểu đồ hoạt động QT.04

### [TABLE 22]
| Thành phần | Nội dung chi tiết |
| Đường bơi | - Tác nhân: MTT.01. Người quản lý - Bộ phận: BP.02. Bộ phận thu ngân |
| Đối tượng kích hoạt | - BP.02. Bộ phận thu ngân |
| Mẫu biểu liên quan | - MB.08. Báo cáo doanh thu ngày - MB.09. Biên bản đối soát doanh thu |
| Kho dữ liệu liên quan | - Nghiệp vụ: K.04. Hóa đơn bán đồ uống - Tài sản: K.01. Đồ uống |
| Điều kiện rẽ nhánh | 1. Vi phạm? 2. Chênh lệch với hóa đơn? |

Biểu đồ hoạt động QT.04
QT.05. Báo cáo đồ uống bán chạy trong tháng
Bảng 4.5. Bảng tổng hợp thông tin biểu đồ hoạt động QT.05

### [TABLE 23]
| Thành phần | Nội dung chi tiết |
| Đường bơi | - Tác nhân: MTT.01. Người quản lý - Bộ phận: BP.02. Bộ phận thu ngân |
| Đối tượng kích hoạt | - BP.02. Bộ phận thu ngân |
| Mẫu biểu liên quan | - MB10. Báo cáo đồ uống bán chạy trong tháng |
| Kho dữ liệu liên quan | - Nghiệp vụ: K.04. Hóa đơn bán đồ uống - Tài sản: K.01. Đồ uống |
| Điều kiện rẽ nhánh | Không có |

Biểu đồ hoạt động QT05
### Chương 2. PHÂN TÍCH HỆ THỐNG
#### 2.1. Phân tích chức năng nghiệp vụ
##### 2.1.1. Mô hình hóa chức năng nghiệp vụ
2.1.1.1. Xác định chức năng chi tiết
(1) Bước 1. Tổng hợp danh sách chức năng có thể của hệ thống

### [TABLE 24]
| QT | Bộ phân phục vụ BP.01 | Bộ phận thu ngân BP.02 | Bộ phận pha chế BP.03 |
| QT.01: Gọi đồ uống | (1) Hướng dẫn gọi đồ uống |  |  |
| QT.01: Gọi đồ uống | (2) Yêu cầu khách hàng gọi đồ uống |  |  |
| QT.01: Gọi đồ uống | (3) Lập phiếu gọi đồ uống |  |  |
| QT.01: Gọi đồ uống | (4) Xác nhận phiếu gọi đồ uống với khách hàng |  |  |
| QT.01: Gọi đồ uống | (5) Kiểm tra yêu cầu khách hàng |  |  |
| QT.01: Gọi đồ uống | (6) Điều chỉnh phiếu đồ uống |  |  |
| QT.01: Gọi đồ uống | (7) Chuyển phiếu gọi đồ uống |  |  |
| QT.01: Gọi đồ uống |  | (8) Xác nhận phiếu gọi đồ uống |  |
| QT.01: Gọi đồ uống |  | (9) Chuyển phiếu gọi đồ uống |  |
| QT.01: Gọi đồ uống |  |  | (10) Tiếp nhận phiếu gọi đồ uống |
| QT.01: Gọi đồ uống |  |  | (11) Kiểm tra số lượng nguyên liệu |
| QT.01: Gọi đồ uống |  |  | (12) Thông báo thay đổi đồ uống |
| QT.01: Gọi đồ uống | (13) Yêu cầu khách đổi đồ uống khác |  |  |
| QT.01: Gọi đồ uống | (14) Thông báo trạng thái nguyên liệu |  |  |
| QT.01: Gọi đồ uống | (15) Cập nhật Menu (MB.01) |  |  |
| QT.01: Gọi đồ uống | (16) Lập phiếu điều chỉnh đồ uống |  |  |
| QT.01: Gọi đồ uống | (17) Chuyển cho khách hàng xác nhận |  |  |
| QT.01: Gọi đồ uống | (18) Chuyển phiếu gọi đồ uống |  |  |
| QT.01: Gọi đồ uống |  |  | (19) Pha chế theo phiếu gọi đồ uống |
| QT.01: Gọi đồ uống |  |  | (20) Trả đồ uống đã pha chế |
| QT.01: Gọi đồ uống |  |  | (21) Cập nhật trạng thái pha chế |
| QT.01: Gọi đồ uống |  | (22) Nhận thông báo pha chế hoàn tất |  |
| QT.01: Gọi đồ uống |  | (23) Nhận đồ uống |  |
| QT.01: Gọi đồ uống |  | (24) Đối chiếu với phiếu gọi đồ uống |  |
| QT.01: Gọi đồ uống |  | (25) Yêu cầu pha chế lại |  |
| QT.01: Gọi đồ uống |  | (26) Nhận đồ uống |  |
| QT.01: Gọi đồ uống |  | (27) Chuyển đồ uống |  |
| QT.01: Gọi đồ uống | (28) Giao đồ uống |  |  |
| QT.01: Gọi đồ uống |  | (29) Chuyển đồ uống |  |
| QT.01: Gọi đồ uống | (30) Giao đồ uống |  |  |
| QT.02: Thanh toán cho khách | (31) Kiểm tra hình thức thanh toán khách hàng |  |  |
| QT.02: Thanh toán cho khách | (32) Yêu cầu đối chiếu thông tin chuyển khoản |  |  |
| QT.02: Thanh toán cho khách | (33) Chuyển yêu cầu lập phiếu tạm tính |  |  |
| QT.02: Thanh toán cho khách | (34) Yêu cầu lập phiếu tạm tính (MB.03) |  |  |
| QT.02: Thanh toán cho khách |  | (35) Tiếp nhận yêu cầu |  |
| QT.02: Thanh toán cho khách |  | (36) Yêu cầu thông tin khách hàng |  |
| QT.02: Thanh toán cho khách |  | (37) Lập phiếu tạm tính |  |
| QT.02: Thanh toán cho khách | (38) Tiếp nhận phiếu tạm tính |  |  |
| QT.02: Thanh toán cho khách | (39) Chuyển phiếu tạm tính cho khách hàng xác nhận |  |  |
| QT.02: Thanh toán cho khách | (40) Yêu cầu chỉnh sửa lại thông tin trên phiếu tạm tính |  |  |
| QT.02: Thanh toán cho khách |  | (41) Tiếp nhận yêu cầu |  |
| QT.02: Thanh toán cho khách |  | (42) Chỉnh sửa phiếu tạm tính |  |
| QT.02: Thanh toán cho khách | (43) Tiếp nhận phiếu tạm tính đã ký |  |  |
| QT.02: Thanh toán cho khách | (44) Chuyển phiếu tạm tính đã ký |  |  |
| QT.02: Thanh toán cho khách | (45) Yêu cầu lập hóa đơn bán đồ uống |  |  |
| QT.02: Thanh toán cho khách |  | (46) Kiểm tra thông tin phiếu tạm tính |  |
| QT.02: Thanh toán cho khách |  | (47) Lập hóa đơn bán đồ uống |  |
| QT.02: Thanh toán cho khách |  | (48) Chuyển hóa đơn bán đồ uống |  |
| QT.02: Thanh toán cho khách | (49) Tiếp nhận hóa đơn bán đồ uống |  |  |
| QT.02: Thanh toán cho khách | (50) Chuyển hóa đơn cho khách |  |  |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (51) Kiểm tra tình trạng nguyên liệu của quán |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (52) Yêu cầu nguyên liệu cần bổ sung |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  | (53) Lập đơn nguyên liệu mua |  |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  | (54) Chuyển đơn nguyên liệu mua |  |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  | (55) Lập đơn nguyên liệu mua |  |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  | (56) Lập phiếu nhập hàng |  |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  | (57) Kiểm tra nguyên liệu |  |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  | (58) Chuyển nguyên liệu |  |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (59) Kiểm tra nguyên liệu |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (60) Lập Phiếu kiểm kê số lượng, chất lượng nguyên liệu |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (61) Chuyển phiếu kiểm kê chất lượng, số lượng nguyên liệu |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (62) Yêu cầu kiểm tra phiếu kiểm kê |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (63) Yêu cầu thay đổi, bổ sung nguyên liệu |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (64) Xác nhận nguyên liệu đạt yêu cầu |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (65) Sắp xếp nguyên liệu |
| QT.03: Nhập nguyên liệu pha chế từ nhà cung cấp |  |  | (66) Cập nhật thông tin nguyên liệu pha chế |
| QT.04: Báo cáo doanh thu ngày |  | (67) Thống kê doanh thu ngày |  |
| QT.04: Báo cáo doanh thu ngày |  | (68) Kiểm tra thực tế số tiền thu được |  |
| QT.04: Báo cáo doanh thu ngày |  | (69) Đối chiếu với dữ liệu hệ thống |  |
| QT.04: Báo cáo doanh thu ngày |  | (70) Lập biên bản đối soát doanh thu |  |
| QT.04: Báo cáo doanh thu ngày |  | (71) Lập Báo cáo doanh thu ngày |  |
| QT.04: Báo cáo doanh thu ngày |  | (72) Thực hiện biện pháp xử lý chênh lệch doanh thu |  |
| QT.05: Báo cáo đồ uống bán chạy trong tháng |  | (73) Tổng hợp hóa đơn gọi đồ uống trong tháng |  |
| QT.05: Báo cáo đồ uống bán chạy trong tháng |  | (74) Thu thập thông tin bán ra của từng đồ uống |  |
| QT.05: Báo cáo đồ uống bán chạy trong tháng |  | (75) Kiểm tra đồ uống số lượng bán ra nhiều nhất |  |
| QT.05: Báo cáo đồ uống bán chạy trong tháng |  | (76) Sắp xếp theo thứ tự từ trên xuống |  |
| QT.05: Báo cáo đồ uống bán chạy trong tháng |  | (77) Lập Báo cáo đồ uống bán chạy trong tháng |  |

(2) Bước 2. Loại bỏ chức năng bị trùng lặp
(6), (16): Trùng lặp cùng BP.01: Lập phiếu điều chỉnh đồ uống.
(7), (18): Trùng lặp cùng BP.01: Chuyển phiếu gọi đồ uống.
(28), (30): Trùng lặp cùng BP.01: Giao đồ uống
(23), (26): Trùng lặp cùng BP.02: Nhận đồ uống.
(27), (29): Trùng lặp cùng BP.02: Chuyển đồ uống.
(35), (41): Trùng lặp cùng BP.02: Tiếp nhận yêu cầu.
(53), (55): Trùng lặp cùng BP.02: Lập đơn nguyên liệu mua.

### [TABLE 25]
| Bộ phân phục vụ (BP.01) | Bộ phận thu ngân (BP.02) | Bộ phận pha chế (BP.03) |
| (1) Hướng dẫn gọi đồ uống |  |  |
| (2) Yêu cầu thông tin khách hàng |  |  |
| (3) Lập phiếu gọi đồ uống |  |  |
| (4) Xác nhận phiếu gọi đồ uống với khách hàng |  |  |
| (5) Kiểm tra yêu cầu khách hàng |  |  |
| (6) Điều chỉnh phiếu đồ uống |  |  |
| (7) Chuyển phiếu gọi đồ uống |  |  |
|  | (8) Xác nhận phiếu gọi đồ uống |  |
|  | (9) Chuyển phiếu gọi đồ uống |  |
|  |  | (10) Tiếp nhận phiếu gọi đồ uống |
|  |  | (11) Kiểm tra số lượng nguyên liệu |
|  |  | (12) Thông báo thay đổi đồ uống |
| (13) Yêu cầu khách đổi đồ uống khác |  |  |
| (14) Thông báo trạng thái nguyên liệu |  |  |
| (15) Cập nhật Menu |  |  |
| (16) Chuyển cho khách hàng xác nhận |  |  |
|  |  | (17) Pha chế theo phiếu gọi đồ uống |
|  |  | (18) Trả đồ uống đã pha chế |
|  |  | (19) Cập nhật trạng thái pha chế |
|  | (20) Nhận thông báo pha chế hoàn tất |  |
|  | (21) Nhận đồ uống |  |
|  | (22) Đối chiếu với phiếu gọi đồ uống |  |
|  | (23) Yêu cầu pha chế lại |  |
|  | (24) Chuyển đồ uống |  |
| (25) Giao đồ uống |  |  |
| (26) Kiểm tra hình thức thanh toán khách hàng |  |  |
| (27) Yêu cầu đối chiếu thông tin chuyển khoản |  |  |
| (28) Chuyển yêu cầu lập phiếu tạm tính |  |  |
| (29) Yêu cầu lập phiếu tạm tính |  |  |
|  | (30) Tiếp nhận yêu cầu |  |
|  | (31) Yêu cầu thông tin khách hàng |  |
|  | (32) Lập phiếu tạm tính |  |
| (33) Tiếp nhận phiếu tạm tính |  |  |
| (34) Chuyển phiếu tạm tính cho khách hàng xác nhận |  |  |
| (35) Yêu cầu chỉnh sửa lại thông tin trên phiếu tạm tính |  |  |
|  | (36) Chỉnh sửa phiếu tạm tính |  |
| (37) Tiếp nhận phiếu tạm tính đã ký |  |  |
| (38) Chuyển phiếu tạm tính đã ký |  |  |
| (39) Yêu cầu lập hóa đơn bán đồ uống |  |  |
|  | (40) Kiểm tra thông tin phiếu tạm tính |  |
|  | (41) Lập hóa đơn bán đồ uống |  |
|  | (42) Chuyển hóa đơn bán đồ uống |  |
| (43) Tiếp nhận hóa đơn bán đồ uống |  |  |
| (44) Chuyển hóa đơn cho khách |  |  |
|  |  | (45) Kiểm tra tình trạng nguyên liệu của quán |
|  |  | (46) Yêu cầu nguyên liệu cần bổ sung |
|  | (47) Lập đơn nguyên liệu mua |  |
|  | (48) Chuyển đơn nguyên liệu mua |  |
|  | (49) Lập phiếu nhập hàng |  |
|  | (50) Kiểm tra nguyên liệu |  |
|  | (51) Chuyển nguyên liệu |  |
|  |  | (52) Kiểm tra nguyên liệu |
|  |  | (53) Lập Phiếu kiểm kê số lượng, chất lượng nguyên liệu |
|  |  | (54) Chuyển phiếu kiểm kê chất lượng, số lượng nguyên liệu |
|  |  | (55) Yêu cầu kiểm tra phiếu kiểm kê |
|  |  | (56) Yêu cầu thay đổi, bổ sung nguyên liệu |
|  |  | (57) Xác nhận nguyên liệu đạt yêu cầu |
|  |  | (58) Sắp xếp nguyên liệu |
|  |  | (59) Cập nhật thông tin nguyên liệu pha chế |
|  | (60) Thống kê doanh thu ngày |  |
|  | (61) Kiểm tra thực tế số tiền thu được |  |
|  | (62) Đối chiếu với dữ liệu hệ thống |  |
|  | (63) Lập biên bản đối soát doanh thu |  |
|  | (64) Lập Báo cáo doanh thu ngày |  |
|  | (65) Thực hiện biện pháp xử lý chênh lệch doanh thu |  |
|  | (66) Tổng hợp hóa đơn gọi đồ uống trong tháng |  |
|  | (67) Thu thập thông tin bán ra của từng đồ uống |  |
|  | (68) Kiểm tra đồ uống số lượng bán ra nhiều nhất |  |
|  | (69) Sắp xếp theo thứ tự từ trên xuống |  |
|  | (70) Lập Báo cáo đồ uống bán chạy trong tháng |  |

(3) Bước 3. Gom nhóm chức năng đơn giản
(3), (4): Đơn giản: Xử lý thông tin phiếu gọi đồ uống
(5), (6): Đơn giản: Lập phiếu điều chỉnh đồ uống
(26), (27), (28), (29), (33): Đơn giản: Xử lý yêu cầu lập phiếu tạm tính khách hàng
(34), (35), (37): Đơn giản: Xử lý xác nhận phiếu tạm tính
(39), (43), (44): Đơn giản: Xử lý trả hóa đơn bán đồ uống
(8), (9): Đơn giản: Xử lý xác nhận thông tin phiếu gọi đồ uống
(21), (22), (23), (24): Đơn giản: Xử lý phục vụ đồ uống mang về
(30), (31), (32), (36), (40), (41): Đơn giản: Lập hóa đơn bán đồ uống
(47), (48), (50), (51): Đơn giản: Xử lý mua nguyên liệu
(60), (64): Đơn giản: Lập thống kê doanh thu ngày
(61), (62), (63): Đơn giản: Lập biên bản đối soát doanh thu
(66), (67), (68), (69), (70): Đơn giản: Lập thống kê đồ uống bán chạy trong tháng
(10), (12), (17), (19): Đơn giản: Xử lý pha chế đồ uống
(52), (53): Đơn giản: Lập phiếu kiểm kê nguyên liệu
(55), (56), (59) : Đơn giản: Xử lý bổ sung nguyên liệu
(57), (58): Đơn giản: Sắp xếp nguyên liệu đạt chuẩn vào vị trí

### [TABLE 26]
| Bộ phân phục vụ (BP.01) | Bộ phận thu ngân (BP.02) | Bộ phận pha chế (BP.03) |
| (1) Hướng dẫn gọi đồ uống |  |  |
| (2) Yêu cầu khách hàng gọi đồ uống |  |  |
| (3) Xử lý thông tin phiếu gọi đồ uống |  |  |
| (4) Điều chỉnh đồ uống khách hàng |  |  |
| (5) Chuyển phiếu gọi đồ uống |  |  |
|  | (6) Xử lý xác nhận thông tin phiếu gọi đồ uống |  |
|  |  | (7) Xử lý pha chế đồ uống |
|  |  | (8) Kiểm tra số lượng nguyên liệu |
| (9) Yêu cầu khách đổi đồ uống khác |  |  |
| (10) Thông báo trạng thái nguyên liệu |  |  |
| (11) Cập nhật Menu |  |  |
| (12) Chuyển cho khách hàng xác nhận |  |  |
|  |  | (13) Trả đồ uống đã pha chế |
|  | (14) Nhận thông báo pha chế hoàn tất |  |
|  | (15) Xử lý phục vụ đồ uống mang về |  |
| (16) Giao đồ uống |  |  |
| (17) Xử lý yêu cầu lập phiếu tạm tính khách hàng |  |  |
| (18) Xử lý xác nhận phiếu tạm tính khách hàng |  |  |
| (19) Chuyển phiếu tạm tính đã ký |  |  |
| (20) Xử lý trả hóa đơn bán đồ uống khách hàng |  |  |
|  | (21) Lập hóa đơn bán đồ uống |  |
|  | (22) Chuyển hóa đơn bán đồ uống |  |
|  |  | (23) Kiểm tra tình trạng nguyên liệu của quán |
|  |  | (24) Yêu cầu nguyên liệu cần bổ sung |
|  | (25) Xử lý mua nguyên liệu |  |
|  | (26) Lập phiếu nhập hàng |  |
|  |  | (27) Lập phiếu kiểm kê nguyên liệu |
|  |  | (28) Chuyển phiếu kiểm kê chất lượng, số lượng nguyên liệu |
|  |  | (29) Xử lý kiểm tra, bổ sung nguyên liệu |
|  |  | (30) Sắp xếp nguyên liệu đạt chuẩn vào vị trí |
|  | (31) Lập thống kê doanh thu ngày |  |
|  | (32) Lập biên bản đối soát doanh thu |  |
|  | (33) Thực hiện biện pháp xử lý chênh lệch doanh thu |  |
|  | (34) Lập thống kê đồ uống bán chạy trong tháng |  |

(4) Bước 4. Loại bỏ chức năng không có ý nghĩa với hệ thống
Các chức năng (1), (2), (4), (5), (6), (8), (9), (10), (12), (13), (14), (16), (17), (18), (19), (20), (22), (23), (24), (28), (30), (33) không tác động vào kho, không có ý nghĩa đối với hệ thống.
Danh sách các chức năng của hệ thống:

### [TABLE 27]
| 1 | Xử lý thông tin phiếu gọi đồ uống |
| 2 | Xử lý pha chế đồ uống |
| 3 | Cập nhật Menu |
| 4 | Xử lý phục vụ đồ uống mang về |
| 5 | Lập hóa đơn bán đồ uống |
| 6 | Xử lý mua nguyên liệu |
| 7 | Lập Phiếu nhập hàng |
| 8 | Lập phiếu kiểm kê nguyên liệu |
| 9 | Xử lý bổ sung nguyên liệu |
| 10 | Lập thống kê doanh thu ngày |
| 11 | Lập biên bản đối soát doanh thu |
| 12 | Lập thống kê đồ uống bán chạy trong tháng |

(5) Bước 5. Đặt lại tên chức năng cho phù hợp

### [TABLE 28]
| STT | Tên chức năng | Quy trình | Tạo MB |
| 1 | Lập phiếu gọi đồ uống | QT.01 | MB.02 |
| 2 | Cập nhật trạng thái pha chế | QT.01 |  |
| 3 | Cập nhật Menu | QT.01 | MB.01 |
| 4 | Cập nhật trạng thái phục vụ đồ uống | QT.01 |  |
| 5 | Lập hóa đơn bán đồ uống | QT.02 | MB.04 |
| 6 | Lập đơn nguyên liệu mua | QT.03 | MB.05 |
| 7 | Lập Phiếu nhập hàng | QT.03 | MB.06 |
| 8 | Lập phiếu kiểm kê | QT.03 | MB.07 |
| 9 | Cập nhật nguyên liệu | QT.03 |  |
| 10 | Lập Thống kê doanh thu ngày | QT.04 | MB.08 |
| 11 | Lập biên bản Đối soát chênh lệch doanh thu | QT.04 | MB.09 |
| 12 | Lập Thống kê đồ uống bán chạy trong tháng | QT.05 | MB.10 |

2.1.1.2. Gom nhóm chức năng
Cơ cấu tổ chức của hệ thống có 3 bộ phận:
BP.01: Bộ phận phục vụ
BP.02: Bộ phận thu ngân
BP.03: Bộ phận pha chế
Nên BFD sẽ có 3 nhóm chức năng chính tương ứng 3 bộ phận:
01: Quản lý bán hàng
02: Quản lý thu chi
03: Quản lý nguyên liệu và pha chế

### [TABLE 29]
| Chức năng mức 2 | Chức năng mức 1 | Chức năng mức 0 |
| (2) 01.01. Lập phiếu gọi đồ uống (5) 01.02. Cập nhật trạng thái phục vụ đồ uống | 01. Quản lý bán hàng | Quản lý bán hàng tại quán café take away |
| (6) 02.01. Lập hóa đơn bán đồ uống (7) 02.02. Lập đơn nguyên liệu mua (11) 02.03. Lập Thống kê doanh thu ngày (12) 02.04. Lập biên bản Đối soát chênh lệch doanh thu (13) 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 02. Quản lý thu chi | Quản lý bán hàng tại quán café take away |
| (3) 03.01. Cập nhật trạng thái pha chế (4) 03.02. Cập nhật Menu (8) 03.03. Lập phiếu nhập hàng (9) 03.04. Lập phiếu kiểm kê (10) 03.05. Cập nhật nguyên liệu | 03. Quản lý nguyên liệu và pha chế | Quản lý bán hàng tại quán café take away |

2.1.1.3. Sơ đồ phân rã chức năng (BFD)
(1) Ký hiệu sử dụng:
Chức năng (công việc và tổ chức cần làm):
Quan hệ phân cấp (mỗi chức năng phân ra thàng nhiều chức năng con):
(2) Sơ đồ phân rã chức năng (BFD)
##### 2.1.2. Mô hình hóa tiến trình nghiệp vụ
2.1.2.1. Ký hiệu sử dụng
Tiến trình:
Luồng dữ liệu:
Tác nhân ngoài:
Tác nhân trong:
Kho dữ liệu:
2.1.2.2. DFD mức khung cảnh (DFD 0)
2.1.2.3. DFD mức đỉnh (DFD 1)
(1) Bảng 5. Bảng tổng hợp thông tin DFD 1

### [TABLE 30]
| STT | Tiến trình mức đỉnh | Tác nhân ngoài | Kho dữ liệu | Tiến trình liên quan |
| 1 | 01. Quản lý bán hàng | MTN.01. Khách hàng | K.01. Đồ uống K.03. Phiếu gọi đồ uống | 02; 03 |
| 2 | 02. Quản lý thu chi | MTN.01. Khách hàng MTN.02. Nhà cung cấp MTT.01. Người quản lý | K.01. Đồ uống K.02. Nguyên liệu K.04. Hóa đơn bán đồ uống K.05. Đơn nguyên liệu mua K.06. Phiếu nhập hàng K.07. Phiếu kiểm kê | 01; 03 |
| 3 | 03. Quản lý nguyên liệu và pha chế | MTN.02. Nhà cung cấp | K.01. Đồ uống K.02. Nguyên liệu K.03. Phiếu gọi đồ uống | 01; 02 |

(2) DFD mức đỉnh (DFD 1)
2.1.2.4. DFD mức dưới đỉnh (DFD 2)
(1) Tiến trình quản lý bán hàng
Bảng 6.1. Bảng tổng hợp thông tin DFD 2

### [TABLE 31]
| STT | Tiến trình mức dưới đỉnh | Tác nhân ngoài | Tác nhân trong | Kho dữ liệu | Tiến trình liên quan |
| 1 | 01.01. Lập phiếu gọi đồ uống | MTN.01. | 02 | K.02; K.03 | 01.02 |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống | MTN.01. | 03 | K.02; K.03 | 01.01 |

DFD mức dưới đỉnh (DFD 2)
(2) Tiến trình quản lý thu chi
Bảng 6.2. Bảng tổng hợp thông tin DFD 2

### [TABLE 32]
| STT | Tiến trình mức dưới đỉnh | Tác nhân ngoài | Tác nhân trong | Kho dữ liệu | Tiến trình liên quan |
| 1 | 02.01. Lập hóa đơn bán đồ uống | MTN.01. | 01 | K.04 |  |
| 2 | 02.02. Lập đơn nguyên liệu mua | MTN.02. | 03 | K.02; K.05 |  |
| 3 | 02.03. Lập Thống kê doanh thu ngày |  |  | K.01; K.04 | 02.04 |
| 4 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu |  |  | K.01; K.04 | 02.03 |
| 5 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng |  |  | K.04 |  |

DFD mức dưới đỉnh (DFD 2)
(3) Tiến trình quản lý nguyên liệu và pha chế
Bảng 6.3. Bảng tổng hợp thông tin DFD 2

### [TABLE 33]
| STT | Tiến trình mức dưới đỉnh | Tác nhân ngoài | Tác nhân trong | Kho dữ liệu | Tiến trình liên quan |
| 1 | 03.01. Cập nhật trạng thái pha chế |  | 01 | K.02; K.04 | 03.05 |
| 2 | 03.02. Cập nhật Menu |  |  | K.01 | 03.05 |
| 3 | 03.03. Lập phiếu nhập hàng | MTN.02 | 01 | K.02; K.06 | 03.04; 03.05 |
| 4 | 03.04. Lập phiếu kiểm kê | MTN.02 | 01 | K.02; K.07 | 03.03; 03.05 |
| 5 | 03.05. Cập nhật nguyên liệu |  |  | K.02 | 03.01; 03.02, 03.03; 03.04 |

DFD mức dưới đỉnh (DFD 2)
##### 2.1.3. Đặc tả tiến trình nghiệp vụ
01.01. Lập phiếu gọi đồ uống
Tên tiến trình: Lập phiếu gọi đồ uống Đầu vào: Yêu cầu gọi đồ uống của khách hàng, Menu, yêu cầu xác
nhận thông tin gọi đồ uống của khách hàng
Đầu ra: Phiếu gọi đồ uống
Nội dung xử lý:
Nếu: Khách hàng yêu cầu gọi đồ uống Thì: Tiếp nhận thông tin món, số lượng và yêu cầu kèm theo
và Đối chiếu với Menu hiện hành
Nếu: Thông tin gọi đồ uống đầy đủ Thì: Lập phiếu gọi đồ uống và Yêu cầu khách hàng xác nhận thông tin gọi đồ uống
Nếu: Khách hàng yêu cầu kiểm tra lại hoặc chỉnh sửa thông tin Thì: Tiếp nhận yêu cầu chỉnh sửa và Cập nhật lại phiếu gọi đồ uống
Nếu: Khách hàng xác nhận thông tin gọi đồ uống Thì: Hoàn tất phiếu gọi đồ uống và Chuyển phiếu sang bước phục vụ đồ uống
01.02. Cập nhật trạng thái phục vụ đồ uống
Tên tiến trình: Cập nhật trạng thái phục vụ đồ uống Đầu vào: Phiếu gọi đồ uống đã xác nhận, phiếu điều chỉnh đồ
uống, đồ uống từ bộ phận pha chế
Đầu ra: Đồ uống hoàn thiện phục vụ khách hàng, yêu cầu pha chế
đồ uống, yêu cầu hoàn thiện đồ uống, yêu cầu đổi đồ uống khác
Nội dung xử lý: Nếu: Phiếu gọi đồ uống đã được xác nhận Thì: Cập nhật trạng thái phục vụ đồ uống và Chuyển yêu cầu pha chế đồ uống cho bộ phận nguyên liệu và
pha chế
Nếu: Có phiếu điều chỉnh đồ uống Thì: Cập nhật lại trạng thái phục vụ theo nội dung điều chỉnh
Nếu: Bộ phận pha chế hoàn tất đồ uống Thì: Tiếp nhận đồ uống và kiểm tra đối chiếu với phiếu gọi
Nếu: Đồ uống đúng yêu cầu Thì: Phục vụ đồ uống hoàn thiện cho khách hàng và Cập nhật trạng thái hoàn tất phục vụ
Nếu: Đồ uống chưa đạt yêu cầu Thì: Gửi yêu cầu hoàn thiện đồ uống hoặc đổi đồ uống khác cho bộ
phận pha chế
02.01. Lập hóa đơn bán đồ uống
Tên tiến trình: Lập hóa đơn bán đồ uống Đầu vào: Phiếu tạm tính đã được khách hàng xác nhận Đầu ra: Hóa đơn bán đồ uống
Nội dung xử lý: Nếu: Phiếu tạm tính đã được xác nhận và thanh toán thành công Thì: Đối chiếu thông tin thanh toán với phiếu tạm tính
Nếu: Thông tin thanh toán hợp lệ Thì: Lập hóa đơn bán đồ uống và Giao hóa đơn bán đồ uống cho khách hàng
Nếu: Có sai lệch trong thông tin thanh toán Thì: Kiểm tra lại phiếu tạm tính và thông tin giao dịch
Nếu không thì: Hoàn tất lưu hóa đơn bán đồ uống vào hệ thống
02.02. Lập đơn nguyên liệu mua
Tên tiến trình: Xử lý mua nguyên liệu
Đầu vào: Yêu cầu kiểm kê nguyên liệu, phiếu kiểm kê, thông tin
nguyên liệu, nhà cung cấp
Đầu ra: Đơn nguyên liệu mua, xác nhận giao nguyên liệu thành
công hoặc yêu cầu đổi trả bổ sung nguyên liệu
Nội dung xử lý: Nếu: Nhận được yêu cầu kiểm kê nguyên liệu từ bộ phận quản lý nguyên liệu và pha chế Thì: Kiểm tra thông tin nguyên liệu cần bổ sung và đối chiếu với phiếu kiểm kê
Nếu: Phát hiện nguyên liệu thiếu hoặc không đủ phục vụ Thì: Lập đơn nguyên liệu mua gửi cho nhà cung cấp
Nếu: Nhà cung cấp giao nguyên liệu kèm hóa đơn giao hàng Thì: Tiếp nhận thông tin giao hàng và yêu cầu kiểm tra nguyên liệu
Nếu: Nguyên liệu được kiểm tra đạt yêu cầu Thì: Xác nhận giao nguyên liệu thành công Và Chuyển thông tin xác nhận nhận hàng thành công cho bộ phận liên quan
Nếu không thì: Lập yêu cầu đổi trả, bổ sung nguyên liệu Và Gửi yêu cầu cho nhà cung cấp xử lý
02.03. Lập Thống kê doanh thu ngày
Tên tiến trình: Thống kê doanh thu ngày Đầu vào: Hóa đơn bán đồ uống trong ngày Đầu ra: Báo cáo doanh thu ngày
Nội dung xử lý: Nếu: Kết thúc hoạt động bán hàng trong ngày Thì: Tập hợp toàn bộ hóa đơn bán đồ uống phát sinh trong ngày
và Tổng hợp doanh thu theo dữ liệu hóa đơn và Lập báo cáo doanh thu ngày
Nếu: Báo cáo doanh thu ngày hoàn tất Thì: Gửi báo cáo doanh thu ngày cho người quản lý
Nếu: Trong quá trình tổng hợp phát hiện chênh lệch doanh thu Thì: Chuyển thông tin sang tiến trình đối soát chênh lệch doanh thu
ngày
02.04. Lập biên bản Đối soát chênh lệch doanh thu ngày
Tên tiến trình: Đối soát chênh lệch doanh thu ngày Đầu vào: Phát hiện chênh lệch doanh thu Đầu ra: Biên bản đối soát chênh lệch doanh thu, thông tin xử lý
chênh lệch doanh thu
Nội dung xử lý: Nếu: Phát hiện chênh lệch giữa doanh thu hệ thống và doanh thu thực
tế Thì: Kiểm tra, đối chiếu dữ liệu hóa đơn và thông tin doanh thu đã
thống kê
Nếu: Xác định có chênh lệch Thì: Lập biên bản đối soát chênh lệch doanh thu và Gửi người quản lý xem xét
Nếu: Người quản lý đưa ra hướng xử lý Thì: Thực hiện xử lý chênh lệch doanh thu theo chỉ đạo
Nếu: Việc xử lý hoàn tất Thì: Cập nhật lại kết quả đối soát vào hệ thống
02.05. Thống kê đồ uống bán chạy trong tháng
Tên tiến trình: Thống kê đồ uống bán chạy trong tháng Đầu vào: Hóa đơn bán đồ uống trong tháng Đầu ra: Báo cáo đồ uống bán chạy trong tháng
Nội dung xử lý: Nếu: Kết thúc kỳ kinh doanh tháng Thì: Tổng hợp dữ liệu từ các hóa đơn bán đồ uống trong tháng
và Thống kê số lượng tiêu thụ của từng đồ uống và Xác định các đồ uống có doanh số và tần suất bán cao
Nếu: Kết quả thống kê hoàn tất Thì: Lập báo cáo đồ uống bán chạy trong tháng và Gửi báo cáo cho người quản lý
Nếu: Báo cáo cần phục vụ quyết định điều chỉnh nguyên liệu Thì: Chuyển thông tin liên quan cho bộ phận quản lý nguyên liệu và
pha chế
03.01. Cập nhật trạng thái pha chế
Tên tiến trình: Cập nhật trạng thái pha chế Đầu vào: Yêu cầu pha chế đồ uống, phiếu gọi đồ uống, phiếu điều
chỉnh đồ uống
Đầu ra: Đồ uống, yêu cầu hoàn thiện đồ uống, yêu cầu đổi đồ
uống khác
Nội dung xử lý: Nếu: Nhận được yêu cầu pha chế đồ uống Thì: Tiến hành pha chế theo thông tin trên phiếu gọi đồ uống hoặc
phiếu điều chỉnh đồ uống
Nếu: Trong quá trình thực hiện cần hoàn thiện hoặc chỉnh sửa đồ
uống Thì: Cập nhật trạng thái pha chế và Thực hiện chỉnh sửa theo yêu cầu
Nếu: Đồ uống pha chế xong Thì: Chuyển đồ uống cho bộ phận bán hàng/phục vụ
Nếu: Có yêu cầu thay đổi đồ uống Thì: Ghi nhận và thực hiện pha chế lại theo yêu cầu mới
03.02. Cập nhật Menu
Tên tiến trình: Cập nhật Menu Đầu vào: Thông tin nguyên liệu hết Đầu ra: Dữ liệu đồ uống/Menu được cập nhật
Nội dung xử lý: Nếu: Nhận thông tin nguyên liệu hết từ tiến trình cập nhật tình trạng nguyên liệu pha chế Thì: Kiểm tra các món đồ uống bị ảnh hưởng bởi tình trạng thiếu nguyên liệu
Nếu: Có món không thể tiếp tục phục vụ Thì: Cập nhật trạng thái món trên Menu
và Đánh dấu các món tạm ngưng phục vụ
Nếu: Nguyên liệu được bổ sung trở lại Thì: Cập nhật lại Menu để khôi phục các món có thể phục vụ
03.03. Lập phiếu nhập hàng
Tên tiến trình: Lập phiếu nhập hàng
Đầu vào: Yêu cầu nhập nguyên liệu
Thông tin nguyên liệu cần nhập
Dữ liệu nguyên liệu hiện có
Thông tin từ nhà cung cấp
Đầu ra: Phiếu nhập hàng
Nếu: Phát sinh yêu cầu nhập nguyên liệu Thì: Kiểm tra nhu cầu nguyên liệu và tình trạng nguyên liệu
hiện có.
Nếu: Xác định có nguyên liệu cần bổ sung Thì: Tổng hợp thông tin nguyên liệu cần nhập.
Nếu: Thông tin nhập hàng đầy đủ và hợp lệ Thì: Lập phiếu nhập hàng.
Nếu: Phiếu nhập hàng đã được lập Thì: Chuyển thông tin sang nhà cung cấp để thực hiện giao
nguyên liệu và chuyển sang bước kiểm tra nguyên liệu
giao.
Nếu không Thì: Rà soát, cập nhật lại thông tin nguyên liệu cần nhập
trước khi lập phiếu.
03.04. Lập phiếu kiểm kê
Tên tiến trình: Lập phiếu kiểm kê chất lượng, số lượng nguyên liệu Đầu vào: Nguyên liệu giao, nhà cung cấp, phiếu kiểm kê, yêu cầu
kiểm tra số lượng và chất lượng nguyên liệu
Đầu ra: Phiếu kiểm kê, xác nhận giao hàng thành công hoặc yêu
cầu đổi trả bổ sung nguyên liệu
Nội dung xử lý: Nếu: Nhận nguyên liệu từ nhà cung cấp Thì: Kiểm tra số lượng và chất lượng nguyên liệu thực nhận
và Đối chiếu với thông tin từ nhà cung cấp và yêu cầu nhập hàng
Nếu: Nguyên liệu đạt yêu cầu Thì: Lập phiếu kiểm kê và Xác nhận giao hàng thành công và Chuyển thông tin cho bộ phận quản lý thu chi
Nếu không thì: Lập yêu cầu đổi trả, bổ sung nguyên liệu và Thông báo cho nhà cung cấp xử lý và Ghi nhận kết quả kiểm tra vào phiếu kiểm kê
03.05. Cập nhật nguyên liệu
Tên tiến trình: Cập nhật nguyên liệu Đầu vào: Yêu cầu nguyên liệu, kết quả tiếp nhận nguyên liệu giao,
Nhu cầu nguyên liệu phục vụ pha chế Đầu ra: Dữ liệu nguyên liệu đã được cập nhật, Thông tin nguyên
liệu phục vụ kiểm kê và pha chế, Thông tin nguyên liệu
cần nhập bổ sung, Thông tin nguyên liệu hiện có, Thông
tin số lượng, chất lượng nguyên liệu giao từ nhà cung cấp
Nội dung xử lý: Nếu: Phát sinh yêu cầu cập nhật nguyên liệu Thì: Kiểm tra số lượng và chất lượng nguyên liệu hiện có.
Nếu: Nguyên liệu đáp ứng nhu cầu sử dụng Thì: Cập nhật thông tin nguyên liệu trong hệ thống.
Nếu: Nguyên liệu thiếu, hết hoặc không đạt yêu cầu Thì: Xác định nguyên liệu cần bổ sung và lập phiếu nhập
hàng.
Nếu: Nhà cung cấp giao nguyên liệu Thì: Tiếp nhận và kiểm tra số lượng, chất lượng nguyên liệu
giao.
Nếu: Nguyên liệu giao đạt yêu cầu Thì: Cập nhật lại dữ liệu nguyên liệu.
Nếu: Nguyên liệu giao chưa đạt yêu cầu hoặc có sai lệch Thì: Chuyển sang bước kiểm kê, đối chiếu và xử lý điều
chỉnh.
Nếu không Thì: Lưu thông tin nguyên liệu đã cập nhật vào hệ
thống.
#### 2.2. Phân tích dữ liệu nghiệp vụ
##### 2.2.1. Mô hình dữ liệu ban đầu
2.2.1.1. Xác định kiểu thực thể
Bảng 7. Bảng tổng hợp kiểu thực thể

### [TABLE 34]
| STT | Tên kiểu thực thể | Tài nguyên | Tài nguyên | Tài nguyên | Giao dịch | Giao dịch |
| STT | Tên kiểu thực thể | Tài sản | Con người | Kho bãi | Có mẫu biểu | Không có mẫu biểu |
| 1 | NGUYÊN LIỆU | * |  |  |  |  |
| 2 | ĐỒ UỐNG | * |  |  |  |  |
| 3 | KHÁCH HÀNG |  | * |  |  |  |
| 4 | NHÀ CUNG CẤP |  | * |  |  |  |
| 5 | LOẠI ĐỒ UỐNG |  |  | * |  |  |
| 6 | PHIẾU GỌI ĐỒ UỐNG |  |  |  | MB02 |  |
| 7 | HÓA ĐƠN BÁN ĐỒ UỐNG |  |  |  | MB04 |  |
| 8 | ĐƠN NGUYÊN LIỆU MUA |  |  |  | MB05 |  |
| 9 | PHIẾU NHẬP HÀNG |  |  |  | MB06 |  |
| 10 | PHIẾU KIỂM KÊ |  |  |  | MB07 |  |

2.2.1.2. Xác định kiểu thuộc tính
Đối với kiểu thực thể có mẫu biểu:
(1) PHIẾU GỌI ĐỒ UỐNG (Số phiếu gọi đồ uống, Ngày gọi đồ uống, Thời gian gọi đồ uống, Tên khách hàng, Tên đồ uống *, Size *, Số lượng *, Yêu cầu đặc biệt *, Người lập phiếu gọi)
(2) HÓA ĐƠN BÁN ĐỒ UỐNG (Số hóa đơn, Ngày lập hóa đơn, Thời gian thanh toán, Tên khách hàng, Số điện thoại khách hàng, Địa chỉ khách hàng, Giới tính, Hình thức thanh toá, Tên đồ uống *, Size*, Số lượng *, Đơn giá *, Thành tiền đồ uống*, Giảm giá, Phụ thu, Tổng tiền thanh toán, Trạng thái, Ghi chú, Người lập hóa đơn)
(3) ĐƠN NGUYÊN LIỆU MUA (Số đơn, Ngày lập đơn mua, Nhà cung cấp Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Bộ phận, Tên nguyên liệu*, Đơn vị tính*, Số lượng đề nghị*, Đơn giá dự kiến*, Thành tiền nguyên liệu dự kiến*, Tổng giá trị đơn dự kiến, Ghi chú, Người lập đơn, Quản lý)
(4) PHIẾU NHẬP HÀNG (Số phiếu nhập, Ngày giao, Thời gian giao hàng, Nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Tên khách hàng, Tổng giá trị phiếu, Tên nguyên liệu*, Đơn vị tính*, Số lượng giao*, Tình trạng*, Đơn giá*, Thành tiền nguyên liệu*, Ghi chú*, Người giao hàng, Người nhận hàng)
(5) PHIẾU KIỂM KÊ (Số phiếu kiểm kê, Tên nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Ngày kiểm kê, Thời gian kiểm kê, Tên nguyên liệu *, Số lượng theo kiểm kê *, Số lượng thực tế*, Chênh lệch*, Hạn sử dụng*, Tình trạng chất lượng*, Ghi chú*)
Đối với kiểu thực thể từ nguồn khác:
(6) ĐỒ UỐNG (Tên đồ uống, Đơn giá)
(7) NGUYÊN LIỆU (Tên nguyên liệu, Đơn vị tính)
(8) KHÁCH HÀNG (Tên khách hàng, Số điện thoại khách hàng, Địa chỉ khách hàng, Giới tính)
(9) NHÀ CUNG CẤP (Tên nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp)
(10) LOẠI ĐỒ UỐNG (Tên loại đồ uống, Mô tả)
2.2.1.3. Xác định kiểu liên kết
CN – GD – TS:
KHÁCH HÀNG – có – HÓA ĐƠN BÁN ĐỒ UỐNG – gồm – ĐỒ UỐNG
KHÁCH HÀNG – có – PHIẾU GỌI ĐỒ UỐNG – gồm – ĐỒ UỐNG
NHÀ CUNG CẤP – có – PHIẾU NHẬP HÀNG – gồm – NGUYÊN LIỆU
NHÀ CUNG CẤP – có – PHIẾU KIỂM KÊ – gồm – NGUYÊN LIỆU
ĐƠN NGUYÊN LIỆU MUA – gồm – NGUYÊN LIỆU
TS – KB:
ĐỒ UỐNG – thuộc – LOẠI ĐỒ UỐNG
CN – KB: Không có
GD – GD:
HÓA ĐƠN BÁN ĐỒ UỐNG – theo – PHIẾU GỌI ĐỒ UỐNG
PHIẾU NHẬP HÀNG – theo – ĐƠN NGUYÊN LIỆU MUA
TS – TS:
ĐỒ UỐNG – gồm – NGUYÊN LIỆU
2.2.1.4. Mô hình thực thể liên kết mở rộng (ERD MR)
(1) Ký hiệu sử dụng

### [TABLE 35]
|  | - Kiểu thực thể |
|  | - Kiểu thuộc tính |
|  | - Liên kết một và chỉ một |
|  | - Liên kết có ít nhất một |
|  | - Liên kết có thể có nhiều hoặc không |
|  | - Liên kết không có hoặc có duy nhất |

(2) Mô hình ERD mở rộng
##### 2.2.2. Chuẩn hóa dữ liệu
2.2.2.1. Chuyển đổi từ ERD mở rộng về ERD kinh điển
(1) Đánh (*) vào các thuộc tính đa trị:
(2) Tách các thuộc tính đa trị:
(1) PHIẾU GỌI ĐỒ UỐNG (Số phiếu gọi đồ uống, Ngày gọi đồ uống, Thời gian gọi đồ uống, Tên khách hàng, Tên đồ uống *, Size *, Số lượng *, Yêu cầu đặc biệt *, Người lập phiếu gọi)
- Tách thành:
PHIẾU GỌI ĐỒ UỐNG (Số phiếu gọi đồ uống, Ngày gọi đồ uống, Thời gian gọi đồ uống, Tên khách hàng, Người lập phiếu gọi)
CHI TIẾT PHIẾU GỌI ĐỒ UỐNG (Tên đồ uống *, Size *, Số lượng *, Yêu cầu đặc biệt *)
(2) HÓA ĐƠN BÁN ĐỒ UỐNG (Số hóa đơn, Ngày lập hóa đơn, Thời gian thanh toán, Tên khách hàng, Số điện thoại khách hàng, Địa chỉ khách hàng, Giới tính, Hình thức thanh toán, Tên đồ uống *, Size*, Số lượng *, Đơn giá *, Thành tiền *, Giảm giá, Phụ thu, Tổng tiền thanh toán, Trạng thái, Ghi chú, Người lập hóa đơn)
- Tách thành:
HÓA ĐƠN BÁN ĐỒ UỐNG (Số hóa đơn, Ngày lập hóa đơn, Thời gian thanh toán, Tên khách hàng, Số điện thoại khách hàng, Địa chỉ khách hàng, Giới tính, Hình thức thanh toán, Giảm giá, Phụ thu, Tổng tiền thanh toán, Trạng thái, Ghi chú, Người lập hóa đơn)
CHI TIẾT HÓA ĐƠN BÁN ĐỒ UỐNG (Tên đồ uống *, Size*, Số lượng *, Đơn giá *, Thành tiền *)
(3) ĐƠN NGUYÊN LIỆU MUA (Số đơn, Ngày lập đơn, Nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Bộ phận, Tên nguyên liệu*, Đơn vị tính*, Số lượng đề nghị*, Đơn giá dự kiến*, Thành tiền nguyên liệu dự kiến*, Tổng giá trị đơn dự kiến, Ghi chú, Người lập đơn, Quản lý)
- Tách thành:
ĐƠN NGUYÊN LIỆU MUA (Số đơn, Ngày lập đơn, Nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Bộ phận, Tổng giá trị đơn dự kiến, Ghi chú, Người lập đơn, Quản lý)
CHI TIẾT ĐƠN NGUYÊN LIỆU MUA (Tên nguyên liệu*, Đơn vị tính*, Số lượng đề nghị*, Đơn giá dự kiến*, Thành tiền nguyên liệu dự kiến*)
(4) PHIẾU NHẬP HÀNG (Số hóa đơn, Ngày giao, Thời gian giao hàng, Nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Người giao hàng, Tên khách hàng, Tổng giá trị đơn dự kiến, Tên nguyên liệu*, Đơn vị tính*, Số lượng giao*, Tình trạng*, Ghi chú*, Người giao hàng, Người nhận hàng)
- Tách thành:
PHIẾU NHẬP HÀNG (Số hóa đơn, Ngày giao, Thời gian giao hàng, Nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Người giao hàng, Tên khách hàng, Tổng giá trị phiếu, Người giao hàng, Người nhận hàng)
CHI TIẾT PHIẾU NHẬP HÀNG (Tên nguyên liệu*, Đơn vị tính*, Số lượng giao*, Tình trạng*, Ghi chú*)
(5) PHIẾU KIỂM KÊ (Số phiếu kiểm kê, Tên nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Ngày kiểm kê, Thời gian kiểm kê, Người thực hiện kiểm kê, Người giám sát, Tên nguyên liệu *, Số lượng theo kiểm kê *, Số lượng thực tế*, Chênh lệch*, Hạn sử dụng*, Tình trạng chất lượng*, Ghi chú*)
- Tách thành:
PHIẾU KIỂM KÊ (Số phiếu kiểm kê, Tên nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp, Ngày kiểm kê, Thời gian kiểm kê, Người thực hiện kiểm kê, Người giám sát)
CHI TIẾT PHIẾU KIỂM KÊ (Tên nguyên liệu*, Số lượng theo kiểm kê*, Số lượng thực tế*, Chênh lệch*, Hạn sử dụng*, Tình trạng chất lượng*, Ghi chú*)
(3) Xác định khóa chính cho các kiểu thực thể chính

### [TABLE 36]
| STT | Kiểu thực thể | Khóa chính | Ghi chú |
| 1 | PHIẾU GỌI ĐỒ UỐNG | Số phiếu gọi đồ uống |  |
| 2 | HÓA ĐƠN BÁN ĐỒ UỐNG | Số hóa đơn |  |
| 3 | ĐƠN NGUYÊN LIỆU MUA | Số đơn |  |
| 4 | PHIẾU NHẬP HÀNG | Số phiếu nhập |  |
| 5 | PHIẾU KIỂM KÊ | Số phiếu kiểm kê |  |
| 6 | NGUYÊN LIỆU | Mã nguyên liệu | Thêm vào |
| 7 | ĐỒ UỐNG | Mã đồ uống | Thêm vào |
| 8 | KHÁCH HÀNG | Mã khách hàng | Thêm vào |
| 9 | NHÀ CUNG CẤP | Mã nhà cung cấp | Thêm vào |
| 10 | LOẠI ĐỒ UỐNG | Mã loại món | Thêm vào |

(4) Ký hiệu sử dụng:

### [TABLE 37]
|  | - Kiểu thực thể |
|  | - Kiểu thuộc tính |
|  | - Liên kết một và chỉ một |
|  | - Liên kết có ít nhất một |
|  | - Liên kết có thể có nhiều hoặc không |
|  | - Liên kết không có hoặc có duy nhất |

(5) Mô hình ERD kinh điển
2.2.2.2. Chuyển đổi từ ERD kinh điển về ERD hạn chế
(1) Khử liên kết n – n, 1 – 1:
Khử liên kết 1 – 1:
- PHIẾU NHẬP HÀNG – theo – ĐƠN NGUYÊN LIỆU MUA : liên kết 1 - 1
+ 2 kiểu thực thể không thể gộp chung
+ ĐƠN NGUYÊN LIỆU MUA là kiểu thực thể có trước
Chuyển của ĐƠN NGUYÊN LIỆU MUA (Số đơn) sang PHIẾU NHẬP HÀNG.
Khử liên kết n – n:
-NGUYÊN LIỆU – gồm – ĐỒ UỐNG
- Sinh ra kiểu thực thể mới NGUYÊN LIỆU – ĐỒ UỐNG trong đó chứa khóa của NGUYÊN LIỆU (Mã nguyên liệu) và khóa của ĐỒ UỐNG (Mã đồ uống)
NGUYÊN LIỆU – ĐỒ UỐNG (Mã nguyên liệu, Mã đồ uống)
(2) Xác định thuộc tính kết nối:

### [TABLE 38]
| STT | Đầu 1 | Đầu n | Thuộc tính kết nối | Ghi chú |
| 1 | NHÀ CUNG CẤP | PHIẾU KIỂM KÊ | Mã nhà cung cấp | Chuyển sang |
| 2 | NHÀ CUNG CẤP | PHIẾU NHẬP HÀNG | Mã nhà cung cấp | Chuyển sang |
| 3 | PHIẾU KIỂM KÊ | CHI TIẾT PHIẾU KIỂM KÊ | Số phiếu kiểm kê | Chuyển sang |
| 4 | ĐƠN NGUYÊN LIỆU MUA | CHI TIẾT ĐƠN NGUYÊN LIỆU MUA | Số đơn | Chuyển sang |
| 5 | NGUYÊN LIỆU | CHI TIẾT PHIẾU KIỂM KÊ | Mã nguyên liệu | Chuyển sang |
| 6 | NGUYÊN LIỆU | CHI TIẾT PHIẾU NHẬP HÀNG | Mã hàng hóa | Chuyển sang |
| 7 | NGUYÊN LIỆU | NGUYÊN LIỆU ĐỒ UỐNG | Mã nguyên liệu | Chuyển sang |
| 8 | NGUYÊN LIỆU | NGUYÊN LIỆU ĐỒ UỐNG | Mã đồ uống | Chuyển sang |
| 9 | LOẠI ĐỒ UỐNG | ĐỒ UỐNG | Mã loại đồ uống | Chuyển sang |
| 10 | ĐỒ UỐNG | CHI TIẾT PHIẾU GỌI ĐỒ UỐNG | Mã đồ uống | Chuyển sang |
| 11 | ĐỒ UỐNG | CHI TIẾT HÓA ĐƠN BÁN ĐỒ UỐNG | Mã đồ uống | Chuyển sang |
| 12 | PHIẾU GỌI ĐỒ UỐNG | CHI TIẾT PHIẾU GỌI ĐỒ UỐNG | Số phiếu gọi đồ uống | Chuyển sang |
| 13 | HÓA ĐƠN BÁN ĐỒ UỐNG | CHI TIẾT HÓA ĐƠN BÁN ĐỒ UỐNG | Số hóa đơn | Chuyển sang |
| 14 | KHÁCH HÀNG | HÓA ĐƠN BÁN ĐỒ UỐNG | Mã khách hàng | Chuyển sang |
| 15 | KHÁCH HÀNG | PHIẾU GỌI ĐỒ UỐNG | Mã khách hàng | Chuyển sang |

(3) Xác định khóa chính, khóa ngoại:

### [TABLE 39]
| STT | Kiểu thực thể | Khóa chính | Khóa ngoại |
| Kiểu thực thể chính | Kiểu thực thể chính | Kiểu thực thể chính | Kiểu thực thể chính |
| 1 | PHIẾU GỌI ĐỒ UỐNG | Số phiếu gọi đồ uống | Mã món |
| 2 | HÓA ĐƠN BÁN ĐỒ UỐNG | Số phiếu gọi đồ uống Mã đồ uống | Số phiếu gọi đồ uống Mã đồ uống |
| 3 | ĐƠN NGUYÊN LIỆU MUA | Số đơn | Mã khách hàng |
| 4 | PHIẾU NHẬP HÀNG | Số phiếu mua hàng | Mã nhà cung cấp |
| 5 | PHIẾU KIỂM KÊ | Số phiếu kiểm kê | Mã nhà cung cấp |
| 6 | ĐỒ UỐNG | Mã đồ uống | Mã loại đồ uống |
| 7 | NGUYÊN LIỆU | Mã nguyên liệu |  |
| 8 | KHÁCH HÀNG | Mã khách hàng |  |
| 9 | NHÀ CUNG CẤP | Mã nhà cung cấp |  |
| 10 | LOẠI ĐỒ UỐNG | Mã loại đồ uống |  |
| Kiểu thực thể phụ thuộc | Kiểu thực thể phụ thuộc | Kiểu thực thể phụ thuộc | Kiểu thực thể phụ thuộc |
| 11 | CHI TIẾT PHIẾU GỌI ĐỒ UỐNG | Số phiếu gọi đồ uống Mã đồ uống | Số phiếu gọi đồ uống Mã đồ uống |
| 12 | CHI TIẾT HÓA ĐƠN BÁN ĐỒ UỐNG | Số hóa đơn Mã đồ uống | Số hóa đơn Mã khách hàng |
| 13 | CHI TIẾT PHIẾU NHẬP HÀNG | Số phiếu mua hàng Mã nguyên liệu | Số phiếu mua hàng Mã nguyên liệu |
| 14 | CHI TIẾT PHIẾU KIỂM KÊ | Số phiếu kiểm kê Mã nguyên liệu | Số phiếu kiểm kê Mã nguyên liệu |
| 15 | NGUYÊN LIỆU ĐỒ UỐNG | Mã đồ uống Mã nguyên liệu | Mã đồ uống Mã nguyên liệu |

(4) Ký hiệu sử dụng:

### [TABLE 40]
|  | - Kiểu thực thể |
|  | - Liên kết 1-n |
|  | - Khóa chính |
|  | - khóa ngoài |
|  | - Vừa khóa chính, vừa khóa ngoài |

(5) Mô hình ERD hạn chế:
2.2.2.3. Chuyển đổi từ ERD hạn chế về mô hình quan hệ (RM)
(1) Mã hóa tên gọi chuyển đổi kiểu thực thể thành bảng quan hệ

### [TABLE 41]
| STT | Tên kiểu thực thể | Tên bảng quan hệ |
| 1 | LOẠI ĐỒ UỐNG | B01. LDU |
| 2 | NGUYÊN LIỆU | B02. NL |
| 3 | ĐỒ UỐNG | B03. DU |
| 4 | NGUYÊN LIỆU – ĐỒ UỐNG | B03.1. DU_NL |
| 5 | KHÁCH HÀNG | B04. K_H |
| 6 | NHÀ CUNG CẤP | B05. NCC |
| 7 | PHIẾU GỌI ĐỒ UỐNG | B06. P_G_DU |
| 8 | CHI TIẾT PHIẾU GỌI ĐỒ UỐNG | B06.1. C_T_PGĐU |
| 9 | HÓA ĐƠN BÁN ĐỒ UỐNG | B07. HD_BDU |
| 10 | CHI TIẾT HÓA ĐƠN BÁN ĐỒ UỐNG | B07.1. C_T_HDBĐU |
| 11 | ĐƠN NGUYÊN LIỆU MUA | B08. D_NLM |
| 12 | CHI TIẾT ĐƠN NGUYÊN LIỆU MUA | B08.1. C_T_ĐNLM |
| 13 | PHIẾU NHẬP HÀNG | B09. P_NH |
| 14 | CHI TIẾT PHIẾU NHẬP HÀNG | B09.1. C_T_PNH |
| 15 | PHIẾU KIỂM KÊ | B10. P_KK |
| 16 | CHI TIẾT PHIẾU KIỂM KÊ | B10.1. C_T_PKK |

(2) Xử lý kiểu thuộc tính mô tả xuất hiện ở nhiều kiểu thực thể
- (Tên nguyên liệu, Đơn vị tính) => Giữ lại trong bảng NGUYENLIEU
- (Tên nhà cung cấp, Địa chỉ nhà cung cấp, Số điện thoại nhà cung cấp) => Giữ lại trong bảng NHACUNGCAP
- (Tên đồ uống, Đơn giá) => Giữ lại trong bảng ĐOUONG
- (Tên khách hàng, Số điện thoại khách hàng, Địa chỉ khách hàng, Giới tính) => Giữ lại trong bảng KHACHHANG
(3) Xử lý kiểu thuộc tính mô tả kết xuất được từ kiểu thuộc tính khác

### [TABLE 42]
| STT | Tên bảng quan hệ | Trường | Cách kết xuất | Ghi chú |
| 1 | B07. HD_BDU | Phụ thu | = (∑ Thành tiền) * 10% | Bỏ trường |
| 2 | B07. HD_BDU | Tổng tiền thanh toán | = (∑ Thành tiền đồ uống) + Phụ thu – Giảm giá | Bỏ trường |
| 3 | B08. D_NLM | Tổng giá trị đơn dự kiến | =∑ Thành tiền | Bỏ trường |
| 4 | B08.1. C_T_ĐNLM | Thành tiền nguyên liệu dự kiến | = Đơn giá dự kiến * Số lượng |  |
| 5 | B09. P_NH | Tổng giá trị phiếu | = ∑ Thành tiền nguyên liệu | Bỏ trường |
| 6 | B09.1. C_T_PNH | Thành tiền nguyên liệu | = Đơn giá * Số lượng | Bỏ trường |

(4) Bảng 8. Bảng tổng hợp lược đồ quan hệ

### [TABLE 43]
| STT | Mã LĐ | Lược đồ quan hệ |
| 1 | B01 | LDU(ma_ldu, tenloaidouong, mota) |
| 2 | B02 | NL(ma_nl, tennguyenlieu, donvitinh) |
| 3 | B03 B03.1 | DU(ma_du, ma_ldu, tendouong, dongia) DU_NL(ma_nl, ma_du) |
| 4 | B04 | K_H(ma_kh, tenkhachhang, sodienthoai, diachi, gioitinh) |
| 5 | B05 | NCC(ma_ncc, tennhacungcap, diachincc, sodienthoaincc) |
| 6 | B06 B06.1 | P_G_DU(so_pgdu, ma_kh, ngaygoiduong, thoigiangoiduong, tenkhachhang) C_T_PGĐU(ma_du, so_pgdu, size, soluong, yeucaudacbiet) |
| 7 | B07 B07.1 | HD_BDUONG(so_hdbdu, ma_kh, so_pgdu, ngaylaphoadon, thoigianthanhtoan, hinhthucthanhtoan, trangthai, ghichu, nguoilaphoadon) C_T_HDBĐU(so_hdbdu, ma_du, size, soluongban, thanhtien) |
| 8 | B08 B08.1 | D_NLM(so_dnlm, ngaylapdon, nhacungcap, diachincc, sodienthoaincc, bophan, ghichu, nguoilapdon, quanly) C_T_ĐNLM(ma_nl, so_dnlm, soluongdenghi, dongiadukien) |
| 9 | B09 B09.1 | P_NH(so_pnh, ma_ncc, so_dnlm, ngaygiao, thoigiangiaohang, tenkhachhang, nguoigiaohang, nguoinhanhang) C_T_PNH(so_pnh, ma_nl, soluonggiao, tinhtrang, ghichu) |
| 10 | B10 B10.1 | PKK(so_pkk, ma_ncc, ngaykiemke, thoigiankiemke, nguoigiamsat) C_T_PKK(so_pkk, ma_nl, soluong, soluongthucte, chenhlech, hansudung, tinhtrangchatluong, ghichu) |

(5) Ký hiệu sử dụng

### [TABLE 44]
|  | - Kiểu quan hệ |
|  | - Liên kết 1-n |
|  | - Khóa chính |
|  | - khóa ngoài |
|  | - Vừa khóa chính, vừa khóa ngoài |

(6) Mô hình quan hệ RM
##### 2.2.3. Đặc tả dữ liệu
B01. LDU

### [TABLE 45]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | ma_ldu | C (6) | Mã loại đồ uống |
| 2 |  |  | tenloaidouong | C (50) | Tên loại đồ uống |

B02. NL

### [TABLE 46]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | ma_nl | C (6) | Mã nguyên liệu |
| 2 |  |  | tennguyenlieu | C (50) | Tên nguyên liệu |
| 3 |  |  | donvitinh | C (20) | Đơn vị tính |

B03. DU

### [TABLE 47]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | ma_du | C (6) | Mã đồ uống |
| 2 |  | x | ma_loaidouong | C (6) | Mã loại đồ uống |
| 3 |  |  | tendouong | C (50) | Tên đồ uống |
| 4 |  |  | dongia | N(10) | Đơn giá |

B03.1. DU_NL

### [TABLE 48]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x | x | ma_nl | C (6) | Mã nguyên liệu |
| 2 | x | x | ma_douong | C (6) | Mã đồ uống |

B04. K_H

### [TABLE 49]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | ma_kh | C (6) | Mã khách hàng |
| 2 |  |  | tenkhachhang | C (50) | Tên khách hàng |
| 3 |  |  | sodienthoaikh | C (10) | Số điện thoại |
| 4 |  |  | diachikh | C (50) | Địa chỉ |
| 5 |  |  | gioitinh | C (10) | Giới tính |

B05. NCC

### [TABLE 50]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | ma_ncc | C (6) | Mã nhà cung cấp |
| 2 |  |  | tennhacungcap | C (50) | Tên nhà cung cấp |
| 3 |  |  | diachincc | C (50) | Địa chỉ |
| 4 |  |  | sodienthoaincc | C (10) | Số điện thoại |

B06. P_G_DU

### [TABLE 51]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | so_pgdu | C (6) | Số phiếu gọi đồ uống |
| 2 |  |  | ngaygoiduong | D (8) | Ngày gọi đồ uống |
| 3 |  |  | thoigiangoiduong | D (8) | Thời gian gọi đồ uống |
| 4 |  |  | tenkhachhang | C (50) | Tên khách hàng trên phiếu gọi |

B06.1. C_T_PGĐU

### [TABLE 52]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x | x | ma_du | C (6) | Mã đồ uống |
| 2 | x | x | so_pgdu | C (6) | Số phiếu gọi đồ uống |
| 3 |  |  | size | C (10) | Kích cỡ đồ uống |
| 4 |  |  | soluong | N (10) | Số lượng |

B07. HD_BDUONG

### [TABLE 53]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | so_hdbdu | C (6) | Số hóa đơn bán đồ uống |
| 2 |  | x | ma_kh | C (10) | Mã khách hàng |
| 3 |  | x | so_pgdu | C (10) | Số phiếu gọi đồ uống |
| 4 |  |  | ngaylaphoadon | D (8) | Ngày lập hóa đơn |
| 5 |  |  | thoigianthanhtoan | D (8) | Thời gian thanh toán |
| 6 |  |  | hinhthucthanhtoan | C (30) | Hình thức thanh toán |
| 7 |  |  | trangthai | C (20) | Trạng thái hóa đơn |
| 8 |  |  | ghichu | C (255) | Ghi chú |
| 9 |  |  | nguoilaphoadon | C (50) | Người lập hóa đơn |

B07.1. C_T_HDBĐU

### [TABLE 54]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x | x | so_hdbdu | C (6) | Số hóa đơn bán đồ uống |
| 2 | x | x | ma_du | C (6) | Mã đồ uống |
| 3 |  |  | size | C (10) | Kích cỡ đồ uống |
| 4 |  |  | soluong | N (10) | Số lượng |
| 5 |  |  | thanhtiendu | N (10) | Thành tiền đồ uống |

B08. D_NLM

### [TABLE 55]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | so_dnlm | C (6) | Số đơn mua nguyên liệu |
| 2 |  |  | ngaylapdon | D (8) | Ngày lập đơn |
| 3 |  |  | nhacungcap | C (50) | Tên nhà cung cấp |
| 4 |  |  | diachincc | C (100) | Địa chỉ nhà cung cấp |
| 5 |  |  | sodienthoaincc | C (10) | Số điện thoại nhà cung cấp |
| 6 |  |  | bophan | C (50) | Bộ phận đề nghị mua |
| 7 |  |  | ghichu | C (255) | Ghi chú |
| 8 |  |  | nguoilapdon | C (50) | Người lập đơn |
| 9 |  |  | quanly | C (50) | Người quản lý phê duyệt |

B08.1. C_T_ĐNLM

### [TABLE 56]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x | x | ma_nl | C (6) | Mã nguyên liệu |
| 2 | x | x | so_dnlm | C (6) | Số đơn mua nguyên liệu |
| 3 |  |  | soluongdenghi | N (8) | Số lượng đề nghị |
| 4 |  |  | dongiadukien | N (8) | Đơn giá dự kiến |

B09. P_NH

### [TABLE 57]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | so_pnh | C (6) | Số phiếu nhập hàng |
| 2 |  | x | ma_ncc | C (6) | Mã nhà cung cấp |
| 3 |  | x | so_dnlm | C (6) | Số đơn mua nguyên liệu |
| 4 |  |  | ngaygiao | D (8) | Ngày giao hàng |
| 5 |  |  | thoigiangiaohang | D (8) | Thời gian giao hàng |
| 6 |  |  | tenkhachhang | C (50) | Tên người/đơn vị giao |
| 7 |  |  | nguoigiaohang | C (50) | Người giao hàng |
| 8 |  |  | nguoinhanhang | C (50) | Người nhận hàng |

B09.1. C_T_HDGH

### [TABLE 58]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x | x | so_pnh | C (6) | Số phiếu nhập hàng |
| 2 | x | x | ma_nl | C (6) | Mã nguyên liệu |
| 3 |  |  | soluonggiao | N (10) | Số lượng giao |
| 4 |  |  | tinhtrang | C (30) | Tình trạng hàng giao |
| 5 |  |  | ghichu | C (255) | Ghi chú |

B10. P_KK

### [TABLE 59]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x |  | so_pkk | C (6) | Số phiếu kiểm kê |
| 2 |  | x | ma_ncc | C (10) | Mã nhà cung cấp |
| 3 |  |  | ngaykiemke | D (8) | Ngày kiểm kê |
| 4 |  |  | thoigiankiemke | D (8) | Thời gian kiểm kê |
| 5 |  |  | nguoithuchienkiemke | C (50) | Người thực hiện kiểm kê |
| 6 |  |  | nguoigiamsat | C (50) | Người giám sát |

B10.1. C_T_PKK

### [TABLE 60]
| STT | Khóa chính | Khóa ngoại | Tên trường | Kiểu dữ liệu | Diễn giải |
| 1 | x | x | so_pkk | C (6) | Số phiếu kiểm kê |
| 2 | x | x | ma_nl | C (6) | Mã nguyên liệu |
| 3 |  |  | soluong | N (10) | Số lượng theo sổ |
| 4 |  |  | soluongthucte | N (10) | Số lượng thực tế |
| 5 |  |  | chenhlech | N (10) | Chênh lệch số lượng |
| 6 |  |  | hansudung | D (8) | Hạn sử dụng |
| 7 |  |  | tinhtrangchatluong | C (50) | Tình trạng chất lượng |
| 8 |  |  | ghichu | C (255) | Ghi chú |

### Chương 3. THIẾT KẾ HỆ THỐNG
#### 3.1. Thiết kế tổng thể
##### 3.1.1. Xác định tiến trình hệ thống
Bảng 9. Tổng hợp tiến trình hệ thống

### [TABLE 61]
| STT | Tiến trình phân định | TT | Tiến trình hệ thống |
| 1 | 01.01. Lập phiếu gọi đồ uống | 001 | Mở form phiếu gọi đồ uống |
| 1 | 01.01. Lập phiếu gọi đồ uống | 002 | Tìm kiếm thông tin phiếu gọi đồ uống theo so_pgdu |
| 1 | 01.01. Lập phiếu gọi đồ uống | 003 | Sinh tự động so_pgdu, ngaygoiduong, thoigiangoiduong theo khuôn mẫu |
| 1 | 01.01. Lập phiếu gọi đồ uống | 004 | Tìm kiếm thông tin đồ uống theo ma_du, tendouong, ma_ldu |
| 1 | 01.01. Lập phiếu gọi đồ uống | 005 | Kiểm soát dữ liệu nhập: ma_du, size, soluong, yeucaudacbiet |
| 1 | 01.01. Lập phiếu gọi đồ uống | 006 | Truy xuất dongia của đồ uống từ bảng B03. DU |
| 1 | 01.01. Lập phiếu gọi đồ uống | 007 | Lưu thông tin phiếu gọi đồ uống vào B06. P_G_DU và B06.1. C_T_PGDU |
| 1 | 01.01. Lập phiếu gọi đồ uống | 008 | Thông báo kết quả lưu phiếu gọi đồ uống |
| 1 | 01.01. Lập phiếu gọi đồ uống | 009 | Cập nhật thông tin phiếu gọi đồ uống khi có thay đổi ma_du, size, soluong, yeucaudacbiet |
| 1 | 01.01. Lập phiếu gọi đồ uống | 010 | Thông báo kết quả cập nhật phiếu gọi đồ uống |
| 1 | 01.01. Lập phiếu gọi đồ uống | 011 | In phiếu gọi đồ uống |
| 1 | 01.01. Lập phiếu gọi đồ uống | 012 | Thông báo trạng thái in phiếu gọi đồ uống |
| 1 | 01.01. Lập phiếu gọi đồ uống | 013 | Xóa phiếu gọi đồ uống và hóa đơn liên quan |
| 1 | 01.01. Lập phiếu gọi đồ uống | 014 | Thông báo yêu cầu xác nhận xóa phiếu gọi đồ uống và hóa đơn liên quan |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống |  | Mở form phiếu gọi đồ uống |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống |  | Tìm kiếm thông tin phiếu gọi đồ uống theo so_pgdu |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống | 015 | Truy xuất thông tin phiếu gọi đồ uống từ B06. P_G_DU, B06.1. C_T_PGDU |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống | 016 | Kiểm soát dữ liệu nhập trạng thái phục vụ đồ uống theo phiếu gọi |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống | 017 | Truy xuất thông tin pha chế hoàn tất |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống | 018 | Đối chiếu thông tin đồ uống đã pha chế với ma_du, size, soluong, yeucaudacbiet trên phiếu gọi |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống | 019 | In phiếu tạm tính |
| 2 | 01.02. Cập nhật trạng thái phục vụ đồ uống | 020 | Thông báo kết quả cập nhật trạng thái phục vụ đồ uống |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 021 | Mở form hóa đơn bán đồ uống |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 022 | Tìm kiếm thông tin hóa đơn bán đồ uống theo so_hdbdu |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 023 | Sinh tự động so_hdbdu, ngaylaphoadon, thoigianthanhtoan theo khuôn mẫu |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 024 | Tìm kiếm thông tin khách hàng theo ma_kh, tenkhachhang, sodienthoaikh |
| 3 | 02.01. Lập hóa đơn bán đồ uống |  | Truy xuất thông tin phiếu gọi đồ uống từ B06. P_G_DU, B06.1. C_T_PGDU |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 025 | Kiểm soát dữ liệu nhập: ma_kh, so_pgdu, hinhthucthanhtoan, trangthai, ghichu, nguoilaphoadon |
| 3 | 02.01. Lập hóa đơn bán đồ uống |  | Truy xuất dongia của đồ uống từ bảng B03. DU |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 026 | Tính toán thanhtiendu cho từng dòng đồ uống |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 027 | Lưu thông tin hóa đơn bán đồ uống vào B07. HD_BDU và B07.1. C_T_HDBDU |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 028 | Thông báo kết quả lưu hóa đơn bán đồ uống |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 029 | In hóa đơn bán đồ uống |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 030 | Thông báo trạng thái in hóa đơn bán đồ uống |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 031 | Xóa hóa đơn bán đồ uống |
| 3 | 02.01. Lập hóa đơn bán đồ uống | 032 | Thông báo yêu cầu xác nhận xóa hóa đơn bán đồ uống |
| 4 | 02.02. Lập đơn nguyên liệu mua | 033 | Mở form đơn nguyên liệu mua |
| 4 | 02.02. Lập đơn nguyên liệu mua | 034 | Tìm kiếm thông tin đơn nguyên liệu mua theo so_dnlm |
| 4 | 02.02. Lập đơn nguyên liệu mua | 035 | Sinh tự động so_dnlm, ngaylapdon theo khuôn mẫu |
| 4 | 02.02. Lập đơn nguyên liệu mua | 036 | Tìm kiếm thông tin nhà cung cấp theo ma_ncc, tennhacungcap, sodienthoaincc |
| 4 | 02.02. Lập đơn nguyên liệu mua | 037 | Tìm kiếm thông tin nguyên liệu theo ma_nl, tennguyenlieu, donvitinh |
| 4 | 02.02. Lập đơn nguyên liệu mua | 038 | Truy xuất nhu cầu nguyên liệu cần bổ sung |
| 4 | 02.02. Lập đơn nguyên liệu mua | 039 | Kiểm soát dữ liệu nhập: ma_nl, soluongdenghi, dongiadukien, ghichu, bophan, nguoilapdon, quanly |
| 4 | 02.02. Lập đơn nguyên liệu mua | 040 | Tính toán thành tiền dự kiến cho từng nguyên liệu cần mua |
| 4 | 02.02. Lập đơn nguyên liệu mua | 041 | Lưu thông tin đơn nguyên liệu mua vào B08. D_NLM và B08.1. C_T_DNLMUA |
| 4 | 02.02. Lập đơn nguyên liệu mua | 042 | Thông báo kết quả lưu đơn nguyên liệu mua |
| 4 | 02.02. Lập đơn nguyên liệu mua | 043 | Cập nhật thông tin đơn nguyên liệu mua |
| 4 | 02.02. Lập đơn nguyên liệu mua | 044 | Thông báo kết quả cập nhật đơn nguyên liệu mua |
| 4 | 02.02. Lập đơn nguyên liệu mua | 045 | In đơn nguyên liệu mua |
| 4 | 02.02. Lập đơn nguyên liệu mua | 046 | Thông báo trạng thái in đơn nguyên liệu mua |
| 4 | 02.02. Lập đơn nguyên liệu mua | 047 | Xóa thông tin đơn nguyên liệu mua |
| 4 | 02.02. Lập đơn nguyên liệu mua | 048 | Thông báo yêu cầu xác nhận xóa đơn nguyên liệu mua |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 049 | Mở form thống kê doanh thu ngày |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 050 | Sinh tự động ngày lập thống kê theo khuôn mẫu |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 051 | Truy xuất hóa đơn bán đồ uống trong ngày từ B07. HD_BDU, B07.1. C_T_HDBDU |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 052 | Tính toán tổng doanh thu ngày từ thanhtiendu |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 053 | Tính toán tổng số hóa đơn bán đồ uống trong ngày theo so_hdbdu |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 054 | Tính toán tổng số lượng đồ uống bán ra trong ngày theo ma_du, soluong |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 055 | Truy xuất thông tin đồ uống theo ma_du, tendouong |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 056 | Xuất thống kê doanh thu ngày dưới dạng bản mềm |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 057 | In thống kê doanh thu ngày |
| 5 | 02.03. Lập Thống kê doanh thu ngày | 058 | Thông báo trạng thái in thống kê doanh thu ngày |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 059 | Mở form biên bản đối soát chênh lệch doanh thu |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 060 | Sinh tự động ngày lập biên bản theo khuôn mẫu |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 061 | Truy xuất doanh thu hệ thống từ B07. HD_BDU, B07.1. C_T_HDBDU |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 062 | Kiểm soát dữ liệu nhập doanh thu thực tế và nội dung đối soát |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 063 | Tính toán chênh lệch giữa doanh thu hệ thống và doanh thu thực tế |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 064 | Tính toán tỷ lệ chênh lệch doanh thu |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 065 | Lưu biên bản đối soát chênh lệch doanh thu |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 066 | Thông báo kết quả lưu biên bản đối soát chênh lệch doanh thu |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 067 | Xuất biên bản đối soát dưới dạng bản mềm |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 068 | In biên bản đối soát chênh lệch doanh thu |
| 6 | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | 069 | Thông báo trạng thái in biên bản đối soát chênh lệch doanh thu |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 070 | Mở form thống kê đồ uống bán chạy trong tháng |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 071 | Sinh tự động ngày lập thống kê theo khuôn mẫu |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 072 | Truy xuất hóa đơn bán đồ uống trong tháng từ B07. HD_BDU, B07.1. C_T_HDBDU |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 073 | Tổng hợp số lượng bán ra của từng đồ uống theo ma_du, soluong |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 074 | Tính toán doanh thu từng đồ uống theo thanhtiendu |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 075 | Sắp xếp đồ uống theo số lượng bán ra giảm dần |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng |  | Truy xuất thông tin đồ uống theo ma_du, tendouong |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 076 | Xuất thống kê đồ uống bán chạy trong tháng dưới dạng bản mềm |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 077 | In thống kê đồ uống bán chạy trong tháng |
| 7 | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | 078 | Thông báo trạng thái in thống kê đồ uống bán chạy trong tháng |
| 8 | 03.01. Cập nhật trạng thái pha chế |  | Mở form phiếu gọi đồ uống |
| 8 | 03.01. Cập nhật trạng thái pha chế |  | Tìm kiếm thông tin phiếu gọi đồ uống theo so_pgdu |
| 8 | 03.01. Cập nhật trạng thái pha chế |  | Truy xuất thông tin chi tiết phiếu gọi đồ uống từ B06. P_G_DU, B06.1. C_T_PGDU |
| 8 | 03.01. Cập nhật trạng thái pha chế |  | Tìm kiếm thông tin nguyên liệu theo ma_nl, tennguyenlieu, donvitinh |
| 8 | 03.01. Cập nhật trạng thái pha chế | 079 | Truy xuất công thức nguyên liệu đồ uống từ B03.1. DU_NL theo ma_du, ma_nl |
| 8 | 03.01. Cập nhật trạng thái pha chế | 080 | Kiểm soát dữ liệu nhập trạng thái pha chế |
| 8 | 03.01. Cập nhật trạng thái pha chế | 081 | Kiểm tra khả năng đáp ứng nguyên liệu cho pha chế |
| 8 | 03.01. Cập nhật trạng thái pha chế | 082 | Cập nhật trạng thái pha chế đồ uống |
| 8 | 03.01. Cập nhật trạng thái pha chế | 083 | Thông báo kết quả cập nhật trạng thái pha chế |
| 9 | 03.02. Cập nhật Menu | 084 | Mở form đồ uống |
| 9 | 03.02. Cập nhật Menu |  | Tìm kiếm thông tin đồ uống theo ma_du, tendouong, ma_ldu |
| 9 | 03.02. Cập nhật Menu | 085 | Sinh tự động ma_du theo khuôn mẫu |
| 9 | 03.02. Cập nhật Menu | 086 | Tìm kiếm thông tin loại đồ uống theo ma_ldu, tenloaidouong |
| 9 | 03.02. Cập nhật Menu | 087 | Kiểm soát dữ liệu nhập: ma_du, ma_ldu, tendouong, dongia |
| 9 | 03.02. Cập nhật Menu | 088 | Lưu thông tin đồ uống vào B03. DU |
| 9 | 03.02. Cập nhật Menu | 089 | Thông báo kết quả lưu thông tin đồ uống |
| 9 | 03.02. Cập nhật Menu | 090 | Cập nhật thông tin đồ uống trong Menu |
| 9 | 03.02. Cập nhật Menu | 091 | Thông báo kết quả cập nhật Menu |
| 9 | 03.02. Cập nhật Menu | 092 | Xóa thông tin đồ uống trên Menu |
| 9 | 03.02. Cập nhật Menu | 093 | Thông báo yêu cầu xác nhận xóa đồ uống trên Menu |
| 10 | 03.03. Lập phiếu nhập hàng | 094 | Mở form phiếu nhập hàng |
| 10 | 03.03. Lập phiếu nhập hàng | 095 | Tìm kiếm thông tin phiếu nhập hàng theo so_pnh |
| 10 | 03.03. Lập phiếu nhập hàng | 096 | Sinh tự động so_pnh, ngaygiao, thoigiangiaohang theo khuôn mẫu |
| 10 | 03.03. Lập phiếu nhập hàng |  | Tìm kiếm thông tin nhà cung cấp theo ma_ncc, tennhacungcap, sodienthoaincc |
| 10 | 03.03. Lập phiếu nhập hàng | 097 | Truy xuất thông tin đơn nguyên liệu mua theo so_dnlm |
| 10 | 03.03. Lập phiếu nhập hàng |  | Tìm kiếm thông tin nguyên liệu theo ma_nl, tennguyenlieu, donvitinh |
| 10 | 03.03. Lập phiếu nhập hàng | 098 | Kiểm soát dữ liệu nhập: so_pnh, ma_ncc, so_dnlm, nguoigiaohang, nguoinhanhang, ma_nl, soluonggiao, tinhtrang, ghichu |
| 10 | 03.03. Lập phiếu nhập hàng | 099 | Lưu thông tin phiếu nhập hàng vào B09. P_NH và B09.1. C_T_PNH |
| 10 | 03.03. Lập phiếu nhập hàng | 100 | Thông báo kết quả lưu phiếu nhập hàng |
| 10 | 03.03. Lập phiếu nhập hàng | 101 | Cập nhật thông tin phiếu nhập hàng |
| 10 | 03.03. Lập phiếu nhập hàng | 102 | Thông báo kết quả cập nhật thông tin phiếu nhập hàng |
| 10 | 03.03. Lập phiếu nhập hàng | 103 | In phiếu nhập hàng |
| 10 | 03.03. Lập phiếu nhập hàng | 104 | Thông báo trạng thái in phiếu nhập hàng |
| 10 | 03.03. Lập phiếu nhập hàng | 105 | Xóa thông tin phiếu nhập hàng |
| 10 | 03.03. Lập phiếu nhập hàng | 106 | Thông báo yêu cầu xác nhận xóa phiếu nhập hàng |
| 11 | 03.04. Lập phiếu kiểm kê | 107 | Mở form phiếu kiểm kê |
| 11 | 03.04. Lập phiếu kiểm kê | 108 | Tìm kiếm thông tin phiếu kiểm kê theo so_pkk |
| 11 | 03.04. Lập phiếu kiểm kê | 109 | Sinh tự động so_pkk, ngaykiemke, thoigiankiemke theo khuôn mẫu |
| 11 | 03.04. Lập phiếu kiểm kê |  | Tìm kiếm thông tin nhà cung cấp theo ma_ncc, tennhacungcap, sodienthoaincc |
| 11 | 03.04. Lập phiếu kiểm kê |  | Tìm kiếm thông tin nguyên liệu theo ma_nl, tennguyenlieu, donvitinh |
| 11 | 03.04. Lập phiếu kiểm kê | 110 | Kiểm soát dữ liệu nhập: so_pkk, ma_ncc, nguoithuchienkiemke, nguoigiamsat, ma_nl, soluongtheokiemke, soluongthucte, hansudung, tinhtrangchatluong, ghichu |
| 11 | 03.04. Lập phiếu kiểm kê | 111 | Tính toán chenhlech nguyên liệu kiểm kê |
| 11 | 03.04. Lập phiếu kiểm kê | 112 | Lưu thông tin phiếu kiểm kê vào B10. P_KK và B10.1. C_T_PKK và cập nhật số lượng nguyên liệu |
| 11 | 03.04. Lập phiếu kiểm kê | 113 | Thông báo kết quả lưu phiếu kiểm kê |
| 11 | 03.04. Lập phiếu kiểm kê | 114 | Cập nhật thông tin phiếu kiểm kê và số lượng nguyên liệu |
| 11 | 03.04. Lập phiếu kiểm kê | 115 | Thông báo kết quả cập nhật phiếu kiểm kê |
| 11 | 03.04. Lập phiếu kiểm kê | 116 | In phiếu kiểm kê |
| 11 | 03.04. Lập phiếu kiểm kê | 117 | Thông báo trạng thái in phiếu kiểm kê |
| 11 | 03.04. Lập phiếu kiểm kê | 118 | Xóa phiếu kiểm kê |
| 11 | 03.04. Lập phiếu kiểm kê | 119 | Thông báo yêu cầu xác nhận xóa phiếu kiểm kê |
| 12 | 03.05. Cập nhật nguyên liệu | 120 | Mở form nguyên liệu |
| 12 | 03.05. Cập nhật nguyên liệu |  | Tìm kiếm thông tin nguyên liệu theo ma_nl, tennguyenlieu, donvitinh |
| 12 | 03.05. Cập nhật nguyên liệu | 121 | Sinh tự động ma_nl theo khuôn mẫu |
| 12 | 03.05. Cập nhật nguyên liệu | 122 | Kiểm soát dữ liệu nhập: ma_nl, tennguyenlieu, donvitinh |
| 12 | 03.05. Cập nhật nguyên liệu | 123 | Truy xuất thông tin từ phiếu nhập hàng B09. P_NH, B09.1. C_T_PNH |
| 12 | 03.05. Cập nhật nguyên liệu | 124 | Truy xuất thông tin từ phiếu kiểm kê B10. P_KK, B10.1. C_T_PKK |
| 12 | 03.05. Cập nhật nguyên liệu | 125 | Cập nhật thông tin nguyên liệu trong B02. NL |
| 12 | 03.05. Cập nhật nguyên liệu | 126 | Thông báo kết quả cập nhật nguyên liệu |
| 13 | 04.01. Quản lý nhóm người dùng | 127 | Mở form nhóm người dùng |
| 13 | 04.01. Quản lý nhóm người dùng | 128 | Tìm kiếm thông tin nhóm người dùng theo ma_nhom, tennhom |
| 13 | 04.01. Quản lý nhóm người dùng | 129 | Sinh tự động ma_nhom theo khuôn mẫu |
| 13 | 04.01. Quản lý nhóm người dùng | 130 | Kiểm soát dữ liệu nhập: ma_nhom, tennhom, mota |
| 13 | 04.01. Quản lý nhóm người dùng | 131 | Lưu thông tin nhóm người dùng |
| 13 | 04.01. Quản lý nhóm người dùng | 132 | Thông báo kết quả lưu thông tin nhóm người dùng |
| 13 | 04.01. Quản lý nhóm người dùng | 133 | Cập nhật thông tin nhóm người dùng |
| 13 | 04.01. Quản lý nhóm người dùng | 134 | Thông báo kết quả cập nhật thông tin nhóm người dùng |
| 13 | 04.01. Quản lý nhóm người dùng | 135 | Xóa nhóm người dùng |
| 13 | 04.01. Quản lý nhóm người dùng | 136 | Thông báo yêu cầu xác nhận xóa nhóm người dùng |
| 14 | 04.02. Quản lý tài khoản người dùng | 137 | Mở form tài khoản người dùng |
| 14 | 04.02. Quản lý tài khoản người dùng | 138 | Tìm kiếm thông tin tài khoản người dùng |
| 14 | 04.02. Quản lý tài khoản người dùng | 139 | Sinh tự động ma_taikhoan theo khuôn mẫu |
| 14 | 04.02. Quản lý tài khoản người dùng |  | Tìm kiếm thông tin nhóm người dùng theo ma_nhom, tennhom |
| 14 | 04.02. Quản lý tài khoản người dùng | 140 | Kiểm soát dữ liệu nhập |
| 14 | 04.02. Quản lý tài khoản người dùng | 141 | Lưu thông tin tài khoản người dùng |
| 14 | 04.02. Quản lý tài khoản người dùng | 142 | Thông báo kết quả lưu thông tin tài khoản người dùng |
| 14 | 04.02. Quản lý tài khoản người dùng | 143 | Cập nhật thông tin tài khoản người dùng |
| 14 | 04.02. Quản lý tài khoản người dùng | 144 | Thông báo kết quả cập nhật thông tin tài khoản người dùng |
| 14 | 04.02. Quản lý tài khoản người dùng | 145 | Xóa tài khoản người dùng |
| 14 | 04.02. Quản lý tài khoản người dùng | 146 | Thông báo yêu cầu xác nhận xóa tài khoản người dùng |
| 15 | 04.03. Phân quyền người dùng | 147 | Mở form phân quyền người dùng |
| 15 | 04.03. Phân quyền người dùng |  | Tìm kiếm thông tin nhóm người dùng theo ma_nhom, tennhom |
| 15 | 04.03. Phân quyền người dùng |  | Tìm kiếm thông tin tài khoản người dùng theo ma_taikhoan, tendangnhap |
| 15 | 04.03. Phân quyền người dùng | 148 | Truy xuất danh sách quyền chức năng hệ thống theo ma_chucnang |
| 15 | 04.03. Phân quyền người dùng | 149 | Kiểm soát dữ liệu nhập: ma_nhom, ma_chucnang, quyentruycap (xem/them/sua/xoa) |
| 15 | 04.03. Phân quyền người dùng | 150 | Cập nhật thông tin phân quyền người dùng |
| 15 | 04.03. Phân quyền người dùng | 151 | Thông báo kết quả cập nhật thông tin phân quyền người dùng |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 152 | Mở form sao lưu và phục hồi dữ liệu |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 153 | Tìm kiếm thông tin lịch sử sao lưu |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 154 | Sinh tự động ma_saoluu, ngay_gio_saoluu theo khuôn mẫu |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 155 | Kiểm soát dữ liệu nhập |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 156 | Thực hiện sao lưu toàn bộ dữ liệu hệ thống |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 157 | Thông báo kết quả sao lưu dữ liệu hệ thống |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 158 | Truy xuất danh sách bản sao lưu khả dụng |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 159 | Kiểm soát dữ liệu nhập phục hồi |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 160 | Thông báo yêu cầu xác nhận phục hồi dữ liệu từ bản sao lưu đã chọn |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 161 | Thực hiện phục hồi dữ liệu hệ thống từ bản sao lưu |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 162 | Thông báo kết quả phục hồi dữ liệu hệ thống |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 163 | Xuất lịch sử sao lưu và phục hồi dưới dạng bản mềm |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 164 | In báo cáo lịch sử sao lưu và phục hồi |
| 16 | 04.04. Sao lưu phục hồi dữ liệu hệ thống | 165 | Thông báo trạng thái in báo cáo sao lưu và phục hồi |
| 17 | 04.05. Theo dõi nhật ký hoạt động | 166 | Mở form nhật ký hoạt động |
| 17 | 04.05. Theo dõi nhật ký hoạt động | 167 | Tìm kiếm thông tin nhật ký hoạt động |
| 17 | 04.05. Theo dõi nhật ký hoạt động | 168 | Truy xuất thông tin nhật ký hoạt động |
| 17 | 04.05. Theo dõi nhật ký hoạt động | 169 | Kiểm soát dữ liệu lọc |
| 17 | 04.05. Theo dõi nhật ký hoạt động | 170 | Hiển thị chi tiết nhật ký |
| 17 | 04.05. Theo dõi nhật ký hoạt động | 171 | Xuất nhật ký hoạt động dưới dạng bản mềm |
| 17 | 04.05. Theo dõi nhật ký hoạt động | 172 | In nhật ký hoạt động |
| 17 | 04.05. Theo dõi nhật ký hoạt động | 173 | Thông báo trạng thái in nhật ký hoạt động |

##### 3.1.2. Xác định kho dữ liệu hệ thống
Bảng 10. Tổng hợp kho dữ liệu hệ thống

### [TABLE 62]
| Kho dữ liệu nghiệp vụ | Kho dữ liệu hệ thống | Kho dữ liệu hệ thống | Kho dữ liệu hệ thống | Tiến trình sử dụng | Tiến trình sử dụng |
| Kho dữ liệu nghiệp vụ | STT | Mã LĐ | Tên lược đồ | TT | Tên tiến trình hệ thống |
|  | 1 | B01 | LDU | 086 | Tìm kiếm thông tin loại đồ uống theo ma_ldu, tenloaidouong |
| K.02. Nguyên liệu | 2 | B02 | NL | 037 | Tìm kiếm thông tin nguyên liệu theo ma_nl, tennguyenlieu, donvitinh |
| K.02. Nguyên liệu | 2 | B02 | NL | 038 | Truy xuất nhu cầu nguyên liệu cần bổ sung |
| K.02. Nguyên liệu | 2 | B02 | NL | 123 | Cập nhật thông tin nguyên liệu trong B02. NL |
| K.02. Nguyên liệu | 2 | B02 | NL | 099 | Lưu thông tin phiếu nhập hàng vào B09. P_NH và B09.1. C_T_PNH |
| K.02. Nguyên liệu | 2 | B02 | NL | 101 | Cập nhật thông tin phiếu nhập hàng |
| K.02. Nguyên liệu | 2 | B02 | NL | 112 | Lưu thông tin phiếu kiểm kê vào B10. P_KK và B10.1. C_T_PKK |
| K.02. Nguyên liệu | 2 | B02 | NL | 114 | Cập nhật thông tin phiếu kiểm kê |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 004 | Tìm kiếm thông tin đồ uống theo ma_du, tendouong, ma_ldu |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 006 | Truy xuất đơn giá đồ uống |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 055 | Truy xuất thông tin đồ uống theo ma_du, tendouong |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 079 | Truy xuất công thức nguyên liệu đồ uống theo ma_du, ma_nl |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 086 | Tìm kiếm thông tin loại đồ uống theo ma_ldu, tenloaidouong |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 088 | Lưu thông tin đồ uống vào B03. DU |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 090 | Cập nhật thông tin đồ uống trong Menu |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 092 | Xóa thông tin đồ uống trên Menu |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 007 | Lưu thông tin phiếu gọi đồ uống vào B06. P_G_DU và B06.1. C_T_PGDU |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 009 | Cập nhật thông tin phiếu gọi đồ uống khi có thay đổi ma_du, size, soluong, yeucaudacbiet |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 013 | Xóa phiếu gọi đồ uống và hóa đơn liên quan |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 027 | Lưu thông tin hóa đơn bán đồ uống vào B07. HD_BDU và B07.1. C_T_HDBDU |
| K.01. Đồ uống | 3 | B03 B03.1 | DU DU_NL | 031 | Xóa hóa đơn bán đồ uống |
|  | 4 | B04 | K_H | 024 | Tìm kiếm thông tin khách hàng theo ma_kh, tenkhachhang, sodienthoaikh |
|  | 4 | B04 | K_H | 027 | Lưu thông tin hóa đơn bán đồ uống vào B07. HD_BDU và B07.1. C_T_HDBDU |
|  | 5 | B05 | NCC | 036 | Tìm kiếm thông tin nhà cung cấp theo ma_ncc, tennhacungcap, sodienthoaincc |
|  | 5 | B05 | NCC | 099 | Lưu thông tin phiếu nhập hàng vào B09. P_NH và B09.1. C_T_PNH |
|  | 5 | B05 | NCC | 101 | Cập nhật thông tin phiếu nhập hàng |
|  | 5 | B05 | NCC | 112 | Lưu thông tin phiếu kiểm kê vào B10. P_KK và B10.1. C_T_PKK và cập nhật số lượng nguyên liệu |
|  | 5 | B05 | NCC | 114 | Cập nhật thông tin phiếu kiểm kê và số lượng nguyên liệu |
| K.03. Phiếu gọi đồ uông | 6 | B06 B06.1 | P_G_DU C_T_PGĐU | 002 | Tìm kiếm thông tin phiếu gọi đồ uống theo so_pgdu |
| K.03. Phiếu gọi đồ uông | 6 | B06 B06.1 | P_G_DU C_T_PGĐU | 007 | Lưu thông tin phiếu gọi đồ uống vào B06. P_G_DU và B06.1. C_T_PGDU |
| K.03. Phiếu gọi đồ uông | 6 | B06 B06.1 | P_G_DU C_T_PGĐU | 009 | Cập nhật thông tin phiếu gọi đồ uống khi có thay đổi ma_du, size, soluong, yeucaudacbiet |
| K.03. Phiếu gọi đồ uông | 6 | B06 B06.1 | P_G_DU C_T_PGĐU | 013 | Truy xuất thông tin phiếu gọi đồ uống từ B06. P_G_DU, B06.1. C_T_PGDU |
| K.03. Phiếu gọi đồ uông | 6 | B06 B06.1 | P_G_DU C_T_PGĐU | 078 | Xóa phiếu gọi đồ uống và hóa đơn liên quan |
| K.04. Hóa đơn bán đồ uống | 7 | B07 B07.1 | HD_BDU C_T_HDBĐU | 022 | Tìm kiếm thông tin hóa đơn bán đồ uống theo so_hdbdu |
| K.04. Hóa đơn bán đồ uống | 7 | B07 B07.1 | HD_BDU C_T_HDBĐU | 013 | Truy xuất thông tin phiếu gọi đồ uống từ B06. P_G_DU, B06.1. C_T_PGDU |
| K.04. Hóa đơn bán đồ uống | 7 | B07 B07.1 | HD_BDU C_T_HDBĐU | 027 | Lưu thông tin hóa đơn bán đồ uống vào B07. HD_BDU và B07.1. C_T_HDBDU |
| K.04. Hóa đơn bán đồ uống | 7 | B07 B07.1 | HD_BDU C_T_HDBĐU | 051 | Truy xuất hóa đơn bán đồ uống trong ngày từ B07. HD_BDU, B07.1. C_T_HDBDU |
| K.04. Hóa đơn bán đồ uống | 7 | B07 B07.1 | HD_BDU C_T_HDBĐU | 061 | Truy xuất doanh thu hệ thống từ B07. HD_BDU, B07.1. C_T_HDBDU |
| K.04. Hóa đơn bán đồ uống | 7 | B07 B07.1 | HD_BDU C_T_HDBĐU | 072 | Truy xuất hóa đơn bán đồ uống trong tháng từ B07. HD_BDU, B07.1. C_T_HDBDU |
| K.04. Hóa đơn bán đồ uống | 7 | B07 B07.1 | HD_BDU C_T_HDBĐU | 027 | Lưu thông tin hóa đơn bán đồ uống vào B07. HD_BDU và B07.1. C_T_HDBDU |
| K.04. Hóa đơn bán đồ uống | 7 | B07 B07.1 | HD_BDU C_T_HDBĐU | 031 | Xóa hóa đơn bán đồ uống |
| K.05. Đơn nguyên liệu mua | 8 | B08 B08.1 | D_NLM C_T_ĐNLM | 034 | Tìm kiếm thông tin đơn nguyên liệu mua theo so_dnlm |
| K.05. Đơn nguyên liệu mua | 8 | B08 B08.1 | D_NLM C_T_ĐNLM | 038 | Truy xuất nhu cầu nguyên liệu cần bổ sung |
| K.05. Đơn nguyên liệu mua | 8 | B08 B08.1 | D_NLM C_T_ĐNLM | 041 | Lưu thông tin đơn nguyên liệu mua vào B08. D_NLM và B08.1. C_T_DNLMUA |
| K.05. Đơn nguyên liệu mua | 8 | B08 B08.1 | D_NLM C_T_ĐNLM | 043 | Cập nhật thông tin đơn nguyên liệu mua |
|  |  |  |  | 047 | Xóa thông tin đơn nguyên liệu mua |
| K.06. Phiếu nhập hàng | 9 | B09 B09.1 | P_NH C_T_PNH | 095 | Tìm kiếm thông tin phiếu nhập hàng theo so_pnh |
| K.06. Phiếu nhập hàng | 9 | B09 B09.1 | P_NH C_T_PNH | 097 | Truy xuất thông tin đơn nguyên liệu mua theo so_dnlm |
| K.06. Phiếu nhập hàng | 9 | B09 B09.1 | P_NH C_T_PNH | 099 | Lưu thông tin phiếu nhập hàng vào B09. P_NH và B09.1. C_T_PNH |
| K.06. Phiếu nhập hàng | 9 | B09 B09.1 | P_NH C_T_PNH | 103 | Xóa thông tin phiếu nhập hàng |
| K.07.Phiếu kiểm kê | 10 | B10 B10.1 | P_KK C_T_PKK | 106 | Tìm kiếm thông tin phiếu kiểm kê theo so_pkk |
| K.07.Phiếu kiểm kê | 10 | B10 B10.1 | P_KK C_T_PKK | 110 | Lưu thông tin phiếu kiểm kê vào B10. P_KK và B10.1. C_T_PKK |
| K.07.Phiếu kiểm kê | 10 | B10 B10.1 | P_KK C_T_PKK | 112 | Cập nhật thông tin phiếu kiểm kê |
| K.07.Phiếu kiểm kê | 10 | B10 B10.1 | P_KK C_T_PKK | 116 | Xóa phiếu kiểm kê |
|  | 11 | B11 B11.1 | NGUOIDUNG ND_NHOM | 138 | Tìm kiếm thông tin tài khoản người dùng |
|  | 11 | B11 B11.1 | NGUOIDUNG ND_NHOM | 141 | Lưu thông tin tài khoản người dùng |
|  | 11 | B11 B11.1 | NGUOIDUNG ND_NHOM | 143 | Cập nhật thông tin tài khoản người dùng |
|  | 11 | B11 B11.1 | NGUOIDUNG ND_NHOM | 145 | Xóa tài khoản người dùng |
|  | 12 | B12 | NHOMND | 128 | Tìm kiếm thông tin nhóm người dùng theo ma_nhom, tennhom |
|  | 12 | B12 | NHOMND | 131 | Lưu thông tin nhóm người dùng |
|  | 12 | B12 | NHOMND | 133 | Cập nhật thông tin nhóm người dùng |
|  | 12 | B12 | NHOMND | 135 | Xóa nhóm người dùng |
|  | 13 | B13 B13.1 | QUYEN PHANQUYEN | 150 | Cập nhật thông tin phân quyền người dùng |
|  | 14 | B14 | SAOLUUDULIEU | 153 | Tìm kiếm thông tin lịch sử sao lưu |
|  | 15 | B15 | NHATKYHOATDONG | 167 | Tìm kiếm thông tin nhật ký hoạt động |

##### 3.1.3. DFD hệ thống
#### 3.2. Thiết kế kiểm soát
##### 3.2.1. Xác định nhóm người dùng
Bảng 11. Tổng hợp nhóm người dùng

### [TABLE 63]
| STT | Nhóm người dùng | Bộ phận tương ứng | Chức năng liên quan |
| 1 | N01. Nhân viên phục vụ | BP.01. Bộ phận phục vụ | 01.01. Lập phiếu gọi đồ uống 01.02. Cập nhật trạng thái phục vụ đồ uống |
| 2 | N02. Nhân viên thu ngân | BP.02. Bộ phận thu ngân | 02.01. Lập hóa đơn bán đồ uống 02.02. Lập đơn nguyên liệu mua 02.03. Lập Thống kê doanh thu ngày 02.04. Lập biên bản Đối soát chênh lệch doanh thu 02.05. Lập Thống kê đồ uống bán chạy trong tháng |
| 3 | N03. Nhân viên pha chế | BP.03. Bộ phận pha chế | 03.01. Cập nhật trạng thái pha chế 03.02. Cập nhật Menu 03.03. Lập phiếu nhập hàng 03.04. Lập phiếu kiểm kê 03.05. Cập nhật nguyên liệu |
| 4 | N04.Người quản trị |  | 04.01. Quản lý nhóm người dùng 04.02. Quản lý tài khoản người dùng 04.03. Phân quyền người dùng 04.04. Sao lưu phục hồi dữ liệu hệ thống 04.05. Theo dõi nhật ký hoạt động |

##### 3.2.2. Phân định quyền hạn nhóm người dùng
3.2.2.1. Phân định quyền hạn về dữ liệu

### [TABLE 64]
| STT | Kho dữ liệu hệ thống | Nhân viên phục vụ | Nhân viên thu ngân | Nhân viên pha chế | Người quản trị |
| 1 | B01. LDU | R | R | C,E,R,D | R |
| 2 | B02. NL | R | R | C,E,R,D | R |
| 3 | B03. DU B03.1. DU_NL | R | R | C,E,R,D | R |
| 4 | B04. K_H | C,E,R,D | R | R | C,E,R,D |
| 5 | B05. NCC | C,E,R,D | R | R | C,E,R,D |
| 6 | B06. P_G_DU B06.1. C_T_PGĐU | C,E,R,D | E,R | R | R |
| 7 | B07. HD_BDU B07.1. C_T_HDBĐU | C,E,R,D | R | R | R |
| 8 | B08. D_NLM B08.1. C_T_ĐNLM | C,E,R,D | R | R | R |
| 9 | B09. P_NH B09.1. C_T_PNH | C,E,R,D | R | R | R |
| 10 | B10. P_KK B10.1. C_T_PKK | R | R | C,E,R,D | R |
| 11 | B11. NGUOIDUNG B11.1. ND_NHOM | R | R | R | C,E,R,D |
| 12 | B12.NHOMND | R | R | R | C,E,R,D |
| 13 | B13.QUYEN B13.1. PHANQUYEN | R | R | R | C,E,R,D |
| 14 | B14. SAOLUUDULIEU | R | R | R | R,D |
| 15 | B14.1. NHATKYHOATDONG | R | R | R | R,D |

3.2.2.2. Phân định quyền hạn về tiến trình

### [TABLE 65]
| STT | TTHT NND | Nhân viên phục vụ | Nhân viên thu ngân | Nhân viên pha chế | Người quản trị |
| 1 | 001. Mở form phiếu gọi đồ uống | A | nA | nA | nA |
| 2 | 002. Tìm kiếm thông tin phiếu gọi đồ uống theo so_pgdu | A | nA | nA | nA |
| 3 | 003. Sinh tự động so_pgdu, ngaygoiduong, thoigiangoiduong theo khuôn mẫu | A | nA | nA | nA |
| 4 | 004. Tìm kiếm thông tin đồ uống theo ma_du, tendouong, ma_ldu | A | nA | nA | nA |
| 5 | 005. Kiểm soát dữ liệu nhập: ma_du, size, soluong, yeucaudacbiet | A | nA | nA | nA |
| 6 | 006. Truy xuất dongia của đồ uống từ bảng B03. DU | A | nA | nA | nA |
| 7 | 007. Lưu thông tin phiếu gọi đồ uống vào B06. P_G_DU và B06.1. C_T_PGDU | A | nA | nA | nA |
| 8 | 008. Thông báo kết quả lưu phiếu gọi đồ uống | A | nA | nA | nA |
| 9 | 009. Cập nhật thông tin phiếu gọi đồ uống khi có thay đổi ma_du, size, soluong, yeucaudacbiet | A | nA | nA | nA |
| 10 | 010. Thông báo kết quả cập nhật phiếu gọi đồ uống | A | nA | nA | nA |
| 11 | 011. In phiếu gọi đồ uống | A | nA | nA | nA |
| 12 | 012. Thông báo trạng thái in phiếu gọi đồ uống | A | nA | nA | nA |
| 13 | 013. Xóa phiếu gọi đồ uống và hóa đơn liên quan | A | nA | nA | nA |
| 14 | 014. Thông báo yêu cầu xác nhận xóa phiếu gọi đồ uống và hóa đơn liên quan | A | nA | nA | nA |
| 15 | 015. Truy xuất thông tin phiếu gọi đồ uống từ B06. P_G_DU, B06.1. C_T_PGDU | A | nA | nA | nA |
| 16 | 016. Kiểm soát dữ liệu nhập trạng thái phục vụ đồ uống theo phiếu gọi | A | nA | nA | nA |
| 17 | 017. Truy xuất thông tin pha chế hoàn tất | A | nA | nA | nA |
| 18 | 018. Đối chiếu thông tin đồ uống đã pha chế với ma_du, size, soluong, yeucaudacbiet trên phiếu gọi | A | nA | nA | nA |
| 19 | 019. In phiếu tạm tính | A | nA | nA | nA |
| 20 | 020. Thông báo kết quả cập nhật trạng thái phục vụ đồ uống | A | nA | nA | nA |
| 21 | 021. Mở form hóa đơn bán đồ uống | A | nA | nA | nA |
| 22 | 022. Tìm kiếm thông tin hóa đơn bán đồ uống theo so_hdbdu | nA | A | nA | nA |
| 23 | 023. Sinh tự động so_hdbdu, ngaylaphoadon, thoigianthanhtoan theo khuôn mẫu | nA | A | nA | nA |
| 24 | 024. Tìm kiếm thông tin khách hàng theo ma_kh, tenkhachhang, sodienthoaikh | nA | A | nA | nA |
| 25 | 025. Kiểm soát dữ liệu nhập: ma_kh, so_pgdu, hinhthucthanhtoan, trangthai, ghichu, nguoilaphoadon | nA | A | nA | nA |
| 26 | 026. Tính toán thanhtiendu cho từng dòng đồ uống | nA | A | nA | nA |
| 27 | 027. Lưu thông tin hóa đơn bán đồ uống vào B07. HD_BDU và B07.1. C_T_HDBDU | nA | A | nA | nA |
| 28 | 028. Thông báo kết quả lưu hóa đơn bán đồ uống | nA | A | nA | nA |
| 29 | 029. In hóa đơn bán đồ uống | nA | A | nA | nA |
| 30 | 030. Thông báo trạng thái in hóa đơn bán đồ uống | nA | A | nA | nA |
| 31 | 031. Xóa hóa đơn bán đồ uống | nA | A | nA | nA |
| 32 | 032. Thông báo yêu cầu xác nhận xóa hóa đơn bán đồ uống | nA | A | nA | nA |
| 33 | 033. Mở form đơn nguyên liệu mua | nA | A | nA | nA |
| 34 | 034. Tìm kiếm thông tin đơn nguyên liệu mua theo so_dnlm | nA | A | nA | nA |
| 35 | 035. Sinh tự động so_dnlm, ngaylapdon theo khuôn mẫu | nA | A | nA | nA |
| 36 | 036. Tìm kiếm thông tin nhà cung cấp theo ma_ncc, tennhacungcap, sodienthoaincc | nA | A | nA | nA |
| 37 | 037. Tìm kiếm thông tin nguyên liệu theo ma_nl, tennguyenlieu, donvitinh | nA | A | nA | nA |
| 38 | 038. Truy xuất nhu cầu nguyên liệu cần bổ sung | nA | A | nA | nA |
| 39 | 039. Kiểm soát dữ liệu nhập: ma_nl, soluongdenghi, dongiadukien, ghichu, bophan, nguoilapdon, quanly | nA | A | nA | nA |
| 40 | 040. Tính toán thành tiền dự kiến cho từng nguyên liệu cần mua | nA | A | nA | nA |
| 41 | 041. Lưu thông tin đơn nguyên liệu mua vào B08. D_NLM và B08.1. C_T_DNLMUA | nA | A | nA | nA |
| 42 | 042. Thông báo kết quả lưu đơn nguyên liệu mua | nA | A | nA | nA |
| 43 | 043. Cập nhật thông tin đơn nguyên liệu mua | nA | A | nA | nA |
| 44 | 044. Thông báo kết quả cập nhật đơn nguyên liệu mua | nA | A | nA | nA |
| 45 | 045. In đơn nguyên liệu mua | nA | A | nA | nA |
| 46 | 046. Thông báo trạng thái in đơn nguyên liệu mua | nA | A | nA | nA |
| 47 | 047. Xóa thông tin đơn nguyên liệu mua | nA | A | nA | nA |
| 48 | 048. Thông báo yêu cầu xác nhận xóa đơn nguyên liệu mua | nA | A | nA | nA |
| 49 | 049. Mở form thống kê doanh thu ngày | nA | A | nA | nA |
| 50 | 050. Sinh tự động ngày lập thống kê theo khuôn mẫu | nA | A | nA | nA |
| 51 | 051. Truy xuất hóa đơn bán đồ uống trong ngày từ B07. HD_BDU, B07.1. C_T_HDBDU | nA | A | nA | nA |
| 52 | 052. Tính toán tổng doanh thu ngày từ thanhtiendu | nA | A | nA | nA |
| 53 | 053. Tính toán tổng số hóa đơn bán đồ uống trong ngày theo so_hdbdu | nA | A | nA | nA |
| 54 | 054. Tính toán tổng số lượng đồ uống bán ra trong ngày theo ma_du, soluong | nA | A | nA | nA |
| 55 | 055. Truy xuất thông tin đồ uống theo ma_du, tendouong | nA | A | nA | nA |
| 56 | 056. Xuất thống kê doanh thu ngày dưới dạng bản mềm | nA | A | nA | nA |
| 57 | 057. In thống kê doanh thu ngày | nA | A | nA | nA |
| 58 | 058. Thông báo trạng thái in thống kê doanh thu ngày | nA | A | nA | nA |
| 59 | 059. Mở form biên bản đối soát chênh lệch doanh thu | nA | A | nA | nA |
| 60 | 060. Sinh tự động ngày lập biên bản theo khuôn mẫu | nA | A | nA | nA |
| 61 | 061. Truy xuất doanh thu hệ thống từ B07. HD_BDU, B07.1. C_T_HDBDU | nA | A | nA | nA |
| 62 | 062. Kiểm soát dữ liệu nhập doanh thu thực tế và nội dung đối soát | nA | A | nA | nA |
| 63 | 063. Tính toán chênh lệch giữa doanh thu hệ thống và doanh thu thực tế | nA | A | nA | nA |
| 64 | 064. Tính toán tỷ lệ chênh lệch doanh thu | nA | A | nA | nA |
| 65 | 065. Lưu biên bản đối soát chênh lệch doanh thu | nA | A | nA | nA |
| 66 | 066. Thông báo kết quả lưu biên bản đối soát chênh lệch doanh thu | nA | A | nA | nA |
| 67 | 067. Xuất biên bản đối soát dưới dạng bản mềm | nA | A | nA | nA |
| 68 | 068. In biên bản đối soát chênh lệch doanh thu | nA | A | nA | nA |
| 69 | 069. Thông báo trạng thái in biên bản đối soát chênh lệch doanh thu | nA | A | nA | nA |
| 70 | 070. Mở form thống kê đồ uống bán chạy trong tháng | nA | A | nA | nA |
| 71 | 071. Sinh tự động ngày lập thống kê theo khuôn mẫu | nA | A | nA | nA |
| 72 | 072. Truy xuất hóa đơn bán đồ uống trong tháng từ B07. HD_BDU, B07.1. C_T_HDBDU | nA | A | nA | nA |
| 73 | 073. Tổng hợp số lượng bán ra của từng đồ uống theo ma_du, soluong | nA | A | nA | nA |
| 74 | 074. Tính toán doanh thu từng đồ uống theo thanhtiendu | nA | A | nA | nA |
| 75 | 075. Sắp xếp đồ uống theo số lượng bán ra giảm dần | nA | A | nA | nA |
| 76 | 076. Xuất thống kê đồ uống bán chạy trong tháng dưới dạng bản mềm | nA | A | nA | nA |
| 77 | 077. In thống kê đồ uống bán chạy trong tháng | nA | A | nA | nA |
| 78 | 078. Thông báo trạng thái in thống kê đồ uống bán chạy trong tháng | nA | A | nA | nA |
| 79 | 079. Truy xuất công thức nguyên liệu đồ uống từ B03.1. DU_NL theo ma_du, ma_nl | nA | nA | A | nA |
| 80 | 080. Kiểm soát dữ liệu nhập trạng thái pha chế | nA | nA | A | nA |
| 81 | 081. Kiểm tra khả năng đáp ứng nguyên liệu cho pha chế | nA | nA | A | nA |
| 82 | 082. Cập nhật trạng thái pha chế đồ uống | nA | nA | A | nA |
| 83 | 083. Thông báo kết quả cập nhật trạng thái pha chế | nA | nA | A | nA |
| 84 | 084. Mở form đồ uống | nA | nA | A | nA |
| 85 | 085. Sinh tự động ma_du theo khuôn mẫu | nA | nA | A | nA |
| 86 | 086. Tìm kiếm thông tin loại đồ uống theo ma_ldu, tenloaidouong | nA | nA | A | nA |
| 87 | 087. Kiểm soát dữ liệu nhập: ma_du, ma_ldu, tendouong, dongia | nA | nA | A | nA |
| 88 | 088. Lưu thông tin đồ uống vào B03. DU | nA | nA | A | nA |
| 89 | 089. Thông báo kết quả lưu thông tin đồ uống | nA | nA | A | nA |
| 90 | 090. Cập nhật thông tin đồ uống trong Menu | nA | nA | A | nA |
| 91 | 091. Thông báo kết quả cập nhật Menu | nA | nA | A | nA |
| 92 | 092. Xóa thông tin đồ uống trên Menu | nA | nA | A | nA |
| 93 | 093. Thông báo yêu cầu xác nhận xóa đồ uống trên Menu | nA | nA | A | nA |
| 94 | 094. Mở form phiếu nhập hàng | nA | nA | A | nA |
| 95 | 095. Tìm kiếm thông tin phiếu nhập hàng theo so_pnh | nA | nA | A | nA |
| 96 | 096. Sinh tự động so_pnh, ngaygiao, thoigiangiaohang theo khuôn mẫu | nA | nA | A | nA |
| 97 | 097. Truy xuất thông tin đơn nguyên liệu mua theo so_dnlm | nA | nA | A | nA |
| 98 | 098. Kiểm soát dữ liệu nhập: so_pnh, ma_ncc, so_dnlm, nguoigiaohang, nguoinhanhang, ma_nl, soluonggiao, tinhtrang, ghichu | nA | nA | A | nA |
| 99 | 099. Lưu thông tin phiếu nhập hàng vào B09. P_NH và B09.1. C_T_PNH | nA | nA | A | nA |
| 100 | 100. Thông báo kết quả lưu phiếu nhập hàng | nA | nA | A | nA |
| 101 | 101. Cập nhật thông tin phiếu nhập hàng | nA | nA | A | nA |
| 102 | 102. Thông báo kết quả cập nhật thông tin phiếu nhập hàng | nA | nA | A | nA |
| 103 | 103. In phiếu nhập hàng | nA | nA | A | nA |
| 104 | 104. Thông báo trạng thái in phiếu nhập hàng | nA | nA | A | nA |
| 105 | 105. Xóa thông tin phiếu nhập hàng | nA | nA | A | nA |
| 106 | 106. Thông báo yêu cầu xác nhận xóa phiếu nhập hàng | nA | nA | A | nA |
| 107 | 107. Mở form phiếu kiểm kê | nA | nA | A | nA |
| 108 | 108. Tìm kiếm thông tin phiếu kiểm kê theo so_pkk | nA | nA | A | nA |
| 109 | 109. Sinh tự động so_pkk, ngaykiemke, thoigiankiemke theo khuôn mẫu | nA | nA | A | nA |
| 110 | 110. Kiểm soát dữ liệu nhập: so_pkk, ma_ncc, nguoithuchienkiemke, nguoigiamsat, ma_nl, soluongtheokiemke, soluongthucte, hansudung, tinhtrangchatluong, ghichu | nA | nA | A | nA |
| 111 | 111. Tính toán chenhlech nguyên liệu kiểm kê | nA | nA | A | nA |
| 112 | 112. Lưu thông tin phiếu kiểm kê vào B10. P_KK và B10.1. C_T_PKK và cập nhật số lượng nguyên liệu | nA | nA | A | nA |
| 113 | 113. Thông báo kết quả lưu phiếu kiểm kê | nA | nA | A | nA |
| 114 | 114. Cập nhật thông tin phiếu kiểm kê và số lượng nguyên liệu | nA | nA | A | nA |
| 115 | 115. Thông báo kết quả cập nhật phiếu kiểm kê | nA | nA | A | nA |
| 116 | 116. In phiếu kiểm kê | nA | nA | A | nA |
| 117 | 117. Thông báo trạng thái in phiếu kiểm kê | nA | nA | A | nA |
| 118 | 118. Xóa phiếu kiểm kê | nA | nA | A | nA |
| 119 | 119. Thông báo yêu cầu xác nhận xóa phiếu kiểm kê | nA | nA | A | nA |
| 120 | 120. Mở form nguyên liệu | nA | nA | A | nA |
| 121 | 121. Sinh tự động ma_nl theo khuôn mẫu | nA | nA | A | nA |
| 122 | 122. Kiểm soát dữ liệu nhập: ma_nl, tennguyenlieu, donvitinh | nA | nA | A | nA |
| 123 | 123. Truy xuất thông tin từ phiếu nhập hàng B09. P_NH, B09.1. C_T_PNH | nA | nA | A | nA |
| 124 | 124. Truy xuất thông tin từ phiếu kiểm kê B10. P_KK, B10.1. C_T_PKK | nA | nA | A | nA |
| 125 | 125. Cập nhật thông tin nguyên liệu trong B02. NL | nA | nA | A | nA |
| 126 | 126. Thông báo kết quả cập nhật nguyên liệu | nA | nA | A | nA |
| 127 | 127. Mở form nhóm người dùng | nA | nA | nA | A |
| 128 | 128. Tìm kiếm thông tin nhóm người dùng theo ma_nhom, tennhom | nA | nA | nA | A |
| 129 | 129.Sinh tự động ma_nhom theo khuôn mẫu | nA | nA | nA | A |
| 130 | 130. Kiểm soát dữ liệu nhập: ma_nhom, tennhom, mota | nA | nA | nA | A |
| 131 | 131. Lưu thông tin nhóm người dùng | nA | nA | nA | A |
| 132 | 132. Thông báo kết quả lưu thông tin nhóm người dùng | nA | nA | nA | A |
| 133 | 133.Cập nhật thông tin nhóm người dùng | nA | nA | nA | A |
| 134 | 134.Thông báo kết quả cập nhật thông tin nhóm người dùng | nA | nA | nA | A |
| 135 | 135. Xóa nhóm người dùng | nA | nA | nA | A |
| 136 | 136. Thông báo yêu cầu xác nhận xóa nhóm người dùng | nA | nA | nA | A |
| 137 | 137. Mở form tài khoản người dùng | nA | nA | nA | A |
| 138 | 138. Sinh tự động ma_taikhoan theo khuôn mẫu | nA | nA | nA | A |
| 139 | 139. Kiểm soát dữ liệu nhập: ma_taikhoan, tendangnhap, matkhau, ma_nhom, quyentruycap, trangthai | nA | nA | nA | A |
| 140 | 140. Lưu thông tin tài khoản người dùng | nA | nA | nA | A |
| 141 | 141. Thông báo kết quả lưu thông tin tài khoản người dùng | nA | nA | nA | A |
| 142 | 142. Cập nhật thông tin tài khoản người dùng | nA | nA | nA | A |
| 143 | 143. Thông báo kết quả cập nhật thông tin tài khoản người dùng | nA | nA | nA | A |
| 144 | 144. Xóa tài khoản người dùng | nA | nA | nA | A |
| 145 | 145 Thông báo yêu cầu xác nhận xóa tài khoản người dùng | nA | nA | nA | A |
| 146 | 146. Mở form phân quyền người dùng | nA | nA | nA | A |
| 147 | 147. Tìm kiếm thông tin tài khoản người dùng theo ma_taikhoan, tendangnhap | nA | nA | nA | A |
| 148 | 148. Truy xuất danh sách quyền chức năng hệ thống theo ma_chucnang | nA | nA | nA | A |
| 149 | 149. Kiểm soát dữ liệu nhập: ma_nhom, ma_chucnang, quyentruycap (xem/them/sua/xoa) | nA | nA | nA | A |
| 150 | 150. Cập nhật thông tin phân quyền người dùng | nA | nA | nA | A |
| 151 | 151. Thông báo kết quả cập nhật thông tin phân quyền người dùng | nA | nA | nA | A |
| 152 | 152. Mở form sao lưu và phục hồi dữ liệu | nA | nA | nA | A |
| 153 | 153. Tìm kiếm thông tin lịch sử sao lưu theo ma_saoluu, ngaysaoluu, loaisaoluu | nA | nA | nA | A |
| 154 | 154. Sinh tự động ma_saoluu, ngay_gio_saoluu theo khuôn mẫu | nA | nA | nA | A |
| 155 | 155. Kiểm soát dữ liệu nhập: loaisaoluu, duongdan_luutru, ghichu, nguoithuchien | nA | nA | nA | A |
| 156 | 156. Thực hiện sao lưu toàn bộ dữ liệu hệ thống | nA | nA | nA | A |
| 157 | 157. Thông báo kết quả sao lưu dữ liệu hệ thống | nA | nA | nA | A |
| 158 | 158. Truy xuất danh sách bản sao lưu khả dụng theo ma_saoluu, ngaysaoluu | nA | nA | nA | A |
| 159 | 159. Kiểm soát dữ liệu nhập phục hồi: ma_saoluu, nguoithuchien, lydo_phuchoi | nA | nA | nA | A |
| 160 | 160. Thông báo yêu cầu xác nhận phục hồi dữ liệu từ bản sao lưu đã chọn | nA | nA | nA | A |
| 161 | 161. Thực hiện phục hồi dữ liệu hệ thống từ bản sao lưu | nA | nA | nA | A |
| 162 | 162. Thông báo kết quả phục hồi dữ liệu hệ thống | nA | nA | nA | A |
| 163 | 163. Xuất lịch sử sao lưu và phục hồi dưới dạng bản mềm | nA | nA | nA | A |
| 164 | 164. In báo cáo lịch sử sao lưu và phục hồi | nA | nA | nA | A |
| 165 | 165. Thông báo trạng thái in báo cáo sao lưu và phục hồi | nA | nA | nA | A |
| 166 | 166. Mở form nhật ký hoạt động | nA | nA | nA | A |
| 167 | 167. Tìm kiếm thông tin nhật ký hoạt động | nA | nA | nA | A |
| 168 | 168. Truy xuất thông tin nhật ký hoạt động từ B_NHATKY theo bộ lọc | nA | nA | nA | A |
| 169 | 169. Kiểm soát dữ liệu lọc | nA | nA | nA | A |
| 170 | 170. Hiển thị chi tiết nhật ký: tên người dùng, thời gian, loại thao tác, đối tượng, kết quả | nA | nA | nA | A |
| 171 | 171. Xuất nhật ký hoạt động dưới dạng bản mềm | nA | nA | nA | A |
| 172 | 172. In nhật ký hoạt động | nA | nA | nA | A |
| 173 | 173. Thông báo trạng thái in nhật ký hoạt động | nA | nA | nA | A |

#### 3.3. Thiết kế cơ sở dữ liệu
##### 3.3.1. Đánh giá nhu cầu bảo mật
3.3.1.1. Thêm bảng dữ liệu phục vụ bảo mật
Dựa vào yêu cầu bảo mật và kiểm soát rủi ro, hệ thống phân nhóm người dùng và phân quyền đối với từng nhóm người dùng. Mỗi người dùng được cấp tài khoản riêng, truy cập vào hệ thống dựa trên tên đăng nhập và mật khẩu cài đặt, và được thực hiện các chức năng đúng theo quyền hạn của mình. Khi người dùng đăng nhập vào hệ thống, lịch sử đăng nhập được ghi lại, các hoạt động thay đổi nội dung bên trong của hệ thống cũng được ghi lại để dễ dàng truy cứu trách nhiệm liên quan. Vì vậy, cơ sở dữ liệu xây dựng thêm các bảng liên quan đến dữ liệu của người dùng, cụ thể:

### [TABLE 66]
| STT | Mã LĐ | Tên LĐ | Lý do đưa vào | Lược đồ quan hệ |
| 1 | B11 B11.1 | NGUOIDUNG ND_NHOM | Lưu trữ thông tin tài khoản người dùng trong hệ thống | NGUOIDUNG (ma_nd, tennd, sdt, usr, pwd_hash, vitri, trangthai) ND_NHOM (ma_nd, ma_nhom) |
| 2 | B12 | NHOMND | Phân loại người dùng theo từng nhóm trong hệ thống | ND_NHOM (ma_nd, ma_nhom) |
| 3 | B13 B13.1 | QUYEN PHANQUYEN | Định nghĩa các quyền có trong hệ thống và Phân quyền cho các nhóm người dùng | QUYEN (ma_quyen, tenquyen) PHANQUYEN (ma_nhom, ma_quyen) |
| 4 | B14 | SAOLUUDULIEU | Lưu trữ thông tin lịch sử sao lưu, đường dẫn file sao lưu để phục hồi dữ liệu khi có sự cố | SAOLUUDULIEU (ma_saoluu, thoigiansaoluu, tenfile, duongdanfile, trangthai, ghichu, ma_nd) |
| 5 | B15 | NHATKYHOATDONG | Ghi lại các hoạt động thay đổi nội dung bên trong của hệ thống | NHATKYHOATDONG (ma_nk, thoigian, noidung, ttcu, ttmoi, ma_lichsu) |

3.3.1.2. Thêm thuộc tính kiểm soát
Đối với bảng dữ liệu liên quan nghiệp vụ thêm trường kiểm soát tennd, ma_nd cho 5 bảng giao dịch : B06. P_G_DU, B07. HD_BDUONG, B08. D_NLM, B09. P_NH, B10. P_KK. Các bảng sau khi thêm trường kiểm soát như sau:

### [TABLE 67]
| STT | Tên bảng | Bảng ban đầu | Bảng sau thêm |
| 1 | B06. P_G_DU |  |  |
| 2 | B07. HD_BDUONG |  |  |
| 3 | B08. D_NLM |  |  |
| 4 | B09. P_NH |  |  |
| 5 | B10. P_KK |  |  |

##### 3.3.2. Đánh giá nhu cầu cải thiện tính hiệu quả
3.3.2.1. Nghiên cứu gom nhóm bảng dữ liệu và cắt quan hệ
(1) Gom nhóm bảng
Dựa trên yêu cầu của bài toán gom nhóm các bảng GIAO DỊCH – CHI TIẾT GIAO DỊCH, nếu số trường dữ liệu dư thừa bé hơn 3, ta tiến hành gom nhóm. Do vậy, kết quả gom nhóm các bảng GIAO DỊCH – CHI TIẾT GIAO DỊCH như sau:

### [TABLE 68]
| STT | Bảng chính | Bảng phụ | Số trường dữ liệu dư thừa | Quyết định gom | Bảng sau gom |
| 1 |  |  | 4 | Không |  |
| 2 |  |  | 7 | Không |  |
| 3 |  |  | 9 | Không |  |
| 4 |  |  | 6 | Không |  |
| 5 |  |  | 5 | Không |  |

(2) Cắt quan hệ bảng
Dựa trên yêu cầu của bài toán cắt quan hệ các bảng, nếu số trường dữ liệu thay đổi bé hơn 2, ta tiến hành cắt quan hệ.

### [TABLE 69]
| STT | Mẫu biểu | Bảng dữ liệu liên quan | Nhóm bảng quan hệ cũ | Bảng quan hệ sau khi gom | Số trường dữ liệu dư | Quyết định cắt quan hệ |
| 1 | MB.02. Phiếu gọi đồ uống | B03.DU B04.KH B06. P_G_DU B06.1. C_T_PGĐU |  |  | 3 | Không |
| 1 | MB.02. Phiếu gọi đồ uống | B03.DU B04.KH B06. P_G_DU B06.1. C_T_PGĐU |  |  | 1 | Có |
| 2 | MB.04. Hóa đơn bán đồ uống | B03.DU B04.KH B07. HD_BDU B07.1. C_T_HDBĐU |  |  | 1 | Có |
| 2 | MB.04. Hóa đơn bán đồ uống | B03.DU B04.KH B07. HD_BDU B07.1. C_T_HDBĐU |  |  | 1 | Có |
| 3 | MB.06. Phiếu nhập hàng | B02.NL B05.NCC B09. P_NH B09.1. C_T_PNH |  |  | 1 | Có |
| 3 | MB.06. Phiếu nhập hàng | B02.NL B05.NCC B09. P_NH B09.1. C_T_PNH |  |  | 1 | Có |
| 4 | MB08. Báo cáo doanh thu theo ngày | B03. DU B03.1. DU_NL B07. HD_BDU B07.1. C_T_HDBĐU |  |  | 0 | Không |
| 5 | MB.10. Báo cáo đồ uống bán chạy trong tháng | B03. DU B03.1. DU_NL B07. HD_BDU B07.1. C_T_HDBĐU |  |  | 0 | Không |

3.3.2.2. Nghiên cứu thêm trường

### [TABLE 70]
| STT | Bảng cũ | Thêm trường | Bảng mới |
| 1 |  | thanhtien = dongia * soluongban |  |
| 2 |  | thanhtien = dongia * soluongban |  |
| 3 |  | thanhtiendukien = dongiadukien*soluongdenghi |  |
| 4 |  | chenhlech=soluongthucte-soluongtheokiemke |  |

##### 3.3.3. Mô hình dữ liệu hệ thống
##### 3.3.4. Đặc tả bảng dữ liệu
(1) Bảng B01. LDU

### [TABLE 71]
| 1. Số hiệu: 1 | 1. Số hiệu: 1 | 1. Số hiệu: 1 | 2. Tên bảng: B01. LDU | 2. Tên bảng: B01. LDU | 3. Bí danh: B01. LDU | 3. Bí danh: B01. LDU | 3. Bí danh: B01. LDU |
| 4. Mô tả: Lưu trữ thông tin loại đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin loại đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin loại đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin loại đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin loại đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin loại đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin loại đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin loại đồ uống trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_ldu | ma_ldu | Mã loại đồ uống | C(10) | C(10) | C(10) | x |
| 2 | tenloaidouong | tenloaidouong | Tên loại đồ uống | C(50) | C(50) | C(50) | x |
| 3 | mota | mota | Mô tả | C(100) | C(100) | C(100) |  |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |

(2) Bảng B02. NL

### [TABLE 72]
| 1. Số hiệu: 2 | 1. Số hiệu: 2 | 1. Số hiệu: 2 | 2. Tên bảng: B02. NL | 2. Tên bảng: B02. NL | 3. Bí danh: B02. NL | 3. Bí danh: B02. NL | 3. Bí danh: B02. NL |
| 4. Mô tả: Lưu trữ thông tin nguyên liệu trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_nl | ma_nl | Mã nguyên liệu | C(10) | C(10) | C(10) | x |
| 2 | tennguyenlieu | tennguyenlieu | Tên nguyên liệu | C(50) | C(50) | C(50) | x |
| 3 | donvitinh | donvitinh | Đơn vị tính | C(20) | C(20) | C(20) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |

(3) Bảng B03. DU

### [TABLE 73]
| 1. Số hiệu: 3 | 1. Số hiệu: 3 | 1. Số hiệu: 3 | 2. Tên bảng: B03. DU | 2. Tên bảng: B03. DU | 3. Bí danh: B03. DU | 3. Bí danh: B03. DU | 3. Bí danh: B03. DU |
| 4. Mô tả: Lưu trữ thông tin đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đồ uống trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_du | ma_du | Mã đồ uống | C(10) | C(10) | C(10) | x |
| 2 | ma_ldu | ma_ldu | Mã loại đồ uống | C(10) | C(10) | C(10) | x |
| 3 | tendouong | tendouong | Tên đồ uống | C(50) | C(50) | C(50) | x |
| 4 | dongia | dongia | Đơn giá | N(10) | N(10) | N(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_ldu | ma_ldu | Mã loại đồ uống | Mã loại đồ uống | B01. LDU | B01. LDU |

(4) Bảng B03.1. DU_NL

### [TABLE 74]
| 1. Số hiệu: 4 | 1. Số hiệu: 4 | 1. Số hiệu: 4 | 2. Tên bảng: B03.1. DU_NL | 2. Tên bảng: B03.1. DU_NL | 3. Bí danh: B03.1. DU_NL | 3. Bí danh: B03.1. DU_NL | 3. Bí danh: B03.1. DU_NL |
| 4. Mô tả: Lưu trữ thông tin nguyên liệu cấu thành đồ uống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu cấu thành đồ uống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu cấu thành đồ uống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu cấu thành đồ uống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu cấu thành đồ uống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu cấu thành đồ uống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu cấu thành đồ uống. | 4. Mô tả: Lưu trữ thông tin nguyên liệu cấu thành đồ uống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_nl | ma_nl | Mã nguyên liệu | C(10) | C(10) | C(10) | x |
| 2 | ma_du | ma_du | Mã đồ uống | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_nl | ma_nl | Mã nguyên liệu | Mã nguyên liệu | B02. NL | B02. NL |
| 2 | 2 | ma_du | ma_du | Mã đồ uống | Mã đồ uống | B03. DU | B03. DU |

(5) Bảng B04. K_H

### [TABLE 75]
| 1. Số hiệu: 5 | 1. Số hiệu: 5 | 1. Số hiệu: 5 | 2. Tên bảng: B04. K_H | 2. Tên bảng: B04. K_H | 3. Bí danh: B04. K_H | 3. Bí danh: B04. K_H | 3. Bí danh: B04. K_H |
| 4. Mô tả: Lưu trữ thông tin khách hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin khách hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin khách hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin khách hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin khách hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin khách hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin khách hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin khách hàng trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_kh | ma_kh | Mã khách hàng | C(10) | C(10) | C(10) | x |
| 2 | tenkhachhang | tenkhachhang | Tên khách hàng | C(50) | C(50) | C(50) | x |
| 3 | sodienthoai | sodienthoai | Số điện thoại | N(11) | N(11) | N(11) |  |
| 4 | diachi | diachi | Địa chỉ | C(100) | C(100) | C(100) |  |
| 5 | gioitinh | gioitinh | Giới tính | C(10) | C(10) | C(10) |  |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |

(6) Bảng B05. NCC

### [TABLE 76]
| 1. Số hiệu: 6 | 1. Số hiệu: 6 | 1. Số hiệu: 6 | 2. Tên bảng: B05. NCC | 2. Tên bảng: B05. NCC | 3. Bí danh: B05. NCC | 3. Bí danh: B05. NCC |
| 4. Mô tả: Lưu trữ thông tin nhà cung cấp trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhà cung cấp trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhà cung cấp trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhà cung cấp trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhà cung cấp trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhà cung cấp trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhà cung cấp trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_ncc | ma_ncc | Mã nhà cung cấp | C(10) | C(10) | x |
| 2 | tennhacungcap | tennhacungcap | Tên nhà cung cấp | C(100) | C(100) | x |
| 3 | diachincc | diachincc | Địa chỉ nhà cung cấp | C(100) | C(100) |  |
| 4 | sodienthoaincc | sodienthoaincc | Số điện thoại nhà cung cấp | N(11) | N(11) |  |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng |

(7) Bảng B06. P_G_DU

### [TABLE 77]
| 1. Số hiệu: 7 | 1. Số hiệu: 7 | 1. Số hiệu: 7 | 2. Tên bảng: B06. P_G_DU | 2. Tên bảng: B06. P_G_DU | 3. Bí danh: B06. P_G_DU |
| 4. Mô tả: Lưu trữ thông tin phiếu gọi đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu gọi đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu gọi đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu gọi đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu gọi đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu gọi đồ uống trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | N |
| 1 | so_pgdu | so_pgdu | Số phiếu gọi đồ uống | C(10) | x |
| 2 | ma_kh | ma_kh | Mã khách hàng | C(10) | x |
| 3 | ngaygoiduong | ngaygoiduong | Ngày gọi đồ uống | D(8) | x |
| 4 | thoigiangoiduong | thoigiangoiduong | Thời gian gọi đồ uống | D(8) | x |
| 5 | tenkhachhang | tenkhachhang | Tên khách hàng | C(50) |  |
| 6 | tennd | tennd | Tên người dùng | C(50) | x |
| 7 | ma_nd | ma_nd | Mã người dùng | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Quan hệ với bảng |
| 1 | 1 | ma_kh | ma_kh | Mã khách hàng | B04. K_H |
| 2 | 2 | ma_nd | ma_nd | Mã người dùng | NGUOIDUNG |

(8) Bảng B06.1. C_T_PGDU

### [TABLE 78]
| 1. Số hiệu: 8 | 1. Số hiệu: 8 | 1. Số hiệu: 8 | 2. Tên bảng: B06.1. C_T_PGDU | 2. Tên bảng: B06.1. C_T_PGDU | 3. Bí danh: B06.1. C_T_PGDU | 3. Bí danh: B06.1. C_T_PGDU | 3. Bí danh: B06.1. C_T_PGDU |
| 4. Mô tả: Lưu trữ thông tin chi tiết phiếu gọi đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu gọi đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu gọi đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu gọi đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu gọi đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu gọi đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu gọi đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu gọi đồ uống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_du | ma_du | Mã đồ uống | C(10) | C(10) | C(10) | x |
| 2 | so_pgdu | so_pgdu | Số phiếu gọi đồ uống | C(10) | C(10) | C(10) | x |
| 3 | size | size | Kích cỡ đồ uống | C(10) | C(10) | C(10) | x |
| 4 | soluonggoi | soluonggoi | Số lượng gọi | N(10) | N(10) | N(10) | x |
| 5 | yeucaudacbiet | yeucaudacbiet | Yêu cầu đặc biệt | C(200) | C(200) | C(200) |  |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_du | ma_du | Mã đồ uống | Mã đồ uống | B03. DU | B03. DU |
| 2 | 2 | so_pgdu | so_pgdu | Số phiếu gọi đồ uống | Số phiếu gọi đồ uống | B06. P_G_DU | B06. P_G_DU |

(9) Bảng B07. HD_BDUONG

### [TABLE 79]
| 1. Số hiệu: 9 | 1. Số hiệu: 9 | 1. Số hiệu: 9 | 2. Tên bảng: B07. HD_BDUONG | 2. Tên bảng: B07. HD_BDUONG | 3. Bí danh: B07. HD_BDUONG | 3. Bí danh: B07. HD_BDUONG | 3. Bí danh: B07. HD_BDUONG |
| 4. Mô tả: Lưu trữ thông tin hóa đơn bán đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin hóa đơn bán đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin hóa đơn bán đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin hóa đơn bán đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin hóa đơn bán đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin hóa đơn bán đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin hóa đơn bán đồ uống trong hệ thống. | 4. Mô tả: Lưu trữ thông tin hóa đơn bán đồ uống trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | so_hdbdu | so_hdbdu | Số hóa đơn bán đồ uống | C(10) | C(10) | C(10) | x |
| 2 | ma_khachhang | ma_khachhang | Mã khách hàng | C(10) | C(10) | C(10) | x |
| 3 | so_pgdu | so_pgdu | Số phiếu gọi đồ uống | C(10) | C(10) | C(10) | x |
| 4 | ngaylaphoadon | ngaylaphoadon | Ngày lập hóa đơn | D(8) | D(8) | D(8) | x |
| 5 | thoigianthanhtoan | thoigianthanhtoan | Thời gian thanh toán | D(8) | D(8) | D(8) | x |
| 6 | hinhthucthanhtoan | hinhthucthanhtoan | Hình thức thanh toán | C(30) | C(30) | C(30) | x |
| 7 | trangthai | trangthai | Trạng thái hóa đơn | C(20) | C(20) | C(20) | x |
| 8 | ghichu | ghichu | Ghi chú | C(200) | C(200) | C(200) |  |
| 9 | nguoilaphoadon | nguoilaphoadon | Người lập hóa đơn | C(50) | C(50) | C(50) | x |
| 10 | ma_du | ma_du | Mã đồ uống | C(10) | C(10) | C(10) | x |
| 11 | soluongban | soluongban | Số lượng bán | N(10) | N(10) | N(10) | x |
| 12 | tendouong | tendouong | Tên đồ uống | C(50) | C(50) | C(50) | x |
| 13 | thanhtien | thanhtien | Thành tiền | N(10) | N(10) | N(10) | x |
| 14 | tennd | tennd | Tên người dùng | C(50) | C(50) | C(50) | x |
| 15 | ma_nd | ma_nd | Mã người dùng | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_khachhang | ma_khachhang | Mã khách hàng | Mã khách hàng | B04. K_H | B04. K_H |
| 2 | 2 | so_pgdu | so_pgdu | Số phiếu gọi đồ uống | Số phiếu gọi đồ uống | B06. P_G_DU | B06. P_G_DU |
| 3 | 3 | ma_nd | ma_nd | Mã người dùng | Mã người dùng | NGUOIDUNG | NGUOIDUNG |

(10) Bảng B07.1. C_T_HDBDU

### [TABLE 80]
| 1. Số hiệu: 10 | 1. Số hiệu: 10 | 1. Số hiệu: 10 | 2. Tên bảng: B07.1. C_T_HDBDU | 2. Tên bảng: B07.1. C_T_HDBDU | 3. Bí danh: B07.1. C_T_HDBDU | 3. Bí danh: B07.1. C_T_HDBDU | 3. Bí danh: B07.1. C_T_HDBDU |
| 4. Mô tả: Lưu trữ thông tin chi tiết hóa đơn bán đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết hóa đơn bán đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết hóa đơn bán đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết hóa đơn bán đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết hóa đơn bán đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết hóa đơn bán đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết hóa đơn bán đồ uống. | 4. Mô tả: Lưu trữ thông tin chi tiết hóa đơn bán đồ uống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | so_hdbdu | so_hdbdu | Số hóa đơn bán đồ uống | C(10) | C(10) | C(10) | x |
| 2 | ma_du | ma_du | Mã đồ uống | C(10) | C(10) | C(10) | x |
| 3 | size | size | Kích cỡ đồ uống | C(10) | C(10) | C(10) | x |
| 4 | soluongban | soluongban | Số lượng bán | N(10) | N(10) | N(10) | x |
| 5 | thanhtien | thanhtien | Thành tiền | N(10) | N(10) | N(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | so_hdbdu | so_hdbdu | Số hóa đơn bán đồ uống | Số hóa đơn bán đồ uống | B07. HD_BDUONG | B07. HD_BDUONG |
| 2 | 2 | ma_du | ma_du | Mã đồ uống | Mã đồ uống | B03. DU | B03. DU |

(11) Bảng B08. D_NLM

### [TABLE 81]
| 1. Số hiệu: 11 | 1. Số hiệu: 11 | 1. Số hiệu: 11 | 2. Tên bảng: B08. D_NLM | 2. Tên bảng: B08. D_NLM | 3. Bí danh: B08. D_NLM | 3. Bí danh: B08. D_NLM | 3. Bí danh: B08. D_NLM |
| 4. Mô tả: Lưu trữ thông tin đơn nguyên liệu mua trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đơn nguyên liệu mua trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đơn nguyên liệu mua trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đơn nguyên liệu mua trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đơn nguyên liệu mua trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đơn nguyên liệu mua trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đơn nguyên liệu mua trong hệ thống. | 4. Mô tả: Lưu trữ thông tin đơn nguyên liệu mua trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | so_dnlm | so_dnlm | Số đơn nguyên liệu mua | C(10) | C(10) | C(10) | x |
| 2 | ngaylapdon | ngaylapdon | Ngày lập đơn | D(8) | D(8) | D(8) | x |
| 3 | nhacungcap | nhacungcap | Nhà cung cấp | C(100) | C(100) | C(100) | x |
| 4 | diachi | diachi | Địa chỉ | C(100) | C(100) | C(100) |  |
| 5 | sodienthoai | sodienthoai | Số điện thoại | N(11) | N(11) | N(11) |  |
| 6 | bophan | bophan | Bộ phận lập đơn | C(50) | C(50) | C(50) | x |
| 7 | ghichu | ghichu | Ghi chú | C(200) | C(200) | C(200) |  |
| 8 | nguoilapdon | nguoilapdon | Người lập đơn | C(50) | C(50) | C(50) | x |
| 9 | quanly | quanly | Quản lý duyệt đơn | C(50) | C(50) | C(50) |  |
| 10 | tennd | tennd | Tên người dùng | C(50) | C(50) | C(50) | x |
| 11 | ma_nd | ma_nd | Mã người dùng | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_nd | ma_nd | Mã người dùng | Mã người dùng | NGUOIDUNG | NGUOIDUNG |

(12) Bảng B08.1. C_T_DNLMUA

### [TABLE 82]
| 1. Số hiệu: 12 | 1. Số hiệu: 12 | 1. Số hiệu: 12 | 2. Tên bảng: B08.1. C_T_DNLMUA | 2. Tên bảng: B08.1. C_T_DNLMUA | 3. Bí danh: B08.1. C_T_DNLMUA | 3. Bí danh: B08.1. C_T_DNLMUA | 3. Bí danh: B08.1. C_T_DNLMUA |
| 4. Mô tả: Lưu trữ thông tin chi tiết đơn nguyên liệu mua. | 4. Mô tả: Lưu trữ thông tin chi tiết đơn nguyên liệu mua. | 4. Mô tả: Lưu trữ thông tin chi tiết đơn nguyên liệu mua. | 4. Mô tả: Lưu trữ thông tin chi tiết đơn nguyên liệu mua. | 4. Mô tả: Lưu trữ thông tin chi tiết đơn nguyên liệu mua. | 4. Mô tả: Lưu trữ thông tin chi tiết đơn nguyên liệu mua. | 4. Mô tả: Lưu trữ thông tin chi tiết đơn nguyên liệu mua. | 4. Mô tả: Lưu trữ thông tin chi tiết đơn nguyên liệu mua. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_nl | ma_nl | Mã nguyên liệu | C(10) | C(10) | C(10) | x |
| 2 | so_dnlm | so_dnlm | Số đơn nguyên liệu mua | C(10) | C(10) | C(10) | x |
| 3 | soluongdenghi | soluongdenghi | Số lượng đề nghị | N(10) | N(10) | N(10) | x |
| 4 | dongiadukien | dongiadukien | Đơn giá dự kiến | N(10) | N(10) | N(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_nl | ma_nl | Mã nguyên liệu | Mã nguyên liệu | B02. NL | B02. NL |
| 2 | 2 | so_dnlm | so_dnlm | Số đơn nguyên liệu mua | Số đơn nguyên liệu mua | B08. D_NLM | B08. D_NLM |

(13) Bảng B09. P_NH

### [TABLE 83]
| 1. Số hiệu: 13 | 1. Số hiệu: 13 | 1. Số hiệu: 13 | 2. Tên bảng: B09. P_NH | 2. Tên bảng: B09. P_NH | 3. Bí danh: B09. P_NH | 3. Bí danh: B09. P_NH | 3. Bí danh: B09. P_NH |
| 4. Mô tả: Lưu trữ thông tin phiếu nhập hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu nhập hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu nhập hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu nhập hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu nhập hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu nhập hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu nhập hàng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu nhập hàng trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | so_pnh | so_pnh | Số phiếu nhập hàng | C(10) | C(10) | C(10) | x |
| 2 | ma_ncc | ma_ncc | Mã nhà cung cấp | C(10) | C(10) | C(10) | x |
| 3 | so_dnlm | so_dnlm | Số đơn nguyên liệu mua | C(10) | C(10) | C(10) | x |
| 4 | ngaygiao | ngaygiao | Ngày giao hàng | D(8) | D(8) | D(8) | x |
| 5 | thoigiangiaohang | thoigiangiaohang | Thời gian giao hàng | D(8) | D(8) | D(8) | x |
| 6 | tenkhachhang | tenkhachhang | Tên khách hàng | C(50) | C(50) | C(50) |  |
| 7 | nguoigiaohang | nguoigiaohang | Người giao hàng | C(50) | C(50) | C(50) | x |
| 8 | nguoinhanhang | nguoinhanhang | Người nhận hàng | C(50) | C(50) | C(50) | x |
| 9 | ma_nl | ma_nl | Mã nguyên liệu | C(10) | C(10) | C(10) | x |
| 10 | soluonggiao | soluonggiao | Số lượng giao | N(10) | N(10) | N(10) | x |
| 11 | tennguyenlieu | tennguyenlieu | Tên nguyên liệu | C(50) | C(50) | C(50) | x |
| 12 | thanhtien | thanhtien | Thành tiền | N(10) | N(10) | N(10) | x |
| 13 | tennd | tennd | Tên người dùng | C(50) | C(50) | C(50) | x |
| 14 | ma_nd | ma_nd | Mã người dùng | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_ncc | ma_ncc | Mã nhà cung cấp | Mã nhà cung cấp | B05. NCC | B05. NCC |
| 2 | 2 | so_dnlm | so_dnlm | Số đơn nguyên liệu mua | Số đơn nguyên liệu mua | B08. D_NLM | B08. D_NLM |
| 3 | 3 | ma_nd | ma_nd | Mã người dùng | Mã người dùng | NGUOIDUNG | NGUOIDUNG |

(14) Bảng B09.1. C_T_PNH

### [TABLE 84]
| 1. Số hiệu: 14 | 1. Số hiệu: 14 | 1. Số hiệu: 14 | 2. Tên bảng: B09.1. C_T_PNH | 2. Tên bảng: B09.1. C_T_PNH | 3. Bí danh: B09.1. C_T_PNH | 3. Bí danh: B09.1. C_T_PNH | 3. Bí danh: B09.1. C_T_PNH |
| 4. Mô tả: Lưu trữ thông tin chi tiết phiếu nhập hàng. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu nhập hàng. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu nhập hàng. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu nhập hàng. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu nhập hàng. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu nhập hàng. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu nhập hàng. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu nhập hàng. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | so_pnh | so_pnh | Số phiếu nhập hàng | C(10) | C(10) | C(10) | x |
| 2 | ma_nl | ma_nl | Mã nguyên liệu | C(10) | C(10) | C(10) | x |
| 3 | soluonggiao | soluonggiao | Số lượng giao | N(10) | N(10) | N(10) | x |
| 4 | tinhtrang | tinhtrang | Tình trạng nguyên liệu | C(50) | C(50) | C(50) | x |
| 5 | ghichu | ghichu | Ghi chú | C(200) | C(200) | C(200) |  |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | so_pnh | so_pnh | Số phiếu nhập hàng | Số phiếu nhập hàng | B09. P_NH | B09. P_NH |
| 2 | 2 | ma_nl | ma_nl | Mã nguyên liệu | Mã nguyên liệu | B02. NL | B02. NL |

(15) Bảng B10. P_KK

### [TABLE 85]
| 1. Số hiệu: 15 | 1. Số hiệu: 15 | 1. Số hiệu: 15 | 2. Tên bảng: B10. P_KK | 2. Tên bảng: B10. P_KK | 3. Bí danh: B10. P_KK | 3. Bí danh: B10. P_KK | 3. Bí danh: B10. P_KK |
| 4. Mô tả: Lưu trữ thông tin phiếu kiểm kê trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu kiểm kê trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu kiểm kê trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu kiểm kê trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu kiểm kê trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu kiểm kê trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu kiểm kê trong hệ thống. | 4. Mô tả: Lưu trữ thông tin phiếu kiểm kê trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | so_pkk | so_pkk | Số phiếu kiểm kê | C(10) | C(10) | C(10) | x |
| 2 | ma_ncc | ma_ncc | Mã nhà cung cấp | C(10) | C(10) | C(10) | x |
| 3 | ngaykiemke | ngaykiemke | Ngày kiểm kê | D(8) | D(8) | D(8) | x |
| 4 | thoigiankiemke | thoigiankiemke | Thời gian kiểm kê | D(8) | D(8) | D(8) | x |
| 5 | nguoithuchienkiemke | nguoithuchienkiemke | Người thực hiện kiểm kê | C(50) | C(50) | C(50) | x |
| 6 | nguoigiamsat | nguoigiamsat | Người giám sát | C(50) | C(50) | C(50) |  |
| 7 | tennd | tennd | Tên người dùng | C(50) | C(50) | C(50) | x |
| 8 | ma_nd | ma_nd | Mã người dùng | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_ncc | ma_ncc | Mã nhà cung cấp | Mã nhà cung cấp | B05. NCC | B05. NCC |
| 2 | 2 | ma_nd | ma_nd | Mã người dùng | Mã người dùng | NGUOIDUNG | NGUOIDUNG |

(16) Bảng B10.1. C_T_PKK

### [TABLE 86]
| 1. Số hiệu: 16 | 1. Số hiệu: 16 | 1. Số hiệu: 16 | 2. Tên bảng: B10.1. C_T_PKK | 2. Tên bảng: B10.1. C_T_PKK | 3. Bí danh: B10.1. C_T_PKK | 3. Bí danh: B10.1. C_T_PKK | 3. Bí danh: B10.1. C_T_PKK |
| 4. Mô tả: Lưu trữ thông tin chi tiết phiếu kiểm kê nguyên liệu. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu kiểm kê nguyên liệu. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu kiểm kê nguyên liệu. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu kiểm kê nguyên liệu. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu kiểm kê nguyên liệu. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu kiểm kê nguyên liệu. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu kiểm kê nguyên liệu. | 4. Mô tả: Lưu trữ thông tin chi tiết phiếu kiểm kê nguyên liệu. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | so_pkk | so_pkk | Số phiếu kiểm kê | C(10) | C(10) | C(10) | x |
| 2 | ma_nl | ma_nl | Mã nguyên liệu | C(10) | C(10) | C(10) | x |
| 3 | soluongtheokiemke | soluongtheokiemke | Số lượng theo kiểm kê | N(10) | N(10) | N(10) | x |
| 4 | soluongthucte | soluongthucte | Số lượng thực tế | N(10) | N(10) | N(10) | x |
| 5 | chenhlech | chenhlech | Chênh lệch | N(10) | N(10) | N(10) | x |
| 6 | hansudung | hansudung | Hạn sử dụng | D(8) | D(8) | D(8) |  |
| 7 | tinhtrangchatluong | tinhtrangchatluong | Tình trạng chất lượng | C(50) | C(50) | C(50) |  |
| 8 | ghichu | ghichu | Ghi chú | C(200) | C(200) | C(200) |  |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | so_pkk | so_pkk | Số phiếu kiểm kê | Số phiếu kiểm kê | B10. P_KK | B10. P_KK |
| 2 | 2 | ma_nl | ma_nl | Mã nguyên liệu | Mã nguyên liệu | B02. NL | B02. NL |

(17) Bảng B11.NGUOIDUNG

### [TABLE 87]
| 1. Số hiệu: 17 | 1. Số hiệu: 17 | 1. Số hiệu: 17 | 2. Tên bảng: B11.NGUOIDUNG | 2. Tên bảng: B11.NGUOIDUNG | 3. Bí danh: B11.NGUOIDUNG | 3. Bí danh: B11.NGUOIDUNG | 3. Bí danh: B11.NGUOIDUNG |
| 4. Mô tả: Lưu trữ thông tin người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin người dùng trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_nd | ma_nd | Mã người dùng | C(10) | C(10) | C(10) | x |
| 2 | tennd | tennd | Tên người dùng | C(50) | C(50) | C(50) | x |
| 3 | sdt | sdt | Số điện thoại | N(11) | N(11) | N(11) |  |
| 4 | usr | usr | Tên đăng nhập | C(20) | C(20) | C(20) | x |
| 5 | pwd_hash | pwd_hash | Mật khẩu đã mã hóa | C(64) | C(64) | C(64) | x |
| 6 | vitri | vitri | Vị trí hoặc chức vụ | C(50) | C(50) | C(50) |  |
| 7 | trangthai | trangthai | Trạng thái tài khoản | N(1) | N(1) | N(1) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |

(18) Bảng B11.1.ND_NHOM

### [TABLE 88]
| 1. Số hiệu: 18 | 1. Số hiệu: 18 | 1. Số hiệu: 18 | 2. Tên bảng: B11.1.ND_NHOM | 2. Tên bảng: B11.1.ND_NHOM | 3. Bí danh: B11.1.ND_NHOM | 3. Bí danh: B11.1.ND_NHOM | 3. Bí danh: B11.1.ND_NHOM |
| 4. Mô tả: Lưu trữ thông tin người dùng thuộc nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin người dùng thuộc nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin người dùng thuộc nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin người dùng thuộc nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin người dùng thuộc nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin người dùng thuộc nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin người dùng thuộc nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin người dùng thuộc nhóm người dùng. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_nd | ma_nd | Mã người dùng | C(10) | C(10) | C(10) | x |
| 2 | ma_nhom | ma_nhom | Mã nhóm người dùng | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_nd | ma_nd | Mã người dùng | Mã người dùng | NGUOIDUNG | NGUOIDUNG |
| 2 | 2 | ma_nhom | ma_nhom | Mã nhóm người dùng | Mã nhóm người dùng | NHOMND | NHOMND |

(19) Bảng B12.NHOMND

### [TABLE 89]
| 1. Số hiệu: 19 | 1. Số hiệu: 19 | 1. Số hiệu: 19 | 2. Tên bảng: B12.NHOMND | 2. Tên bảng: B12.NHOMND | 3. Bí danh: B12.NHOMND | 3. Bí danh: B12.NHOMND | 3. Bí danh: B12.NHOMND |
| 4. Mô tả: Lưu trữ thông tin nhóm người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhóm người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhóm người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhóm người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhóm người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhóm người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhóm người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhóm người dùng trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_nhom | ma_nhom | Mã nhóm người dùng | C(10) | C(10) | C(10) | x |
| 2 | tennhom | tennhom | Tên nhóm người dùng | C(50) | C(50) | C(50) | x |
| 3 | mota | mota | Mô tả nhóm người dùng | C(100) | C(100) | C(100) |  |
| 4 | trangthai | trangthai | Trạng thái nhóm | N(1) | N(1) | N(1) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |

(20) Bảng B13.QUYEN

### [TABLE 90]
| 1. Số hiệu: 20 | 1. Số hiệu: 20 | 1. Số hiệu: 20 | 2. Tên bảng: B13.QUYEN | 2. Tên bảng: B13.QUYEN | 3. Bí danh: B13.QUYEN | 3. Bí danh: B13.QUYEN | 3. Bí danh: B13.QUYEN |
| 4. Mô tả: Lưu trữ thông tin quyền sử dụng chức năng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin quyền sử dụng chức năng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin quyền sử dụng chức năng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin quyền sử dụng chức năng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin quyền sử dụng chức năng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin quyền sử dụng chức năng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin quyền sử dụng chức năng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin quyền sử dụng chức năng trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_quyen | ma_quyen | Mã quyền | C(10) | C(10) | C(10) | x |
| 2 | tenquyen | tenquyen | Tên quyền | C(50) | C(50) | C(50) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |

(21) Bảng B13.1.PHANQUYEN

### [TABLE 91]
| 1. Số hiệu: 21 | 1. Số hiệu: 21 | 1. Số hiệu: 21 | 2. Tên bảng: B13.1.PHANQUYEN | 2. Tên bảng: B13.1.PHANQUYEN | 3. Bí danh: B13.1.PHANQUYEN | 3. Bí danh: B13.1.PHANQUYEN | 3. Bí danh: B13.1.PHANQUYEN |
| 4. Mô tả: Lưu trữ thông tin phân quyền cho từng nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin phân quyền cho từng nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin phân quyền cho từng nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin phân quyền cho từng nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin phân quyền cho từng nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin phân quyền cho từng nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin phân quyền cho từng nhóm người dùng. | 4. Mô tả: Lưu trữ thông tin phân quyền cho từng nhóm người dùng. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_nhom | ma_nhom | Mã nhóm người dùng | C(10) | C(10) | C(10) | x |
| 2 | ma_quyen | ma_quyen | Mã quyền | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_nhom | ma_nhom | Mã nhóm người dùng | Mã nhóm người dùng | NHOMND | NHOMND |
| 2 | 2 | ma_quyen | ma_quyen | Mã quyền | Mã quyền | QUYEN | QUYEN |

(22) Bảng B14.SAOLUUDULIEU

### [TABLE 92]
| 1. Số hiệu: 22 | 1. Số hiệu: 22 | 1. Số hiệu: 22 | 2. Tên bảng: B14.SAOLUUDULIEU | 2. Tên bảng: B14.SAOLUUDULIEU | 3. Bí danh: B14.SAOLUUDULIEU | 3. Bí danh: B14.SAOLUUDULIEU | 3. Bí danh: B14.SAOLUUDULIEU |
| 4. Mô tả: Lưu trữ thông tin sao lưu và phục hồi dữ liệu hệ thống. | 4. Mô tả: Lưu trữ thông tin sao lưu và phục hồi dữ liệu hệ thống. | 4. Mô tả: Lưu trữ thông tin sao lưu và phục hồi dữ liệu hệ thống. | 4. Mô tả: Lưu trữ thông tin sao lưu và phục hồi dữ liệu hệ thống. | 4. Mô tả: Lưu trữ thông tin sao lưu và phục hồi dữ liệu hệ thống. | 4. Mô tả: Lưu trữ thông tin sao lưu và phục hồi dữ liệu hệ thống. | 4. Mô tả: Lưu trữ thông tin sao lưu và phục hồi dữ liệu hệ thống. | 4. Mô tả: Lưu trữ thông tin sao lưu và phục hồi dữ liệu hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_saoluu | ma_saoluu | Mã sao lưu | C(10) | C(10) | C(10) | x |
| 2 | thoigiansaoluu | thoigiansaoluu | Thời gian sao lưu | D(12) | D(12) | D(12) | x |
| 3 | tenfile | tenfile | Tên file sao lưu | C(100) | C(100) | C(100) | x |
| 4 | duongdanfile | duongdanfile | Đường dẫn file sao lưu | C(200) | C(200) | C(200) | x |
| 5 | trangthai | trangthai | Trạng thái sao lưu | N(1) | N(1) | N(1) | x |
| 6 | ghichu | ghichu | Ghi chú | C(200) | C(200) | C(200) |  |
| 7 | ma_nd | ma_nd | Mã người dùng | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_nd | ma_nd | Mã người dùng | Mã người dùng | NGUOIDUNG | NGUOIDUNG |

(23) Bảng B15.NHATKYHOATDONG

### [TABLE 93]
| 1. Số hiệu: 23 | 1. Số hiệu: 23 | 1. Số hiệu: 23 | 2. Tên bảng: B15.NHATKYHOATDONG | 2. Tên bảng: B15.NHATKYHOATDONG | 3. Bí danh: B15.NHATKYHOATDONG | 3. Bí danh: B15.NHATKYHOATDONG | 3. Bí danh: B15.NHATKYHOATDONG |
| 4. Mô tả: Lưu trữ thông tin nhật ký hoạt động của người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhật ký hoạt động của người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhật ký hoạt động của người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhật ký hoạt động của người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhật ký hoạt động của người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhật ký hoạt động của người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhật ký hoạt động của người dùng trong hệ thống. | 4. Mô tả: Lưu trữ thông tin nhật ký hoạt động của người dùng trong hệ thống. |
| 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột | 5. Mô tả chi tiết các cột |
| STT | Tên cột | Tên cột | Mô tả | Kiểu dữ liệu | Kiểu dữ liệu | Kiểu dữ liệu | N |
| 1 | ma_nk | ma_nk | Mã nhật ký | C(10) | C(10) | C(10) | x |
| 2 | thoigian | thoigian | Thời gian thao tác | D(12) | D(12) | D(12) | x |
| 3 | noidung | noidung | Nội dung thao tác | C(200) | C(200) | C(200) | x |
| 4 | ttcu | ttcu | Thông tin cũ | C(200) | C(200) | C(200) |  |
| 5 | ttmoi | ttmoi | Thông tin mới | C(200) | C(200) | C(200) |  |
| 6 | ma_ls | ma_ls | Mã lịch sử truy cập | C(10) | C(10) | C(10) | x |
| 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài | 6. Khóa ngoài |
| STT | STT | Tên | Tên | Cột khóa ngoài | Cột khóa ngoài | Quan hệ với bảng | Quan hệ với bảng |
| 1 | 1 | ma_ls | ma_ls | Mã lịch sử truy cập | Mã lịch sử truy cập | LICHSUTRUYCAP | LICHSUTRUYCAP |

#### 3.4. Thiết kế giao diện người – máy
##### 3.4.1. Thiết kế hệ thống đơn chọn
(1) Hình thành Menu
Theo thiết kế, hệ thống xác định 3 nhóm người dùng nghiệp vụ và 1 nhóm quản trị:
N01. Nhân viên phục vụ
N02. Nhân viên thu ngân
N03. Nhân viên pha chế
N04. Người quản trị
Do đó, hệ thống xác định số nhóm người dùng nghiệp vụ lớn hơn 2, menu sẽ được hình thành theo hướng người dùng.
Xác định menu gồm 4 nhánh chính, tên nhánh được đặt theo tên của nhóm người dùng, mỗi nhánh xác định đầy đủ các chức năng hệ thống của nhóm người dùng đó.
(2) Hệ thống Menu
##### 3.4.2. Thiết kế form nhập liệu cho danh mục
(1) Bảng 12. Bảng tổng hợp form danh mục

### [TABLE 94]
| STT | Tên form | Chức năng trên form | Loại dữ liệu | Bảng dữ liệu | Mục đơn chọn tương ứng | Thiết kế |
| 1 | Đồ uống | Thêm, sửa, xóa, tìm kiếm | Tài sản | B03. DU | C04.06.01. Đồ uống | (*) |
| 2 | Nguyên liệu | Thêm, sửa, xóa, tìm kiếm | Tài sản | B02. NL | C03.06. Quản lý nguyên liệu C04.06.02. Nguyên liệu |  |
| 3 | Khách hàng | Thêm, sửa, xóa, tìm kiếm | Con người |  | C04.06.03. Khách hàng | (*) |
| 4 | Nhà cung cấp | Thêm, sửa, xóa, tìm kiếm | Con người | B05. NCC | C02.06. Quản lý nhà cung cấp C04.06.04. Nhà cung cấp |  |
| 5 | Loại đồ uống | Thêm, sửa, xóa, tìm kiếm | Kho bãi | B01. LDU | C04.06.05. Loại đồ uống |  |

(2) Thiết kế chi tiết form Đồ uống
Tên giao diện: Đồ uống.
Nhiệm vụ: Thêm, sửa, xóa, tìm kiếm thông tin đồ uống.
Người sử dụng: Người quản trị.
Môi trường:
Tiền điều kiện: Người dùng đã đăng nhập vào hệ thống với quyền của Người quản trị
Hậu điều kiện: Trở về giao diện trang chủ.
Mẫu thiết kế

### [TABLE 95]
| STT | Tên | Loại control | Bắt buộc | Độ dài tối đa | Read only |
| 1 | QUẢN LÝ ĐỒ UỐNG | Label | x | 50 | x |
| 2 | Lưu | Button |  |  | x |
| 3 | Làm mới | Button |  |  | x |
| 4 | Đóng | Button |  |  | x |
| 5 | THÔNG TIN ĐỒ UỐNG | Groupbox | x |  | x |
| 6 | Hình ảnh đồ uống | Label |  |  | x |
| 7 | Hiển thị hình ảnh đồ uống | PictureBox |  |  | x |
| 8 | Chọn ảnh | Button |  |  | x |
| 9 | Mã đồ uống | Label |  |  | x |
| 10 | Hiển thị mã đồ uống | Textbox | x | 10 | x |
| 11 | Tên đồ uống | Label |  |  | x |
| 12 | Hiển thị tên đồ uống | Textbox | x | 100 |  |
| 13 | Loại đồ uống | Label |  |  | x |
| 14 | Hiển thị loại đồ uống | Combobox | x | 50 |  |
| 15 | Đơn vị tính | Label |  |  | x |
| 16 | Hiển thị đơn vị tính | Combobox | x | 20 |  |
| 17 | Đơn giá | Label |  |  | x |
| 18 | Hiển thị đơn giá | Textbox | x | 15 |  |
| 19 | Tình trạng | Label |  |  | x |
| 20 | Hiển thị tình trạng | Combobox | x | 20 |  |
| 21 | Mô tả | Label |  |  | x |
| 22 | Hiển thị mô tả | Textbox |  | 200 |  |
| 23 | Ghi chú hướng dẫn | Label |  | 100 | x |
| 24 | Thêm | Button |  |  | x |
| 25 | Sửa | Button |  |  | x |
| 26 | Xóa | Button |  |  | x |
| 27 | Hủy | Button |  |  | x |
| 28 | TÌM KIẾM / THAO TÁC | Groupbox | x |  | x |
| 29 | Tìm kiếm | Label |  |  | x |
| 30 | Hiển thị tìm kiếm | Textbox |  | 100 |  |
| 31 | Tìm kiếm | Button |  |  | x |
| 32 | Tất cả | Button |  |  | x |
| 33 | Mũi tên lên | Button |  |  | x |
| 34 | Mũi tên xuống | Button |  |  | x |
| 35 | DANH SÁCH ĐỒ UỐNG | Groupbox | x |  | x |
| 36 | Bảng chi tiết ( Mã đồ uống, Tên đồ uống, Loại đồ uống, Đơn vị tính, Đơn giá, Tình trạng, Mô tả ) | DataGridView | x |  | x |
| 37 | Thanh điều hướng dữ liệu | BindingNavigator | x |  | x |

6. Biểu đồ hoạt động
7. Bảng dữ liệu

### [TABLE 96]
| Tên bảng dữ liệu | Thuộc tính sử dụng | Mức độ sử dụng C, E, R, D | Điều kiện toàn vẹn |
| B01. LDU | ma_ldu | R |  |
| B01. LDU | tenloaidouong | R |  |
| B01. LDU | mota | R |  |
| B03.DU | ma_du | R | Mã tự sinh |
| B03.DU | ma_ldu | R |  |
| B03.DU | tendouong | C, R, E, D | Chữ cái + Chữ số |
| B03.DU | dongia | C, R, D | Số thực, >0 |
| B03.DU | donvitinh | C, R, D | Chữ cái |
| B03.DU | tinhtrang | C, R, E, D | Chọn Sẵn sàng/Hết hàng/Ngừng bán |
| B03.DU | hinhanh | C, R, E, D |  |
| B03.DU | mota | C, E, R, D | Tối đa 200 ký tự. |

8. Quy trình, công thức xử lý

### [TABLE 97]
| STT | Đối tượng tương tác | Xử lý | Bảng dữ liệu liên quan |
| 1 | btnReturn | Nếu click vào button này Thì trở lại giao diện trang chủ |  |
| 2 | btnThem | Nếu click vào button này Thì mở form phụ frmThemDoUong với txtTenDoUong, cbbDonViTinh, txtDonGia, cbbTinhTrang, cbbLoaiDoUong, imgHinhAnh enabled = true Nếu click Lưu Nếu txtTenDoUong, cbbLoaiDoUong = null Thì hiển thị thông báo không được để trống dữ liệu và tiếp tục frmThemDoUong Nếu không thì lưu dữ liệu trong bảng DU, hiển thị thông báo thêm đồ uống thành công và quay về frmDoUong ban đầu Nếu click Hủy Thì đóng frmThemDoUong, quay trở lại frmDoUong | DU |
| 3 | btnSua | Chọn btnSua của 1 dòng nào đó trong dgvDoUong Hiển thị frmSuaDoUong với thông tin các trường dữ liệu tương ứng được phép sửa txtTenDoUong, cbbDonViTinh, txtDonGia, cbbTinhTrang, cbbLoaiDoUong, imgHinhAnh có sẵn thông tin được chọn ban đầu Nếu click Cập nhật Thì hiển thị thông báo “Bạn có chắc chắn muốn sửa không?” Nếu click OK Nếu txtTenDoUong, cbbLoaiDoUong = null Thì hiển thị thông báo không được để trống dữ liệu và trở lại thông tin ban đầu Nếu không thì sửa dữ liệu trong bảng DU các trường tương ứng và quay về frmDoUong ban đầu Nếu click Hủy Thì tắt thông báo Nếu click Hủy Thì đóng frmSuaDoUong, quay trở lại frmDoUong | DU |
| 4 | btnXem | Chọn btnXem của 1 dòng nào đó trong dgvDoUong Hiển thị frmXemDoUong với thông tin các trường dữ liệu tương ứng với txtTenDoUong, cbbDonViTinh, txtDonGia, cbbTinhTrang, cbbLoaiDoUong, imgHinhAnh visibled = false Nếu click Chỉnh sửa Thì hiển thị thông báo “Bạn có chắc chắn muốn sửa không?” Nếu click OK Thì mở frmSuaDoUong cho phép chỉnh sửa thông tin của đồ uống Nếu click Hủy Thì tắt thông báo, tiếp tục ở lại frmXemDoUong Nếu click Hủy Thì đóng frmXemDoUong, quay trở lại frmDoUong | DU, LDU |
| 5 | btnTimKiem | Nếu click vào button này Nếu txtTimKiem != null Thì tự động hiển thị kết quả tìm kiếm có trường thông tin tương ứng trong CSDL lên dgvDoUong Nếu txtTimKiem == null Thì hiển thị thông báo “Vui lòng nhập thông tin cần tìm kiếm!” | DU, LDU |
| 6 | btnXoa | Nếu chọn btnXoa của 1 dòng nào đó trong dgvDoUong Thì hiển thị thông báo “Bạn có chắc chắn muốn xóa không?” Nếu click OK Thì xóa bản ghi DU ứng với ma_du của dòng được chọn trong CSDL và tải lại dgvDoUong Nếu click Hủy Thì tắt thông báo hiển thị và tiếp tục frmDoUong | DU |
| 7 | btnXoaTatCa | Enable = false Nếu click vào ô vuông checkbox của 1 hay nhiều hàng của dgvDoUong Thì enable = true Nếu click btnXoaTatCa Thì xoá thông tin các đồ uống đã chọn khỏi CSDL Hiển thị lại danh sách đồ uống sau khi cập nhật dgvDoUong | DU |
| 8 | btnLamMoi | Nếu click vào button này Thì tải lại danh sách đồ uống từ CSDL lên dgvDoUong | DU |

9. Định dạng kết quả đầu ra:
- Khi thoát khỏi giao diện thì:
+ Bảng dữ liệu bị thay đổi: DU
+ Trạng thái hệ thống sau khi thoát khỏi giao diện: Trở về giao diện Trang chủ
(3) Thiết kế chi tiết form Khách hàng
1. Tên giao diện: Khách hàng.
2. Nhiệm vụ: Thêm, sửa, xóa, tìm kiếm thông tin khách hàng.
3. Người sử dụng: Người quản trị, Nhân viên thu ngân.
4. Môi trường:
- Tiền điều kiện: Người dùng đăng nhập với quyền của Người quản trị hoặc nhân viên thu ngân.
- Hậu điều kiện: Trở về giao diện trang chủ.
5. Mẫu thiết kế

### [TABLE 98]
| STT | Tên | Loại control | Bắt buộc | Độ dài tối đa | Read only |
| 1 | QUẢN LÝ KHÁCH HÀNG | Label | x | 50 | x |
| 2 | Lưu | Button |  |  | x |
| 3 | Làm mới | Button |  |  | x |
| 4 | Đóng | Button |  |  | x |
| 5 | THÔNG TIN KHÁCH HÀNG | Groupbox | x |  | x |
| 6 | Hình ảnh khách hàng | Label |  |  | x |
| 7 | Hiển thị hình ảnh khách hàng | PictureBox |  |  | x |
| 8 | Chọn ảnh | Button |  |  | x |
| 9 | Mã khách hàng | Label |  |  | x |
| 10 | Hiển thị mã khách hàng | Textbox | x | 10 | x |
| 11 | Tên khách hàng | Label |  |  | x |
| 12 | Hiển thị tên khách hàng | Textbox | x | 100 |  |
| 13 | Giới tính | Label |  |  | x |
| 14 | Hiển thị giới tính | Combobox | x | 10 |  |
| 15 | Số điện thoại | Label |  |  | x |
| 16 | Hiển thị số điện thoại | Textbox |  | 15 |  |
| 17 | CCCD/CMND | Label |  |  | x |
| 18 | Hiển thị CCCD/CMND | Textbox |  | 12 |  |
| 19 | Địa chỉ | Label |  |  | x |
| 20 | Hiển thị địa chỉ | Textbox |  | 200 |  |
| 21 | Hạng khách hàng | Label |  |  | x |
| 22 | Hiển thị hạng khách hàng | Combobox | x | 20 |  |
| 23 | Tình trạng | Label |  |  | x |
| 24 | Hiển thị tình trạng | Combobox | x | 20 |  |
| 25 | Ghi chú | Label |  |  | x |
| 26 | Hiển thị ghi chú | Textbox |  | 200 |  |
| 27 | Ghi chú hướng dẫn | Label |  | 100 | x |
| 28 | Thêm | Button |  |  | x |
| 29 | Sửa | Button |  |  | x |
| 30 | Xóa | Button |  |  | x |
| 31 | Hủy | Button |  |  | x |
| 32 | TÌM KIẾM / THAO TÁC | Groupbox | x |  | x |
| 33 | Tìm kiếm | Label |  |  | x |
| 34 | Hiển thị tìm kiếm | Textbox |  | 100 |  |
| 35 | Tìm kiếm | Button |  |  | x |
| 36 | Tất cả | Button |  |  | x |
| 37 | Mũi tên lên | Button |  |  | x |
| 38 | Mũi tên xuống | Button |  |  | x |
| 39 | DANH SÁCH KHÁCH HÀNG | Groupbox | x |  | x |
| 40 | Bảng chi tiết ( Mã khách hàng, Tên khách hàng, Giới tính, Số điện thoại, CCCD/CMND, Địa chỉ, Hạng KH, Tình trạng, Ghi chú ) | DataGridView | x |  | x |
| 41 | Thanh điều hướng dữ liệu | BindingNavigator | x |  | x |

6. Biểu đồ hoạt động
7. Bảng dữ liệu

### [TABLE 99]
| Tên bảng dữ liệu | Thuộc tính sử dụng | Mức độ sử dụng C, E, R, D | Điều kiện toàn vẹn |
| B04. KH | ma_kh | R | Mã tự sinh |
| B04. KH | tenkhachhang | C, R, E, D | Chữ cái |
| B04. KH | gioitinh | C, R, E, D | Chọn Nam/Nữ/Khác |
| B04. KH | sodienthoai | C, R, E, D | Chữ số, tối đa 10 ký tự |
| B04. KH | diachi | C, R, E, D | Chữ cái + chữ số |

8. Quy trình, công thức xử lý

### [TABLE 100]
| STT | Đối tượng tương tác | Xử lý | Bảng dữ liệu liên quan |
| 1 | btnReturn | Nếu click vào button này Thì trở lại giao diện trang chủ |  |
| 2 | btnThem | Nếu click vào button này Thì mở form phụ frmThemKhachHang với txtTenKhachHang, cbbGioiTinh, txtSoDienThoai, txtCCCD, txtDiaChi, cbbHangKhachHang, cbbTinhTrang, txtGhiChu, imgKhachHang enabled = true Nếu click Lưu Nếu txtTenKhachHang = null Thì hiển thị thông báo không được để trống dữ liệu và tiếp tục frmThemKhachHang Nếu số điện thoại hoặc CCCD/CMND không hợp lệ Thì hiển thị thông báo dữ liệu không hợp lệ và tiếp tục frmThemKhachHang Nếu không thì lưu dữ liệu trong bảng KH, hiển thị thông báo thêm khách hàng thành công và quay về frmKhachHang ban đầu Nếu click Hủy Thì đóng frmThemKhachHang, quay trở lại frmKhachHang | KH |
| 3 | btnSua | Chọn btnSua của 1 dòng nào đó trong dgvKhachHang Hiển thị frmSuaKhachHang với thông tin các trường dữ liệu tương ứng được phép sửa txtTenKhachHang, cbbGioiTinh, txtSoDienThoai, txtCCCD, txtDiaChi, cbbHangKhachHang, cbbTinhTrang, txtGhiChu, imgKhachHang có sẵn thông tin được chọn ban đầu Nếu click Cập nhật Thì hiển thị thông báo “Bạn có chắc chắn muốn sửa không?” Nếu click OK Nếu txtTenKhachHang = null Thì hiển thị thông báo không được để trống dữ liệu và trở lại thông tin ban đầu Nếu số điện thoại hoặc CCCD/CMND không hợp lệ Thì hiển thị thông báo dữ liệu không hợp lệ và trở lại thông tin ban đầu Nếu không thì sửa dữ liệu trong bảng KH các trường tương ứng và quay về frmKhachHang ban đầu Nếu click Hủy Thì tắt thông báo Nếu click Hủy Thì đóng frmSuaKhachHang, quay trở lại frmKhachHang | KH |
| 4 | btnXem | Chọn btnXem của 1 dòng nào đó trong dgvKhachHang Hiển thị frmXemKhachHang với thông tin các trường dữ liệu tương ứng với txtTenKhachHang, cbbGioiTinh, txtSoDienThoai, txtCCCD, txtDiaChi, cbbHangKhachHang, cbbTinhTrang, txtGhiChu, imgKhachHang visible = false Nếu click Chỉnh sửa Thì hiển thị thông báo “Bạn có chắc chắn muốn sửa không?” Nếu click OK Thì mở frmSuaKhachHang cho phép chỉnh sửa thông tin của khách hàng Nếu click Hủy Thì tắt thông báo, tiếp tục ở lại frmXemKhachHang Nếu click Hủy Thì đóng frmXemKhachHang, quay trở lại frmKhachHang | KH |
| 5 | btnTimKiem | Nếu click vào button này Nếu txtTimKiem != null Thì tự động hiển thị kết quả tìm kiếm có trường thông tin tương ứng trong CSDL lên dgvKhachHang Nếu txtTimKiem == null Thì hiển thị thông báo “Vui lòng nhập thông tin cần tìm kiếm!” | KH |
| 6 | btnXoa | Nếu chọn btnXoa của 1 dòng nào đó trong dgvKhachHang Thì hiển thị thông báo “Bạn có chắc chắn muốn xóa không?” Nếu click OK Thì xóa bản ghi KH ứng với ma_kh của dòng được chọn trong CSDL và tải lại dgvKhachHang Nếu click Hủy Thì tắt thông báo hiển thị và tiếp tục frmKhachHang | KH |
| 7 | btnXoaTatCa | Enable = false Nếu click vào ô vuông checkbox của 1 hay nhiều hàng của dgvKhachHang Thì enable = true Nếu click btnXoaTatCa Thì xoá thông tin các khách hàng đã chọn khỏi CSDL Hiển thị lại danh sách khách hàng sau khi cập nhật dgvKhachHang | KH |
| 8 | btnLamMoi | Nếu click vào button này Thì tải lại danh sách khách hàng từ CSDL lên dgvKhachHang | KH |

9. Định dạng kết quả đầu ra:
- Khi thoát khỏi giao diện thì:
+ Bảng dữ liệu bị thay đổi: KH
+ Trạng thái hệ thống sau khi thoát khỏi giao diện: Trở về giao diện Trang chủ
##### 3.4.3. Thiết kế form xử lý nghiệp vụ
(1) Bảng 13. Bảng tổng hợp form nghiệp vụ

### [TABLE 101]
| STT | Tên form | Tiến trình nghiệp vụ tương ứng | Quy trình sử dụng | Mục đơn chọn tương ứng | Thiết kế |
| 1 | Lập phiếu gọi đồ uống | 01.01. Lập phiếu gọi đồ uống | QT.01.Gọi đồ uống | C01.01. Lập phiếu gọi đồ uống |  |
| 2 | Cập nhật trạng thái phục vụ | 01.02. Cập nhật trạng thái phục vụ đồ uống | QT.01.Gọi đồ uống | C01.02. Cập nhật trạng thái phục vụ đồ uống |  |
| 3 | Lập hóa đơn bán đồ uống | 02.01. Lập hóa đơn bán đồ uống | QT.02.Thanh toán cho khách | C02.01. Lập hóa đơn bán đồ uống | (*) |
| 4 | Lập đơn nguyên liệu mua | 02.02. Lập đơn nguyên liệu mua | QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp | C02.02. Lập đơn nguyên liệu mua |  |
| 5 | Thống kê doanh thu ngày | 02.03. Lập Thống kê doanh thu ngày | QT.04. Báo cáo doanh thu ngày | C02.03. Lập thống kê doanh thu ngày |  |
| 6 | Đối soát chênh lệch doanh thu | 02.04. Lập biên bản Đối soát chênh lệch doanh thu | QT.04. Báo cáo doanh thu ngày | C02.04. Lập biên bản Đối soát chênh lệch doanh thu |  |
| 7 | Thống kê đồ uống bán chạy | 02.05. Lập Thống kê đồ uống bán chạy trong tháng | QT.05. Báo cáo đồ uống bán chạy trong tháng | C02.05. Lập Thống kê đồ uống bán chạy trong tháng |  |
| 8 | Cập nhật trạng thái pha chế | 03.01. Cập nhật trạng thái pha chế | QT.01.Gọi đồ uống | C03.01. Cập nhật trạng thái phục pha chế | (*) |
| 9 | Cập nhật Menu | 03.02. Cập nhật Menu | QT.01.Gọi đồ uống | C03.02. Cập nhật Menu |  |
| 10 | Lập phiếu nhập hàng | 03.03. Lập phiếu nhập hàng | QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp | C03.03. Lập phiếu nhập hàng |  |
| 11 | Lập phiếu kiểm kê | 03.04. Lập phiếu kiểm kê | QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp | C03.04. Lập phiếu kiểm kê |  |
| 12 | Cập nhật nguyên liệu | 03.05. Cập nhật nguyên liệu | QT.03. Nhập nguyên liệu pha chế từ nhà cung cấp | C03.05. Cập nhật nguyên liệu |  |

(2) Thiết kế chi tiết form Lập Hóa đơn bán đồ uống
Tên giao diện: Lập Hóa đơn bán đồ uống.
Nhiệm vụ: Lập và in Hóa đơn bán đồ uống.
Người sử dụng: Nhân viên thu ngân.
Môi trường:
Tiền điều kiện: Người dùng đăng nhập với quyền của nhân viên thu ngân.
Hậu điều kiện: Quay trở lại giao diện Trang chủ.
Mẫu thiết kế

### [TABLE 102]
| STT | Tên | Loại control | Bắt buộc | Độ dài tối đa | Read only |
| 1 | LẬP HÓA ĐƠN BÁN ĐỒ UỐNG | Label |  |  | x |
| 2 | Lưu | Button | x |  | x |
| 3 | In | Button | x |  | x |
| 4 | Mới | Button | x |  | x |
| 5 | Hủy | Button | x |  | x |
| 6 | QUẢN LÝ HÓA ĐƠN | Groupbox | x |  | x |
| 7 | Nhập thông tin tìm kiếm hóa đơn | Textbox |  | 100 |  |
| 8 | Tìm | Button |  |  | x |
| 9 | Làm mới danh sách hóa đơn | Button |  |  | x |
| 10 | Danh sách hóa đơn | DataGridView | x |  | x |
| 11 | Bảng quản lý (Mã HĐ, Ngày, Khách hàng, Tổng tiền, Hình thức thanh toán, Trạng thái) | DataGridView | x |  | x |
| 12 | Thêm hóa đơn | Button |  |  | x |
| 13 | Sửa hóa đơn | Button |  |  | x |
| 14 | Xóa hóa đơn | Button |  |  | x |
| 15 | Xuất hóa đơn | Button |  |  | x |
| 16 | THÔNG TIN HÓA ĐƠN | Groupbox | x |  | x |
| 17 | Mã hóa đơn | Label |  |  | x |
| 18 | Hiển thị Mã hóa đơn | Textbox | x | 20 | x |
| 19 | Ngày lập | Label |  |  | x |
| 20 | Hiển thị Ngày lập | Textbox | x | 12 | x |
| 21 | Thời gian lập | Label |  |  | x |
| 22 | Hiển thị Thời gian lập | Textbox | x | 10 | x |
| 23 | Nhân viên lập | Label |  |  | x |
| 24 | Hiển thị Nhân viên lập | Textbox | x | 50 | x |
| 25 | Trạng thái thanh toán | Label |  |  | x |
| 26 | Chọn Trạng thái thanh toán | Combobox | x | 30 |  |
| 27 | Hình thức thanh toán | Label |  |  | x |
| 28 | Chọn Hình thức thanh toán | Combobox | x | 30 |  |
| 29 | THÔNG TIN KHÁCH HÀNG / PHIẾU GỌI | Groupbox | x |  | x |
| 30 | Mã khách hàng | Label |  |  | x |
| 31 | Hiển thị Mã khách hàng | Textbox | x | 20 |  |
| 32 | Tên khách hàng | Label |  |  | x |
| 33 | Hiển thị Tên khách hàng | Textbox | x | 100 |  |
| 34 | Số điện thoại | Label |  |  | x |
| 35 | Hiển thị Số điện thoại | Textbox |  | 10 |  |
| 36 | Địa chỉ | Label |  |  | x |
| 37 | Hiển thị Địa chỉ | Textbox |  | 150 |  |
| 38 | Số phiếu gọi | Label |  |  | x |
| 39 | Hiển thị Số phiếu gọi | Textbox | x | 20 |  |
| 40 | Số bàn | Label |  |  | x |
| 41 | Hiển thị Số bàn | Textbox |  | 10 |  |
| 42 | Chọn khách hàng | Button |  |  | x |
| 43 | Chọn phiếu gọi đồ uống | Button |  |  | x |
| 44 | THÔNG TIN ĐỒ UỐNG | Groupbox | x |  | x |
| 45 | Đồ uống | Label |  |  | x |
| 46 | Chọn Đồ uống | Combobox | x | 100 |  |
| 47 | Size | Label |  |  | x |
| 48 | Chọn Size | Combobox | x | 5 |  |
| 49 | Số lượng | Label |  |  | x |
| 50 | Hiển thị Số lượng | NumericUpDown | x | 3 |  |
| 51 | Đơn giá | Label |  |  | x |
| 52 | Hiển thị Đơn giá | Textbox | x | 12 |  |
| 53 | Thành tiền | Label |  |  | x |
| 54 | Hiển thị Thành tiền | Textbox | x | 15 | x |
| 55 | Ghi chú | Label |  |  | x |
| 56 | Hiển thị Ghi chú | Textbox |  | 100 |  |
| 57 | Thêm đồ uống | Button |  |  | x |
| 58 | DANH SÁCH ĐỒ UỐNG TRONG HÓA ĐƠN | Groupbox | x |  | x |
| 59 | Bảng chi tiết (STT, Tên đồ uống, Size, Số lượng, Đơn giá, Thành tiền, Ghi chú, Thao tác) | DataGridView | x |  | x |
| 60 | Xóa đồ uống trong bảng | Button |  |  | x |
| 61 | KHU TỔNG TIỀN | Groupbox | x |  | x |
| 62 | Giảm giá | Label |  |  | x |
| 63 | Hiển thị Giảm giá | Textbox |  | 15 |  |
| 64 | Phụ phí | Label |  |  | x |
| 65 | Hiển thị Phụ phí | Textbox |  | 15 |  |
| 66 | VAT (%) | Label |  |  | x |
| 67 | Hiển thị VAT (%) | Textbox | x | 3 |  |
| 68 | Tổng tiền thanh toán | Label |  |  | x |
| 69 | Hiển thị Tổng tiền thanh toán | Textbox | x | 20 | x |
| 70 | Lưu hóa đơn | Button | x |  | x |
| 71 | THANH TRẠNG THÁI | StatusStrip/Panel |  |  | x |
| 72 | Hiển thị tên người dùng | Label |  | 50 | x |
| 73 | Hiển thị vai trò người dùng | Label |  | 50 | x |

6. Biểu đồ hoạt động
7. Bảng dữ liệu

### [TABLE 103]
| Tên bảng dữ liệu | Thuộc tính sử dụng | Mức độ sử dụng C, E, R, D | Điều kiện toàn vẹn |
| B04.K_H | B04.K_H | B04.K_H | B04.K_H |
|  | ma_kh | R |  |
|  | tenkhachhang | R |  |
|  | sodienthoai | R |  |
|  | diachi | R |  |
| B06.P_G_DU | B06.P_G_DU | B06.P_G_DU | B06.P_G_DU |
|  | so_pgdu | R |  |
|  | ma_kh | R |  |
|  | ngaygoidouong | R |  |
|  | thoigiangoidouong | R |  |
|  | tenkhachhang | R |  |
|  | soban | R |  |
|  | trangthai | R, E |  |
|  | tennd | R |  |
|  | ma_nd | R |  |
| B06.1.C_T_PGDU | B06.1.C_T_PGDU | B06.1.C_T_PGDU | B06.1.C_T_PGDU |
|  | so_pgdu | R |  |
|  | ma_du | R |  |
|  | soluong | R |  |
|  | yeucaudacbiet | R |  |
|  | size | R |  |
| B03.DU | B03.DU | B03.DU | B03.DU |
|  | ma_du | R |  |
|  | ma_ldu | R |  |
|  | tendouong | R |  |
|  | dongia | R |  |
|  | donvitinh | R |  |
|  | tinhtrang | R |  |
| B01.LDU | B01.LDU | B01.LDU | B01.LDU |
|  | ma_ldu | R |  |
|  | tenloaidouong | R |  |
|  | mota | R |  |
| B07.HD_BDUONG | B07.HD_BDUONG | B07.HD_BDUONG | B07.HD_BDUONG |
|  | so_hdbdu | C, R, D | Mã tự sinh |
|  | ma_kh | C, R, E |  |
|  | so_pgdu | C, R |  |
|  | ngaylaphoadon | C, R | Ngày hệ thống |
|  | thoigianthanhtoan | C, R | Thời gian hệ thống |
|  | hinhthucthanhtoan | C, R, E |  |
|  | trangthai | C, R, E |  |
|  | ghichu | C, R, E | Tối đa 200 ký tự |
|  | nguoilaphoadon | C, R |  |
|  | ma_du | R |  |
|  | soluongban | C, E, R, D | Chữ số, >0 |
|  | dongia | C, E, R, D | Chữ số |
|  | thanhtien | C, E, R, D |  |
|  | tongtien | C, E, R, D |  |

8. Quy trình, công thức xử lý

### [TABLE 104]
| STT | Đối tượng tương tác | Xử lý | Bảng dữ liệu liên quan |
| 1 | btnThem | Nếu click vào button này Thì Mở frmLapHDBDU. Tự động sinh mã hóa đơn bán đồ uống mới trên txtMaHDBDU. Ngày lập lấy ngày hiện tại trên txtNgayLap. Thời gian lập lấy thời gian hiện tại trên txtThoiGianLap. Nhân viên lập lấy tên người dùng hiện tại trên txtNhanVien. Các textbox, combobox còn lại = null và dgvDoUong chưa có dữ liệu. | HD_BDUONG |
| 2 | btnReturn | Nếu click vào button này Thì trở lại frmQuanLyHDBDU. |  |
| 3 | btnChonKH | Nếu click vào button này Thì mở frmChonKhachHang gồm dgvKhachHang và txtTimKiem. Nếu txtTimKiem != null Thì Tìm kiếm khách hàng theo mã khách hàng, tên khách hàng, CCCD/CMND hoặc số điện thoại. Nếu dgvKhachHang = null Thì hiển thị thông báo “Không tìm thấy khách hàng”. Nếu không Thì nhấn checkbox chọn khách hàng muốn lập hóa đơn. Nếu click Chọn Thì điền mã khách hàng, tên khách hàng, CCCD/CMND, số điện thoại và địa chỉ vào các ô tương ứng trên frmLapHDBDU. Nếu click Hủy Thì đóng frmChonKhachHang và quay về frmLapHDBDU. | K_H |
| 4 | btnThemKH | Nếu click vào button này Thì Mở frmThemKhachHang. Tự động sinh mã khách hàng mới trên txtMaKH. Các textbox, combobox còn lại = null. Nếu click Lưu Nếu txtTenKH, txtSDT, txtDiaChiChiTiet = null Thì hiển thị thông báo không được để trống dữ liệu. Nếu không Thì lưu khách hàng mới vào CSDL và điền thông tin khách hàng vào frmLapHDBDU. Nếu click Hủy hoặc close form Thì đóng frmThemKhachHang và quay về frmLapHDBDU. | K_H |
| 5 | btnChonPGDU | Nếu click vào button này Thì mở frmChonPhieuGoiDoUong gồm dgvPGDU và txtTimKiem. Nếu txtTimKiem != null Thì Tìm kiếm phiếu gọi đồ uống theo số phiếu, ngày lập, số bàn hoặc nhân viên lập. Nếu dgvPGDU = null Thì hiển thị thông báo “Không tìm thấy phiếu gọi đồ uống”. Nếu không Thì nhấn checkbox chọn phiếu gọi đồ uống muốn lập hóa đơn. Nếu click Chọn Thì điền số phiếu gọi, ngày gọi, thời gian gọi, số bàn và danh sách đồ uống vào các ô tương ứng trên frmLapHDBDU. Nếu click Hủy Thì đóng frmChonPhieuGoiDoUong và quay về frmLapHDBDU. | P_G_DU C_T_PGDU DU |
| 6 | btnXemPGDU | Nếu click vào button này Thì mở frmXemTruocPhieuGoiDoUong. Tải hình ảnh xem trước phiếu gọi đồ uống theo biểu mẫu: thông tin quán, số phiếu, ngày gọi, thời gian gọi, trạng thái và danh sách đồ uống. Nếu click In Thì in phiếu gọi đồ uống. Nếu click Thoát Thì đóng frmXemTruocPhieuGoiDoUong và quay về frmChonPhieuGoiDoUong. | P_G_DU C_T_PGDU DU |
| 7 | btnLuu | Nếu click vào button này Thì Nếu txtMaKH, txtTenKH, txtSDT, txtDiaChi, txtCCCD, txtSoPGDU, txtNgayGoi, txtThoiGianGoi, txtSoBan, cboHinhThucThanhToan, cboTrangThaiThanhToan, txtGiamGia, txtThueVAT, txtTongTienThanhToan, dgvDoUong = null Thì hiển thị thông báo không được để trống dữ liệu và trở lại frmLapHDBDU. Nếu không Thì lưu dữ liệu hóa đơn bán đồ uống vào CSDL. Tính tổng tiền thanh toán = tổng thành tiền đồ uống - giảm giá + thuế VAT. Cập nhật trạng thái thanh toán theo cboTrangThaiThanhToan. Nếu cập nhật thành công Thì hiển thị thông báo lưu thành công. Nếu chọn OK Thì đóng thông báo và tự động cập nhật dữ liệu trên dgvHoaDon. Nếu cập nhật không thành công Thì hiển thị thông báo lỗi và tiếp tục ở lại frmLapHDBDU. | HD_BDUONG K_H P_G_DU C_T_PGDU DU |
| 8 | btnXemTruocTamTinh | Nếu click vào button này Thì mở frmXemTruocPhieuTamTinh. Nếu txtMaKH, txtTenKH, txtSDT, txtDiaChi, txtSoPGDU, dgvDoUong = null Thì hiển thị thông báo không được để trống dữ liệu và trở lại frmLapHDBDU. Nếu không Thì tải hình ảnh xem trước phiếu tạm tính theo biểu mẫu: thông tin quán, thông tin khách hàng, danh sách đồ uống, giảm giá, thuế VAT và tổng tiền tạm tính. Nếu click In Thì in phiếu tạm tính và quay về frmLapHDBDU. Nếu click Thoát Thì đóng frmXemTruocPhieuTamTinh và quay về frmLapHDBDU. | K_H P_G_DU C_T_PGDU DU |
| 9 | btnXuatHD | Nếu click vào button này Thì mở frmXuatHoaDonBanDoUong. Nếu txtMaKH, txtTenKH, txtSDT, txtDiaChi, txtCCCD, txtSoPGDU, txtNgayGoi, txtThoiGianGoi, txtSoBan, cboHinhThucThanhToan, cboTrangThaiThanhToan, dgvDoUong = null Thì hiển thị thông báo không được để trống dữ liệu và trở lại frmLapHDBDU. Nếu không Thì tải mẫu hóa đơn bán đồ uống theo biểu mẫu: thông tin quán, số hóa đơn, thông tin khách hàng, hình thức thanh toán, danh sách đồ uống và tổng tiền thanh toán. Nếu click Xuất hoặc In Thì cập nhật dữ liệu hóa đơn bán đồ uống vào CSDL, xuất/in hóa đơn và quay về frmQuanLyHDBDU. Nếu click Thoát Thì đóng frmXuatHoaDonBanDoUong và quay về frmLapHDBDU. | HD_BDUONG K_H P_G_DU C_T_PGDU DU |
| 10 | btnHuy | Nếu click vào button này Thì đóng frmLapHDBDU và quay về frmQuanLyHDBDU. |  |

9. Định dạng kết quả đầu ra :
- Khi thoát khỏi giao diện thì:
+ Bảng dữ liệu bị thay đổi: B04.KHACHHANG, B07.HD_BDUONG, B07.1. C_T_HDBDU
+ Trạng thái hệ thống sau khi thoát khỏi giao diện: Trở về giao diện Quản lý hóa đơn bán đồ uống
(3) Thiết kế chi tiết form Cập nhật trạng thái pha chế
1. Tên giao diện: Cập nhật trạng thái pha chế
2. Nhiệm vụ: Cập nhật tình trạng pha chế theo yêu cầu gọi đồ uống của Khách hàng.
3. Người sử dụng: Nhân viên pha chế.
4. Môi trường:
Tiền điều kiện: Người dùng đăng nhập với quyền của nhân viên pha chế.
Hậu điều kiện: Quay trở lại giao diện Trang chủ.
5. Mẫu thiết kế:

### [TABLE 105]
| STT | Tên | Loại control | Bắt buộc | Độ dài tối đa | Read only |
| 1 | CẬP NHẬT TRẠNG THÁI PHA CHẾ | Label |  | 50 | x |
| 2 | Lưu | Button | x |  | x |
| 3 | Làm mới | Button |  |  | x |
| 4 | Đóng | Button |  |  | x |
| 5 | DANH SÁCH PHIẾU GỌI CẦN PHA CHẾ | Groupbox | x |  | x |
| 6 | Nhập thông tin tìm kiếm | Textbox |  | 100 |  |
| 7 | Tìm kiếm | Button |  |  | x |
| 8 | Tất cả | Button |  |  | x |
| 9 | Danh sách phiếu gọi cần pha chế | DataGridView | x |  | x |
| 10 | Bảng quản lý (Số phiếu, Tên đồ uống, SL, Size, Bàn, Trạng thái) | DataGridView | x |  | x |
| 11 | Bắt đầu pha chế | Button | x |  | x |
| 12 | Hoàn tất | Button | x |  | x |
| 13 | Cập nhật | Button | x |  | x |
| 14 | Hủy | Button |  |  | x |
| 15 | Thanh điều hướng dữ liệu | BindingNavigator | x |  | x |
| 16 | THÔNG TIN ĐỒ UỐNG ĐANG PHA CHẾ | Groupbox | x |  | x |
| 17 | Hiển thị hình ảnh đồ uống | PictureBox |  |  | x |
| 18 | Số phiếu | Label |  |  | x |
| 19 | Hiển thị Số phiếu | Textbox | x | 20 | x |
| 20 | Mã đồ uống | Label |  |  | x |
| 21 | Hiển thị Mã đồ uống | Textbox | x | 20 | x |
| 22 | Tên đồ uống | Label |  |  | x |
| 23 | Hiển thị Tên đồ uống | Textbox | x | 100 | x |
| 24 | Loại đồ uống | Label |  |  | x |
| 25 | Hiển thị Loại đồ uống | Textbox | x | 50 | x |
| 26 | Size | Label |  |  | x |
| 27 | Hiển thị Size | Textbox | x | 5 | x |
| 28 | Số lượng | Label |  |  | x |
| 29 | Hiển thị Số lượng | Textbox | x | 3 | x |
| 30 | THÔNG TIN CẬP NHẬT TRẠNG THÁI | Groupbox | x |  | x |
| 31 | Số bàn | Label |  |  | x |
| 32 | Hiển thị Số bàn | Textbox |  | 10 | x |
| 33 | Yêu cầu đặc biệt | Label |  |  | x |
| 34 | Hiển thị Yêu cầu đặc biệt | Textbox |  | 100 | x |
| 35 | NV pha chế | Label |  |  | x |
| 36 | Hiển thị NV pha chế | Textbox | x | 50 |  |
| 37 | Trạng thái | Label |  |  | x |
| 38 | Chọn Trạng thái pha chế | Combobox | x | 30 |  |
| 39 | Thời gian nhận | Label |  |  | x |
| 40 | Hiển thị Thời gian nhận | Textbox | x | 10 | x |
| 41 | TG bắt đầu | Label |  |  | x |
| 42 | Hiển thị TG bắt đầu | Textbox |  | 10 | x |
| 43 | TG hoàn tất | Label |  |  | x |
| 44 | Hiển thị TG hoàn tất | Textbox |  | 10 | x |
| 45 | Ghi chú hướng dẫn | Label |  | 150 | x |
| 46 | Bắt đầu pha chế | Button | x |  | x |
| 47 | Hoàn tất | Button | x |  | x |
| 48 | Cập nhật | Button | x |  | x |
| 49 | Làm mới | Button |  |  | x |
| 50 | GHI CHÚ PHA CHẾ | Groupbox |  |  | x |
| 51 | Hiển thị Ghi chú | Textbox |  | 200 |  |
| 52 | THANH TRẠNG THÁI | StatusStrip/Panel |  |  | x |
| 53 | Hiển thị tên người dùng | Label |  | 50 | x |
| 54 | Hiển thị vai trò người dùng | Label |  | 50 | x |

6. Biểu đồ hoạt động
7. Bảng dữ liệu

### [TABLE 106]
| Tên bảng dữ liệu | Thuộc tính sử dụng | Mức độ sử dụng C, E, R, D | Điều kiện toàn vẹn |
| B04.K_H | B04.K_H | B04.K_H | B04.K_H |
|  | ma_kh | R |  |
|  | tenkhachhang | R |  |
|  | sodienthoai | R |  |
|  | diachi | R |  |
| B06.P_G_DU | B06.P_G_DU | B06.P_G_DU | B06.P_G_DU |
|  | so_pgdu | R |  |
|  | ma_kh | R |  |
|  | ngaygoidouong | R |  |
|  | thoigiangoidouong | R |  |
|  | tenkhachhang | R |  |
|  | soban | R |  |
|  | trangthai | R, E |  |
|  | tennd | R |  |
|  | ma_nd | R |  |
| B06.1.C_T_PGDU | B06.1.C_T_PGDU | B06.1.C_T_PGDU | B06.1.C_T_PGDU |
|  | so_pgdu | R |  |
|  | ma_du | R |  |
|  | soluong | R |  |
|  | yeucaudacbiet | R |  |
|  | size | R |  |
| B03.DU | B03.DU | B03.DU | B03.DU |
|  | ma_du | R |  |
|  | ma_ldu | R |  |
|  | tendouong | R |  |
|  | dongia | R |  |
|  | donvitinh | R |  |
|  | tinhtrang | R |  |
| B01.LDU | B01.LDU | B01.LDU | B01.LDU |
|  | ma_ldu | R |  |
|  | tenloaidouong | R |  |
|  | mota | R |  |
| B07.HD_BDUONG | B07.HD_BDUONG | B07.HD_BDUONG | B07.HD_BDUONG |
|  | so_hdbdu | C, R, D | Mã tự sinh |
|  | ma_kh | C, R, E |  |
|  | so_pgdu | C, R |  |
|  | ngaylaphoadon | C, R | Ngày hệ thống |
|  | thoigianthanhtoan | C, R | Thời gian hệ thống |
|  | hinhthucthanhtoan | C, R, E |  |
|  | trangthai | C, R, E |  |
|  | ghichu | C, R, E | Tối đa 200 ký tự |
|  | nguoilaphoadon | C, R |  |
|  | ma_du | R |  |
|  | soluongban | C, E, R, D | Chữ số, >0 |
|  | dongia | C, E, R, D | Chữ số |
|  | thanhtien | C, E, R, D |  |
|  | tongtien | C, E, R, D |  |

8. Quy trình, công thức xử lý

### [TABLE 107]
| ST T | Đối tượng tương tác | Xử lý | Bảng dữ liệu liên quan |
| 1 | btnThem | Nếu click vào button này Thì Mở frmLapHDBDU. Tự động sinh mã hóa đơn bán đồ uống mới trên txtMaHDBDU. Ngày lập lấy ngày hiện tại trên txtNgayLap. Thời gian lập lấy thời gian hiện tại trên txtThoiGianLap. Nhân viên lập lấy tên người dùng hiện tại trên txtNhanVien. Các textbox, combobox còn lại = null và dgvDoUong chưa có dữ liệu. | HD_BDUONG |
| 2 | btnReturn | Nếu click vào button này Thì trở lại frmQuanLyHDBDU. |  |
| 3 | btnChonKH | Nếu click vào button này Thì mở frmChonKhachHang gồm dgvKhachHang và txtTimKiem. Nếu txtTimKiem != null Thì Tìm kiếm khách hàng theo mã khách hàng, tên khách hàng, CCCD/CMND hoặc số điện thoại. Nếu dgvKhachHang = null Thì hiển thị thông báo “Không tìm thấy khách hàng”. Nếu không Thì nhấn checkbox chọn khách hàng muốn lập hóa đơn. Nếu click Chọn Thì điền mã khách hàng, tên khách hàng, CCCD/CMND, số điện thoại và địa chỉ vào các ô tương ứng trên frmLapHDBDU. Nếu click Hủy Thì đóng frmChonKhachHang và quay về frmLapHDBDU. | K_H |
| 4 | btnThemKH | Nếu click vào button này Thì Mở frmThemKhachHang. Tự động sinh mã khách hàng mới trên txtMaKH. Các textbox, combobox còn lại = null. Nếu click Lưu Nếu txtTenKH, txtSDT, txtDiaChiChiTiet = null Thì hiển thị thông báo không được để trống dữ liệu. Nếu không Thì lưu khách hàng mới vào CSDL và điền thông tin khách hàng vào frmLapHDBDU. Nếu click Hủy hoặc close form Thì đóng frmThemKhachHang và quay về frmLapHDBDU. | K_H |
| 5 | btnChonPGDU | Nếu click vào button này Thì mở frmChonPhieuGoiDoUong gồm dgvPGDU và txtTimKiem. Nếu txtTimKiem != null Thì Tìm kiếm phiếu gọi đồ uống theo số phiếu, ngày lập, số bàn hoặc nhân viên lập. Nếu dgvPGDU = null Thì hiển thị thông báo “Không tìm thấy phiếu gọi đồ uống”. Nếu không Thì nhấn checkbox chọn phiếu gọi đồ uống muốn lập hóa đơn. Nếu click Chọn Thì điền số phiếu gọi, ngày gọi, thời gian gọi, số bàn và danh sách đồ uống vào các ô tương ứng trên frmLapHDBDU. Nếu click Hủy Thì đóng frmChonPhieuGoiDoUong và quay về frmLapHDBDU. | P_G_DU C_T_PGDU DU |
| 6 | btnXemPGDU | Nếu click vào button này Thì mở frmXemTruocPhieuGoiDoUong. Tải hình ảnh xem trước phiếu gọi đồ uống theo biểu mẫu: thông tin quán, số phiếu, ngày gọi, thời gian gọi, trạng thái và danh sách đồ uống. Nếu click In Thì in phiếu gọi đồ uống. Nếu click Thoát Thì đóng frmXemTruocPhieuGoiDoUong và quay về frmChonPhieuGoiDoUong. | P_G_DU C_T_PGDU DU |
| 7 | btnLuu | Nếu click vào button này Thì Nếu txtMaKH, txtTenKH, txtSDT, txtDiaChi, txtCCCD, txtSoPGDU, txtNgayGoi, txtThoiGianGoi, txtSoBan, cboHinhThucThanhToan, cboTrangThaiThanhToan, txtGiamGia, txtThueVAT, txtTongTienThanhToan, dgvDoUong = null Thì hiển thị thông báo không được để trống dữ liệu và trở lại frmLapHDBDU. Nếu không Thì lưu dữ liệu hóa đơn bán đồ uống vào CSDL. Tính tổng tiền thanh toán = tổng thành tiền đồ uống - giảm giá + thuế VAT. Cập nhật trạng thái thanh toán theo cboTrangThaiThanhToan. Nếu cập nhật thành công Thì hiển thị thông báo lưu thành công. Nếu chọn OK Thì đóng thông báo và tự động cập nhật dữ liệu trên dgvHoaDon. Nếu cập nhật không thành công Thì hiển thị thông báo lỗi và tiếp tục ở lại frmLapHDBDU. | HD_BDUONG K_H P_G_DU C_T_PGDU DU |
| 8 | btnXemTruocTamTinh | Nếu click vào button này Thì mở frmXemTruocPhieuTamTinh. Nếu txtMaKH, txtTenKH, txtSDT, txtDiaChi, txtSoPGDU, dgvDoUong = null Thì hiển thị thông báo không được để trống dữ liệu và trở lại frmLapHDBDU. Nếu không Thì tải hình ảnh xem trước phiếu tạm tính theo biểu mẫu: thông tin quán, thông tin khách hàng, danh sách đồ uống, giảm giá, thuế VAT và tổng tiền tạm tính. Nếu click In Thì in phiếu tạm tính và quay về frmLapHDBDU. Nếu click Thoát Thì đóng frmXemTruocPhieuTamTinh và quay về frmLapHDBDU. | K_H P_G_DU C_T_PGDU DU |
| 9 | btnXuatHD | Nếu click vào button này Thì mở frmXuatHoaDonBanDoUong. Nếu txtMaKH, txtTenKH, txtSDT, txtDiaChi, txtCCCD, txtSoPGDU, txtNgayGoi, txtThoiGianGoi, txtSoBan, cboHinhThucThanhToan, cboTrangThaiThanhToan, dgvDoUong = null Thì hiển thị thông báo không được để trống dữ liệu và trở lại frmLapHDBDU. Nếu không Thì tải mẫu hóa đơn bán đồ uống theo biểu mẫu: thông tin quán, số hóa đơn, thông tin khách hàng, hình thức thanh toán, danh sách đồ uống và tổng tiền thanh toán. Nếu click Xuất hoặc In Thì cập nhật dữ liệu hóa đơn bán đồ uống vào CSDL, xuất/in hóa đơn và quay về frmQuanLyHDBDU. Nếu click Thoát Thì đóng frmXuatHoaDonBanDoUong và quay về frmLapHDBDU. | HD_BDUONG K_H P_G_DU C_T_PGDU DU |
| 10 | btnHuy | Nếu click vào button này Thì đóng frmLapHDBDU và quay về frmQuanLyHDBDU. |  |

9. Định dang kết quả đầu ra:
- Khi thoát khỏi giao diện thì:
+ Bảng dữ liệu bị thay đổi: P_G_DU, C_T_PGDU
+ Trạng thái hệ thống sau khi thoát khỏi giao diện: Trở về giao diện Trang chủ
##### 3.4.4. Thiết kế báo cáo
(1) Bảng 14. Bảng tổng hợp báo cáo đầu ra

### [TABLE 108]
| STT | Mẫu biểu | Tiến trình hệ thống tạo báo cáo | Mục đơn chọn tương ứng | Bảng dữ liệu liên quan | Thiết kế |
| 1 | MB.01. Menu | 090. Cập nhật thông tin đồ uống trong Menu | C03.02. Cập nhật Menu | B03. DU B03.1. DU_NL B01. LDU |  |
| 2 | MB.02. Phiếu gọi đồ uống | 011. In phiếu gọi đồ uống | C01.01. Lập phiếu gọi đồ uống | B06. P_G_DU B06.1. C_T_PGĐU B04. K_H B03. DU B03.1. DU_NL |  |
| 3 | MB.03. Phiếu tạm tính | 019. In phiếu tạm tính | C01.02. Cập nhật trạng thái phục vụ đồ uống | B06. P_G_DU B06.1. C_T_PGĐU B04. K_H B03. DU B03.1. DU_NL | Thiết kế tương tự Hoá đơn bán đồ uống chỉ khác ở trạng thái |
| 4 | MB.04. Hóa đơn bán đồ uống | 029. In hóa đơn bán đồ uống | C02.01. Lập hóa đơn bán đồ uống | B07. HD_BDU B07.1. C_T_HDBĐU B04. K_H B03. DU B03.1. DU_NL | (*) |
| 5 | MB.05. Đơn nguyên liệu mua | 045. In đơn nguyên liệu mua | C02.02. Lập đơn nguyên liệu mua | B08. D_NLM B08.1. C_T_ĐNLM B05. NCC B02. NL |  |
| 6 | MB.06. Phiếu nhập hàng | 103. In phiếu nhập hàng | C03.03. Lập phiếu nhập hàng | B09. P_NH B09.1. C_T_PNH B05. NCC B02. NL |  |
| 7 | MB.07. Phiếu kiểm kê | 116. In phiếu kiểm kê | C03.04. Lập phiếu kiểm kê | B10. P_KK B10.1. C_T_PKK B05. NCC B02. NL |  |
| 8 | MB.08. Báo cáo doanh thu theo ngày | 057. In thống kê doanh thu ngày | C02.03. Lập Thống kê doanh thu ngày | B07.HD_BDUONG B07.1.C_T_HDBDU B03.DU B03.1.DU_NL | (*) |
| 9 | MB.09. Biên bản đối soát doanh thu | 068. In biên bản đối soát chênh lệch doanh thu | C02.04. Lập biên bản đối soát chênh lệch doanh thu | B07. HD_BDU B07.1. C_T_HDBĐU B03.DU B03.1.DU_NL |  |
| 10 | MB.10. Báo cáo đồ uống bán chạy trong tháng | 077. In thống kê đồ uống bán chạy trong tháng | C02.05. Lập thống kê đồ uống bán chạy trong tháng | B07.HD_BDUONG B07.1.C_T_HDBDU B03.DU B03.1.DU_NL |  |

Tên báo cáo : HÓA ĐƠN BÁN ĐỒ UỐNG
Người lập : Nhân viên thu ngân
Nhiệm vụ : Từ thông tin Phiếu gọi đồ uống và thông tin thanh toán của khách hàng để lập thông tin hóa đơn bán đồ uống.
Môi trường : MTN.01. Khách hàng
Mẫu báo cáo : MB.04. Hóa đơn bán đồ uống
Bảng dữ liệu

### [TABLE 109]
| STT | Trường thông tin trên mẫu biểu | Trường dữ liệu trong CSDL |
| 1 | Số hóa đơn | HD_BDUONG.so_hdbdu |
| 2 | Ngày thanh toán | HD_BDUONG.ngaylaphoadon |
| 3 | Thời gian thanh toán | HD_BDUONG.thoigianthanhtoan |
| 4 | Tên khách hàng | K_H.tenkhachhang |
| 5 | Số điện thoại khách hàng | K_H.sodienthoai |
| 6 | Địa chỉ khách hàng | K_H.diachi |
| 7 | Giới tính | K_H.gioitinh |
| 8 | Hình thức thanh toán | HD_BDUONG.hinhthucthanhtoan |
| 9 | Tên đồ uống | DU.tendouong |
| 10 | Size | C_T_HDBDU.size |
| 11 | Số lượng | C_T_HDBDU.soluongban |
| 12 | Đơn giá | DU.dongia |
| 13 | Thành tiền | C_T_HDBDU.thanhtien |
| 14 | Giảm giá | HD_BDUONG.giamgia |
| 15 | Phụ thu | HD_BDUONG.phuthu |
| 16 | Tổng tiền thanh toán | HD_BDUONG.tongtien |
| 17 | Trạng thái | HD_BDUONG.trangthai |
| 18 | Ghi chú | HD_BDUONG.ghichu |
| 19 | Người lập hóa đơn | HD_BDUONG.nguoilaphoadon |
| 20 | Khách hàng | K_H.tenkhachhang |

Tóm lại, mẫu biểu Hóa đơn bán đồ uống sử dụng các bảng sau:
(1) B07.HD_BDUONG (so_hdbdu, ma_kh, so_pgdu, ngaylaphoadon, thoigianthanhtoan, hinhthucthanhtoan, trangthai, ghichu, nguoilaphoadon, giamgia, phuthu, tongtien)
(2) B07.1.C_T_HDBDU (so_hdbdu, ma_du, size, soluongban, dongia, thanhtien)
(3) B04.K_H (ma_kh, tenkhachhang, sodienthoai, diachi, gioitinh)
(4) B03.DU (ma_du, tendouong, dongia, donvitinh, tinhtrang)
Trường dữ liệu tính toán

### [TABLE 110]
| STT | Trường dữ liệu trong báo cáo | Công thức |
| 1 | C_T_HDBDU.thanhtien | = C_T_HDBDU.soluongban * DU.dongia |
| 2 | HD_BDUONG.tongtien | = ∑ (C_T_HDBDU.thanhtien) + HD_BDUONG.phuthu - HD_BDUONG.giamgia |

Kích cỡ : Khổ giấy sử dụng A4(210mm x 297mm)
Số lượng phiên bản : 02 bản.
4.5. Thiết kế báo cáo thống kê
Bảng tổng hợp báo cáo thống kê :

### [TABLE 111]
| STT | Mẫu biểu thống kê | Tên bảng dữ liệu trong RM | Menu |
| 1 | Báo cáo doanh thu theo ngày | B07.HD_BDUONG B07.1.C_T_HDBDU B03.DU B03.1.DU_NL | Nhân viên Thu ngân → Thống kê doanh thu ngày |
| 2 | Báo cáo đồ uống bán chạy trong tháng | B07.HD_BDUONG B07.1.C_T_HDBDU B03.DU B03.1.DU_NL | Nhân viên Thu ngân → Thống kê đồ uống bán chạy |

Tên báo cáo : BÁO CÁO DOANH THU THEO NGÀY
Người lập : Nhân viên thu ngân
Nhiệm vụ : Thống kê doanh thu trong ngày của quán cafe và gửi báo cáo đến cho Người quản lý
Môi trường : MTT.01. Người quản lý
Mẫu báo cáo : MB.08. Báo cáo doanh thu theo ngày
Bảng dữ liệu

### [TABLE 112]
| STT | Trường thông tin trên mẫu biểu | Trường dữ liệu trong CSDL |
| 1 | Ngày báo cáo | HD_BDUONG.ngaylaphoadon |
| 2 | Người lập báo cáo | HD_BDUONG.nguoilaphoadon |
| 3 | Mã hóa đơn | HD_BDUONG.so_hdbdu |
| 4 | Thời gian thanh toán | HD_BDUONG.thoigianthanhtoan |
| 5 | Hình thức thanh toán | HD_BDUONG.hinhthucthanhtoan |
| 6 | Mã đồ uống | C_T_HDBDU.ma_du |
| 7 | Tên đồ uống | DU.tendouong |
| 8 | Đơn vị tính | DU.donvitinh |
| 9 | Số lượng bán | C_T_HDBDU.soluongban |
| 10 | Đơn giá | DU.dongia |
| 11 | Thành tiền | C_T_HDBDU.thanhtien |
| 12 | Ghi chú | HD_BDUONG.ghichu |
| 13 | Tổng số lượng đồ uống bán ra | Trường dữ liệu tính toán: =∑ (C_T_HDBDU.soluongban) |
| 14 | Tổng doanh thu trong ngày | Trường dữ liệu tính toán: =∑ (C_T_HDBDU.thanhtien) |

Tóm lại, mẫu biểu Báo cáo doanh thu theo ngày sử dụng các bảng dữ liệu sau:
(1) B07.HD_BDUONG (so_hdbdu, ngaylaphoadon, thoigianthanhtoan, hinhthucthanhtoan, ghichu, nguoilaphoadon)
(2) B07.1.C_T_HDBDU (so_hdbdu, ma_du, soluongban, dongia, thanhtien)
(3) B03.DU (ma_du, ma_ldu, tendouong, dongia, donvitinh, tinhtrang)
(4) B03.1.DU_NL (ma_du, ma_nl)
Trường dữ liệu tính toán

### [TABLE 113]
| STT | Trường dữ liệu trong báo cáo | Công thức |
| 1 | Thành tiền | = C_T_HDBDU.soluongban * DU.dongia |
| 2 | Tổng số lượng đồ uống bán ra | =∑ (C_T_HDBDU.soluongban) |
| 3 | Tổng doanh thu trong ngày | =∑ (C_T_HDBDU.thanhtien) |

Kích cỡ : Khổ giấy sử dụng A4(210mm x 297mm)
Số lượng phiên bản : 01 bản.
## ĐÁNH GIÁ CÔNG VIỆC VÀ KẾT LUẬN
Sau quá trình nghiên cứu, khảo sát và phân tích thiết kế hệ thống "Quản lý bán hàng quán cà phê take away", em đã hoàn thành các nội dung công việc đề ra ban đầu. Em đã tiến hành khảo sát thực trạng, xác định cơ cấu tổ chức, quy trình nghiệp vụ cốt lõi, xây dựng mô hình chức năng và thiết kế hệ thống dữ liệu chi tiết. Tuy nhiên, nhìn nhận một cách khách quan, hệ thống vẫn còn tồn tại một số hạn chế nhất định.
Về mặt quy trình, hệ thống hiện tại chủ yếu tập trung vào các nghiệp vụ cơ bản, chưa phân tích sâu vào các kịch bản phức tạp như: quản lý chương trình khuyến mãi theo giờ, quản lý thẻ thành viên tích điểm hoặc chính sách chiết khấu linh hoạt cho khách hàng thân thiết. Bên cạnh đó, việc quản lý kho nguyên liệu mới chỉ dừng lại ở mức ghi nhận, chưa có cơ chế cảnh báo tự động khi nguyên liệu sắp hết hoặc tính toán định mức tiêu hao nguyên liệu cho mỗi sản phẩm bán ra, điều này sẽ gây khó khăn trong việc kiểm soát chi phí thực tế. Về mặt kỹ thuật, thiết kế giao diện chưa được tối ưu hóa cho các thiết bị di động (như máy tính bảng tại quầy thu ngân), và cấu trúc cơ sở dữ liệu hiện tại có thể gặp trở ngại khi phải xử lý đồng thời một lượng lớn giao dịch trong giờ cao điểm mà không có cơ chế lưu trữ đệm hoặc phân quyền người dùng phức tạp. Ngoài ra, việc bảo mật dữ liệu và phân quyền truy cập giữa các bộ phận (phục vụ, pha chế, quản lý) mới chỉ dừng lại ở mức phân cấp chức năng, chưa có các giải pháp bảo mật nâng cao để ngăn chặn rủi ro mất mát hoặc rò rỉ thông tin doanh thu.
Tổng kết lại, đề tài đã góp phần giải quyết bài toán quản lý thủ công, giúp tối ưu hóa quy trình từ khâu gọi món đến thanh toán và báo cáo, tạo tiền đề quan trọng để phát triển thành một phần mềm hoàn chỉnh. Mặc dù còn những hạn chế kể trên, đây là những bài học kinh nghiệm quý báu giúp em nhận ra tầm quan trọng của việc khảo sát kỹ lưỡng và dự báo các tình huống phát sinh trong thực tế. Để hệ thống đạt hiệu quả cao nhất, trong thời gian tới, em dự định sẽ tiếp tục nghiên cứu để bổ sung tính năng quản lý kho tự động, tối ưu hóa giao diện người dùng theo hướng hiện đại và cập nhật các phương thức bảo mật dữ liệu chặt chẽ hơn.
## TÀI LIỆU THAM KHẢO
1. Nguyễn Hoài Anh, Slide bài giảng môn phân tích và thiết kế hệ thống, 2025-2026.
2. Lường Thị Ngàn, "Bài Tập Học Phần Phân Tích Và Thiết Kế Hệ Thống quản lý bán hàng tại cửa hàng trà sữa",11/2025.
3. Nguyễn Lê Hồng Nhung, "Bài Tập Học Phần Phân Tích Và Thiết Kế Hệ Thống quản lý bán hàng tại quán cafe truyền thống",11/2025.
4. Nguyễn Đức Hòa, "Bài Tập Học Phần Phân Tích Và Thiết Kế Hệ Thống quản lý mượn trả sách thư viện đại học",11/2025.