--Third Highest Total Sales 
select * from Order_Detail o 
Inner join Product_Master p 
on p.Id=o.Product_Id 
order by p.Unit_Price*o.Quantity desc
offset 2 rows fetch next 1 row only;


