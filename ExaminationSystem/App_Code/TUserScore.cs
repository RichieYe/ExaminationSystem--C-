using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    public class TUserScore
    {
        private int _id;

        private int _tID;

        private double _score;

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

        public int TID
        {
            get
            {
                return _tID;
            }

            set
            {
                _tID = value;
            }
        }

        public double Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
            }
        }
    }
}
