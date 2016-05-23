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
    /// UserScore_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class UserScore_Operator : System.Web.Services.WebService
    {
        DBHelper helper;

        public UserScore_Operator()
        {
            helper = new DBHelper();
        }

        public int Insert(int TID, double Score)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@TID",SqlDbType.Int),
                new SqlParameter("@Score",SqlDbType.Float)
            };
            parameters[0].Value = TID;
            parameters[1].Value = Score;


            try
            {
                helper.RunProc("sp_UserScore_Insert", parameters);

                return 1;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return -1;
            }
            
        }

        public int Delete(int ID)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;

            try
            {
                helper.RunProc("sp_UserScore_Delete", parameters);
                return 1;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return -1;
            }
        }

        public int Update(int ID, int TID, double Score)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int),
                new SqlParameter("@TID",SqlDbType.Int),
                new SqlParameter("@Score",SqlDbType.Float)
            };
            parameters[0].Value = ID;
            parameters[1].Value = TID;
            parameters[2].Value = Score;

            try
            {
                helper.RunProc("sp_UserScore_Update", parameters);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        [WebMethod]
        public string GetUserScoreForTID(string TID)
        {
            string strSql = "select * from tb_UserScore where TID=@TID";
            SqlParameter[] parameters = {
                new SqlParameter("@TID",SqlDbType.Int)
            };
            parameters[0].Value = TID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_UserScore");

            return GetToJSon(ds);
        }

        [WebMethod]
        public string GetUserScoreForID(string ID)
        {
            string strSql = "select * from tb_UserScore where _id=@ID";
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = ID;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_UserScore");

            return GetToJSon(ds);
        }

        private string GetToJSon(DataSet ds)
        {
            List<TUserScore> list = GetUserScores(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TUserScore> GetUserScores(DataSet ds)
        {
            List<TUserScore> list = new List<TUserScore>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TUserScore tu = new TUserScore();
                tu.ID = Convert.ToInt32(dr[0].ToString());
                tu.TID = Convert.ToInt32(dr[1].ToString());
                tu.Score = Convert.ToDouble(dr[2].ToString());

                list.Add(tu);
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
