using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    public class TTesting
    {
        private int _iD;

        private int _sID;

        private string _testDate;

        private int _flag;

        private string _startTime;

        private string _endTime;

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

        public int SID
        {
            get
            {
                return _sID;
            }

            set
            {
                _sID = value;
            }
        }

        public string TestDate
        {
            get
            {
                return _testDate;
            }

            set
            {
                _testDate = value;
            }
        }

        public int Flag
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

        public string StartTime
        {
            get
            {
                return _startTime;
            }

            set
            {
                _startTime = value;
            }
        }

        public string EndTime
        {
            get
            {
                return _endTime;
            }

            set
            {
                _endTime = value;
            }
        }
    }
}
