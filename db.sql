USE [master]
GO
/****** Object:  Database [Polling_DB]    Script Date: 10/1/2020 5:14:42 PM ******/
CREATE DATABASE [Polling_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Polling_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Polling_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Polling_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Polling_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Polling_DB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Polling_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Polling_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Polling_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Polling_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Polling_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Polling_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Polling_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Polling_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Polling_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Polling_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Polling_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Polling_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Polling_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Polling_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Polling_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Polling_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Polling_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Polling_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Polling_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Polling_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Polling_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Polling_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Polling_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Polling_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [Polling_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Polling_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Polling_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Polling_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Polling_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Polling_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Polling_DB] SET QUERY_STORE = OFF
GO
USE [Polling_DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Polling_DB]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 10/1/2020 5:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QID] [int] NULL,
	[AnswerDesc] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_Answer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 10/1/2020 5:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedUserID] [int] NULL,
	[QuestionDesc] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Question] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/1/2020 5:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](200) NULL,
	[IsAdmin] [bigint] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voting]    Script Date: 10/1/2020 5:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[QID] [int] NULL,
	[AID] [int] NULL,
 CONSTRAINT [PK_tbl_Voting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (1, 1, N'Black')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (2, 1, N'White')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (3, 1, N'Silver')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (4, 1, N'Other')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (5, 2, N'V6')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (6, 2, N'V8')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (7, 2, N'V12')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (8, 2, N'Other')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (9, 3, N'Sport')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (10, 3, N'SUV')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (11, 3, N'Sedan')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (12, 3, N'Hybrid')
INSERT [dbo].[Answer] ([ID], [QID], [AnswerDesc]) VALUES (13, 3, N'Coupe')
SET IDENTITY_INSERT [dbo].[Answer] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([ID], [CreatedUserID], [QuestionDesc]) VALUES (1, 1, N'What is your the color of you car?')
INSERT [dbo].[Question] ([ID], [CreatedUserID], [QuestionDesc]) VALUES (2, 1, N'What is the engine power of your car ?')
INSERT [dbo].[Question] ([ID], [CreatedUserID], [QuestionDesc]) VALUES (3, 1, N'What is the type of your car?')
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [FullName], [UserName], [Password], [IsAdmin]) VALUES (1, N'Han Myint Tun', N'han', N'$s2$16384$8$1$knVQSQxHxlkQlgxP2Zulnt3lpoRcOumI5DPA7EXG2TM=$0xeutc2WNCp2mxXsoFikD1Q79bt+zD6E5rN1dp5ylIM=', 0)
INSERT [dbo].[User] ([ID], [FullName], [UserName], [Password], [IsAdmin]) VALUES (2, N'Ester Tan', N'ester', N'$s2$16384$8$1$Si6rJzVp/43slveMcUFl7LjoT4jxJYQvwdUw3N+svP4=$b4z1jbWn0p06y3d4y2V08MPv1XCV7TNsAk4eGxl5LqM=', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Voting] ON 

INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (1, 2, 1, 2)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (2, 2, 2, 7)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (3, 2, 3, 11)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (4, 2, 1, 1)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (5, 2, 2, 5)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (6, 2, 3, 10)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (7, 2, 1, 4)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (8, 2, 2, 8)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (9, 2, 3, 12)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (10, 2, 1, 2)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (11, 2, 2, 8)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (12, 2, 3, 13)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (13, 2, 1, 2)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (14, 2, 2, 5)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (15, 2, 3, 12)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (16, 1, 1, 4)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (17, 1, 2, 8)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (18, 1, 1, 1)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (19, 1, 2, 8)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (20, 1, 3, 10)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (21, 1, 1, 2)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (22, 1, 2, 7)
INSERT [dbo].[Voting] ([ID], [UserID], [QID], [AID]) VALUES (23, 1, 3, 11)
SET IDENTITY_INSERT [dbo].[Voting] OFF
USE [master]
GO
ALTER DATABASE [Polling_DB] SET  READ_WRITE 
GO
