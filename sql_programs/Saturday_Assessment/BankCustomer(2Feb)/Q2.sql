--Q2Monthly Bonus Update

insert into bonus(BonusID,AccountID,BonusMonth,BonusYear,BonusAmount,CreatedDate)
select row_number() over(order by t.AccountID)+isnull(max(b.BonusID),0),t.AccountID,month(t.TransactionDate),
year(t.TransactionDate),1000,getdate()
FROM Transactions t
LEFT JOIN Bonus b
ON  t.AccountID = b.AccountID
and month(t.TransactionDate) = b.BonusMonth
and year(t.TransactionDate)  = b.BonusYear
where t.TransactionType = 'Deposit'
group by t.AccountID,month(t.TransactionDate),year(t.TransactionDate)
having sum(t.Amount) > 50000
and count(b.BonusID) = 0;
