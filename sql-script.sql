USE [master]
GO
/****** Object:  Database [rentacar]    Script Date: 21.08.2020 23:10:27 ******/
CREATE DATABASE [rentacar] ON  PRIMARY 
( NAME = N'rentacar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\rentacar.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'rentacar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\rentacar_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [rentacar] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [rentacar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [rentacar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [rentacar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [rentacar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [rentacar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [rentacar] SET ARITHABORT OFF 
GO
ALTER DATABASE [rentacar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [rentacar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [rentacar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [rentacar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [rentacar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [rentacar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [rentacar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [rentacar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [rentacar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [rentacar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [rentacar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [rentacar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [rentacar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [rentacar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [rentacar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [rentacar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [rentacar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [rentacar] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [rentacar] SET  MULTI_USER 
GO
ALTER DATABASE [rentacar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [rentacar] SET DB_CHAINING OFF 
GO
USE [rentacar]
GO
/****** Object:  Table [dbo].[admins]    Script Date: 21.08.2020 23:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](500) NULL,
	[password] [varchar](500) NULL,
	[name] [varchar](500) NULL,
	[token] [varchar](500) NULL,
 CONSTRAINT [PK_admins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[announcements]    Script Date: 21.08.2020 23:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[announcements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](max) NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_announcements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cars]    Script Date: 21.08.2020 23:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cars](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brand] [varchar](100) NULL,
	[model] [varchar](100) NULL,
	[color] [varchar](100) NULL,
	[km] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[period] [varchar](50) NULL,
	[title] [varchar](255) NULL,
	[img] [varchar](max) NULL,
	[modelyear] [varchar](50) NULL,
	[rank] [int] NULL,
 CONSTRAINT [PK_cars] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservations]    Script Date: 21.08.2020 23:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[phone] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[reservationtime] [varchar](50) NULL,
	[cars] [varchar](50) NULL,
	[isclose] [bit] NULL,
	[reservationnot] [varchar](max) NULL,
	[reservationadminnot] [varchar](max) NULL,
	[reservationcode] [varchar](50) NULL,
 CONSTRAINT [PK_reservations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [rentacar] SET  READ_WRITE 
GO
