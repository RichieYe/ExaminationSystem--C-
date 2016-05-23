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
    /// Judgment_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Judgment_Operator : System.Web.Services.WebService,IOperator
    {
        DBHelper helper;

        public Judgment_Operator()
        {
            helper = new DBHelper();
        }

        public string Delete(string ID)
        {
            throw new NotImplementedException();
        }

        public DataSet GetAllTest(string ID)
        {
            string strSql = "select * from tb_Judgment";

            SqlParameter[] paramters = null;

            if (!"".Equals(ID.Trim()))
            {
                strSql = strSql + " where _id=@ID";
                paramters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int)
                };
                paramters[0].Value = ID;
            }

            DataSet ds = helper.RunProcReturn(strSql, paramters, "tb_Judgment");

            return ds;
        }

        public string GetAnswerForID(string ID)
        {
            string strSql = "select Answer from tb_Judgment where _id=@ID";

            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Judgment");

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
            List<TJudgmentT> lsJudgment = new List<TJudgmentT>();
            Random rd;

            for (int i = 0; i < count; i++)
            {
               rd= new Random();
                int iNo = rd.Next(ds.Tables[0].Rows.Count+1);
                if (lsNo.Contains(iNo))
                {
                    i--;
                    continue;
                }
                else
                {
                    TJudgmentT tj = new TJudgmentT();
                    try
                    {
                        tj.ID = Convert.ToInt32(ds.Tables[0].Rows[iNo][0].ToString());
                        tj.Content = ds.Tables[0].Rows[iNo][1].ToString();
                    }
                    catch (Exception ex)
                    {
                        tj.Content = "Error:" + ex.Message;
                    }

                    lsJudgment.Add(tj);
                    lsNo.Add(iNo);
                }
            }

            string strMsg = new UserTest_Operator().CreateTest(TID, 4, lsNo);

            if (!"OK".Equals(strMsg.Trim()))
            {
                return "[{\"ID\":0,\"Flag\":" + strMsg + "\"}]";
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(lsJudgment);
        }

        [WebMethod]
        public string Insert(string Content, string Answer)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Content",SqlDbType.VarChar,200),
                new SqlParameter("@Answer",SqlDbType.VarChar,10)
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
                    helper.RunProc("sp_Judgment_Insert", parameters);
                    flag.ID = helper.GetNewID("tb_Judgment");
                    strFlag = "OK";
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
            throw new NotImplementedException();
        }

        private string GetToJSon(List<Flags> list)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private string GetToJSon(DataSet ds)
        {
            List<TJudgment> list = GetJudgments(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TJudgment> GetJudgments(DataSet ds)
        {
            List<TJudgment> list = new List<TJudgment>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TJudgment tj = new TJudgment();
                tj.ID = Convert.ToInt32(dr[0].ToString());
                tj.Content = dr[1].ToString();
                tj.Answer = dr[2].ToString();

                list.Add(tj);
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
