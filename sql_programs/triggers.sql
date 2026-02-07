alter trigger prevent_update
on [dbo].[Hostel3] 
for update
as begin
raiserror('you can not update this table',16,1)
rollback
end;
update [dbo].[Hostel3] set RoomNo=165
select * from [dbo].[Hostel3]
create table emp(
empid int identity(1,1) primary key,empname varchar(100),
empsal(dec(10,2)
go