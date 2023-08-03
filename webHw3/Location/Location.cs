using System;

namespace location
{
    public class Location
    {
        double latitude, longitude;
        public double Mylatitude
        {
            set
            {
                latitude = value;
            }
            get
            {
                return latitude;
            }
        }
        public double Mylongitude
        {
            set
            {
                longitude = value;
            }
            get
            {
                return longitude;
            }
        }

        public void setLocation(double Latitude, double Longitude)
        {
            Mylatitude = Latitude;
            Mylongitude = Longitude;
        }
    }
}
