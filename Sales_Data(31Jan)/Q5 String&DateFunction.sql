--Operations team wants formatted and filtered data
select 
upper(c.Customber_Name) as CustomerName,
datename(MONTH, o.Purchase_Date) as OrderMonth,
o.Order_ID, o.Purchase_Date
from Order_Detail o
inner join Customber_Master c 
on c.ID = o.Customber_Id
where o.Purchase_Date >= '2026-01-01'
and o.Purchase_Date < '2026-02-01';