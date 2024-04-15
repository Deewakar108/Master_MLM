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
    public partial class RoyaltyClosingReport : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {  }
        }

        protected void btn_find_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        public void BindGridView()
        {
            string ClosingType = "Royalty";
            string StartDate = "01/" + ddlStartMonth.SelectedValue + "/" + ddlStartYear.SelectedValue;
            string sql = "select p.Member_code, (select Member_name from Member_registration m where Member_code=p.Member_code) as Name,  " + 
                         "(select Sponcer_name from Member_registration where Member_code=p.Member_code) as SponsorName,  (select Sponcer_code from " + 
                         "Member_registration where Member_code=p.Member_code) as Sponcer_code,  (select Mobile_number from Member_registration where " + 
                         "Member_code=p.Member_code) as MobileNo, Closingno, p.Start_date,p.End_date, SUM(convert(float, p.TDS)) as TDS,   " + 
                         "SUM(convert(float, p.Final_amount)) as Final_amount, SUM(convert(float, p.Totalamount)) as Totalamount, " +
                         "SUM(convert(float, p.Servicecharge)) as admincharge from payout p  where   p.Member_code!='0' and p.ClosingType='" + 
                         ClosingType + "' and Start_date='" + StartDate + "' group by p.Member_code, p.Closingno, p.Start_date,p.End_date";

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
    }
}