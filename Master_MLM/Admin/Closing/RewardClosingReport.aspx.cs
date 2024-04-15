using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;

namespace Master_MLM.Admin_87554b
{
    public partial class RewardClosingReport : System.Web.UI.Page
    {
        Important imp = new Important();
        DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { BindClosingDate(); }
        }

        public void BindClosingDate() 
        {
            string sql = "select * from closing_reward order by Id desc";
            DataTable dtTemp = imp.FillTable(sql);
            if(dtTemp.Rows.Count!=0)
            {
                ddlClosingDate.DataSource = dtTemp;
                ddlClosingDate.DataTextField = "End_date";
                ddlClosingDate.DataValueField = "Closingno";
                ddlClosingDate.DataBind();

                ddlClosingDate.Items.Insert(0, new ListItem { Text="Select", Value="0", Selected=true });
            }
        }

        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (ddlClosingDate.SelectedValue != "0") 
            {                
                BindGridView();
            }
            else 
            {
                lbl_message.Text = "Invalid selection.";
                pnl_view.Visible = false;
            }
        }

        public void BindGridView()
        {
            string ClosingNumber = ddlClosingDate.SelectedValue;
            string sql = "select *, (select Member_name from Member_registration  where Member_code=MemberCode) as MemberName, (select Member_name from Member_registration  " +
                         "where Member_code=SponsorCode) as SponsorName from AchievedTable where ClosingNumber='" + ClosingNumber + "'";

            DataTable dt = imp.FillTable(sql);

            grd_view.DataSource = dt;
            grd_view.DataBind();
            pnl_view.Visible = true;
            lbl_message.Text = "";
        }

        protected void grd_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_view.PageIndex = e.NewPageIndex;
            BindGridView();

        }

        protected void grd_view_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "IsPaid") 
            {
                Label lbl = (Label)grd_view.Rows[index].FindControl("lblID");

                string ID = lbl.Text;
                string PaidDate = dtToday.ToString("dd/MM/yyyy");

                string sql = "update AchievedTable set Status='PAID', PaidDate='" + PaidDate + "' where ID='" + ID + "'";
                int i = imp.InsertUpdateDelete(sql);
                BindGridView();
            }
        }

        protected void grd_view_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                Button btn = (Button)e.Row.FindControl("btnPaid");
                Label lbl = (Label)e.Row.FindControl("lblPaidDate");
                if (lbl.Text == "") { btn.Visible = true; }
                else { btn.Visible = false; lbl.Visible = true; }
            }
        }
    }
}