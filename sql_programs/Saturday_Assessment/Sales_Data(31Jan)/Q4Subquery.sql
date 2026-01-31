--Subquery Usage (find customers who spent more than the average customer spending.)
select c.Customber_Name, sum(p.Unit_Price * o.Quantity) AS TotalSpent
from Order_Detail o
inner join Customber_Master c 
on c.ID = o.Customber_Id
inner join Product_Master p 
on p.ID = o.Product_Id
group by c.Customber_Name
having sum(p.Unit_Price * o.Quantity) >
(select avg(CustomerTotal) from(select sum(p2.Unit_Price * o2.Quantity) as CustomerTotal
from Order_Detail o2
inner join Product_Master p2 
on p2.ID = o2.Product_Id
group by o2.Customber_Id) x);