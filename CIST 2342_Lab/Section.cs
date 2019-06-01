/*Donya Moxley
 * CIST 2342 Fall 2018
 * Section class
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
    class Section
    {
        // Properties
        private int crn, instructor;
        private String courseID, timeDays, roomNo;


        // Constructors

        public Section()
        {

            crn = 0;
            instructor = 0;
            courseID = "";
            timeDays = "";
            roomNo = "";
        }

        public Section(int n ,int x, String course, String time, String room)
        {
            crn = n;
            instructor = x;
            courseID = course;
            timeDays = time;
            roomNo = room;
            
        }

        public Section(int n)
        {
            crn = n;
            SelectDB(crn);
        }
        // Behaviors 

        public int getCRN() { return crn; }

        public void setCRN(int n) { crn = n; }

        public int getInstructor() { return instructor; }

        public void setInstructor(int x) { instructor = x; }

        public String getCourseID() { return courseID; }

        public void setCourseID(String course) { courseID = course; }

        public String getTimeDays() { return timeDays; }

        public void setTimeDays(String time) { timeDays = time; }

        public String getRoomNo() { return roomNo; }

        public void setRoomNo(String room) { roomNo = room; }


        // Display Method 

        
        public void Display()
        {
            Console.WriteLine("CRN: " + getCRN());
            Console.WriteLine("Course ID: " + getCourseID());
            Console.WriteLine("Time and Day: " + getTimeDays());
            Console.WriteLine("Instructor: " + getInstructor());
            Console.WriteLine("Room Number: " + getRoomNo());

        }


        //database methods

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
            cmd = "Select * from Sections where CRN = " + n ;
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();
                dr.Read();
                crn = (n);
                setCourseID(dr.GetValue(1) + "");
                setTimeDays(dr.GetValue(2) + "");
                setRoomNo(dr.GetValue(3) + "");
                setInstructor(Int32.Parse(dr.GetValue(4) + ""));

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
            cmd = "INSERT into Sections values('" + getCRN() + "'," + "'" + getCourseID() + "'," + "'" + getTimeDays() + "'," +
                "'" + getRoomNo() + "' , '"+ getInstructor() + "')";
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
            cmd = "Update Sections set CourseID = '" + getCourseID() + "'," +
             " TimeDays = '" + getTimeDays() + "', " +
             "RoomNo = '" + getRoomNo() + "' ,"+ " Instructor = "+ getInstructor() +"   Where CRN = " + getCRN() + ";";

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
            cmd = "Delete from Sections where CRN = " + getCRN();
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

    }

    
}
