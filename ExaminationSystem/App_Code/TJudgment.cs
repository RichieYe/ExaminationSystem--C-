using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    class TJudgment
    {
        private int _iD;

        private string _content;

        private string _answer;

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

        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }

        public string Answer
        {
            get
            {
                return _answer;
            }

            set
            {
                _answer = value;
            }
        }
    }
}
