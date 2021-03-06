USE [master]
GO
/****** Object:  Database [TestDb]    Script Date: 09/11/2016 10:52:45 ******/
CREATE DATABASE [TestDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\TestDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\TestDb_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestDb] SET  MULTI_USER 
GO
ALTER DATABASE [TestDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TestDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TestDb]
GO
/****** Object:  Table [dbo].[tblTransaction]    Script Date: 09/11/2016 10:52:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransaction](
	[Account] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CurrencyCode] [nvarchar](5) NULL,
	[Amount] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1AB"', N'"25"', N'USD', CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1EA"', N'"25"', N'GBP', CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1ED"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1EE"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1HB"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1HE"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1HJ"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1HL"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1JG"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1LB"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1LQ"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NE"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NJ"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NN"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NW"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NZ"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1QG"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1AB"', N'"25"', N'USD', CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1EA"', N'"25"', N'GBP', CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1ED"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1EE"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1HB"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1HE"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1HJ"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1HL"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1JG"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1LB"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1LQ"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NE"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NJ"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NN"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NW"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1NZ"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[tblTransaction] ([Account], [Description], [CurrencyCode], [Amount]) VALUES (N'"CH1 1QG"', N'"25"', NULL, CAST(16.00 AS Decimal(18, 2)))
/****** Object:  StoredProcedure [dbo].[TransactionDelete]    Script Date: 09/11/2016 10:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionDelete]
	@Id as nvarchar(MAX)
AS
BEGIN
	delete from tblTransaction
	where Account = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[TransactionGetAll]    Script Date: 09/11/2016 10:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionGetAll]
AS
BEGIN
	select * from tblTransaction
END

GO
/****** Object:  StoredProcedure [dbo].[TransactionGetById]    Script Date: 09/11/2016 10:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionGetById]
	@Id as nvarchar(MAX)
AS
BEGIN
	select * from tblTransaction
	where Account = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[TransactionUpdate]    Script Date: 09/11/2016 10:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TransactionUpdate]
 	-- Add the parameters for the stored procedure here
 	@Id nvarchar(MAX),		
 	@Description	nvarchar(MAX),
 	@CurrencyCode	nvarchar(50),
 	@Amount decimal(10,2)
 
 AS
 BEGIN
 
 UPDATE tblTransaction	
 SET	[Description] = @Description,
 	CurrencyCode = @CurrencyCode,
 	[Amount] = @Amount
 WHERE [Account] = @Id  
 END

GO
USE [master]
GO
ALTER DATABASE [TestDb] SET  READ_WRITE 
GO
