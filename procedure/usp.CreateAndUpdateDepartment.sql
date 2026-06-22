-- creating and updating Department
CREATE OR ALTER PROCEDURE usp.CreateAndUpdateDepartment
(
	@DeptId Int = 0,
	@DepartmentCode NVARCHAR(20),
	@DepartmentName NVARCHAR(50),
	@IsActive BIT = 1,
	@CreatedAt DATETIME = NULL,
	@CreatedBy NVARCHAR(10) = 'Admin',
	@ModifiedAt DATETIME = NULL,
	@ModifiedBy NVARCHAR(10) = NULL,
	@IsDeleted BIT = 0
)

AS
BEGIN
 --   DECLARE @NewDepartmentId INT;

	--SELECT @NewDepartmentId =
	--	ISNULL(MAX(DeptId), 0) + 1
	--FROM Departments;

	 IF EXISTS
    (
        SELECT 1
        FROM Departments
        WHERE DepartmentName = @DepartmentName 
		AND DepartmentCode = @DepartmentCode
		AND DeptId <> @DeptId
    )
    BEGIN
        PRINT 'please check the department code and name,entered data already exists';
        RETURN;
    END

	IF @DeptId = 0
	BEGIN
		INSERT INTO Departments
        (
			
            DepartmentName,
            DepartmentCode,
			IsActive,
			CreatedAt,
			CreatedBy,
			ModifiedAt,
			ModifiedBy,
			IsDeleted
        )
        VALUES
        (
			
            @DepartmentName,
            @DepartmentCode,
			@IsActive,
			GETDATE(),
			@CreatedBy,
			GETDATE(),
			@ModifiedBy,
			@IsDeleted
        );

        SELECT
            SCOPE_IDENTITY() AS DepartmentId,
            'Department Created Successfully' AS Message;
	END
	ELSE
	BEGIN
		 IF NOT EXISTS
        (
            SELECT 1
            FROM Departments
            WHERE DeptId = @DeptId
        )
        BEGIN
            RAISERROR('Department not found.', 16, 1);
            RETURN;
        END;
		UPDATE Departments
		SET
		    --DeptId = @DeptId,
            DepartmentName = @DepartmentName,
            DepartmentCode = @DepartmentCode,
			IsActive = @IsActive,
			--CreatedAt = @CreatedAt,
			--CreatedBy = @CreatedBy,
			ModifiedAt = @ModifiedAt,
			ModifiedBy = @ModifiedBy,
			IsDeleted = @IsDeleted
        WHERE DeptId = @DeptId;

		SELECT
		@DeptId AS DepartmentId,
		'Department Updated Successfully' AS Message;
	END
	
END
GO


-----------------------------------------------------
--              TEST CASE
-----------------------------------------------------
EXEC usp.CreateAndUpdateDepartment
    @DepartmentCode = 'IT',
    @DepartmentName = 'Information Technology',
    @CreatedBy = 'Admin';


EXEC usp.CreateAndUpdateDepartment
    @DeptId = 1,
    @DepartmentCode = 'IT01',
    @DepartmentName = 'Information  Updated',
    @ModifiedBy = 'Admin';


SELECT * FROM Departments