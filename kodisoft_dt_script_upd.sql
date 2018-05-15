USE master;
IF DB_ID('Kodisoft') IS NOT NULL
   DROP DATABASE Kodisoft;
CREATE DATABASE Kodisoft  collate Ukrainian_CI_AS;
GO
USE Kodisoft;


IF OBJECT_ID('Tables', 'U') IS NOT NULL
   DROP TABLE Tables;


CREATE TABLE dbo.Tables
(
   TableId int not null IDENTITY(1,1) primary key,
   TableName NVARCHAR(100) not null,
   TableStatus BIT   NULL   DEFAULT 1,
   PositionX int not null,
   PositionY int not null,
   ImagePath NVARCHAR(100) not null
);
GO
SET IDENTITY_INSERT dbo.Tables ON;
INSERT INTO dbo.Tables (TableId, TableName, TableStatus, PositionX, PositionY, ImagePath)
VALUES
   (1, '1', 1, 125, 120, 'Image/Tables/table-1.png'),
   (2, '2', 1, 275,120, 'Image/Tables/table-2.png'),
   (3, '3', 1, 425,120, 'Image/Tables/table-3.png'),
   (4, '4', 1, 575,120, 'Image/Tables/table-4.png'),
   (5, '5', 1, 125,350, 'Image/Tables/table-5.png'),
   (6, '6', 1, 275,350, 'Image/Tables/table-6.png'),
   (7, '7', 1, 425,350, 'Image/Tables/table-7.png'),
   (8, '8', 1, 575,350, 'Image/Tables/table-8.png'),
   (9, '9', 1, 175,235, 'Image/Tables/table-9.png'),
   (10, '10', 1, 475,235, 'Image/Tables/table-10.png')

   
GO
SET IDENTITY_INSERT dbo.Tables OFF;
GO

IF OBJECT_ID('Places', 'U') IS NOT NULL
   DROP TABLE Places;


CREATE TABLE dbo.Places
(
   PlaceId int not null IDENTITY(1,1) primary key,
   PlaceName NVARCHAR(100) NOT NULL,
   TableId int not null FOREIGN KEY REFERENCES dbo.Tables(TableId)

);

GO
SET IDENTITY_INSERT dbo.Places ON;
INSERT INTO dbo.Places (PlaceId, PlaceName, TableId)
VALUES
   (1, 'A', 1),
   (2, 'B', 1),
   (3, 'C', 1),
   (4, 'D', 1),
   (5, 'A', 2),
   (6, 'B', 2),
   (7, 'C', 2),
   (8, 'D', 2),
   (9, 'A', 3),
   (10, 'B', 3),
   (11, 'C', 3),
   (12, 'D', 3),
   (13, 'A', 4),
   (14, 'B', 4),
   (15, 'C', 4),
   (16, 'D', 4),
   (17, 'A', 5),
   (18, 'B', 5),
   (19, 'C', 5),
   (20, 'D', 5),
   (21, 'A', 6),
   (22, 'B', 6),
   (23, 'C', 6),
   (24, 'D', 6),
   (25, 'A', 7),
   (26, 'B', 7),
   (27, 'C', 7),
   (28, 'D', 7),
   (29, 'A', 8),
   (30, 'B', 8),
   (31, 'C', 8),
   (32, 'D', 8),
   (33, 'A', 9),
   (34, 'B', 9),
   (35, 'C', 9),
   (36, 'D', 9),
   (37, 'A', 10),
   (38, 'B', 10),
   (39, 'C', 10),
   (40, 'D', 10)

   
GO
SET IDENTITY_INSERT dbo.Places OFF;
GO

IF OBJECT_ID('StatusList', 'U') IS NOT NULL
   DROP TABLE StatusList;

CREATE TABLE dbo.StatusList
(
   StatusId int not null IDENTITY(1,1) primary key,
   StatusName NVARCHAR(100) NOT NULL
);
GO

SET IDENTITY_INSERT dbo.StatusList ON;
INSERT INTO dbo.StatusList (StatusId, StatusName)
VALUES
   (1, 'New'),
   (2, 'In Process'),
   (3, 'Ready'),
   (4, 'Paid'),
   (5, 'Voided')

GO
SET IDENTITY_INSERT dbo.StatusList OFF;
GO

IF OBJECT_ID('Orders', 'U') IS NOT NULL
   DROP TABLE Orders;


CREATE TABLE dbo.Orders
(
   OrderId int not null IDENTITY(1,1) primary key,
   OrderDate DATETIME NOT NULL,
   OrderStatus int NOT NULL FOREIGN KEY REFERENCES dbo.StatusList(StatusId),
   OrderTips float not null,
   OrderPlaceId int not null FOREIGN KEY REFERENCES dbo.Places(PlaceId)
);
SET DATEFORMAT dmy;
GO

IF OBJECT_ID('MenuItems', 'U') IS NOT NULL
   DROP TABLE MenuItems;

CREATE TABLE dbo.MenuItems
(
   ItemId int not null IDENTITY(1,1) primary key,
   ItemName NVARCHAR(100) NOT NULL,
   Price float NOT NULL
);
GO
SET IDENTITY_INSERT dbo.MenuItems ON;
INSERT INTO dbo.MenuItems (ItemId, ItemName, Price)
VALUES
   (1, 'а╡т аспцеп', 124),
   (2, 'дюак а╡т аспцеп', 169),
   (3, 'юркюмрю аспцеп', 165),
   (4, 'вхк╡ аспцеп', 155),
   (5, 'аспцеп юмрха╡т', 135),
   (6, 'т╡кюдекэт╡ъ аспцеп', 199),
   (7, '╡мд╡юмю аспцеп', 159),
   (8, 'в╡йем аспцеп', 139),
   (9, 'яреий мэч-инпй', 229),
   (10, 'т╡ке-л╡мэинм', 249),
   (11, 'л╡м╡ яреийх г янсянл цпелнкюрю', 195),
   (12, '1/2 йспвю реп╡ъй╡', 159),
   (13, 'цпсдйю ╡мдхвйх цпхкэ', 159),
   (14, 'ябхмъв╡ пеаепжъ б янся╡ реп╡ъй╡', 149),
   (15, 'яэнлцю цпхкэ', 149),
   (16, 'йбюянкъ яоюпфебю г вюямхйнбнч гюопюбйнч', 49),
   (17, 'ъгхй цпхкэ г нбнвюлх', 209),
   (18, 'йспъвю цпсдйю г яхпнл ьебпер', 129),
   (19, 'яреий яюкюр', 139),
   (20, 'реокхи яюкюр г пняра╡тнл', 129),
   (21, 'жегюп г йспйнч', 129),
   (22, 'цпежэйхи яюкюр', 149),
   (23, 'реокхи яюкюр г уюксл╡ рю цпсьеч', 125),
   (24, 'яюкюр г ╡мдхвйнч рю оевемхлх цпхаюлх', 129),
   (25, 'реокхи яюкюр г ледюкэинмюлх г йспъвн╞ оев╡мйх', 230),
   (26, 'юлепхйюмн', 30),
   (27, 'йюосв╡мн', 47),
   (28, 'еяопеян', 30),
   (29, 'кюре', 47)
GO
SET IDENTITY_INSERT dbo.MenuItems OFF;
GO

IF OBJECT_ID('OrderItem', 'U') IS NOT NULL
   DROP TABLE OrderItem;


CREATE TABLE dbo.OrderItem
(
   OrderItemId int not null IDENTITY(1,1) primary key,
   ItemId int not null FOREIGN KEY REFERENCES dbo.MenuItems(ItemId),
   ItemAmount int not null,
   OrderId int not null FOREIGN KEY REFERENCES dbo.Orders(OrderId),

);
GO