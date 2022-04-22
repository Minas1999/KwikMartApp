Create procedure GetAllOrders
@userID int
as
select * from Orders
where ord_user_id = @userID
go
