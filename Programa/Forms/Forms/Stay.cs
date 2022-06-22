using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner
{
    [Serializable()]
    class Stay
    {
        private String _email;
        private int _rating;
        private String _name;
        private String _contact;
        private String _address;
        
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        public String Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
