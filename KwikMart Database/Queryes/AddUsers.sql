CREATE PROCEDURE AddUsers
    @name VARCHAR(25),
    @normName varchar(25),
    @phone_number VARCHAR(25),
    @gmail VARCHAR(25),
    @normGmail varchar(25),
    @address varchar(100),
    @password VARCHAR(300),
    @status varchar (100)
AS
INSERT INTO Users([user_name], [user_norm_name], [user_pNumber], [user_gmail], [user_norm_gmail], [user_address], [user_password], [user_status]) 
VALUES(@name, @normName, @phone_number, @gmail, @normGmail, @address, @password, @status)

