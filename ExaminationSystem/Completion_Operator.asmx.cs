using ExaminationSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace ExaminationSystem
{
    /// <summary>
    /// Completion_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Completion_Operator : System.Web.Services.WebService,IOperator
    {
        DBHelper helper;

        public Completion_Operator()
        {
            helper = new DBHelper();
        }

        public string Delete(string ID)
        {
            throw new NotImplementedException();
        }

        public DataSet GetAllTest(string ID)
        {
            string strSql = "select * from tb_Completion";

            SqlParameter[] paramters=null;

            if (!"".Equals(ID.Trim()))
            {
                strSql = strSql + " where _id=@ID";
                paramters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int)
                };
                paramters[0].Value = ID;
            }

            DataSet ds = helper.RunProcReturn(strSql,paramters, "tb_Completion");

            return ds;
        }

        public string GetAnswerForID(string ID)
        {
            string strSql = "select Answer from tb_Completion where _id=@ID";
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;
            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Completion");

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().Trim();
            }

            return "Error";
        }

        [WebMethod]
        public string GetTestForID(string ID)
        {
            string strSql = "select * from tb_Completion where _id=@ID";
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Completion");

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
            List<TCompletionT> lsCompletion = new List<TCompletionT>();
            Random rd;

            for (int i = 0; i < count; i++)
            {
                rd = new Random();
                int iNo = rd.Next(ds.Tables[0].Rows.Count+1);
                if (lsNo.Contains(iNo)||iNo ==0)
                {
                    i--;
                    continue;
                }
                else
                {
                    TCompletionT tc = new TCompletionT();
                    try
                    {
                        tc.ID = Convert.ToInt32(ds.Tables[0].Rows[iNo][0].ToString());
                        tc.Content = ds.Tables[0].Rows[iNo][1].ToString();
                    }
                    catch (Exception ex)
                    {
                        tc.Content = "Error:" + ex.Message;
                    }

                    lsCompletion.Add(tc);
                    lsNo.Add(iNo);
                }
            }

            string strMsg = new UserTest_Operator().CreateTest(TID, 1, lsNo);

            if (!"OK".Equals(strMsg))
            {
                return "[{\"ID\":0,\"Flag\":"+strMsg+"\"}]";
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(lsCompletion);

        }

        [WebMethod]
        public string Insert(string Content,string Answer)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Content",SqlDbType.VarChar,200),
                new SqlParameter("@Answer",SqlDbType.VarChar,100)
            };
            parameters[0].Value = Content;
            parameters[1].Value = Answer;

            return Insert(parameters);
        }

        public string Insert(SqlParameter[] parameters)
        {
            string strFlag = "";
            List<Flags> list = new List<Flags>();
            Flags flag = new Flags();
            int iError = 0;
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
                    helper.RunProc("sp_Completion_Insert", parameters);

                    flag.ID = helper.GetNewID("tb_Completion");
                    strFlag = "OK";
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
            List<TCompletion> list = GetCompletion(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TCompletion> GetCompletion(DataSet ds)
        {
            List<TCompletion> list = new List<TCompletion>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TCompletion tc = new TCompletion();
                tc.ID = Convert.ToInt32(dr[0].ToString());
                tc.Content = dr[1].ToString();
                tc.Answer = dr[2].ToString();

                list.Add(tc);
            }

            return list;
        }

        public int GetAnswerIDForID(string ID)
        {
            throw new NotImplementedException();
        }

        /*
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        */


    }
}
