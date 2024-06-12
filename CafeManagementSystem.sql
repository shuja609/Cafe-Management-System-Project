
create database CafeSystem


use CafeSystem

--table for customer info 



	select * from Items;
	select * from Orders;
	select * from OrderedItems;
	select * from Customer;
	select * from Cashier;
	select * from payment;
	select * from CashRegister;
	select * from InventoryManager;
	select * from categories

	DELETE FROM Orders WHERE OrderID = 10

	delete from Orders;
	delete from items
	delete from OrderedItems;

	delete from Orders where OrderID=7;

	





	drop table Orders

	


SELECT
    constraint_name
FROM
    information_schema.table_constraints
WHERE
    table_name = 'CategoriesHasItems' AND constraint_type = 'foreign key';


	items
	ordereditems

	select * from CategoriesHasItems

	alter table items
	drop constraint PK__Items__727E83EB9E7DD5F4

	select BasePrice from Pricing join Items on Pricing.PricingID = Items.priceid where Items.itemID = 102;

	


select * from items
select * from InventoryManager
select * from Customer;
select * from Orders;
select * from CafeManager
select * from Cashier
select * from Items
select * from Categories;
select * from CategoriesHasItems	
SELECT * FROM Pricing;
select * from menu;



-- Create a trigger named CheckAmountPaid

CREATE TRIGGER CheckAmountPaid
ON Payment
AFTER INSERT
AS
BEGIN
    -- Check if AmountPaid is less than Amount
    IF (SELECT COUNT(*) FROM inserted WHERE AmountPaid < Amount) > 0
    BEGIN
        -- Perform actions when AmountPaid is less than Amount
        print('AmountPaid cannot be less than Amount');
        ROLLBACK; -- Rollback the transaction to prevent the invalid data from being inserted
    END
END;



-- Create a trigger after insert on the Pricing table
CREATE TRIGGER tr_PriceInserted
ON Pricing
AFTER INSERT
AS
BEGIN
    DECLARE @BasePrice int;
    DECLARE @ControlByManager int;

    SELECT @BasePrice = BasePrice, @ControlByManager = ControlByManager
    FROM inserted;

    -- Your logic here to handle the newly inserted base price
    -- For example, you can log the information or perform additional actions

    PRINT 'New base price inserted. BasePrice: ' + CAST(@BasePrice AS varchar(10)) +
          ', ControlByManager: ' + CAST(@ControlByManager AS varchar(10));
END;





-- Create a trigger after insert on the CategoriesHasItems table
CREATE TRIGGER tr_InvalidCategory
ON CategoriesHasItems
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @InvalidCategoryCount int;

    -- Check if there are any invalid CategoryIDs (not 1, 2, or 3)
    SELECT @InvalidCategoryCount = COUNT(*)
    FROM inserted
    WHERE CategoryID NOT IN (1, 2, 3);

    -- If there are invalid CategoryIDs, perform the desired action
    IF @InvalidCategoryCount > 0
    BEGIN
        -- Your logic here, for example, you can log an error message or rollback the transaction
        -- For demonstration purposes, we are rolling back the transaction and printing a message
        ROLLBACK;
        PRINT 'Invalid CategoryID detected. Rollback initiated.';
    END
END;






select *from items
-- Alter the table to change ItemID to identity column








select * from Items

delete from Items

UPDATE Items
SET Quantity = 10  -- Replace 10 with the desired quantity
WHERE ItemID IN (1, 2, 3);

select * from CafeManager
select * from items

select * from Items

--////////////////////////Procedure/////////////////

--Procedure to check inventory Level
CREATE PROCEDURE CheckInventoryLevels
AS
BEGIN
    DECLARE @ItemId INT;
    DECLARE @CurrentStock INT;
    DECLARE @MinStockLevel INT;
    DECLARE @ManagerEmail VARCHAR(100);
    
    DECLARE cur CURSOR FOR
    SELECT InventoryID, QuantityInHand, MinimumStockLevel, Email
    FROM Inventory INNER JOIN InventoryManager ON Inventory.InventoryManagerid = InventoryManager.IManagerID;
    
    OPEN cur;
    FETCH NEXT FROM cur INTO @ItemId, @CurrentStock, @MinStockLevel, @ManagerEmail;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF @CurrentStock < @MinStockLevel
        BEGIN
            -- Send alert to Inventory Manager
            EXEC SendInventoryAlert @ItemId, @ManagerEmail;
        END;
        
        FETCH NEXT FROM cur INTO @ItemId, @CurrentStock, @MinStockLevel, @ManagerEmail;
    END;
    
    CLOSE cur;
    DEALLOCATE cur;
END;



--Procedure to Send Email for inventory alert
CREATE PROCEDURE SendInventoryAlert
    @ItemId INT,
    @ManagerEmail VARCHAR(100)
AS
BEGIN
    DECLARE @Subject NVARCHAR(255);
    DECLARE @Body NVARCHAR(MAX);
    
    SELECT @Subject = 'Alert: Low Inventory',
           @Body = 'Item with ID ' + CAST(@ItemId AS VARCHAR(10)) + ' has fallen below the minimum stock level.';
    
    -- Send email notification
    EXEC msdb.dbo.sp_send_dbmail
        @profile_name = 'Cafe System',
        @recipients = @ManagerEmail,
        @subject = @Subject,
        @body = @Body;
END;



--/////////////////////////////////////////////////////////////////


---VIEWS----

--View 1: Available Items and Their Prices
CREATE VIEW AvailableItemsWithPrices AS
SELECT i.ItemID, i.ItemName, i.ItemAvailibility, p.BasePrice
FROM Items i
INNER JOIN Pricing p ON i.PriceID = p.PricingID;

SELECT * FROM AvailableItemsWithPrices;


--View 2: Orders with Customer Information
CREATE VIEW OrdersWithCustomers AS
SELECT o.OrderID, o.Payment_Status, c.FullName AS CustomerName, c.ContactNo AS CustomerContact
FROM Orders o
INNER JOIN Customer c ON o.CustomerID = c.CustomerID;

SELECT * FROM OrdersWithCustomers;

--View 3: Cashiers and Their Contact Information
CREATE VIEW CashiersContactInfo AS
SELECT CashierID, CashierName, CashierContactNo
FROM Cashier;

SELECT * FROM CashiersContactInfo;

--View 4: Menu Categories with Items
CREATE VIEW MenuCategoriesWithItems AS
SELECT c.CategoryID, c.CategoryName, i.ItemName
FROM Categories c
INNER JOIN CategoriesHasItems ci ON c.CategoryID = ci.CategoryID
INNER JOIN Items i ON ci.ItemID = i.ItemID;

SELECT * FROM MenuCategoriesWithItems;

--view 5: Deatils of each order
CREATE VIEW OrderDetails AS
SELECT o.OrderID, c.FullName AS CustomerName, i.ItemName, oi.Quantity
FROM Orders o
INNER JOIN Customer c ON o.CustomerID = c.CustomerID
INNER JOIN OrderedItems oi ON o.OrderID = oi.OrderID
INNER JOIN Items i ON oi.ItemID = i.ItemID;

SELECT * FROM OrderDetails;

--View 6: Deatils of complete staff
CREATE VIEW AllStaffDetails AS
SELECT 'Cafe Manager' AS Role, CManagerID AS StaffID, CManagerName AS StaffName, CManagerEmail AS StaffEmail, CManagerContactno AS StaffContact
FROM CafeManager
UNION ALL
SELECT 'Inventory Manager' AS Role, IManagerID AS StaffID, IManagerName AS StaffName, Email AS StaffEmail, IMContactno AS StaffContact
FROM InventoryManager
UNION ALL
SELECT 'Cashier' AS Role, CashierID AS StaffID, CashierName AS StaffName, CashierEmail AS StaffEmail, CashierContactno AS StaffContact
FROM Cashier;

SELECT * FROM AllStaffDetails;



--///////////////////////Triggers////////////////////////////////
--checking order status is valid or not
CREATE TRIGGER EnforcePaymentStatusTrigger
ON Orders
AFTER INSERT
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE payment_status NOT IN ('Pending', 'Processing', 'Completed'))
    BEGIN
        RAISERROR('Invalid payment status. Payment status must be "Pending", "Processing", or "Completed".', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;

--prevent deletion of inventory manager
CREATE TRIGGER PreventInventoryManagerDeleteTrigger
ON InventoryManager
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR ('Deletion from InventoryManager table is not allowed.', 16, 1);
    ROLLBACK TRANSACTION;
END;
delete from InventoryManager where IManagerID=1;
select * from InventoryManager




--///////////////Aggregate and group by (withhaving) /////////////////////////////////'

-- 1: Total Quantity of Items Sold per Order
SELECT OrderID, SUM(quantity) AS TotalQuantity
FROM OrderedItems
GROUP BY OrderID;

--2 Count of Orders Placed by Each Customer
SELECT Customerid, COUNT(OrderID) AS TotalOrders
FROM Orders
GROUP BY Customerid
HAVING COUNT(OrderID) >= 0;

--3 Total Revenue Generated by Each Menu Category
SELECT c.CategoryName, SUM(i.quantity * p.BasePrice) AS TotalRevenue
FROM Categories c
JOIN CategoriesHasItems chi ON c.CategoryID = chi.CategoryID
JOIN Items i ON chi.ItemID = i.ItemID
JOIN Pricing p ON i.priceid = p.PricingID
JOIN OrderedItems oi ON i.ItemID = oi.itemID
GROUP BY c.CategoryName
HAVING SUM(i.quantity * p.BasePrice) > 0;

select * from Payment;

--4 Average rating by each customer
SELECT CustomerId, AVG(Rating) AS AverageRating
FROM RatingandReviews
GROUP BY CustomerId
HAVING AVG(Rating) > 3.5;

--5 Total Revenue per Customer with Total Exceeding x
SELECT o.Customerid, SUM(p.AmountPaid) AS TotalRevenue
FROM Orders o
JOIN Payment p ON o.OrderID = p.OrderId
GROUP BY o.Customerid
HAVING SUM(p.AmountPaid) > 0; --x


--//////////////////////Nested Subqueries //////////////////////////////

--1 Customers Who Have Not Given Reviews
SELECT FullName
FROM Customer
WHERE CustomerID NOT IN (
    SELECT DISTINCT CustomerID
    FROM RatingandReviews
);

--2 Finding Customers who have placed orders managed by a specific Inventory Manager
SELECT FullName
FROM Customer
WHERE CustomerId IN (
    SELECT Customerid
    FROM Orders
    WHERE IManagerId = (
        SELECT IManagerID
        FROM InventoryManager
        WHERE IManagerName = 'Shuja Uddin'
    )
);


--3 Finding Inventory Managers who are managing inventories with a quantity below the minimum stock level
SELECT IManagerName
FROM InventoryManager
WHERE IManagerID IN (
    SELECT InventoryManagerid
    FROM Inventory
    WHERE QuantityInHand < MinimumStockLevel
);

--4 Finding the Inventory Manager who manages the inventory with the earliest expiration date
SELECT IManagerName
FROM InventoryManager
WHERE IManagerID = (
    SELECT InventoryManagerid
    FROM Inventory
    WHERE ExpirationDate = (
        SELECT MIN(ExpirationDate)
        FROM Inventory
    )
);

--5 Finding the Menu items that belong to a specific Category managed by a particular Cafe Manager
SELECT MenuName
FROM Menu
WHERE CafeManagerId = (
    SELECT CManagerID
    FROM CafeManager
    WHERE CManagerName = 'Ali Hamza'
)
AND MenuID IN (
    SELECT MenuID
    FROM MenuHasCategories
    WHERE CategoryID IN (
        SELECT CategoryID
        FROM Categories
        WHERE CategoryName = 'Beverages'
    )
);

select * from MenuHasCategories
select * from Menu

--///////////////////////////Multitable Queries//////////////////////

--4 Table Joins

--1 Joining Menu, Categories, Items, and Pricing:
SELECT m.MenuName, cat.CategoryName, i.ItemName, p.BasePrice
FROM Menu m
INNER JOIN Categories cat ON m.MenuID = cat.menuId
INNER JOIN CategoriesHasItems chi ON cat.CategoryID = chi.CategoryID
INNER JOIN Items i ON chi.ItemID = i.ItemID
INNER JOIN Pricing p ON i.priceid = p.PricingID;


--2 Joining Orders, Customer, Payment, and Items:
SELECT o.OrderID, c.FullName AS CustomerName, p.AmountPaid, i.ItemName
FROM Orders o
INNER JOIN Customer c ON o.Customerid = c.Customerid
LEFT JOIN Payment p ON o.OrderID = p.OrderID
INNER JOIN Items i ON o.Customerid = i.ItemID;


SELECT o.OrderID, c.FullName AS CustomerName, p.AmountPaid, i.ItemName
FROM Orders o
INNER JOIN Customer c ON o.Customerid = c.Customerid
LEFT JOIN Payment p ON o.OrderID = p.OrderID
INNER JOIN Items i ON o.Customerid = i.ItemID;

--3 Selecting order ID, customer's full name, and calculating total payment amount for orders with pending status
SELECT O.OrderID, C.FullName AS CustomerName, SUM(P.BasePrice * OI.quantity) AS PaymentAmount 
FROM Orders O JOIN Customer C ON O.Customerid = C.CustomerId 
LEFT JOIN OrderedItems OI ON O.OrderID = OI.OrderID 
LEFT JOIN Items I ON OI.itemID = I.ItemID 
LEFT JOIN Pricing P ON I.priceid = P.PricingID
WHERE O.payment_status = 'Pending' GROUP BY O.OrderID, C.FullName;

--3 Table Joins

--1 Total Amount Paid by Each Customer:
SELECT o.Customerid, c.FullName, SUM(p.AmountPaid) AS TotalAmountPaid
FROM Orders o
INNER JOIN Payment p ON o.OrderID = p.OrderID
INNER JOIN Customer c ON o.Customerid = c.Customerid
GROUP BY o.Customerid, c.FullName;

--2 List of Categories and Their Menu Items:
SELECT cat.CategoryName, i.ItemName
FROM Categories cat
INNER JOIN CategoriesHasItems chi ON cat.CategoryID = chi.CategoryID
INNER JOIN Items i ON chi.ItemID = i.ItemID;

--3 Orders Placed by a Specific Customer:
SELECT o.OrderID, o.payment_status, oi.ItemID, i.ItemName, oi.Quantity
FROM Orders o
INNER JOIN OrderedItems oi ON o.OrderID = oi.OrderID
INNER JOIN Items i ON oi.ItemID = i.ItemID
WHERE o.Customerid = 2; -- write desired CustomerID


--4 Details of Items with Their Categories:
SELECT i.ItemName, c.CategoryName
FROM Items i
INNER JOIN CategoriesHasItems chi ON i.ItemID = chi.ItemID
INNER JOIN Categories c ON chi.CategoryID = c.CategoryID;


--5 Cashiers with Their Shifts:
SELECT c.CashierName, sh.shiftType, sh.StartingTime, sh.EndingTime
FROM Cashier c
INNER JOIN Staff s ON c.CashierID = s.CashierId
INNER JOIN Shedule sh ON s.SheduleId = sh.SheduleID;

--6Inventory Manager with Their Shifts:
SELECT c.IManagerName, sh.shiftType, sh.StartingTime, sh.EndingTime
FROM InventoryManager c
INNER JOIN Staff s ON c.IManagerID = s.InventoryManagerId
INNER JOIN Shedule sh ON s.SheduleId = sh.SheduleID;

--7 Cafe Manager with Their Shifts:
SELECT c.CManagerName, sh.shiftType, sh.StartingTime, sh.EndingTime
FROM CafeManager c
INNER JOIN Staff s ON c.CManagerID = s.CafeManagerId
INNER JOIN Shedule sh ON s.SheduleId = sh.SheduleID;

--8 SQL query to retrieve items for a specific category with quantity
SELECT Items.ItemID, Items.ItemName, Items.ItemDes, Items.ItemAvailibility, Items.priceid, Items.quantity
FROM Items
INNER JOIN CategoriesHasItems ON Items.ItemID = CategoriesHasItems.ItemID
INNER JOIN Categories ON CategoriesHasItems.CategoryID = Categories.CategoryID
WHERE Categories.CategoryName = 'Desserts'; --Beverages  / Food / Desserts



--2 Table Joins


--1 List of Orders with Customer Information:
SELECT o.OrderID, c.FullName AS CustomerName, o.Payment_Status
FROM Orders o
INNER JOIN Customer c ON o.Customerid = c.Customerid;

--2  Details of Items Ordered in a Specific Order:
SELECT oi.OrderID, i.ItemName, oi.Quantity
FROM OrderedItems oi
INNER JOIN Items i ON oi.ItemID = i.ItemID
WHERE oi.OrderID = 4; -- Replace 1 with the desired OrderID

--3 Menu Items with Their Prices:
SELECT i.ItemName, p.BasePrice
FROM Items i
INNER JOIN Pricing p ON i.priceid = p.PricingID;

--4Total Amount Paid for Each Order:
SELECT o.OrderID, SUM(p.AmountPaid) AS TotalAmountPaid
FROM Orders o
INNER JOIN Payment p ON o.OrderID = p.OrderID
GROUP BY o.OrderID;











