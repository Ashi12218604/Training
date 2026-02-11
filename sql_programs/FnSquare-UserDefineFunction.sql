CREATE OR ALTER FUNCTION dbo.Fnsquare(@num INT)
RETURNS INT
AS
BEGIN
    RETURN @num * @num;
END;
GO

SELECT dbo.Fnsquare(6) AS result;

