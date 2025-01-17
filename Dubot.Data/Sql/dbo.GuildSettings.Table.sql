ALTER TABLE [dbo].[GuildSettings] DROP CONSTRAINT [FK_GuildSettings_Settings]
GO
ALTER TABLE [dbo].[GuildSettings] DROP CONSTRAINT [FK_GuildSettings_Guilds]
GO
/****** Object:  Table [dbo].[GuildSettings]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[GuildSettings]
GO
/****** Object:  Table [dbo].[GuildSettings]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuildSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuildId] [bigint] NOT NULL,
	[GuildName] [nvarchar](50) NOT NULL,
	[SettingId] [int] NOT NULL,
	[Value1] [nvarchar](512) NOT NULL,
	[Value2] [nvarchar](512) NULL,
	[CreatedId] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GuildSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GuildSettings]  WITH CHECK ADD  CONSTRAINT [FK_GuildSettings_Guilds] FOREIGN KEY([GuildId])
REFERENCES [dbo].[Guilds] ([GuildId])
GO
ALTER TABLE [dbo].[GuildSettings] CHECK CONSTRAINT [FK_GuildSettings_Guilds]
GO
ALTER TABLE [dbo].[GuildSettings]  WITH CHECK ADD  CONSTRAINT [FK_GuildSettings_Settings] FOREIGN KEY([SettingId])
REFERENCES [dbo].[Settings] ([SettingId])
GO
ALTER TABLE [dbo].[GuildSettings] CHECK CONSTRAINT [FK_GuildSettings_Settings]
GO
