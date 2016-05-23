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
    /// Program_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Program_Operator : System.Web.Services.WebService,IOperator
    {
        DBHelper helper;

        public Program_Operator()
        {
            helper = new DBHelper();
        }

        public string Delete(string ID)
        {
            throw new NotImplementedException();
        }

        public DataSet GetAllTest(string ID)
        {
            string strSql = "select * from tb_Program";

            SqlParameter[] paramters = null;

            if (!"".Equals(ID.Trim()))
            {
                strSql = strSql + " where _id=@ID";
                paramters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int)
                };
                paramters[0].Value = ID;
            }

            DataSet ds = helper.RunProcReturn(strSql, paramters, "tb_Program");

            return ds;
        }

        public string GetAnswerForID(string ID)
        {
            string strSql = "select Answer from tb_Program where _id=@ID";

            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Program");

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }

            return "Error";
        }

        public string GetTestForID(string ID)
        {
            DataSet ds = GetAllTest(ID);

            return GetToJSon(ds);
        }

        public string GetTestToClient(int TID,int count)
        {
            DataSet ds = GetAllTest("");

            if (count > ds.Tables[0].Rows.Count)
            {
                return "[{\"ID\":0,\"Flag\":\"Error: 参数值超出试题表中的数量！\"}]";
            }

            List<int> lsNo = new List<int>();
            List<TProgramT> lsProgram = new List<TProgramT>();
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
                    TProgramT tp = new TProgramT();
                    try
                    {
                        tp.ID = Convert.ToInt32(ds.Tables[0].Rows[iNo][0].ToString());
                        tp.Content = ds.Tables[0].Rows[iNo][1].ToString();
                    }
                    catch (Exception ex)
                    {
                        tp.Content = "Error:" + ex.Message;
                    }

                    lsProgram.Add(tp);
                    lsNo.Add(iNo);
                }
            }

            string strMsg = new UserTest_Operator().CreateTest(TID, 5, lsNo);

            if (!"OK".Equals(strMsg.Trim()))
            {
                return "[{\"ID\":0,\"Flag\":\"Error:"+strMsg+"\"}]";
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(lsProgram);
        }

        [WebMethod]
        public string Insert(string Content, string Answer)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Content",SqlDbType.VarChar,200),
                new SqlParameter("@Answer",SqlDbType.VarChar,200)
            };
            parameters[0].Value = Content;
            parameters[1].Value = Answer;

            return Insert(parameters);
        }

        public string Insert(SqlParameter[] parameters)
        {
            string strFlag = "";
            List<Flags> list = new List<Flags>();
            int iError = 0;
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
                strFlag = "Error:参数值不能为空！";
            }
            else
            {
                try
                {
                    helper.RunProc("sp_Program_Insert", parameters);

                    flag.ID = helper.GetNewID("tb_Program");
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
            List<TProgram> list = GetPrograms(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TProgram> GetPrograms(DataSet ds)
        {
            List<TProgram> list = new List<TProgram>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TProgram tp = new TProgram();
                tp.ID = Convert.ToInt32(dr[0].ToString());
                tp.Content = dr[1].ToString();
                tp.Answer = dr[2].ToString();

                list.Add(tp);
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
