CREATE TABLE [dbo].[User_Roles](
	[user_id]	[int]			NOT NULL,
	[role_name] [varchar] (25)  NOT NULL,

	CONSTRAINT PK_UserRoles PRIMARY KEY([user_id], [role_name])
)
GO

ALTER TABLE [dbo].[User_Roles] ADD 
	CONSTRAINT [FK_User_Roles_user_id] FOREIGN KEY 
	(
		[user_id]
	) REFERENCES [dbo].[Users] (
		[user_id]
	)
GO

ALTER TABLE [dbo].[User_Roles] ADD 
	CONSTRAINT [FK_User_Roles_role_id] FOREIGN KEY 
	(
		[role_name]
	) REFERENCES [dbo].[Roles] (
		[role_name]
	)
GO