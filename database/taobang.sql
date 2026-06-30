USE master;
GO

IF DB_ID(N'QLBH_TAKEAWAY') IS NOT NULL
BEGIN
    ALTER DATABASE QLBH_TAKEAWAY SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLBH_TAKEAWAY;
END
GO

CREATE DATABASE QLBH_TAKEAWAY;
GO

USE QLBH_TAKEAWAY;
GO

/* =========================================================
   CSDL: QUẢN LÝ BÁN HÀNG CÀ PHÊ TAKE AWAY
   Theo mục 3.3.4. Đặc tả bảng dữ liệu
   ========================================================= */


/* =========================
   1. BẢNG BẢO MẬT - NGƯỜI DÙNG
   ========================= */

CREATE TABLE NGUOIDUNG (
    ma_nd       VARCHAR(10)    NOT NULL PRIMARY KEY,
    tennd       NVARCHAR(50)   NOT NULL,
    sdt         VARCHAR(11)    NULL,
    usr         VARCHAR(20)    NOT NULL UNIQUE,
    pwd_hash    VARCHAR(64)    NOT NULL,
    vitri       NVARCHAR(50)   NULL,
    trangthai   BIT            NOT NULL DEFAULT 1
);

CREATE TABLE NHOMND (
    ma_nhom     VARCHAR(10)    NOT NULL PRIMARY KEY,
    tennhom     NVARCHAR(50)   NOT NULL,
    mota        NVARCHAR(100)  NULL,
    trangthai   BIT            NOT NULL DEFAULT 1
);

CREATE TABLE QUYEN (
    ma_quyen    VARCHAR(10)    NOT NULL PRIMARY KEY,
    tenquyen    NVARCHAR(50)   NOT NULL
);

CREATE TABLE ND_NHOM (
    ma_nd       VARCHAR(10)    NOT NULL,
    ma_nhom     VARCHAR(10)    NOT NULL,

    CONSTRAINT PK_ND_NHOM PRIMARY KEY (ma_nd, ma_nhom),

    CONSTRAINT FK_ND_NHOM_NGUOIDUNG
        FOREIGN KEY (ma_nd) REFERENCES NGUOIDUNG(ma_nd),

    CONSTRAINT FK_ND_NHOM_NHOMND
        FOREIGN KEY (ma_nhom) REFERENCES NHOMND(ma_nhom)
);

CREATE TABLE PHANQUYEN (
    ma_nhom     VARCHAR(10)    NOT NULL,
    ma_quyen    VARCHAR(10)    NOT NULL,

    CONSTRAINT PK_PHANQUYEN PRIMARY KEY (ma_nhom, ma_quyen),

    CONSTRAINT FK_PHANQUYEN_NHOMND
        FOREIGN KEY (ma_nhom) REFERENCES NHOMND(ma_nhom),

    CONSTRAINT FK_PHANQUYEN_QUYEN
        FOREIGN KEY (ma_quyen) REFERENCES QUYEN(ma_quyen)
);


/* =========================
   2. BẢNG DANH MỤC
   ========================= */

CREATE TABLE LDU (
    ma_ldu          VARCHAR(10)    NOT NULL PRIMARY KEY,
    tenloaidouong   NVARCHAR(50)   NOT NULL,
    mota            NVARCHAR(100)  NULL
);

CREATE TABLE NL (
    ma_nl           VARCHAR(10)    NOT NULL PRIMARY KEY,
    tennguyenlieu   NVARCHAR(50)   NOT NULL,
    donvitinh       NVARCHAR(20)   NOT NULL
);

CREATE TABLE K_H (
    ma_kh           VARCHAR(10)    NOT NULL PRIMARY KEY,
    tenkhachhang    NVARCHAR(50)   NOT NULL,
    sodienthoai     VARCHAR(11)    NULL,
    diachi          NVARCHAR(100)  NULL,
    gioitinh        NVARCHAR(10)   NULL
);

CREATE TABLE NCC (
    ma_ncc              VARCHAR(10)    NOT NULL PRIMARY KEY,
    tennhacungcap       NVARCHAR(100)  NOT NULL,
    diachincc           NVARCHAR(100)  NULL,
    sodienthoaincc      VARCHAR(11)    NULL
);

CREATE TABLE DU (
    ma_du           VARCHAR(10)     NOT NULL PRIMARY KEY,
    ma_ldu          VARCHAR(10)     NOT NULL,
    tendouong       NVARCHAR(50)    NOT NULL,
    dongia          DECIMAL(18,2)   NOT NULL,

    CONSTRAINT FK_DU_LDU
        FOREIGN KEY (ma_ldu) REFERENCES LDU(ma_ldu),

    CONSTRAINT CK_DU_DONGIA
        CHECK (dongia >= 0)
);

CREATE TABLE DU_NL (
    ma_nl       VARCHAR(10) NOT NULL,
    ma_du       VARCHAR(10) NOT NULL,

    CONSTRAINT PK_DU_NL PRIMARY KEY (ma_nl, ma_du),

    CONSTRAINT FK_DU_NL_NL
        FOREIGN KEY (ma_nl) REFERENCES NL(ma_nl),

    CONSTRAINT FK_DU_NL_DU
        FOREIGN KEY (ma_du) REFERENCES DU(ma_du)
);


/* =========================
   3. PHIẾU GỌI ĐỒ UỐNG
   ========================= */

CREATE TABLE P_G_DU (
    so_pgdu             VARCHAR(10)    NOT NULL PRIMARY KEY,
    ma_kh               VARCHAR(10)    NOT NULL,
    ngaygoiduong        DATE           NOT NULL,
    thoigiangoiduong    TIME(0)        NOT NULL,
    tenkhachhang        NVARCHAR(50)   NULL,
    tennd               NVARCHAR(50)   NOT NULL,
    ma_nd               VARCHAR(10)    NOT NULL,

    CONSTRAINT FK_P_G_DU_KH
        FOREIGN KEY (ma_kh) REFERENCES K_H(ma_kh),

    CONSTRAINT FK_P_G_DU_NGUOIDUNG
        FOREIGN KEY (ma_nd) REFERENCES NGUOIDUNG(ma_nd)
);

CREATE TABLE C_T_PGDU (
    ma_du           VARCHAR(10)    NOT NULL,
    so_pgdu         VARCHAR(10)    NOT NULL,
    size            NVARCHAR(10)   NOT NULL,
    soluonggoi      INT            NOT NULL,
    yeucaudacbiet   NVARCHAR(200)  NULL,

    CONSTRAINT PK_C_T_PGDU PRIMARY KEY (ma_du, so_pgdu, size),

    CONSTRAINT FK_C_T_PGDU_DU
        FOREIGN KEY (ma_du) REFERENCES DU(ma_du),

    CONSTRAINT FK_C_T_PGDU_P_G_DU
        FOREIGN KEY (so_pgdu) REFERENCES P_G_DU(so_pgdu),

    CONSTRAINT CK_C_T_PGDU_SOLUONG
        CHECK (soluonggoi > 0)
);


/* =========================
   4. HÓA ĐƠN BÁN ĐỒ UỐNG
   ========================= */

CREATE TABLE HD_BDUONG (
    so_hdbdu             VARCHAR(10)     NOT NULL PRIMARY KEY,
    ma_khachhang         VARCHAR(10)     NOT NULL,
    so_pgdu              VARCHAR(10)     NOT NULL,
    ngaylaphoadon        DATE            NOT NULL,
    thoigianthanhtoan    TIME(0)         NOT NULL,
    hinhthucthanhtoan    NVARCHAR(30)    NOT NULL,
    trangthai            NVARCHAR(20)    NOT NULL,
    ghichu               NVARCHAR(200)   NULL,
    nguoilaphoadon       NVARCHAR(50)    NOT NULL,

    ma_du                VARCHAR(10)     NOT NULL,
    soluongban           INT             NOT NULL,
    tendouong            NVARCHAR(50)    NOT NULL,
    thanhtien            DECIMAL(18,2)   NOT NULL,

    tennd                NVARCHAR(50)    NOT NULL,
    ma_nd                VARCHAR(10)     NOT NULL,

    CONSTRAINT FK_HD_BDUONG_KH
        FOREIGN KEY (ma_khachhang) REFERENCES K_H(ma_kh),

    CONSTRAINT FK_HD_BDUONG_P_G_DU
        FOREIGN KEY (so_pgdu) REFERENCES P_G_DU(so_pgdu),

    CONSTRAINT FK_HD_BDUONG_NGUOIDUNG
        FOREIGN KEY (ma_nd) REFERENCES NGUOIDUNG(ma_nd),

    CONSTRAINT CK_HD_BDUONG_SOLUONG
        CHECK (soluongban > 0),

    CONSTRAINT CK_HD_BDUONG_THANHTIEN
        CHECK (thanhtien >= 0)
);

CREATE TABLE C_T_HDBDU (
    so_hdbdu       VARCHAR(10)     NOT NULL,
    ma_du          VARCHAR(10)     NOT NULL,
    size           NVARCHAR(10)    NOT NULL,
    soluongban     INT             NOT NULL,
    thanhtien      DECIMAL(18,2)   NOT NULL,

    CONSTRAINT PK_C_T_HDBDU PRIMARY KEY (so_hdbdu, ma_du, size),

    CONSTRAINT FK_C_T_HDBDU_HD_BDUONG
        FOREIGN KEY (so_hdbdu) REFERENCES HD_BDUONG(so_hdbdu),

    CONSTRAINT FK_C_T_HDBDU_DU
        FOREIGN KEY (ma_du) REFERENCES DU(ma_du),

    CONSTRAINT CK_C_T_HDBDU_SOLUONG
        CHECK (soluongban > 0),

    CONSTRAINT CK_C_T_HDBDU_THANHTIEN
        CHECK (thanhtien >= 0)
);


/* =========================
   5. ĐƠN NGUYÊN LIỆU MUA
   ========================= */

CREATE TABLE D_NLM (
    so_dnlm         VARCHAR(10)     NOT NULL PRIMARY KEY,
    ngaylapdon      DATE            NOT NULL,
    nhacungcap      NVARCHAR(100)   NOT NULL,
    diachi          NVARCHAR(100)   NULL,
    sodienthoai     VARCHAR(11)     NULL,
    bophan          NVARCHAR(50)    NOT NULL,
    ghichu          NVARCHAR(200)   NULL,
    nguoilapdon     NVARCHAR(50)    NOT NULL,
    quanly          NVARCHAR(50)    NULL,
    tennd           NVARCHAR(50)    NOT NULL,
    ma_nd           VARCHAR(10)     NOT NULL,

    CONSTRAINT FK_D_NLM_NGUOIDUNG
        FOREIGN KEY (ma_nd) REFERENCES NGUOIDUNG(ma_nd)
);

CREATE TABLE C_T_DNLMUA (
    ma_nl           VARCHAR(10)     NOT NULL,
    so_dnlm         VARCHAR(10)     NOT NULL,
    soluongdenghi   INT             NOT NULL,
    dongiadukien    DECIMAL(18,2)   NOT NULL,

    CONSTRAINT PK_C_T_DNLMUA PRIMARY KEY (ma_nl, so_dnlm),

    CONSTRAINT FK_C_T_DNLMUA_NL
        FOREIGN KEY (ma_nl) REFERENCES NL(ma_nl),

    CONSTRAINT FK_C_T_DNLMUA_D_NLM
        FOREIGN KEY (so_dnlm) REFERENCES D_NLM(so_dnlm),

    CONSTRAINT CK_C_T_DNLMUA_SOLUONG
        CHECK (soluongdenghi > 0),

    CONSTRAINT CK_C_T_DNLMUA_DONGIA
        CHECK (dongiadukien >= 0)
);


/* =========================
   6. PHIẾU NHẬP HÀNG
   ========================= */

CREATE TABLE P_NH (
    so_pnh             VARCHAR(10)     NOT NULL PRIMARY KEY,
    ma_ncc             VARCHAR(10)     NOT NULL,
    so_dnlm            VARCHAR(10)     NOT NULL,
    ngaygiao           DATE            NOT NULL,
    thoigiangiaohang   TIME(0)         NOT NULL,
    tenkhachhang       NVARCHAR(50)    NULL,
    nguoigiaohang      NVARCHAR(50)    NOT NULL,
    nguoinhanhang      NVARCHAR(50)    NOT NULL,

    ma_nl              VARCHAR(10)     NOT NULL,
    soluonggiao        INT             NOT NULL,
    tennguyenlieu      NVARCHAR(50)    NOT NULL,
    thanhtien          DECIMAL(18,2)   NOT NULL,

    tennd              NVARCHAR(50)    NOT NULL,
    ma_nd              VARCHAR(10)     NOT NULL,

    CONSTRAINT FK_P_NH_NCC
        FOREIGN KEY (ma_ncc) REFERENCES NCC(ma_ncc),

    CONSTRAINT FK_P_NH_D_NLM
        FOREIGN KEY (so_dnlm) REFERENCES D_NLM(so_dnlm),

    CONSTRAINT FK_P_NH_NGUOIDUNG
        FOREIGN KEY (ma_nd) REFERENCES NGUOIDUNG(ma_nd),

    CONSTRAINT CK_P_NH_SOLUONG
        CHECK (soluonggiao > 0),

    CONSTRAINT CK_P_NH_THANHTIEN
        CHECK (thanhtien >= 0)
);

CREATE TABLE C_T_PNH (
    so_pnh         VARCHAR(10)     NOT NULL,
    ma_nl          VARCHAR(10)     NOT NULL,
    soluonggiao    INT             NOT NULL,
    tinhtrang      NVARCHAR(50)    NOT NULL,
    ghichu         NVARCHAR(200)   NULL,

    CONSTRAINT PK_C_T_PNH PRIMARY KEY (so_pnh, ma_nl),

    CONSTRAINT FK_C_T_PNH_P_NH
        FOREIGN KEY (so_pnh) REFERENCES P_NH(so_pnh),

    CONSTRAINT FK_C_T_PNH_NL
        FOREIGN KEY (ma_nl) REFERENCES NL(ma_nl),

    CONSTRAINT CK_C_T_PNH_SOLUONG
        CHECK (soluonggiao > 0)
);


/* =========================
   7. PHIẾU KIỂM KÊ
   ========================= */

CREATE TABLE P_KK (
    so_pkk                  VARCHAR(10)    NOT NULL PRIMARY KEY,
    ma_ncc                  VARCHAR(10)    NOT NULL,
    ngaykiemke              DATE           NOT NULL,
    thoigiankiemke          TIME(0)        NOT NULL,
    nguoithuchienkiemke     NVARCHAR(50)   NOT NULL,
    nguoigiamsat            NVARCHAR(50)   NULL,
    tennd                   NVARCHAR(50)   NOT NULL,
    ma_nd                   VARCHAR(10)    NOT NULL,

    CONSTRAINT FK_P_KK_NCC
        FOREIGN KEY (ma_ncc) REFERENCES NCC(ma_ncc),

    CONSTRAINT FK_P_KK_NGUOIDUNG
        FOREIGN KEY (ma_nd) REFERENCES NGUOIDUNG(ma_nd)
);

CREATE TABLE C_T_PKK (
    so_pkk                 VARCHAR(10)     NOT NULL,
    ma_nl                  VARCHAR(10)     NOT NULL,
    soluongtheokiemke      INT             NOT NULL,
    soluongthucte          INT             NOT NULL,
    chenhlech              INT             NOT NULL,
    hansudung              DATE            NULL,
    tinhtrangchatluong     NVARCHAR(50)    NULL,
    ghichu                 NVARCHAR(200)   NULL,

    CONSTRAINT PK_C_T_PKK PRIMARY KEY (so_pkk, ma_nl),

    CONSTRAINT FK_C_T_PKK_P_KK
        FOREIGN KEY (so_pkk) REFERENCES P_KK(so_pkk),

    CONSTRAINT FK_C_T_PKK_NL
        FOREIGN KEY (ma_nl) REFERENCES NL(ma_nl),

    CONSTRAINT CK_C_T_PKK_SOLUONG_HE_THONG
        CHECK (soluongtheokiemke >= 0),

    CONSTRAINT CK_C_T_PKK_SOLUONG_THUC_TE
        CHECK (soluongthucte >= 0)
);


/* =========================
   8. SAO LƯU, LỊCH SỬ, NHẬT KÝ
   ========================= */

CREATE TABLE SAOLUUDULIEU (
    ma_saoluu        VARCHAR(10)     NOT NULL PRIMARY KEY,
    thoigiansaoluu   DATETIME2(0)    NOT NULL,
    tenfile          NVARCHAR(100)   NOT NULL,
    duongdanfile     NVARCHAR(200)   NOT NULL,
    trangthai        BIT             NOT NULL DEFAULT 1,
    ghichu           NVARCHAR(200)   NULL,
    ma_nd            VARCHAR(10)     NOT NULL,

    CONSTRAINT FK_SAOLUUDULIEU_NGUOIDUNG
        FOREIGN KEY (ma_nd) REFERENCES NGUOIDUNG(ma_nd)
);

/*
   Trong bảng B15.NHATKYHOATDONG của tài liệu có ma_ls tham chiếu LICHSUTRUYCAP,
   nhưng mục 3.3.4 không đặc tả riêng bảng LICHSUTRUYCAP.
   Vì vậy tạo thêm bảng tối thiểu để khóa ngoại của NHATKYHOATDONG chạy được.
*/

CREATE TABLE LICHSUTRUYCAP (
    ma_ls              VARCHAR(10)    NOT NULL PRIMARY KEY,
    ma_nd              VARCHAR(10)    NOT NULL,
    thoigiandangnhap   DATETIME2(0)   NOT NULL DEFAULT SYSDATETIME(),
    thoigiandangxuat   DATETIME2(0)   NULL,
    trangthai          NVARCHAR(50)   NULL,

    CONSTRAINT FK_LICHSUTRUYCAP_NGUOIDUNG
        FOREIGN KEY (ma_nd) REFERENCES NGUOIDUNG(ma_nd)
);

CREATE TABLE NHATKYHOATDONG (
    ma_nk       VARCHAR(10)     NOT NULL PRIMARY KEY,
    thoigian    DATETIME2(0)    NOT NULL,
    noidung     NVARCHAR(200)   NOT NULL,
    ttcu        NVARCHAR(200)   NULL,
    ttmoi       NVARCHAR(200)   NULL,
    ma_ls       VARCHAR(10)     NOT NULL,

    CONSTRAINT FK_NHATKYHOATDONG_LICHSUTRUYCAP
        FOREIGN KEY (ma_ls) REFERENCES LICHSUTRUYCAP(ma_ls)
);
GO