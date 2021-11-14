CREATE TABLE [dbo].[Manufacturer_Foods](
	[manufacturer_name] [nvarchar] (100) NOT NULL,
	[food_id]			[int]			NOT NULL,
	
	CONSTRAINT PK_ManufacturerFoods PRIMARY KEY([manufacturer_name], [food_id])
)
Go

ALTER TABLE [dbo].[Manufacturer_Foods] ADD 
	CONSTRAINT [FK_Manufacturer_Foods_food_id] FOREIGN KEY 
	(
		[food_id]
	) REFERENCES [dbo].[Foods] (
		[food_id]
	)
GO

ALTER TABLE [dbo].[Manufacturer_Foods] ADD 
	CONSTRAINT [FK_Manufacturer_Foods_manufacturer_name] FOREIGN KEY 
	(
		[manufacturer_name]
	) REFERENCES [dbo].[Manufacturer] (
		[name]
	)
GO