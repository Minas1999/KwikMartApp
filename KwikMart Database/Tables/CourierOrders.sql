CREATE TABLE [dbo].[CourierOrders](
	[courier_id]	[int]	NOT NULL,
	[order_id]	[int]	NOT NULL, 

	CONSTRAINT PK_CourierOrders PRIMARY KEY([courier_id], [order_id])
);
go

ALTER TABLE [dbo].[CourierOrders] ADD 
	CONSTRAINT [FK_CourierOrders_Courier] FOREIGN KEY 
	(
		[courier_id]
	) REFERENCES [dbo].[Couriers] (
		[courier_id]
	)
GO

ALTER TABLE [dbo].[CourierOrders] ADD 
	CONSTRAINT [FK_Courier_CourierOrders] FOREIGN KEY 
	(
		[order_id]
	) REFERENCES [dbo].[Orders] (
		[ord_id]
	)
GO