create table Ingredients(
	food_id [int] NOT NULL,
	Ingredient [nvarchar] (100) NOT NULL
)
go
ALTER TABLE [dbo].Ingredients ADD 
	CONSTRAINT [FK_Ingredients] FOREIGN KEY 
	(
		[food_id]
	) REFERENCES [dbo].[Foods] (
		[food_id]
	)
GO