select m.name from [dbo].[Manager] m
inner join [dbo].[Manager] e on
e.managerid=m.id;

select count(e.name) from [dbo].[Manager] e
inner join [dbo].[Manager] m on
e.id=m.managerid;


select * from [dbo].[WrongData]
update [dbo].[WrongData]
set m1=m2,m2=m1

with cte as(select id,m1,m2,(m1+m2) as t
from wrongdata)
update cte 
set m1=t-m2,
m2=t-m1;

