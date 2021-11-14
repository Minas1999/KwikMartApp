CREATE TABLE [dbo].[Users](
	[user_id]         [int] IDENTITY   NOT NULL,
	[user_name]       [nvarchar] (55)  NOT NULL,
	[user_norm_name]  [nvarchar] (55),
	[user_pNumber]    [varchar]  (255) NOT NULL,
	[user_gmail]      [varchar]  (100),
	[user_norm_gmail] [varchar]	 (100),
	[user_address]    [nvarchar] (100) NOT NULL,
	[user_password]   [varchar]  (MAX) NOT NULL,
	[user_status]     [varchar]  (100) NOT NULL,

	CONSTRAINT PK_Users PRIMARY KEY([user_id])
)
GO