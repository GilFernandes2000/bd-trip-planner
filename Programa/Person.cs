using System;
using System.Collections.Generic;
using System.Text;

namespace TripPlanner
{
    [Serializable()]
    class Person{
        private String _sex;
        private String _PfName;
        private String _PmName;
        private String _PlName;
        private String _email;
        private String _CC;
        private String _PAddress;
    

        public String PersonCC{
            get {
                return _CC;
            }

            set {
                if (value.Equals(null) | value.Equals(" ")){
                    throw new Exception("Person's CC cannot be null");
                    return;
                }
                if (value.Length != 8){
                    throw new Exception("A Person's CC has only 8 digits");
                    return;
                }
                for (int i = 0; i < value.Length; i++){
                    if (!isDigit(value[i])){
                        throw new Exception("Peron's CC must only contain digits");
                        return;
                    }
                }
                _CC = value
            }
        }

        public String Sex{
            get {
                return _sex;
            }
            set {
                if (value.Equals("F") | value.Equals("M")){
                    _sex = value;
                }
                throw new Exception("Person's Sex can only be F or M");
                return;
            }
        }

        public String First_Name{
            get {
                return _PfName;
            }
            set {
                if (String.IsNullOrEmpty(value)){
                    throw new Exception("Person must have a first name");
                    return;
                }
                _PfName = value;
            }
        }

        public String Middle_Name{
            get {
                return _PmName;
            }
            set {
                if (String.IsNullOrEmpty(value)){
                    throw new Exception("Person must have a middle name");
                    return;
                }
                _PmName = value;
            }
        }

        public String Last_Name{
            get {
                return _PlName;
            }
            set {
                if (String.IsNullOrEmpty(value)){
                    throw new Exception("Person must have a last name");
                    return;
                }
                _PlName = value;
            }
        }

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

        public String Address{
            get {
                return _PAddress;
            }
            set {
                _PAddress = value;
            }
        }

        public override String ToString(){
            return _PfName + " " + _PmName + " " + _PlName + '\nCC: ' + _CC + '\nEmail: ' + _email; 
        }
    }
}