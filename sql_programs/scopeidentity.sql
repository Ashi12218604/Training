ALTER TABLE dbo.College
DROP CONSTRAINT CK_College_Name;

create or alter proc dbo.uspAddNewStudentWithHostel
as
begin
begin try
       begin transaction;

        declare @NewStudentId int;
        insert into dbo.College
        (
             Id,Name, Location, Department, PhoneNo, gender,
            M1, M2, M3, Total, grade, DOB
        )
        values
        (
            @NewStudentId,'Mr X','Delhi','BTECH','9699', 'Male',90, 85, 88,263,'Second','2000-01-01');
            SET @NewStudentId = SCOPE_IDENTITY();
        insert into dbo.Hostel2 (ID, RoomNo, HostelId)
        values (@NewStudentId, 501, 8);
        commit transaction;
 end try
 begin catch;
        if @@TRANCOUNT>0
         rollback transaction;
throw;
end catch
end;
go

exec uspAddNewStudentWithHostel;
select * from college;
select * from Hostel2;

----------------------------------------------------------------------------------------------------------------