CREATE OR ALTER PROC dbo.uspInsertStudent
AS
BEGIN
    DECLARE @studentcount INT;

    SELECT @studentcount = COUNT(*)
    FROM dbo.Hostel2;

    IF @studentcount < 5
    BEGIN
        INSERT INTO dbo.Hostel2 (ID, RoomNo, HostelId)
        VALUES (343, '122', 1);
    END
END;
GO
EXEC dbo.uspInsertStudent;

