USE [master]
GO
/****** Object:  Database [WebShop]    Script Date: 7.2.2023. 21:01:22 ******/
CREATE DATABASE [WebShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebShop', FILENAME = N'/var/opt/mssql/data/WebShop.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebShop_log', FILENAME = N'/var/opt/mssql/data/WebShop_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [WebShop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WebShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebShop] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WebShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebShop] SET RECOVERY FULL 
GO
ALTER DATABASE [WebShop] SET  MULTI_USER 
GO
ALTER DATABASE [WebShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebShop', N'ON'
GO
ALTER DATABASE [WebShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [WebShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [WebShop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Adresses]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[ZipCode] [nvarchar](max) NOT NULL,
	[Tel] [nvarchar](max) NOT NULL,
	[BillingOrderId] [int] NULL,
	[ShippingOrderId] [int] NULL,
	[Street] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Adresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Street] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Tel] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attributes]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [nvarchar](max) NOT NULL,
	[ProductId] [int] NOT NULL,
	[AttributesType] [int] NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Socket] [nvarchar](max) NULL,
	[CoreCount] [int] NULL,
	[ThreadCount] [int] NULL,
	[CacheL3] [int] NULL,
	[BoostClockGpu] [real] NULL,
	[CoreClockGpu] [real] NULL,
	[TDP] [int] NULL,
	[Graphics] [nvarchar](max) NULL,
	[BaseClockCpu] [real] NULL,
	[BoostClockCpu] [real] NULL,
	[Brand] [nvarchar](max) NULL,
	[Cooler] [nvarchar](max) NULL,
	[DisplayPort] [nvarchar](max) NULL,
	[HDMI] [nvarchar](max) NULL,
	[Interface] [nvarchar](max) NULL,
	[MaxGPULength] [int] NULL,
	[Memory] [int] NULL,
	[MemoryInterface] [int] NULL,
	[MemoryType] [nvarchar](max) NULL,
	[PowerConnector] [nvarchar](max) NULL,
	[RecommendedPSU] [nvarchar](max) NULL,
	[SlotWidth] [nvarchar](max) NULL,
	[StreamProcessors] [nvarchar](max) NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ISO4217] [nvarchar](max) NOT NULL,
	[Symbol] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[File] [nvarchar](max) NOT NULL,
	[ProductId] [int] NOT NULL,
	[MainImage] [bit] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Newsletters]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Newsletters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Newsletters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[UserId] [int] NULL,
	[StripeId] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[CurrencyISO4217] [nvarchar](max) NOT NULL,
	[Amount] [float] NOT NULL,
	[Status] [int] NOT NULL,
	[SessionId] [uniqueidentifier] NOT NULL,
	[CratedDate] [datetime2](7) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Invoice] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [real] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCart]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CartId] [int] NULL,
 CONSTRAINT [PK_ProductCart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrders]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderId] [int] NULL,
	[CurrencyISO4217] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ShortName] [nvarchar](max) NOT NULL,
	[CurrencySymbol] [nvarchar](max) NOT NULL,
	[Discount] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_ProductOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Discount] [int] NOT NULL,
	[InStock] [int] NOT NULL,
	[Sold] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[SelectedSpecification] [nvarchar](max) NOT NULL,
	[ShortName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductWishlist]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductWishlist](
	[ProductsId] [int] NOT NULL,
	[WishlistsId] [int] NOT NULL,
 CONSTRAINT [PK_ProductWishlist] PRIMARY KEY CLUSTERED 
(
	[ProductsId] ASC,
	[WishlistsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[StarRating] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlists]    Script Date: 7.2.2023. 21:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Wishlists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220918003006_1', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220918165032_2', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220918165159_3', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221029121624_4', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221030151718_5', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221106120606_6', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221106121205_8', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221125192759_GpuAttributes', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221125201213_FixNamingGPuAttr', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221209195507_ProdSelSepc', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221217113638_ChangePcitureName', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221217113754_ChangePcitureName2', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221217114145_ChangePcitureName3', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221226195729_UpdateProductModel', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221228212412_CatWishlist', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221229224209_UpdateUser', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221230210700_UpdateUser3', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230101200144_AddOrder', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230101204047_UpdateOrder', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230101205941_UpdateOrder2', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230123204251_UpdateProduct', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230125173309_AddSesionIdToOrder', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230126195631_AddOrderCreatedDate', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230128192553_AddProductOrder', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230128193527_AddProductOrder2', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230128195545_AddProductOrder3', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230128200504_AddProductOrder4', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230128200706_AddProductOrder5', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230128201111_AddProductOrder6', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230128230312_AddProductOrder7', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230128230732_AddProductOrder8', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230129110126_AddProductOrder9', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230129112056_ChangeUser', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230129120707_ChangOrderAdress', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230129122712_ChangOrderAdress3', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230129124312_ChangOrderAdress4', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230202190715_ProductDescription', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230202212637_AddReview', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230203234908_AddProductIdToReview', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230205193456_AddNewsLetter', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230205200834_AddNewsLetter2', N'7.0.1')
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Super Administrator', N'SUPER ADMINISTRATOR', N'3599bb1e-207b-4b3e-a5a3-0014d114f8f4')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Administrator', N'ADMINISTRATOR', N'fb5e9ce8-4ce9-46c1-889b-6fe7367a2b07')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'User', N'USER', N'f60aafc0-6546-49f9-b291-421cf460e3b8')
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (11, 3)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Street], [City], [Country], [Tel], [ZipCode]) VALUES (11, N'Luke', N'Benson', N'fZcpZFmkKwlVkSKt/tm4uNr4wTtDF0xk8XKvxIUiF98=', CAST(N'2023-02-11T20:44:27.2860670' AS DateTime2), N'b4212249-bb56-4aa9-89a2-0b1df689775d', N'B4212249-BB56-4AA9-89A2-0B1DF689775D', N'lukeBenson@rhyta.com', N'LUKEBENSON@RHYTA.COM', 0, N'AQAAAAIAAYagAAAAEFcFEzp3+HA453cQGHsJfQLO0WDNRWERzSKhoLWE5/mmpCDlDCf2MyTFdLLiekrXXw==', N'ODXB5PHKEDNYQUCACTO2G3WTEO3SD3PQ', N'f09a41c3-acf5-4430-af86-171342a81e60', N'252-395-6522', 0, 0, NULL, 1, 0, N'Green Acres Road 34', N'Rocky Mount', N'Croatia', NULL, N'1000')
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Attributes] ON 

INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (3, N'AMD', 1, 1, N'Ryzen 5 5600X', N'AM4', 6, 12, 32, 3.7, 4.6, 65, N'None', 3.7, 4.6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (7, N'AMD', 2, 1, N'Ryzen 9 5900X', N'AM4', 12, 24, 64, 3.7, 4.8, 105, N'None', 3.7, 4.8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (8, N'AMD', 3, 1, N'Ryzen 9 5950X', N'AM4', 16, 32, 64, 3.4, 4.9, 105, N'None', 3.4, 4.9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (9, N'AMD', 4, 1, N'Ryzen 5 4500', N'AM4', 6, 12, 8, 3.6, 4.1, 65, N'None', 3.6, 4.1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (10, N'AMD', 5, 1, N'Ryzen 7 5700G', N'AM4', 8, 16, 16, 3.8, 4.6, 65, N'Radeon Graphics', 3.8, 4.6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (11, N'Intel', 6, 1, N'Core i7-11700K', N'FCLGA1200', 8, 16, 16, 3.6, 5, 125, N'Intel UHD Graphics 750', 3.1, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (12, N'Intel', 7, 1, N'Core i5-10400', N'FCLGA1200', 6, 12, 12, 2.9, 4.3, 65, N'Intel UHD Graphics 630', 2.9, 4.3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (13, N'Intel', 8, 1, N'Core i9-12900K', N'FCLGA1700', 16, 24, 30, 2.4, 5.2, 125, N'Intel UHD Graphics 770', 2.4, 5.2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (17, N'AMD', 9, 2, N'AMD Radeon RX 6600 XT', NULL, NULL, NULL, NULL, 2602, 2413, NULL, NULL, NULL, NULL, N'MSI', N'Double Fans', N'3 x DisplayPort 1.4', N'1 x HDMI 2.1', N'PCI Express 4.0', 215, 8, 128, N'GDDR6', N'8-Pin', N'500', N'Dual Slot', N'2048 Stream Processors')
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (18, N'AMD', 10, 2, N'Radeon RX 6700 XT', NULL, NULL, NULL, NULL, 2620, 2620, NULL, NULL, NULL, NULL, N'MSI', N'Double Fans', N'3 x DisplayPort 1.4', N'1 x HDMI 2.1', N'PCI Express 4.0', 247, 12, 192, N'GDDR6', N'2 x 8-Pin', N'650', N'Triple Slot', N'2560 Stream Processors')
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (19, N'Nvidia', 11, 2, N'TUF-RTX3070TI-O8G-V2-GAMING', NULL, NULL, NULL, NULL, 1815, 1815, NULL, NULL, NULL, NULL, N'ASUS', N'Triple Fans', N'3 x DisplayPort 1.4a', N'2 x HDMI 2.1', N'PCI Express 4.0', 300, 8, 256, N'GDDR6X', N'2 x 8-Pin', N'750', N'2.7 Slot', N'6144')
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (20, N'Nvidia', 12, 2, N'GV-N3060GAMING OC-12GD (rev. 2.0)', NULL, NULL, NULL, NULL, 1837, 1837, NULL, NULL, NULL, NULL, N'GIGABYTE', N'WINDFORCE 3X', N'2 x DisplayPort 1.4a', N'2 x HDMI 2.1', N'PCI Express 4.0', 282, 12, 192, N'GDDR6', N'1 x 8-Pin', N'550', N'Dual Slot', N'3584')
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (21, N'Nvidia', 13, 2, N'RTX 4070 Ti GAMING X TRIO 12G', NULL, NULL, NULL, NULL, 2745, 2745, NULL, NULL, NULL, NULL, N'MSI', N'Triple Fans', N'3 x DisplayPort 1.4a', N'1 x HDMI 2.1a', N'PCI Express 4.0', 337, 12, 192, N'GDDR6X', N'1 x 16-Pin', N'750', N'N/A', N'7680')
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (22, N'Nvidia', 14, 2, N'ZT-A30610H-10MLHR', NULL, NULL, NULL, NULL, 1695, 1695, NULL, NULL, NULL, NULL, N'ZOTAC', N'Double Fans', N'3 x DisplayPort 1.4a', N'1 x HDMI 2.1', N'PCI Express 4.0', 222, 8, 256, N'GDDR6', N'8-Pin', N'650', N'Dual Slot', N'4864')
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (23, N'AMD', 15, 2, N'RX6950XT OCF 16G', NULL, NULL, NULL, NULL, 2279, 2143, NULL, NULL, NULL, NULL, N'ASRock', N'Triple Fans', N'3 x DisplayPort 1.4', N'1 x HDMI 2.1', N'PCI Express 4.0', 332, 16, 256, N'GDDR6', N'3 x 8-Pin', N'1000', N'Triple Slot', N'5120')
INSERT [dbo].[Attributes] ([Id], [Manufacturer], [ProductId], [AttributesType], [Model], [Socket], [CoreCount], [ThreadCount], [CacheL3], [BoostClockGpu], [CoreClockGpu], [TDP], [Graphics], [BaseClockCpu], [BoostClockCpu], [Brand], [Cooler], [DisplayPort], [HDMI], [Interface], [MaxGPULength], [Memory], [MemoryInterface], [MemoryType], [PowerConnector], [RecommendedPSU], [SlotWidth], [StreamProcessors]) VALUES (24, N'Nvidia', 16, 2, N'TUF-RTX3080TI-12G-GAMING', NULL, NULL, NULL, NULL, 1695, 1695, NULL, NULL, NULL, NULL, N'ASUS', N'Triple Fans', N'3 x DisplayPort 1.4a', N'2 x HDMI 2.1', N'PCI Express 4.0', 300, 12, 384, N'GDDR6X', N'2 x 8-Pin', N'850', N'2.7 Slot', N'10240')
SET IDENTITY_INSERT [dbo].[Attributes] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'CPUs / Processors')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'GPUs / Video Graphics Cards')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([Id], [ISO4217], [Symbol]) VALUES (1, N'EUR', N'€')
INSERT [dbo].[Currencies] ([Id], [ISO4217], [Symbol]) VALUES (2, N'HRK', N'kn')
SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (44, N'ef99204c-42fd-48b3-b376-3c918c2cc4a0.jpg', 2, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (46, N'471a34fd-b5f0-4ab8-9c7e-2486d36528d0.jpg', 3, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (61, N'680c3865-a3b8-422c-a8e9-7b3347675012.jpg', 1, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (62, N'380f0101-2164-4389-aa8f-f48296111fde.jpg', 1, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (63, N'350b49e4-9bf4-4f32-a1f6-1df23899d40b.jpg', 1, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (65, N'6df607df-e1d8-4b5c-9d51-f55eaa2b5915.jpg', 2, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (66, N'de8dc70c-2cbf-446c-8d0a-7f05f9b508e1.jpg', 3, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (67, N'308bc712-032c-468e-ad90-cffd303ac615.jpg', 4, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (68, N'70336f37-c44b-4683-8fcf-a47503dfc7f3.jpg', 4, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (69, N'cc357e6e-a5fe-41f0-970a-de97589a05e6.jpg', 4, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (70, N'068e4c9f-e44f-4923-8827-065e4267bb77.jpg', 5, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (71, N'11cba69e-3d6b-492b-a5b7-2268e75aa601.jpg', 5, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (72, N'fdf8e2a5-713b-43d8-b931-c838ddae8189.jpg', 5, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (73, N'6d28be42-72e8-488a-867f-89d06e40612c.jpg', 6, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (74, N'e444579a-90aa-4276-8b0c-7b9fc72cffd4.jpg', 6, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (75, N'a96a7553-eaaf-4ed6-a1c9-1a7ee0f716fe.jpg', 6, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (76, N'78d87209-6034-43b6-9e02-a28ea984d03b.jpg', 7, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (77, N'8ebea072-89b2-4be5-9175-86ef0c5af9b6.jpg', 7, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (78, N'c58ff3c0-2805-410f-a64e-f6bde8ae0f97.jpg', 8, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (79, N'55c837cd-e15d-4576-b700-a79c8265466c.jpg', 8, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (85, N'1a073bb7-43d1-464b-b78d-051c2ad2a676.jpg', 9, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (86, N'10cfded1-efe7-4680-b94a-eb713fd028f1.jpg', 9, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (87, N'077b82f6-8aec-4827-8a8b-922b329da91b.jpg', 9, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (88, N'635c724c-dbde-47ce-89ae-02e2136a544c.jpg', 9, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (89, N'39975122-bee6-4362-bc77-6009d445a1ef.jpg', 9, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (90, N'60115b7d-3700-4477-8e4b-d3d64061e44d.jpg', 10, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (91, N'3633d006-2320-435f-b725-e119b7caaa5a.jpg', 10, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (92, N'29b686cf-d0b5-4a45-8ba8-ff0f71c12762.jpg', 10, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (93, N'fc123dd7-cc2a-43a7-b9f9-afa060ecab8e.jpg', 10, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (94, N'bc488a04-320a-491d-a7b7-4be3514a45c0.png', 11, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (95, N'e7bdcf5f-2294-4dc0-aa94-17edbcd7eafe.png', 11, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (96, N'fbff74f6-6739-4241-a2be-74ddfbb20bae.png', 11, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (97, N'ac0d929e-c185-4ecf-9bfb-f56ca66a93a4.jpg', 12, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (98, N'e11ec46a-cd66-40b5-aeea-48b6b9411ceb.jpg', 12, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (99, N'03a84232-1405-466e-9761-fde5d448be27.jpg', 12, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (100, N'd5ddd5ff-b1e6-4272-8881-d7efceaf1e5e.jpg', 13, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (101, N'e8f5264a-1810-4eaa-a165-2cea9a018015.jpg', 13, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (102, N'32fe68fa-db98-41ea-963c-854e51e6c03d.jpg', 13, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (103, N'0368d3ba-71f3-4c37-b576-b859a6f9e111.jpg', 14, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (104, N'1ba46aad-490c-4875-b19e-d2d99b45bfff.jpg', 14, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (105, N'2c72ab9d-0fee-4f84-8521-190305318b48.jpg', 14, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (109, N'51bba329-42df-4df2-8571-ef367390db15.jpg', 15, 1)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (110, N'fcb3da3d-d62d-434a-ba6c-1aa54f789197.jpg', 15, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (111, N'5f7cc7f5-f740-4147-ac15-26c12db1f90f.jpg', 15, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (112, N'2c3a5514-478a-43c3-a612-093fb6740808.jpg', 16, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (113, N'eaf7848b-953f-4c74-a05d-a1563f6c3992.jpg', 16, 0)
INSERT [dbo].[Images] ([Id], [File], [ProductId], [MainImage]) VALUES (114, N'ea8dd9b9-c415-46df-bc29-adb9dd54b90e.jpg', 16, 1)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Newsletters] ON 

INSERT [dbo].[Newsletters] ([Id], [Email]) VALUES (1, N'mail@email.com')
SET IDENTITY_INSERT [dbo].[Newsletters] OFF
GO
SET IDENTITY_INSERT [dbo].[Prices] ON 

INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (46, 187.8, 1, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (47, 1412.78, 1, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (50, 398.6, 2, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (51, 2988.34, 2, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (52, 545, 3, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (53, 4106.78, 3, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (54, 84.55, 4, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (55, 637.09, 4, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (56, 190.49, 5, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (57, 1435.25, 5, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (58, 381, 6, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (59, 2870.65, 6, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (60, 111.26, 7, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (61, 838.29, 7, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (62, 588.05, 8, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (63, 4430.66, 8, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (66, 366.62, 9, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (67, 2760.776, 9, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (68, 2711.55, 10, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (69, 358.89, 10, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (70, 648.78, 11, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (71, 4886.67, 11, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (72, 376.87, 12, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (74, 867.87, 13, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (76, 408.98, 14, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (80, 895, 15, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (81, 6743.72, 15, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (82, 1460, 16, 1)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (83, 10995.17, 16, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (84, 3108.78, 14, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (85, 6596.94, 13, 2)
INSERT [dbo].[Prices] ([Id], [Value], [ProductId], [CurrencyId]) VALUES (86, 37145.04, 12, 2)
SET IDENTITY_INSERT [dbo].[Prices] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (1, N'AMD - Ryzen 5 5600X 4th Gen 6-core, 12-threads Unlocked Desktop Processor With Wraith Stealth Cooler', 10, 50, 10, 1, N'CPU Specifications', N'Ryzen 5 5600X', N'Be unstoppable with the unprecedented speed of the world’s best desktop processors. AMD Ryzen 5000 Series processors deliver the ultimate in high performance, whether you’re playing the latest games, designing the next skyscraper or crunching scientific data. With AMD Ryzen, you’re always in the lead.')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (2, N'AMD - Ryzen 9 5900X 4th Gen 12-core, 24-threads Unlocked Desktop Processor Without Cooler', 15, 38, 256, 1, N'CPU Specifications', N'Ryzen 9 5900X', N'Be unstoppable with the unprecedented speed of the world’s best desktop processors. AMD Ryzen 5000 Series processors deliver the ultimate in high performance, whether you’re playing the latest games, designing the next skyscraper or crunching scientific data. With AMD Ryzen, you’re always in the lead.')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (3, N'AMD - Ryzen 9 5950X 4th Gen 16-core, 32-threads Unlocked Desktop Processor Without Cooler', 15, 27, 156, 1, N'CPU Specifications', N'Ryzen 9 5950X', N'Be unstoppable with the unprecedented speed of the world’s best desktop processors. AMD Ryzen 5000 Series processors deliver the ultimate in high performance, whether you’re playing the latest games, designing the next skyscraper or crunching scientific data. With AMD Ryzen, you’re always in the lead.')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (4, N'AMD Ryzen 5 4500 3.6 GHz Six-Core AM4 Processor, Black - Black', 10, 78, 1023, 1, N'CPU Specifications', N'Ryzen 5 4500', N'Be unstoppable with the unprecedented speed of the world’s best desktop processors. AMD Ryzen 5000 Series processors deliver the ultimate in high performance, whether you’re playing the latest games, designing the next skyscraper or crunching scientific data. With AMD Ryzen, you’re always in the lead.')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (5, N'AMD - Ryzen 7 5700G 8-Core - 16-Thread - (4.6 GHz Max Boost) Unlocked Desktop Processor', 5, 15, 235, 1, N'CPU Specifications', N'Ryzen 7 5700G', N'Be unstoppable with the unprecedented speed of the world’s best desktop processors. AMD Ryzen 5000 Series processors deliver the ultimate in high performance, whether you’re playing the latest games, designing the next skyscraper or crunching scientific data. With AMD Ryzen, you’re always in the lead.')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (6, N'Intel - Core i7-11700K 11th Generation - 8 Core - 16 Thread - 3.6 to 5.0 GHz - LGA1200 - Unlocked Desktop Processor', 5, 76, 236, 1, N'CPU Specifications', N'Core i7-11700K', N'This desktop processor family features an innovative architecture designed for intelligent performance (AI), immersive display and graphics, plus enhanced tuning and expandability to put gamers and PC enthusiasts fully in control of real-world experiences. ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (7, N'Intel - Core i5-10400 10th Generation 6-Core - 12-Thread - 2.9 GHz (4.3 GHz Turbo) Socket LGA1200 Locked Desktop Processor', 3, 58, 352, 1, N'CPU Specifications', N'Core i5-10400', N'This desktop processor family features an innovative architecture designed for intelligent performance (AI), immersive display and graphics, plus enhanced tuning and expandability to put gamers and PC enthusiasts fully in control of real-world experiences. ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (8, N'Intel - Core i9-12900K Desktop Processor 16 (8P+8E) Cores up to 5.2 GHz Unlocked LGA1700 600 Series Chipset 125W', 0, 26, 45, 1, N'CPU Specifications', N'Core i9-12900K', N'This desktop processor family features an innovative architecture designed for intelligent performance (AI), immersive display and graphics, plus enhanced tuning and expandability to put gamers and PC enthusiasts fully in control of real-world experiences. ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (9, N'MSI - AMD Radeon RX 6600 XT MECH 2X 8G OC GDDR6 PCI Express 4.0 Gaming Graphics Card - Black', 2, 26, 45, 2, N'GPU Specifications', N'MSI - AMD Radeon RX 6600 XT MECH', N'The all new RDNA powered Radeon RX 6600 XT series for exceptional performance and High-fidelity gaming. Take control with RX 6600 XT series and experience powerful, accelerated gaming customized for you. Radeon RX 6600 XT series features new compute units, new instructions better suited for visual effects, and multi-level cache hierarchy for greatly reduced latency and highly responsive gaming. High-performance RDNA architecture was engineered to greatly enhance features like Radeon Image Sharpening, FidelityFX, and VR technologies3 for maximum performance and jaw-dropping gaming experiences. Get the competitive advantage with dramatically reduced input lag with Radeon Anti-Lag, get stutter-free, tear-free gaming with AMD Radeon FreeSync technology, and the latest Radeon Software for incredibly responsive and insanely immersive gameplay.')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (10, N'MSI - AMD Radeon RX 6700 XT MECH 2X 12G - 12GB GDDR6 - PCI Express 4.0 - Graphics Card - Black', 3, 26, 45, 2, N'GPU Specifications', N'MSI - AMD Radeon RX 6700 XT', N' Great gaming experiences are created by bending the rules. The all new RDNA powered Radeon RX 5700 XT series for exceptional performance and High-fidelity gaming. Take control with Radeon RX 5700 XT series and experience powerful, accelerated gaming customized for you. High-performance RDNA architecture was engineered to greatly enhance features like Radeon Image Sharpening, FidelityFX, and VR technologies for maximum performance and jaw-dropping gaming experiences. Get the competitive advantage with dramatically reduced input lag with Radeon Anti-Lag, get stutter-free, tear-free gaming with AMD Radeon FreeSync technology, and the latest Radeon Software for incredibly responsive and insanely immersive gameplay. Radeon RX 5700 XT series features new compute units, new instructions better suited for visual effects, and multi-level cache hierarchy for greatly reduced latency and highly responsive gaming. ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (11, N'ASUS - NVIDIA GeForce RTX 3070 V2 TUF 8GB GDDR6 PCI Express 4.0 Graphics Card - Black', 0, 26, 45, 2, N'GPU Specifications', N'ASUS - NVIDIA GeForce RTX 3070 V2 TUF', N' TUF Gaming GeForce RTX™ 3070 V2 OC Edition 8GB GDDR6 with LHR offers a buffed-up design that delivers chart-topping thermal performance. A new all-metal shroud houses three powerful axial-tech fans that utilize durable dual ball fan bearings. Fan rotation has been optimized for reduced turbulence. ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (12, N'GIGABYTE Gaming OC GeForce RTX 3060 12GB GDDR6 PCI Express 4.0 ATX Video Card GV-N3060GAMING OC-12GD (rev. 2.0) (LHR)', 0, 26, 45, 2, N'GPU Specifications', N'GIGABYTE - NVIDIA GeForce RTX 3060', N' NVIDIA Ampere Streaming Multiprocessors 2nd Generation RT Cores 3rd Generation Tensor Cores Powered by GeForce RTX 3060 Integrated with 12GB GDDR6 192-bit memory interface WINDFORCE 3X Cooling System with alternate spinning fans RGB Fusion 2.0 Protection metal back plate. ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (13, N'MSI Gaming (MSI) GeForce RTX 4070 Ti 12GB GDDR6X PCI Express 4.0 Video Card RTX 4070 Ti GAMING X TRIO 12G', 0, 26, 6, 2, N'GPU Specifications', N'MSI Gaming (MSI) GeForce RTX 4070 Ti 12GB', N' The NVIDIA GeForce RTX 4070 Ti delivers the ultra performance and features that enthusiast gamers and creators demand. Bring your games and creative projects to life with ray tracing and AI-powered graphics. It’s powered by the ultra-efficient NVIDIA Ada Lovelace architecture and up to 12GB of superfast G6X memory. ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (14, N'ZOTAC GAMING GeForce RTX 3060 Ti Twin Edge OC LHR 8GB GDDR6 256-bit 14 Gbps PCIE 4.0 Gaming Graphics Card, IceStorm 2.0 Advanced Cooling, Active Fan Control, FREEZE Fan Stop ZT-A30610H-10MLHR', 15, 54, 89, 2, N'GPU Specifications', N'ZOTAC GAMING GeForce RTX 3060 Ti Twin Edge OC LHR 8GB', N' Get Amplified with the all-new ZOTAC GAMING GeForce RTX 30 Series based on the NVIDIA Ampere architecture. Built with enhanced RT Cores and Tensor Cores, new streaming multiprocessors, and superfast GDDR6 memory, the ZOTAC GAMING GeForce RTX 3060 Ti Twin Edge OC LHR gives rise to amplified gaming with high graphics fidelity. Features: - 2nd Gen Ray Tracing Cores - 3rd Gen Tensor Cores - White LED Logo Lighting - IceStorm 2.0 Advanced Cooling - Active Fan Control - FREEZE Fan Stop - Metal Backplate - FireStorm Utility - VR Ready - LHR 25 MH/s ETH hash rate (est.). ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (15, N'ASRock OC Formula Radeon RX 6950 XT 16GB GDDR6 PCI Express 4.0 Video Card RX6950XT OCF 16G', 0, 34, 23, 2, N'GPU Specifications', N'ASRock OC Formula Radeon RX 6950 XT 16GB', N' ASRock RX6950XT OCF 16G Graphics Board, AMD Radeon RX6950XT ')
INSERT [dbo].[Products] ([Id], [Name], [Discount], [InStock], [Sold], [CategoryId], [SelectedSpecification], [ShortName], [Description]) VALUES (16, N'ASUS - NVIDIA GeForce RTX 3080 Ti TUF 12GB GDDR6 PCI Express 4.0 Graphics Card - Black', 9, 12, 4, 2, N'GPU Specifications', N'ASUS - NVIDIA GeForce RTX 3080 Ti TUF', N' The TUF Gaming GeForce RTX 3070 Ti O8GB GDDR6X features three Axial-tech Fans and a MaxContact heatsink to deliver best-in-class thermal performance. Military-grade Capacitors and other TUF components enhance durability and performance. ')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (1, N'Marko', N'Very good product', N'mark@mail.com', 4, CAST(N'2023-02-03T17:27:38.4266667' AS DateTime2), 1)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (2, N'John', N'This sucks', N'john56@mail.com', 2, CAST(N'2023-02-03T19:51:35.4000000' AS DateTime2), 1)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (4, N'wayn87', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Volutpat consequat mauris nunc congue nisi. Aenean et tortor at risus viverra. Vitae semper quis lectus nulla at. Ultrices neque ornare aenean euismod elementum nisi quis eleifend.', N'lolko@email.com', 5, CAST(N'2023-02-03T19:53:05.5133333' AS DateTime2), 1)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (5, N'polki', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sollicitudin tempor id eu nisl. Risus in hendrerit gravida rutrum quisque non tellus orci ac. Id diam vel quam elementum. Donec adipiscing tristique risus nec feugiat.', N'lol@email.com', 5, CAST(N'2023-02-03T19:53:31.1700000' AS DateTime2), 1)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (6, NULL, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'lori@mail.com', 4, CAST(N'2023-02-04T00:31:00.5300000' AS DateTime2), 1)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (7, NULL, N'Ultrices neque ornare aenean euismod elementum nisi quis eleifend.', N'kolo@mail.com', 1, CAST(N'2023-02-04T00:35:22.1666667' AS DateTime2), 1)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (8, N'mario', N'Volutpat consequat mauris nunc congue nisi. Aenean et tortor at risus viverra. Vitae semper quis lectus nulla at. Ultrices neque ornare aenean euismod elementum nisi quis eleifend.', N'mario@super.com', 5, CAST(N'2023-02-04T00:40:45.5100000' AS DateTime2), 1)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (9, NULL, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Volutpat consequat mauris nunc congue nisi. Aenean et tortor at risus viverra', N'johny@mail.com', 5, CAST(N'2023-02-04T00:47:08.6733333' AS DateTime2), 1)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (10, N'John Doe', N'Great product, highly recommend it!', N'johndoe@example.com', 5, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (11, N'Jane Doe', N'Not impressed, wouldn''t buy it again', N'janedoe@example.com', 2, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (12, N'Jim Smith', N'It''s okay, but not worth the price', N'jimsmith@example.com', 3, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (13, N'Lisa Brown', N'I love this product, it''s amazing!', N'lisabrown@example.com', 5, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (14, N'Bob Johnson', N'Just what I was looking for, thanks!', N'bobjohnson@example.com', 4, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (15, N'John Doe', N'Great product, highly recommend it!', N'johndoe@example.com', 5, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (16, N'Jane Doe', N'Not impressed, wouldn''t buy it again', N'janedoe@example.com', 2, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (17, N'Jim Smith', N'It''s okay, but not worth the price', N'jimsmith@example.com', 3, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (18, N'Lisa Brown', N'I love this product, it''s amazing!', N'lisabrown@example.com', 5, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (19, N'Bob Johnson', N'Just what I was looking for, thanks!', N'bobjohnson@example.com', 4, CAST(N'2023-02-05T19:18:09.0066667' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (20, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (21, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (22, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (23, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (24, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 2)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (25, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (26, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (27, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (28, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (29, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:24:15.3333333' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (30, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (31, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (32, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 3)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (33, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 4)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (34, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 4)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (35, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 5)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (36, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 5)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (37, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 5)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (38, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 5)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (39, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:25:11.5633333' AS DateTime2), 6)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (40, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 6)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (41, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 6)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (42, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 6)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (43, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 6)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (44, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 7)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (45, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 7)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (46, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 8)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (47, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 8)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (48, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 8)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (49, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:25:38.2700000' AS DateTime2), 8)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (50, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 9)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (51, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 9)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (52, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 10)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (53, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 10)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (54, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 10)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (55, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 10)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (56, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 11)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (57, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 15)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (58, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 14)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (59, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:26:15.1566667' AS DateTime2), 13)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (60, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 16)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (61, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 16)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (62, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 15)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (63, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 15)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (64, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 16)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (65, N'Tom Johnson', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent auctor aliquet enim, ac suscipit elit commodo at.', N'tomjohnson@example.com', 5, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 12)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (66, N'Sara Smith', N'Vestibulum vitae neque quis dolor varius semper id id massa. Integer auctor est eu metus dapibus, eu scelerisque sapien.', N'sarasmith@example.com', 4, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 13)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (67, N'Mike Brown', N'Proin porta justo in tincidunt auctor. Sed pharetra libero eget est dapibus congue.', N'mikebrown@example.com', 3, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 13)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (68, N'Amy Doe', N'Nullam euismod, dui vel eleifend placerat, mauris nunc malesuada nulla, id blandit nulla orci eget elit.', N'amydoe@example.com', 2, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 12)
INSERT [dbo].[Reviews] ([Id], [Name], [Description], [Email], [StarRating], [CreatedDate], [ProductId]) VALUES (69, N'David Wilson', N'In id congue est. Integer bibendum euismod sem, ut tempus ligula placerat quis.', N'davidwilson@example.com', 4, CAST(N'2023-02-05T19:26:56.4600000' AS DateTime2), 12)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Wishlists] ON 

INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (29, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (30, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (31, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (32, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (33, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (34, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (35, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (36, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (37, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (38, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (39, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (40, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (41, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (42, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (43, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (44, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (45, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (46, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (47, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (48, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (49, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (50, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (51, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (52, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (53, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (54, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (55, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (56, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (57, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (58, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (59, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (60, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (61, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (62, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (63, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (64, NULL)
INSERT [dbo].[Wishlists] ([Id], [UserId]) VALUES (65, NULL)
SET IDENTITY_INSERT [dbo].[Wishlists] OFF
GO
/****** Object:  Index [IX_Adresses_BillingOrderId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Adresses_BillingOrderId] ON [dbo].[Adresses]
(
	[BillingOrderId] ASC
)
WHERE ([BillingOrderId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Adresses_ShippingOrderId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Adresses_ShippingOrderId] ON [dbo].[Adresses]
(
	[ShippingOrderId] ASC
)
WHERE ([ShippingOrderId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Attributes_ProductId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Attributes_ProductId] ON [dbo].[Attributes]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Carts_UserId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Carts_UserId] ON [dbo].[Carts]
(
	[UserId] ASC
)
WHERE ([UserId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Images_ProductId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_Images_ProductId] ON [dbo].[Images]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Prices_CurrencyId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_Prices_CurrencyId] ON [dbo].[Prices]
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Prices_ProductId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_Prices_ProductId] ON [dbo].[Prices]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCart_CartId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_ProductCart_CartId] ON [dbo].[ProductCart]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCart_ProductId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_ProductCart_ProductId] ON [dbo].[ProductCart]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductOrders_OrderId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_ProductOrders_OrderId] ON [dbo].[ProductOrders]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductWishlist_WishlistsId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_ProductWishlist_WishlistsId] ON [dbo].[ProductWishlist]
(
	[WishlistsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reviews_ProductId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_ProductId] ON [dbo].[Reviews]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wishlists_UserId]    Script Date: 7.2.2023. 21:01:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Wishlists_UserId] ON [dbo].[Wishlists]
(
	[UserId] ASC
)
WHERE ([UserId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adresses] ADD  DEFAULT (N'') FOR [Street]
GO
ALTER TABLE [dbo].[AspNetRoles] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Attributes] ADD  DEFAULT (N'') FOR [Model]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [SessionId]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [CratedDate]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT (N'') FOR [CurrencyISO4217]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Price]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT (N'') FOR [ShortName]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT (N'') FOR [CurrencySymbol]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [SelectedSpecification]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [ShortName]
GO
ALTER TABLE [dbo].[Reviews] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Reviews] ADD  DEFAULT ((0)) FOR [ProductId]
GO
ALTER TABLE [dbo].[Adresses]  WITH CHECK ADD  CONSTRAINT [FK_Adresses_Orders_BillingOrderId] FOREIGN KEY([BillingOrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Adresses] CHECK CONSTRAINT [FK_Adresses_Orders_BillingOrderId]
GO
ALTER TABLE [dbo].[Adresses]  WITH CHECK ADD  CONSTRAINT [FK_Adresses_Orders_ShippingOrderId] FOREIGN KEY([ShippingOrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Adresses] CHECK CONSTRAINT [FK_Adresses_Orders_ShippingOrderId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Attributes]  WITH CHECK ADD  CONSTRAINT [FK_Attributes_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attributes] CHECK CONSTRAINT [FK_Attributes_Products_ProductId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Products_ProductId]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Prices_Currencies_CurrencyId] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Prices_Currencies_CurrencyId]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Prices_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Prices_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductCart]  WITH CHECK ADD  CONSTRAINT [FK_ProductCart_Carts_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[ProductCart] CHECK CONSTRAINT [FK_ProductCart_Carts_CartId]
GO
ALTER TABLE [dbo].[ProductCart]  WITH CHECK ADD  CONSTRAINT [FK_ProductCart_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCart] CHECK CONSTRAINT [FK_ProductCart_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrders_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[ProductOrders] CHECK CONSTRAINT [FK_ProductOrders_Orders_OrderId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductWishlist]  WITH CHECK ADD  CONSTRAINT [FK_ProductWishlist_Products_ProductsId] FOREIGN KEY([ProductsId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductWishlist] CHECK CONSTRAINT [FK_ProductWishlist_Products_ProductsId]
GO
ALTER TABLE [dbo].[ProductWishlist]  WITH CHECK ADD  CONSTRAINT [FK_ProductWishlist_Wishlists_WishlistsId] FOREIGN KEY([WishlistsId])
REFERENCES [dbo].[Wishlists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductWishlist] CHECK CONSTRAINT [FK_ProductWishlist_Wishlists_WishlistsId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Products_ProductId]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlists_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlists_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [WebShop] SET  READ_WRITE 
GO
