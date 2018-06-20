 CREATE TABLE Supplier
 (
   ID			NUMERIC(5,0)	NOT NULL,
   Name			VARCHAR(80)		NOT NULL,
   PhoneNum		VARCHAR(15)		NOT NULL,
   Email		VARCHAR(80),
   SAddress		VARCHAR(225),

   PRIMARY KEY (ID),
);