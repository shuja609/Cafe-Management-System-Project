


--table for shedule
create table Shedule(
SheduleID int identity(1,1) primary key,
shiftType varchar(10),
StartingTime time,
EndingTime time,

);


--table for Cashier
create table Cashier(
CashierID int identity(1,1) primary key,
CashierName varchar(30),
Username varchar(10),
CashierContactno varchar(11),
Password varchar(10),
CashierEmail varchar(50),
--ControllerCashRegistered int not null,
--foreign key (ControllerCashRegistered) references CashRegister(RegisterID)
);

alter table Cashier
add CashierEmail varchar(50)


--table for Cafe Manager
create table CafeManager(
CManagerID int identity(1,1) primary key,
CManagerName varchar(30),
Username varchar(20),
CManagerEmail varchar(20),
CManagerContactno varchar(11),
Password varchar(10),

);


--tabke for Inventory Manager
create table InventoryManager(
IManagerID int identity(1,1) primary key,
IManagerName varchar(20),
Username varchar(20),
IMContactno varchar(11),
Password varchar(10),
 Email VARCHAR(30)
);

create table Customer(
CustomerId int identity(1,1)primary key,
FullName varchar(15),
Email varchar(20),
Password varchar(10),
ContactNo varchar(11),
Username varchar(20) Unique,
);


--table for Orders
create table Orders(
OrderID int identity(1,1) primary key,
Customerid int NOT NULL,
IManagerId int NOT NULL,
 payment_status varchar(20) DEFAULT NULL,
 foreign key (Customerid) references Customer(CustomerId),
foreign key (IManagerId) references InventoryManager(IManagerID)
);
alter table Orders
add foreign key (ItemsListID) references OrderedItems(ID);






--table for rating and reviews
create table RatingandReviews(
RatingID int identity(1,1) PRIMARY KEY,
Customerid int NOT NULL,
Rating int,
Review varchar(30),

foreign key (Customerid) references Customer(CustomerId),

);


--table for Payment
create table Payment(
PaymentID int identity(1,1) PRIMARY KEY,
OrderId int NOT NULL,
Amount int,
AmountPaid int,
CashBacktocustomer int,
 PaymentDate datetime,
foreign key (OrderId) references Orders(OrderID),
);

--table for Cash Register
create table CashRegister(
paymentID int,
foreign key (paymentID) references Payment(PaymentID),
);


--table for Staff
create table Staff(
SheduleId int not null,
CafeManagerId int not null,
InventoryManagerId int not null,
CashierId int not null,
foreign key (SheduleId) references Shedule(SheduleID),
foreign key (CafeManagerId) references CafeManager(CManagerID),
foreign key (InventoryManagerId) references InventoryManager(IManagerID),
foreign key (CashierId) references Cashier(CashierID),
);
drop table Staff
Select * from Staff;

--table for menu
create table Menu(
MenuID int identity(1,1) primary key,
MenuName varchar(20),
Description varchar(50),
CafeManagerId int not null,
foreign key (CafeManagerId) references CafeManager(CManagerID)
);


--table for Categories
create table Categories(
CategoryID int not null,
CategoryName varchar(30),
CategoryDes varchar(50),
menuId int not null,
primary key(CategoryID),
foreign key (menuId) references Menu(MenuID)
);

--table for pricing of item
create table Pricing(
PricingID int identity(1,1) primary key,
BasePrice int,
ControlBymanager int not null,
foreign key (ControlBymanager) references CafeManager(CManagerID)
);

--table for items in cafe
create table Items(
ItemID int identity(1,1) primary key,
ItemName varchar(15),
ItemDes varchar(30),
ItemAvailibility varchar(10),
priceid int not null,
quantity int,

foreign key (priceid) references Pricing(PricingID)
);

-- Drop the foreign key constraint
ALTER TABLE Items
add quantity int;

ALTER TABLE Items
DROP COLUMN ItemID;
ALTER TABLE Items
ADD ItemID int identity(1,1) primary key;
ALTER TABLE Items
ADD FOREIGN KEY (priceid) REFERENCES Pricing(PricingID);

create table CategoriesHasItems(
    ItemID int not null,
    CategoryID int not null,
    primary key(ItemID, CategoryID),
    foreign key (ItemID) references Items(ItemID),
    foreign key (CategoryID) references Categories(CategoryID)
);


--table for MenuHasCategories
create table MenuHasCategories(
menuId int not null,
categoryId int not null,
foreign key (menuId) references Menu(MenuID),
foreign key (categoryId) references Categories(CategoryID)
);

--6 Finding the Customers who have rated items with a rating higher than the average rating
SELECT FullName
FROM Customer
WHERE CustomerId IN (
    SELECT Customerid
    FROM RatingandReviews
    WHERE Rating > (
        SELECT AVG(Rating)
        FROM RatingandReviews
    )
);


--table for cafe
create table Cafe(
CafeID int not null,
CafeName varchar(30),
CafeLocation varchar(30),
CafeManagerId int not null,
InventoryManagerId int not null,
CashierId int not null,
ServeMenuid int not null,
Description varchar(50),
primary key(CafeID),
foreign key (CafeManagerId) references CafeManager(CManagerID),
foreign key (InventoryManagerId) references InventoryManager(IManagerID),
foreign key (ServeMenuid) references Menu(MenuId),
);


--table for Inventory
create table Inventory(
InventoryID int identity(1,1) primary key,
InventoryName varchar(30),
InventoryManagerid int not null,
MinimumStockLevel int,
QuantityInHand int,
ExpirationDate date,

foreign key (InventoryManagerid) references InventoryManager(IManagerID)
);


create table OrderedItems( --
	OrderID int,
	itemID int,
	quantity int,
	foreign key (itemID) references items(itemID),
	foreign key (OrderID) references Orders(OrderID),
	Primary key(OrderID,itemID)
	);

		alter table OrderedItems
	add foreign key (itemID) references items(itemid)