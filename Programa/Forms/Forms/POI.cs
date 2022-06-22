using System;
using System.Collections;
using System.Text;

namespace TripPlanner{
    [Serializable()]
    class POI{
        private String _email;
        private int _rating;
        private String _name;
        private String _contact;
        private String _price;
        private String _address;

        public String Email{
            get {
                return _email;
            }
            set {
                if (!value.Contains("@")){
                    throw new Exception("Emails must have @");
                    return;
                }
                _email = value;
            }
        }

        public String POI_name{
            get {
                return _name;
            }
            set {
                if (String.IsNullOrEmpty(value)){
                    throw new Exception("Point of Interest must have a name");
                    return;
                }
                _name = value;
            }
        }

        public int Rating{
            get {
                return _rating;
            }
            set {
                if (value > 5 | value < 0){
                    throw new Exception("Rating must be between 0 and 5");
                    return;
                }
                _rating = value;
            }
        }

        public String Contact{
            get {
                return _contact;
            }
            set {
                _contact = value;
            }
        }

        public String Price{
            get {
                return _price;
            }
            set {
                if(!value.Equals("€") && !value.Equals("€€") && !value.Equals("€€€")){
                    throw new Exception("Price must only be € or €€ or €€€");
                    return;    
                }
                _price = value;
            }
        }

        public String Address{
            get {
                return _address;
            }
            set {
                _address = value;
            }
        }
    }
}