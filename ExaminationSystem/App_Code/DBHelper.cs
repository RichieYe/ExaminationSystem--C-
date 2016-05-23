using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ExaminationSystem.App_Code
{
    public class DBHelper
    {
        SqlConnection conn;

        public void Open()
        {
            if (conn == null)
            {
                conn = new SqlConnection("Data Source=(Local);DataBase=db_Examination;Uid=sa;pwd=juest2004");
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void Close()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public SqlParameter MakeInParam(string strParam, SqlDbType DbType, int Size, Object Value)
        {
            return MakeParam(strParam, DbType, Size, ParameterDirection.Input, Value);
        }

        private SqlParameter MakeParam(string strParam, SqlDbType DbType, int Size, ParameterDirection Direction, Object Value)
        {
            SqlParameter param;

            if (Size > 0)
            {
                param = new SqlParameter(strParam, DbType, Size);
            }
            else
            {
                param = new SqlParameter(strParam, DbType);
            }

            param.Direction = Direction;

            if (!(Direction == ParameterDirection.Output && Value != null))
            {
                param.Value = Value;
            }

            return param;
        }

        public int RunProc(String strProcName, SqlParameter[] parameters)
        {
            SqlCommand cmd = CreateCommand(strProcName, parameters);

            cmd.ExecuteNonQuery();

            this.Close();

            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        public int RunProc(String strProcName)
        {
            this.Open();

            SqlCommand cmd = new SqlCommand(strProcName, conn);

            int iRows = cmd.ExecuteNonQuery();

            this.Close();

            return iRows;
        }

        public DataSet RunProcReturn(String strProcName, SqlParameter[] parameters, string tbName)
        {
            SqlDataAdapter adapter = CreateAdapter(strProcName, parameters);

            DataSet ds = new DataSet();

            adapter.Fill(ds, tbName);

            this.Close();

            return ds;
        }

        public DataSet RunProcReturn(string strProcName, string tbName)
        {
            this.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strProcName, conn);

            adapter.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            adapter.Fill(ds, tbName);

            this.Close();

            return ds;
        }

        private SqlDataAdapter CreateAdapter(string strProcName, SqlParameter[] parameters)
        {
            this.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(strProcName, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.Add(parameter);
                }
            }

            adapter.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));

            return adapter;
        }

        private SqlCommand CreateCommand(string strProcName, SqlParameter[] parameters)
        {
            this.Open();

            SqlCommand cmd = new SqlCommand(strProcName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false,
                0, 0, string.Empty, DataRowVersion.Default, null));

            return cmd;
        }

        public int GetNewID(string strTableName)
        {
            string strSql = "select top 1 * from ";
            if ("".Equals(strSql.Trim()))
            {
                return -1;
            }
            else
            {
                strSql = strSql + strTableName + " order by _id desc";
            }

            DataSet ds = this.RunProcReturn(strSql, strTableName);

            if (ds.Tables[0].Rows.Count < 0)
            {
                return -1;
            }

            return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        }
    }
}
