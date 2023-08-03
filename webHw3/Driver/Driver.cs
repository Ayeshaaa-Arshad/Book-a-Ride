using System;
using location;
using System.Collections;
using Vehicle;
using System.Collections.Generic;

namespace Driver
{
    public class Driver
    {
        public int ID;
        public string name;
        public int age;
        public string gender;
        public string address;
        public string phone_no;
        public location.Location curr_location = new location.Location();
        public Vehicle.Vehicle Vehicle = new Vehicle.Vehicle();
        public bool availability;
        public List<int> rating = new List<int>();

        public Driver(string n, int a, string g, string ad, Vehicle.Vehicle v, string phone = "", int id = 0, double lat = 0, double longi = 0)
        {
            Myname = n;
            MyAge = a;
            MyGender = g;
            MyAddress = ad;
            this.Vehicle = v;
            availability = true;
            ID = id;
            curr_location.Mylatitude = lat;
            curr_location.Mylongitude = longi;
            MyPhone = phone;
        }
        public Driver()
        {
            Myname = "ali";
            MyAge = 1;
            MyGender = "M";
            MyAddress = "";
            availability = true;
            MyID = 0;

        }
        public int MyID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public string Myname
        {
            get
            {
                return name;
            }
            set
            {
                name= value;
            }
        }
        public int MyAge
        { get; set; }
        public string MyGender
        { get; set; }
        public string MyAddress
        { get; set; }
        public string MyPhone
        { get; set; }
        public bool MyAvailabilty
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
            }
        }
        public void updateAvailability(bool status)
        {
            MyAvailabilty = status;
        }
        public float getRating()
        {
            float sum = 0;
            foreach (var i in rating)
            {
                sum += rating[i];
            }
            return sum / rating.Count;
        }

        public void updateLocation()
        {
            Console.WriteLine("Enter the updated value for latitude");
            Console.ForegroundColor = ConsoleColor.Green;
            curr_location.Mylatitude = float.Parse(Console.ReadLine());
            Console.ResetColor();

            Console.WriteLine("Enter the updated value for longitude");
            Console.ForegroundColor = ConsoleColor.Green;
            curr_location.Mylongitude = float.Parse(Console.ReadLine());
            Console.ResetColor();
        }

    }
}
