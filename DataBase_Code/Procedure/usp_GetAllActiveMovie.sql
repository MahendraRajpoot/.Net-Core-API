GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetAllActiveMovie]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_GetAllActiveMovie]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
-- =============================================
-- Author:  		Mahendra S Rajpoot
-- Created Date:	18-Jan-2021
-- Description:		Get All Active Movie records
-- Modified By:
-- Modified Date:
-- Modified Reason:
-- =============================================
CREATE PROCEDURE dbo.usp_GetAllActiveMovie
AS
BEGIN

    SELECT 
    Movie.Movie_ID,
    Movie.Movie_Name,
    Movie.Description,
    Movie.Release_Date,
    Movie.Status,
    Movie.Created_By,
    Movie.Created_Date,
    Movie.Updated_By,
    Movie.Updated_Date,
	(SELECT ISNULL(SUM(Movie_Rating.rating)/COUNT(Movie_Rating.rating), 0) 
	FROM Movie_Rating WHERE Movie_Rating.Movie_ID = Movie.Movie_ID) AS Average_Rating
    FROM Movie WITH (NOLOCK) 	 
    WHERE Movie.Status = 1

END
GO

