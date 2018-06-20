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

