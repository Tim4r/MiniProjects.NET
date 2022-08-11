USE [Sample]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insert_Person]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(50),
	@PhoneNumber varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.People
	VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber);

END
