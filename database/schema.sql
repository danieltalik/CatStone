USE [master]
GO
/****** Object:  Database [CatStone]    Script Date: 8/13/2018 5:13:43 PM ******/
CREATE DATABASE [CatStone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CatStone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\CatStone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CatStone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\CatStone.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CatStone] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CatStone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CatStone] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [CatStone] SET ANSI_NULLS ON 
GO
ALTER DATABASE [CatStone] SET ANSI_PADDING ON 
GO
ALTER DATABASE [CatStone] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [CatStone] SET ARITHABORT ON 
GO
ALTER DATABASE [CatStone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CatStone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CatStone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CatStone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CatStone] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [CatStone] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [CatStone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CatStone] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [CatStone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CatStone] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CatStone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CatStone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CatStone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CatStone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CatStone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CatStone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CatStone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CatStone] SET RECOVERY FULL 
GO
ALTER DATABASE [CatStone] SET  MULTI_USER 
GO
ALTER DATABASE [CatStone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CatStone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CatStone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CatStone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CatStone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CatStone] SET QUERY_STORE = OFF
GO
USE [CatStone]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CatStone]
GO
/****** Object:  Table [dbo].[cat_skill]    Script Date: 8/13/2018 5:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cat_skill](
	[cat_id] [int] NOT NULL,
	[skill_id] [int] NOT NULL,
 CONSTRAINT [PK_Cats_Skills_cat_id_skill_id] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC,
	[skill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cats]    Script Date: 8/13/2018 5:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[color] [varchar](50) NULL,
	[hair_length] [varbinary](50) NULL,
	[age] [int] NULL,
	[prior_exp] [varchar](250) NULL,
	[photo] [varbinary](max) NULL,
	[is_featured] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 8/13/2018 5:13:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[skill] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CatStone] SET  READ_WRITE 
GO
