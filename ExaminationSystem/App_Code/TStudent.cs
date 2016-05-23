using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    public class TStudent
    {
        private int _iD;

        private string _userName;

        private string _nO;

        private int _cID;

        private string _password;

        private string _gender;

        private string _phone;

        private string _address;

        public int ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }

        public string NO
        {
            get
            {
                return _nO;
            }

            set
            {
                _nO = value;
            }
        }

        public int CID
        {
            get
            {
                return _cID;
            }

            set
            {
                _cID = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

    }
}
