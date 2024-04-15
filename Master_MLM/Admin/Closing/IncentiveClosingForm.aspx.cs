using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;
using System.Globalization;

namespace Master_MLM.Admin_87554b
{
    public partial class IncentiveClosingForm : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitiateClosingDate();
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string StartDate = "01/" + ddlStartMonth.SelectedValue + "/" + ddlStartYear.SelectedValue;

            DateTime dtXDate = DateTime.ParseExact(StartDate,"dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string Today_iDate = dtToday.ToString("yyyyMM") + "01";

            dtXDate = dtXDate.AddMonths(1).AddDays(-1);
            string EndDate = dtXDate.ToString("dd/MM/yyyy");
            
            string ClosingDate = dtToday.ToString("dd/MM/yyyy");
            string Closing_iDate = dtToday.ToString("yyyyMMdd");

            string closingNumber = hdfClosingNumber.Value;
            string DeleteID = hdfDeleteID.Value;
            int Start_iDate = int.Parse(ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "01");
            int End_iDate = int.Parse(dtXDate.ToString("yyyyMMdd"));

            string MonthValue = ddlStartMonth.SelectedValue;
            string Year = ddlStartYear.SelectedValue;

            if (Start_iDate >= int.Parse(Today_iDate)) { lblMessage.Text = "Please select Valid <b>Month</b> and <b>Year</b> for Closing."; return; }

            if (End_iDate > Start_iDate)
            {
                LoadAchievedMembersIncome(MonthValue, Year);
            }
            else { lblMessage.Text = "Invalid Date."; pnlAchivedMember.Visible = false; }
        }

        public void InitiateClosingDate()
        {
            string sql = "select * from Ry_closing order by Id desc";
            DataTable dtTemp = imp.FillTable(sql);
            hdfClosingNumber.Value = "Royalty-Closing-" + (dtTemp.Rows.Count + 1).ToString("000");
            hdfDeleteID.Value = "1" + (dtTemp.Rows.Count + 1).ToString("000");
            if (dtTemp.Rows.Count == 0) { lblPreviousClosingDate.Visible = false; }
            else
            {
                string LastClosingDate = dtTemp.Rows[0]["End_date"].ToString();
                DateTime EndClosingDate = DateTime.ParseExact(LastClosingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime NextClosingStartDate = EndClosingDate.AddDays(1);

                //ddlStartDate.SelectedValue = int.Parse(NextClosingStartDate.ToString("dd")).ToString("00");
                //ddlStartDate.Enabled = false;

                //ddlStartMonth.SelectedValue = int.Parse(NextClosingStartDate.ToString("MM")).ToString("00");
                //ddlStartMonth.Enabled = false;

                //ddlStartYear.SelectedValue = NextClosingStartDate.ToString("yyyy");
                //ddlStartYear.Enabled = false;

                lblPreviousClosingDate.Visible = true;
                lblPreviousClosingDate.Text = "Previous Closing Date : " + LastClosingDate;
            }
        }

        public void LoadAchievedMembersIncome(string MonthValue, string Year) 
        {
            string sql = "select i.*, m.Member_name, m.Member_code, m.Sponcer_name, m.Sponcer_code, m.Mobile_number from IncentiveAchievedIncome i join  " + 
                         "Member_registration m on m.Member_code=i.MemberCode   where Month='" + MonthValue + "' and Year='" + Year + "'";
            DataTable dtTable = imp.FillTable(sql);

            grd_view.DataSource = dtTable;
            grd_view.DataBind();

            pnlAchivedMember.Visible = true;
        }

        protected void grd_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}