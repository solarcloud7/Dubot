ALTER TABLE [dbo].[Guilds] DROP CONSTRAINT [DF_Guilds_Owner]
GO
ALTER TABLE [dbo].[Guilds] DROP CONSTRAINT [DF_Guilds_Name]
GO
/****** Object:  Table [dbo].[Guilds]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[Guilds]
GO
/****** Object:  Table [dbo].[Guilds]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guilds](
	[GuildId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Owner] [nvarchar](50) NOT NULL,
	[CmdPrefix] [nvarchar](3) NULL,
 CONSTRAINT [PK_Guilds_1] PRIMARY KEY CLUSTERED 
(
	[GuildId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Guilds] ADD  CONSTRAINT [DF_Guilds_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Guilds] ADD  CONSTRAINT [DF_Guilds_Owner]  DEFAULT ('') FOR [Owner]
GO
