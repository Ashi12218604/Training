create proc usp_getstudentname
as
begin 
select * from [dbo].[College]
end

exec usp_getstudentname