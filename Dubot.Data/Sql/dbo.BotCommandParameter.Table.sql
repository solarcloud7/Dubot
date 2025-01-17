ALTER TABLE [dbo].[BotCommandParameter] DROP CONSTRAINT [FK_BotCommandParameter_BotCommands]
GO
ALTER TABLE [dbo].[BotCommandParameter] DROP CONSTRAINT [DF_BotCommandParameter_Parameter]
GO
/****** Object:  Table [dbo].[BotCommandParameter]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[BotCommandParameter]
GO
/****** Object:  Table [dbo].[BotCommandParameter]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotCommandParameter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommandId] [int] NOT NULL,
	[ParamName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BotCommandParameter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BotCommandParameter] ADD  CONSTRAINT [DF_BotCommandParameter_Parameter]  DEFAULT ('') FOR [ParamName]
GO
ALTER TABLE [dbo].[BotCommandParameter]  WITH CHECK ADD  CONSTRAINT [FK_BotCommandParameter_BotCommands] FOREIGN KEY([CommandId])
REFERENCES [dbo].[BotCommands] ([Id])
GO
ALTER TABLE [dbo].[BotCommandParameter] CHECK CONSTRAINT [FK_BotCommandParameter_BotCommands]
GO
