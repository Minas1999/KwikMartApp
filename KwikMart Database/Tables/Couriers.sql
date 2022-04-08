CREATE TABLE [dbo].[Couriers](
	[courier_id]	[int]	NOT NULL,
	[name]	[nvarchar] (50)	NOT NULL, 
	[address]	[nvarchar] (100) 	NOT NULL,
	[phoneNumber]	[varchar] (30)	NOT NULL,
	[passport_number]	[varchar] (20)	NOT NULL,
	[gender]	[nvarchar] (5) 	NOT NULL,
	[bank_account]	[int] 	NOT NULL,

	CONSTRAINT PK_Courier PRIMARY KEY([courier_id])
);