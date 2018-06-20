CREATE TABLE Employee(
   ID		NUMERIC(5,0)		NOT NULL,
   FName	VARCHAR(50)			NOT NULL,
   MNames	VARCHAR(80),
   LName	VARCHAR(50)			NOT NULL,
   Gender	BIT,
   
   NatID		NUMERIC(14,0)	NOT NULL, 
   Phone_Num	VARCHAR(15)		NOT NULL, 
   Email		VARCHAR(80),
   BasicSalary	smallmoney		NOT NULL   CHECK(BasicSalary>0),
   JobID		numeric(5,0),
   SupervisorID NUMERIC(5,0),

PRIMARY KEY (ID),
	  
);