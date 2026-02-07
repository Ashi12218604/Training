-- Creating view for query optimization
create view v1 as 
select location from [dbo].[College] where gender='Male'
select location from v1

create view Job as
select Name from [dbo].[College] where Department='CSE'
select Name from Job

