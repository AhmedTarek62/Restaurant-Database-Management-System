CREATE TABLE Cust_Order(

OrderID			NUMERIC(5,0)	NOT NULL,
OTimeStamp		smallDATETIME,
OStatusID		NUMERIC(5,0),
CashierID		NUMERIC(5,0)	NOT NULL,                               
CustID			NUMERIC(5,0)	NOT NULL,                                   
NetPrice		smallmoney		NOT NULL CHECK(NetPrice>0),
ServicePrice	smallmoney		NOT NULL CHECK(ServicePrice>0),
TaxPrice		smallmoney		NOT NULL CHECK(TaxPrice>0),
TotalPrice		smallmoney		NOT NULL CHECK(TotalPrice>0),
BranchID		NUMERIC (5,0)	NOT NULL,

PRIMARY KEY (OrderID),
   
);