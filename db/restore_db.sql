USE [master]
GO

/****** Object:  Database [Customers]    Script Date: 2022/08/21 12:13:33 ******/
CREATE DATABASE [Customers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Customers', FILENAME = N'/var/opt/mssql/data/Customers.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Customers_log', FILENAME = N'/var/opt/mssql/data/Customers_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Customers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Customers] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Customers] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Customers] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Customers] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Customers] SET ARITHABORT OFF 
GO

ALTER DATABASE [Customers] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Customers] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Customers] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Customers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Customers] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Customers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Customers] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Customers] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Customers] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Customers] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Customers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Customers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Customers] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Customers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Customers] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Customers] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Customers] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Customers] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Customers] SET  MULTI_USER 
GO

ALTER DATABASE [Customers] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Customers] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Customers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Customers] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Customers] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Customers] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Customers] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Customers] SET  READ_WRITE 
GO



USE [Customers]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2022/08/21 11:58:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerDetail]    Script Date: 2022/08/21 11:58:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PhoneNumber] [varchar](31) NULL,
	[Address] [varchar](511) NULL,
	[ModifiedDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerNote]    Script Date: 2022/08/21 11:58:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerNote](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Note] [varchar](max) NOT NULL,
 CONSTRAINT [PK_CustomerNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2022/08/21 11:58:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CustomerDetail] ADD  CONSTRAINT [DF_CustomerDetails_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Customer] FOREIGN KEY([Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Customer]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Status]
GO
ALTER TABLE [dbo].[CustomerDetail]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetail_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerDetail] CHECK CONSTRAINT [FK_CustomerDetail_Customer]
GO
ALTER TABLE [dbo].[CustomerNote]  WITH CHECK ADD  CONSTRAINT [FK_CustomerNote_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerNote] CHECK CONSTRAINT [FK_CustomerNote_Customer]
GO

use [Customers]
insert into Status select 0, 'Prospective'
insert into Status select 1, 'Current'
insert into Status select 2, 'Non-active'

insert into [Customers].[dbo].[Customer] SELECT 'customer 1',0, getdate()
insert into [Customers].[dbo].[Customer] SELECT 'customer 2',1, getdate()
insert into [Customers].[dbo].[Customer] SELECT 'customer 3',2, getdate()

insert into [Customers].[dbo].[CustomerNote] SELECT 0, 0, 'test note 1'
insert into [Customers].[dbo].[CustomerNote] SELECT 1, 1, 'test note 2'
insert into [Customers].[dbo].[CustomerNote] SELECT 2, 2, 'test note 3'