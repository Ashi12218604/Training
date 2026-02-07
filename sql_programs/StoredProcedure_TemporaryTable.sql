create or alter proc usp_BonusCalculation
as
begin
create table #bonuscalculator(Name nvarchar(50),Total int, Bonus int);
insert into #bonuscalculator(Name,Total) select Name, Total from [dbo].[College]
update #bonuscalculator set bonus=500 where Total>280;
select * from #bonuscalculator
end
exec usp_BonusCalculation

-----------------------------------------------------------------------------------------------------
create or alter proc usp_StudentsPassingAdd5
as
begin
create table #passingstudent(Name nvarchar(50),M1 int, UpdatedM1 nvarchar(10));
insert into #passingstudent(Name,M1) select Name,M1 from [dbo].[College] declare beforepass int
select beforepass=count(*) from #passingstudent where M1>=35;
update #passingstudent set UpdatedM1='Pass' where (M1+5)>=35;
update #passingstudent set UpdatedM1='Fail'
where UpdatedM1 IS Null;
Declare @AfterPassint;
select @AfterPass = COUNT(*) from #passingstudent
where UpdatedM1 = 'Pass';
select @BeforePass AS Passed_Before,@AfterPass AS Passed_After;
select * from #passingstudent
end
exec usp_StudentsPassingAdd5

------------------------------------------------------------------------------------------------------
