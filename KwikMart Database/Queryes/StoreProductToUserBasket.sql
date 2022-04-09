CREATE PROCEDURE [dbo].[StoreProductsToUserBasket]
@food_id int,
@food_name nvarchar (55),
@food_price int,
@food_desc nvarchar (255),
@food_ctg_id int,
@food_cmp_id int,
@food_img varchar(MAX)
as
insert into UserBasket([food_id], [food_name], [food_price], [food_desc], [food_ctg_id], [food_cmp_id], [food_img_url])
values (@food_id, @food_name, @food_price, @food_desc, @food_ctg_id, @food_cmp_id, @food_img)
GO