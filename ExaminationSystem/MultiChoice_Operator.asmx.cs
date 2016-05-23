using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using ExaminationSystem.App_Code;
using System.Web.Script.Serialization;

namespace ExaminationSystem
{
    /// <summary>
    /// MultiChoice_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MultiChoice_Operator : System.Web.Services.WebService, IOperator
    {
        DBHelper helper;

        public MultiChoice_Operator()
        {
            helper = new DBHelper();
        }

        public string Delete(string ID)
        {
            //TODO:MultiChoice_Operator.Delete方法尚未实现该功能
            throw new NotImplementedException();
        }

        public DataSet GetAllTest(string ID)
        {
            string strSql = "select * from tb_MultiChoice";

            SqlParameter[] parameters = null;

            if (!"".Equals(ID.Trim()))
            {
                strSql = strSql + " where _id=@ID";
                parameters = new SqlParameter[]{
                    new SqlParameter("@ID",SqlDbType.Int)
                };
                parameters[0].Value = ID;
            }
            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_MultiChoice");

            return ds;
        }

        public string GetAnswerForID(string ID)
        {
            string strSql = "select Answer from tb_MultiChoice where _id=@ID";

            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_MultiChoice");

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }

            return "Error";
        }

        [WebMethod]
        public string GetTestForID(string ID)
        {
            DataSet ds = GetAllTest(ID);

            return GetToJSon(ds);
        }

        [WebMethod]
        public string GetTestToClient(int TID,int count)
        {
            DataSet ds = GetAllTest("");

            if (count > ds.Tables[0].Rows.Count)
            {
                return "[{\"ID\":0,\"Flag\":\"Error: 参数值超出试题表中的数量！\"}]";
            }

            List<int> lsNo = new List<int>();
            List<TMultiChoiceT> lsMultiChoice = new List<TMultiChoiceT>();
            Random rd;

            for (int i = 0; i < count; i++)
            {
                rd = new Random();
                int iNo = rd.Next(ds.Tables[0].Rows.Count+1);
                if (lsNo.Contains(iNo)||iNo==0)
                {
                    i--;
                    continue;
                }
                else
                {
                    TMultiChoiceT tm = new TMultiChoiceT();
                    try
                    {
                        tm.ID = Convert.ToInt32(ds.Tables[0].Rows[iNo][0].ToString());
                        tm.Content = ds.Tables[0].Rows[iNo][1].ToString();
                        tm.AnswerA = ds.Tables[0].Rows[iNo][2].ToString();
                        tm.AnswerB = ds.Tables[0].Rows[iNo][3].ToString();
                        tm.AnswerC = ds.Tables[0].Rows[iNo][4].ToString();
                        tm.AnswerD = ds.Tables[0].Rows[iNo][5].ToString();
                    }
                    catch (Exception ex)
                    {
                        tm.Content = "Error:" + ex.Message;
                    }

                    lsMultiChoice.Add(tm);
                    lsNo.Add(iNo);
                }
            }

            string strMsg = new UserTest_Operator().CreateTest(TID, 3, lsNo);

            if (!"OK".Equals(strMsg.Trim()))
            {
                return "[{\"ID\":0,\"Flag\":" + strMsg + "\"}]";
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(lsMultiChoice);
        }

        [WebMethod]
        public string Insert(string Content, string AnswerA, string AnswerB, string AnswerC, string AnswerD, string Answer)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Content",SqlDbType.VarChar,200),
                new SqlParameter("@AnswerA",SqlDbType.VarChar,100),
                new SqlParameter("@AnswerB",SqlDbType.VarChar,100),
                new SqlParameter("@AnswerC",SqlDbType.VarChar,100),
                new SqlParameter("@AnswerD",SqlDbType.VarChar,100),
                new SqlParameter("@Answer",SqlDbType.VarChar,100)
            };
            parameters[0].Value = Content;
            parameters[1].Value = AnswerA;
            parameters[2].Value = AnswerB;
            parameters[3].Value = AnswerC;
            parameters[4].Value = AnswerD;
            parameters[5].Value = Answer;

            return Insert(parameters);
        }

        public string Insert(SqlParameter[] parameters)
        {
            string strFlag = "";

            int iError = 0;

            List<Flags> list = new List<Flags>();
            Flags flag = new Flags();

            foreach (SqlParameter parameter in parameters)
            {
                if ("".Equals(parameter.Value.ToString().Trim()))
                {
                    iError++;
                }
            }

            if (iError > 0)
            {
                strFlag = "Error:参数值为空！";
            }
            else
            {
                try
                {
                    helper.RunProc("sp_MultiChoice_Insert", parameters);
                    strFlag = "OK";
                    flag.ID = helper.GetNewID("tb_MultiChoice");
                }
                catch (Exception ex)
                {
                    strFlag = "Error:" + ex.Message;
                }
            }

            flag.Flag = strFlag;

            list.Add(flag);

            return GetToJSon(list);
        }

        public string Update(SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        private string GetToJSon(List<Flags> list)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private string GetToJSon(DataSet ds)
        {
            List<TMultiChoice> list = GetMultiChoice(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TMultiChoice> GetMultiChoice(DataSet ds)
        {
            List<TMultiChoice> list = new List<TMultiChoice>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TMultiChoice tm = new TMultiChoice();
                tm.ID = Convert.ToInt32(dr[0].ToString());
                tm.AnswerA = dr[1].ToString();
                tm.AnswerB = dr[2].ToString();
                tm.AnswerC = dr[3].ToString();
                tm.AnswerD = dr[4].ToString();
                tm.Answer = dr[5].ToString();

                list.Add(tm);
            }

            return list;
        }

        public int GetAnswerIDForID(string ID)
        {
            throw new NotImplementedException();
        }
    }
}
