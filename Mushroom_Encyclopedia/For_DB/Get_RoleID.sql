USE [Mushrooms]
GO
/****** Object:  StoredProcedure [dbo].[Authorization]    Script Date: 01.11.2022 12:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_RoleID]
	@Parametr_username NVARCHAR(50),
	@RoleID INT OUTPUT
AS
SET NOCOUNT ON
BEGIN

SELECT @RoleID = Logins.RoleID
				FROM Logins 
				WHERE UserName = @Parametr_username
END
SET NOCOUNT OFF
