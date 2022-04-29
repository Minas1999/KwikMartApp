create procedure GetAllOrderCountByProductID
@product_id int
as
select sum(products_count) as productCount
from Order_Foods
where food_id = @product_id
group by food_id
go
