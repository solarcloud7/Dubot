ALTER TABLE [dbo].[BotCommandAlias] DROP CONSTRAINT [FK_BotCommandAlias_BotCommands]
GO
ALTER TABLE [dbo].[BotCommandAlias] DROP CONSTRAINT [DF_BotCommandAlias_Alias]
GO
/****** Object:  Table [dbo].[BotCommandAlias]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[BotCommandAlias]
GO
/****** Object:  Table [dbo].[BotCommandAlias]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotCommandAlias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommandId] [int] NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BotCommandAlias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BotCommandAlias] ADD  CONSTRAINT [DF_BotCommandAlias_Alias]  DEFAULT ('') FOR [Alias]
GO
ALTER TABLE [dbo].[BotCommandAlias]  WITH CHECK ADD  CONSTRAINT [FK_BotCommandAlias_BotCommands] FOREIGN KEY([CommandId])
REFERENCES [dbo].[BotCommands] ([Id])
GO
ALTER TABLE [dbo].[BotCommandAlias] CHECK CONSTRAINT [FK_BotCommandAlias_BotCommands]
GO
