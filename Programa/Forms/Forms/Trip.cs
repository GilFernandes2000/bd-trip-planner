using System;
using System.Collections;
using System.Text;

namespace TripPlanner{
    [Serializable()]
    class Trip{
        private int _id;
        private String _name;
        private int _price;
        private int _duration;
        private String _departure;
        private String _state;

        public String Trip_name{
            get {
                return _name;
            }
            set {
                if (String.IsNullOrEmpty(value)){
                    throw new Exception("Trip must have a name");
                    return;
                }
                _name = value;
            }
        }

        public int ID{
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }
        
        public int Price{
            get {
                return _price;
            }
            set {
                if (value < 0){
                    throw new Exception("Price cant be negative");
                    return;
                }
                _price = value;
            }
        }

        public int Duration{
            get {
                return _duration;
            }
            set {
                if (value < 0){
                    throw new Exception("Duration cant be negative");
                    return;
                }
                _duration = value;
            }
        }

        public String Departure{
            get {
                return _departure;
            }
            set {
                _departure = value;
            }
        }

        public String State{
            get {
                return _state;
            }
            set {
                _state = value;
            }
        }

        public override string ToString(){
            return "Trip: " + _name + "\nStarting: " + _departure + "\nCosting: " + _price;
        }
    }
}