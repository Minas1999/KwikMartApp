--STEP 1
insert into Companyes([company_name],[company_address],[company_pNumber],[company_gmail],[company_img_url])
values ('Yerevan-City','Avan-Arinj','+37491666666', 'yerevancity@gmail.com', 'https://res.cloudinary.com/ysu/image/upload/v1622034943/yerevanCity_aks26l.jpg'),
		('SAS Supermarket','35 Isahakyan St','+37411538888', 'sassupermarket@gmail.com', 'https://res.cloudinary.com/ysu/image/upload/v1622034943/sasSup_kzwzcg.png')

--STEP 2
insert into Categoryes([category_name])
values (N'Սպիտակ Հաց'),
	  (N'Գորշ հաց'),
	  (N'Լավաշ'),
	  (N'Դիետիկ հաց'),
	  (N'Մեղր'),
	  (N'Տորթ'),
	  (N'Վաֆլիներ'),
	  (N'Մակարոնեղեն'),
	  (N'Հնդկաձավար'),
	  (N'Ձեթ')

--STEP 3
insert into Departments([department_name], [department_img])
values (N'Հացաբուլկեղեն', 'URL'),
(N'Քաղցրավենիք', 'URL'),
(N'Նպարեղեն', 'URL'),
(N'Պահածո', 'URL'),
(N'Մսամթերք', 'URL'),
(N'Սառեցված մթերք', 'URL')

--STEP 4
insert into Department_Categoryes([department_id],[category_id])
values 
(1,1),
(1,2),
(1,3),
(1,4),
(2,5),
(2,6),
(2,7),
(3,8),
(3,9),
(3,10)

--STEP 5
INSERT INTO Foods([food_name], [food_price], [food_desc], [food_ctg_id], [food_cmp_id],[food_img_url])
VALUES
 (N'Պիկանտ Համ',       100,N'Հաց',                                          1,1,'https://res.cloudinary.com/ysu/image/upload/v1617040798/hac1_p9tmfn.jpg'),
 (N'տոստի «Պանո»',     200,N'Հաց',                                          2,1,'https://res.cloudinary.com/ysu/image/upload/v1617040798/hac2_rcb65g.jpg'),
 (N'Մատնաքաշ',         200,N'Հաց Մատնաքաշ',                                 1,1,'https://res.cloudinary.com/ysu/image/upload/v1617040814/hac3_zjfpej.jpg'),
 (N'Գառնի',            600, N'Լավաշ «Գառնի Սուրիկի շիճուկով» 500գ',         3,1,'https://res.cloudinary.com/ysu/image/upload/v1617040827/lavash1_msmnn4.jpg'),
 (N'Royal Jelly',     1000,N'Բնական մեղր «Royal Jelly» մեղր ընկույզով 250գ',5,2,'https://res.cloudinary.com/ysu/image/upload/v1617040817/mexr1_pgnieh.jpg'),
 (N'Կրեմ-մեղր',       1000,N'Կրեմ-մեղր «Honey.am» 340գ',                    5,2,'https://res.cloudinary.com/ysu/image/upload/v1617040819/mexr2_mc7dsm.jpg'),
 (N'Mummys Cake',     5000,N'Տորթ «Mummys Cake» 350գ',                      6,2,'https://res.cloudinary.com/ysu/image/upload/v1617040817/tort1_hmvusm.jpg'),
 (N'Makfa',            400,N'Մակարոն «Makfa» 400գ',                         8,2,'https://res.cloudinary.com/ysu/image/upload/v1617040814/makaron1_mlyftn.jpg'),
 (N'Barill',           600,N'Մակարոն «Barilla» 500գ Cellentani',            8,2,'https://res.cloudinary.com/ysu/image/upload/v1617040822/makaron2_xyxog2.png'),
 (N'Divell',           450,N'Մակարոն «Divella» 500գ',                       8,2,'https://res.cloudinary.com/ysu/image/upload/v1617040806/makaron3_lpuduk.jpg')
 
select * from Users

--STEP 6
insert into Users([user_name], [user_norm_name], [user_pNumber], [user_gmail], [user_norm_gmail], [user_address], [user_password], [user_status])
values 
(N'Մինաս', N'ՄԻՆԱՍ', '+37491386888', 'mss.sandadze@gmail.com', 'MSS.SANDADZE@GMAIL.COM', N'Ավան-Առինջ', 'HashPassword', 'Admin'),
(N'Անի', N'ԱՆԻ', '+37491388569', 'ani.hakobyab@gmail.com', 'ANI>HAKOBYAN@GMAIL.COM', N'Ավան-Առինջ', 'HashPassword', 'User')

--STEP 7
insert into Couriers([courier_id], [name], [address], [phoneNumber], [passport_number], [gender], [bank_account])
values
(1, N'Արամ Սարգսյան', N'Շենգավիթ 12Ա', N'+37499548796', N'896577000', N'Տղա', N'0070211124'),
(2, N'Վահագ Նազարյան', N'Շենգավիթ 7Ա', N'+37499548000', N'896577569', N'Տղա', N'0070211177')


select * from Foods
select * from Orders

insert into Orders([ord_date], [ord_tmOfTaken], [ord_ttl_amount], [ord_user_id])
values
('2022-04-08', '2004-01-22', 5500, 1),
('2022-04-08', '2022-04-08', 1200, 1),
('2022-04-08', '2022-04-08', 3540, 1),
('2022-04-08', '2022-04-08', 1100, 2)

insert into CourierOrders([courier_id], [order_id])
values 
(1, 6),
(2, 9)

select * from Couriers
join CourierOrders on CourierOrders.courier_id = Couriers.courier_id
join Orders on CourierOrders.order_id = Orders.ord_id


exec GetFoodByFoodID @food_id = 3


--select * from Foods	

--DECLARE @DatabaseName nvarchar(50)
--SET @DatabaseName = N'KwikMart'

--DECLARE @SQL varchar(max)

--SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
--FROM MASTER..SysProcesses
--WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId

----SELECT @SQL 
--EXEC(@SQL)
