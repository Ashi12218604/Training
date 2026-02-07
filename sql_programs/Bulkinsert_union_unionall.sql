insert into [dbo].[Hostel2]
select * 
from [dbo].[Hostel3]

select * from [dbo].[Hostel2]
-----------------------------------------------------------------------------------------
select * from[dbo].[College]
union  -- filter outs duplicates and keep only unique rows
select * from [dbo].[College]

select * from[dbo].[College]
union all   -- includes the duplicated records of rows
select * from [dbo].[College]