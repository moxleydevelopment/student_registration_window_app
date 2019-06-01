/*Donya Moxley
 * CIST 2342 Fall 2018
 * Course class
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
    class Course
    {
        // Properties

         private String courseID, courseName, description;
         private int creditHours;

        // Constructors

        public Course()
        {
            courseID = "";
            courseName = "";
            description = "";
            creditHours = 0;
        }

        public Course(String id, String name, String des, int hours)
        {
            courseID = id;
            courseName = name;
            description = des;
            creditHours = hours;
            
        }

        public Course(String id)
        {
            SelectDB(id);
        }

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

        public void SelectDB(String id)
        {
            DBSetup();
            cmd = "Select * from Courses where CourseID = '" + id + "'";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();
                dr.Read();
                courseID = (id);
                setCourseName(dr.GetValue(1) + "");
                setDescription(dr.GetValue(2) + "");
                setCreditHours((Int32.Parse(dr.GetValue(3) + "")));
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
            cmd = "INSERT into Courses values('" + getCourseID() + "'," + "'" + getCourseName() + "'," + "'" + getDescription() + "'," +
                "'" + getCreditHours() + "'" + ")";
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
            catch(Exception ex)
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
            cmd = "Update Courses set CourseName = '" + getCourseName() + "'," +
             "Description = '" + getDescription() + "', " +
             "CreditHours = '" + getCreditHours() + "'  Where CourseID = '" + getCourseID()+"';";

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
            cmd = "Delete from Courses where CourseID = '" + getCourseID()+"'";
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

        // behaviors

        public String getCourseID() { return courseID; }

        public void setCourseID(String id) { courseID = id; }

        public String getCourseName() { return courseName; }

        public void setCourseName(String name) { courseName = name; }

        public String getDescription() { return description; }

        public void setDescription(String des) { description = des; }

        public int getCreditHours() { return creditHours; }

        public void setCreditHours(int hours) { creditHours = hours; }


        // Display method

        public void Display()
        {
            Console.WriteLine("Course ID: " + getCourseID());
            Console.WriteLine("Course Name: " + getCourseName());
            Console.WriteLine("Description: " + getDescription());
            Console.WriteLine("Credit Hours: " + getCreditHours());
        }


    }
}
