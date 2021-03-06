USE [CatStone]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_Reviews_Users]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_Reviews_Cats]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 8/23/2018 1:32:08 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 8/23/2018 1:32:08 PM ******/
DROP TABLE [dbo].[Skills]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 8/23/2018 1:32:08 PM ******/
DROP TABLE [dbo].[Reviews]
GO
/****** Object:  Table [dbo].[Cats]    Script Date: 8/23/2018 1:32:08 PM ******/
DROP TABLE [dbo].[Cats]
GO
/****** Object:  Table [dbo].[cat_skill]    Script Date: 8/23/2018 1:32:08 PM ******/
DROP TABLE [dbo].[cat_skill]
GO
/****** Object:  Table [dbo].[cat_skill]    Script Date: 8/23/2018 1:32:08 PM ******/
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
/****** Object:  Table [dbo].[Cats]    Script Date: 8/23/2018 1:32:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[color] [varchar](50) NULL,
	[hair_length] [varchar](50) NULL,
	[age] [int] NULL,
	[prior_exp] [varchar](250) NULL,
	[photo] [varchar](50) NULL,
	[is_featured] [bit] NOT NULL,
	[description] [varchar](max) NULL,
	[isEmployed] [bit] NOT NULL,
	[gender] [varchar](10) NULL,
	[is_approved] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 8/23/2018 1:32:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[cat_id] [int] NOT NULL,
	[date] [datetime] NULL,
	[rating] [int] NOT NULL,
	[title] [varchar](150) NULL,
	[sucess_story] [varchar](max) NULL,
	[review] [varchar](max) NULL,
	[is_approved] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 8/23/2018 1:32:09 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 8/23/2018 1:32:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[is_admin] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cats] ADD  DEFAULT ((0)) FOR [is_featured]
GO
ALTER TABLE [dbo].[Cats] ADD  DEFAULT ((0)) FOR [isEmployed]
GO
ALTER TABLE [dbo].[Cats] ADD  DEFAULT ((0)) FOR [is_approved]
GO
ALTER TABLE [dbo].[Reviews] ADD  DEFAULT ((0)) FOR [rating]
GO
ALTER TABLE [dbo].[Reviews] ADD  DEFAULT ((0)) FOR [is_approved]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [is_admin]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Cats] FOREIGN KEY([cat_id])
REFERENCES [dbo].[Cats] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Cats]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users]
GO
