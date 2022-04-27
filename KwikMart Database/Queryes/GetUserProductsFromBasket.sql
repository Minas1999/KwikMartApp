CREATE PROCEDURE [dbo].[GetUserProductsFromBasket]
@user_id int
as
select * from UserBasket
GO