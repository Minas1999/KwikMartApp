CREATE TABLE [dbo].[Companyes](
	[company_id]	  [int]			   NOT NULL,
	[company_name]    [nvarchar] (55)  NOT NULL,
	[company_address] [nvarchar] (100) NOT NULL,
	[company_pNumber] [nchar]	 (15)  NOT NULL,
	[company_gmail]   [varchar]	 (100) NOT NULL,
	[company_img_url] [varchar]  (MAX) NOT NULL,

	CONSTRAINT PK_Companyes PRIMARY KEY([company_id])
);
