USE [master]
GO

/****** Object:  Database [customer]    Script Date: 21/11/2020 12:30:03 ******/
CREATE DATABASE [customer] ON  PRIMARY 
( NAME = N'customer', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\customer.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'customer_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\customer_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

EXEC dbo.sp_dbcmptlevel @dbname=N'customer', @new_cmptlevel=90
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [customer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [customer] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [customer] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [customer] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [customer] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [customer] SET ARITHABORT OFF 
GO

ALTER DATABASE [customer] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [customer] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [customer] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [customer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [customer] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [customer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [customer] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [customer] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [customer] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [customer] SET  DISABLE_BROKER 
GO

ALTER DATABASE [customer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [customer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [customer] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [customer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [customer] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [customer] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [customer] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [customer] SET  MULTI_USER 
GO

ALTER DATABASE [customer] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [customer] SET DB_CHAINING OFF 
GO

ALTER DATABASE [customer] SET  READ_WRITE 
GO

USE [customer]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 21/11/2020 12:27:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] PRIMARY KEY default NEWID(),
	[Name] [varchar](100) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Cep] [varchar](15) NULL,
	[Adress] [varchar](100) NULL,
	[Number] [varchar](10) NULL,
	[Complement] [varchar](50) NULL,
	[Neighborhood] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[City] [varchar](100) NULL,
	[Date] [datetime] NOT NULL,
	[Version] [int] NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY]
GO

USE [customer]
GO

/****** Object:  Table [dbo].[User]    Script Date: 21/11/2020 12:28:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] PRIMARY KEY default NEWID(),
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Version] [int] NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY]
GO