CREATE TABLE Employees
(
    EmpId INT PRIMARY KEY,
    Name VARCHAR(50),
    Department VARCHAR(50),
    Phone VARCHAR(15),
    Email VARCHAR(50)
);
INSERT INTO Employees VALUES
(1, 'Ashi', 'CSE', '9999999999', 'ashi@company.com'),
(2, 'Rahul', 'Sales', '8888888888', 'rahul@company.com'),
(3, 'Neha', 'CSE', '7777777777', 'neha@company.com');
DROP PROCEDURE IF EXISTS sp_GetEmployeesByDepartment;
GO

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @Department VARCHAR(50)
AS
BEGIN
    SELECT EmpId, Name, Department, Phone, Email
    FROM Employees
    WHERE Department = @Department;
END;
GO
USE EFTestMVC;
GO
EXEC sp_GetEmployeesByDepartment 'CSE';
SELECT * FROM Employees;

CREATE TABLE Orders
(
    OrderId INT PRIMARY KEY,
    EmpId INT,
    OrderAmount DECIMAL(10,2),
    OrderDate DATE,
    FOREIGN KEY (EmpId) REFERENCES Employees(EmpId)
);

INSERT INTO Orders VALUES
(101, 1, 25000, '2024-01-10'),
(102, 2, 18000, '2024-02-05');

CREATE PROCEDURE sp_GetDepartmentEmployeeCount
    @Department VARCHAR(50),
    @TotalEmployees INT OUTPUT
AS
BEGIN
    SELECT @TotalEmployees = COUNT(*)
    FROM Employees
    WHERE Department = @Department;
END;

CREATE PROCEDURE sp_GetEmployeeOrders
AS
BEGIN
    SELECT 
        e.Name,
        e.Department,
        o.OrderId,
        o.OrderAmount,
        o.OrderDate
    FROM Employees e
    INNER JOIN Orders o
        ON e.EmpId = o.EmpId;
END;




CREATE PROCEDURE sp_GetDuplicateEmployees
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE Phone IN (
        SELECT Phone FROM Employees GROUP BY Phone HAVING COUNT(*) > 1
    )
    OR Email IN (
        SELECT Email FROM Employees GROUP BY Email HAVING COUNT(*) > 1
    );
END;

INSERT INTO Employees VALUES
(4, 'Rohit', 'Sales', '6666666666', 'rohit@company.com'),
(5, 'Pooja', 'HR', '5555555555', 'pooja@company.com'),
(6, 'Aman', 'IT', '4444444444', 'aman@company.com'),
(7, 'Sneha', 'CSE', '3333333333', 'sneha@company.com');


