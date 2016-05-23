using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    class QuestionFactory
    {
        
        public String GetAnswerForID(int iType, string ID)
        {
            IOperator qOperator = OperatorFactory(iType);
                    
            return qOperator.GetAnswerForID(ID); 
        }

        private IOperator OperatorFactory(int iType)
        {
            IOperator iOperator;
            switch (iType)
            {
                case 1:
                    iOperator=(IOperator)new Completion_Operator();
                    break;
                case 2:
                    iOperator=(IOperator)new Choice_Operator();
                    break;
                case 3:
                    iOperator=(IOperator)new MultiChoice_Operator();
                    break;
                case 4:
                    iOperator=(IOperator)new Judgment_Operator();
                    break;
                case 5:
                    iOperator=(IOperator)new Program_Operator();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return iOperator;
        }
    }
}
