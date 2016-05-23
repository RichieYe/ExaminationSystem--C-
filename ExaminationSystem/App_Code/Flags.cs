using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    public class Flags
    {
        private int _id;

        private string _flag;

        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Flag
        {
            get
            {
                return _flag;
            }

            set
            {
                _flag = value;
            }
        }
    }
}
