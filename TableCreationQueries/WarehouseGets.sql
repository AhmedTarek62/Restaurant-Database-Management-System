CREATE TABLE WarehouseGets
(
 TransactionID		NUMERIC(5,0)	NOT NULL,
 WarehouseID		NUMERIC(5,0)	NOT NULL,
 SupplyID			NUMERIC(5,0)	NOT NULL,
 SupplierID			NUMERIC(5,0)	NOT NULL,
 Qty				NUMERIC(6,2)	NOT NULL,
 UnitID				NUMERIC(5,0),
 ArrivalDate		date			NOT NULL,
 ExpiryDate			date			Not null, 
 UnitPrice			smallmoney		not null	CHECK (UnitPrice>0),

 PRIMARY KEY(TransactionID),
  );