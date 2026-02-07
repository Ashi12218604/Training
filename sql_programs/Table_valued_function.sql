create function GetDepartmentName(@name nvarchar(20))
returns table 
as
return
(select * from [dbo].[College] where Name=@name);
select * from GetDepartmentName('Ashi')


