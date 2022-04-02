CREATE TABLE [dbo].[Orders](
	[ord_id]		 [int] IDENTITY	NOT NULL,
	[ord_date]		 [date] NOT NULL,
	[ord_tmOfTaken]  [date]	NOT NULL,
	[ord_ttl_amount] [int]	NOT NULL,
	[ord_user_id]	 [int]  NOT NULL,

	CONSTRAINT PK_Orders PRIMARY KEY([ord_id])
);
Go

ALTER TABLE [dbo].[Orders] ADD 
	CONSTRAINT [FK_Orders_user] FOREIGN KEY 
	(
		[ord_user_id]
	) REFERENCES [dbo].[Users] (
		[user_id]
	)
GO