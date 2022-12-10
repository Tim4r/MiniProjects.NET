USE [Mushrooms]
GO
/****** Object:  StoredProcedure [dbo].[Create_Mushroom]    Script Date: 03.12.2022 23:25:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Create_Mushroom]
	@NameMushroom nvarchar(50),
	@NameKingdom nvarchar(50),
	@NameDepartment nvarchar(50),
	@NameGenus nvarchar(50),
	@NameType nvarchar(50),
	@Edibility nvarchar(50),
	@Weight int,
	@Cost int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Mushrooms
	VALUES (@NameMushroom, @NameKingdom, @NameDepartment, @NameGenus, @NameType, @Edibility, @Weight, @Cost);

END
