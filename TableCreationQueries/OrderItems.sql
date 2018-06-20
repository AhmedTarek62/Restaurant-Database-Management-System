CREATE TABLE OrderItems 
(OrderID		NUMERIC(5,0)	NOT NULL,
 ItemID			numeric(5,0)	NOT NULL,
 Number			smallint		NOT NULL,
 
 PRIMARY KEY(OrderID,ItemID),
  );