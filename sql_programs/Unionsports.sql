select  Name, Sport from [dbo].[UPSPORT]
where Sport='Cricket'
Union 
Select	Name, Sport from [dbo].[PunjabSport]
where Sport='Cricket'



