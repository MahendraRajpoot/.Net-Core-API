GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InsertMovieRating]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_InsertMovieRating]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
-- =============================================
-- Author:  		Mahendra S Rajpoot
-- Created Date:	18-Jan-2021
-- Description:		Insert record intoMovie_Rating
-- Modified By:
-- Modified Date:
-- Modified Reason:
-- =============================================
CREATE PROCEDURE dbo.usp_InsertMovieRating
@Movie_ID DECIMAL(18,0) = NULL,
@Rating INT = NULL,
@Comment NVARCHAR(4000) = NULL,
@Created_By DECIMAL(18,0) = NULL
AS
BEGIN
BEGIN TRY  
BEGIN TRANSACTION 

	 IF NOT EXISTS(SELECT 1 FROM Movie_Rating WITH (NOLOCK) WHERE Movie_Rating.Movie_ID = @Movie_ID AND Movie_Rating.Created_By = @Created_By)
	 BEGIN
		INSERT INTO Movie_Rating(
		Movie_ID,
		Rating,
		Comment,
		Status,
		Created_By,
		Created_Date,
		Updated_By,
		Updated_Date) 
		VALUES( 
		@Movie_ID,
		@Rating,
		@Comment,
		1,
		@Created_By,
		GETDATE(),
		@Created_By,
		GETDATE())
	 END
	 ELSE
	 BEGIN
		UPDATE Movie_Rating SET Movie_Rating.Rating = @Rating
		WHERE Movie_Rating.Movie_ID = @Movie_ID AND Movie_Rating.Created_By = @Created_By
	 END

COMMIT TRANSACTION  
END TRY  
BEGIN CATCH  
DECLARE   
@ErrorMessage NVARCHAR(4000),  
@ErrorSeverity INT,  
@ErrorState INT;  
SELECT   
@ErrorMessage = ERROR_MESSAGE(),  
@ErrorSeverity = ERROR_SEVERITY(),  
@ErrorState = ERROR_STATE();  
RAISERROR (  
@ErrorMessage,  
@ErrorSeverity,  
@ErrorState);  
  
IF @@TRANCOUNT > 0  
BEGIN  
ROLLBACK TRANSACTION   
END      
END CATCH     
END    
GO

