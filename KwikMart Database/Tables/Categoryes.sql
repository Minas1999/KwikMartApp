CREATE TABLE [dbo].[Categoryes](
	[category_id]	[int] IDENTITY   NOT NULL,
	[category_name] [nvarchar] (100) NOT NULL,

	CONSTRAINT PK_Categoryes PRIMARY KEY([category_id])
)
GO