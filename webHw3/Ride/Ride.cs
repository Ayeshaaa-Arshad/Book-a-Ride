using System;
using location;
using Driver;
using Passenger;
using Admin;
using System.Numerics;
using Microsoft.Data.SqlClient;
namespace Ride
{
    public class Ride
    {
        public location.Location start_location, end_location;
        public double price;
        public Driver.Driver driver;
        public Passenger.Passenger passenger;

        public int MyPrice { get; set; }
        public Driver.Driver Driver { get; set; }
        public Passenger.Passenger Passenger { get; set; }
        public void assignPassenger(Passenger.Passenger obj)
        {
            this.passenger = obj;
        }

        public bool assignDriver(Admin.Admin admin, location.Location start, Passenger.Passenger p, Ride r,string type)
        {
            double cost = 0;
            int driver_number = 0;
            double latitude_diff, longitude_diff = 0;
            double distance = 0;
            bool flag = false;

            Driver.Driver d = new Driver.Driver();
            dynamic listOfDrivers= admin.GetAllDrivers(d);
            
            for (int i = 0; i < listOfDrivers.Count; i++)
            {
                d = listOfDrivers[i];
                if (d.MyAvailabilty && (type.ToLower()) == d.Vehicle.MyType.ToLower())
                {
                    latitude_diff = Math.Pow((start.Mylatitude - d.curr_location.Mylatitude), 2);
                    longitude_diff = Math.Pow((start.Mylongitude - d.curr_location.Mylongitude), 2);
                    distance = Math.Sqrt(latitude_diff + longitude_diff);
                    if (cost == 0)
                        cost = distance;
                    if (distance <= cost)
                    {
                        cost = distance;
                        driver_number = i;
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                driver = listOfDrivers[driver_number];
                passenger = p;
                Console.WriteLine("\nDriver assigned " + driver.Myname +"\n");

                return true;
            }
            return false;
        }

        public void getLocations(location.Location start, location.Location end)
        {
            start_location = start;
            end_location = end;
        }

        public void giveRating(int rate)
        {
            driver.rating.Add(rate);
        }
        public double calculatePrice(string type)
        {
            int fuel_avg = 0;double commission = 0;
            bool flag = false;
            double latitude_diff = Math.Pow((start_location.Mylatitude - end_location.Mylatitude), 2);
            double longitude_diff = Math.Pow((start_location.Mylongitude - end_location.Mylongitude), 2);
            double distance = Math.Sqrt(latitude_diff + longitude_diff);
            if(type=="bike"|| type=="Bike")
            {
                fuel_avg = 50;
                commission = 0.05;
                flag = true;
            }
            else if(type=="Rickshaw"|| type=="rickshaw")
            {
                fuel_avg = 35;
                commission = 0.1;
                flag = true;
            }
            else if(type=="car" || type=="Car")
            {
                fuel_avg = 15;
                commission = 0.2;
                flag = true;
            }
            float fuel_price = 250;
            if (flag)
                 price = ((distance * fuel_price) / fuel_avg) + commission;
            return price;
        }
    }
    
}
