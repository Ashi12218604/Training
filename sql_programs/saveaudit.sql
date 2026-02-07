CREATE TABLE Empl (
    EmpID INT IDENTITY(1,1) PRIMARY KEY,
    EmpName VARCHAR(100),
    EmpSal DECIMAL(10,2)
);
GO
CREATE TABLE Employee_Audit (
    EmpID INT,
    EmpName VARCHAR(100),
    EmpSal DECIMAL(10,2),
    Audit_Action VARCHAR(100),
    Audit_Timestamp DATETIME
);
GO

CREATE TRIGGER trgAfterInsertEmployee
ON Empl
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Employee_Audit
        (EmpID, EmpName, EmpSal, Audit_Action, Audit_Timestamp)
    SELECT
        i.EmpID,
        i.EmpName,
        i.EmpSal,
        'Inserted Record',
        GETDATE()
    FROM inserted i;
END;
GO

INSERT INTO Empl (EmpName, EmpSal)
VALUES ('Ashi', 60000.00),('Sanjana',50000.00);

SELECT * FROM Employee_Audit;