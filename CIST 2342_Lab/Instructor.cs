/*Donya Moxley
 * CIST 2342 Fall 2018
 * Lab 3
 * 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIST_2342_Lab
{
    class Instructor : Person
    {
        private int id;
        private String roomNumber;



        public Instructor() : base()
        {

        }

        public Instructor(String fname, String lname, String mail, String str, String cy, String st, int zip, int _id, String _roomNumber) : base(fname, lname, mail, str, cy, st, zip)
        {
            id = _id;
            roomNumber = _roomNumber;
        }


        public Instructor(int id) : base()
        {
            SelectDB(id);

        }


        public int getID() { return id; }

        public void setID(int _id) { id = _id; }


        public String getRoomNumber() { return roomNumber; }


        public void setRoomNumber(String _roomNumber) { roomNumber = _roomNumber; }

        // Database connection methods

        public System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter2;
        public System.Data.OleDb.OleDbCommand OleDbSelectCommand2;
        public System.Data.OleDb.OleDbCommand OleDbInsertCommand2;
        public System.Data.OleDb.OleDbCommand OleDbUpdateCommand2;
        public System.Data.OleDb.OleDbCommand OleDbDeleteCommand2;
        public System.Data.OleDb.OleDbConnection OleDbConnection2;
        public String cmd;

        public void DBSetup()
        {
            OleDbDataAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
            OleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbConnection2 = new System.Data.OleDb.OleDbConnection();

            OleDbDataAdapter2.DeleteCommand = OleDbDeleteCommand2;
            OleDbDataAdapter2.InsertCommand = OleDbInsertCommand2;
            OleDbDataAdapter2.SelectCommand = OleDbSelectCommand2;
            OleDbDataAdapter2.UpdateCommand = OleDbUpdateCommand2;

            OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path =; Jet OLEDB:Database L" +
               "ocking Mode=1;Data Source=c:\\Users\\dmoxl\\Downloads\\RegistrationMDB.mdb;J" +
               "et OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System datab" +
               "ase=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=S" +
               "hare Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet " +
               "OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repai" +
               "r=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
        }
        public void SelectDB(int n)
        {
            DBSetup();
            cmd = "Select * from Instructors where ID = " + n;
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();
                dr.Read();
                id = (n);
                setFname(dr.GetValue(1) + "");
                setLname(dr.GetValue(2) + "");
                setStreet(dr.GetValue(3)+ "");
                setCity(dr.GetValue(4) + "");
                setState(dr.GetValue(5) + "");
                setZipCode(int.Parse(dr.GetValue(6) + ""));
                setRoomNumber(dr.GetValue(7) + "");
                setEmail(dr.GetValue(8) + "");
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }


        }

        public void InsertDB()
        {
            DBSetup();
            cmd = "INSERT into Instructors values("+ getID() +", '" + getFname() + "'," + "'" + getLname() + "'," + "'" + getStreet() + "'," +
                "'" + getCity() + "'," +"'"+ getState() +"',"+" " +getZipCode() +" , '"+ getRoomNumber()+"', '"+ getEmail()+ "')";
            OleDbDataAdapter2.InsertCommand.CommandText = cmd;
            OleDbDataAdapter2.InsertCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);

            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.InsertCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Inserted");
                else
                    Console.WriteLine("ERROR: Inserting Data");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            finally
            {
                OleDbConnection2.Close();
            }
        }

        public void UpdateDB()
        {
            cmd = "Update Instructors set FirstName = '" + getFname() + "'," +
             "LastName = '" + getLname() + "', " +
             "Street = '" + getStreet() +
             "', City ='"+getCity()+
             "', State ='" + getState()+
             "', Zip = "+ getZipCode()+ 
             ", Office = '"+getRoomNumber()+
             "', EMail= '"+getEmail()+
             "'  Where ID = " + getID() + ";";

            OleDbDataAdapter2.UpdateCommand.CommandText = cmd;
            OleDbDataAdapter2.UpdateCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);

            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.UpdateCommand.ExecuteNonQuery();
                if (n == 1)
                { Console.WriteLine("Data Updated"); }
                else { Console.WriteLine("ERROR: Updating Data"); }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { OleDbConnection2.Close(); }

        }

        public void DeleteDB()
        {
            cmd = "Delete from Instructors where ID = " + getID();
            OleDbDataAdapter2.DeleteCommand.CommandText = cmd;
            OleDbDataAdapter2.DeleteCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.DeleteCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Deleted");
                else
                    Console.WriteLine("ERROR: Deleting Data");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        }







        public new void Display()
        {
            Console.WriteLine("Instructor ID: " + getID());
            base.Display();
            Console.WriteLine("Room Number: " + getRoomNumber());
        }
    }
}