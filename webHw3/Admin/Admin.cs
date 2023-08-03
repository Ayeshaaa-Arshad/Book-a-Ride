using System;
using System.Collections.Generic;
using Driver;
using Vehicle;
using Microsoft.Data.SqlClient;
using System.Runtime.Intrinsics.X86;
using Microsoft.Data.SqlClient;

namespace Admin
{
    public class Admin
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Rider;Integrated Security=True";
        public void AddDriver(Driver.Driver driver)
        {
            string query1 = $"INSERT INTO dbo.Vehicle (vehicle_id, vehicle_type, vehicle_model) VALUES ('{driver.Vehicle.MyLicense}','{driver.Vehicle.MyType}', '{driver.Vehicle.MyModel}')";
            string query2 = $"INSERT INTO dbo.Drivers (id,name, age, gender, address, phone_no, latitude, longitude, vehicle_id, availability) VALUES ({driver.MyID},'{driver.Myname}', {driver.MyAge}, '{driver.MyGender}', '{driver.MyAddress}', '{driver.MyPhone}', {driver.curr_location.Mylatitude}, {driver.curr_location.Mylongitude}, '{driver.Vehicle.MyLicense}', {(driver.availability ? 1 : 0)})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Transaction = transaction;
                    int rowsAffected1 = command1.ExecuteNonQuery();

                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Transaction = transaction;
                    int rowsAffected2 = command2.ExecuteNonQuery();

                    if (rowsAffected1 > 0 && rowsAffected2 > 0)
                    {
                        transaction.Commit();
                        Console.WriteLine("Driver and Vehicle added successfully!\n");
                    }
                    else
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error adding driver and vehicle!\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding driver and vehicle: " + ex.Message + "\n");
                    transaction.Rollback();
                }
            }
        }
        public void removeDriver(int id)
        {
            string query = $"delete from dbo.vehicle where vehicle_id=(select vehicle_id from dbo.drivers where ID={id})";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                    Console.WriteLine("Removed Successfully\n");
                else
                    Console.WriteLine("Not found\n");
            }
        }
        public Driver.Driver searchDriver(int id)
        {
            string query = $"SELECT * FROM dbo.drivers d JOIN dbo.vehicle v ON d.vehicle_id = v.vehicle_id WHERE d.ID='{id}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int Id = (int)reader["ID"];
                    string name = (string)reader["name"];
                    int age = (int)reader["age"];
                    string gender = (string)reader["gender"];
                    string address = (string)reader["address"];
                    string phone_no = (string)reader["phone_no"];
                    dynamic latitude = (double)reader["latitude"];
                    dynamic longitude = (double)reader["longitude"];
                    string vehicleID = (string)reader["vehicle_id"];
                    bool availability = (bool)reader["availability"];
                    string model = (string)reader["vehicle_model"];
                    string type = (string)reader["vehicle_type"];

                    Vehicle.Vehicle v = new Vehicle.Vehicle(type, model, vehicleID);
                    Driver.Driver driver = new Driver.Driver(name, age, gender, address, v, null, Id, latitude, longitude);
                    reader.Close();
                    connection.Close();
                    return driver;
                }
                else
                {
                    Console.WriteLine($"No driver with ID {id} found.\n");
                    reader.Close();
                    connection.Close();
                    Driver.Driver d = new Driver.Driver();
                    return d;
                }
            }
        }
        public List<Driver.Driver> GetAllDrivers(Driver.Driver d)
        {
            List<Driver.Driver> drivers = new List<Driver.Driver>();
            string query = @"SELECT * FROM dbo.drivers d, dbo.vehicle v WHERE v.vehicle_id = d.vehicle_id";

            if (d.Myname != null)
                query = $"SELECT * FROM dbo.drivers dri JOIN dbo.vehicle v ON v.vehicle_id = dri.vehicle_id WHERE dri.name = '{d.Myname}'";
            if (d.MyAge != 0)
                query = $"SELECT * FROM dbo.drivers dri JOIN dbo.vehicle v ON v.vehicle_id = dri.vehicle_id WHERE dri.age = '{d.MyAge}'";
            if (d.MyGender != "")
                query = $"SELECT * FROM dbo.drivers dri JOIN dbo.vehicle v ON v.vehicle_id = dri.vehicle_id WHERE dri.gender = '{d.MyGender}'";
            if (d.MyAddress != "")
                query = $"SELECT * FROM dbo.drivers dri JOIN dbo.vehicle v ON v.vehicle_id = dri.vehicle_id WHERE dri.address = '{d.MyAddress}'";
            if (d.Vehicle.Type != "")
                query = $"SELECT * FROM dbo.drivers dri JOIN dbo.vehicle v ON v.vehicle_id = dri.vehicle_id WHERE v.vehicle_type = '{d.Vehicle.MyType}'";
            if (d.Vehicle.MyModel != "")
                query = $"SELECT * FROM dbo.drivers dri JOIN dbo.vehicle v ON v.vehicle_id = dri.vehicle_id WHERE v.vehicle_model = '{d.Vehicle.MyModel}'";
            if (d.Vehicle.MyLicense != "")
                query = $"SELECT * FROM dbo.drivers dri JOIN dbo.vehicle v ON v.vehicle_id = dri.vehicle_id WHERE v.Vehicle_id = '{d.Vehicle.MyLicense}'";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string name = (string)reader["name"];
                    int age = (int)reader["age"];
                    string gender = (string)reader["gender"];
                    string address = (string)reader["address"];
                    string phone_no = (string)reader["phone_no"];
                    double latitude = (double)reader["latitude"];
                    double longitude = (double)reader["longitude"];
                    string vehicleID = (string)reader["vehicle_id"];
                    bool availability = (bool)reader["availability"];
                    string model = (string)reader["vehicle_model"];
                    string type = (string)reader["vehicle_type"];

                    Vehicle.Vehicle v = new Vehicle.Vehicle(type, model, vehicleID);
                    Driver.Driver driver = new Driver.Driver(name, age, gender, address, v, phone_no, id, latitude, longitude);
                    drivers.Add(driver);
                }

                reader.Close();
                connection.Close();
            }

            return drivers;
        }
        public void updateDriver(int id, Driver.Driver d2, Driver.Driver d)
        {
            if (d.Myname != "")
                d2.Myname = d.Myname;
            if (d.MyAge != 0)
                d2.MyAge = d.MyAge;
            if (d.MyGender != "")
                d2.MyGender = d.MyGender;
            if (d.MyAddress != "")
                d2.MyAddress = d.MyAddress;
            if (d.Vehicle.Type != "")
                d2.Vehicle.MyType = d.Vehicle.MyType;
            if (d.Vehicle.MyModel != "")
                d2.Vehicle.MyModel = d.Vehicle.MyModel;
            if (d.Vehicle.MyLicense != "")
                d2.Vehicle.MyLicense = d.Vehicle.MyLicense;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Update vehicle information
                        string vehicleQuery = $"UPDATE vehicle SET vehicle_type='{d2.Vehicle.MyType}', vehicle_model='{d2.Vehicle.MyModel}' WHERE vehicle_id='{d2.Vehicle.MyLicense}'";
                        SqlCommand vehicleCommand = new SqlCommand(vehicleQuery, connection, transaction);
                        int vehicleRowsAffected = vehicleCommand.ExecuteNonQuery();

                        if (vehicleRowsAffected == 0)
                        {
                            // If no rows were affected, it means the vehicle_id doesn't exist in the vehicle table
                            throw new Exception("Vehicle ID not found in the database.");
                        }

                        // Update driver information
                        string driverQuery = $"UPDATE drivers SET name='{d2.Myname}', age={d2.MyAge}, gender='{d2.MyGender}', address='{d2.MyAddress}', phone_no='{d2.MyPhone}', vehicle_id='{d2.Vehicle.MyLicense}' WHERE id={id}";
                        SqlCommand driverCommand = new SqlCommand(driverQuery, connection, transaction);
                        int driverRowsAffected = driverCommand.ExecuteNonQuery();

                        if (driverRowsAffected > 0)
                        {
                            transaction.Commit();
                            Console.WriteLine("Driver and vehicle information updated successfully!\n");
                        }
                        else
                        {
                            Console.WriteLine("Error updating driver and vehicle information!");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error updating driver and vehicle information: {ex.Message}");
                    }
                }

                connection.Close();
            }

        }
        public void updateDriver(int id, Driver.Driver d2)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Update vehicle information
                        string vehicleQuery = $"UPDATE dbo.vehicle SET vehicle_type='{d2.Vehicle.MyType}', vehicle_model='{d2.Vehicle.MyModel}' WHERE vehicle_id='{d2.Vehicle.MyLicense}'";
                        SqlCommand vehicleCommand = new SqlCommand(vehicleQuery, connection, transaction);
                        int vehicleRowsAffected = vehicleCommand.ExecuteNonQuery();

                        if (vehicleRowsAffected == 0)
                        {
                            // If no rows were affected, it means the vehicle_id doesn't exist in the vehicle table
                            throw new Exception("Vehicle ID not found in the database.");
                        }

                        // Update driver information
                        string driverQuery = $"UPDATE dbo.drivers SET name='{d2.Myname}', age={d2.MyAge}, gender='{d2.MyGender}', address='{d2.MyAddress}', phone_no='{d2.MyPhone}', vehicle_id='{d2.Vehicle.MyLicense}',latitude={d2.curr_location.Mylatitude},longitude={d2.curr_location.Mylongitude},availability={(d2.MyAvailabilty ? 1 : 0)} WHERE id={id}";
                        SqlCommand driverCommand = new SqlCommand(driverQuery, connection, transaction);
                        int driverRowsAffected = driverCommand.ExecuteNonQuery();

                        if (driverRowsAffected > 0)
                        {
                            transaction.Commit();
                            Console.WriteLine("Driver and vehicle information updated successfully!\n");
                        }
                        else
                        {
                            Console.WriteLine("Error updating driver and vehicle information!");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error updating driver and vehicle information: {ex.Message}");
                    }
                }

                connection.Close();
            }

        }
    }
}


