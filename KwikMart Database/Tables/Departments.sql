CREATE TABLE [dbo].[Departments](
	[department_id]	  [int] IDENTITY	NOT NULL,
	[department_name] [nvarchar] (100)  NOT NULL,
	[department_img]  [varchar]  (MAX)  NOT NULL,

	CONSTRAINT PK_Departments PRIMARY KEY([department_id])
)
GO
