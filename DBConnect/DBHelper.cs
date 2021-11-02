using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBConnect
{
    public class DBHelper
    {

        /// <summary>
/// 連接資料庫
/// </summary>
/// <param name="args"></param>
/// 
        public static string GetConnectionString()   //0723 001 課程
        {
            string val = ConfigurationManager.AppSettings["DefaultConnection"]; 
                        //ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return val;
        }

        public static DataTable ReadDataTable(string connStr, string dbcommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    return dt;
                }
            }
        }

        /// <summary>
        /// 讀取資料
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="dbcommand"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataRow ReadDataRow(string connStr, string dbcommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());
                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt.Rows.Count == 0)
                        return null;

                    return dt.Rows[0];
                }
            }
        }

        public static int ModifyData(string connStr, string dbCommand, List<SqlParameter> paramList)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(paramList.ToArray());
                    conn.Open();
                    int effectRowsCount = comm.ExecuteNonQuery();
                    return effectRowsCount;
                }
            }
        }

        public static void CreateData(string connStr, string dbCommand, List<SqlParameter> createList)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(createList.ToArray());
                    conn.Open();
                    comm.ExecuteNonQuery();

                }
            }
        }
    }
}