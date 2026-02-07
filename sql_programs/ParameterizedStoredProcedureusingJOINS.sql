create proc dbo.uspgetstudentstayinginroom531
@room nvarchar(50),   --input parameter
@studentname nvarchar(50) output   --output parameter
as
begin 
select @studentname=name from[dbo].[College]
inner join [dbo].[Hostel2] on [dbo].[College].Id=[dbo].[Hostel2].Id
where [dbo].[Hostel2].RoomNo=@room
END;

declare @sname nvarchar(50)
Exec dbo.uspgetstudentstayinginroom531
@room=232,
@studentname=@sname output
select @sname