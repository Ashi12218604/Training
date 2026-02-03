create proc getaccounttranssactionsummary
(
@StartDate Date,
@EndDate Date,
@AccountId int
)
as
begin
select sum(case when TransactionType='Deposit'
then amount else 0 end) as TotalDeposited,
sum(case when TransactionType='Withdraw'
then amount
else 0 end) as TotalWithdrawn
from Transactions
where AccountId=@AccountID
and transactiondate between @StartDate and @EndDate;
end;
