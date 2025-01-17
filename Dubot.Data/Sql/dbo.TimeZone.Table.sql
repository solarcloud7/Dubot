ALTER TABLE [dbo].[TimeZone] DROP CONSTRAINT [FK_TimeZone_TimeZone]
GO
/****** Object:  Table [dbo].[TimeZone]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP TABLE [dbo].[TimeZone]
GO
/****** Object:  Table [dbo].[TimeZone]    Script Date: 12/31/2020 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeZone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[TimeZoneId] [nvarchar](50) NULL,
 CONSTRAINT [PK_TimeZone_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TimeZone]  WITH CHECK ADD  CONSTRAINT [FK_TimeZone_TimeZone] FOREIGN KEY([Id])
REFERENCES [dbo].[TimeZone] ([Id])
GO
ALTER TABLE [dbo].[TimeZone] CHECK CONSTRAINT [FK_TimeZone_TimeZone]
GO
