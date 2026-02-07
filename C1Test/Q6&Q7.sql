--Q6 Substring and left

select s.studentname,
left(s.studentname,3)+left(c.coursename,2)+cast(s.studentId as varchar)
as Student_LoginId
from student s
inner join Exam e 
on e.studentId=s.studentId
inner join Course c 
on e.CourseId=c.CourseId


--Q7 Subquery

select s.studentname 
from student s
inner join exam e on e.studentid=s.studentid
where e.marks>(select avg(marks) from exam)