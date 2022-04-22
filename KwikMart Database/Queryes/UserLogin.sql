create procedure [dbo].[UserLogin](
@usergmail [varchar] (100),
@userpassword [varchar] (max))
as
select * 
from Users
where user_gmail = @usergmail and user_password = @userpassword
go