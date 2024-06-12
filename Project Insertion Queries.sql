INSERT INTO Customer (FullName, Email, Password, ContactNo, Username)
VALUES ('Amna Hassan', 'amnahsn@gmail.com', '1234', '03134556364', 'Amna');
SELECT * FROM Customer;

INSERT INTO InventoryManager (IManagerName, Username, IMContactno, Password, Email)
VALUES ('Shuja Uddin', 'Shuja', '12654866543', '1234', 'shujauddin@gmail.com');
SELECT * FROM InventoryManager;

INSERT INTO CafeManager VALUES ('Ali hamza', 'Ali', 'alihamza@gmail.com', '03155148556', '1234');
SELECT * FROM CafeManager;

INSERT INTO Cashier (CashierName, Username, CashierContactno, Password, CashierEmail)
VALUES
    ('Hassan', 'hassan', '1234567890', '1234', 'hassan@example.com');
SELECT * FROM Cashier;

Delete from Cashier where CashierID=2;

INSERT INTO Orders (Customerid, IManagerId)
VALUES (1, 1);
Select * From Orders;

INSERT INTO Payment (OrderId, Amount, AmountPaid, CashBacktocustomer)
VALUES (1, 150.00, 100.00, 0);
SELECT * FROM payment;

-- Insert data into Menu table
insert into Menu (MenuName, Description, CafeManagerId) values 
('Main Menu', 'Main menu items', 1);
SELECT * FROM Menu;


-- Insert data into Categories table
insert into Categories (CategoryID,CategoryName, CategoryDes, menuId) values
(1,'Food', 'Delicious main courses', 1),
(2,'Desserts', 'Sweet treats for dessert', 1),
(3,'Beverages', 'Refreshing drinks', 1);
SELECT * FROM categories;


-- Insert data into Items table
insert into Items (ItemName, ItemDes, ItemAvailibility, priceid,quantity) values
('Burger', 'Classic beef burger', 'Available', 1,10),
('Cheesecake', 'Creamy cheesecake', 'Available', 2,20),
('Iced Tea', 'Refreshing iced tea', 'Available', 3,30);
select * from Items

INSERT INTO Pricing (BasePrice, ControlByManager)
VALUES (20, 1);
INSERT INTO Pricing (BasePrice, ControlByManager)
VALUES (30, 1),(10,1);
SELECT * FROM Pricing;

-- Insert valid data
INSERT INTO CategoriesHasItems (ItemID, CategoryID)
VALUES
    (2, 1),
    (3, 2),
    (4, 3);
	SELECT * FROM CategoriesHasItems;


INSERT INTO MenuHasCategories (menuID,categoryID)
values(1,1),(1,2),(1,3);

select * from Menu;
select * from Categories;
-- Insert invalid data (CategoryID not 1, 2, or 3)
INSERT INTO CategoriesHasItems (ItemID, CategoryID)
VALUES
    (4, 4),
    (5, 1),
    (6, 6);


	INSERT INTO Shedule (shiftType, StartingTime, EndingTime)
VALUES ('Morning', '08:00:00', '16:00:00');

INSERT INTO Staff (SheduleId, CafeManagerId, InventoryManagerId, CashierId)
VALUES (1,1 ,1 ,3);

INSERT INTO RatingandReviews (CustomerID, Rating, Review)
VALUES
   (1, 4, 'Great service!'),
	(2, 5, 'Amazing food!');
	delete from RatingandReviews where CustomerID=2;

	select * from RatingandReviews;

	INSERT INTO Inventory (InventoryName, InventoryManagerid, MinimumStockLevel, QuantityInHand, ExpirationDate)
VALUES ('Item A', 1, 10, 20, '2024-05-01');