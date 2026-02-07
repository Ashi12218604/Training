ALTER PROCEDURE dbo.uspGetStudentCountByDept
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION Trans_One;

INSERT INTO Hostel2 (RoomNo, ID, HostelId)
VALUES (675, 15, 6);


        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION Trans_One;
        END
        ELSE
        BEGIN
            COMMIT TRANSACTION Trans_One;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION Trans_One;

        -- show actual error (important)
        THROW;
    END CATCH
END;
GO


exec uspGetStudentCountByDept

----------------------------------------------------------------------------------------------
ALTER TABLE dbo.College
DROP CONSTRAINT CK_College_Department;


ALTER PROCEDURE [dbo].[uspgetstudentcountbydept]
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION Trans_One;
    
        UPDATE College
        SET Department = 'CSE'
        WHERE Department = 'BTECH';
        INSERT INTO Hostel2 (ID,RoomNo,HostelId)
        VALUES (77,221,19);
        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION Trans_One;
            RETURN;
        END
        else
        COMMIT TRANSACTION Trans_One;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION Trans_One;

        THROW; 
    END CATCH
END;
GO
EXEC [dbo].[uspgetstudentcountbydept]

select * from College

select * from Hostel2