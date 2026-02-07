create function GetHighestM2()
returns int
as 
begin
    declare @MaxM2 INT;
    SELECT @MaxM2 = MAX(M2)
    from dbo.College;
        return @MaxM2;
end;

select M2 from GetHighestM2()