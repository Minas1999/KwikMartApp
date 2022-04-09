CREATE PROCEDURE [dbo].[GetFoodByFoodID] @food_id int
as
	select * 
	from Foods
	where food_id = @food_id
GO