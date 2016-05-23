using ExaminationSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace ExaminationSystem
{
    /// <summary>
    /// Testing_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Testing_Operator : System.Web.Services.WebService
    {

        DBHelper helper;

        public Testing_Operator()
        {
            helper = new DBHelper();
        }

        [WebMethod]
        public string Insert(string SID, string TestDate, string Flag, string StartTime, string EndTime)
        {
            string strFlag = "Error";
            Flags flags = new Flags();
            try {
                if ("".Equals(TestDate.Trim())|| Convert.ToInt32(Flag) < 0)
                {
                    strFlag = "Error";
                }
                else
                {
                    SqlParameter[] parameters = {
                        new SqlParameter("@SID",SqlDbType.Int),
                        new SqlParameter("@TestDate",SqlDbType.DateTime),
                        new SqlParameter("@Flag",SqlDbType.Int),
                        new SqlParameter("@StartTime", SqlDbType.VarChar,20),
                        new SqlParameter("@EndTime", SqlDbType.VarChar,20)
                    };
                    parameters[0].Value = SID;
                    parameters[1].Value = TestDate;
                    parameters[2].Value = Flag;
                    parameters[3].Value = StartTime;
                    parameters[4].Value = EndTime;

                    helper.RunProc("sp_Testing_Insert", parameters);

                    int iNewId = helper.GetNewID("tb_Testing");

                    flags.ID = iNewId;
                    strFlag = "OK";
                }
            } catch(Exception ex)
            {
                strFlag=ex.Message.ToString();
                //strFlag = "Error";
            }
            flags.Flag = strFlag;
            List<Flags> list = new List<Flags>();
            list.Add(flags);
            return GetToJSon(list);
        }

        //[WebMethod]
        public string Delete(string ID)
        {
            return "功能尚未实现";
        }

        [WebMethod]
        public string Update(int ID, string SID, string TestDate, string Flag,string StartTime,string EndTime)
        {
            string strFlag = "";
            Flags flags = new Flags();
            try
            {
                if ("".Equals(TestDate.Trim()) || Convert.ToInt32(Flag) < 0)
                {
                    strFlag = "Error";
                }
                else {
                    SqlParameter[] parameters = {
                        new SqlParameter("@ID",SqlDbType.Int),
                        new SqlParameter("@SID",SqlDbType.Int),
                        new SqlParameter("@TestDate",SqlDbType.DateTime),
                        new SqlParameter("@Flag",SqlDbType.Int),
                        new SqlParameter("@StartTime",SqlDbType.VarChar,20),
                        new SqlParameter("@EndTime",SqlDbType.VarChar,20)
                        };
                    parameters[0].Value = ID;
                    parameters[1].Value = SID;
                    parameters[2].Value = TestDate;
                    parameters[3].Value = Flag;
                    parameters[4].Value = StartTime;
                    parameters[5].Value = EndTime;

                    helper.RunProc("sp_Testing_Update", parameters);
                    flags.ID = ID;
                    strFlag = "OK";
                }
            }
            catch (Exception ex)
            {
                strFlag = ex.Message;
            }

            flags.Flag = strFlag;
            List<Flags> list = new List<Flags>();
            list.Add(flags);

            return GetToJSon(list);
        }

        [WebMethod]
        public string GetAllTest()
        {
            string strSql = "select * from tb_Testing";

            DataSet ds = helper.RunProcReturn(strSql, "tb_Testing");

            return GetToJSon(ds);
        }

        [WebMethod]
        public string GetAllTestForSID(string SID)
        {
            string strSql = "select * from tb_Testing where SID=@SID";
            SqlParameter[] parameters = {
                new SqlParameter("@SID",SqlDbType.Int)
            };
            parameters[0].Value = SID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Testing");
            
            return GetToJSon(ds);
        }

        [WebMethod]
        public string GetTestForID(string ID)
        {
            string strSql = "select * from tb_Testing where _id=@ID";
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Testing");

            return GetToJSon(ds);
        }

        private string GetToJSon(List<Flags> list)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private string GetToJSon(DataSet ds)
        {
            List<TTesting> list = GetTests(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TTesting> GetTests(DataSet ds)
        {
            List<TTesting> list = new List<TTesting>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TTesting tt = new TTesting();
                tt.ID = Convert.ToInt32(dr[0].ToString());
                tt.SID = Convert.ToInt32(dr[1].ToString());
                tt.TestDate =dr[2].ToString();
                tt.Flag = Convert.ToInt32(dr[3].ToString());
                tt.StartTime=dr[4].ToString();
                tt.EndTime = dr[5].ToString();

                list.Add(tt);
            }

            return list;
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
