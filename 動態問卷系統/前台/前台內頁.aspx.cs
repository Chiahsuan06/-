using DBSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace 動態問卷系統.前台
{
    public partial class 前台內頁 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDNumber = "1";   //先寫死 "1"
                            //this.Session["QuestionnaireNum"] as string
            this.reHeading.DataSource = GetHeading(IDNumber);
            this.reHeading.DataBind();

            this.reContent.DataSource = GetContent(IDNumber);
            this.reContent.DataBind();
        }

        /// <summary>
        /// 顯示資料
        /// </summary>
        /// <returns></returns>
        //標題
        public static DataTable GetHeading(string IDNumber)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT [Heading]
                    FROM [Outline]
                    WHERE Number = @IDNumber
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@IDNumber", IDNumber));

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
        //內容
        public static DataTable GetContent(string IDNumber)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT [Content]
                    FROM [Outline]
                    WHERE Number = @IDNumber
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@IDNumber", IDNumber));

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
        //問卷題目

        /// <summary>
        /// 按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"將返回列表頁", "確定", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Response.Redirect("/前台/前台列表頁.aspx");
        }
        
        protected void btnSent_Click(object sender, EventArgs e)
        {
            this.Session["Name"] = this.txtbName.Text;
            this.Session["Phone"] = this.txtbPhone.Text;
            this.Session["Email"] = this.txtbEmail.Text;
            this.Session["Age"] = this.txtbAge.Text;

            MessageBox.Show($"即將前往確認頁面，請確認填寫的資訊是否正確", "確定", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Response.Redirect("/前台/前台確認頁.aspx");
        }
    }
}