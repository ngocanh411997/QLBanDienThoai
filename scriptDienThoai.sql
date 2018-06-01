USE [master]
GO
/****** Object:  Database [gtmobile]    Script Date: 01/06/2018 11:04:42 PM ******/
CREATE DATABASE [gtmobile]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gtmobile', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\gtmobile.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'gtmobile_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\gtmobile_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [gtmobile] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gtmobile].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gtmobile] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gtmobile] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gtmobile] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gtmobile] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gtmobile] SET ARITHABORT OFF 
GO
ALTER DATABASE [gtmobile] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [gtmobile] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [gtmobile] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gtmobile] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gtmobile] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gtmobile] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gtmobile] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gtmobile] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gtmobile] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gtmobile] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gtmobile] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gtmobile] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gtmobile] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gtmobile] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gtmobile] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gtmobile] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gtmobile] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gtmobile] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gtmobile] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [gtmobile] SET  MULTI_USER 
GO
ALTER DATABASE [gtmobile] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gtmobile] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gtmobile] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gtmobile] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [gtmobile]
GO
/****** Object:  StoredProcedure [dbo].[SP_Login]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[SP_Login](@uname NCHAR(10), @pass NCHAR(10))
AS
BEGIN
	DECLARE @count INT
	DECLARE @res BIT  

	SELECT @count = COUNT(id) FROM dbo.tbl_nguoidung WHERE taikhoan = @uname AND matkhau = @pass

	IF(@count = 1) SET @res = 1
	ELSE SET @res = 0

	SELECT @res

END


GO
/****** Object:  StoredProcedure [dbo].[SP_SanPham_ListAll]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SanPham_ListAll]
AS 
BEGIN
	SELECT *FROM dbo.tbl_sanpham
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ThemSP]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ThemSP]
(
	@id INT,
	@id_km INT,
	@id_dm INT,
	@ten NVARCHAR(50),
	@anh VARCHAR(50),
	@gia DECIMAL,
	@soluong INT,
	@trongluong INT,
	@Rom INT, 
	@Ram INT,
	@thenho INT,
	@camtruoc INT,
	@camsau INT,
	@pin INT,
	@baohanh INT,
	@bluetooth FLOAT,
	@id_nsx INT
)
AS
BEGIN
	INSERT INTO dbo.tbl_sanpham
	VALUES  ( @id , -- id - int
	          @id_km , -- id_khuyenmai - int
	          @id_dm , -- id_danhmuc - int
	          @ten , -- ten - nvarchar(150)
	          @anh , -- link_anh - varchar(150)
	          @gia , -- gia - decimal
	          @soluong , -- soluong - int
	          @trongluong , -- trongluong - int
	          @Rom , -- ROM - int
	          @Ram , -- RAM - int
	          @thenho , -- thenho - int
	          @camtruoc, -- camera_truoc - int
	          @camsau , -- camera_sau - int
	          @pin , -- pin - int
	          @baohanh , -- baohanh - int
	          @bluetooth , -- bluetooth - float
	          @id_nsx  -- id_nhasanxuat - int
	        )
END
GO
/****** Object:  Table [dbo].[tbl_chitietdonhang]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_chitietdonhang](
	[id_dondathang] [int] NOT NULL,
	[id_sanpham] [int] NOT NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_tbl_chitietdonhang] PRIMARY KEY CLUSTERED 
(
	[id_dondathang] ASC,
	[id_sanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_danhmuc]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_danhmuc](
	[id] [int] NOT NULL,
	[ten] [nchar](20) NULL,
	[icon] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_danhmuc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_dondathang]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_dondathang](
	[id] [int] NOT NULL,
	[id_khachhang] [int] NULL,
	[id_tinhtrang] [int] NULL,
	[id_shipper] [int] NULL,
	[id_nguoilap] [int] NULL,
	[ngaylap] [date] NULL,
	[tonggia] [decimal](18, 0) NULL,
	[noinhan] [nvarchar](250) NULL,
	[ghichu] [nvarchar](150) NULL,
 CONSTRAINT [PK_tbl_dondathang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_khachhang]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_khachhang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](50) NULL,
	[sdt] [decimal](18, 0) NULL,
	[diachi] [varchar](200) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_tbl_khachhang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_nguoidung]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_nguoidung](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[taikhoan] [nvarchar](50) NULL,
	[matkhau] [nvarchar](50) NULL,
	[id_quyen] [int] NULL,
	[ghichu] [nvarchar](150) NULL,
 CONSTRAINT [PK_tbl_nguoidung] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_nhanvien]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_nhanvien](
	[id] [int] NOT NULL,
	[id_nhiemvu] [int] NULL,
	[ten] [nvarchar](100) NULL,
	[sdt] [decimal](18, 0) NULL,
	[email] [varchar](100) NULL,
	[ngaysinh] [date] NULL,
 CONSTRAINT [PK_tbl_nhanvien] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_nhasanxuat]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_nhasanxuat](
	[id] [int] NOT NULL,
	[ten] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_nhasanxuat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_nhiemvu]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_nhiemvu](
	[id] [int] NOT NULL,
	[nhiemvu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_nhiemvu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_quyen]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_quyen](
	[id] [int] NOT NULL,
	[ten] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_quyen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_sanpham]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sanpham](
	[id] [int] NOT NULL,
	[id_khuyenmai] [int] NULL,
	[id_danhmuc] [int] NULL,
	[ten] [nvarchar](150) NULL,
	[link_anh] [varchar](150) NULL,
	[gia] [decimal](18, 0) NULL,
	[soluong] [int] NULL,
	[trongluong] [int] NULL,
	[ROM] [int] NULL,
	[RAM] [int] NULL,
	[thenho] [int] NULL,
	[camera_truoc] [int] NULL,
	[camera_sau] [int] NULL,
	[pin] [int] NULL,
	[baohanh] [int] NULL,
	[bluetooth] [float] NULL,
	[id_nhasanxuat] [int] NULL,
 CONSTRAINT [PK_tbl_sanpham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_tinhtrang]    Script Date: 01/06/2018 11:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tinhtrang](
	[id] [int] NOT NULL,
	[tinhtrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_tinhtrang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (1, N'Smartphone          ', NULL)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (2, N'Featurephone        ', NULL)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (3, N'Dumphone            ', NULL)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (4, N'Tablet              ', NULL)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (5, N'Phụ Kiện            ', NULL)
SET IDENTITY_INSERT [dbo].[tbl_nguoidung] ON 

INSERT [dbo].[tbl_nguoidung] ([id], [taikhoan], [matkhau], [id_quyen], [ghichu]) VALUES (1, N'admin', N'admin', 1, NULL)
INSERT [dbo].[tbl_nguoidung] ([id], [taikhoan], [matkhau], [id_quyen], [ghichu]) VALUES (2, N'nguoidung', N'nguoidung', 2, NULL)
SET IDENTITY_INSERT [dbo].[tbl_nguoidung] OFF
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (1, N'Apple')
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (2, N'SamSung')
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (3, N'Huawei')
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (4, N'Xiaomi')
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (5, N'Nokia')
INSERT [dbo].[tbl_nhiemvu] ([id], [nhiemvu]) VALUES (1, N'Nhân viên tiếp thị')
INSERT [dbo].[tbl_nhiemvu] ([id], [nhiemvu]) VALUES (2, N'Nhân viên bán hàng')
INSERT [dbo].[tbl_nhiemvu] ([id], [nhiemvu]) VALUES (3, N'Nhân viên ')
INSERT [dbo].[tbl_nhiemvu] ([id], [nhiemvu]) VALUES (4, NULL)
INSERT [dbo].[tbl_quyen] ([id], [ten]) VALUES (1, N'admin')
INSERT [dbo].[tbl_quyen] ([id], [ten]) VALUES (2, N'Người Dùng')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (1, NULL, 1, N'iphone 5s', N'iphone5.jpg', CAST(10000000 AS Decimal(18, 0)), 1, 200, 128, 4, 256, 12, 12, 4000, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (2, NULL, 1, N'iphone 6', N'iphone6.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 3, 256, 12, 12, 3500, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (3, NULL, 1, N'Iphone 7', N'iphone7.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 6, 256, 12, 24, 3500, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (4, NULL, 1, N'Iphone 10', N'iphone10.jpg', CAST(30000000 AS Decimal(18, 0)), 1, 200, 128, 4, 256, 12, 24, 3500, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (5, NULL, 1, N'Samsung galaxy s8', N'ssgalaxys8.jpg', CAST(15000000 AS Decimal(18, 0)), 1, 200, 128, 6, 256, 12, 24, 3500, NULL, NULL, 2)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (6, NULL, 1, N'Samsung galaxy s9', N'ssgalaxys9.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 3500, NULL, NULL, 2)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (8, NULL, 4, N'Ipad pro 2018', N'ipadpro2018.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 6, 256, 12, 24, 4000, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (9, NULL, 4, N'Ipad Air 2', N'ipadAir2.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (10, NULL, 4, N'Surface Pro 2017', N'surfacepro2017.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 6, 256, 12, 24, 4000, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (11, NULL, 4, N'ZTEE8Q', N'ZTEE8Q.png', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 8, 256, 12, 24, 4000, NULL, NULL, 2)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (12, NULL, 4, N'Huaweit Mate 7 pro', N'huaweit17pro.png', CAST(20000000 AS Decimal(18, 0)), 1, 200, 200, 4, 256, 12, 24, 4000, NULL, NULL, 3)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (13, NULL, 1, N'Nokia 2', N'nokia2.jpg', CAST(2000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (14, NULL, 1, N'Nokia 3', N'nokia3.jpg', CAST(3000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (15, NULL, 1, N'Nokia 4', N'nokia4.jpg', CAST(4000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (16, NULL, 1, N'Nokia 5', N'nokia5.jpg', CAST(5000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (17, NULL, 1, N'Nokia 6', N'nokia6.jpg', CAST(6000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (18, NULL, 4, N'Ipad Wifi', N'ipadWifi.png', CAST(15000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (19, NULL, 4, N'Ipad Mini', N'ipadMini.jpg', CAST(6000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 1)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (20, NULL, 4, N'Samsung Galaxy Tab A6', N'ssgalaxyTabA6.jpg', CAST(15000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 2)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (21, NULL, 4, N'Samsung Galaxy Tab A8', N'ssgalaxyTabA8.jpg', CAST(15000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 2)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (22, NULL, 4, N'Samsung Galaxy Tab E', N'ssgalaxyTabE.jpg', CAST(6000000 AS Decimal(18, 0)), 10, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 2)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (23, NULL, 4, N'Huawei MediaPad M3 8.0', N'huaweiMediaPadM3.jpeg', CAST(6000000 AS Decimal(18, 0)), 10, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 3)
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat]) VALUES (24, NULL, 4, N'Huawei MediaPad T3', N'huaweiMediaPadT3.jpg', CAST(4000000 AS Decimal(18, 0)), 10, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 3)
ALTER TABLE [dbo].[tbl_chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_tbl_chitietdonhang_tbl_dondathang] FOREIGN KEY([id_dondathang])
REFERENCES [dbo].[tbl_dondathang] ([id])
GO
ALTER TABLE [dbo].[tbl_chitietdonhang] CHECK CONSTRAINT [FK_tbl_chitietdonhang_tbl_dondathang]
GO
ALTER TABLE [dbo].[tbl_chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_tbl_chitietdonhang_tbl_sanpham] FOREIGN KEY([id_sanpham])
REFERENCES [dbo].[tbl_sanpham] ([id])
GO
ALTER TABLE [dbo].[tbl_chitietdonhang] CHECK CONSTRAINT [FK_tbl_chitietdonhang_tbl_sanpham]
GO
ALTER TABLE [dbo].[tbl_dondathang]  WITH CHECK ADD  CONSTRAINT [FK_tbl_dondathang_tbl_khachhang] FOREIGN KEY([id_khachhang])
REFERENCES [dbo].[tbl_khachhang] ([id])
GO
ALTER TABLE [dbo].[tbl_dondathang] CHECK CONSTRAINT [FK_tbl_dondathang_tbl_khachhang]
GO
ALTER TABLE [dbo].[tbl_dondathang]  WITH CHECK ADD  CONSTRAINT [FK_tbl_dondathang_tbl_nhanvien] FOREIGN KEY([id_nguoilap])
REFERENCES [dbo].[tbl_nhanvien] ([id])
GO
ALTER TABLE [dbo].[tbl_dondathang] CHECK CONSTRAINT [FK_tbl_dondathang_tbl_nhanvien]
GO
ALTER TABLE [dbo].[tbl_dondathang]  WITH CHECK ADD  CONSTRAINT [FK_tbl_dondathang_tbl_nhanvien1] FOREIGN KEY([id_shipper])
REFERENCES [dbo].[tbl_nhanvien] ([id])
GO
ALTER TABLE [dbo].[tbl_dondathang] CHECK CONSTRAINT [FK_tbl_dondathang_tbl_nhanvien1]
GO
ALTER TABLE [dbo].[tbl_dondathang]  WITH CHECK ADD  CONSTRAINT [FK_tbl_dondathang_tbl_tinhtrang] FOREIGN KEY([id_tinhtrang])
REFERENCES [dbo].[tbl_tinhtrang] ([id])
GO
ALTER TABLE [dbo].[tbl_dondathang] CHECK CONSTRAINT [FK_tbl_dondathang_tbl_tinhtrang]
GO
ALTER TABLE [dbo].[tbl_nguoidung]  WITH CHECK ADD  CONSTRAINT [FK_tbl_nguoidung_tbl_quyen] FOREIGN KEY([id_quyen])
REFERENCES [dbo].[tbl_quyen] ([id])
GO
ALTER TABLE [dbo].[tbl_nguoidung] CHECK CONSTRAINT [FK_tbl_nguoidung_tbl_quyen]
GO
ALTER TABLE [dbo].[tbl_nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_tbl_nhanvien_tbl_nhiemvu] FOREIGN KEY([id_nhiemvu])
REFERENCES [dbo].[tbl_nhiemvu] ([id])
GO
ALTER TABLE [dbo].[tbl_nhanvien] CHECK CONSTRAINT [FK_tbl_nhanvien_tbl_nhiemvu]
GO
ALTER TABLE [dbo].[tbl_sanpham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_sanpham_tbl_danhmuc] FOREIGN KEY([id_danhmuc])
REFERENCES [dbo].[tbl_danhmuc] ([id])
GO
ALTER TABLE [dbo].[tbl_sanpham] CHECK CONSTRAINT [FK_tbl_sanpham_tbl_danhmuc]
GO
ALTER TABLE [dbo].[tbl_sanpham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_sanpham_tbl_nhasanxuat] FOREIGN KEY([id_nhasanxuat])
REFERENCES [dbo].[tbl_nhasanxuat] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[tbl_sanpham] CHECK CONSTRAINT [FK_tbl_sanpham_tbl_nhasanxuat]
GO
USE [master]
GO
ALTER DATABASE [gtmobile] SET  READ_WRITE 
GO

GO
ALTER TABLE tbl_sanpham
ADD TrangThai VARCHAR(2)