/*Donya Moxley
 * CIST 2342 Fall 2018
 * Address class
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
    class Address
    {
        // properties
        protected String street, city, state;
        protected int zipCode;

        // constructors

         public Address()
        {
            street = "";
            city = "";
            state = "";
            zipCode = 0;
            
        }


        public Address(String str, String cy, String st, int zip)
        {
            street = str;
            city = cy;
            state = st;
            zipCode = zip;
        }


        // Behaviors 

        public String getStreet() {return street;}

        public void setStreet(String str) { street = str; }

        public String getCity() { return city; }

        public void setCity(String cy) { city = cy; }

        public String getState() { return state; }

        public void setState(String st) { state = st; }

        public int getZipCode() { return zipCode; }

        public void setZipCode(int zip) { zipCode = zip; }


        // Display method

        public void Display()
        {

            Console.WriteLine("Street is: " + getStreet());
            Console.WriteLine("City is: " + getCity());
            Console.WriteLine("State is: " + getState());
            Console.WriteLine("Zipcode is: " + getZipCode());

        }
        
    }
}
