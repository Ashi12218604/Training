--Q8 Union 
select s.studentname, e.marks ,'HIGH' as Category
from student s
inner join exam e 
on e.studentid=s.studentid
where e.marks>80
union
select s.studentname, e.marks ,'LOW' as Category
from student s
inner join exam e 
on e.studentid=s.studentid
where e.marks<40


-- Q9 Trigger

create or alter trigger updaterewardpoint
on Exam after insert 
as begin
update s set RewardPoints=RewardPoints+
case
when i.marks>=80 then 10
when i.marks>=60 then 5
else 2 end
from student s

inner join inserted i on
s.studentid=i.studentid;
end;
select  * from student
select * from exam
select StudentId, StudentName, RewardPoints
from Student;
