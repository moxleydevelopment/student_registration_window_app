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
    class Person
    {
        private String fName;
        private String lName;
        private String email;
        private Address address;
        private Schedule schedule;


        public Person()
        {
            schedule = new Schedule();
            address = new Address();
        }

        public Person(String fname, String lname, String mail, String str, String cy, String st, int zip)
        {
            fName = fname;
            lName = lname;
            email = mail;
            address = new Address(str, cy, st, zip);
            schedule = new Schedule();

            
        }

        

        public String getFname() { return fName; }

        public void setFname(String fname) { fName = fname; }

        public String getLname() { return lName; }

        public void setLname(String lname) { lName = lname; }

        public String getEmail() { return email; }

        public void setEmail(String mail) { email = mail; }

        public String getStreet() { return address.getStreet(); }

        public void setStreet(String street) { address.setStreet(street); }

        public String getCity() { return address.getCity(); }

        public void setCity(String city) { address.setCity(city); }

        public String getState() { return address.getState(); }

        public void setState(String state) { address.setState(state); }

        public int getZipCode() { return address.getZipCode(); }

        public void setZipCode(int zip) { address.setZipCode(zip); }

        public void addSection(Section a)
        {

            schedule.AddSection(a);
        }

        public void addSection(int n, int x, String course, String time, String room)
        {
            schedule.AddSection(n, x, course, time, room);
        }


       


        public void Display()
        {
            Console.WriteLine("First Name: " + getFname());
            Console.WriteLine("Last Name: " + getLname());
            Console.WriteLine("Email Address: " + getEmail());
            Console.WriteLine("Address: " +" "+ address.getStreet()+" " + address.getCity()+" " + address.getState() +" "+ address.getZipCode());
            schedule.Display();
        }






    }
}
