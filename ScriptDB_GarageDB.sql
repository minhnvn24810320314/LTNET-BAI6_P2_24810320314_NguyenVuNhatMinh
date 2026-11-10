-- 1. Tạo CSDL GarageDB
CREATE DATABASE GarageDB;
GO
USE GarageDB;
GO

-- 2. Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(200)
);
GO

-- 3. Tạo bảng Xe
CREATE TABLE Xe (
    BienSo VARCHAR(20) PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH) ON DELETE CASCADE,
    HieuXe NVARCHAR(50),
    NamSanXuat INT
);
GO

-- 4. Tạo bảng PhuTung
CREATE TABLE PhuTung (
    MaPhuTung INT IDENTITY(1,1) PRIMARY KEY,
    TenPhuTung NVARCHAR(150) NOT NULL,
    DonGia DECIMAL(18,2),
    SoLuongTon INT CHECK (SoLuongTon >= 0)
);
GO

-- 5. Tạo bảng PhieuSuaChua
CREATE TABLE PhieuSuaChua (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    BienSo VARCHAR(20) FOREIGN KEY REFERENCES Xe(BienSo) ON DELETE CASCADE,
    NgayNhan DATETIME DEFAULT GETDATE(),
    NoiDungSua NVARCHAR(MAX),
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai NVARCHAR(30) DEFAULT N'Đang sửa'
);
GO

-- 6. Tạo bảng ChiTietSuaChua
CREATE TABLE ChiTietSuaChua (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuSuaChua(MaPhieu) ON DELETE CASCADE,
    MaPhuTung INT FOREIGN KEY REFERENCES PhuTung(MaPhuTung) ON DELETE CASCADE,
    SoLuong INT CHECK (SoLuong > 0),
    TienCong DECIMAL(18,2) DEFAULT 0,
    PRIMARY KEY (MaPhieu, MaPhuTung)
);
GO

-- =============================================
-- DỮ LIỆU MẪU (TESTING DATA)
-- =============================================

INSERT INTO KhachHang (TenKH, DienThoai, DiaChi) VALUES
(N'Nguyễn Văn An', '0905123456', N'123 Lê Lợi, Đà Nẵng'),
(N'Trần Thị Bích', '0914987654', N'456 Hải Phòng, Đà Nẵng');

INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat) VALUES
('43A-123.45', 1, N'Toyota', 2020),
('43B-999.99', 2, N'VinFast', 2022);

INSERT INTO PhuTung (TenPhuTung, DonGia, SoLuongTon) VALUES
(N'Lọc nhớt Toyota', 150000, 20),
(N'Dầu nhớt Castrol 4L', 450000, 15),
(N'Bugi Iridium', 120000, 30),
(N'Má phanh trước VinFast', 850000, 5);