/****** Object:  StoredProcedure [dbo].[CommandsPerHour]    Script Date: 12/31/2020 10:02:44 PM ******/
DROP PROCEDURE [dbo].[CommandsPerHour]
GO
/****** Object:  StoredProcedure [dbo].[CommandsPerHour]    Script Date: 12/31/2020 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Walker
-- Create date: 10/25/18
-- Description:	CommandsPerHour
-- =============================================
create PROCEDURE [dbo].[CommandsPerHour] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT TOP(12)
		CAST(CreatedDate as date) AS Date,
		DATEPART(hour,CreatedDate) AS Hour,
		COUNT(*) AS Count
	FROM CommandStats
	GROUP BY CAST(CreatedDate as date),
		DATEPART(hour,CreatedDate)
	order by Date desc

END
GO
