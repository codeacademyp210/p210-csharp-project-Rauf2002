USE [master]
GO
/****** Object:  Database [Academy]    Script Date: 31.05.2019 17:20:52 ******/
CREATE DATABASE [Academy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Academy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Academy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Academy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Academy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Academy] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Academy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Academy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Academy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Academy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Academy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Academy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Academy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Academy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Academy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Academy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Academy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Academy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Academy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Academy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Academy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Academy] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Academy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Academy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Academy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Academy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Academy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Academy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Academy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Academy] SET RECOVERY FULL 
GO
ALTER DATABASE [Academy] SET  MULTI_USER 
GO
ALTER DATABASE [Academy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Academy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Academy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Academy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Academy] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Academy', N'ON'
GO
ALTER DATABASE [Academy] SET QUERY_STORE = OFF
GO
USE [Academy]
GO
/****** Object:  Table [dbo].[AcademyInfo]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademyInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classrooms]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classrooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education Programs]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education Programs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Price] [int] NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Phone] [nvarchar](30) NOT NULL,
	[PositionId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[Salary] [int] NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ClassroomId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[MentorId] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[EducationId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialities]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](30) NOT NULL,
	[Fee] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Deadline] [datetime] NOT NULL,
	[GroupId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 31.05.2019 17:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[SpecialityId] [int] NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Phone] [nvarchar](30) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AcademyInfo] ON 

INSERT [dbo].[AcademyInfo] ([Id], [Name], [Address], [Phone], [Status]) VALUES (1, N'Code Academy', N'Nizami street 203B, AF Business House, second floor', N'+994125552525', 1)
SET IDENTITY_INSERT [dbo].[AcademyInfo] OFF
SET IDENTITY_INSERT [dbo].[Classrooms] ON 

INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (1, N'Titan', 1)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (2, N'Mercury', 1)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (3, N'Mars', 1)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (4, N'Neptune', 1)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (5, N'Jupiter', 1)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (6, N'Moon', 1)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (7, N'Pluto', 1)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (8, N'Venus', 1)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (9, N'Earth', 0)
INSERT [dbo].[Classrooms] ([Id], [Name], [Status]) VALUES (10, N'876', 0)
SET IDENTITY_INSERT [dbo].[Classrooms] OFF
SET IDENTITY_INSERT [dbo].[Education Programs] ON 

INSERT [dbo].[Education Programs] ([Id], [Name], [Price], [Status]) VALUES (1, N'Programming', 3500, 1)
INSERT [dbo].[Education Programs] ([Id], [Name], [Price], [Status]) VALUES (2, N'Digital Marketing', 3000, 1)
INSERT [dbo].[Education Programs] ([Id], [Name], [Price], [Status]) VALUES (3, N'Graphic and Web Design', 3200, 1)
INSERT [dbo].[Education Programs] ([Id], [Name], [Price], [Status]) VALUES (4, N'3D Modeling', 3000, 1)
INSERT [dbo].[Education Programs] ([Id], [Name], [Price], [Status]) VALUES (5, N'System Administrator', 3300, 1)
INSERT [dbo].[Education Programs] ([Id], [Name], [Price], [Status]) VALUES (6, N'Ms Office', 2900, 1)
INSERT [dbo].[Education Programs] ([Id], [Name], [Price], [Status]) VALUES (7, N'IELTS', 180, 0)
SET IDENTITY_INSERT [dbo].[Education Programs] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [Name], [Surname], [Email], [Phone], [PositionId], [StartTime], [Salary], [Status]) VALUES (1, N'Rauf', N'Allahverdiyev', N'raufsa@code.edu.az', N'+994508507575', 1, CAST(N'2019-09-23T16:07:47.000' AS DateTime), 14000, 1)
INSERT [dbo].[Employees] ([Id], [Name], [Surname], [Email], [Phone], [PositionId], [StartTime], [Salary], [Status]) VALUES (3, N'Togrul', N'Rzazade', N'togrulrr@code.edu.az', N'+994559491917', 5, CAST(N'2020-06-01T22:46:06.000' AS DateTime), 2000, 1)
INSERT [dbo].[Employees] ([Id], [Name], [Surname], [Email], [Phone], [PositionId], [StartTime], [Salary], [Status]) VALUES (4, N'Zaur', N'Allahverdiyev', N'zaursa@code.edu.az', N'+994504530100', 5, CAST(N'2019-06-02T22:50:28.000' AS DateTime), 6000, 1)
INSERT [dbo].[Employees] ([Id], [Name], [Surname], [Email], [Phone], [PositionId], [StartTime], [Salary], [Status]) VALUES (15, N'Tamerlan', N'Letifli', N'tamerlan@code.edu.az', N'+994513291029', 6, CAST(N'2019-05-25T00:43:24.000' AS DateTime), 8000, 1)
INSERT [dbo].[Employees] ([Id], [Name], [Surname], [Email], [Phone], [PositionId], [StartTime], [Salary], [Status]) VALUES (16, N'Nicat', N'Abdullayev', N'nicat@code.edu.az', N'+994517552717', 7, CAST(N'2019-05-25T15:33:07.000' AS DateTime), 1000, 1)
INSERT [dbo].[Employees] ([Id], [Name], [Surname], [Email], [Phone], [PositionId], [StartTime], [Salary], [Status]) VALUES (17, N'Aqil', N'Atakisiyev', N'aqil@code.edu.az', N'+994702111999', 7, CAST(N'2019-06-08T16:28:16.000' AS DateTime), 1000, 1)
INSERT [dbo].[Employees] ([Id], [Name], [Surname], [Email], [Phone], [PositionId], [StartTime], [Salary], [Status]) VALUES (18, N'John', N'Doe', N'john@code.edu.az', N'+14001010', 7, CAST(N'2019-06-26T12:11:22.000' AS DateTime), 100, 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Grades] ON 

INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (6, 90, 2, 5, 1)
INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (14, 80, 5, 2, 1)
INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (22, 50, 1, 6, 1)
INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (24, 90, 3, 2, 1)
INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (25, 88, 4, 4, 1)
INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (26, 33, 6, 2, 1)
INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (27, 55, 6, 6, 1)
INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (29, 50, 3, 6, 1)
INSERT [dbo].[Grades] ([Id], [Grade], [StudentId], [TaskId], [Status]) VALUES (30, 70, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Grades] OFF
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [Name], [ClassroomId], [TeacherId], [MentorId], [Capacity], [EducationId], [Status]) VALUES (2, N'P210', 1, 1, 16, 17, 1, 1)
INSERT [dbo].[Groups] ([Id], [Name], [ClassroomId], [TeacherId], [MentorId], [Capacity], [EducationId], [Status]) VALUES (3, N'P211', 5, 3, 17, 19, 1, 1)
INSERT [dbo].[Groups] ([Id], [Name], [ClassroomId], [TeacherId], [MentorId], [Capacity], [EducationId], [Status]) VALUES (5, N'V205', 3, 4, 18, 16, 3, 1)
INSERT [dbo].[Groups] ([Id], [Name], [ClassroomId], [TeacherId], [MentorId], [Capacity], [EducationId], [Status]) VALUES (6, N'P212', 1, 3, 17, 17, 1, 1)
INSERT [dbo].[Groups] ([Id], [Name], [ClassroomId], [TeacherId], [MentorId], [Capacity], [EducationId], [Status]) VALUES (7, N'P200', 3, 5, 17, 20, 1, 1)
INSERT [dbo].[Groups] ([Id], [Name], [ClassroomId], [TeacherId], [MentorId], [Capacity], [EducationId], [Status]) VALUES (8, N'P213', 4, 1, 16, 17, 1, 1)
SET IDENTITY_INSERT [dbo].[Groups] OFF
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([Id], [Name], [Status]) VALUES (1, N'CEO', 1)
INSERT [dbo].[Positions] ([Id], [Name], [Status]) VALUES (2, N'Consultant', 1)
INSERT [dbo].[Positions] ([Id], [Name], [Status]) VALUES (3, N'Receptionist', 1)
INSERT [dbo].[Positions] ([Id], [Name], [Status]) VALUES (4, N'Cleaner', 1)
INSERT [dbo].[Positions] ([Id], [Name], [Status]) VALUES (5, N'It Tech', 1)
INSERT [dbo].[Positions] ([Id], [Name], [Status]) VALUES (6, N'System Administrator', 1)
INSERT [dbo].[Positions] ([Id], [Name], [Status]) VALUES (7, N'Mentor', 1)
INSERT [dbo].[Positions] ([Id], [Name], [Status]) VALUES (8, N'Accountant', 1)
SET IDENTITY_INSERT [dbo].[Positions] OFF
SET IDENTITY_INSERT [dbo].[Specialities] ON 

INSERT [dbo].[Specialities] ([Id], [Name]) VALUES (1, N'Developer')
INSERT [dbo].[Specialities] ([Id], [Name]) VALUES (2, N'Designer')
INSERT [dbo].[Specialities] ([Id], [Name]) VALUES (3, N'System administrator')
SET IDENTITY_INSERT [dbo].[Specialities] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [Surname], [Email], [Phone], [Fee], [GroupId], [Status]) VALUES (1, N'Rauf', N'Allahverdiyev', N'raufsa@code.edu.az', N'+994508507575', 3500, 2, 1)
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Email], [Phone], [Fee], [GroupId], [Status]) VALUES (2, N'Nihad', N'Teymurlu', N'nihadnt@code.edu.az', N'+994514913800', 7100, 3, 1)
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Email], [Phone], [Fee], [GroupId], [Status]) VALUES (3, N'Togrul', N'Rzayev', N'togrulrr@code.edu.az', N'+994559491917', 4000, 2, 1)
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Email], [Phone], [Fee], [GroupId], [Status]) VALUES (4, N'Hasan', N'Ali', N'hasan@code.edu.az', N'+994771000011', 1600, 5, 1)
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Email], [Phone], [Fee], [GroupId], [Status]) VALUES (5, N'Tamerlan', N'Letifli', N'tamerlan@code.edu.az', N'+994503291029', 3000, 2, 1)
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Email], [Phone], [Fee], [GroupId], [Status]) VALUES (6, N'Ekber', N'Amanov', N'ekber@code.edu.az', N'+994553303399', 3500, 2, 1)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([Id], [Name], [Deadline], [GroupId], [Status]) VALUES (2, N'C#', CAST(N'2019-06-03T20:58:45.000' AS DateTime), 2, 1)
INSERT [dbo].[Tasks] ([Id], [Name], [Deadline], [GroupId], [Status]) VALUES (3, N'Frontend Project', CAST(N'2019-06-20T14:15:59.000' AS DateTime), 3, 1)
INSERT [dbo].[Tasks] ([Id], [Name], [Deadline], [GroupId], [Status]) VALUES (4, N'Final Project', CAST(N'2019-06-09T15:57:05.000' AS DateTime), 5, 1)
INSERT [dbo].[Tasks] ([Id], [Name], [Deadline], [GroupId], [Status]) VALUES (5, N'Weekend', CAST(N'2019-06-02T17:02:36.000' AS DateTime), 3, 1)
INSERT [dbo].[Tasks] ([Id], [Name], [Deadline], [GroupId], [Status]) VALUES (6, N'Backend', CAST(N'2019-06-09T17:15:40.000' AS DateTime), 2, 1)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [Name], [Surname], [SpecialityId], [Email], [Phone], [Status]) VALUES (1, N'Sattar', N'Amrahov', 1, N'sattar@code.edu.az', N'+994514669934', 1)
INSERT [dbo].[Teachers] ([Id], [Name], [Surname], [SpecialityId], [Email], [Phone], [Status]) VALUES (2, N'Orxan', N'Rzazade', 1, N'orxan@code.edu.az', N'+994505000000', 0)
INSERT [dbo].[Teachers] ([Id], [Name], [Surname], [SpecialityId], [Email], [Phone], [Status]) VALUES (3, N'Samir', N'Dadashzade', 1, N'samird@code.edu.az', N'+994555555555', 1)
INSERT [dbo].[Teachers] ([Id], [Name], [Surname], [SpecialityId], [Email], [Phone], [Status]) VALUES (4, N'Knyaz', N'Yaqublu', 2, N'knyaz@code.edu.az', N'+994707777777', 1)
INSERT [dbo].[Teachers] ([Id], [Name], [Surname], [SpecialityId], [Email], [Phone], [Status]) VALUES (5, N'Yolcu', N'Nesib', 1, N'yolcu@code.edu.az', N'+994509008888', 1)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classrooms] ([Id])
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD FOREIGN KEY([EducationId])
REFERENCES [dbo].[Education Programs] ([Id])
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD FOREIGN KEY([MentorId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD FOREIGN KEY([SpecialityId])
REFERENCES [dbo].[Specialities] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Academy] SET  READ_WRITE 
GO
