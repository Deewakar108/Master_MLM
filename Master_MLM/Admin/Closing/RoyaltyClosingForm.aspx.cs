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
    public partial class RoyaltyClosingForm : System.Web.UI.Page
    {
        ocean_royalty c = new ocean_royalty();
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitiateClosingDate();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string StartDate = "01/" + ddlStartMonth.SelectedValue + "/" + ddlStartYear.SelectedValue;

            DateTime dtXDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                bool status = false;
                if (c.IsClosingInProcess())
                {
                    if (!c.IsClosingExist(Start_iDate.ToString(), End_iDate.ToString()))
                    {
                        c.UpdateClosingStatus(closingNumber, "InProcess");
                        //status = c.StartClosing(StartDate, EndDate, closingNumber, ClosingDate, Closing_iDate, DeleteID);
                        status = c.StartClosing(StartDate, EndDate, closingNumber, ClosingDate, Closing_iDate, DeleteID, MonthValue, Year);

                        if (status) { c.UpdateClosingStatus(closingNumber, "Complete"); }
                    }
                    else { lblMessage.Text = "Closing already done."; btnSubmit.Visible = false; return; }
                }
                else { lblMessage.Text = "Closing already in process. Please try again after few minutes..."; btnSubmit.Visible = false; return; }

                if (status) { lblMessage.Text = "Closing successfully done."; btnSubmit.Visible = false; }
                else { lblMessage.Text = "Sorry, Closing process failed. Try Again."; }

                //Below commented lines are OK.
                //bool status = c.StartClosing(StartDate, EndDate, closingNumber, ClosingDate, Closing_iDate, DeleteID);
                //if (status) { lblMessage.Text = "Closing successfully done."; btnSubmit.Visible = false; }
                //else { lblMessage.Text = "Sorry, Closing process failed. Try Again."; }
            }
            else { lblMessage.Text = "Invalid Date."; }
        }

        public void InitiateClosingDate()
        {
            My.fetch_year(ddlStartYear);
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

                ddlStartMonth.SelectedValue = NextClosingStartDate.ToString("MM");
                ddlStartMonth.Enabled = false;
                ddlStartYear.Text = NextClosingStartDate.ToString("yyyy");
                ddlStartYear.Enabled = false;

                lblPreviousClosingDate.Visible = true;
                lblPreviousClosingDate.Text = "Previous Closing Date : " + dtTemp.Rows[0]["Start_date"].ToString() + " To " + dtTemp.Rows[0]["End_date"].ToString();
  
            }
        }
    }
}