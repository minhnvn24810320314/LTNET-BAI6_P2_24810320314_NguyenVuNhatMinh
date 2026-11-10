CREATE DATABASE ProjectTaskDB;
GO
USE ProjectTaskDB;
GO

-- 1. Bảng DuAn
CREATE TABLE DuAn (
    MaDuAn INT IDENTITY(1,1) PRIMARY KEY,
    TenDuAn NVARCHAR(150) NOT NULL,
    NgayBatDau DATETIME,
    NgayKetThuc DATETIME,
    TrangThai NVARCHAR(50) DEFAULT N'Đang chạy' -- 'Đang chạy', 'Hoàn thành', 'Tạm dừng'
);
GO

-- 2. Bảng ThanhVien
CREATE TABLE ThanhVien (
    MaThanhVien INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    ChuyenMon NVARCHAR(100)
);
GO

-- 3. Bảng CongViec
CREATE TABLE CongViec (
    MaTask INT IDENTITY(1,1) PRIMARY KEY,
    MaDuAn INT FOREIGN KEY REFERENCES DuAn(MaDuAn) ON DELETE CASCADE,
    TenTask NVARCHAR(200) NOT NULL,
    MoTa NVARCHAR(MAX),
    HanNop DATETIME,
    DoUuTien NVARCHAR(20) DEFAULT N'Trung bình', -- 'Cao', 'Trung bình', 'Thấp'
    TrangThai NVARCHAR(50) DEFAULT N'To Do'     -- 'To Do', 'In Progress', 'Review', 'Done'
);
GO

-- 4. Bảng PhanCong
CREATE TABLE PhanCong (
    MaTask INT FOREIGN KEY REFERENCES CongViec(MaTask) ON DELETE CASCADE,
    MaThanhVien INT FOREIGN KEY REFERENCES ThanhVien(MaThanhVien) ON DELETE CASCADE,
    NgayGiao DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MaTask, MaThanhVien)
);
GO

-- DỮ LIỆU MẪU (TESTING DATA)
INSERT INTO DuAn (TenDuAn, NgayBatDau, NgayKetThuc, TrangThai) VALUES
(N'Xây dựng Website E-Commerce', '2026-11-01', '2026-12-30', N'Đang chạy'),
(N'Phần mềm Quản lý Nhân sự', '2026-10-01', '2026-11-15', N'Đang chạy');

INSERT INTO ThanhVien (HoTen, Email, ChuyenMon) VALUES
(N'Nguyễn Vũ Nhật Minh', 'minhnv@gmail.com', N'Backend Developer'),
(N'Trần Thị Hoa', 'hoatt@gmail.com', N'Frontend Developer'),
(N'Lê Hoàng Nam', 'namlh@gmail.com', N'Tester');

INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai) VALUES
(1, N'Thiết kế CSDL SQL Server', N'Tạo các bảng và khóa ngoại', '2026-11-05', N'Cao', N'Done'),
(1, N'Lập trình API Đăng nhập', N'Viết JWT Authentication', '2026-11-08', N'Cao', N'In Progress'), -- Quá hạn (Cảnh báo Overdue)
(1, N'Thiết kế Giao diện Homepage', N'Dùng ReactJS/HTML5', '2026-11-20', N'Trung bình', N'To Do'),
(2, N'Kiểm thử mô hình Disconnected', N'Test SqlDataAdapter', '2026-11-12', N'Thấp', N'To Do');

INSERT INTO PhanCong (MaTask, MaThanhVien) VALUES 
(1, 1), 
(2, 1), 
(2, 2), 
(3, 2), 
(4, 3);