Create Procedure [dbo].[sp_GetUserById]
@Id int
as
	SET NOCOUNT ON
	select *
	from Users
	where user_id = @ID;
go 
