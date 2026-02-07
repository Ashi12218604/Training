-- ID+ FIRST 3 LETTER OF NAME
select concat (ID,left(Name,3)) as NewId,
ID, Name, Sport
from [dbo].[UPSPORT]  
-----------------------------------------------------------
--Extract the substring till r
select
    left(Name, charindex('r', Name)) as TillR
from dbo.UPSPORT

-----------------------------------------------------------
-- Extract the substring from r till end
select
 substring(Name, charindex('r', Name),len(Name)+1) as RtoEnd
from dbo.UPSPORT
-----------------------------------------------------------
