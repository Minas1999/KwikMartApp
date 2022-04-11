create procedure CreateUserOrderFoodsTable
@order_id [int],
@food_id [int],
@products_count [int]
as
insert into Order_Foods([order_id], [food_id], [products_count])
values(@order_id, @food_id, @products_count)