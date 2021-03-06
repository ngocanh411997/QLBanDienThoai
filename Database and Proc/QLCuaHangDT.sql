USE [master]
GO
/****** Object:  Database [gtmobile]    Script Date: 6/3/2018 2:05:19 AM ******/
CREATE DATABASE [gtmobile]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gtmobile', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.NGOCANH\MSSQL\DATA\gtmobile.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'gtmobile_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.NGOCANH\MSSQL\DATA\gtmobile_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [gtmobile] SET DELAYED_DURABILITY = DISABLED 
GO
USE [gtmobile]
GO
/****** Object:  UserDefinedFunction [dbo].[ChuyenDoiUnicode]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ChuyenDoiUnicode] ( @strInput NVARCHAR(4000) )
 RETURNS NVARCHAR(4000) AS BEGIN 
 IF @strInput IS NULL RETURN @strInput
 IF @strInput = '' RETURN @strInput 
 DECLARE @RT NVARCHAR(4000) 
 DECLARE @SIGN_CHARS NCHAR(136) 
 DECLARE @UNSIGN_CHARS NCHAR (136) 
 SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
 SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
 DECLARE @COUNTER int 
 DECLARE @COUNTER1 int 
 SET @COUNTER = 1 
 WHILE (@COUNTER <=LEN(@strInput)) 
 BEGIN SET @COUNTER1 = 1 
 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
 BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
 BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
 ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
 BREAK END 
 SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END 
 SET @strInput = replace(@strInput,' ','-') 
 RETURN @strInput END

GO
/****** Object:  Table [dbo].[tbl_chitietdonhang]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_chitietdonhang](
	[id_dondathang] [varchar](50) NOT NULL,
	[id_sanpham] [varchar](50) NOT NULL,
	[soluong] [int] NULL,
	[thanhtien] [int] NULL,
 CONSTRAINT [PK_tbl_chitietdonhang] PRIMARY KEY CLUSTERED 
(
	[id_dondathang] ASC,
	[id_sanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_danhmuc]    Script Date: 6/3/2018 2:05:19 AM ******/
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
/****** Object:  Table [dbo].[tbl_dondathang]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_dondathang](
	[id] [varchar](50) NOT NULL,
	[id_khachhang] [varchar](50) NULL,
	[id_tinhtrang] [int] NULL,
	[id_shipper] [varchar](50) NULL,
	[id_nguoilap] [varchar](50) NULL,
	[ngaylap] [date] NULL,
	[noinhan] [nvarchar](250) NULL,
	[ghichu] [nvarchar](150) NULL,
 CONSTRAINT [PK_tbl_dondathang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_khachhang]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_khachhang](
	[id] [varchar](50) NOT NULL,
	[ten] [nvarchar](50) NULL,
	[sdt] [decimal](18, 0) NULL,
	[diachi] [nvarchar](200) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_tbl_khachhang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_nguoidung]    Script Date: 6/3/2018 2:05:19 AM ******/
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
/****** Object:  Table [dbo].[tbl_nhanvien]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_nhanvien](
	[id] [varchar](50) NOT NULL,
	[id_nhiemvu] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[tbl_nhasanxuat]    Script Date: 6/3/2018 2:05:19 AM ******/
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
/****** Object:  Table [dbo].[tbl_nhiemvu]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_nhiemvu](
	[id] [varchar](50) NOT NULL,
	[nhiemvu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_nhiemvu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_quyen]    Script Date: 6/3/2018 2:05:19 AM ******/
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
/****** Object:  Table [dbo].[tbl_sanpham]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sanpham](
	[id] [varchar](50) NOT NULL,
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
	[TrangThai] [varchar](2) NULL,
 CONSTRAINT [PK_tbl_sanpham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tbl_chitietdonhang] ([id_dondathang], [id_sanpham], [soluong], [thanhtien]) VALUES (N'DDH01', N'1', 2, 20000000)
INSERT [dbo].[tbl_chitietdonhang] ([id_dondathang], [id_sanpham], [soluong], [thanhtien]) VALUES (N'DDH01', N'10', 4, 80000000)
INSERT [dbo].[tbl_chitietdonhang] ([id_dondathang], [id_sanpham], [soluong], [thanhtien]) VALUES (N'DDH02', N'1', 3, 30000000)
INSERT [dbo].[tbl_chitietdonhang] ([id_dondathang], [id_sanpham], [soluong], [thanhtien]) VALUES (N'DDH02', N'11', 2, 40000000)
INSERT [dbo].[tbl_chitietdonhang] ([id_dondathang], [id_sanpham], [soluong], [thanhtien]) VALUES (N'DDH03', N'1', 1, 10000000)
INSERT [dbo].[tbl_chitietdonhang] ([id_dondathang], [id_sanpham], [soluong], [thanhtien]) VALUES (N'DDH03', N'20', 1, 15000000)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (1, N'Smartphone          ', NULL)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (2, N'Featurephone        ', NULL)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (3, N'Dumphone            ', NULL)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (4, N'Tablet              ', NULL)
INSERT [dbo].[tbl_danhmuc] ([id], [ten], [icon]) VALUES (5, N'Phụ Kiện            ', NULL)
INSERT [dbo].[tbl_dondathang] ([id], [id_khachhang], [id_tinhtrang], [id_shipper], [id_nguoilap], [ngaylap], [noinhan], [ghichu]) VALUES (N'DDH01', N'KH01', 1, N'NV03', N'NV06', CAST(N'2018-06-02' AS Date), N'Hà Nội', N'')
INSERT [dbo].[tbl_dondathang] ([id], [id_khachhang], [id_tinhtrang], [id_shipper], [id_nguoilap], [ngaylap], [noinhan], [ghichu]) VALUES (N'DDH02', N'KH03', 1, N'NV03', N'NV06', CAST(N'2018-06-02' AS Date), N'Quốc Oai', N'')
INSERT [dbo].[tbl_dondathang] ([id], [id_khachhang], [id_tinhtrang], [id_shipper], [id_nguoilap], [ngaylap], [noinhan], [ghichu]) VALUES (N'DDH03', N'KH02', 1, N'NV04', N'NV07', CAST(N'2018-06-03' AS Date), N'Cổ Nhuế', N'')
INSERT [dbo].[tbl_khachhang] ([id], [ten], [sdt], [diachi], [email]) VALUES (N'KH01', N'Bùi Thảo Phương', CAST(987789234 AS Decimal(18, 0)), N'Hà Nội', N'Phuong@gmail.com')
INSERT [dbo].[tbl_khachhang] ([id], [ten], [sdt], [diachi], [email]) VALUES (N'KH02', N'Trần Ngọc Bích', CAST(987683393 AS Decimal(18, 0)), N'Bắc Ninh', N'Bich@gmail.com')
INSERT [dbo].[tbl_khachhang] ([id], [ten], [sdt], [diachi], [email]) VALUES (N'KH03', N'Nguyễn Quốc Cường', CAST(973923432 AS Decimal(18, 0)), N'Quảng Ninh', N'Cuong@gmail.com')
INSERT [dbo].[tbl_khachhang] ([id], [ten], [sdt], [diachi], [email]) VALUES (N'KH04', N'Phùng Khánh Linh', CAST(933222435 AS Decimal(18, 0)), N'Hà Nội', N'Linh@gmail.com')
SET IDENTITY_INSERT [dbo].[tbl_nguoidung] ON 

INSERT [dbo].[tbl_nguoidung] ([id], [taikhoan], [matkhau], [id_quyen], [ghichu]) VALUES (1, N'admin', N'admin', 1, NULL)
INSERT [dbo].[tbl_nguoidung] ([id], [taikhoan], [matkhau], [id_quyen], [ghichu]) VALUES (2, N'nguoidung', N'nguoidung', 2, NULL)
SET IDENTITY_INSERT [dbo].[tbl_nguoidung] OFF
INSERT [dbo].[tbl_nhanvien] ([id], [id_nhiemvu], [ten], [sdt], [email], [ngaysinh]) VALUES (N'NV01', N'NVU01', N'Nguyễn Văn Huy', CAST(987678765 AS Decimal(18, 0)), N'huy@gmail.com', CAST(N'1994-06-02' AS Date))
INSERT [dbo].[tbl_nhanvien] ([id], [id_nhiemvu], [ten], [sdt], [email], [ngaysinh]) VALUES (N'NV02', N'NVU01', N'Trần Thị Hồng', CAST(987678023 AS Decimal(18, 0)), N'hong@gmail.com', CAST(N'1994-06-21' AS Date))
INSERT [dbo].[tbl_nhanvien] ([id], [id_nhiemvu], [ten], [sdt], [email], [ngaysinh]) VALUES (N'NV03', N'NVU03', N'Đào Văn Minh', CAST(987677654 AS Decimal(18, 0)), N'minh@gmail.com', CAST(N'1996-06-20' AS Date))
INSERT [dbo].[tbl_nhanvien] ([id], [id_nhiemvu], [ten], [sdt], [email], [ngaysinh]) VALUES (N'NV04', N'NVU03', N'Nguyễn Văn Đạo', CAST(987677890 AS Decimal(18, 0)), N'dao@gmail.com', CAST(N'1993-06-20' AS Date))
INSERT [dbo].[tbl_nhanvien] ([id], [id_nhiemvu], [ten], [sdt], [email], [ngaysinh]) VALUES (N'NV05', N'NVU03', N'Hà Chí Công', CAST(987654382 AS Decimal(18, 0)), N'Cong@gmail.com', CAST(N'1997-01-14' AS Date))
INSERT [dbo].[tbl_nhanvien] ([id], [id_nhiemvu], [ten], [sdt], [email], [ngaysinh]) VALUES (N'NV06', N'NVU02', N'Nguyễn Văn Hưng', CAST(987672345 AS Decimal(18, 0)), N'hung123@gmail.com', CAST(N'1993-08-17' AS Date))
INSERT [dbo].[tbl_nhanvien] ([id], [id_nhiemvu], [ten], [sdt], [email], [ngaysinh]) VALUES (N'NV07', N'NVU02', N'Bùi Bá Quang', CAST(987672098 AS Decimal(18, 0)), N'quang123@gmail.com', CAST(N'1993-08-11' AS Date))
INSERT [dbo].[tbl_nhanvien] ([id], [id_nhiemvu], [ten], [sdt], [email], [ngaysinh]) VALUES (N'NV08', N'NVU02', N'Lê Hải Yến', CAST(987671209 AS Decimal(18, 0)), N'Yen@gmail.com', CAST(N'1993-05-17' AS Date))
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (1, N'Apple')
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (2, N'SamSung')
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (3, N'Huawei')
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (4, N'Xiaomi')
INSERT [dbo].[tbl_nhasanxuat] ([id], [ten]) VALUES (5, N'Nokia')
INSERT [dbo].[tbl_nhiemvu] ([id], [nhiemvu]) VALUES (N'NVU01', N'Tiếp thị')
INSERT [dbo].[tbl_nhiemvu] ([id], [nhiemvu]) VALUES (N'NVU02', N'Bán hàng')
INSERT [dbo].[tbl_nhiemvu] ([id], [nhiemvu]) VALUES (N'NVU03', N'Giao hàng')
INSERT [dbo].[tbl_nhiemvu] ([id], [nhiemvu]) VALUES (N'NVU04', N'Kiểm hàng')
INSERT [dbo].[tbl_quyen] ([id], [ten]) VALUES (1, N'admin')
INSERT [dbo].[tbl_quyen] ([id], [ten]) VALUES (2, N'Người Dùng')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'1', NULL, 1, N'iphone 5s', N'iphone5.jpg', CAST(10000000 AS Decimal(18, 0)), 1, 200, 128, 4, 256, 12, 12, 4000, NULL, NULL, 1, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'10', NULL, 4, N'Surface Pro 2017', N'surfacepro2017.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 6, 256, 12, 24, 4000, NULL, NULL, 1, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'11', NULL, 4, N'ZTEE8Q', N'ZTEE8Q.png', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 8, 256, 12, 24, 4000, NULL, NULL, 2, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'12', NULL, 4, N'Huaweit Mate 7 pro', N'huaweit17pro.png', CAST(20000000 AS Decimal(18, 0)), 1, 200, 200, 4, 256, 12, 24, 4000, NULL, NULL, 3, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'13', NULL, 1, N'Nokia 2', N'nokia2.jpg', CAST(2000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'14', NULL, 1, N'Nokia 3', N'nokia3.jpg', CAST(3000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'15', NULL, 1, N'Nokia 4', N'nokia4.jpg', CAST(4000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'16', NULL, 1, N'Nokia 5', N'nokia5.jpg', CAST(5000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'17', NULL, 1, N'Nokia 6', N'nokia6.jpg', CAST(6000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 5, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'18', NULL, 4, N'Ipad Wifi', N'ipadWifi.png', CAST(15000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 1, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'19', NULL, 4, N'Ipad Mini', N'ipadMini.jpg', CAST(6000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 1, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'2', NULL, 1, N'iphone 6', N'iphone6.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 3, 256, 12, 12, 3500, NULL, NULL, 1, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'20', NULL, 4, N'Samsung Galaxy Tab A6', N'ssgalaxyTabA6.jpg', CAST(15000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 2, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'21', NULL, 4, N'Samsung Galaxy Tab A8', N'ssgalaxyTabA8.jpg', CAST(15000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 2, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'22', NULL, 4, N'Samsung Galaxy Tab E', N'ssgalaxyTabE.jpg', CAST(6000000 AS Decimal(18, 0)), 10, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 2, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'23', NULL, 4, N'Huawei MediaPad M3 8.0', N'huaweiMediaPadM3.jpeg', CAST(6000000 AS Decimal(18, 0)), 10, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 3, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'24', NULL, 4, N'Huawei MediaPad T3', N'huaweiMediaPadT3.jpg', CAST(4000000 AS Decimal(18, 0)), 10, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 3, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'3', NULL, 1, N'Iphone 7', N'iphone7.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 6, 256, 12, 24, 3500, NULL, NULL, 1, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'4', NULL, 1, N'Iphone 10', N'iphone10.jpg', CAST(30000000 AS Decimal(18, 0)), 1, 200, 128, 4, 256, 12, 24, 3500, NULL, NULL, 1, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'5', NULL, 1, N'Samsung galaxy s8', N'ssgalaxys8.jpg', CAST(15000000 AS Decimal(18, 0)), 1, 200, 128, 6, 256, 12, 24, 3500, NULL, NULL, 2, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'6', NULL, 1, N'Samsung galaxy s9', N'ssgalaxys9.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 3500, NULL, NULL, 2, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'8', NULL, 4, N'Ipad pro 2018', N'ipadpro2018.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 6, 256, 12, 24, 4000, NULL, NULL, 1, N'0')
INSERT [dbo].[tbl_sanpham] ([id], [id_khuyenmai], [id_danhmuc], [ten], [link_anh], [gia], [soluong], [trongluong], [ROM], [RAM], [thenho], [camera_truoc], [camera_sau], [pin], [baohanh], [bluetooth], [id_nhasanxuat], [TrangThai]) VALUES (N'9', NULL, 4, N'Ipad Air 2', N'ipadAir2.jpg', CAST(20000000 AS Decimal(18, 0)), 1, 200, 256, 4, 256, 12, 24, 4000, NULL, NULL, 1, N'0')
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
/****** Object:  StoredProcedure [dbo].[DaTT]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DaTT](@id VARCHAR(50),@id_tinhtrang INT)
AS
BEGIN
	UPDATE dbo.tbl_dondathang
	SET id_tinhtrang=1
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[HoaDonDaTT]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[HoaDonDaTT]
AS
BEGIN
	SELECT tbl_dondathang.id,ten,id_nguoilap,ngaylap,SUM(thanhtien) AS tongtien FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id INNER JOIN dbo.tbl_chitietdonhang ON tbl_chitietdonhang.id_dondathang = tbl_dondathang.id
	WHERE id_tinhtrang=1
	GROUP BY tbl_dondathang.id,ten,id_nguoilap,ngaylap
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAll_Sp]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SelectAll_Sp]
AS
BEGIN
SELECT * FROM dbo.tbl_sanpham
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Login]    Script Date: 6/3/2018 2:05:19 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SanPham_ListAll]    Script Date: 6/3/2018 2:05:19 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ThemSP]    Script Date: 6/3/2018 2:05:19 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SuaCTDDH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SuaCTDDH](@id_dondathang VARCHAR(50), @id_sanpham VARCHAR(50), @soluong INT,@thanhtien int)
AS
BEGIN
	UPDATE dbo.tbl_chitietdonhang
	SET soluong=@soluong,thanhtien=@soluong*(SELECT gia FROM dbo.tbl_sanpham WHERE id=@id_sanpham)
	WHERE id_dondathang=@id_dondathang AND id_sanpham=@id_sanpham
    
END
GO
/****** Object:  StoredProcedure [dbo].[SuaDDH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SuaDDH](@id VARCHAR(50),@id_khachhang VARCHAR(50), @id_tinhtrang INT,@id_shipper VARCHAR(50), @id_nguoilap VARCHAR(50),@ngaylap DATE,@noinhan NVARCHAR(250), @ghichu NVARCHAR(150))
AS
BEGIN
	UPDATE dbo.tbl_dondathang
	SET id_khachhang=@id_khachhang,id_tinhtrang=0,id_shipper=@id_shipper,id_nguoilap=@id_nguoilap,ngaylap=@ngaylap,noinhan=@noinhan,ghichu=@ghichu
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SuaNhVu]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SuaNhVu](@id VARCHAR(50), @nhiemvu NVARCHAR(50))
AS
BEGIN
	UPDATE dbo.tbl_nhiemvu
	SET nhiemvu=@nhiemvu
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SuaNV]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SuaNV](@id VARCHAR(50),@id_nhiemvu VARCHAR(50), @ten NVARCHAR(100), @sdt DECIMAL(18,0), @email VARCHAR(100), @ngaysinh DATE)
AS
BEGIN
	UPDATE dbo.tbl_nhanvien
	SET id_nhiemvu=@id_nhiemvu,ten=@ten,sdt=@sdt,email=@email,ngaysinh=@ngaysinh
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[ThemCTDDH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemCTDDH](@id_dondathang VARCHAR(50), @id_sanpham VARCHAR(50), @soluong INT,@thanhtien int)
AS
BEGIN
	INSERT INTO dbo.tbl_chitietdonhang
	        ( id_dondathang ,
	          id_sanpham ,
	          soluong,
			 thanhtien
	        )
	VALUES  ( @id_dondathang,@id_sanpham,@soluong,@soluong*(SELECT gia FROM dbo.tbl_sanpham WHERE id=@id_sanpham)
	        )
END
GO
/****** Object:  StoredProcedure [dbo].[ThemDDH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemDDH](@id VARCHAR(50),@id_khachhang VARCHAR(50), @id_tinhtrang INT,@id_shipper VARCHAR(50), @id_nguoilap VARCHAR(50),@ngaylap DATE,@noinhan NVARCHAR(250), @ghichu NVARCHAR(150))
AS
BEGIN
	INSERT INTO dbo.tbl_dondathang
	        ( id ,
	          id_khachhang ,
	          id_tinhtrang ,
	          id_shipper ,
	          id_nguoilap ,
	          ngaylap ,
	          noinhan ,
	          ghichu
	        )
	VALUES  ( @id,@id_khachhang,0,@id_shipper,@id_nguoilap,@ngaylap,@noinhan,@ghichu)
END
GO
/****** Object:  StoredProcedure [dbo].[ThemNhVu]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemNhVu](@id VARCHAR(50), @nhiemvu NVARCHAR(50))
AS
BEGIN
	INSERT INTO dbo.tbl_nhiemvu
	        ( id, nhiemvu )
	VALUES  ( @id,@nhiemvu)
END
GO
/****** Object:  StoredProcedure [dbo].[ThemNV]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemNV](@id VARCHAR(50),@id_nhiemvu VARCHAR(50), @ten NVARCHAR(100), @sdt DECIMAL(18,0), @email VARCHAR(100), @ngaysinh DATE)
AS
BEGIN
	INSERT INTO dbo.tbl_nhanvien
	        ( id ,
	          id_nhiemvu ,
	          ten ,
	          sdt ,
	          email ,
	          ngaysinh
	        )
	VALUES  ( @id,@id_nhiemvu,@ten,@sdt,@email,@ngaysinh)
END
GO
/****** Object:  StoredProcedure [dbo].[TK_KH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TK_KH](@Ten NVARCHAR(50))
AS BEGIN
SELECT  tbl_dondathang.id,tbl_khachhang.ten,id_shipper,id_nguoilap,ngaylap,noinhan,ghichu
	FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id WHERE id_tinhtrang=0
and dbo.ChuyenDoiUnicode(tbl_khachhang.ten) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END
GO
/****** Object:  StoredProcedure [dbo].[TK_NVDDH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TK_NVDDH](@Ten NVARCHAR(50))
AS BEGIN
SELECT tbl_dondathang.id,tbl_khachhang.ten,tbl_nhanvien.ten,tbl_nhanvien.ten,ngaylap,noinhan,ghichu
	FROM dbo.tbl_dondathang INNER JOIN dbo.tbl_khachhang ON tbl_khachhang.id = tbl_dondathang.id_khachhang INNER JOIN dbo.tbl_nhanvien ON tbl_nhanvien.id = tbl_dondathang.id_nguoilap AND tbl_nhanvien.id = tbl_dondathang.id_shipper WHERE id_tinhtrang=0
and dbo.ChuyenDoiUnicode(tbl_nhanvien.ten) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END
GO
/****** Object:  StoredProcedure [dbo].[TK_NVu]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TK_NVu](@Ten NVARCHAR(50))
AS BEGIN
SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh 
	FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu
WHERE dbo.ChuyenDoiUnicode(nhiemvu) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END
GO
/****** Object:  StoredProcedure [dbo].[TKTenNV]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TKTenNV](@Ten NVARCHAR(50))
AS BEGIN
SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh 
	FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu
WHERE dbo.ChuyenDoiUnicode(ten) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END
GO
/****** Object:  StoredProcedure [dbo].[TKTenNVu]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TKTenNVu](@Ten NVARCHAR(50))
AS BEGIN
SELECT *
FROM dbo.tbl_nhiemvu
WHERE dbo.ChuyenDoiUnicode(nhiemvu) LIKE N'%'+dbo.ChuyenDoiUnicode(@Ten)+N'%'
END
GO
/****** Object:  StoredProcedure [dbo].[XemDDH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XemDDH]
AS
BEGIN
	SELECT tbl_dondathang.id,tbl_khachhang.ten,id_shipper,id_nguoilap,ngaylap,noinhan,ghichu
	FROM dbo.tbl_khachhang INNER JOIN dbo.tbl_dondathang ON tbl_dondathang.id_khachhang = tbl_khachhang.id WHERE id_tinhtrang=0
END
GO
/****** Object:  StoredProcedure [dbo].[XemNV]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XemNV]
AS
BEGIN
	SELECT tbl_nhanvien.id,nhiemvu,ten,sdt,email,ngaysinh 
	FROM dbo.tbl_nhanvien INNER JOIN dbo.tbl_nhiemvu ON tbl_nhiemvu.id = tbl_nhanvien.id_nhiemvu
END
GO
/****** Object:  StoredProcedure [dbo].[XemNVu]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XemNVu]
AS
BEGIN
	SELECT *
	FROM dbo.tbl_nhiemvu
END
GO
/****** Object:  StoredProcedure [dbo].[XoaCTDDH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XoaCTDDH](@id_dondathang VARCHAR(50), @id_sanpham VARCHAR(50))
AS
BEGIN
	DELETE dbo.tbl_chitietdonhang
	WHERE id_dondathang=@id_dondathang AND id_sanpham=@id_sanpham
END
GO
/****** Object:  StoredProcedure [dbo].[XoaDDH]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XoaDDH](@id VARCHAR(50))
AS
BEGIN
	DELETE dbo.tbl_chitietdonhang
	WHERE id_dondathang=@id
	DELETE dbo.tbl_dondathang
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[XoaNhVu]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XoaNhVu](@id VARCHAR(50))
AS
BEGIN
	DELETE dbo.tbl_nhanvien
	WHERE id_nhiemvu=@id
	DELETE dbo.tbl_nhiemvu
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[XoaNV]    Script Date: 6/3/2018 2:05:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XoaNV](@id VARCHAR(50))
AS
BEGIN
	DELETE dbo.tbl_dondathang
	WHERE id_nguoilap=@id OR id_shipper=@id
	DELETE dbo.tbl_nhanvien
	WHERE id=@id
END
GO
USE [master]
GO
ALTER DATABASE [gtmobile] SET  READ_WRITE 
GO
