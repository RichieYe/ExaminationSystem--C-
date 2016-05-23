using ExaminationSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace ExaminationSystem
{
    /// <summary>
    /// UserTest_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class UserTest_Operator : System.Web.Services.WebService
    {
        DBHelper helper;

        public UserTest_Operator()
        {
            helper = new DBHelper();
        }

        public string CreateTest(int TID, int iType, List<int> lsQuestion)
        {
            try
            {
                for (int i = 0; i < lsQuestion.Count; i++)
                {
                    SqlParameter[] parameters = {
                            new SqlParameter("@TID",SqlDbType.Int),
                            new SqlParameter("@Type",SqlDbType.Int),
                            new SqlParameter("@Question",SqlDbType.Int),
                            new SqlParameter("@UAnswer",SqlDbType.VarChar,200),
                            new SqlParameter("@Flag",SqlDbType.Int)
                };
                    parameters[0].Value = TID;
                    parameters[1].Value = iType;
                    parameters[2].Value = lsQuestion[i];
                    parameters[3].Value = "";
                    parameters[4].Value = 0;

                    helper.RunProc("sp_UserTest_Insert", parameters);
                }
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }

            return "OK";
        }

        [WebMethod]
        public string GetUserTestForTID(int TID)
        {
            string strSql = "select * from tb_UserTest where TID=@TID";
            SqlParameter[] parameters = {
                new SqlParameter("@TID",SqlDbType.Int)
            };
            parameters[0].Value = TID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_UserTest");

            return GetToJSon(ds);
        }

        [WebMethod]
        public string CommitTests(string strTestJson)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            List<TUserTest> list = js.Deserialize<List<TUserTest>>(strTestJson);

            string strMsg = "";

            try
            {
                foreach (TUserTest ts in list)
                {
                    SqlParameter[] parameters = {
                        new SqlParameter("@TID",SqlDbType.Int),
                        new SqlParameter("@Type",SqlDbType.Int),
                        new SqlParameter("@Question",SqlDbType.Int),
                        new SqlParameter("@UAnswer",SqlDbType.VarChar,200)
                    };
                    strMsg = ts.TID+"";
                    parameters[0].Value = ts.TID;
                    parameters[1].Value = ts.Type;
                    parameters[2].Value = ts.Question;
                    parameters[3].Value = ts.UAnswer;

                    helper.RunProc("sp_UserTest_UpdateUAnswer", parameters);
                }

                strMsg = "OK";

            }
            catch (Exception ex)
            {
                strMsg = "Error:"+ex.Message;
            }

            List<Flags> list1 = new List<Flags>();
            Flags flag = new Flags();
            flag.Flag = strMsg;

            list1.Add(flag);

            return GetToJSon(list1);
        }

        private string GetToJSon(List<Flags> list)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private string GetToJSon(DataSet ds)
        {
            List<TUserTest> list = GetTests(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TUserTest> GetTests(DataSet ds)
        {
            List<TUserTest> list = new List<TUserTest>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TUserTest tu = new TUserTest();
                tu.ID = Convert.ToInt32(dr[0].ToString());
                tu.TID = Convert.ToInt32(dr[1].ToString());
                tu.Type = Convert.ToInt32(dr[2].ToString());
                tu.Question = Convert.ToInt32(dr[3].ToString());
                tu.UAnswer = dr[4].ToString();

                list.Add(tu);
            }

            return list;
        }
    }
}
