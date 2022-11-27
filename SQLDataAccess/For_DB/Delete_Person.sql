USE [Sample]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeletePerson]
	@deleteID INT,
	@resultDelete BIT OUTPUT
AS
SET NOCOUNT ON
BEGIN
	IF (EXISTS (SELECT * FROM People
				WHERE @deleteID = People.ID))
		BEGIN
			DELETE FROM People
			WHERE @deleteID = People.ID
			SET @resultDelete = 'true'
		END;
	ELSE
		SET @resultDelete = 'false'
END
SET NOCOUNT OFF
GO