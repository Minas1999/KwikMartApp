Create Procedure GetProductsByCategoryes
@id [int]
as
select *
from Departments
join Department_Categoryes on Departments.department_id = Department_Categoryes.department_id
join Categoryes on Department_Categoryes.category_id= Categoryes.category_id
join Foods on Categoryes.category_id= Foods.food_ctg_id
where Departments.department_id = @id
go