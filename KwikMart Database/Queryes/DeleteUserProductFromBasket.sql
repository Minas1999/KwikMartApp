create proc DeleteUserProductFromBasket
@user_id int,
@product_id int
as
DELETE FROM UserBasket WHERE [user_id] = @user_id and food_id = @product_id
go