/****** Object:  StoredProcedure [dbo].[CommandsPerDayPerPerson]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP PROCEDURE [dbo].[CommandsPerDayPerPerson]
GO
/****** Object:  StoredProcedure [dbo].[CommandsPerDayPerPerson]    Script Date: 12/31/2020 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Walker
-- Create date: 10/25/18
-- Description:	CommandsPerDayPerPerson
-- =============================================
create PROCEDURE [dbo].[CommandsPerDayPerPerson]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Select Count(*) as Count
	, dateadd(DAY,0, datediff(day,0, CreatedDate)) as Day
	, u.UserName
	from CommandStats as s
	inner join Users u on u.Id = s.UserId
	group by dateadd(DAY,0, datediff(day,0, CreatedDate)), u.UserName


END
GO
