USE [AdvProg]
GO 

CREATE PROCEDURE [dbo].[GetCustomerData]
@Customer_id int, 
@Customer_name VARCHAR OUTPUT
AS
Select @Customer_name = FirstName + LastName from Customers WHERE Customers.Id = @Customer_id
GO