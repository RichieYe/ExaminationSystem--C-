using ExaminationSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace ExaminationSystem
{
    /// <summary>
    /// Classes_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Classes_Operator : System.Web.Services.WebService
    {
        DBHelper helper;

        /*
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        */

        public Classes_Operator()
        {
            helper = new DBHelper();
        }

        //[WebMethod]
        public string Insert(string strClassName)
        {
            string strFlag = "";
            List<Flags> list = new List<Flags>();
            Flags flags = new Flags();
            if ("".Equals(strClassName.Trim()))
            {
                strFlag = "Error";
            }
            else
            {
                SqlParameter[] parameters = {
                new SqlParameter("@ClassName",SqlDbType.VarChar,20)
            };
                parameters[0].Value = strClassName;

                int iRows = helper.RunProc("sp_Classes_Insert", parameters);
                
                if (iRows < 0)
                {
                    strFlag = "Error";
                }
                else
                {
                    strFlag = "OK";
                }               
                flags.ID = helper.GetNewID("tb_Classes");
            }
            flags.Flag = strFlag;
            list.Add(flags);
            return GetToJSon(list);
        }

        //[WebMethod]
        public string DeleteForID(int ID)
        {
            SqlParameter[] parameters = { };

            return "";
        }

        [WebMethod]
        public string GetAllClasses()
        {
            string strSql = "select * from tb_Classes";

            DataSet ds = helper.RunProcReturn(strSql, "tb_Classes");
            return GetToJSon(ds);
        }

        [WebMethod]
        public string GetClassesForID(int id)
        {
            string strSql = "select * from tb_Classes where _id=@ID";
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };

            parameters[0].Value = id;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Classes");
            return GetToJSon(ds);
        }

        [WebMethod]
        public string GetClassesForName(string strClassName)
        {
            string strSql = "select * from tb_Classes where ClassName=@ClassName";
            SqlParameter[] parameters = {
                new SqlParameter("@ClassName",SqlDbType.VarChar,20)
            };
            parameters[0].Value = strClassName;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Classes");
            return GetToJSon(ds);
        }

        private string GetToJSon(List<Flags> list)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private string GetToJSon(DataSet ds)
        {
            List<TClasses> list = GetClassesForDataSet(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(list);
        }

        private List<TClasses> GetClassesForDataSet(DataSet ds)
        {
            List<TClasses> list = new List<TClasses>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TClasses tc = new TClasses();
                tc.Id = Convert.ToInt32(dr[0].ToString());
                tc.ClassName = dr[1].ToString();
                list.Add(tc);
            }

            return list;
        }
    }
}
