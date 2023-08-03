using System;

namespace Passenger
{
    public class Passenger
    {
        public Passenger(string name, string Phne_no)
        {
            Myname = name;
            MyPhone_no = Phne_no;
        }
        string name, phone_no;
        public string Myname
        {
            get
            {
                return name;
            }
            set
            {
                if (value != " ")
                    name = value;
                else
                    throw new Exception();
            }
        }

        public string MyPhone_no
        {
            get
            {
                return phone_no;
            }
            set
            {
                if (value != " ")
                    phone_no = value;
                else
                    throw new Exception();
            }

        }
    }
}
