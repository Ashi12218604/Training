create table #Student(ID int, Name varchar(10)) -- local temporary table
insert into #Student values(1,'Ashi')
insert into #Student values(2,'Sanjana')
select * from #Student


-- create table ##Student(ID int, Name varchar(10)) -- global temporary table