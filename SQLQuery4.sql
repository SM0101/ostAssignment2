USE [master]
GO
/****** Object:  Database [ostAssignment2]    Script Date: 2025-03-22 12:05:01 PM ******/
CREATE DATABASE [ostAssignment2]

USE [ostAssignment2]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2025-03-22 12:05:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL
) ON [PRIMARY]
GO

INSERT INTO Users(UserName,Password)
	Values('Minhaj','123456')