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
    /// User_Operator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ExaminationSystem.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class User_Operator : System.Web.Services.WebService
    {
        DBHelper helper;

        public User_Operator()
        {
            helper = new DBHelper();
        }

        [WebMethod]
        public string Insert(string UserName, string No, string CId, string Password, string Gender, string Phone, string Address)
        {
            string strFlag = "";
            Flags flag = new Flags();
            List<Flags> list = new List<Flags>();

            if ("".Equals(UserName.Trim()) || "".Equals(No.Trim()) || "".Equals(Password.Trim()) || "".Equals(Gender.Trim()))
            {
                strFlag = "Error";
            }
            else
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@UserName",SqlDbType.VarChar,20),
                    new SqlParameter("@No",SqlDbType.VarChar,20),
                    new SqlParameter("@CId",SqlDbType.Int),
                    new SqlParameter("@Password",SqlDbType.VarChar,20),
                    new SqlParameter("@Gender",SqlDbType.VarChar,2),
                    new SqlParameter("@Phone",SqlDbType.VarChar,12),
                    new SqlParameter("@Address",SqlDbType.VarChar,50)
                };

                parameters[0].Value = UserName;
                parameters[1].Value = No;
                parameters[2].Value = CId;
                parameters[3].Value = Password;
                parameters[4].Value = Gender;
                parameters[5].Value = Phone;
                parameters[6].Value = Address;

                try
                {
                    helper.RunProc("sp_Student_Insert", parameters);
                    strFlag = "OK";
                    flag.ID = helper.GetNewID("tb_Student");
                }
                catch (Exception ex)
                {
                    //strFlag=ex.ToString();
                    strFlag = "Error";
                }       
            }
            flag.Flag = strFlag;
            list.Add(flag);

            return GetToJSon(list);
        }

        //[WebMethod]
        public string DeleteForID(int id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = id;

            int iRows = helper.RunProc("sp_Student_Delete", parameters);
            Flags flag = new Flags();
            if (iRows < 0)
            {
                flag.Flag = "Error";
            }
            else
            {
                flag.Flag = "OK";
                flag.ID = id;
            }
            List<Flags> list = new List<Flags>();
            list.Add(flag);

            return GetToJSon(list);
        }

        [WebMethod]
        public string Update(int ID, string UserName, string No, int CId, string Password, string Gender, string Phone, string Address)
        {
            string strFlag = "";
            Flags flag = new Flags();
            List<Flags> list = new List<Flags>();

            if ("".Equals(UserName.Trim()) || "".Equals(No.Trim()) || "".Equals(Password.Trim()) || "".Equals(Gender.Trim()))
            {
                strFlag = "Error";
            }
            else
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@ID",SqlDbType.Int),
                    new SqlParameter("@UserName",SqlDbType.VarChar,20),
                    new SqlParameter("@No",SqlDbType.VarChar,20),
                    new SqlParameter("@CId",SqlDbType.Int),
                    new SqlParameter("@Password",SqlDbType.VarChar,20),
                    new SqlParameter("@Gender",SqlDbType.VarChar,2),
                    new SqlParameter("@Phone",SqlDbType.VarChar,12),
                    new SqlParameter("@Address",SqlDbType.VarChar,50)
                };

                parameters[0].Value = ID;
                parameters[1].Value = UserName;
                parameters[2].Value = No;
                parameters[3].Value = CId;
                parameters[4].Value = Password;
                parameters[5].Value = Gender;
                parameters[6].Value = Phone;
                parameters[7].Value = Address;

                int iRows = helper.RunProc("sp_Student_Update", parameters);
                if (iRows < 0)
                {
                    strFlag = "Error";
                }
                else
                {
                    strFlag = "OK";
                    flag.ID = ID;
                }
            }
            flag.Flag = strFlag;
            list.Add(flag);

            return GetToJSon(list);
        }

        [WebMethod]
        public string GetAllStudents()
        {
            string strSql = "select * from tb_Student";

            DataSet ds = helper.RunProcReturn(strSql, "tb_Student");
            
            return GetToJSon(ds);
        }

        [WebMethod]
        public string GetStudentForID(int id)
        {
            string strSql = "select * from tb_Student where _id=@ID";
            SqlParameter[] parameters = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            parameters[0].Value = id;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Student");

            return GetToJSon(ds);
        }

        [WebMethod]
        public string GetStudentForName(string UserName)
        {
            string strSql = "select * from tb_Student where UserName=@UserName";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName",SqlDbType.VarChar,20)
            };
            parameters[0].Value = UserName;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Student");

            return GetToJSon(ds);
        }

        [WebMethod]
        public string Login(string UserName,string No,int CId,string Password)
        {
            string strSql = "select * from tb_Student where UserName=@UserName and No=@No and CId=@CID and password=@Password";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName",SqlDbType.VarChar,20),
                new SqlParameter("@No",SqlDbType.VarChar,20),
                new SqlParameter("@CId",SqlDbType.Int),
                new SqlParameter("@Password",SqlDbType.VarChar,20)
            };
            parameters[0].Value = UserName;
            parameters[1].Value = No;
            parameters[2].Value = CId;
            parameters[3].Value = Password;

            DataSet ds = helper.RunProcReturn(strSql, parameters, "tb_Student");
            Flags flag = new Flags();
            if (ds.Tables[0].Rows.Count == 0)
            {
                flag.Flag = "Error";
            }
            else
            {
                flag.Flag = "OK";
                flag.ID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            List<Flags> list = new List<Flags>();
            list.Add(flag);

            return GetToJSon(list);
        }

        private string GetToJSon(List<Flags> list)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private string GetToJSon(DataSet ds)
        {
            List<TStudent> list = GetStudents(ds);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(list);
        }

        private List<TStudent> GetStudents(DataSet ds)
        {
            List<TStudent> list = new List<TStudent>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TStudent ts = new TStudent();
                ts.ID = Convert.ToInt32(dr[0].ToString());
                ts.UserName = dr[1].ToString();
                ts.NO = dr[2].ToString();
                ts.CID = Convert.ToInt32(dr[3].ToString());
                ts.Password = dr[4].ToString();
                ts.Gender = dr[5].ToString();
                ts.Phone = dr[6].ToString();
                ts.Address = dr[7].ToString();
                list.Add(ts);                
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
