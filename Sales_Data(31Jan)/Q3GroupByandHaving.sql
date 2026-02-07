--Management wants to identify salespersons who generated high revenue

select s.Id as SalesPerson_ID,s.SalesPerson_Name,
sum(p.Unit_Price * o.Quantity) as TotalSales
from SalesPerson_Master s
inner join Order_Detail o 
on o.SalesPerson_Id = s.Id
inner join Product_Master p 
on o.Product_Id = p.Id
group by s.Id, s.SalesPerson_Name
having sum(p.Unit_Price * o.Quantity) < 60000;