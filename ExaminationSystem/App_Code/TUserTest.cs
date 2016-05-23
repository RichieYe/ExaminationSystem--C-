using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    public class TUserTest
    {
        private int _iD;

        private int _tID;

        private int _type;

        private int _question;

        private string uAnswer;

        private int _tAnswer;

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

        public int Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public int Question
        {
            get
            {
                return _question;
            }

            set
            {
                _question = value;
            }
        }

        public string UAnswer
        {
            get
            {
                return uAnswer;
            }

            set
            {
                uAnswer = value;
            }
        }

        public int TAnswer
        {
            get
            {
                return _tAnswer;
            }

            set
            {
                _tAnswer = value;
            }
        }
    }
}
