CREATE TABLE Branch_Has
(
 BranchID       NUMERIC(5,0)    NOT NULL,
 SupplyID		NUMERIC(5,0)    NOT NULL,
 Qty			NUMERIC(6,2)    NOT NULL,
 UnitID			numeric(5,0)	NOT NULL,

 PRIMARY KEY(BranchID,SupplyID),
  );

