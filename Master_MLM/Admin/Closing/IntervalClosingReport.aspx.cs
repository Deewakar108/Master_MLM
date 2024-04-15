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
    public partial class IntervalClosingReport : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { BindClosingDate(); }
        }

        public void BindClosingDate() 
        {
            string sql = "select *, (End_date + ' - ' + Interval) as TextValue from closing order by Id desc";
            DataTable dtTemp = imp.FillTable(sql);
            if(dtTemp.Rows.Count!=0)
            {
                ddlClosingDate.DataSource = dtTemp;
                ddlClosingDate.DataTextField = "TextValue";
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
                lbl_message.Text = "Invalid Date.";
                pnl_view.Visible = false;
            }
        }

        public void BindGridView()
        {
            string ClosingNumber = ddlClosingDate.SelectedValue;
            string sql = "select p.Member_code, (select Member_name from Member_registration m where Member_code=p.Member_code) as Name, " +
                "(select Sponcer_name from Member_registration where Member_code=p.Member_code) as SponsorName, " +
                  "(select Sponcer_code from Member_registration where Member_code=p.Member_code) as Sponcer_code, SUM(convert(float, p.carryAmount)) as carryAmount , " +
                "(select Mobile_number from Member_registration where Member_code=p.Member_code) as MobileNo, Closingno, p.Start_date,p.End_date, SUM(convert(float, p.TDS)) as TDS,  " +
                  " (SUM(convert(float, p.Final_amount)) + SUM(convert(float, p.carryAmount))) as Final_amount, SUM(convert(float, p.Totalamount)) as Totalamount, SUM(convert(float, p.Servicecharge)) as admincharge from payout p  where  " +
                  "p.Member_code!='0' and  p.Closingno='" + ClosingNumber + "' group by p.Member_code, p.Closingno, p.Start_date,p.End_date";

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