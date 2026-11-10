-- 1. Tạo CSDL KaraokeDB
CREATE DATABASE KaraokeDB;
GO
USE KaraokeDB;
GO

-- 2. Tạo bảng PhongHat
CREATE TABLE PhongHat (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(50) NOT NULL,
    LoaiPhong NVARCHAR(30),
    GiaTheoGio DECIMAL(18,2),
    TrangThai NVARCHAR(20) DEFAULT N'Trống'
);
GO

-- 3. Tạo bảng DichVu
CREATE TABLE DichVu (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2),
    TonKho INT CHECK (TonKho >= 0)
);
GO

-- 4. Tạo bảng HoaDon
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong INT FOREIGN KEY REFERENCES PhongHat(MaPhong) ON DELETE CASCADE,
    GioVao DATETIME NOT NULL,
    GioRa DATETIME NULL,
    TongTienPhong DECIMAL(18,2) DEFAULT 0,
    TongTienDichVu DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);
GO

-- 5. Tạo bảng ChiTietDichVu
CREATE TABLE ChiTietDichVu (
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV) ON DELETE CASCADE,
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2),
    PRIMARY KEY (MaHD, MaDV)
);
GO

-- =============================================
-- DỮ LIỆU MẪU (TESTING DATA)
-- =============================================

INSERT INTO PhongHat (TenPhong, LoaiPhong, GiaTheoGio, TrangThai) VALUES
(N'Phòng Thường 01', N'Thường', 100000, N'Trống'),
(N'Phòng Thường 02', N'Thường', 100000, N'Trống'),
(N'Phòng Thường 03', N'Thường', 100000, N'Trống'),
(N'Phòng VIP 01', N'VIP', 200000, N'Trống'),
(N'Phòng VIP 02', N'VIP', 200000, N'Trống'),
(N'Phòng VIP Super 03', N'VIP', 300000, N'Trống');

INSERT INTO DichVu (TenDV, DonGia, TonKho) VALUES
(N'Bia Heineken (Lon)', 25000, 100),
(N'Bia Tiger (Lon)', 22000, 120),
(N'Nước ngọt Cocacola', 15000, 80),
(N'Trái cây dĩa lớn', 150000, 20),
(N'Mực khô nướng', 180000, 15),
(N'Khăn lạnh', 5000, 300);