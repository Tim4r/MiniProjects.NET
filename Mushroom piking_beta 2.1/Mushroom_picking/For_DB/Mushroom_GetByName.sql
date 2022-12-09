USE [Mushrooms]
GO
/****** Object:  StoredProcedure [dbo].[People_GetByLastName]    Script Date: 22.08.2022 12:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Mushroom_GetByName]
	@SearthMushroom nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.Mushrooms
	WHERE NameMushroom = @SearthMushroom

END
