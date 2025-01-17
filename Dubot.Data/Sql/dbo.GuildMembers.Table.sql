ALTER TABLE [dbo].[GuildMembers] DROP CONSTRAINT [FK_GuildMembers_Users]
GO
ALTER TABLE [dbo].[GuildMembers] DROP CONSTRAINT [FK_GuildMembers_Guilds1]
GO
/****** Object:  Table [dbo].[GuildMembers]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[GuildMembers]
GO
/****** Object:  Table [dbo].[GuildMembers]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuildMembers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GuildId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Nickname] [nvarchar](50) NULL,
 CONSTRAINT [PK_GuidMembers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GuildMembers]  WITH CHECK ADD  CONSTRAINT [FK_GuildMembers_Guilds1] FOREIGN KEY([GuildId])
REFERENCES [dbo].[Guilds] ([GuildId])
GO
ALTER TABLE [dbo].[GuildMembers] CHECK CONSTRAINT [FK_GuildMembers_Guilds1]
GO
ALTER TABLE [dbo].[GuildMembers]  WITH CHECK ADD  CONSTRAINT [FK_GuildMembers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[GuildMembers] CHECK CONSTRAINT [FK_GuildMembers_Users]
GO
