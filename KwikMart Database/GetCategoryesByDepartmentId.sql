Create Procedure GetCategoryesByDepartmentID
@ID [int]
as
	select Categoryes.category_name, Departments.department_id, Departments.department_name, Departments.department_img from 
	Categoryes
	join Department_Categoryes  on Department_Categoryes.category_id = Categoryes.category_id
	join Departments on Department_Categoryes.department_id = Departments.department_id
	where Departments.department_id = @ID
go