USE [master]
GO
/****** Object:  Database [WebTapHoa]    Script Date: 10/19/2014 11:21:03 PM ******/
CREATE DATABASE [WebTapHoa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebTapHoa', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.TRUNGDUC2\MSSQL\DATA\WebTapHoa.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebTapHoa_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.TRUNGDUC2\MSSQL\DATA\WebTapHoa_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WebTapHoa] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebTapHoa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebTapHoa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebTapHoa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebTapHoa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebTapHoa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebTapHoa] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebTapHoa] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [WebTapHoa] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WebTapHoa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebTapHoa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebTapHoa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebTapHoa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebTapHoa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebTapHoa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebTapHoa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebTapHoa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebTapHoa] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WebTapHoa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebTapHoa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebTapHoa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebTapHoa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebTapHoa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebTapHoa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebTapHoa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebTapHoa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebTapHoa] SET  MULTI_USER 
GO
ALTER DATABASE [WebTapHoa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebTapHoa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebTapHoa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebTapHoa] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [WebTapHoa]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[ID] [int] NOT NULL,
	[IDSanPham] [nvarchar](5) NOT NULL,
	[ThuTuShow] [int] NULL,
	[MoTa] [nchar](10) NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[SanPhamID] [nvarchar](5) NOT NULL,
	[HoaDonID] [int] NOT NULL,
	[SoLuongMua] [int] NOT NULL,
	[Gia] [float] NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
 CONSTRAINT [PK_CtHoaDon] PRIMARY KEY CLUSTERED 
(
	[SanPhamID] ASC,
	[HoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[DanhMucID] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](200) NOT NULL,
	[NhaCungCapID] [int] NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[DanhMucID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucAnh]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucAnh](
	[DanhMucAnhID] [int] IDENTITY(1,1) NOT NULL,
	[SanPhamID] [nvarchar](5) NOT NULL,
	[TenAnh] [nvarchar](100) NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
 CONSTRAINT [PK_DmAnh] PRIMARY KEY CLUSTERED 
(
	[DanhMucAnhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucTin]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucTin](
	[Id] [int] NOT NULL,
	[TenDMTin] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](500) NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_DanhMucTin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[DichVuID] [int] IDENTITY(1,1) NOT NULL,
	[NgayDang] [date] NOT NULL,
	[NguoiDang] [nvarchar](100) NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
	[TenDichVu] [nvarchar](200) NOT NULL,
	[MieuTaNgan] [nvarchar](500) NULL,
	[MieuTaChiTiet] [nvarchar](max) NULL,
	[AnhDaiDien] [nchar](100) NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[DichVuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DoiTac]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoiTac](
	[DoiTacID] [int] IDENTITY(1,1) NOT NULL,
	[TenDoiTac] [nvarchar](200) NOT NULL,
	[NgayCapNhat] [date] NOT NULL,
	[NoiDung] [nvarchar](max) NOT NULL,
	[MieuTaNgan] [nvarchar](500) NOT NULL,
	[NguoiDang] [nvarchar](100) NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
 CONSTRAINT [PK_DoiTac] PRIMARY KEY CLUSTERED 
(
	[DoiTacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[HoaDonID] [int] IDENTITY(1,1) NOT NULL,
	[NgayMua] [date] NOT NULL,
	[TaiKhoanID] [int] NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[HoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[LoaiSpID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSp] [nvarchar](200) NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
	[DanhMucID] [int] NOT NULL,
 CONSTRAINT [PK_LoaiSp] PRIMARY KEY CLUSTERED 
(
	[LoaiSpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiTaiKhoan]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTaiKhoan](
	[LoaiTaiKhoanID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
 CONSTRAINT [PK_LoaiTk] PRIMARY KEY CLUSTERED 
(
	[LoaiTaiKhoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[NhaCungCapID] [int] IDENTITY(1,1) NOT NULL,
	[TenNcc] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
 CONSTRAINT [PK_Ncc] PRIMARY KEY CLUSTERED 
(
	[NhaCungCapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[SanPhamID] [nvarchar](5) NOT NULL,
	[TenSp] [nvarchar](200) NOT NULL,
	[LoaiSpID] [int] NOT NULL,
	[AnhDaiDien] [nvarchar](200) NOT NULL,
	[Gia] [money] NOT NULL,
	[TrangThai] [nvarchar](20) NOT NULL,
	[Model] [nvarchar](10) NOT NULL,
	[MieuTaNgan] [nvarchar](500) NOT NULL,
	[MieuTaChiTiet] [nvarchar](max) NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
	[SoLuong] [int] NULL,
	[NgayCapNhat] [date] NULL,
	[LuotView] [float] NULL,
	[LuotBan] [float] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoanID] [int] IDENTITY(1,1) NOT NULL,
	[LoaiTaiKhoanID] [int] NOT NULL,
	[TenNguoiDung] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[TenDangNhap] [nvarchar](100) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[TrangThaiXoa] [bit] NOT NULL,
	[NgayXoa] [date] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThongTinCongTy]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinCongTy](
	[CongTyID] [int] IDENTITY(1,1) NOT NULL,
	[TenCongTy] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CongTy] PRIMARY KEY CLUSTERED 
(
	[CongTyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TinTuc]    Script Date: 10/19/2014 11:21:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinTuc](
	[Id] [int] NOT NULL,
	[LoaiDMTin] [int] NOT NULL,
	[TenTin] [nvarchar](100) NOT NULL,
	[MieuTaNgan] [nvarchar](500) NULL,
	[MieuTaChiTiet] [nvarchar](max) NULL,
	[TrangThai] [bit] NOT NULL,
	[NgayXoaTin] [date] NULL,
	[NgayCapNhat] [date] NOT NULL,
	[NguoiDang] [nvarchar](50) NULL,
	[AnhDaiDien] [nchar](200) NULL,
 CONSTRAINT [PK_TinTuc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([DanhMucID], [TenDanhMuc], [NhaCungCapID], [TrangThaiXoa], [NgayXoa]) VALUES (1, N'Trống rượu', 1, 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMuc] ([DanhMucID], [TenDanhMuc], [NhaCungCapID], [TrangThaiXoa], [NgayXoa]) VALUES (2, N'Quần áo', 2, 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMuc] ([DanhMucID], [TenDanhMuc], [NhaCungCapID], [TrangThaiXoa], [NgayXoa]) VALUES (3, N'Sữa', 3, 0, CAST(0x0C380B00 AS Date))
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
SET IDENTITY_INSERT [dbo].[DanhMucAnh] ON 

INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (1, N'TR001', N'tu-ruou/tu-ruou-dep-01-128x128.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (2, N'TR001', N'tu-ruou/tu-ruou-dep-01-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (3, N'TR002', N'tu-ruou/tu-ruou-dep-02-128x128.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (4, N'TR002', N'tu-ruou/tu-ruou-dep-02-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (5, N'TR003', N'tu-ruou/tu-ruou-dep-03-128x128.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (6, N'TR003', N'tu-ruou/tu-ruou-dep-03-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (7, N'TR004', N'tu-ruou/tu-ruou-dep-04-128x128.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (8, N'TR004', N'tu-ruou/tu-ruou-dep-04-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (9, N'TR005', N'tu-ruou/tu-ruou-dep-05-128x128.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (10, N'TR005', N'tu-ruou/tu-ruou-dep-05-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (11, N'BR001', N'Quay_bar/quay bar tu bep 01-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (12, N'BR001', N'Quay_bar/quay bar tu bep 02-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (13, N'BR001', N'Quay_bar/quay bar tu bep 03-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (14, N'BR002', N'Quay_bar/quay bar tu bep 02-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[DanhMucAnh] ([DanhMucAnhID], [SanPhamID], [TenAnh], [TrangThaiXoa], [NgayXoa]) VALUES (15, N'BR002', N'Quay_bar/quay bar tu bep 03-150x150.jpg', 0, CAST(0x0C380B00 AS Date))
SET IDENTITY_INSERT [dbo].[DanhMucAnh] OFF
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (1, N'Tủ rượu', 0, CAST(0x0C380B00 AS Date), 1)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (2, N'Quầy bar', 0, CAST(0x0C380B00 AS Date), 1)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (3, N'Trống rượu', 0, CAST(0x0C380B00 AS Date), 1)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (4, N'Quần jeam nam', 0, CAST(0x0C380B00 AS Date), 2)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (5, N'Quần jeam nữ', 0, CAST(0x0C380B00 AS Date), 2)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (6, N'Quần dài nam', 0, CAST(0x0C380B00 AS Date), 2)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (7, N'Quần dài nữ', 0, CAST(0x0C380B00 AS Date), 2)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (8, N'Sữa Alpha Mama', 0, CAST(0x0C380B00 AS Date), 3)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (9, N'Sữa cô gái Hà Lan', 0, CAST(0x0C380B00 AS Date), 3)
INSERT [dbo].[LoaiSanPham] ([LoaiSpID], [TenLoaiSp], [TrangThaiXoa], [NgayXoa], [DanhMucID]) VALUES (10, N'Sữa Vinamilk', 0, CAST(0x0C380B00 AS Date), 3)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([NhaCungCapID], [TenNcc], [Phone], [DiaChi], [TrangThaiXoa], [NgayXoa]) VALUES (1, N'Nhà cung cấp 1', N'041523611', N'Mai Dịch, Cầu Giấy, Hà Nội', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[NhaCungCap] ([NhaCungCapID], [TenNcc], [Phone], [DiaChi], [TrangThaiXoa], [NgayXoa]) VALUES (2, N'Nhà cung cấp 2', N'041523611', N'Mai Dịch, Cầu Giấy, Hà Nội', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[NhaCungCap] ([NhaCungCapID], [TenNcc], [Phone], [DiaChi], [TrangThaiXoa], [NgayXoa]) VALUES (3, N'Nhà cung cấp 3', N'041523611', N'Mai Dịch, Cầu Giấy, Hà Nội', 0, CAST(0x0C380B00 AS Date))
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR001', N'Quầy bar tủ bếp 1', 2, N'Quay_bar/quay bar tu bep 01-150x150.jpg', 5000000.0000, N'Còn hàng', N'B001', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x0F380B00 AS Date), 44, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR002', N'Quầy bar tủ bếp 2', 2, N'Quay_bar/quay bar tu bep 02-150x150.jpg', 4000000.0000, N'Còn hàng', N'B002', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', 0, CAST(0x0C380B00 AS Date), 1, CAST(0x0F380B00 AS Date), 11, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR003', N'Quầy bar tủ bếp 3', 2, N'Quay_bar/quay bar tu bep 03-150x150.jpg', 4000000.0000, N'Còn hàng', N'B003', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', 0, CAST(0x0C380B00 AS Date), 1, CAST(0x0F380B00 AS Date), 4, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR004', N'Quầy bar tủ bếp 4', 2, N'Quay_bar/quay bar tu bep 04-150x150.jpg', 2000000.0000, N'Còn hàng', N'T003', N'A', N'A', 0, CAST(0x0C380B00 AS Date), 12, CAST(0x0F380B00 AS Date), 7, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR005', N'Quầy bar tủ bếp 5', 2, N'Quay_bar/thiet ke quay bar tu bep dep 2-150x150.jpg', 2000000.0000, N'Còn hàng', N'T003', N'A', N'A', 0, CAST(0x0C380B00 AS Date), 20, CAST(0x0F380B00 AS Date), 5556, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR001', N'Tủ rượu 1', 1, N'tu-ruou/tu-ruou-dep-01-128x128.jpg', 1200000.0000, N'Còn hàng', N'T001', N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng', N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng', 0, CAST(0x0C380B00 AS Date), 10, CAST(0x0F380B00 AS Date), 561, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR002', N'Tủ rượu 2', 1, N'tu-ruou/tu-ruou-dep-02-128x128.jpg', 1500000.0000, N'Còn hàng', N'T002', N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng', N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x0F380B00 AS Date), 558, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR003', N'Tủ rượu 3', 1, N'tu-ruou/tu-ruou-dep-03-128x128.jpg', 2000000.0000, N'Còn hàng', N'T003', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x0F380B00 AS Date), 59, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR004', N'Tủ rượu 4', 1, N'tu-ruou/tu-ruou-dep-04-128x128.jpg', 1000000.0000, N'Còn hàng', N'T003', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x0F380B00 AS Date), 5557, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR005', N'Tủ rượu 5', 1, N'tu-ruou/tu-ruou-dep-05-128x128.jpg', 3000000.0000, N'Còn hàng', N'T003', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x0F380B00 AS Date), 56, 2)
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  CONSTRAINT [DF__ChiTietHo__Trang__34C8D9D1]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[DanhMuc] ADD  CONSTRAINT [DF__DanhMuc__TrangTh__1367E606]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[DanhMucAnh] ADD  CONSTRAINT [DF__DanhMucAn__Trang__1ED998B2]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[DichVu] ADD  CONSTRAINT [DF__DichVu__TrangTha__2C3393D0]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[DoiTac] ADD  CONSTRAINT [DF__DoiTac__TrangTha__22AA2996]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [DF__HoaDon__TrangTha__30F848ED]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[LoaiSanPham] ADD  CONSTRAINT [DF__LoaiSanPh__Trang__173876EA]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[LoaiTaiKhoan] ADD  CONSTRAINT [DF__LoaiTaiKh__Trang__25869641]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [DF__NhaCungCa__Trang__108B795B]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF__SanPham__TrangTh__1B0907CE]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [DF__TaiKhoan__TrangT__286302EC]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CtHoaDon_HoaDon] FOREIGN KEY([HoaDonID])
REFERENCES [dbo].[HoaDon] ([HoaDonID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_CtHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CtHoaDon_SamPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([SanPhamID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_CtHoaDon_SamPham]
GO
ALTER TABLE [dbo].[DanhMuc]  WITH CHECK ADD  CONSTRAINT [FK_DanhMuc_NhaCc] FOREIGN KEY([DanhMucID])
REFERENCES [dbo].[NhaCungCap] ([NhaCungCapID])
GO
ALTER TABLE [dbo].[DanhMuc] CHECK CONSTRAINT [FK_DanhMuc_NhaCc]
GO
ALTER TABLE [dbo].[DanhMucAnh]  WITH CHECK ADD  CONSTRAINT [FK_DmAnh_SanPham] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([SanPhamID])
GO
ALTER TABLE [dbo].[DanhMucAnh] CHECK CONSTRAINT [FK_DmAnh_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_TaiKhoan] FOREIGN KEY([TaiKhoanID])
REFERENCES [dbo].[TaiKhoan] ([TaiKhoanID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_TaiKhoan]
GO
ALTER TABLE [dbo].[LoaiSanPham]  WITH CHECK ADD  CONSTRAINT [FK_LoaiSp_DanhMuc] FOREIGN KEY([DanhMucID])
REFERENCES [dbo].[DanhMuc] ([DanhMucID])
GO
ALTER TABLE [dbo].[LoaiSanPham] CHECK CONSTRAINT [FK_LoaiSp_DanhMuc]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSp] FOREIGN KEY([LoaiSpID])
REFERENCES [dbo].[LoaiSanPham] ([LoaiSpID])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSp]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_LoaiTk] FOREIGN KEY([LoaiTaiKhoanID])
REFERENCES [dbo].[LoaiTaiKhoan] ([LoaiTaiKhoanID])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_LoaiTk]
GO
ALTER TABLE [dbo].[TinTuc]  WITH CHECK ADD  CONSTRAINT [FK_TinTuc_DanhMucTin] FOREIGN KEY([LoaiDMTin])
REFERENCES [dbo].[DanhMucTin] ([Id])
GO
ALTER TABLE [dbo].[TinTuc] CHECK CONSTRAINT [FK_TinTuc_DanhMucTin]
GO
USE [master]
GO
ALTER DATABASE [WebTapHoa] SET  READ_WRITE 
GO
