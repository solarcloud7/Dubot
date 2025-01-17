ALTER TABLE [dbo].[BotCommands] DROP CONSTRAINT [DF_BotCommands_Display]
GO
/****** Object:  Table [dbo].[BotCommands]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[BotCommands]
GO
/****** Object:  Table [dbo].[BotCommands]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BotCommands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommandName] [nvarchar](50) NOT NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[Example] [nvarchar](200) NOT NULL,
	[Module] [nvarchar](50) NOT NULL,
	[Display] [bit] NOT NULL,
 CONSTRAINT [PK_BotCommands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[BotCommands] ADD  CONSTRAINT [DF_BotCommands_Display]  DEFAULT ((1)) FOR [Display]
GO
