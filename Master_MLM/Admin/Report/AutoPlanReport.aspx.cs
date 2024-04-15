using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;

namespace Master_MLM.Admin.Report
{
    public partial class AutoPlanReport : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlAutoPlanList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAutoPlanList.SelectedValue != "0")
            {
                string sql = "select (select Member_name from Member_registration m where m.Member_code=a.member_code) as MemberName, * from " + ddlAutoPlanList.SelectedValue + " a order by id asc";
                DataTable dt = imp.FillTable(sql);

                grdAutoPlan.DataSource = dt;
                grdAutoPlan.DataBind();
                lbl_message.Text = "";
                pnl_view.Visible = true;
            }
            else { lbl_message.Text = "Please select valid plan."; pnl_view.Visible = false; }
        }
    }
}