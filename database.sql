USE [master]
GO
/****** Object:  Database [Project Drink]    Script Date: 11/03/2025 17:22:52 ******/
CREATE DATABASE [Project Drink]

CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coments]    Script Date: 11/03/2025 17:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [nvarchar](50) NOT NULL,
	[coment] [nvarchar](50) NULL,
	[Rating] [int] NULL,
 CONSTRAINT [PK__Ratings__3214EC075513AE68] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Difficulty]    Script Date: 11/03/2025 17:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Difficulty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Difficulty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 11/03/2025 17:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__Ingredie__3214EC075867AED2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measure]    Script Date: 11/03/2025 17:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measure](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeIngredients]    Script Date: 11/03/2025 17:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeIngredients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[recipiesId] [int] NOT NULL,
	[ingredientsId] [int] NOT NULL,
	[measureId] [int] NOT NULL,
	[quantity] [nvarchar](50) NULL,
 CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 11/03/2025 17:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[preparationMethod] [nvarchar](max) NOT NULL,
	[userId] [int] NULL,
	[categoryId] [int] NULL,
	[difficultyId] [int] NULL,
 CONSTRAINT [PK__Recipes__3214EC077D75AA86] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/03/2025 17:22:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[username] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[isAdmin] [bit] NULL,
 CONSTRAINT [PK__Users__3214EC0757038242] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Alcoolic Drinks')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Difficulty] ON 

INSERT [dbo].[Difficulty] ([id], [name]) VALUES (1, N'hhh')
INSERT [dbo].[Difficulty] ([id], [name]) VALUES (2, N'medium')
INSERT [dbo].[Difficulty] ([id], [name]) VALUES (3, N'hard')
SET IDENTITY_INSERT [dbo].[Difficulty] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([id], [name]) VALUES (1, N'Vodka')
INSERT [dbo].[Ingredients] ([id], [name]) VALUES (2, N'Drinks')
INSERT [dbo].[Ingredients] ([id], [name]) VALUES (1002, N'sdaddddddd')
INSERT [dbo].[Ingredients] ([id], [name]) VALUES (1003, N'dasddddddad')
INSERT [dbo].[Ingredients] ([id], [name]) VALUES (1004, N'dsadsa')
INSERT [dbo].[Ingredients] ([id], [name]) VALUES (1005, N'ggggg')
INSERT [dbo].[Ingredients] ([id], [name]) VALUES (1006, N'louro')
INSERT [dbo].[Ingredients] ([id], [name]) VALUES (1007, N'agua')
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
SET IDENTITY_INSERT [dbo].[Measure] ON 

INSERT [dbo].[Measure] ([id], [Name]) VALUES (1, N'jj')
INSERT [dbo].[Measure] ([id], [Name]) VALUES (2, N'cl')
SET IDENTITY_INSERT [dbo].[Measure] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (1, N'Joaos', N'adimin', N'admin', N'admin', 1)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (2, N'John Doe', N'john.doe@example.com', N'johndoe', N'securepassword123', 1)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (6, N'rafael', N'josahn.doe@example.com', N'goldani', N'goldani', 1)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (9, N'Johadasasdasdasddsadasdasdaddasn Doe', N'josahn.doe@exsssssssssamplasdasdasddadasdasde.com', N'jsdohndasdasdasddssssoe', N'securepasswssssoaasdasdasdasdasdsadard123', 1)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (1002, N'Joao', N'joao@email.com', N'jpss', N'123', 0)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (2002, N'carlota', N'caralota@email', N'charlote2', N'123', 0)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (3002, N'Joao lago', N'doutor.lago@hotmail.com', N'lagoelmagos', N'123', 0)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (3003, N'jjojooj', N'joaoao', N'adasdsa', N'123', 0)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (3004, N'TesteService', N'123', N'161', N'123', 0)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (4004, N'teste2asddsa', N'teste2@hotmail,cidadd', N'teste2asddsa', N'123', 0)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (4005, N'teste3dsad', N'teste3@email.comfsdf', N'123fsdf', N'123', 0)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (4006, N'j1s', N'j1s', N'j1', N'12', 0)
INSERT [dbo].[Users] ([id], [name], [email], [username], [password], [isAdmin]) VALUES (4007, N'manda2', N'manda@lemos', N'mdlemos', N'123', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E4C1B0A2F0]    Script Date: 11/03/2025 17:22:52 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__536C85E4C1B0A2F0] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D1053499894A26]    Script Date: 11/03/2025 17:22:52 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__A9D1053499894A26] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Ingredients] FOREIGN KEY([ingredientsId])
REFERENCES [dbo].[Ingredients] ([id])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Ingredients]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Measures] FOREIGN KEY([measureId])
REFERENCES [dbo].[Measure] ([id])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Measures]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Recipes] FOREIGN KEY([recipiesId])
REFERENCES [dbo].[Recipes] ([id])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Recipes]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Category]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Recipes] FOREIGN KEY([difficultyId])
REFERENCES [dbo].[Recipes] ([id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Recipes]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Users] FOREIGN KEY([id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Users]
GO
ALTER TABLE [dbo].[Coments]  WITH CHECK ADD  CONSTRAINT [CK__Ratings__Rating__6477ECF3] CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Coments] CHECK CONSTRAINT [CK__Ratings__Rating__6477ECF3]
GO
USE [master]
GO
ALTER DATABASE [Project Drink] SET  READ_WRITE 
GO
