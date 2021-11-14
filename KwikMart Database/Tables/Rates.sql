CREATE TABLE [dbo].[Rates](
	[user_id]	[int]	NOT NULL,
	[food_id]	[int]	NOT NULL, 
	[rate]		[nchar] (15) CHECK (rate IN('1', '2', '3','4','5')),

	CONSTRAINT PK_Rates PRIMARY KEY([user_id])
);
GO

ALTER TABLE [dbo].[Rates] ADD 
	CONSTRAINT [FK_Rates_user] FOREIGN KEY 
	(
		[user_id]
	) REFERENCES [dbo].[Users] (
		[user_id]
	)
GO

ALTER TABLE [dbo].[Rates] ADD 
	CONSTRAINT [FK_Rates_food] FOREIGN KEY 
	(
		[food_id]
	) REFERENCES [dbo].[Foods] (
		[food_id]
	)
GO