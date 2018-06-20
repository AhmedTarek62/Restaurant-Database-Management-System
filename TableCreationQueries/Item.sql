CREATE TABLE Item
( 

 ID					NUMERIC(5,0)	NOT NULL,
 Name				Varchar(40)		Not null, 
 Price				smallmoney		NOT NULL     CHECK(Price>0),
 ItemCategoryID		NUMERIC(5,0),
 IAvailability		BIT				NOT NULL,
 
 PRIMARY KEY(ID)
 );

