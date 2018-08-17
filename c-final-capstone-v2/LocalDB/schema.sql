USE [CatStone]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_Reviews_Cats]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__is_admin__2F10007B]
GO
ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [DF__Cats__isEmployed__2E1BDC42]
GO
ALTER TABLE [dbo].[Cats] DROP CONSTRAINT [DF__Cats__is_feature__2D27B809]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/16/2018 3:29:11 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Success_Stories]    Script Date: 8/16/2018 3:29:11 PM ******/
DROP TABLE [dbo].[Success_Stories]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 8/16/2018 3:29:11 PM ******/
DROP TABLE [dbo].[Skills]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 8/16/2018 3:29:11 PM ******/
DROP TABLE [dbo].[Reviews]
GO
/****** Object:  Table [dbo].[Cats]    Script Date: 8/16/2018 3:29:11 PM ******/
DROP TABLE [dbo].[Cats]
GO
/****** Object:  Table [dbo].[cat_skill]    Script Date: 8/16/2018 3:29:11 PM ******/
DROP TABLE [dbo].[cat_skill]
GO
/****** Object:  Table [dbo].[cat_skill]    Script Date: 8/16/2018 3:29:11 PM ******/
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
/****** Object:  Table [dbo].[Cats]    Script Date: 8/16/2018 3:29:11 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 8/16/2018 3:29:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[cat_id] [int] NULL,
	[date] [datetime] NULL,
	[rating] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 8/16/2018 3:29:12 PM ******/
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
/****** Object:  Table [dbo].[Success_Stories]    Script Date: 8/16/2018 3:29:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Success_Stories](
	[cat_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[comment] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/16/2018 3:29:12 PM ******/
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
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (1, 1)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (1, 7)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (2, 6)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (2, 10)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (3, 2)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (3, 5)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (3, 9)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (4, 2)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (4, 11)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (4, 13)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (5, 1)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (5, 3)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (5, 6)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (5, 9)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (6, 2)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (6, 7)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (6, 10)
GO
INSERT [dbo].[cat_skill] ([cat_id], [skill_id]) VALUES (7, 13)
GO
SET IDENTITY_INSERT [dbo].[Cats] ON 
GO
INSERT [dbo].[Cats] ([Id], [name], [color], [hair_length], [age], [prior_exp], [photo], [is_featured], [description], [isEmployed]) VALUES (1, N'Percy', N'orange $ white', N'Long', 12, N'Purficient at wakeup calls', N'Percy.jpg', 1, N'', 0)
GO
INSERT [dbo].[Cats] ([Id], [name], [color], [hair_length], [age], [prior_exp], [photo], [is_featured], [description], [isEmployed]) VALUES (2, N'Fern', N'tabby', N'long', 8, N'Will do anything for bread.', N'fern.jpg', 0, N'', 0)
GO
INSERT [dbo].[Cats] ([Id], [name], [color], [hair_length], [age], [prior_exp], [photo], [is_featured], [description], [isEmployed]) VALUES (3, N'Luna', N'Black & Orange', N'short', 3, N'Flexible for the right opportunity', N'luna.jpg', 0, N'', 0)
GO
INSERT [dbo].[Cats] ([Id], [name], [color], [hair_length], [age], [prior_exp], [photo], [is_featured], [description], [isEmployed]) VALUES (4, N'Picard', N'orange', N'short', 7, N'Licking, Stealing food, Commanding USS Enterprise', N'picard.jpg', 0, N'', 0)
GO
INSERT [dbo].[Cats] ([Id], [name], [color], [hair_length], [age], [prior_exp], [photo], [is_featured], [description], [isEmployed]) VALUES (5, N'Memesiku', N'calico', N'long', 9, N'Flooping, Drooling, Hunting gnats', N'memsiku.jpg', 1, N'', 0)
GO
INSERT [dbo].[Cats] ([Id], [name], [color], [hair_length], [age], [prior_exp], [photo], [is_featured], [description], [isEmployed]) VALUES (6, N'Wulfgang', N'black', N'long', 7, N'Always looking for new ways to assinate dogs', N'wulfgang.jpg', 0, N'', 0)
GO
INSERT [dbo].[Cats] ([Id], [name], [color], [hair_length], [age], [prior_exp], [photo], [is_featured], [description], [isEmployed]) VALUES (7, N'Brahm', N'brown', N'short', 5, N'100% good boy 0% cat', N'brahm.jpg', 0, N'', 0)
GO
SET IDENTITY_INSERT [dbo].[Cats] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 
GO
INSERT [dbo].[Reviews] ([id], [user_id], [cat_id], [date], [rating]) VALUES (1, 1, 4, CAST(N'2018-08-16T15:26:16.610' AS DateTime), 5)
GO
INSERT [dbo].[Reviews] ([id], [user_id], [cat_id], [date], [rating]) VALUES (2, 1, 5, CAST(N'2018-08-16T15:26:16.610' AS DateTime), 5)
GO
INSERT [dbo].[Reviews] ([id], [user_id], [cat_id], [date], [rating]) VALUES (3, 1, 6, CAST(N'2018-08-16T15:26:16.610' AS DateTime), 4)
GO
INSERT [dbo].[Reviews] ([id], [user_id], [cat_id], [date], [rating]) VALUES (4, 2, 7, CAST(N'2018-08-16T15:26:16.610' AS DateTime), 2)
GO
INSERT [dbo].[Reviews] ([id], [user_id], [cat_id], [date], [rating]) VALUES (5, 3, 1, CAST(N'2018-08-16T15:26:16.610' AS DateTime), 3)
GO
INSERT [dbo].[Reviews] ([id], [user_id], [cat_id], [date], [rating]) VALUES (6, 3, 2, CAST(N'2018-08-16T15:26:16.610' AS DateTime), 4)
GO
INSERT [dbo].[Reviews] ([id], [user_id], [cat_id], [date], [rating]) VALUES (7, 3, 3, CAST(N'2018-08-16T15:26:16.610' AS DateTime), 4)
GO
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Skills] ON 
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (1, N'Drooling')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (2, N'Driving')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (3, N'Efficiency expert')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (4, N'Comendering')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (5, N'Pirating')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (6, N'Dependency Injection')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (7, N'Cuddling')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (8, N'Gravity Testing')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (9, N'Filling Boxes')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (10, N'Hate')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (11, N'Schedule Management')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (12, N'Hiding')
GO
INSERT [dbo].[Skills] ([id], [skill]) VALUES (13, N'Life Coach')
GO
SET IDENTITY_INSERT [dbo].[Skills] OFF
GO
INSERT [dbo].[Success_Stories] ([cat_id], [user_id], [date], [comment]) VALUES (1, 3, CAST(N'2018-08-16T15:26:16.613' AS DateTime), N'Percy - Very successful morning wakeups')
GO
INSERT [dbo].[Success_Stories] ([cat_id], [user_id], [date], [comment]) VALUES (2, 3, CAST(N'2018-08-16T15:26:16.613' AS DateTime), N'Fern will find your bread at any costs')
GO
INSERT [dbo].[Success_Stories] ([cat_id], [user_id], [date], [comment]) VALUES (4, 1, CAST(N'2018-08-16T15:26:16.613' AS DateTime), N'Picard has really taken an interest in the cleanliness of my hands')
GO
INSERT [dbo].[Success_Stories] ([cat_id], [user_id], [date], [comment]) VALUES (4, 3, CAST(N'2018-08-16T15:26:16.613' AS DateTime), N'Luna always finds a way')
GO
INSERT [dbo].[Success_Stories] ([cat_id], [user_id], [date], [comment]) VALUES (5, 1, CAST(N'2018-08-16T15:26:16.613' AS DateTime), N'Memesiku is very inviting to strangers, tolerates superiors')
GO
INSERT [dbo].[Success_Stories] ([cat_id], [user_id], [date], [comment]) VALUES (6, 1, CAST(N'2018-08-16T15:26:16.613' AS DateTime), N'Never have I met a cat more determined to kill dogs')
GO
INSERT [dbo].[Success_Stories] ([cat_id], [user_id], [date], [comment]) VALUES (7, 2, CAST(N'2018-08-16T15:26:16.613' AS DateTime), N'Brahm does his best to fit in')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (1, N'Dinah', N'adnmin@email.com.com', N'password', 1)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (2, N'Peter', N'adnmin@email.com.com', N'password', 1)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (3, N'Dan', N'adnmin@email.com.com', N'password', 1)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (4, N'Austin', N'adnmin@email.com.com', N'password', 1)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (5, N'John', N'adnmin@email.com.com', N'password', 1)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (6, N'Babadook', N'babadook@email.com', N'password', 0)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (7, N'rumpelstiltskin', N'rumpdahump@email.com', N'password', 0)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (8, N'Slenderman', N'slendy@email.com', N'password', 0)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (9, N'NightMan', N'EnemyofDayman@email.com', N'password', 0)
GO
INSERT [dbo].[Users] ([Id], [name], [email], [password], [is_admin]) VALUES (10, N'DayMan', N'FighterofNightman@email.com', N'password', 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Cats] ADD  DEFAULT ((0)) FOR [is_featured]
GO
ALTER TABLE [dbo].[Cats] ADD  DEFAULT ((0)) FOR [isEmployed]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [is_admin]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Cats] FOREIGN KEY([cat_id])
REFERENCES [dbo].[Cats] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Cats]
GO
