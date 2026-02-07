ALTER TABLE dbo.Hostel2
ALTER COLUMN RoomNo INT NOT NULL;
Go
ALTER TABLE dbo.Hostel2
ADD CONSTRAINT CK_RoomLimit CHECK (RoomNo <= 900);
GO
CREATE OR ALTER PROC dbo.uspLimitedToRoom
AS
BEGIN
    INSERT INTO dbo.Hostel2 (ID, RoomNo, HostelId)
    VALUES (14, 567,5 );
END;
Go

exec dbo.uspLimitedToRoom;
---------------------------------------------------------------------------------------------------

ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_Id_Positive CHECK (Id > 0);
ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_Name
CHECK (Name NOT LIKE '%[^a-zA-Z]%');
ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_Location
CHECK (LEN(Location) > 0);
ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_Department
CHECK (Department IN ('BTECH', 'NAVY', 'BUSINESS'));
ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_Phone
CHECK (
    LEN(PhoneNo) BETWEEN 4 AND 5
    AND PhoneNo NOT LIKE '%[^0-9]%'
);
ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_Gender
CHECK (Gender IN ('Male', 'Female'));


ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_M1 CHECK (M1 BETWEEN 0 AND 100 OR M1 IS NULL);

ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_M2 CHECK (M2 BETWEEN 0 AND 100 OR M2 IS NULL);

ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_M3 CHECK (M3 BETWEEN 0 AND 100 OR M3 IS NULL);

ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_Total
CHECK (
    Total = ISNULL(M1,0) + ISNULL(M2,0) + ISNULL(M3,0)
    OR Total IS NULL
);

ALTER TABLE dbo.College
ADD CONSTRAINT CK_College_Grade
CHECK (Grade IN ('Second', 'Fail'));





select dateAdd(year,1,Getdate()) as warrantydate;
select Datediff(day,'2004-05-20', GETDATE())as age;

ALTER TABLE dbo.College
ADD DOB DATE;

select * from [dbo].[College]

CREATE OR ALTER PROC dbo.uspGetBirthdaysInMyMonth
    @month DATE
as
begin
    SELECT *
    from dbo.College
    where month(DOB) = month(@month);
end;
exec dbo.uspGetBirthdaysInMyMonth @month = '2004-05-20';
