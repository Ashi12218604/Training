--Q3 Current Balance
select c.CustomerName,a.AccountNumber,
a.OpeningBalance+isnull(sum(case when t.TransactionType='Deposit'
then t.Amount end),0)-isnull(sum(case when t.TransactionType='Withdraw' then t.Amount end),0)+isnull(sum(b.BonusAmount),0)
as CurrentBalance
from Customers c
join Accounts a on c.CustomerID = a.CustomerID
left join Transactions t on a.AccountID=t.AccountID
left join Bonus b on a.AccountID=b.AccountID
group by c.CustomerName,a.AccountNumber,a.OpeningBalance;

