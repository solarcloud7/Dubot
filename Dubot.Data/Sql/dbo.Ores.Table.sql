/****** Object:  Table [dbo].[Ores]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[Ores]
GO
/****** Object:  Table [dbo].[Ores]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ores](
	[Id] [int] NOT NULL,
	[OreName] [nvarchar](50) NOT NULL,
	[PureName] [nvarchar](50) NOT NULL,
	[Tier] [nvarchar](50) NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	[Volume] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Ores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (1, N'Quartz', N'Silicon', N'1', CAST(2.65 AS Decimal(18, 2)), CAST(2.33 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (2, N'Hematite', N'Iron', N'1', CAST(5.04 AS Decimal(18, 2)), CAST(7.85 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (3, N'Bauxite', N'Aluminum', N'1', CAST(1.28 AS Decimal(18, 2)), CAST(2.70 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (4, N'Coal', N'Carbon', N'1', CAST(1.35 AS Decimal(18, 2)), CAST(2.27 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (5, N'Limestone', N'Calcium', N'2', CAST(2.71 AS Decimal(18, 2)), CAST(1.55 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (6, N'Natron', N'Sodium', N'2', CAST(1.55 AS Decimal(18, 2)), CAST(0.97 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (7, N'Malachite', N'Copper', N'2', CAST(4.00 AS Decimal(18, 2)), CAST(8.96 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (8, N'Chromite', N'Chromium', N'2', CAST(4.54 AS Decimal(18, 2)), CAST(7.19 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (9, N'Pyrite', N'Sulfer', N'3', CAST(5.01 AS Decimal(18, 2)), CAST(1.82 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (10, N'Acanthite', N'Silver', N'3', CAST(7.20 AS Decimal(18, 2)), CAST(10.49 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (11, N'Garnierite', N'Nickel', N'3', CAST(2.60 AS Decimal(18, 2)), CAST(8.91 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (12, N'Petalite', N'Lithium', N'3', CAST(2.41 AS Decimal(18, 2)), CAST(0.53 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (13, N'Gold Nuggets', N'Gold', N'4', CAST(19.30 AS Decimal(18, 2)), CAST(19.30 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (14, N'Cryolite', N'Fluorine', N'4', CAST(2.95 AS Decimal(18, 2)), CAST(1.70 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (15, N'Cobaltite', N'Cobalt', N'4', CAST(6.33 AS Decimal(18, 2)), CAST(8.90 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (16, N'Kolbeckite', N'Scandium', N'4', CAST(2.37 AS Decimal(18, 2)), CAST(2.98 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (17, N'Illmenite', N'Titanium', N'5', CAST(4.55 AS Decimal(18, 2)), CAST(4.51 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (18, N'Rhodonite', N'Manganese', N'5', CAST(3.76 AS Decimal(18, 2)), CAST(7.21 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (19, N'Vanadinite', N'Vanadium', N'5', CAST(6.95 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[Ores] ([Id], [OreName], [PureName], [Tier], [Weight], [Volume]) VALUES (20, N'Columbite', N'Niobium', N'5', CAST(5.38 AS Decimal(18, 2)), CAST(8.57 AS Decimal(18, 2)))
