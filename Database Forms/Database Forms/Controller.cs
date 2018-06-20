using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace Database_Forms
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }
        public int CheckPassword(String username, String password)
        {
            string query = "Select Privilege From LoginInfo Where" + "'" +username + "'"+ "= Username AND" + "'" + password + "'" +"=uPassword";
            return Int16.Parse(dbMan.ExecuteScalarQuery(query).ToString());
        }
        public int AddSupplier(int SprID, String Name, String PhoneNum, String mail,/**Removed the rest and SAddress Added**/ String SAddress)
        // Add Supplier given these information
        {
            string query = "INSERT INTO Supplier(ID,Name,PhoneNum,Email,SAddress) Values("
            + SprID + ",'"
            + Name + "',"
            + PhoneNum + ",'" //Notice there are no " ' " because I want PhoneNum to be input as a number no text.Although it is originally a string.
            + mail + "','"
            + SAddress + "');";
            return dbMan.UpdateData(query);


        }

        public int AddEmployee(String Fname, String Mname, String Lname, bool Gender,int ID, String NatID, String Phone_Num, String mail, int Salary, String Job_Type, int SuperVisorID)

        //Adds Employee given these information.
        //Job_ID is zero if no such job is found (Hopefully won't happen since the user chooses from a list, 
        //but zero is to prevent program from crashing and know the error type).
        {
            String Job_ID;
            string query1 = "SELECT ID FROM Job WHERE Descr like '%" + Job_Type + "%' ;"; //First query to get Job_ID.

            Job_ID = dbMan.ExecuteScalarQuery(query1).ToString();


            int sex;
            if (Gender) { sex = 1; } else { sex = 0; } //To fix that bool for sql is 0 and 1, while bool for C# is true and false.


            //The Query:
            string query2 = "INSERT INTO Employee (ID,FName,MNames,LName,Gender,NatID,Phone_Num,Email,BasicSalary,JobID,SupervisorID) " +
                            "Values (" + ID + ",'"
                            + Fname + "','"
                            + Mname + "','"
                            + Lname + "',"
                            + sex + ",'"
                            + NatID + "','"
                            + Phone_Num + "','"
                            + mail + "',"
                            + Salary + ","
                            + Job_ID + ","
                            + SuperVisorID + ");";

            return dbMan.UpdateData(query2);
        }

        public int AddSupply(int SpyID, String Name, double UnitPrice, String Unit)
        //Add supply given these information
        {

            String Unit_ID;
            string query1 = "SELECT ID FROM MeasurementUnit  WHERE Descr like '%" + Unit + "%' ;"; //First query to get Unit_ID.

            Unit_ID = dbMan.ExecuteScalarQuery(query1).ToString();

            string query2 = "INSERT INTO Supply(ID,Name,UnitPrice,UnitID) VALUES("
                + SpyID + ",'"
                + Name + "',"
                + UnitPrice + ","
                + Unit_ID + ");";

            return dbMan.UpdateData(query2);
        }



        public String GetTotal_Income(int Start_Month, int Start_Day, int End_Month, int End_Day)
        //Gets Total Income over a time period of time //Year is always this year.
        {
            string This_Year = DateTime.Now.Year.ToString();
            string query1 = "SELECT SUM(TotalPrice) FROM Cust_Order WHERE NOT(OTimeStamp > '"
                + This_Year + "-" + End_Month + "-" + End_Day
                + "' OR OTimeStamp < '"
                + This_Year + "-" + Start_Month + "-" + Start_Day + "');";
            return dbMan.ExecuteScalarQuery(query1).ToString();
        }

        public string GetMostUsedItem(int Start_Month, int Start_Day, int End_Month, int End_Day)
        { //View the most frequently bought items in a time period of his/her choice

            string This_Year = DateTime.Now.Year.ToString();
            string query1 = " SELECT Name FROM Item WHERE ID in(SELECT ItemID FROM(SELECT SUM(Number) as summed_n , ItemID From OrderItems AS OI WHERE OI.OrderID IN(Select OrderID FROM Cust_Order WHERE  NOT(OTimeStamp > '"
                    + This_Year + "-" + End_Month + "-" + End_Day + " ' OR OTimeStamp < '"
                    + This_Year + "-" + Start_Month + "-" + Start_Day + "'))"
                    + " Group By ItemID) as Summed_All Where summed_n = (SELECT MAX(a.Total_Qty) as 'Max_Qty' From(SELECT OT.ItemID, SUM(OT.Number) AS Total_Qty FROM OrderItems as OT GROUP BY OT.ItemID) as a));";
            return dbMan.ExecuteScalarQuery(query1).ToString();
        }

        public DataTable ViewMostActiveCusts(int Start_Month, int Start_Day, int End_Month, int End_Day)
        {   //Allows Supervisor to view Most Active Customer(s) within a certain time frame to send them Offers/Invitations.
            //Phone Number and first name are displayed.

            string This_Year = DateTime.Now.Year.ToString();
            string query1 = "Select Fname,PhoneNum  /*Select Needed Data*/ From Customer  Where ID IN (SELECT  CustID /*Select the CustID with max time*/FROM (SELECT COUNT(*) AS times, CustID FROM Cust_Order" +
                        " Where NOT(Cust_Order.OTimeStamp> '"
                        + This_Year + "-" + End_Month + "-" + End_Day
                        + "' OR Cust_Order.OTimeStamp < '"
                        + This_Year + "-" + Start_Month + "-" + Start_Day + "' )"
                        + " group by CustID) CustID Where times = (SELECT MAX(a.Total_Qty) as 'Max_Qty' From(SELECT CustID, COUNT(*) AS Total_Qty /*Find Max Time*/ FROM Cust_Order"
                        + " Where NOT(Cust_Order.OTimeStamp> '"
                        + This_Year + "-" + End_Month + "-" + End_Day
                        + "' OR Cust_Order.OTimeStamp < '"
                        + This_Year + "-" + Start_Month + "-" + Start_Day + "' )" +
                        "GROUP BY CustID) as a))";
            return dbMan.ExecuteTableQuery(query1);
        }

        public DataTable ViewOrderListAndStatus(int limt_minutes)
        {
            //Displays A list of order ID’s and their status, ordered limit_minutes away. (Maximum is not 60, can enter Up to 4 Hours earlier (random choice of limit))  //Also shows  customer name 
            //--Order, OStatus,Customer

            string query1 = "Select FName, OrderID, Descr from Customer, Cust_Order, OrderStatus Where OstatusID = OrderStatus.ID AND Cust_Order.CustID = Customer.ID AND OTimeStamp> DateAdd(MINUTE, DateDiff(MINUTE, 0, GetDate()) - "
                + limt_minutes + ", 0);";
            return dbMan.ExecuteTableQuery(query1);
        }
        public int AddOrder(int Status, int CashierID, int CustID, double Net_Price, int BranchID)
        {
            //Autogenerates OrderID from Last Order (So that Chef would know what order came first). 
            //Timestamp Auto-generated.  
            //ServicePrice and TaxPrice are calculated from Net Price. Total Price is calculated from Net Price + Service Price + Tax Price. 
            //Also Subtracts the amount used from every raw material from each item on the order used, from Branch_Has.


            //Get Previous Order_ID and ADD 1

            string query1 = "select MAX(OrderID) from Cust_Order";
            int new_order_id = Int32.Parse(dbMan.ExecuteScalarQuery(query1).ToString()) + 1;


            //Timestamp Auto-generated.  

            DateTime TheMoment = DateTime.Now;

            //Get ServicePrice and TaxPrice and TotalPrice

            double ServicePrice = Net_Price * 0.12;
            double TaxPrice = Net_Price * 0.13;
            double TotalPrice = Net_Price + ServicePrice + TaxPrice;

            //AddOrder
            string query2 = "Insert Into Cust_Order Values("
                + new_order_id + ",'"
                + TheMoment + "',"
                + Status + ","
                + CashierID + ","
                + CustID + ","
                + Net_Price + ","
                + ServicePrice + ","
                + TaxPrice + ","
                + TotalPrice + ","
                + BranchID + ");";
            return dbMan.UpdateData(query2);
        }
        public int UpdateRawMaterialPrice(int Spy_ID, double New_Price)
        {
            /* Updates item prices given a new price to a certain raw material. 
Algorithm: Gets all items containing a certain raw material, then for each item: Averages old and new price of the raw material, and subracts (new_price - old_price)*Qty of  the raw material used in item, from the item price.*/

            string query1 = "select UnitPrice from Supply Where ID =" + Spy_ID + ";";
            double Old_Price = double.Parse(dbMan.ExecuteScalarQuery(query1).ToString());
            string query2 = "Update Supply Set UnitPrice = " + New_Price + " Where ID =" + Spy_ID;
            dbMan.UpdateData(query2);

            string query3 = "Select ID From Item Where ID in(Select ItemID from ItemContains where SupplyID =" + Spy_ID + ")";

            DataTable ItemIDtable = dbMan.ExecuteTableQuery(query3); //Table Items
            int ctr = 0;
            string query5, query6, query7; double QuantityUsed; double CurrentItemPrice;
            foreach (DataRow row in ItemIDtable.Rows)
            {
                foreach (var itemID in row.ItemArray)
                {
                    query5 = "select Qty FROM ItemContains Where ItemID =" + itemID + "AND SupplyID = " + Spy_ID + ";";
                    QuantityUsed = double.Parse(dbMan.ExecuteScalarQuery(query5).ToString());
                    query6 = "select Price from Item Where ID =" + itemID + ";";
                    CurrentItemPrice = double.Parse(dbMan.ExecuteScalarQuery(query6).ToString());
                    double newItemPrice = CurrentItemPrice - QuantityUsed * CurrentItemPrice + QuantityUsed * (New_Price + CurrentItemPrice) / 2;
                    query7 = "update Item Set Price =" + newItemPrice + "where ID=" + itemID + ";";
                    dbMan.UpdateData(query7);
                    Console.Write("Item: "); // Print label.
                    Console.WriteLine(itemID);
                    Console.Write("New_Price:");
                    Console.WriteLine(newItemPrice);
                }
            }




            return 0;


        }
        public int AddBranch_WarehouseTransaction(int BID, int WHID, int SupplyID, DateTime Date1, int Qty, String Unit, int Price)
        { //Subtracts Qty from Warehouse_Has table with SupplyID and adds it to the quantity in Branch_Gets table, under the same SupplyID. Also adds it to the Branch_Has table, with the same SupplyID.
          //-- Branch_Has, Branch_Gets, Supply

            String Unit_ID;
            string query1 = "SELECT ID FROM MeasurementUnit  WHERE Descr like '%" + Unit + "%' ;"; //First query to get Unit_ID.
            Unit_ID = dbMan.ExecuteScalarQuery(query1).ToString();


            string query2 = "INSERT INTO BranchGets(BranchID,WarehouseID,SupplyID,ArrivalDate,QTY,UnitID,UnitPrice) VALUES("
                + BID + ","
                + WHID + ","
                + SupplyID + ",'"
                + Date1 + "',"
                + Qty + ","
                + Unit_ID + ","
                + Price + ");";
            dbMan.UpdateData(query2);
            //Added to BranchGets

            string query3 = "select Qty from BranchHas Where SupplyID =" + SupplyID + " AND BranchID=" + BID + ";";
            double Old_Quantity = double.Parse(dbMan.ExecuteScalarQuery(query3).ToString());
            double NewQuantity = Old_Quantity + Qty;
            string query4 = "Update BranchHas SET Qty =" + NewQuantity + " Where SupplyID =" + SupplyID + " AND BranchID=" + BID + "; ";
            dbMan.UpdateData(query4);
            //Added to  BranchHas 
            //Need to check first if it does not exist to Insert instead of Update  but will do this later


            //Subtracted to WareHouseHas
            string query5 = "Select TransactionID From WarehouseHas Where SupplyID=" + SupplyID + ";";
            DataTable Transtable = dbMan.ExecuteTableQuery(query5); //Table Items

            double Needed_Quantity = Qty; double AvaialbleWithExpiringBatch;

            string query6; string query7;

            while (Needed_Quantity > 0)
            {
                query6 = "select QtyLeft From WarehouseHas W where W.SupplyID =" + SupplyID + " and ExpiryDate = (Select Min(ExpiryDate) From WarehouseHas H Where H.SupplyID = W.SupplyID );";
                AvaialbleWithExpiringBatch = double.Parse(dbMan.ExecuteScalarQuery(query6).ToString());

                if (AvaialbleWithExpiringBatch >= Needed_Quantity)
                {
                    AvaialbleWithExpiringBatch -= Needed_Quantity; //Then Update the AvaialableWithExpiringBatch
                    query7 = "Update WareHouseHas  SET QtyLeft =" + AvaialbleWithExpiringBatch + " where TransactionID in(select TransactionID From WarehouseHas W where W.SupplyID =" + SupplyID + " and ExpiryDate = (Select Min(ExpiryDate) From WarehouseHas H Where H.SupplyID = W.SupplyID ))";
                    dbMan.UpdateData(query7);
                }
                else
                {
                    Needed_Quantity -= AvaialbleWithExpiringBatch; //Then AvailableWithExpiration=0, and delete it.
                    query7 = "Delete From WarehouseHas where TransactionID in(select TransactionID From WarehouseHas W where W.SupplyID =" + SupplyID + " and ExpiryDate = (Select Min(ExpiryDate) From WarehouseHas H Where H.SupplyID = W.SupplyID ))";
                    dbMan.UpdateData(query7);
                }




            }


            /*foreach (DataRow row in Transtable.Rows)
            {
                foreach (var TID in row.ItemArray)
                {
                    
                }

            }*/










            return 0;
        }

    }

        
    }

;