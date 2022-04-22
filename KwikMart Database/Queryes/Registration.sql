create procedure registration
@username nvarchar(55),
@userphone varchar(255),
@usergmail varchar(100),
@useraddress varchar(100),
@userpassword varchar (max)
as
insert into Users([user_name], [user_pNumber], [user_gmail], [user_address], [user_password], [user_status])
values(@username, @userphone, @usergmail, @useraddress, @userpassword, 'Admin')
go