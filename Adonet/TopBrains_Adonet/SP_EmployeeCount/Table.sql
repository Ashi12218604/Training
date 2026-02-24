CREATE TABLE Employees
(
    EmpId INT PRIMARY KEY,
    Name VARCHAR(50),
    Department VARCHAR(50)
);


INSERT INTO Employees VALUES
(1, 'Ashi', 'CSE'),
(2, 'Rahul', 'Sales'),
(3, 'Neha', 'HR'),
(4, 'Rohit', 'Sales'),
(5, 'Pooja', 'IT');


CREATE or alter PROCEDURE sp_GetTotalEmployeeCount
    @TotalCount INT OUTPUT
AS
BEGIN
    SELECT @TotalCount = COUNT(*)
    FROM Employees;
END;
DECLARE @cnt INT;
EXEC sp_GetTotalEmployeeCount @TotalCount = @cnt OUTPUT;
SELECT @cnt AS EmployeeCount;
exec sp_GetTotalEmployeeCount;