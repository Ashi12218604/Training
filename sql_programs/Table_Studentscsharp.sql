CREATE TABLE studentscsharp
(
    Id INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Department VARCHAR(50) NOT NULL,
    Gender CHAR(1) NOT NULL,
    Location VARCHAR(50) NOT NULL
);

INSERT INTO studentscsharp (Id, Name, Department, Gender, Location)
VALUES
(1, 'Ashi',     'CSE',     'F', 'Dehradun'),
(2, 'Mari',     'MCA',     'M', 'Chennai'),
(3, 'Sanjana',  'CSE',     'F', 'Hyderabad'),
(4, 'Sabeer',   'Navy',    'M', 'Telangana'),
(5, 'Mustafeez','CSE',     'M', 'Kadappa'),
(6, 'Raima',    'Finance', 'F', 'Hyderabad'),
(7, 'Shahid',   'Poetry',  'M', 'Bangalore');


select * from studentscsharp