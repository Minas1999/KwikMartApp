CREATE TABLE [dbo].[UserBasket](
	[ID]    [int] not null IDENTITY,
	[user_id]         [int]  NOT NULL,
	[food_id]      [int]   NOT NULL,
	[food_name]    [nvarchar] (55)  NOT NULL,
	[food_price]   [int]            NOT NULL,
	[food_desc]    [nvarchar] (255),
	[food_ctg_id]  [int]            NOT NULL,
	[food_cmp_id]  [int]		    NOT NULL,
	[food_img_url] [varchar]  (MAX) NOT NULL,
	[product_count] [int] NOT NULL

	CONSTRAINT PK_UserBasket PRIMARY KEY([ID], [user_id])
)
GO

ALTER TABLE [dbo].[UserBasket] ADD 
	CONSTRAINT [FK_UsersBasket] FOREIGN KEY 
	(
		[user_id]
	) REFERENCES [dbo].[Users] (
		[user_id]
	)
GO