CREATE PROCEDURE [dbo].[GetUserProductsFromBasket]
@user_id int
as
select * from UserBasket
where [user_id] = @user_id
GO