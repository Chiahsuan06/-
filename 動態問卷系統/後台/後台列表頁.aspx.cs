using DBSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 動態問卷系統.後台
{
    public partial class 後台列表頁 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.DataSource = GetDBData();  ///讓GridView1顯示DB的資料
            this.GridView1.DataBind();
        }

        /// <summary>
        /// 顯示資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDBData()
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT [QuestionnaireID],[Heading],[Vote],[StartTime],[EndTime]
                    FROM [Outline]
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            try
            {
                return DBHelper.ReadDataTable(connStr, dbcommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        
        /// <summary>
        /// 新增問卷或更新問卷(問毛豆)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImgbtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/後台/後台內頁1.aspx");
        }
        /// <summary>
        /// 刪除問卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImgbtnBin_Click(object sender, ImageClickEventArgs e)
        {
            //DBUtil db = null;  連結DB用的
            List<object> parameters = new List<object>();
            List<object> parameters_value = new List<object>();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");

                if (cb.Checked == true)
                {
                    parameters.Add("@QuestionnaireID");
                    parameters_value.Add(GridView1.Rows[i].Cells[1].Text);
                }
            }

            if (parameters.Count != 0)  //寫刪除方法進DB
            {
                //db = new DBUtil();
                string sql = "";
                for(int i = 0; i < parameters.Count; i++)
                {
                    sql += "DELECT From Outline WHERE QuestionnaireID = '" + parameters_value[i].ToString() + "';";
                }
                //db.delect_pure(sql);
                Response.Write("<Script language= 'JaveScript'> alert('刪除完成!');<Script>");
            }
        }
    }
}