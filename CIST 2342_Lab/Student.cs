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
    class Student : Person 

    {
        private int id;
        private double gpa;
        public Schedule schedule = new Schedule();



        public Student() : base()
        {

        }

        


        public Student(String fname, String lname, String mail, String str, String cy, String st, int zip, int _id, double _gpa) : base(fname, lname, mail, str, cy, st, zip) 
        {
            id = _id;
            gpa = _gpa;
        }

        public Student(int id) :base()
        {
            SelectDB(id);
        }

       

        
        public int getID() { return id; }
        public void setID(int _id) { id = _id; }

        public int getCRN() { return getCRN(); }
        public void setCRN(int _crn) { schedule.AddSection(_crn); }

        public double getGPA() { return gpa; }
        public void setGPA(double _gpa) { gpa = _gpa; }

        

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
            cmd = "Select * from Students where ID = " + n;
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
                setStreet(dr.GetValue(3) + "");
                setCity(dr.GetValue(4) + "");
                setState(dr.GetValue(5) + "");
                setZipCode(int.Parse(dr.GetValue(6) + ""));
                setEmail(dr.GetValue(7) + "");
                setGPA(double.Parse(dr.GetValue(8) + ""));
                dr.Close();

               // OleDbConnection2.Close();
                cmd = "Select * from StudentSchedule where StudentID = " + getID();
                OleDbDataAdapter2.SelectCommand.CommandText = cmd;
                OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
                Console.WriteLine(cmd);
                // OleDbConnection2.Open();
                 System.Data.OleDb.OleDbDataReader dr1;
                dr1 = OleDbDataAdapter2.SelectCommand.ExecuteReader();
                
                while (dr1.Read())
                {
                    
                    Console.WriteLine(dr1.GetValue(1));
                    schedule.AddSection(int.Parse(dr1.GetValue(1)+ ""));
                }









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
            cmd = "INSERT into Students values('" + getID() + "', '" + getFname() + "'," + "'" + getLname() + "'," + "'" + getStreet() + "'," +
                "'" + getCity() + "'," + "'" + getState() + "'," + "'" + getZipCode() + "' , '" + getEmail() + "', '" + getGPA() + "')";
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
            cmd = "Update Students set FirstName = '" + getFname() + "'," +
             "LastName = '" + getLname() + "', " +
             "Street = '" + getStreet() +
             "', City ='" + getCity() +
             "', State ='" + getState() +
             "', Zip = " + getZipCode() +
             ", EMail = '" + getEmail() +
             "', GPA = " + getGPA() +
             "  Where ID = " + getID() + ";";

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
            cmd = "Delete from Students where ID = " + getID();
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

        public void AddSectionDB(int crn)
        {
            cmd = "INSERT into StudentSchedule values('" + getID() + "', '" + crn + "')";
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

        public void DeleteSectionDB(int crn)
        {
            cmd = "Delete from StudentSchedule where StudentID = " + getID()+ " and CRN = " + crn +" ;";
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

        public new void  Display()
        {
            Console.WriteLine("Student ID: " + getID());
            base.Display();
            Console.WriteLine("GPA: " + getGPA());
        }

    }   
}
