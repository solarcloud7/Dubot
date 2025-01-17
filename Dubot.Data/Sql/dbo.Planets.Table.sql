/****** Object:  Table [dbo].[Planets]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[Planets]
GO
/****** Object:  Table [dbo].[Planets]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planets](
	[Id] [int] NOT NULL,
	[PlanetName] [nvarchar](50) NOT NULL,
	[ParentPlanetId] [int] NULL,
	[Gravity] [decimal](3, 2) NULL,
	[Atmosphere] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (1, N'Alioth', NULL, CAST(1.00 AS Decimal(3, 2)), 3500)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (2, N'Alioth M1', 1, CAST(0.24 AS Decimal(3, 2)), 0)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (3, N'Alioth M4', 1, CAST(0.24 AS Decimal(3, 2)), 0)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (4, N'Sanctuary', 1, CAST(1.00 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (5, N'Feli', NULL, CAST(0.48 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (6, N'Feli M1', 5, CAST(0.11 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (7, N'Ion', NULL, CAST(0.36 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (8, N'Ion M1', 7, CAST(0.09 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (9, N'Ion M2', 7, CAST(0.12 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (10, N'Jago', NULL, CAST(0.50 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (11, N'Lacobus', NULL, CAST(0.46 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (12, N'Lacobus M1', 11, CAST(0.14 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (13, N'Lacobus M2', 11, CAST(0.11 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (14, N'Lacobus M3', 11, CAST(0.12 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (15, N'Madis', NULL, CAST(0.36 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (16, N'Madis M1', 15, CAST(0.08 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (17, N'Madis M2', 15, CAST(0.10 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (18, N'Madis M3', 15, CAST(0.12 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (19, N'Sicari', NULL, CAST(0.41 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (20, N'Sinnen', NULL, CAST(0.44 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (21, N'Sinnen M1', 20, CAST(0.14 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (22, N'Symeon', NULL, CAST(0.39 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (23, N'Talemai', NULL, CAST(0.46 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (24, N'Talemai M1', 23, CAST(0.12 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (25, N'Talemai M2', 23, CAST(0.10 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (26, N'Talemai M3', 23, CAST(0.09 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (27, N'Teoma', NULL, CAST(0.49 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (28, N'Thades', NULL, CAST(0.50 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (29, N'Thades M1', 28, CAST(0.11 AS Decimal(3, 2)), NULL)
INSERT [dbo].[Planets] ([Id], [PlanetName], [ParentPlanetId], [Gravity], [Atmosphere]) VALUES (30, N'Thades M2', 28, CAST(0.12 AS Decimal(3, 2)), NULL)
