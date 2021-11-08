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

namespace 動態問卷系統.後台
{
    public partial class 後台內頁1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtStartT.Text = DateTime.Now.ToString("yyyy-MM-dd");  //預設為當日
        }

        /// <summary>
        /// 問卷-送出紐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSent_Click(object sender, EventArgs e)
        {
            string Heading = this.txtQuestaireName.Text;
            string Content = this.txtContent.Text;
            DateTime StartT = Convert.ToDateTime(this.txtStartT.Text);
            DateTime EndT = Convert.ToDateTime(this.txtEndT.Text);
            Guid QuestionnaireNum = Guid.NewGuid();

            if (string.IsNullOrEmpty(this.txtQuestaireName.Text) || string.IsNullOrEmpty(this.txtContent.Text) || string.IsNullOrEmpty(this.txtStartT.Text) || string.IsNullOrEmpty(this.txtEndT.Text))
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "問卷名稱、描述內容、開始時間、結束時間 皆為必填";
            }
            if (ckbActivated.Checked == true)  //狀態要顯示已啟用
            {
                //已啟用 Vote 要寫投票中
                string Vote = "投票中";
                MessageBox.Show($"提醒您問卷將送出，請確認", "確定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Add(Heading, Content, StartT, EndT, QuestionnaireNum, Vote);

            }
            else 
            {
                if (StartT > DateTime.Now) //尚未開始
                {
                    string Vote = "尚未開始";
                    MessageBox.Show($"提醒您問卷將送出，請確認", "確定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Add(Heading, Content, StartT, EndT, QuestionnaireNum, Vote);

                }
                else if (EndT < DateTime.Now) //已完結
                {
                    string Vote = "已完結";
                    MessageBox.Show($"提醒您問卷將送出，請確認", "確定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Add(Heading, Content, StartT, EndT, QuestionnaireNum, Vote);
                }
            }
            

        }
        /// <summary>
        /// 問卷 - 取消紐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/後台/後台列表頁.aspx");
        }
        /// <summary>
        /// 寫進資料庫
        /// </summary>
        /// <param name="IDNumber"></param>
        /// <returns></returns>
        public static DataTable Add(string Heading, string Content, DateTime StartT, DateTime EndT, Guid QuestionnaireNum, string Vote)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT [QuestionnaireID],[QuestionnaireNum],[Heading],[Vote],[StartTime],[EndTime],[Content]
                    FROM [Outline]
                   INSERT INTO Outline (Heading, Content, StartTime, EndTime, QuestionnaireNum, Vote)
                    VALUES (@Heading, @Content, @StartTime, @EndTime, @QuestionnaireNum, @Vote )
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@Heading", Heading));
            list.Add(new SqlParameter("@Content", Content));
            list.Add(new SqlParameter("@StartTime", StartT));
            list.Add(new SqlParameter("@EndTime", EndT));
            list.Add(new SqlParameter("@QuestionnaireNum", QuestionnaireNum));
            list.Add(new SqlParameter("@Vote", Vote));

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


    }
}