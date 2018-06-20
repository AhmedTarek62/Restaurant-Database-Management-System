CREATE TABLE Branch
(ID				NUMERIC(5,0)	NOT NULL,
 MngrID			NUMERIC(5,0)	NOT NULL,
 BAddress		VARCHAR(255),
 OpensAt		TIME,
 ClosesAt		TIME,
 Capacity		INT,
 PhoneNum		VARCHAR(15)  NOT NULL,

 PRIMARY KEY(ID),
 );

CREATE TABLE BranchHas
(
 BranchID       NUMERIC(5,0)    NOT NULL,
 SupplyID		NUMERIC(5,0)    NOT NULL,
 Qty			NUMERIC(6,2)    NOT NULL,
 UnitID			numeric(5,0)	NOT NULL,

 PRIMARY KEY(BranchID,SupplyID),
  );

CREATE TABLE BranchGets
(
 BranchID			NUMERIC(5,0)            NOT NULL,
 WarehouseID		numeric(5,0)            NOT NULL,
 SupplyID			numeric(5,0)            NOT NULL,
 ArrivalDate		DATE,
 QTY				NUMERIC(6,2)            NOT NULL,
 UnitID				numeric(5,0)			NOT NULL,
 UnitPrice			smallmoney				NOT NULL,
 PRIMARY KEY(BranchID,WarehouseID,SupplyID,ArrivalDate),
  );

CREATE TABLE CustOrder(

OrderID			NUMERIC(5,0)	NOT NULL,
OTimeStamp		smallDATETIME,
OStatusID		NUMERIC(5,0),
CashierID		NUMERIC(5,0)	NOT NULL,                               
CustomerID		NUMERIC(5,0)	NOT NULL,                                   
NetPrice		smallmoney		NOT NULL CHECK(NetPrice>0),
ServicePrice	smallmoney		NOT NULL CHECK(ServicePrice>0),
TaxPrice		smallmoney		NOT NULL CHECK(TaxPrice>0),
TotalPrice		smallmoney		NOT NULL CHECK(TotalPrice>0),
BranchID		NUMERIC (5,0)	NOT NULL,

PRIMARY KEY (OrderID),
   
);

CREATE TABLE Customer
(
   ID			NUMERIC(5,0)	NOT NULL,
   FName		VARCHAR(50)		NOT NULL,
   MNames		VARCHAR(80),
   LName		VARCHAR(50),
   PhoneNum		VARCHAR(15)		NOT NULL, 
   Email		VARCHAR(80),
   CAddress		VARCHAR(255)	NOT NULL,
   
   PRIMARY KEY (ID),
);

CREATE TABLE Employee(
   ID		NUMERIC(5,0)		NOT NULL,
   FName	VARCHAR(50)			NOT NULL,
   MNames	VARCHAR(80),
   LName	VARCHAR(50)			NOT NULL,
   Gender	BIT,
   
   NatID		NUMERIC(14,0)	NOT NULL, 
   PhoneNum		VARCHAR(15)		NOT NULL, 
   Email		VARCHAR(80),
   BasicSalary	smallmoney		NOT NULL   CHECK(BasicSalary>0),
   JobID		numeric(5,0),
   SupervisorID NUMERIC(5,0),

PRIMARY KEY (ID),
	  
);CREATE TABLE Item
( 

 ID					NUMERIC(5,0)	NOT NULL,
 Name				Varchar(40)		Not null, 
 Price				smallmoney		NOT NULL     CHECK(Price>0),
 ItemCategoryID		NUMERIC(5,0),
 IAvailability		BIT				NOT NULL,
 
 PRIMARY KEY(ID)
 );

CREATE TABLE ItemCategory
(
ID		NUMERIC(5,0)	NOT NULL,
Descr	VARCHAR(20)		NOT NULL,

PRIMARY KEY(ID)
);

CREATE TABLE ItemContains
(
ItemID		NUMERIC(5,0)	NOT NULL,
SupplyID	NUMERIC(5,0)	NOT NULL,
Qty			NUMERIC(6,2)	NOT NULL      CHECK(Qty>0),
UnitID		NUMERIC(5,0)	NOT NULL,

PRIMARY KEY(ItemID,SupplyID),
  );

  CREATE TABLE Job
(
ID		NUMERIC(5,0)	NOT NULL,
Descr	VARCHAR(40)		NOT NULL,

PRIMARY KEY(ID)
);

CREATE TABLE LoginInfo
(
Username	nvarchar(15)	NOT NULL,
uPassword	nvarchar(20)	NOT NULL,
Privilege	smallint		NOT NULL,

PRIMARY KEY(Username),
);

CREATE TABLE MeasurementUnit
(ID				numeric(5,0) NOT NULL,
 Descr			varchar(20) NOT NULL,

 PRIMARY KEY(ID),
);

CREATE TABLE OrderItems 
(OrderID		NUMERIC(5,0)	NOT NULL,
 ItemID			numeric(5,0)	NOT NULL,
 Number			smallint		NOT NULL,
 
 PRIMARY KEY(OrderID,ItemID),
  );

  CREATE TABLE OrderStatus
(ID			numeric(5,0) NOT NULL,
 Descr		varchar(20) NOT NULL,

 PRIMARY KEY(ID),
);

 CREATE TABLE Supplier
 (
   ID			NUMERIC(5,0)	NOT NULL,
   Name			VARCHAR(80)		NOT NULL,
   PhoneNum		VARCHAR(15)		NOT NULL,
   Email		VARCHAR(80),
   SAddress		VARCHAR(225),

   PRIMARY KEY (ID),
);

CREATE TABLE Supply
(
   ID			NUMERIC(5,0)	NOT NULL,
   Name			VARCHAR(50)		NOT NULL,
   UnitPrice	smallmoney		NOT NULL	CHECK(UnitPrice>0),
   
   UnitID		numeric(5,0)	NOT NULL,


PRIMARY KEY (ID),

);

CREATE TABLE Warehouse
(
 ID				NUMERIC(5,0)	NOT NULL,
 MngrID			NUMERIC(5,0)	NOT NULL,
 WAddress		VARCHAR(255)	NOT NULL,
 PhoneNum		VARCHAR(15)		NOT NULL,

 PRIMARY KEY(ID),
 );

 CREATE TABLE WarehouseGets
(
 TransactionID		NUMERIC(5,0)	NOT NULL,
 WarehouseID		NUMERIC(5,0)	NOT NULL,
 SupplyID			NUMERIC(5,0)	NOT NULL,
 SupplierID			NUMERIC(5,0)	NOT NULL,
 QtyReceived		NUMERIC(6,2)	NOT NULL,
 UnitID				NUMERIC(5,0),
 ArrivalDate		date			NOT NULL,
 ExpiryDate			date			Not null, 
 UnitPrice			smallmoney		not null	CHECK (UnitPrice>0),

 PRIMARY KEY(TransactionID),
  );

  CREATE TABLE WarehouseHas
(
TransactionID		NUMERIC(5,0)	NOT NULL,
 WarehouseID		NUMERIC(5,0)	NOT NULL,
 SupplyID			NUMERIC(5,0)	NOT NULL,
 SupplierID			NUMERIC(5,0)	NOT NULL,
 QtyLeft			NUMERIC(6,2)	NOT NULL,
 UnitID				NUMERIC(5,0),
 ArrivalDate		date			NOT NULL,
 ExpiryDate			date			Not null, 
 UnitPrice			smallmoney		not null	CHECK (UnitPrice>0),

 PRIMARY KEY(TransactionID),
);

CREATE TABLE WorksAtBr 
(EmployeeID		NUMERIC(5,0)	NOT NULL,
 BranchID		numeric(5,0)	NOT NULL,
 
 PRIMARY KEY(EmployeeID),
  );

  CREATE TABLE WorksAtWH
(EmployeeID		NUMERIC(5,0)	NOT NULL,
 WarehouseID	numeric(5,0)	NOT NULL,
 
 PRIMARY KEY(EmployeeID),
  );


ALTER TABLE Branch
	ADD CONSTRAINT FK_Branch_Employee
    FOREIGN KEY (MngrID)
    REFERENCES Employee(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE BranchHas
	ADD CONSTRAINT FK_BranchHas_Branch
    FOREIGN KEY (BranchID)
    REFERENCES Branch(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE BranchHas
	ADD CONSTRAINT FK_BranchHas_Supply
    FOREIGN KEY (SupplyID)
    REFERENCES Supply(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE BranchHas
	ADD CONSTRAINT FK_BranchHas_MeasurementUnit
    FOREIGN KEY (UnitID)
    REFERENCES MeasurementUnit(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE BranchGets
	ADD CONSTRAINT FK_BranchGets_Branch
    FOREIGN KEY (BranchID)
    REFERENCES Branch(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE BranchGets
	ADD CONSTRAINT FK_BranchGets_Warehouse
    FOREIGN KEY (WarehouseID)
    REFERENCES Warehouse(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE BranchGets
	ADD CONSTRAINT FK_BranchGets_Supply
    FOREIGN KEY (SupplyID)
    REFERENCES Supply(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE BranchGets
	ADD CONSTRAINT FK_BranchGets_MeasurementUnit
    FOREIGN KEY (UnitID)
    REFERENCES MeasurementUnit(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE CustOrder
	ADD CONSTRAINT FK_CustOrder_OStatus
    FOREIGN KEY (OStatusID)
    REFERENCES OrderStatus(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE CustOrder
	ADD CONSTRAINT FK_CustOrder_Employee
    FOREIGN KEY (CashierID)
    REFERENCES Employee(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE CustOrder
	ADD CONSTRAINT FK_CustOrder_Customer
    FOREIGN KEY (CustomerID)
    REFERENCES Customer(ID)
    ON DELETE NO ACTION
	ON UPDATE NO ACTION;

ALTER TABLE CustOrder
	ADD CONSTRAINT FK_CustOrder_Branch
    FOREIGN KEY (BranchID)
    REFERENCES Branch(ID)
    ON DELETE NO ACTION
	ON UPDATE NO ACTION;

ALTER TABLE Employee
	ADD CONSTRAINT FK_Employee_Job
    FOREIGN KEY (JobID)
    REFERENCES Job(ID)
    ON DELETE SET NULL
	ON UPDATE CASCADE;

ALTER TABLE Employee
	ADD CONSTRAINT FK_Employee_Employee
    FOREIGN KEY (SupervisorID)
    REFERENCES Employee(ID)
    ON DELETE NO ACTION
	ON UPDATE NO ACTION;

ALTER TABLE Item
	ADD CONSTRAINT FK_Item_ItemCategory
    FOREIGN KEY (ItemCategoryID)
    REFERENCES ItemCategory(ID)
    ON DELETE SET NULL
	ON UPDATE CASCADE;

ALTER TABLE ItemContains
	ADD CONSTRAINT FK_ItemContains_Item
    FOREIGN KEY (ItemID)
    REFERENCES Item(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE ItemContains
	ADD CONSTRAINT FK_ItemContains_Supply
    FOREIGN KEY (SupplyID)
    REFERENCES Supply(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE ItemContains
	ADD CONSTRAINT FK_ItemContains_MeasurementUnit
    FOREIGN KEY (UnitID)
    REFERENCES MeasurementUnit(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE OrderItems
	ADD CONSTRAINT FK_OrderItems_CustOrder
    FOREIGN KEY (OrderID)
    REFERENCES CustOrder(OrderID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE OrderItems
	ADD CONSTRAINT FK_OrderItems_Item
    FOREIGN KEY (ItemID)
    REFERENCES Item(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE Supply
	ADD CONSTRAINT FK_Supply_MeasurementUnit
    FOREIGN KEY (UnitID)
    REFERENCES MeasurementUnit(ID)
    ON DELETE NO ACTION
	ON UPDATE NO ACTION;

ALTER TABLE Warehouse
	ADD CONSTRAINT FK_Warehouse_Employee
    FOREIGN KEY (MgrID)
    REFERENCES Employee(ID)
    ON DELETE NO ACTION
	ON UPDATE NO ACTION;
	
ALTER TABLE WarehouseGets
	ADD CONSTRAINT FK_WarehouseGets_Warehouse
    FOREIGN KEY (WarehouseID)
    REFERENCES Warehouse(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE WarehouseGets
	ADD CONSTRAINT FK_WarehouseGets_Supply
    FOREIGN KEY (SupplyID)
    REFERENCES Supply(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE WarehouseGets
	ADD CONSTRAINT FK_WarehouseGets_Supplier
    FOREIGN KEY (SupplierID)
    REFERENCES Supplier(ID)
	ON UPDATE CASCADE;

ALTER TABLE WarehouseGets
	ADD CONSTRAINT FK_WarehouseGets_MeasurementUnit
    FOREIGN KEY (UnitID)
    REFERENCES MeasurementUnit(ID)
    ON DELETE SET NULL
	ON UPDATE CASCADE;

ALTER TABLE WarehouseHas
	ADD CONSTRAINT FK_WarehouseHas_Warehouse
    FOREIGN KEY (WarehouseID)
    REFERENCES Warehouse(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE WarehouseHas
	ADD CONSTRAINT FK_WarehouseHas_Supply
    FOREIGN KEY (SupplyID)
    REFERENCES Supply(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE WarehouseHas
	ADD CONSTRAINT FK_WarehouseHas_Supplier
    FOREIGN KEY (SupplierID)
    REFERENCES Supplier(ID)
	ON UPDATE CASCADE;

ALTER TABLE WarehouseHas
	ADD CONSTRAINT FK_WarehouseHas_MeasurementUnit
    FOREIGN KEY (UnitID)
    REFERENCES MeasurementUnit(ID)
    ON DELETE SET NULL
	ON UPDATE CASCADE;

ALTER TABLE WorksAtBr
	ADD CONSTRAINT FK_WorksAtBr_Employee
    FOREIGN KEY (EmployeeID)
    REFERENCES Employee(ID)
    ON DELETE NO ACTION
	ON UPDATE NO ACTION;

ALTER TABLE WorksAtBr
	ADD CONSTRAINT FK_WorksAtBr_Branch
    FOREIGN KEY (BranchID)
    REFERENCES Branch(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE WorksAtWH
	ADD CONSTRAINT FK_WorksAtWH_Employee
    FOREIGN KEY (EmployeeID)
    REFERENCES Employee(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;

ALTER TABLE WorksAtWH
	ADD CONSTRAINT FK_WorksAtWH_Warehouse
    FOREIGN KEY (WarehouseID)
    REFERENCES Warehouse(ID)
    ON DELETE CASCADE
	ON UPDATE CASCADE;
