/*    ==Scripting Parameters==

    Source Server Version : SQL Server v160 (16.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server v160
    Target Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [MyBiblioCDsDB]    Script Date: 14/03/2024 14:04:00 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'MyBiblioCDsDB')
BEGIN
CREATE DATABASE [MyBiblioCDsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyBiblioCDsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyBiblioCDsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyBiblioCDsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyBiblioCDsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Latin1_General_CI_AS
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
END
GO
USE [MyBiblioCDsDB]
GO
ALTER DATABASE [MyBiblioCDsDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyBiblioCDsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyBiblioCDsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyBiblioCDsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyBiblioCDsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyBiblioCDsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyBiblioCDsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MyBiblioCDsDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyBiblioCDsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyBiblioCDsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyBiblioCDsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyBiblioCDsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyBiblioCDsDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyBiblioCDsDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyBiblioCDsDB', N'ON'
GO
ALTER DATABASE [MyBiblioCDsDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MyBiblioCDsDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MyBiblioCDsDB]
GO
/****** Object:  Table [dbo].[filenumandword]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[filenumandword]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[filenumandword](
	[idfilenumandword] [int] IDENTITY(1,1) NOT NULL,
	[pkfiles] [int] NULL,
	[word] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[ce] [tinyint] NULL,
 CONSTRAINT [PK_file_num_and_word] PRIMARY KEY CLUSTERED 
(
	[idfilenumandword] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[duplicatewords]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[duplicatewords]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[duplicatewords]
AS
SELECT      word, COUNT(word) AS NUMDUPL
FROM
			dbo.filenumandword
			group BY word
			HAVING count(word) > 1;
' 
GO
/****** Object:  Table [dbo].[words]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[words]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[words](
	[idWords] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_words] PRIMARY KEY CLUSTERED 
(
	[idWords] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[View_1]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_1]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_1]
AS
SELECT        dbo.filenumandword.idfilenumandword, dbo.filenumandword.pkfiles, dbo.filenumandword.word, dbo.filenumandword.ce, dbo.words.Word AS Expr1
FROM            dbo.filenumandword INNER JOIN
                         dbo.words ON dbo.filenumandword.word = dbo.words.Word
' 
GO
/****** Object:  Table [dbo].[filenumandword_pro]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[filenumandword_pro]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[filenumandword_pro](
	[idfilenumandword_pro] [int] IDENTITY(1,1) NOT NULL,
	[pkfile] [int] NOT NULL,
	[word] [nvarchar](255) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_filenumandword_pro] PRIMARY KEY CLUSTERED 
(
	[idfilenumandword_pro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[DUPLICATEWORDPROG]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DUPLICATEWORDPROG]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[DUPLICATEWORDPROG]
AS
SELECT        word, COUNT(word) AS NUMDUPL
FROM            dbo.filenumandword_pro
GROUP BY word
HAVING        (COUNT(word) > 1)
' 
GO
/****** Object:  Table [dbo].[wordsfileprogram]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wordsfileprogram]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[wordsfileprogram](
	[idwordsfileprogram] [int] IDENTITY(1,1) NOT NULL,
	[programwords_idprogramwords] [int] NULL,
	[Files_idFiles] [int] NULL,
 CONSTRAINT [PK_wordsfileprogram] PRIMARY KEY CLUSTERED 
(
	[idwordsfileprogram] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[wordprofrequenze]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[wordprofrequenze]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[wordprofrequenze]
AS
SELECT        programwords_idprogramwords, COUNT(programwords_idprogramwords) AS NUMDUPL
FROM            dbo.wordsfileprogram
GROUP BY programwords_idprogramwords
HAVING        (COUNT(programwords_idprogramwords) > 1)
' 
GO
/****** Object:  Table [dbo].[wordsfiles]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wordsfiles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[wordsfiles](
	[idwordsfiles] [int] IDENTITY(1,1) NOT NULL,
	[Words_idWords] [int] NOT NULL,
	[Files_idFiles] [int] NOT NULL,
 CONSTRAINT [PK_wordsfiles] PRIMARY KEY CLUSTERED 
(
	[idwordsfiles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[WordsFrequenze]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[WordsFrequenze]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[WordsFrequenze]
AS
SELECT        TOP (100) PERCENT Words_idWords, COUNT(Words_idWords) AS Frequenze
FROM            dbo.wordsfiles
GROUP BY Words_idWords
HAVING        (COUNT(Words_idWords) > 1)
' 
GO
/****** Object:  Table [dbo].[artist]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[artist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[artist](
	[idArtist] [int] IDENTITY(1,1) NOT NULL,
	[NameArtist] [nvarchar](128) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_artist] PRIMARY KEY CLUSTERED 
(
	[idArtist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[audiocd]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[audiocd]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[audiocd](
	[idAudioCD] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) COLLATE Latin1_General_CI_AS NULL,
	[Country] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[Genre] [int] NULL,
	[PublicationDate] [int] NULL,
	[Duration] [time](7) NULL,
	[NumTracks] [smallint] NULL,
	[AudioCDcol] [nvarchar](45) COLLATE Latin1_General_CI_AS NULL,
	[CdNew_idCdNew] [int] NOT NULL,
 CONSTRAINT [PK_audiocd] PRIMARY KEY CLUSTERED 
(
	[idAudioCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[audiocd_has_artist]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[audiocd_has_artist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[audiocd_has_artist](
	[AudioCD_has_Artist] [int] NOT NULL,
	[Artist_idArtist] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[cdmediatype]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cdmediatype]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cdmediatype](
	[idCdMediaType] [tinyint] IDENTITY(1,1) NOT NULL,
	[TypeCd] [nvarchar](14) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_cdmediatype] PRIMARY KEY CLUSTERED 
(
	[idCdMediaType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CdNew]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CdNew]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CdNew](
	[idCdNew] [int] IDENTITY(1,1) NOT NULL,
	[NameCD] [nvarchar](128) COLLATE Latin1_General_CI_AS NULL,
	[NumCd] [int] NULL,
	[Position] [nvarchar](30) COLLATE Latin1_General_CI_AS NULL,
	[CreationDate] [date] NULL,
	[CoverPath] [nvarchar](255) COLLATE Latin1_General_CI_AS NULL,
	[Unic_IDCD] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[CdMediatype] [tinyint] NULL,
 CONSTRAINT [PK_CdNew] PRIMARY KEY CLUSTERED 
(
	[idCdNew] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[files]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[files]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[files](
	[idFiles] [int] IDENTITY(1,1) NOT NULL,
	[FullNameFile] [nvarchar](255) COLLATE Latin1_General_CI_AS NOT NULL,
	[FileName] [nvarchar](255) COLLATE Latin1_General_CI_AS NOT NULL,
	[CreationData] [date] NULL,
	[LastModified] [date] NULL,
	[Size] [int] NULL,
	[TypeFile] [nvarchar](13) COLLATE Latin1_General_CI_AS NULL,
	[Ext] [nvarchar](125) COLLATE Latin1_General_CI_AS NULL,
	[Hashcode] [varchar](60) COLLATE Latin1_General_CI_AS NULL,
	[CdNew_idCdNew] [int] NOT NULL,
	[Note] [tinyint] NULL,
 CONSTRAINT [PK_files] PRIMARY KEY CLUSTERED 
(
	[idFiles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[film]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[film]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[film](
	[idFilm] [int] IDENTITY(1,1) NOT NULL,
	[TitleFilm] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[CdNew_idCdNew] [int] NULL,
	[CdNew_idCdNew1] [int] NOT NULL,
 CONSTRAINT [PK_film] PRIMARY KEY CLUSTERED 
(
	[idFilm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[fotos]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fotos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[fotos](
	[idFotos] [int] IDENTITY(1,1) NOT NULL,
	[Catalogue] [smallint] NULL,
	[Object] [nvarchar](45) COLLATE Latin1_General_CI_AS NULL,
	[CdNew_idCdNew] [int] NULL,
	[CdNew_idCdNew1] [int] NOT NULL,
 CONSTRAINT [PK_fotos] PRIMARY KEY CLUSTERED 
(
	[idFotos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[genre]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[genre]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[genre](
	[idGenre] [int] NOT NULL,
	[NameGenre] [nvarchar](45) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_genre] PRIMARY KEY CLUSTERED 
(
	[idGenre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[note]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[note]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[note](
	[idNote] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](2024) COLLATE Latin1_General_CI_AS NULL,
	[idFile_idNote] [int] NULL,
	[typeNt] [smallint] NULL,
 CONSTRAINT [PK_note] PRIMARY KEY CLUSTERED 
(
	[idNote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[programwords]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[programwords]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[programwords](
	[idprogramwords] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](128) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_programwords] PRIMARY KEY CLUSTERED 
(
	[idprogramwords] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tracks]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tracks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tracks](
	[idTracks] [int] IDENTITY(1,1) NOT NULL,
	[NumTrack] [tinyint] NULL,
	[NameTrack] [nvarchar](128) COLLATE Latin1_General_CI_AS NULL,
	[Duration] [time](7) NULL,
	[AudioCD_idAudioCD] [int] NOT NULL,
 CONSTRAINT [PK_tracks] PRIMARY KEY CLUSTERED 
(
	[idTracks] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[cdmediatype] ON 

INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (1, N'CD-AUDIO')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (2, N'CD-ROM')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (3, N'CD-PHOTOS')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (4, N'CD-VARIOUS')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (5, N'DVD-DATA')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (6, N'DVD-FILM')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (7, N'BLU-RAY-DATA')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (8, N'BLU-RAY-FILM')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (9, N'REMOVABLE')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (10, N'DIRECTORY')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (11, N'COLLECTION')
INSERT [dbo].[cdmediatype] ([idCdMediaType], [TypeCd]) VALUES (12, N'MYCOMPILATION')
SET IDENTITY_INSERT [dbo].[cdmediatype] OFF
GO
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (1, N'Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (2, N'Alternative Rock
')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (3, N'Alt-Rock
')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (4, N'Art Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (5, N'Avant Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (6, N'Avant-garde')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (7, N'Ballad/Slow Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (8, N'Classic Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (9, N'Crossover Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (10, N'Deutch Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (11, N'Gothic Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (12, N'Hard Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (13, N'Italo House')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (14, N'Italo techno')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (15, N'Latin Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (16, N'Psychedelic Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (17, N'Rock & Roll')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (18, N'Rock Italiano')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (19, N'Rockabilly')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (20, N'Rocksteady')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (21, N'Rocktronica')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (22, N'jazz')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (23, N'Free Jazz')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (24, N'Gipsy Jazz')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (25, N'Jazz Manouche')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (26, N'Jazz Samba - Bossanova')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (27, N'Jazz/Downtempo')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (28, N'J-Pop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (29, N'J-Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (30, N'Latin Jazz')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (31, N'Smooth Jazz')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (32, N'Soul-Jazz')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (33, N'Blues')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (34, N'Bluegrass')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (35, N'Blues Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (36, N'Swing')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (37, N'Rhythm & Blues')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (38, N'Funk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (39, N'Funk Brasileiro')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (40, N'Funk metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (41, N'Funk Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (42, N'Funky')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (43, N'Funky House')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (44, N'Funky Jazz')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (45, N'Funky Soul')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (46, N'Fusion')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (47, N'G-Funk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (48, N'Liquid funk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (49, N'Metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (50, N'Avantgarde metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (51, N'Black doom metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (52, N'Black metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (53, N'Brutal death metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (54, N'Celtic metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (55, N'Extreme disco metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (56, N'Extreme power metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (57, N'Gothic metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (58, N'Groove metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (59, N'Hair metal (Glam metal)')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (60, N'Heavy Metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (61, N'Heavy metal classico')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (62, N'Medieval metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (63, N'Melodic death metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (64, N'Neoclassical metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (65, N'Power metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (66, N'Thrash metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (67, N'Pop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (68, N'Pop Italiano')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (69, N'Deutch pop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (70, N'Latin Pop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (71, N'Soul Pop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (72, N'Classic')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (73, N'Acapella')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (74, N'Musica da camera')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (75, N'Musica per balletto')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (76, N'Musica sacra')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (77, N'Musica sinfonica')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (78, N'Opera Lirica')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (79, N'Folk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (80, N'Canto Popolare')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (81, N'Combat Folk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (82, N'Country (USA)')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (83, N'Country Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (84, N'Flamenco (ESP)')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (85, N'Flamenco Chill')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (86, N'Folk Elettronico')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (87, N'Folk Italiano')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (88, N'Folk metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (89, N'Folk Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (90, N'Folk Singing')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (91, N'Gospel Music')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (92, N'Musica celtica')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (93, N'Hip-Hop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (94, N'Hip-Hop Soul')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (95, N'Hip-Hop USA')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (96, N'Disco Music')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (97, N'Disco House')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (98, N'Disco Music (70es)')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (99, N'Dance')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (100, N'Braindance')
GO
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (101, N'punk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (102, N'Crust punk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (103, N'Gipsy Punk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (104, N'Punk metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (105, N'Punk Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (106, N'Techno')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (107, N'Bouncy Techno')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (108, N'Dub techno')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (109, N'Electro')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (110, N'Electro Backbeat')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (111, N'Electro Funk')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (112, N'Electro House')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (113, N'Electro Pop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (114, N'Electro techno')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (115, N'Electro trance')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (116, N'Electroclash')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (117, N'Electronic Body Music')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (118, N'Elettropop/Technopop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (119, N'Rap')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (120, N'Hardcore Rap')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (121, N'Deutch Rap')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (122, N'Foreign Rap/Hip-Hop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (123, N'Jazz Rap')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (124, N'Rap & Ragamuffin')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (125, N'Rapcore')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (126, N'Rap-Rock')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (127, N'Underground Rap')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (128, N'Ambient')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (129, N'Ambient House')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (130, N'Ambient Techno')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (131, N'Beat Box')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (132, N'Beat Music')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (133, N'Bebop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (134, N'Big Beat')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (135, N'New Age')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (136, N'New beat')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (137, N'New Wave')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (138, N'New Wave (80es)')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (139, N'New Wave of British Heavy Metal')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (140, N'R\''N B')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (141, N'R\''n B & Soul')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (142, N'R\''nB')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (143, N'Ragtime')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (144, N'Reggae')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (145, N'Reggae Hip-Hop')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (146, N'Reggaeton')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (147, N'Salsa')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (148, N'Samba (BRA)')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (149, N'Ska')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (150, N'Ska Reggae')
INSERT [dbo].[genre] ([idGenre], [NameGenre]) VALUES (151, N'World Music')
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_artist_NameArtist]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[artist] ADD  CONSTRAINT [DF_artist_NameArtist]  DEFAULT (NULL) FOR [NameArtist]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CdNew_NumCd]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CdNew] ADD  CONSTRAINT [DF_CdNew_NumCd]  DEFAULT (NULL) FOR [NumCd]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CdNew_Position]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CdNew] ADD  CONSTRAINT [DF_CdNew_Position]  DEFAULT (NULL) FOR [Position]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CdNew_Unic_IDCD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CdNew] ADD  CONSTRAINT [DF_CdNew_Unic_IDCD]  DEFAULT (NULL) FOR [Unic_IDCD]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CdNew_CdMediatype]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CdNew] ADD  CONSTRAINT [DF_CdNew_CdMediatype]  DEFAULT (NULL) FOR [CdMediatype]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_filenumandword_ce]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[filenumandword] ADD  CONSTRAINT [DF_filenumandword_ce]  DEFAULT ((0)) FOR [ce]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_files_CreationData]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[files] ADD  CONSTRAINT [DF_files_CreationData]  DEFAULT (NULL) FOR [CreationData]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_files_LastModified]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[files] ADD  CONSTRAINT [DF_files_LastModified]  DEFAULT (NULL) FOR [LastModified]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_files_Size]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[files] ADD  CONSTRAINT [DF_files_Size]  DEFAULT (NULL) FOR [Size]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_files_TypeFile]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[files] ADD  CONSTRAINT [DF_files_TypeFile]  DEFAULT (NULL) FOR [TypeFile]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_files_Ext]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[files] ADD  CONSTRAINT [DF_files_Ext]  DEFAULT (NULL) FOR [Ext]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_files_Hashcode]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[files] ADD  CONSTRAINT [DF_files_Hashcode]  DEFAULT (NULL) FOR [Hashcode]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_files_CdNew_idCdNew]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[files] ADD  CONSTRAINT [DF_files_CdNew_idCdNew]  DEFAULT (NULL) FOR [CdNew_idCdNew]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_audiocd_CdNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[audiocd]'))
ALTER TABLE [dbo].[audiocd]  WITH CHECK ADD  CONSTRAINT [FK_audiocd_CdNew] FOREIGN KEY([CdNew_idCdNew])
REFERENCES [dbo].[CdNew] ([idCdNew])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_audiocd_CdNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[audiocd]'))
ALTER TABLE [dbo].[audiocd] CHECK CONSTRAINT [FK_audiocd_CdNew]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_audiocd_has_artist_artist]') AND parent_object_id = OBJECT_ID(N'[dbo].[audiocd_has_artist]'))
ALTER TABLE [dbo].[audiocd_has_artist]  WITH CHECK ADD  CONSTRAINT [FK_audiocd_has_artist_artist] FOREIGN KEY([Artist_idArtist])
REFERENCES [dbo].[artist] ([idArtist])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_audiocd_has_artist_artist]') AND parent_object_id = OBJECT_ID(N'[dbo].[audiocd_has_artist]'))
ALTER TABLE [dbo].[audiocd_has_artist] CHECK CONSTRAINT [FK_audiocd_has_artist_artist]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_audiocd_has_artist_audiocd]') AND parent_object_id = OBJECT_ID(N'[dbo].[audiocd_has_artist]'))
ALTER TABLE [dbo].[audiocd_has_artist]  WITH CHECK ADD  CONSTRAINT [FK_audiocd_has_artist_audiocd] FOREIGN KEY([AudioCD_has_Artist])
REFERENCES [dbo].[audiocd] ([idAudioCD])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_audiocd_has_artist_audiocd]') AND parent_object_id = OBJECT_ID(N'[dbo].[audiocd_has_artist]'))
ALTER TABLE [dbo].[audiocd_has_artist] CHECK CONSTRAINT [FK_audiocd_has_artist_audiocd]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CdNew_cdmediatype]') AND parent_object_id = OBJECT_ID(N'[dbo].[CdNew]'))
ALTER TABLE [dbo].[CdNew]  WITH CHECK ADD  CONSTRAINT [FK_CdNew_cdmediatype] FOREIGN KEY([CdMediatype])
REFERENCES [dbo].[cdmediatype] ([idCdMediaType])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CdNew_cdmediatype]') AND parent_object_id = OBJECT_ID(N'[dbo].[CdNew]'))
ALTER TABLE [dbo].[CdNew] CHECK CONSTRAINT [FK_CdNew_cdmediatype]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_files_CdNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[files]'))
ALTER TABLE [dbo].[files]  WITH CHECK ADD  CONSTRAINT [FK_files_CdNew] FOREIGN KEY([CdNew_idCdNew])
REFERENCES [dbo].[CdNew] ([idCdNew])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_files_CdNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[files]'))
ALTER TABLE [dbo].[files] CHECK CONSTRAINT [FK_files_CdNew]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_film_CdNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[film]'))
ALTER TABLE [dbo].[film]  WITH CHECK ADD  CONSTRAINT [FK_film_CdNew] FOREIGN KEY([CdNew_idCdNew])
REFERENCES [dbo].[CdNew] ([idCdNew])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_film_CdNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[film]'))
ALTER TABLE [dbo].[film] CHECK CONSTRAINT [FK_film_CdNew]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_fotos_CdNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[fotos]'))
ALTER TABLE [dbo].[fotos]  WITH CHECK ADD  CONSTRAINT [FK_fotos_CdNew] FOREIGN KEY([CdNew_idCdNew])
REFERENCES [dbo].[CdNew] ([idCdNew])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_fotos_CdNew]') AND parent_object_id = OBJECT_ID(N'[dbo].[fotos]'))
ALTER TABLE [dbo].[fotos] CHECK CONSTRAINT [FK_fotos_CdNew]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tracks_audiocd]') AND parent_object_id = OBJECT_ID(N'[dbo].[tracks]'))
ALTER TABLE [dbo].[tracks]  WITH CHECK ADD  CONSTRAINT [FK_tracks_audiocd] FOREIGN KEY([AudioCD_idAudioCD])
REFERENCES [dbo].[audiocd] ([idAudioCD])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tracks_audiocd]') AND parent_object_id = OBJECT_ID(N'[dbo].[tracks]'))
ALTER TABLE [dbo].[tracks] CHECK CONSTRAINT [FK_tracks_audiocd]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_wordsfileprogram_files]') AND parent_object_id = OBJECT_ID(N'[dbo].[wordsfileprogram]'))
ALTER TABLE [dbo].[wordsfileprogram]  WITH CHECK ADD  CONSTRAINT [FK_wordsfileprogram_files] FOREIGN KEY([Files_idFiles])
REFERENCES [dbo].[files] ([idFiles])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_wordsfileprogram_files]') AND parent_object_id = OBJECT_ID(N'[dbo].[wordsfileprogram]'))
ALTER TABLE [dbo].[wordsfileprogram] CHECK CONSTRAINT [FK_wordsfileprogram_files]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_wordsfileprogram_programwords]') AND parent_object_id = OBJECT_ID(N'[dbo].[wordsfileprogram]'))
ALTER TABLE [dbo].[wordsfileprogram]  WITH CHECK ADD  CONSTRAINT [FK_wordsfileprogram_programwords] FOREIGN KEY([programwords_idprogramwords])
REFERENCES [dbo].[programwords] ([idprogramwords])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_wordsfileprogram_programwords]') AND parent_object_id = OBJECT_ID(N'[dbo].[wordsfileprogram]'))
ALTER TABLE [dbo].[wordsfileprogram] CHECK CONSTRAINT [FK_wordsfileprogram_programwords]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_wordsfiles_files]') AND parent_object_id = OBJECT_ID(N'[dbo].[wordsfiles]'))
ALTER TABLE [dbo].[wordsfiles]  WITH CHECK ADD  CONSTRAINT [FK_wordsfiles_files] FOREIGN KEY([Files_idFiles])
REFERENCES [dbo].[files] ([idFiles])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_wordsfiles_files]') AND parent_object_id = OBJECT_ID(N'[dbo].[wordsfiles]'))
ALTER TABLE [dbo].[wordsfiles] CHECK CONSTRAINT [FK_wordsfiles_files]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_wordsfiles_words]') AND parent_object_id = OBJECT_ID(N'[dbo].[wordsfiles]'))
ALTER TABLE [dbo].[wordsfiles]  WITH CHECK ADD  CONSTRAINT [FK_wordsfiles_words] FOREIGN KEY([Words_idWords])
REFERENCES [dbo].[words] ([idWords])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_wordsfiles_words]') AND parent_object_id = OBJECT_ID(N'[dbo].[wordsfiles]'))
ALTER TABLE [dbo].[wordsfiles] CHECK CONSTRAINT [FK_wordsfiles_words]
GO
/****** Object:  StoredProcedure [dbo].[txTX]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[txTX]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[txTX] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[txTX] 
	 @p1 INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO dbo.words (Word)
	(
	       Select dbo.duplicatewords.word from dbo.duplicatewords group by word
	)
	
	SET @p1 = 1
    Select dbo.duplicatewords.word from dbo.duplicatewords group by word
	SET @p1 = 2

	return 100

END
GO
/****** Object:  StoredProcedure [dbo].[txTX2]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[txTX2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[txTX2] AS' 
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[txTX2]
	 @p1 INT OUTPUT
AS
BEGIN
	declare @p2 int;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO dbo.words (Word)
	(
	       Select dbo.duplicatewords.word from dbo.duplicatewords group by word
	)
	
	SET @p1 = 1
    Select dbo.duplicatewords.word from dbo.duplicatewords group by word
	SET @p1 = 2
	set @p2 = 333
	return @p2

END
GO
/****** Object:  StoredProcedure [dbo].[Update_DB_word]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Update_DB_word]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Update_DB_word] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Update_DB_word]
				@p1 INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	-- Insert idWord and idfile in Wordfiles von words already in the db

INSERT INTO wordsfiles (Files_idFiles, Words_idWords)
(
	Select 
			filenumandword.pkfiles, words.idWords from filenumandword, words
	where
			filenumandword.word = words.Word
)
WAITFOR DELAY '00:00:00.500' 
DELETE filenumandword FROM filenumandword
inner join words ON filenumandword.word = words.Word
set @p1 = 1;
 -- Search and insert duplicated words 
INSERT INTO dbo.words (Word)
(
       Select dbo.duplicatewords.word from dbo.duplicatewords group by word
) 
	-- Insert idWord and idfile in Wordfiles von words duplicated
WAITFOR DELAY '00:00:00.500' 
INSERT INTO wordsfiles (Files_idFiles, Words_idWords)
(
        Select filenumandword.pkfiles, words.idWords from filenumandword, words
		       where filenumandword.word = words.Word 
)
WAITFOR DELAY '00:00:00.500' 
DELETE filenumandword FROM filenumandword
where filenumandword.word IN (Select duplicatewords.word from duplicatewords);
set @p1 = 2;

INSERT INTO words (Word)
(
       Select filenumandword.word  from filenumandword
)

INSERT INTO wordsfiles (Files_idFiles, Words_idWords)
(
        Select filenumandword.pkfiles, words.idWords from filenumandword, words
		       where filenumandword.word = words.Word 
)
set @p1 = 3
WAITFOR DELAY '00:00:00.500' 
TRUNCATE TABLE filenumandword;
IF((SELECT COUNT(*) from filenumandword) = 0)
	set @p1 = 4

END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_DB_WORD_PROG]    Script Date: 14/03/2024 14:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UPDATE_DB_WORD_PROG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UPDATE_DB_WORD_PROG] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UPDATE_DB_WORD_PROG] 
					@p1 INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert idWord and idfile in Wordfiles von words already in the db
INSERT INTO wordsfileprogram (Files_idFiles, programwords_idprogramwords)
(
	Select 
			filenumandword_pro.pkfile, programwords.idprogramwords from filenumandword_pro, programwords
	where
			filenumandword_pro.word = programwords.Word
)
WAITFOR DELAY '00:00:00.500' 
DELETE filenumandword_pro FROM filenumandword_pro
inner join programwords ON filenumandword_pro.word = programwords.Word
set @p1 = 1;


 -- Search and insert duplicated words 
INSERT INTO dbo.programwords(Word)
(
       Select dbo.DUPLICATEWORDPROG.word from dbo.DUPLICATEWORDPROG group by word
) 
WAITFOR DELAY '00:00:00.500' 
	-- Insert idWord and idfile in Wordfiles von words duplicated
INSERT INTO wordsfileprogram (Files_idFiles, programwords_idprogramwords)
(
        Select filenumandword_pro.pkfile, programwords.idprogramwords from filenumandword_pro, programwords
		       where filenumandword_pro.word = programwords.Word 
)
WAITFOR DELAY '00:00:00.500' 
DELETE filenumandword_pro FROM filenumandword_pro
where filenumandword_pro.word IN (Select DUPLICATEWORDPROG.word from DUPLICATEWORDPROG);
set @p1 = 2;

INSERT INTO programwords (Word)
(
       Select filenumandword_pro.word  from filenumandword_pro
)

INSERT INTO wordsfileprogram (Files_idFiles, programwords_idprogramwords)
(
        Select filenumandword_pro.pkfile, programwords.idprogramwords from filenumandword_pro, programwords
		       where filenumandword_pro.word = programwords.Word 
)

set @p1 = 3
WAITFOR DELAY '00:00:00.500' 
TRUNCATE TABLE filenumandword_pro;
IF((SELECT COUNT(*) from filenumandword_pro) = 0)
	set @p1 = 4

END
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'DUPLICATEWORDPROG', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "filenumandword_pro"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 143
               Right = 248
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 1620
         Table = 1170
         Output = 1395
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DUPLICATEWORDPROG'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'DUPLICATEWORDPROG', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DUPLICATEWORDPROG'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'duplicatewords', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "filenumandword"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'duplicatewords'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'duplicatewords', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'duplicatewords'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'View_1', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "filenumandword"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "words"
            Begin Extent = 
               Top = 87
               Left = 485
               Bottom = 183
               Right = 655
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 2655
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'View_1', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'wordprofrequenze', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "wordsfileprogram"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 298
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wordprofrequenze'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'wordprofrequenze', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'wordprofrequenze'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'WordsFrequenze', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "wordsfiles"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WordsFrequenze'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'WordsFrequenze', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WordsFrequenze'
GO
USE [master]
GO
ALTER DATABASE [MyBiblioCDsDB] SET  READ_WRITE 
GO