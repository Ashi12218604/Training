--Q4 Inner Join
select s.studentname , c.coursename, t.trainername, e.exammonth,e.examyear
from student s
inner join Exam e on s.studentId=e.studentId
inner join Course c on e.courseid=c.courseid
inner join trainer t on c.trainerid=t.trainerid


--Q5 Date Function

select s.studentname, sum(e.marks) as Total
from student s
inner join Exam e on
e.studentid=s.studentid
where e.examyear=year(getdate())
group by s.studentname;