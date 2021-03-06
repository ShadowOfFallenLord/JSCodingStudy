USE [master]
GO
/****** Object:  Database [JSCodingStudyDB]    Script Date: 08.02.2021 20:47:08 ******/
CREATE DATABASE [JSCodingStudyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JSCodingStudyDB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JSCodingStudyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JSCodingStudyDB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JSCodingStudyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JSCodingStudyDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JSCodingStudyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JSCodingStudyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JSCodingStudyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JSCodingStudyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JSCodingStudyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JSCodingStudyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JSCodingStudyDB] SET  MULTI_USER 
GO
ALTER DATABASE [JSCodingStudyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JSCodingStudyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JSCodingStudyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JSCodingStudyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JSCodingStudyDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JSCodingStudyDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [JSCodingStudyDB] SET QUERY_STORE = OFF
GO
USE [JSCodingStudyDB]
GO
/****** Object:  Table [dbo].[RobotLessons]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RobotLessons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [xml] NOT NULL,
	[Task] [xml] NOT NULL,
	[Pattern] [xml] NOT NULL,
	[StartX] [int] NOT NULL,
	[StartY] [int] NOT NULL,
	[HelpAPIMove] [bit] NOT NULL,
	[HelpAPICheck] [bit] NOT NULL,
	[HelpAPIDraw] [bit] NOT NULL,
 CONSTRAINT [PK_RobotLessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RobotUserCode]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RobotUserCode](
	[UserId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[Code] [xml] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_RobotUserCode]    Script Date: 08.02.2021 20:47:08 ******/
CREATE UNIQUE CLUSTERED INDEX [IX_RobotUserCode] ON [dbo].[RobotUserCode]
(
	[UserId] ASC,
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RobotLastLesson] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_RobotLastLesson]  DEFAULT ((1)) FOR [RobotLastLesson]
GO
ALTER TABLE [dbo].[RobotUserCode]  WITH CHECK ADD  CONSTRAINT [FK_RobotUserCode_RobotLessons] FOREIGN KEY([LessonId])
REFERENCES [dbo].[RobotLessons] ([Id])
GO
ALTER TABLE [dbo].[RobotUserCode] CHECK CONSTRAINT [FK_RobotUserCode_RobotLessons]
GO
ALTER TABLE [dbo].[RobotUserCode]  WITH CHECK ADD  CONSTRAINT [FK_RobotUserCode_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RobotUserCode] CHECK CONSTRAINT [FK_RobotUserCode_Users]
GO
/****** Object:  StoredProcedure [dbo].[RobotLessons_Add]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RobotLessons_Add]
	@title xml,
	@task xml,
	@pattern xml,
	@start_x int,
	@start_y int,
	@help_api_move bit,
	@help_api_check bit,
	@help_api_draw bit
AS
BEGIN
	INSERT INTO RobotLessons(Title, Task, Pattern, StartX, StartY, HelpAPIMove, HelpAPICheck, HelpAPIDraw)
	VALUES(@title, @task, @pattern, @start_x, @start_y, @help_api_move, @help_api_check, @help_api_draw)
	RETURN SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[RobotLessons_GetAll]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RobotLessons_GetAll]
	@id int
AS
BEGIN
	SELECT Id, Title, Task, Pattern, StartX, StartY, HelpAPIMove, HelpAPICheck, HelpAPIDraw
	FROM RobotLessons
END
GO
/****** Object:  StoredProcedure [dbo].[RobotLessons_GetById]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RobotLessons_GetById]
	@id int
AS
BEGIN
	SELECT Id, Title, Task, Pattern, StartX, StartY, HelpAPIMove, HelpAPICheck, HelpAPIDraw
	FROM RobotLessons
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[RobotLessons_Remove]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RobotLessons_Remove]
	@id int
AS
BEGIN
	DELETE FROM RobotLessons
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[RobotLessons_Update]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RobotLessons_Update]
	@id int,
	@title xml,
	@task xml,
	@pattern xml,
	@start_x int,
	@start_y int,
	@help_api_move bit,
	@help_api_check bit,
	@help_api_draw bit
AS
BEGIN
	UPDATE RobotLessons
	SET Title = @title, 
		Task = @task, 
		Pattern = @pattern, 
		StartX = @start_x, 
		StartY = @start_y, 
		HelpAPIMove = @help_api_move, 
		HelpAPICheck = @help_api_check, 
		HelpAPIDraw = @help_api_draw
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[RobotUserCode_Add]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RobotUserCode_Add]
	@user_id int,
	@lesson_id int,
	@code xml
AS
BEGIN
	INSERT INTO RobotUserCode(UserId, LessonId, Code)
	VALUES (@user_id, @lesson_id, @code)
END
GO
/****** Object:  StoredProcedure [dbo].[RobotUserCode_GetById]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RobotUserCode_GetById]
	@user_id int,
	@lesson_id int
AS
BEGIN
	SELECT TOP(1) UserId, LessonId, Code
	FROM RobotUserCode
	WHERE UserId = @user_id AND LessonId = @lesson_id
END
GO
/****** Object:  StoredProcedure [dbo].[RobotUserCode_Update]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RobotUserCode_Update]
	@user_id int,
	@lesson_id int,
	@code xml
AS
BEGIN
	UPDATE RobotUserCode
	SET Code = @code
	WHERE UserId = @user_id AND LessonId = @lesson_id
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Add]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Users_Add]
	@login nvarchar(50),
	@password nvarchar(50)
AS
BEGIN
	INSERT INTO Users([Login], [Password])
	VALUES(@login, @password)
	RETURN SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[Users_GetById]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Users_GetById]
	@id int
AS
BEGIN
	SELECT TOP(1) [Id], [Login], [Password], [RobotLastLesson]
	FROM Users
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Users_GetByLogin]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Users_GetByLogin]
	@login nvarchar(50)
AS
BEGIN
	SELECT TOP(1) [Id], [Login], [Password], [RobotLastLesson]
	FROM Users
	WHERE [Login] = @login
END
GO
/****** Object:  StoredProcedure [dbo].[Users_UpdateLessons]    Script Date: 08.02.2021 20:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Users_UpdateLessons]
	@id int,
	@robot_last_lesson int
AS
BEGIN
	UPDATE Users
	SET RobotLastLesson = @robot_last_lesson
	WHERE Id = @id
END
GO
USE [master]
GO
ALTER DATABASE [JSCodingStudyDB] SET  READ_WRITE 
GO
