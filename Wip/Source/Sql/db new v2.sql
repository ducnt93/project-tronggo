USE [master]
GO
/****** Object:  Database [WebTapHoa]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[Banner]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[DanhMucAnh]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[DanhMucTin]    Script Date: 10/21/2014 8:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucTin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDMTin] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](500) NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_DanhMucTin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[DoiTac]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[LoaiTaiKhoan]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[ThongTinCongTy]    Script Date: 10/21/2014 8:02:49 PM ******/
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
/****** Object:  Table [dbo].[TinTuc]    Script Date: 10/21/2014 8:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinTuc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
SET IDENTITY_INSERT [dbo].[DanhMucTin] ON 

INSERT [dbo].[DanhMucTin] ([Id], [TenDMTin], [MoTa], [TrangThai]) VALUES (1, N'Bom đựng rượu vang gỗ sồi', N'Chuyên bán các loại thùng đựng rươu, bom rượu vang gỗ rồi giá cả hợp lý. Liên hệ: 0983.244562', 1)
SET IDENTITY_INSERT [dbo].[DanhMucTin] OFF
SET IDENTITY_INSERT [dbo].[DichVu] ON 

INSERT [dbo].[DichVu] ([DichVuID], [NgayDang], [NguoiDang], [TrangThaiXoa], [NgayXoa], [TenDichVu], [MieuTaNgan], [MieuTaChiTiet], [AnhDaiDien]) VALUES (1, CAST(0x25390B00 AS Date), N'Nguyễn Trung Đức', 0, NULL, N'Làng nghề làm trống', N'Cách Thủ Đô Hà Nội 45km hướng xuôi theo quốc lộ 1A cũ về với tỉnh Hà Nam, mảnh đất được mệnh danh là mảnh đất của những người mẹ anh hung bất khuất. Nơi đây có rất nhiều làng nghề truyền thống có sự hình thành và phát triển từ rất lâu đời, nhưng nếu ai trong chúng ta đã nhắc tới tỉnh Hà Nam, là sẽ nhắc ngay tới làng nghề truyền thống làm trống Đọi Tam, làng nghề có sức sống trên 1.000 năm lịch sử.', N' <div class="middle">
   <p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify; text-indent: 36pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;">C&aacute;ch Thủ Đ&ocirc; H&agrave; Nội 45km hướng xu&ocirc;i theo quốc lộ 1A cũ về với tỉnh H&agrave; Nam, mảnh đất được mệnh danh l&agrave; mảnh đất của những người mẹ anh hung bất khuất. Nơi đ&acirc;y c&oacute; rất nhiều l&agrave;ng nghề truyền thống c&oacute; sự h&igrave;nh th&agrave;nh v&agrave; ph&aacute;t triển từ rất l&acirc;u đời, nhưng nếu ai trong ch&uacute;ng ta đ&atilde; nhắc tới tỉnh H&agrave; Nam, l&agrave; sẽ nhắc ngay tới l&agrave;ng nghề truyền thống l&agrave;m trống <strong>Đọi Tam</strong>, l&agrave;ng nghề c&oacute; sức sống tr&ecirc;n 1.000 năm lịch sử.</span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify; text-indent: 36pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;">L&agrave;ng Trống Đọi Tam thuộc x&atilde; Đợi Sơn, huyện Duy Ti&ecirc;n, tỉnh H&agrave; Nam, l&agrave; l&agrave;ng nghề được được bao quanh bởi ngọn n&uacute;i Đọi Sơn. Với sự t&iacute;ch tương truyền rằng ở năm 986 được tin vua L&ecirc; Đại H&agrave;nh sửa soạn về l&agrave;ng c&agrave;y ruộng tịch điền khuyến n&ocirc;ng, hai anh em nh&agrave; nọ l&agrave; Nguyễn Đức Năng v&agrave; Nguyễn Đức Bản đ&atilde; tự tay l&agrave;m một c&aacute;i trống to để đ&oacute;n vua. Tiếng trống vang như sấm rền n&ecirc;n về sau hai &ocirc;ng được d&acirc;n l&agrave;ng t&ocirc;m l&agrave; Trạng Sấm, tổ nghề của l&agrave;ng trống.</span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify; text-indent: 36pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;">Nghề l&agrave;m trống ở <strong><a href="http://trongdoitam.net/">Đọi Tam</a></strong> l&agrave; nghề cha truyền con nối, l&agrave;m đủ c&aacute;c loại trống. Thợ trống l&agrave;ng&nbsp;<a href="http://trongdoitam.net/"><b><span style="color: blue;">Đọi Tam</span></b></a>&nbsp;l&agrave;m đủ c&aacute;c loại trống, từ chiếc trống sấm lớn nhất Việt Nam đến những chiếc trống Trung thu của bọn trẻ con. Con trai trong l&agrave;ng khoảng 12, 13 tuổi được dạy l&agrave;m c&aacute;c loại trống nhỏ&hellip; đến 16, 17 tuổi th&igrave; theo cha, anh đi l&agrave;m trống đại. Trống sấm chỉ d&agrave;nh cho c&aacute;c đ&agrave;n &ocirc;ng khoẻ mạnh, c&oacute; kinh nghiệm v&agrave; kỹ thuật đi&ecirc;u luyện.</span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify; text-indent: 36pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;">Quy tr&igrave;nh để l&agrave;m được một chiếc trống phải trải qua ba bước l&agrave; l&agrave;m da mặt trống, l&agrave;m tang th&acirc;n trống v&agrave; bưng trống. Mỗi một quy tr&igrave;nh l&agrave;m đều c&oacute; c&aacute;ch thức thực hiện rất tỉ mỉ đ&ograve;i hỏi những nghệ nh&acirc;n phải rất kh&eacute;o trong từng đường tay của m&igrave;nh. </span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify; text-indent: 36pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;">T&acirc;m sự với B&aacute;c Khang, một nghệ nh&acirc;n của l&agrave;ng nghề chuy&ecirc;n l&agrave;m da tr&acirc;u bứng mặt trống được biết: &ldquo;Da l&agrave;m trống phải l&agrave; da tr&acirc;u c&aacute;i, được đem b&agrave;o hết lớp m&agrave;ng, sau đ&oacute; ng&acirc;m nước, khử m&ugrave;i, chống thối rồi phơi kh&ocirc; 3 nắng. Khi b&agrave;o da cũng phải ch&uacute; &yacute; kh&ocirc;ng để da qu&aacute; d&agrave;y v&igrave; tiếng trống sẽ bị b&igrave;, ngược lại nếu da mỏng th&igrave; trống sẽ mau thủng. Lớp da ngo&agrave;i được d&ugrave;ng&nbsp;<a href="http://www.trongdoitam.net/news/detail/lam-trong-boi-yeu-nghe/167.html"><b><span style="color: blue;">l&agrave;m trống</span></b></a>&nbsp;to, lớp da dưới d&ugrave;ng l&agrave;m trống nhỏ cho trẻ con&rdquo;. </span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify; text-indent: 36pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;">C&ograve;n đối với việc chọn gỗ l&agrave;m tang &nbsp;th&acirc;n trống th&igrave; chủ yếu l&agrave; gỗ m&iacute;t do loại gỗ n&agrave;y dẻo, mềm, kh&ocirc;ng bị cong v&ecirc;nh, nứt vỡ; hơn nữa &ldquo;gỗ m&iacute;t đ&aacute;nh &iacute;t k&ecirc;u nhiều&rdquo;. Gỗ được cắt th&agrave;nh nhiều kh&uacute;c sau đ&oacute; pha th&agrave;nh từng &ldquo;dăm&rdquo;. Tuỳ theo k&iacute;ch cỡ của trống mới định ra bao nhi&ecirc;u &ldquo;dăm&rdquo;, cũng như độ cong v&agrave; độ dẻo của dăm để khi kh&eacute;p với th&acirc;n trống vừa kh&iacute;t, kh&ocirc;ng c&oacute; kẽ hở. Để cho trống thật k&iacute;n, thợ l&agrave;m trống d&ugrave;ng sơn ta miết v&agrave;o c&aacute;c khe, cứ một lớp sơn lại c&oacute; một lớp vải m&agrave;n.</span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify; text-indent: 36pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;">Cuối c&ugrave;ng l&agrave; bưng trống. Da tr&acirc;u được qu&acirc;y tr&ograve;n căng hết cỡ tr&ecirc;n mặt trống, rồi đ&oacute;ng cố định v&agrave;o th&acirc;n trống bằng đinh chốt. Đinh chốt được l&agrave;m từ vầu hoặc tre gi&agrave;.</span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trống Đọi Tam</b>&nbsp;nổi tiếng nhờ độ bền, đẹp, tiếng no, tr&ograve;n&hellip; đ&oacute; l&agrave; nhờ b&iacute; quyết ri&ecirc;ng của l&agrave;ng c&ugrave;ng t&acirc;m huyết của người l&agrave;m trống. V&agrave; một điều thật đ&aacute;ng tự h&agrave;o khi chiếc trống sấm lớn nhất Việt Nam với đường k&iacute;nh 2,2 m, cao 2,8 m được ch&iacute;nh những nghệ nh&acirc;n ở l&agrave;ng l&agrave;m ra. Chiếc trống đ&atilde; được c&aacute;c nghệ sĩ biểu diễn v&agrave;o dịp mừng đại lễ 1000 Thăng Long&ndash; H&agrave; Nội.</span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt; text-align: justify;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ng&agrave;y nay, người d&acirc;n ở Đọi Tam vẫn ra sức bảo tồn nghề truyền thống của cha &ocirc;ng. Với nghề trống, kh&ocirc;ng chỉ đủ ăn nhiều gia đ&igrave;nh ở l&agrave;ng đ&atilde; l&agrave;m gi&agrave;u. V&agrave; người d&acirc;n Đọi Tam lu&ocirc;n tự h&agrave;o l&agrave; sống được bằng nghề tổ, giữ được nghề tổ v&agrave; truyền nghề cho con ch&aacute;u.</span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;"><b>Nguồn:&nbsp;</b><b><span style="color: red;"><a href="http://trongdoitam.vn/"><span style="color: blue;">www.trongdoitam.vn</span></a></span></b></span></span><span style="font-size: 14pt; font-family: &#039;Times New Roman&#039;, serif;"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt;">
	<span style="font-family:times new roman,times,serif;"><span style="font-size: 20px;"><strong><span style="color: maroon;">Doanh nghi&ecirc;̣p tư nh&acirc;n sản xu&acirc;́t Tr&ocirc;́ng G&ocirc;̃, Tr&ocirc;́ng Rượu - Tr&ocirc;́ng Ho&agrave;ng Gia</span></strong></span></span><span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt;">
	<em><span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;"><b><span style="color: black;">Chuy&ecirc;n sản xu&acirc;́t d&acirc;y chuy&ecirc;̀n</span></b><span style="color: black;">&nbsp;:<b>&nbsp;Tr&ocirc;́ng g&ocirc;̃ bom ch&acirc;n, tr&ocirc;́ng g&ocirc;̃, tr&ocirc;́ng g&ocirc;̃ đựng rượu, tr&ocirc;́ng g&ocirc;̃ rượu vang, bom ch&acirc;n, bom ruou vang, ....</b></span></span></span></em><span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt;">
	<span style="font-family:times new roman,times,serif;"><span style="font-size: 18px;"><span style="color: black;">Với đ&ocirc;̣i ngũ sản xu&acirc;́t 08 xưởng sản xu&acirc;́t bom rượu, tr&ocirc;́ng g&ocirc;̃ đựng rượu vang cao c&acirc;́p, sang trọng phong c&aacute;ch t&acirc;y &acirc;u tại t&acirc;y &acirc;u</span></span></span><span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt;">
	<span style="font-family:times new roman,times,serif;"><span style="font-size: 18px;"><span style="color: black;">Thị trường Vi&ecirc;̣t Nam &nbsp;v&agrave; c&aacute;c nước Ch&acirc;u &Aacute;, v&agrave; khu vực</span></span></span><span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt;">
	<span style="font-family:times new roman,times,serif;"><span style="font-size: 18px;"><span style="color: black;">- Năm ph&aacute;t tri&ecirc;̉n sản xu&acirc;́t 1989 - 2013 ( Qu&aacute; tr&igrave;nh 26 năm ).</span></span></span><span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black"><o:p></o:p></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt;">
	<span style="font-family:times new roman,times,serif;"><span style="font-size: 18px;"><span style="color: black;">- Nh&acirc;n c&ocirc;ng: 70-200 nh&acirc;n c&ocirc;ng sản xu&acirc;́t</span></span></span><span style="font-size:14.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black"><o:p></o:p></span></p>
<p>
	<span style="color:#008000;"><span style="font-family:arial,helvetica,sans-serif;"><span style="font-size:16px;"><strong>Add: P.801 - Chung Cư CTM 299 Cầu Giấy - H&agrave; Nội<br />
	</strong></span></span></span></p>
<p>
	<span style="color:#008000;"><span style="font-family:arial,helvetica,sans-serif;"><span style="font-size:16px;"><strong>Hotline: 0974.84.91.93 - Home: 04 66874066</strong></span></span></span></p>
<p>
	<span style="color:#008000;"><span style="font-family:arial,helvetica,sans-serif;"><span style="font-size:16px;"><strong>Email: cp.hoanggia82@gmail.com - contact@hoanggiagroup.vn<br />
	</strong></span></span></span></p>
<p class="MsoNormal" style="margin-bottom: 0.0001pt;">
	<span style="font-size:18px;"><span style="font-family: &#039;times new roman&#039;, times, serif;"><span style="color: black;">&nbsp;</span></span><u style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;">Từ kh&oacute;a t&igrave;m kiếm</u><span style="font-family: &#039;times new roman&#039;, times, serif;">&nbsp;:&nbsp;</span><a href="http://www.thunggo.com/Trong-ruou/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Trống rượu</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Thung-ruou/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Th&ugrave;ng rượu</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Trong-dung-ruou/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Trống đựng rượu</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Trong-go-bom-chan/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Trống gỗ bom ch&acirc;n</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;&nbsp;</span><a href="http://www.thunggo.com/Trong-ruou-xe-ngua/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue; text-decoration: none;">Trống rượu xe ngựa</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,</span><a href="http://www.thunggo.com/Ngua-keo-bom-ruou/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Ngựa k&eacute;o bom rượu</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Bom-ruou-vang-2013/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Bom rượu vang 2013</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Thung-ruou-go-soi/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Th&ugrave;ng rượu gỗ sồi</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;&nbsp;</span><a href="http://www.thunggo.com/Phu-kien-ruou/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Phụ kiện rượu</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Ruou-vang-bich/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Rượu vang bịch</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Ban-thung-ruou/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">B&agrave;n th&ugrave;ng rượu</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,</span><a href="http://www.thunggo.com/Trong-go-mit-moi/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Trống gỗ m&iacute;t mới</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Tu-ruou-dep/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Tủ rượu đẹp</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Trong-da/" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">Trống da</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Thung-ruou/375-Thung-ruou-vang.html" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">th&ugrave;ng rượu vang</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Thung-ruou-go-soi/376-Thung-go-dung-ruou-.html" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">th&ugrave;ng gỗ đựng rượu</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Trong-ruou/374-Trong-ruou-vang.html" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">trống rượu vang</span></a><span style="font-family: &#039;times new roman&#039;, times, serif;">,&nbsp;</span><a href="http://www.thunggo.com/Thung-ruou-go-soi/376-Thung-go-dung-ruou-.html" style="font-family: &#039;times new roman&#039;, times, serif; font-size: 16px;"><span style="color: blue;">bom rượu</span></a></span></p>
<p style="font-family: Arial, Helvetica, sans-serif; margin: 2px 0px; color: rgb(0, 0, 0); "></div>', N'Quay_bar/quay bar tu bep 03-150x150.jpg                                                             ')
SET IDENTITY_INSERT [dbo].[DichVu] OFF
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
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoan] ON 

INSERT [dbo].[LoaiTaiKhoan] ([LoaiTaiKhoanID], [TenLoai], [TrangThaiXoa], [NgayXoa]) VALUES (1, N'Admin', 0, NULL)
INSERT [dbo].[LoaiTaiKhoan] ([LoaiTaiKhoanID], [TenLoai], [TrangThaiXoa], [NgayXoa]) VALUES (2, N'User', 0, NULL)
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([NhaCungCapID], [TenNcc], [Phone], [DiaChi], [TrangThaiXoa], [NgayXoa]) VALUES (1, N'Nhà cung cấp 1', N'041523611', N'Mai Dịch, Cầu Giấy, Hà Nội', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[NhaCungCap] ([NhaCungCapID], [TenNcc], [Phone], [DiaChi], [TrangThaiXoa], [NgayXoa]) VALUES (2, N'Nhà cung cấp 2', N'041523611', N'Mai Dịch, Cầu Giấy, Hà Nội', 0, CAST(0x0C380B00 AS Date))
INSERT [dbo].[NhaCungCap] ([NhaCungCapID], [TenNcc], [Phone], [DiaChi], [TrangThaiXoa], [NgayXoa]) VALUES (3, N'Nhà cung cấp 3', N'041523611', N'Mai Dịch, Cầu Giấy, Hà Nội', 0, CAST(0x0C380B00 AS Date))
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR001', N'Quầy bar tủ bếp 1', 2, N'Quay_bar/quay bar tu bep 01-150x150.jpg', 5000000.0000, N'Còn hàng', N'B001', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x0F380B00 AS Date), 44, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR002', N'Quầy bar tủ bếp 2', 2, N'Quay_bar/quay bar tu bep 02-150x150.jpg', 4000000.0000, N'Còn hàng', N'B002', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', 0, CAST(0x0C380B00 AS Date), 1, CAST(0x01380B00 AS Date), 11, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR003', N'Quầy bar tủ bếp 3', 2, N'Quay_bar/quay bar tu bep 03-150x150.jpg', 4000000.0000, N'Còn hàng', N'B003', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', N'Mẫu quầy bar tủ bếp đẹp hiện đại, hợp lý cho bếp của bạn', 0, CAST(0x0C380B00 AS Date), 1, CAST(0x02380B00 AS Date), 4, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR004', N'Quầy bar tủ bếp 4', 2, N'Quay_bar/quay bar tu bep 04-150x150.jpg', 2000000.0000, N'Còn hàng', N'T003', N'A', N'A', 0, CAST(0x0C380B00 AS Date), 12, CAST(0x03380B00 AS Date), 7, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'BR005', N'Quầy bar tủ bếp 5', 2, N'Quay_bar/thiet ke quay bar tu bep dep 2-150x150.jpg', 2000000.0000, N'Còn hàng', N'T003', N'A', N'A', 0, CAST(0x0C380B00 AS Date), 20, CAST(0x05380B00 AS Date), 5556, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR001', N'Tủ rượu 1', 1, N'tu-ruou/tu-ruou-dep-01-128x128.jpg', 1200000.0000, N'Còn hàng', N'T001', N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng', N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng', 0, CAST(0x0C380B00 AS Date), 10, CAST(0x3F390B00 AS Date), 561, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR002', N'Tủ rượu 2', 1, N'tu-ruou/tu-ruou-dep-02-128x128.jpg', 1500000.0000, N'Còn hàng', N'T002', N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng', N'Mẫu tủ đẹp trang nhã, hợp lý cho phòng khách và văn phòng', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x31390B00 AS Date), 558, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR003', N'Tủ rượu 3', 1, N'tu-ruou/tu-ruou-dep-03-128x128.jpg', 2000000.0000, N'Còn hàng', N'T003', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x5D390B00 AS Date), 59, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR004', N'Tủ rượu 4', 1, N'tu-ruou/tu-ruou-dep-04-128x128.jpg', 1000000.0000, N'Còn hàng', N'T003', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x05380B00 AS Date), 5557, 2)
INSERT [dbo].[SanPham] ([SanPhamID], [TenSp], [LoaiSpID], [AnhDaiDien], [Gia], [TrangThai], [Model], [MieuTaNgan], [MieuTaChiTiet], [TrangThaiXoa], [NgayXoa], [SoLuong], [NgayCapNhat], [LuotView], [LuotBan]) VALUES (N'TR005', N'Tủ rượu 5', 1, N'tu-ruou/tu-ruou-dep-05-128x128.jpg', 3000000.0000, N'Còn hàng', N'T003', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', N'M?u t? d?p trang nhã, h?p lý cho phòng khách và van phòng', 0, CAST(0x0C380B00 AS Date), 2, CAST(0x44380B00 AS Date), 56, 2)
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([TaiKhoanID], [LoaiTaiKhoanID], [TenNguoiDung], [Email], [TenDangNhap], [MatKhau], [Phone], [DiaChi], [TrangThaiXoa], [NgayXoa]) VALUES (5, 2, N'Nguyễn Trung Đức', N'anhduc@gmail.com', N'ducnt', N'1232', N'12344555', N'Hà nội', 0, NULL)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[TinTuc] ON 

INSERT [dbo].[TinTuc] ([Id], [LoaiDMTin], [TenTin], [MieuTaNgan], [MieuTaChiTiet], [TrangThai], [NgayXoaTin], [NgayCapNhat], [NguoiDang], [AnhDaiDien]) VALUES (1, 1, N'Mẫu trống rượu gỗ sồi', N'Trống đựng rượu bằng gỗ sồi được nhiều người yêu thích, đặc biệt với những người làm công việc phải tiếp khách, đi công tác nhiều. Ở Việt Nam không có gỗ sồi, cây sồi chỉ có ở các nước xứ lạnh châu Âu, do đặc tính riêng biệt của loại gỗ này rất hợp với rượu vang, làm cho rượu ngon... ', N' <div class="middle">
 <p style="color:#777;padding:0px 0px 5px;margin:0px;">Cập nhật ngày: 10:49AM 17/10/2014</p>
  <p class="MsoNormal" style="text-align:justify">
	<a href="http://thunggo.com/"><strong>Trống đựng rượu bằng gỗ sồi</strong></a> được nhiều người y&ecirc;u th&iacute;ch, đặc biệt với những người l&agrave;m c&ocirc;ng việc phải tiếp kh&aacute;ch, đi c&ocirc;ng t&aacute;c nhiều. Ở Việt Nam kh&ocirc;ng c&oacute; gỗ sồi, c&acirc;y sồi chỉ c&oacute; ở c&aacute;c nước xứ lạnh ch&acirc;u &Acirc;u, do đặc t&iacute;nh ri&ecirc;ng biệt của loại gỗ n&agrave;y rất hợp với rượu vang, l&agrave;m cho rượu ngon hơn, đậm vị v&agrave; thơm lạ khiến người thưởng thức kh&ocirc;ng thể cưỡng lại được sự hấp dẫn của loại ẩm thực uống n&agrave;y. Người Việt hiện đại cũng uống rượu vang nhiều đặc biệt l&agrave; trong c&aacute;c buổi dạ tiệc, lễ tết&hellip; th&igrave; c&agrave;ng kh&ocirc;ng được ph&eacute;p thiếu những li vang s&oacute;ng s&aacute;nh vừa ngon vừa đẹp mắt, lung linh, trang trọng. Lịch sử trống rượu gỗ sồi nhập v&agrave;o nước ta c&aacute;ch đ&acirc;y khoảng 200 năm c&ugrave;ng với đội quan viễn chinh của Ph&aacute;p nhưng v&igrave; để dễ vận chuyển h&agrave;ng h&oacute;a cồng kềnh n&agrave;y m&agrave; người ta nhập gỗ sồi th&ocirc; rồi được c&aacute;c xưởng l&agrave;m trống chuy&ecirc;n nghiệp thực hiện theo kĩ thuật chuẩn của Ph&aacute;p v&agrave; &Yacute; với nhiều k&iacute;ch thước v&agrave; kiểu d&aacute;ng kh&aacute;c nhau.</p>
<p class="MsoNormal" style="text-align:justify">
	C&ocirc;ng ty cổ phần ph&aacute;t triển c&ocirc;ng nghệ v&agrave; thương mại Ho&agrave;ng Gia xuất th&acirc;n từ l&agrave;ng trống Đọi Tam, H&agrave; Nam c&oacute; nghề l&agrave;m trống l&acirc;u đời. Ch&uacute;ng t&ocirc;i thực hiện đ&oacute;ng trống rượu gỗ sồi theo c&aacute;c đơn đặt h&agrave;ng trực tiếp của kh&aacute;ch với nhiều mẫu phong ph&uacute; từ số lượng &iacute;t đến số lượng nhiều, cung cấp to&agrave;n quốc. Đảm bảo h&agrave;ng kh&ocirc;ng đạt ti&ecirc;u chuẩn sẽ kh&ocirc;ngthu tiền sản phẩm. <a href="http://thunggo.com/Thung-ruou/"><strong>Trống rượu gỗ sồi Ho&agrave;ng Gia</strong></a> lu&ocirc;n khẳng định l&agrave; thương hiệu uy t&iacute;n số 1 thị trường trong nước m&agrave; kh&ocirc;ng đơn vị n&agrave;o c&oacute; thể s&aacute;nh kịp cả về lịch sử cũng như kĩ thuật sản xuất trống rượu,</p>
<p class="MsoNormal" style="text-align:justify">
	Gi&uacute;p kh&aacute;ch lựa chọn được sản phẩm ưng &yacute; ch&uacute;ng t&ocirc;i giới thiệu một số <a href="http://thunggo.com/Cai-thung-go/Mau-trong-ruou-go-soi-138.html"><strong>mẫu trống rượu gỗ sồi</strong></a> ti&ecirc;u biểu của xưởng:</p>
<p class="MsoNormal" style="text-align: center;">
	<img alt="" height="221" src="http://www.thunggo.com/image/data/bom-ruou-vang/bom-ruou-go-thong.png" width="300" /></p>
<p class="MsoNormal" style="text-align: center;">
	<img alt="" height="200" src="http://www.thunggo.com/image/data/Ngua-keo-xe/phao-keo-thung-ruou-01.jpg" width="300" /></p>
<p class="MsoNormal" style="text-align: center;">
	<img alt="" height="172" src="http://www.thunggo.com/image/data/Ngua-keo-xe/ngua-doi-keo-thung-ruou-01.jpg" width="300" /></p>
<p class="MsoNormal" style="text-align: center;">
	<img alt="" height="225" src="http://www.thunggo.com/image/data/bom-ruou-vang/thiet-ke-thung-ruou-vang-bar.jpg" width="300" /></p>
<p class="MsoNormal" style="text-align: center;">
	<img alt="" height="199" src="http://www.thunggo.com/image/data/thung-ruou/thung-ruou-go-soi-t62014.jpg" width="300" /></p>
<p class="MsoNormal" style="text-align: center;">
	<img alt="" height="200" src="http://www.thunggo.com/image/data/trong-ruou/trong-ruou-go.jpg" width="300" /></p>
<p class="MsoNormal">
	Trống rượu gỗ sồi Ho&agrave;ng Gia vừa l&agrave; sản phẩm đựng rượu vừa l&agrave; phụ kiện phục vụ văn h&oacute;a uống rượu c&oacute; gi&aacute; trị nghệ thuật giải tr&iacute; cao. Vui l&ograve;ng li&ecirc;n hệ&nbsp;</p>
<p class="MsoNormal" style="text-align: center;">
	<strong style="font-size: 16px; color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; text-align: center;">C&Ocirc;NG TY CỔ PHẦN HO&Agrave;NG GIA GROUP</strong></p>
<p style="font-family: Arial, Helvetica, sans-serif; margin: 2px 0px; color: rgb(0, 0, 0); text-align: center;">
	<span style="color: rgb(255, 0, 0);"><span style="font-size: 14px;"><strong>C&Ocirc;NG TY TƯ VẤN V&Agrave; THIẾT KẾ THI C&Ocirc;NG NỘI THẤT&nbsp;HO&Agrave;NG GIA</strong></span></span></p>
<p style="font-family: Arial, Helvetica, sans-serif; margin: 2px 0px; color: rgb(0, 0, 0); text-align: center;">
	<span style="color: rgb(0, 0, 205);"><span style="font-size: 14px;"><strong>Văn ph&ograve;ng H&agrave; Nội : P801 - T&ograve;a nh&agrave; CTM &nbsp;- 299 Cầu Giấy - H&agrave; Nội &nbsp;</strong></span></span></p>
<p style="font-family: Arial, Helvetica, sans-serif; margin: 2px 0px; color: rgb(0, 0, 0); text-align: center;">
	<strong>Tel : &nbsp;&nbsp;<span style="color: rgb(255, 0, 0);"><span style="font-family: Roboto, sans-serif; font-size: 14px; line-height: 19.6000003814697px; text-align: left;">04.6687.4066 -&nbsp;<span style="font-family: Arial, Helvetica, sans-serif; color: rgb(0, 0, 0);">Hotline:&nbsp;</span>0963.8444.445 - 097484.9193</span></span><span style="color: rgb(255, 0, 0);">&nbsp;</span></strong></p></div>', 1, NULL, CAST(0x25390B00 AS Date), N'Nguyễn Trung Đức', N'Quay_bar/quay bar tu bep 03-150x150.jpg                                                                                                                                                                 ')
SET IDENTITY_INSERT [dbo].[TinTuc] OFF
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
