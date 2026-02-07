--Q2 Alter Table
alter table Student
add RewardPoints int default 0;
select * from student


 --Q3 Check Constraint
alter table student 
add constraint rwpck
check (RewardPoints between 0 and 100)
select * from student
