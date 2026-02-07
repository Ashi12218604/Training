create or alter proc [dbo].[stpbankcustomer]
(
@StartDate Date,@EndDate Date,@AccountId int
)
as
begin
select sum(case when TransactionType='Deposit'
then amount 
else 0 end) as TotalDeposited,
sum(case when TransactionType='Withdraw'
then amount
else 0 end) as TotalWithdrawn
from Transactions
where AccountID=@AccountId
and TransactionDate between @StartDate and @EndDate;
end;
exec [dbo].[stpbankcustomer];
