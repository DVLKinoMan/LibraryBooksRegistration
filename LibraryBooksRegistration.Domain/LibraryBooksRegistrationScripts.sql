USE [master]
GO
/****** Object:  Database [LibraryBooksRegistration]    Script Date: 5/9/2017 16:01:50 ******/
CREATE DATABASE [LibraryBooksRegistration]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryBooksRegistration', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.DVL_DAVID\MSSQL\DATA\LibraryBooksRegistration.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LibraryBooksRegistration_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.DVL_DAVID\MSSQL\DATA\LibraryBooksRegistration_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LibraryBooksRegistration] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryBooksRegistration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryBooksRegistration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryBooksRegistration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryBooksRegistration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryBooksRegistration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryBooksRegistration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryBooksRegistration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryBooksRegistration] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryBooksRegistration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryBooksRegistration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryBooksRegistration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryBooksRegistration] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LibraryBooksRegistration]
GO
/****** Object:  StoredProcedure [dbo].[AddAuthor]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAuthor]
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@BirthDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into dbo.Authors(FirstName,LastName,BirthDate)
	values (@FirstName,@LastName,@BirthDate);
END



GO
/****** Object:  StoredProcedure [dbo].[AddAuthorBook]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddAuthorBook]
	-- Add the parameters for the stored procedure here
	@AuthorID int,
	@BookID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--delete dbo.Authors
	--where ID=@ID;
	--update dbo.Authors
	--set FirstName=@FirstName,LastName=@LastName,BirthDate=@BirthDate
	--where ID=@ID;
	insert into dbo.AuthorBooks(AuthorID,BookID)
	values (@AuthorID,@BookID);
END



GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddBook]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@CategoryID int,
	@PublishingHouse nvarchar(50),
	@PublishingDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--delete dbo.AuthorBooks
	--where ID=@ID;
	--update dbo.Authors
	--set FirstName=@FirstName,LastName=@LastName,BirthDate=@BirthDate
	--where ID=@ID;
	insert into dbo.Books(Name,CategoryID,PublishingHouse,PublishingDate)
	values (@Name,@CategoryID,@PublishingHouse,@PublishingDate);
END



GO
/****** Object:  StoredProcedure [dbo].[AddBookCategory]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddBookCategory]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Description nvarchar(200)='',
	@ParentCategoryID int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--delete dbo.Books
	--where ID=@ID;
	--update dbo.Books
	--set Name=@Name,CategoryID=@CategoryID,PublishingHouse=@PublishingHouse,PublishingDate=@PublishingDate
	--where ID=@ID;
	insert into dbo.BookCategories(Name,Description,ParentCategoryID)
	values (@Name,@Description,@ParentCategoryID);
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteAuthor]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAuthor]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete dbo.Authors
	where ID=@ID;
	--update dbo.Authors
	--set FirstName=@FirstName,LastName=@LastName,BirthDate=@BirthDate
	--where ID=@ID;
	--insert into dbo.Authors(FirstName,LastName,BirthDate)
	--values (@FirstName,@LastName,@BirthDate);
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteAuthorBook]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAuthorBook]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete dbo.AuthorBooks
	where ID=@ID;
	--update dbo.Authors
	--set FirstName=@FirstName,LastName=@LastName,BirthDate=@BirthDate
	--where ID=@ID;
	--insert into dbo.AuthorBooks(AuthorID,BookID)
	--values (@AuthorID,@BookID);
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteBook]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBook]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete dbo.Books
	where ID=@ID;
	--update dbo.Books
	--set Name=@Name,CategoryID=@CategoryID,PublishingHouse=@PublishingHouse,PublishingDate=@PublishingDate
	--where ID=@ID;
	--insert into dbo.Books(Name,CategoryID,PublishingHouse,PublishingDate)
	--values (@Name,@CategoryID,@PublishingHouse,@PublishingDate);
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteBookCategory]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBookCategory]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete dbo.BookCategories
	where ID=@ID;
	--update dbo.BookCategories
	--set Name=@Name,Description=@Description
	--where ID=@ID;
	--insert into dbo.BookCategories(Name,Description)
	--values (@Name,@Description);
END



GO
/****** Object:  StoredProcedure [dbo].[EditAuthor]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditAuthor]
	-- Add the parameters for the stored procedure here
	@ID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@BirthDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update dbo.Authors
	set FirstName=@FirstName,LastName=@LastName,BirthDate=@BirthDate
	where ID=@ID;
	--insert into dbo.Authors(FirstName,LastName,BirthDate)
	--values (@FirstName,@LastName,@BirthDate);
END



GO
/****** Object:  StoredProcedure [dbo].[EditBook]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditBook]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name nvarchar(50),
	@CategoryID int,
	@PublishingHouse nvarchar(50),
	@PublishingDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--delete dbo.AuthorBooks
	--where ID=@ID;
	update dbo.Books
	set Name=@Name,CategoryID=@CategoryID,PublishingHouse=@PublishingHouse,PublishingDate=@PublishingDate
	where ID=@ID;
	--insert into dbo.Books(Name,CategoryID,PublishingHouse,PublishingDate)
	--values (@Name,@CategoryID,@PublishingHouse,@PublishingDate);
END



GO
/****** Object:  StoredProcedure [dbo].[EditBookCategory]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditBookCategory]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name nvarchar(50),
	@Description nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--delete dbo.Books
	--where ID=@ID;
	update dbo.BookCategories
	set Name=@Name,Description=@Description
	where ID=@ID;
	--insert into dbo.BookCategories(Name,Description)
	--values (@Name,@Description);
END



GO
/****** Object:  Table [dbo].[AuthorBooks]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorBooks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
 CONSTRAINT [PK_AuthorBooks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Authors]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookCategories]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[BooksQuantity] [int] NULL,
	[ParentCategoryID] [int] NULL,
 CONSTRAINT [PK_BookCategories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 5/9/2017 16:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[PublishingHouse] [nvarchar](50) NOT NULL,
	[PublishingDate] [date] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BookCategories]    Script Date: 5/9/2017 16:01:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_BookCategories] ON [dbo].[BookCategories]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookCategories] ADD  CONSTRAINT [DF_BookCategories_BooksQuantity]  DEFAULT ((0)) FOR [BooksQuantity]
GO
ALTER TABLE [dbo].[BookCategories] ADD  CONSTRAINT [DF_BookCategories_ParentID]  DEFAULT ((0)) FOR [ParentCategoryID]
GO
ALTER TABLE [dbo].[AuthorBooks]  WITH CHECK ADD  CONSTRAINT [FK_AuthorBooks_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([ID])
GO
ALTER TABLE [dbo].[AuthorBooks] CHECK CONSTRAINT [FK_AuthorBooks_Authors]
GO
ALTER TABLE [dbo].[AuthorBooks]  WITH CHECK ADD  CONSTRAINT [FK_AuthorBooks_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([ID])
GO
ALTER TABLE [dbo].[AuthorBooks] CHECK CONSTRAINT [FK_AuthorBooks_Books]
GO
ALTER TABLE [dbo].[BookCategories]  WITH CHECK ADD  CONSTRAINT [FK_BookCategories_BookCategories] FOREIGN KEY([ParentCategoryID])
REFERENCES [dbo].[BookCategories] ([ID])
GO
ALTER TABLE [dbo].[BookCategories] CHECK CONSTRAINT [FK_BookCategories_BookCategories]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_BookCategories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[BookCategories] ([ID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_BookCategories]
GO
USE [master]
GO
ALTER DATABASE [LibraryBooksRegistration] SET  READ_WRITE 
GO
