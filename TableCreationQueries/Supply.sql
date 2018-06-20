CREATE TABLE Supply
(
   ID			NUMERIC(5,0)	NOT NULL,
   Name			VARCHAR(50)		NOT NULL,
   UnitPrice	smallmoney		NOT NULL	CHECK(UnitPrice>0),
   
   UnitID		numeric(5,0)	NOT NULL,


PRIMARY KEY (ID),

);