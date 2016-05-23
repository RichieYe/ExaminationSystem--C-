using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    public interface IOperator
    {
        string Insert(SqlParameter[] parameters);

        string Delete(string ID);

        string Update(SqlParameter[] parameters);

        DataSet GetAllTest(string ID);

        string GetTestForID(string ID);

        string GetTestToClient(int TID,int count);

        string GetAnswerForID(string ID);

        int GetAnswerIDForID(string ID);

    }
}
