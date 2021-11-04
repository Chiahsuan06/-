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
            string IDNumber = this.Request.QueryString["ID"];
            this.reHeading.DataSource = GetHeading(IDNumber);
            this.reHeading.DataBind();

            this.reContent.DataSource = GetContent(IDNumber);
            this.reContent.DataBind();

            string QuestionnaireID = "2E16818C-CB64-44B3-A491-882773558BA1"; //尋問毛豆
            this.reTopicOptions.DataSource = GetTopicOptions(QuestionnaireID);
            this.reTopicOptions.DataBind();
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
        //問卷題目、選項
        public static DataTable GetTopicOptions(string QuestionnaireID)   //要改成用TopicID或QuestionnaireID找
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT [Topic], [Options]
                    FROM [Question]
                    WHERE QuestionnaireID = @QuestionnaireID
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@QuestionnaireID", QuestionnaireID));

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

        public static DataTable GetQuestionnaireID(string IDNumber) 
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT [QuestionnaireID]
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
        }  //取得QuestionnaireID
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
            if (string.IsNullOrEmpty(this.txtbName.Text) || string.IsNullOrEmpty(this.txtbPhone.Text) || string.IsNullOrEmpty(this.txtbEmail.Text) || string.IsNullOrEmpty(this.txtbAge.Text))
            {
                this.plcNoWriteData.Visible = true;
            }
            else 
            {
                this.plcNoWriteData.Visible = false;

                this.Session["Name"] = this.txtbName.Text;
                this.Session["Phone"] = this.txtbPhone.Text;
                this.Session["Email"] = this.txtbEmail.Text;
                this.Session["Age"] = this.txtbAge.Text;

                MessageBox.Show($"即將前往確認頁面，請確認填寫的資訊是否正確", "確定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Response.Redirect("/前台/前台確認頁.aspx");
            }
        }
    }
}