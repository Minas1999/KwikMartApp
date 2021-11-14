CREATE TABLE [dbo].[Foods](
	[food_id]      [int] IDENTITY   NOT NULL,
	[food_name]    [nvarchar] (55)  NOT NULL,
	[food_price]   [int]            NOT NULL,
	[food_desc]    [nvarchar] (255),
	[food_ctg_id]  [int]            NOT NULL,
	[food_cmp_id]  [int]		    NOT NULL,
	[food_img_url] [varchar]  (MAX) NOT NULL,

	CONSTRAINT PK_Foods PRIMARY KEY([food_id])
)
GO

ALTER TABLE [dbo].[Foods] ADD 
	CONSTRAINT [FK_Foods_company] FOREIGN KEY 
	(
		[food_cmp_id]
	) REFERENCES [dbo].[Companyes] (
		[company_id]
	)
GO

ALTER TABLE [dbo].[Foods] ADD 
	CONSTRAINT [FK_Foods_category] FOREIGN KEY 
	(
		[food_ctg_id]
	) REFERENCES [dbo].[Categoryes] (
		[category_id]
	)
GO