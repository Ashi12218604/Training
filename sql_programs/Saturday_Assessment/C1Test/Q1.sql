-- Q1
create table student
(studentId int primary key, studentname varchar(50), joiningdate date)

create table Trainer
( TrainerId int primary key,TrainerName varchar(50) )

create table Course
(CourseId int primary key, Coursename varchar(50), coursefee int,
TrainerId int foreign key references Trainer(TrainerId))

create table Exam
(MarksId int primary key, ExamMonth int,ExamYear int,
StudentId int foreign key references student(StudentId),
CourseId int foreign key references Course(CourseId))

alter table Exam
add marks int

select * from student
select * from Trainer
select * from Course
select * from Exam



