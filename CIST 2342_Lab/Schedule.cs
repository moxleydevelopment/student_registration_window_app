/*Donya Moxley
 * CIST 2342 Fall 2018
 * Lab 4
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
    class Schedule
    {
        
        public List<Section> scheduleList = new List<Section>();


        public Schedule()
        {
        }

        public Schedule(Section a)
        {
            scheduleList.Add(a);
        }


      public void AddSection(int l, int x, String c, String t, String r)
        {
            scheduleList.Add(new Section(l, x, c, t, r));
        }


        public void AddSection(Section a)
        {
            scheduleList.Add(a);
        }

        public void AddSection(int crn)
        {
            scheduleList.Add(new Section(crn));

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

        public void SelectDB()
        {
            DBSetup();
            cmd = "Select * from Sections";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

                while (dr.Read())
                {
                    int l = (Int32.Parse(dr.GetValue(0) + ""));
                    String c= (dr.GetValue(1) + "");
                    String t= (dr.GetValue(2) + "");
                    String r= (dr.GetValue(3) + "");
                    int  x= (Int32.Parse(dr.GetValue(4) + ""));

                    AddSection(l, x, c, t, r);
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




        public void Display() {
           
            foreach (Section scl in scheduleList)
            {
                Console.WriteLine(scl.getCourseID());
                Console.WriteLine(scl.getCRN());
                Console.WriteLine(scl.getInstructor());
                Console.WriteLine(scl.getRoomNo());
                Console.WriteLine(scl.getTimeDays());
            }

        }

        



    }
}
