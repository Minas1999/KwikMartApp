CREATE PROCEDURE [dbo].[GetCourierOrders]
as
	select * from Couriers
	join CourierOrders on CourierOrders.courier_id = Couriers.courier_id
	join Orders on CourierOrders.order_id = Orders.ord_id

