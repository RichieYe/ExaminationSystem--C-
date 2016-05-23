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
    /// Choice_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Choice_Operator : System.Web.Services.WebService,IOperator
    {
        DBHelper helper;

        public Choice_Operator()
        {
            helper = new DBHelper();
        }

        public string Delete(string ID)
        {
            //TODO:Choice_Operator.Delete方法尚未实现该功能
            throw new NotImplementedException();
        }

        public DataSet GetAllTest(string ID)
        {
            string strSql = "select * from tb_Choice";

            SqlParameter[] parameters = null;

            if (!"".Equals(ID.Trim()))
            {
                strSql = strSql + " where _id=@ID";
                parameters=new SqlParameter[]{
                    new SqlParameter("@ID",SqlDbType.Int)
                };
                parameters[0].Value = ID;
            }
            DataSet ds = helper.RunProcReturn(strSql,parameters, "tb_Choice");

            return ds;
        }

        public string GetAnswerForID(string ID)
        {
            string strSql = "select Answer from tb_Choice where _id=@ID";
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Choice");

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
            List<TChoiceT> lsChoice = new List<TChoiceT>();
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
                    TChoiceT tc = new TChoiceT();
                    try
                    {
                        tc.ID = Convert.ToInt32(ds.Tables[0].Rows[iNo][0].ToString());
                        tc.Content = ds.Tables[0].Rows[iNo][1].ToString();
                        tc.AnswerA = ds.Tables[0].Rows[iNo][2].ToString();
                        tc.AnswerB = ds.Tables[0].Rows[iNo][3].ToString();
                        tc.AnswerC = ds.Tables[0].Rows[iNo][4].ToString();
                        tc.AnswerD = ds.Tables[0].Rows[iNo][5].ToString();
                    }
                    catch (Exception ex)
                    {
                        tc.Content = "Error:" + ex.Message;
                    }

                    lsChoice.Add(tc);
                    lsNo.Add(iNo);
                }
            }

            string strMsg = new UserTest_Operator().CreateTest(TID, 2, lsNo);

            if (!"OK".Equals(strMsg))
            {
                return "[{\"ID\":0,\"Flag\":" + strMsg + "\"}]";
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(lsChoice);
        }

        /*
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        */

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
                    helper.RunProc("sp_Choice_Insert", parameters);
                    strFlag = "OK";
                    flag.ID = helper.GetNewID("tb_Choice");
                }
                catch (Exception ex)
                {
                    strFlag = "Error:"+ex.Message;
                }
            }

            flag.Flag = strFlag;

            list.Add(flag);

            return GetToJSon(list);
        }

        public string Update(SqlParameter[] parameters)
        {
            //TODO:Choice_Operator.Update方法尚未实现该功能
            throw new NotImplementedException();
        }

        private string GetToJSon(List<Flags> list)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private string GetToJSon(DataSet ds)
        {
            List<TChoice> list = GetChoice(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TChoice> GetChoice(DataSet ds)
        {
            List<TChoice> list = new List<TChoice>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TChoice tc = new TChoice();
                
            }

            return list;
        }

        public int GetAnswerIDForID(string ID)
        {
            //TODO:Choice_Operator.GetAnswerIDForID方法尚未实现该功能
            throw new NotImplementedException();
        }
    }
}
