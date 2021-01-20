GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InsertErrorLogs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_InsertErrorLogs]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
-- =============================================
-- Author:  	    Mahendra Singh Rajpoot
-- Company Name:    Chaster IT solutions Pvt. Ltd.
-- Created Date:	18-Jan-2021
-- Description:		Insert record into Error log
-- Modified By:
-- Modified Date:
-- Modified Reason:  For Error Logs
-- =============================================
CREATE PROCEDURE [dbo].[usp_InsertErrorLogs]
@Application_Code NVARCHAR(10) = NULL,
@Host NVARCHAR(100) = NULL,
@Error_Type NVARCHAR(50) = NULL,
@Error_Message NVARCHAR(400) = NULL,
@Stack_Trace NVARCHAR(MAX) = NULL,
@Server_ID NVARCHAR(200) = NULL,
@Error_Additional_Information NVARCHAR(MAX) = NULL,
@Error_Inner_Exception NVARCHAR(MAX) = NULL
AS
BEGIN

    INSERT INTO Error_Logs(
     Time_Stamp,
	 Application_Code,
     Host,
     Error_Type,
     Error_Message,
     Stack_Trace,
     Server_ID,
	 Error_Additional_Information,
	 Error_Inner_Exception)
	 VALUES
	 (GETDATE(),
	 @Application_Code,
     @Host,
     @Error_Type,
     @Error_Message,
     @Stack_Trace,
     @Server_ID,
	 @Error_Additional_Information,
	 @Error_Inner_Exception)

END
