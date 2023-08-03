using System;

namespace Vehicle
{
    public class Vehicle
    {
        public string Type, model, license_plate;
        public Vehicle(string t,string m,string l)
        {
            MyType = t; MyModel = m; MyLicense = l;
        }
        public Vehicle()
        {
            MyType = ""; MyModel = ""; MyLicense = "";
        }
        public string MyType
        {
            get
            {
                return Type;
            }
            set
            {
                Type = value;
            }
        }
        public string MyModel
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public string MyLicense
        {
            get
            {
                return license_plate;
            }
            set
            {
                license_plate = value;
            }
        }
    }
}
