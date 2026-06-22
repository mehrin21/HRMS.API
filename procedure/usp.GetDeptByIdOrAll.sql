-- procedure for getall department by id or get all
--CREATE SCHEMA usp;
--GO;

CREATE OR ALTER PROCEDURE usp.GetDeptByIdOrAll
 @ID INT = 0
AS
BEGIN
	SET NOCOUNT ON;
	IF @ID = 0
	BEGIN
		SELECT * FROM Departments;
	END
	ELSE
	BEGIN
		SELECT * 
		FROM Departments
		WHERE DeptId = @ID;
	END

END
GO


-----------------------------------------------------------------------------------------------------------------
SET STATISTICS IO ON;

EXEC usp.GetDeptByIdOrAll @ID = 1;

SET STATISTICS IO OFF;