USE [master]
GO
/****** Object:  Database [dbfloralshop]    Script Date: 12/1/2024 11:35:40 PM ******/
CREATE DATABASE [dbfloralshop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbfloralshop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\dbfloralshop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbfloralshop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\dbfloralshop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbfloralshop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbfloralshop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbfloralshop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbfloralshop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbfloralshop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbfloralshop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbfloralshop] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbfloralshop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbfloralshop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbfloralshop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbfloralshop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbfloralshop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbfloralshop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbfloralshop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbfloralshop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbfloralshop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbfloralshop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbfloralshop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbfloralshop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbfloralshop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbfloralshop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbfloralshop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbfloralshop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbfloralshop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbfloralshop] SET RECOVERY FULL 
GO
ALTER DATABASE [dbfloralshop] SET  MULTI_USER 
GO
ALTER DATABASE [dbfloralshop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbfloralshop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbfloralshop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbfloralshop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbfloralshop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbfloralshop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbfloralshop', N'ON'
GO
ALTER DATABASE [dbfloralshop] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbfloralshop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbfloralshop]
GO
/****** Object:  Table [dbo].[Bouquet]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bouquet](
	[BouquetID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[OccasionID] [int] NULL,
	[Image] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[BouquetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[BouquetID] [int] NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] NOT NULL,
	[FullName] [varchar](255) NULL,
	[CNIC] [varchar](20) NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[PAddress] [varchar](255) NOT NULL,
	[Picture] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](500) NOT NULL,
	[OccasionID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Occasion]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occasion](
	[OccasionID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OccasionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[DeliveryDate] [date] NOT NULL,
	[RecipientName] [nvarchar](100) NOT NULL,
	[RecipientAddress] [nvarchar](255) NOT NULL,
	[RecipientPhone] [nvarchar](15) NOT NULL,
	[MessageID] [int] NULL,
	[CustomMessage] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[BouquetID] [int] NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[PaymentStatus] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/1/2024 11:35:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [varchar](255) NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Occasion] ON 
GO
INSERT [dbo].[Occasion] ([OccasionID], [Name]) VALUES (10, N'Birthday')
GO
INSERT [dbo].[Occasion] ([OccasionID], [Name]) VALUES (5, N'Celebration vibes')
GO
SET IDENTITY_INSERT [dbo].[Occasion] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Password], [Role], [Address], [Phone]) VALUES (1, N'Siraj', N'siraj27@gmqail.com', N'123456', N'admin', N'jadklvnkjjdjvh', N'989332')
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Password], [Role], [Address], [Phone]) VALUES (6, N'sameer', N'sam@gmail.com', N'karachi', N'User', N'lahore', N'03237293232')
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Password], [Role], [Address], [Phone]) VALUES (7, N'samar', N'samar@gmail.com', N'ghnaiok', N'User', N'dufilane', N'03152386871')
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Password], [Role], [Address], [Phone]) VALUES (8, N'azan', N'azan@gmail.com', N'azanslam', N'User', N'j,kuikitk', N'03152383124')
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Password], [Role], [Address], [Phone]) VALUES (10, N'ahmed', N'ahmed@gmail.com', N'ahmedrza', N'User', N'Golimar karachi', N'8313432373')
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Password], [Role], [Address], [Phone]) VALUES (1010, N'daniyal', N'daniyal@gmail.com', N'daniya', N'User', N'djdncdjlcndsejirjr', N'92362387463')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Occasion__737584F68214E7F3]    Script Date: 12/1/2024 11:35:41 PM ******/
ALTER TABLE [dbo].[Occasion] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534C2141E23]    Script Date: 12/1/2024 11:35:41 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bouquet]  WITH CHECK ADD FOREIGN KEY([OccasionID])
REFERENCES [dbo].[Occasion] ([OccasionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([BouquetID])
REFERENCES [dbo].[Bouquet] ([BouquetID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD FOREIGN KEY([OccasionID])
REFERENCES [dbo].[Occasion] ([OccasionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([BouquetID])
REFERENCES [dbo].[Bouquet] ([BouquetID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD CHECK  (([PaymentMethod]='Cash' OR [PaymentMethod]='Debit Card' OR [PaymentMethod]='Credit Card'))
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD CHECK  (([PaymentStatus]='Pending' OR [PaymentStatus]='Paid'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Role]='Admin' OR [Role]='User'))
GO
USE [master]
GO
ALTER DATABASE [dbfloralshop] SET  READ_WRITE 
GO

select * from Users