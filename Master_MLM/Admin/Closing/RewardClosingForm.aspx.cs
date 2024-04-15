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
    public partial class RewardClosingForm : System.Web.UI.Page
    {
        ocean_reward c = new ocean_reward();
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitiateClosingDate();
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string StartDate = ddlStartDate.SelectedValue + "/" + ddlStartMonth.SelectedValue + "/" + ddlStartYear.SelectedValue;
            string EndDate = ddlEndDate.SelectedValue + "/" + ddlEndMonth.SelectedValue + "/" + ddlEndYear.SelectedValue;
            DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string ClosingDate = dtToday.ToString("dd/MM/yyyy");
            string Closing_iDate = dtToday.ToString("yyyyMMdd");

            string closingNumber = hdfClosingNumber.Value;
            string DeleteID = hdfDeleteID.Value;
            int Start_iDate = int.Parse(ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + ddlStartDate.SelectedValue);
            int End_iDate = int.Parse(ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + ddlEndDate.SelectedValue);

            string MonthValue = "";
            string Year = "";

            if (End_iDate > Start_iDate)
            {
                bool status = false;
                if (c.IsClosingInProcess())
                {
                    if (!c.IsClosingExist(Start_iDate.ToString(), End_iDate.ToString()))
                    {
                        c.UpdateClosingStatus(closingNumber, "InProcess");
                        status = c.StartClosing(StartDate, EndDate, closingNumber, ClosingDate, Closing_iDate, DeleteID, MonthValue, Year, "1");
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
            string sql = "select * from R_closing order by Id desc";
            DataTable dtTemp = imp.FillTable(sql);
            hdfClosingNumber.Value = "Reward-Closing-" + (dtTemp.Rows.Count + 1).ToString("000");
            hdfDeleteID.Value = "1" + (dtTemp.Rows.Count + 1).ToString("000");
            if (dtTemp.Rows.Count == 0) { lblPreviousClosingDate.Visible = false; }
            else
            {
                string LastClosingDate = dtTemp.Rows[0]["End_date"].ToString();
                DateTime EndClosingDate = DateTime.ParseExact(LastClosingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime NextClosingStartDate = EndClosingDate.AddDays(1);

                ddlStartDate.SelectedValue = int.Parse(NextClosingStartDate.ToString("dd")).ToString("00");
                ddlStartDate.Enabled = false;

                ddlStartMonth.SelectedValue = int.Parse(NextClosingStartDate.ToString("MM")).ToString("00");
                ddlStartMonth.Enabled = false;

                ddlStartYear.SelectedValue = NextClosingStartDate.ToString("yyyy");
                ddlStartYear.Enabled = false;

                lblPreviousClosingDate.Visible = true;
                lblPreviousClosingDate.Text = "Previous Closing Date : " + LastClosingDate;
            }
        }
    }
}