CREATE PROCEDURE [dbo].[StoreProductsToUserBasket1]
@user_id int,
@food_id int,
@food_name nvarchar (55),
@food_price int,
@food_ctg_id int, 
@food_cmp_id int, 
@food_desc nvarchar (255),
@food_img varchar(MAX),
@product_count int
as
if exists (
	select * from UserBasket
	where food_id = @food_id
)
begin
	UPDATE UserBasket
	SET product_count += @product_count
	WHERE food_id = @food_id;
end
else
begin
	insert into UserBasket([user_id], [food_id], [food_name], [food_price], [food_desc], [food_ctg_id], [food_cmp_id], [food_img_url], [product_count])
	values (@user_id, @food_id, @food_name, @food_price, @food_desc, @food_ctg_id, @food_cmp_id, @food_img, @product_count)
end
GO