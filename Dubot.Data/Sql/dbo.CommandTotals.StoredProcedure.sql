/****** Object:  StoredProcedure [dbo].[CommandTotals]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP PROCEDURE [dbo].[CommandTotals]
GO
/****** Object:  StoredProcedure [dbo].[CommandTotals]    Script Date: 12/31/2020 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Walker
-- Create date: 10/25/18
-- Description:	CommandTotals
-- =============================================
CREATE PROCEDURE [dbo].[CommandTotals]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Select Count(*) as Count
		, c.CommandName as CommandName
	from CommandStats as s
	inner join BotCommands c on s.CommandId = c.Id
	group by c.CommandName	
	order by Count desc

END
GO
