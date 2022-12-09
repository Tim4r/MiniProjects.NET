USE [Mushrooms]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteMushroom]
	@deleteID INT,
	@resultDelete BIT OUTPUT
AS
SET NOCOUNT ON
BEGIN
	IF (EXISTS (SELECT * FROM Mushrooms
				WHERE @deleteID = Mushrooms.ID))
		BEGIN
			DELETE FROM Mushrooms
			WHERE @deleteID = Mushrooms.ID
			SET @resultDelete = 'true'
		END;
	ELSE
		SET @resultDelete = 'false'
END
SET NOCOUNT OFF
GO