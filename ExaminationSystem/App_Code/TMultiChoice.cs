﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    class TMultiChoice
    {
        private int _iD;

        private string _answerA;

        private string _answerB;

        private string _answerC;

        private string _answerD;

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

        public string AnswerA
        {
            get
            {
                return _answerA;
            }

            set
            {
                _answerA = value;
            }
        }

        public string AnswerB
        {
            get
            {
                return _answerB;
            }

            set
            {
                _answerB = value;
            }
        }

        public string AnswerC
        {
            get
            {
                return _answerC;
            }

            set
            {
                _answerC = value;
            }
        }

        public string AnswerD
        {
            get
            {
                return _answerD;
            }

            set
            {
                _answerD = value;
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
