/****** Object:  StoredProcedure [dbo].[CommandsPerDay]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP PROCEDURE [dbo].[CommandsPerDay]
GO
/****** Object:  StoredProcedure [dbo].[CommandsPerDay]    Script Date: 12/31/2020 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Walker
-- Create date: 10/25/18
-- Description:	CommandsPerDay
-- =============================================
CREATE PROCEDURE [dbo].[CommandsPerDay] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
--Commands per day
  Select TOP(7)
    Count(*) as Count
  , dateadd(DAY,0, datediff(day,0, CreatedDate)) as Day
  from CommandStats as s
   group by dateadd(DAY,0, datediff(day,0, CreatedDate))

END
GO
