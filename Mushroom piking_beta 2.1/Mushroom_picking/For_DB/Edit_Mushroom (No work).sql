USE [Sample]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Edit_People]	
	@DefaultPeople nvarchar(max)
AS
SET NOCOUNT ON;	
BEGIN
	CREATE table #Split (ID int primary key, First_Name nvarchar(50), Last_Name nvarchar(50), Email_Address nvarchar(50), Phone_Number varchar(100))
	INSERT into #Split(ID, First_Name, Last_Name, Email_Address, Phone_Number)
		SELECT value FROM STRING_SPLIT(@DefaultPeople, ',')
	SELECT * FROM #Split
	--DECLARE @VARIABLE nvarchar(max) = null
	--@VARIABLE = CONVERT(nvarchar(max), STRING_SPLIT(@DefaultPeople, '|'))
	--SELECT @VARIABLE;
	--INSERT INTO PEOPLE ()
END
SET NOCOUNT OFF;	

