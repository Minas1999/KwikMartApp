Create Procedure [dbo].[CreateOrder]
@ord_date [Date],
@order_time [date],
@summa [int],
@order_userID [int]
as

insert into Orders([ord_date], [ord_tmOfTaken], [ord_ttl_amount], [ord_user_id])
values (@ord_date, @order_time, @summa, @order_userID)

DECLARE @orderID AS INT
SELECT @orderID=Orders.ord_id FROM Orders 
RETURN @orderID
GO