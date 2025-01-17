ALTER TABLE [dbo].[CommandStats] DROP CONSTRAINT [FK_CommandStats_BotCommands]
GO
/****** Object:  Table [dbo].[CommandStats]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[CommandStats]
GO
/****** Object:  Table [dbo].[CommandStats]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommandStats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommandId] [int] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ErrorMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_CommandStats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CommandStats]  WITH CHECK ADD  CONSTRAINT [FK_CommandStats_BotCommands] FOREIGN KEY([CommandId])
REFERENCES [dbo].[BotCommands] ([Id])
GO
ALTER TABLE [dbo].[CommandStats] CHECK CONSTRAINT [FK_CommandStats_BotCommands]
GO
