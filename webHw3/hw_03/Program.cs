using System;
using Driver;
using Admin;
using System.Reflection.Emit;
using System.Collections.Generic;
using Microsoft.Identity.Client;

class TakeInput
{
    public static int TakeId()
    {
        int id = 0;
        Console.WriteLine("Enter ID ");
        Console.ForegroundColor = ConsoleColor.Green;
        string Id = Console.ReadLine();
        Console.ResetColor();
        int res;
        bool isnumeric = int.TryParse(Id, out res);
        while (Id == "" || !isnumeric)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter phone no again:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Id = Console.ReadLine();
            Console.ResetColor();
            isnumeric = int.TryParse(Id, out res);
        }
        id = res;
        return id;
    }
    public static dynamic TakeChoice(dynamic choice)
    {
        while (choice > 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter 1 or 3 only:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            choice = System.Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
        }
        return choice;
    }
    public static string EnterName(int x = 0)
    {
        Console.Write("Enter Name:");
        Console.ForegroundColor = ConsoleColor.Green;
        string name = Console.ReadLine();
        Console.ResetColor();
        if (x == 0)
        {
            while (name == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nWrong Input…!\n\nEnter name again:  ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                name = Console.ReadLine();
                Console.ResetColor();
            }
        }
        return name;
    }
    public static string EnterPhone_no()
    {
        Console.Write("Enter Phone no: ");
        Console.ForegroundColor = ConsoleColor.Green;
        string phone = Console.ReadLine();
        Console.ResetColor();
        int res;
        bool isnumeric = int.TryParse(phone, out res);

        while (phone == "" || !isnumeric)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter phone no again:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            phone = Console.ReadLine();
            Console.ResetColor();
            isnumeric = int.TryParse(phone, out res);
        }
        return phone;
    }
    public static void enterLatitude_Longitude(double start_loc_1, double start_loc_2, double end_loc_1, double end_loc_2)
    {
        Console.Write("Enter Start Location comma seperated :");
        Console.ForegroundColor = ConsoleColor.Green;
        string loc = Console.ReadLine();
        string[] location = loc.Split(',');

        start_loc_1 = double.Parse(location[0]);
        start_loc_2 = double.Parse(location[1]);
        Console.ResetColor();

        Console.Write("Enter End Location comma seperated :");
        Console.ForegroundColor = ConsoleColor.Green;
        loc = Console.ReadLine();
        location = loc.Split(',');
        end_loc_1 = double.Parse(location[0]);
        end_loc_2 = double.Parse(location[1]);
        Console.ResetColor();

    }
    public static string EnterRideType()
    {
        Console.Write("Enter Ride vehicle Type car/rickshaw/bike");
        Console.ForegroundColor = ConsoleColor.Green;
        dynamic type = Console.ReadLine();
        Console.ResetColor();
        while (type == "" || (type != "car" && type != "rickshaw" && type != "bike" && type != "Car" && type != "Rickshaw" && type != "Bike"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter type again car/rickshaw/bike:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            type = Console.ReadLine();
            Console.ResetColor();
        }
        return type;
    }
    public static string confirmRide()
    {
        Console.Write("\nEnter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation:");
        Console.ForegroundColor = ConsoleColor.Green;
        var ch = Console.ReadLine();
        Console.ResetColor();

        if (ch != "N" && ch != "Y")
        {
            while (ch != "N" && ch != "Y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nWrong Input…!\n\nEnter Y or N only:  ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                ch = Console.ReadLine();
                Console.ResetColor();
            }
        }
        return ch;
    }
    public static void RideConfirmed(Ride.Ride r)
    {
        bool isnumeric;
        Console.Write("\nHappy Travel…!\n\nGive rating out of 5:  ");
        Console.ForegroundColor = ConsoleColor.Green;
        string rating = Console.ReadLine();
        Console.ResetColor();
        int result;
        isnumeric = int.TryParse(rating, out result);

        while (rating == "" || !isnumeric || result > 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter Rating again out of 5:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            rating = Console.ReadLine();
            Console.ResetColor();
            isnumeric = int.TryParse(rating, out result);
        }
        int Rating = result;

        r.giveRating(Rating);
    }
    public static void PriceOfRide(Ride.Ride r, string type)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Price for this ride is: " + r.calculatePrice(type));
        Console.ResetColor();
    }
    public static void RideCantBooked()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You can't book any ride as we don't have any driver available as per your need ;)\n");
        Console.ResetColor();
    }
    public static dynamic EnterLatitude(string name)
    {
        double a = 0;
        if (name != "")
            Console.Write("Hello " + name + "!\nEnter our current latitude ");
        Console.ForegroundColor = ConsoleColor.Green;
        string lat= Console.ReadLine();
        if (lat != "")
            a = double.Parse(lat);
        Console.ResetColor();
        return a;
    }
    public static dynamic EnterLongitude()
    {
        double b = 0;
        Console.Write("Enter our current longitude ");
        Console.ForegroundColor = ConsoleColor.Green;
        string longi = Console.ReadLine();
        if (longi != "")
            b= double.Parse(longi);
        Console.ResetColor();
        return b;
    }
    public static dynamic askFor3options()
    {
        Console.WriteLine("1. Change availabilty\n2. Update Location\n3. Exit as driver\n\nPress 1 to 3 to select an option");
        Console.ForegroundColor = ConsoleColor.Green;
        int ch = System.Convert.ToInt32(Console.ReadLine());
        while (ch > 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter 1 to 3 only:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            ch = System.Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
        }
        Console.ResetColor();
        return ch;
    }
    public static void changeAvailabilty(Driver.Driver driver, Admin.Admin admin, int id)
    {
        Console.WriteLine("You may change your availabilty true/false !!!\n");
        string status = Console.ReadLine();
        while (status != "true" && status != "false")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter true or false only:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            status = Console.ReadLine();
            Console.ResetColor();
        }
        //d = (Driver.Driver)admin.listOfDrivers[driver_no];
        bool Status = System.Convert.ToBoolean(status);
        driver.updateAvailability(Status);
        admin.updateDriver(id, driver);
        Console.ResetColor();
    }
    public static dynamic TakeAdminChoice()
    {
        Console.WriteLine("1. Add Driver\n2. Remove Driver\n3. Update Driver\n4. Search Driver\n5. Exit as Admin\n\nPress 1 to 5 to select an option");

        int Choice = System.Convert.ToInt32(Console.ReadLine());
        while (Choice > 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter 1 to 3 only:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Choice = System.Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
        }
        return Choice;
    }
    public static dynamic EnterAge()
    {
        Console.WriteLine("Enter Age");
        Console.ForegroundColor = ConsoleColor.Green;
        string Age = Console.ReadLine();
        Console.ResetColor();
        bool isnumeric;
        int res = 0;
        isnumeric = int.TryParse(Age, out res);

        while (Age == "" || !isnumeric)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWrong Input…!\n\nEnter Age again:  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Age = Console.ReadLine();
            Console.ResetColor();
            isnumeric = int.TryParse(Age, out res);
        }
        int age = res;
        return age;
    }
    public static dynamic EnterGender(int x = 0)
    {
        Console.Write("Enter Gender ");
        Console.ForegroundColor = ConsoleColor.Green;
        string gender = Console.ReadLine();
        Console.ResetColor();
        if (x == 0)
        {
            while (gender != "Male" && gender != "Female")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nWrong Input…!\n\nEnter again Male or Female:  ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                gender = Console.ReadLine();
                Console.ResetColor();
            }
        }
        return gender;
    }
    public static dynamic EnterAddress()
    {
        Console.Write("Enter Address ");
        Console.ForegroundColor = ConsoleColor.Green;
        string address = Console.ReadLine();
        Console.ResetColor();
        return address;
    }
    public static dynamic TakelicensePlate()
    {
        Console.Write("Enter Vehicle License Plate ");
        Console.ForegroundColor = ConsoleColor.Green;
        dynamic license = Console.ReadLine();
        Console.ResetColor();
        return license;
    }
    public static dynamic TakevehicleModel()
    {
        Console.Write("Enter Vehicle Model ");
        Console.ForegroundColor = ConsoleColor.Green;
        dynamic model = Console.ReadLine();
        Console.ResetColor();
        return model;
    }
    public static dynamic TakeVehicleType(int x = 0)
    {
        Console.Write("Enter Vehicle Type car/rickshaw/bike ");
        Console.ForegroundColor = ConsoleColor.Green;
        dynamic type = Console.ReadLine();
        Console.ResetColor();
        if (x == 0)
        {
            while (type == "" || (type != "car" && type != "rickshaw" && type != "bike" && type != "Car" && type != "Rickshaw" && type != "Bike"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nWrong Input…!\n\nEnter type again car/rickshaw/bike:  ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                type = Console.ReadLine();
                Console.ResetColor();
            }
        }
        return type;
    }
    public static dynamic EnterAgeForUpdation()
    {
        int age = 0;
        Console.Write("Enter Age");
        Console.ForegroundColor = ConsoleColor.Green;
        string Age = Console.ReadLine();
        if (Age != "")
            age = System.Convert.ToInt32(Age);
        Console.ResetColor();
        return age;
    }

}
class display
{
    public static void ShowSearchResults(List<Driver.Driver> list)
    {
        foreach (dynamic d in list)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------\n\n");
            Console.WriteLine("Name\t\t\tAge\t\t\tGender\t\t\tV.Type\t\t\tV.Model\t\t\tV.License\n\n");
            Console.WriteLine($"{d.Myname}\t\t\t{d.MyAge}\t\t\t{d.MyGender}\t\t\t{d.Vehicle.MyType}\t\t\t{d.Vehicle.MyModel}\t\t\t{d.Vehicle.MyLicense}\n\n");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------\n\n");
        }
    }
    public static void ShowSearchResults()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Driver Not found !!!\n");
        Console.ResetColor();
    }
    public static dynamic showMenu()
    {
        Console.WriteLine("1. Book a ride\n2. Enter as driver\n3. Enter as admin\n\nPress 1 to 3 to select an option");
        int choice = System.Convert.ToInt32(Console.ReadLine());
        choice = TakeInput.TakeChoice(choice);
        return choice;
    }
    public static void showMain()
    {
        Console.WriteLine("------------------------------------------------------\n\t\tWelcome to MyRide\n------------------------------------------------------");
    }
}
class BookARide
{
    public static void BR(Admin.Admin admin)
    {
        double start_loc_1 = 0, start_loc_2 = 0, end_loc_1 = 0, end_loc_2 = 0;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\tBOOK A RIDE\n");
        Console.ResetColor();

        dynamic name = TakeInput.EnterName();

        dynamic phone = TakeInput.EnterPhone_no();

        TakeInput.enterLatitude_Longitude(start_loc_1, start_loc_2, end_loc_1, end_loc_2);

        dynamic type = TakeInput.EnterRideType();


        Console.WriteLine("\n---------Thank You----------\n");

        Ride.Ride r = new Ride.Ride();
        Passenger.Passenger p = new Passenger.Passenger(name, phone);
        r.assignPassenger(p);

        location.Location Start = new location.Location();
        Start.setLocation(start_loc_1, start_loc_2);

        location.Location End = new location.Location();
        End.setLocation(end_loc_1, end_loc_2);

        r.getLocations(Start, End);

        bool flag = r.assignDriver(admin, Start, p, r, type);
        if (flag)
        {
            TakeInput.PriceOfRide(r, type);
            dynamic ch = TakeInput.confirmRide();
            if (ch == "Y")
                TakeInput.RideConfirmed(r);
        }
        else
            TakeInput.RideCantBooked();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n---____---_____---_____---____----____----____---\n");
        Console.ResetColor();
    }
}
class EnterAsDriver
{
    public static void EAD(Admin.Admin admin)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\t\tENTER AS DRIVER\n");
        Console.ResetColor();

        dynamic id = TakeInput.TakeId();

        dynamic name = TakeInput.EnterName();

        bool flag = false;

        Driver.Driver driver = admin.searchDriver(id);
        if (name == driver.Myname)
            flag = true;
        if (flag)
        {
            dynamic a = TakeInput.EnterLatitude(name);

            dynamic b = TakeInput.EnterLongitude();

            dynamic ch = TakeInput.askFor3options();

            if (ch == 1)
            {
                TakeInput.changeAvailabilty(driver, admin, id);
            }
            else if (ch == 2)
            {
                driver.updateLocation();
                admin.updateDriver(id, driver);

            }
            else if (ch == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n---____---_____---_____---____----____----____---\n");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter Again Wrong Input !!!\n");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are not registered  !!!\n");
            Console.ResetColor();
        }
    }
}
class EnterAsAdmin
{
    public static void EAA(Admin.Admin admin)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\t\tENTER AS ADMIN\n");
        Console.ResetColor();

        dynamic Choice = TakeInput.TakeAdminChoice();
        if (Choice == 1)
        {
            dynamic id = TakeInput.TakeId();

            dynamic name = TakeInput.EnterName(1);

            dynamic age = TakeInput.EnterAgeForUpdation();

            dynamic gender = TakeInput.EnterGender(1);

            dynamic address = TakeInput.EnterAddress();

            dynamic type = TakeInput.TakeVehicleType(1);

            dynamic model = TakeInput.TakevehicleModel();

            dynamic license = TakeInput.TakelicensePlate();

            dynamic latitude = TakeInput.EnterLatitude(null);

            dynamic longitude = TakeInput.EnterLongitude();

            Vehicle.Vehicle v = new Vehicle.Vehicle(type, model, license);
            Driver.Driver driver = new Driver.Driver(name, age, gender, address, v, null, 0, latitude, longitude);

            admin.AddDriver(driver);
        }
        else if (Choice == 2)
        {
            Console.Write("You want to remove a Driver..");
            dynamic id = TakeInput.TakeId();

            admin.removeDriver(id);
        }
        else if (Choice == 3)
        {
            Console.Write("You want to update a driver..");

            dynamic id = TakeInput.TakeId();

            Driver.Driver driver = new Driver.Driver();
            driver = admin.searchDriver(id);

            if (driver.MyID > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------Driver with this ID exists-------------");
                Console.ResetColor();

                dynamic name = TakeInput.EnterName(1);

                dynamic age = TakeInput.EnterAgeForUpdation();

                dynamic gender = TakeInput.EnterGender(1);

                dynamic address = TakeInput.EnterAddress();

                dynamic type = TakeInput.TakeVehicleType(1);

                dynamic model = TakeInput.TakevehicleModel();

                dynamic license = TakeInput.TakelicensePlate();

                Vehicle.Vehicle v = new Vehicle.Vehicle(type, model, license);
                Driver.Driver driver2 = new Driver.Driver(name, age, gender, address, v, null, id);

                admin.updateDriver(driver.MyID, driver, driver2);
            }
        }
        else if (Choice == 4)
        {
            Console.Write("You want to search a Driver..");

            SearchDriver.SD(admin);
        }
        else if (Choice == 5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n---____---_____---_____---____----____----____---\n");
            Console.ResetColor();
        }
    }
}
class SearchDriver
{
    public static void SD(Admin.Admin admin)
    {
        String Choice;
        int age = 0;
        string name = "", gender = "", address = "", type = "", model = "", license = ""; double latitude = 0, longitude = 0;
        int choice;
        Console.WriteLine("\n1.Name\n2.Age\n3.Gender\n4.Address\n5.Type\n6.Model\n7.LicensePlate\n ");
        Console.Write("Enter Choice ");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Choice = Console.ReadLine();
        Console.ResetColor();

        choice = System.Convert.ToInt32(Choice);
        if (choice == 1)
            name = TakeInput.EnterName();
        else if (choice == 2)
            age = TakeInput.EnterAge();
        else if (choice == 3)
            gender = TakeInput.EnterGender();
        else if (choice == 4)
            address = TakeInput.EnterAddress();
        else if (choice == 5)
            type = TakeInput.TakeVehicleType();
        else if (choice == 6)
            model = TakeInput.TakevehicleModel();
        else if (choice == 7)
            license = TakeInput.TakelicensePlate();
        
        Vehicle.Vehicle v = new Vehicle.Vehicle(type, model, license);
        Driver.Driver driver2 = new Driver.Driver(name, age, gender, address, v, null);

        List<Driver.Driver> d = admin.GetAllDrivers(driver2);
        if (d.Count > 0)
            display.ShowSearchResults(d);
        else
            display.ShowSearchResults();
    }
}

namespace hw_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin.Admin admin = new Admin.Admin();
            display.showMain();
            do
            {
                dynamic choice = display.showMenu();
                if (choice == 1)
                {
                    BookARide.BR(admin);
                }
                else if (choice == 2)
                {
                    EnterAsDriver.EAD(admin);
                }
                else if (choice == 3)
                {
                    EnterAsAdmin.EAA(admin);
                }

            } while (true);
        }
    }
}
