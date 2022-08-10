USE [Sample]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[People_GetByLastName]
	@LastName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.People
	WHERE LastName = @LastName

END
