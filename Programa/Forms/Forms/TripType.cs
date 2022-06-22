using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner
{
    [Serializable()]
    class TripType
    {
        private int _id;
        private String _type;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
