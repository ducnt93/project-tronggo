-- =============================================
-- Create database template
-- =============================================
USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'WebTapHoa'
)
DROP DATABASE WebTapHoa
GO

CREATE DATABASE WebTapHoa
GO


use WebTapHoa
go

Create table DanhMucAnh
(
	DanhMucAnhID int identity(1,1),
	TenAnh nvarchar(100) not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_DmAnh primary key(DanhMucAnhID)
)
go

Create table NhaCungCap
(
	NhaCungCapID int identity(1,1),
	TenNcc nvarchar(200) not null,
	Phone nvarchar(20) not null,
	DiaChi nvarchar(200) not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_Ncc Primary key(NhaCungCapID)
)
go

Create table DanhMuc
(
	DanhMucID int identity(1,1), 
	TenDanhMuc nvarchar(200) not null,
	NhaCungCapID int not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_DanhMuc Primary key(DanhMucID),
	constraint FK_DanhMuc_NhaCc foreign key(DanhMucID) references NhaCungCap(NhaCungCapID)
)
go

Create table LoaiSanPham
(
	LoaiSpID int identity(1,1),
	TenLoaiSp nvarchar(200) not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	DanhMucID int not null,
	constraint PK_LoaiSp primary key(LoaiSpID),
	constraint FK_LoaiSp_DanhMuc foreign key(DanhMucID) references DanhMuc(DanhMucID)
)
go

Create table SanPham
(
	SanPhamID nvarchar(5),
	TenSp nvarchar(200) not null,
	LoaiSpID int not null,
	AnhDaiDien nvarchar(200) not null,
	Gia float not null,
	TrangThai nvarchar(20) not null,	
	Model nvarchar(10) not null,
	DanhMucAnhID int not null,
	MieuTaNgan nvarchar(500) not null,
	MieuTaChiTiet nvarchar(max) not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	SoLuong int,
	constraint PK_SanPham PRIMARY KEY(SanPhamID),
	constraint FK_SanPham_LoaiSp foreign key (LoaiSpID) references LoaiSanPham(LoaiSpID),
	constraint FK_SanPham_DanhMucAnh foreign key (DanhMucAnhID) references DanhMucAnh(DanhMucAnhID)
)
go
 
Create table DoiTac
(
	DoiTacID int identity(1,1),
	TenDoiTac nvarchar(200)not null,
	NgayCapNhat date not null,
	NoiDung nvarchar(max) not null,
	MieuTaNgan nvarchar(500) not null,
	NguoiDang nvarchar(100) not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_DoiTac primary key (DoiTacID)
)
go

Create table LoaiTaiKhoan
(
	LoaiTaiKhoanID int identity(1,1),
	TenLoai nvarchar(100)not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_LoaiTk primary key (LoaiTaiKhoanID) 
)
go

Create table TaiKhoan
(
	TaiKhoanID int identity(1,1),
	LoaiTaiKhoanID int not null,
	TenNguoiDung nvarchar(100) not null,
	Email nvarchar(200) not null,
	TenDangNhap nvarchar(100) not null,
	MatKhau nvarchar(100) not null,
	Phone nvarchar(20) not null,
	DiaChi nvarchar(200) not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_TaiKhoan primary key(TaiKhoanID),
	constraint FK_TaiKhoan_LoaiTk foreign key (LoaiTaiKhoanID) references LoaiTaiKhoan(LoaiTaiKhoanID) 
)
go

Create table DichVu
(
	DichVuID int identity(1,1),
	NgayDang date not null,
	NguoiDang nvarchar(100) not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_DichVu primary key(DichVuID)		
)
go

Create table ThongTinCongTy
(
	CongTyID int identity(1,1),
	TenCongTy nvarchar(100) not null,
	DiaChi nvarchar(200) not null,
	Phone nvarchar(20) not null,
	Email nvarchar(100) not null,
	constraint PK_CongTy primary key (CongTyID)
)
go

Create table HoaDon
(
	HoaDonID int identity(1,1),
	NgayMua date not null,
	TaiKhoanID int not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_HoaDon primary key (HoaDonID),
	constraint FK_HoaDon_TaiKhoan foreign key (TaiKhoanID)references TaiKhoan(TaiKhoanID) 
)
go

Create table ChiTietHoaDon
(
	SanPhamID nvarchar(5) not null,
	HoaDonID int not null,
	SoLuongMua int not null,
	Gia float not null,
	TrangThaiXoa bit not null default 0,
	NgayXoa date not null,
	constraint PK_CtHoaDon primary key(SanPhamID, HoaDonID),
	constraint FK_CtHoaDon_HoaDon foreign key (HoaDonID) references HoaDon(HoaDonID),
	constraint FK_CtHoaDon_SamPham foreign key (SanPhamID) references SanPham(SanPhamID)
)
go