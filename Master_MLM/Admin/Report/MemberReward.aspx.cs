using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin.Report
{
    public partial class MemberReward : System.Web.UI.Page
    {
        Important imp = new Important();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string sql = "select a.ID, Sponcer_name, Member_name, Mobile_number, MemberCode, DateOfAchievement, a.Status, RewardName, ClosingNumber, " +
                "PaidDate  from AchievedTable a join Member_registration m on m.Member_code=a.MemberCode order by a.ID DESC";
            DataTable dt = imp.FillTable(sql);

            grdReward.DataSource = dt;
            grdReward.DataBind();
        }

        protected void btn_find_Click(object sender, EventArgs e)
        {
            
        }

        protected void grdReward_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IsSubmit") 
            {
                DateTime dtToday = DateTime.UtcNow.AddMinutes(30).AddHours(5);
                string PaidDate = dtToday.ToString("dd/MM/yyyy");
                string ID = e.CommandArgument.ToString();

                string sql = "update AchievedTable set PaidDate='" + PaidDate + "', Status='PAID' where ID='" + ID + "'";
                int i1 = imp.InsertUpdateDelete(sql);
                if (i1 != 0) { BindGridView(); }
            }
        }

        protected void grdReward_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                Button btn = (Button)e.Row.FindControl("btnSubmit");
                Label lbl = (Label)e.Row.FindControl("lblStatus");

                if (lbl.Text == "PAID") { btn.Visible = false; }
            }
        }
    }
}