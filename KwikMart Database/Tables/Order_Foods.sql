CREATE TABLE [dbo].[Order_Foods](
	[order_id]		 [int]	NOT NULL,
	[food_id]		 [int]	NOT NULL,
	[products_count] [int]  NOT NULL,

	CONSTRAINT PK_OrderFoods PRIMARY KEY([order_id], [food_id])
);
GO

ALTER TABLE [dbo].[Order_Foods] ADD 
	CONSTRAINT [FK_Order_Foods_order_id] FOREIGN KEY 
	(
		[order_id]
	) REFERENCES [dbo].[Orders] (
		[ord_id]
	)
GO

ALTER TABLE [dbo].[Order_Foods] ADD 
	CONSTRAINT [FK_Order_Foods_food_id] FOREIGN KEY 
	(
		[food_id]
	) REFERENCES [dbo].[Foods] (
		[food_id]
	)
GO
