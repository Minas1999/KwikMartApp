CREATE TABLE [dbo].[Orders_History](
	[order_id]	 [int]	NOT NULL,
	[order_date] [date] NOT NUll,
	[price]		 [int]	NOT NULL,
	[user_id]	 [int]  NOT NULL,
	[curier_id]  [int],

	CONSTRAINT PK_OrdersHistory PRIMARY KEY([order_id])
);
GO

ALTER TABLE [dbo].[Orders_History] ADD 
	CONSTRAINT [FK_Orders_History_user] FOREIGN KEY 
	(
		[user_id]
	) REFERENCES [dbo].[Users] (
		[user_id]
	)
GO

ALTER TABLE [dbo].[Orders_History] ADD 
	CONSTRAINT [FK_Orders_History_curier] FOREIGN KEY 
	(
		[curier_id]
	) REFERENCES [dbo].[Users] (
		[user_id]
	)
GO
