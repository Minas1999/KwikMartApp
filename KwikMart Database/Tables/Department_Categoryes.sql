CREATE TABLE [dbo].[Department_Categoryes](
	[department_id] [int] NOT NULL,
	[category_id]   [int] NOT NULL,

	CONSTRAINT PK_DepartmentCategoryes PRIMARY KEY([department_id], [category_id])
)
GO

ALTER TABLE [dbo].[Department_Categoryes] ADD 
	CONSTRAINT [FK_Dep_Cat_category_id] FOREIGN KEY 
	(
		[category_id]
	) REFERENCES [dbo].[Categoryes] (
		[category_id]
	)
GO

ALTER TABLE [dbo].[Department_Categoryes] ADD 
	CONSTRAINT [FK_Dep_Cat_department_id] FOREIGN KEY 
	(
		[department_id]
	) REFERENCES [dbo].[Departments] (
		[department_id]
	)
GO
