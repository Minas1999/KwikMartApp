CREATE PROC [dbo].[sp_GetUserByName]
	@NORM_NAME nvarchar(55)
AS
	SET NOCOUNT ON
	select * 
	from Users
	where user_norm_name = @NORM_NAME
