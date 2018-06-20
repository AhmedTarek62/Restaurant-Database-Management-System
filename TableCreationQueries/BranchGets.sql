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
