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
    public partial class Copy_of_IntervalWiseClosingForm : System.Web.UI.Page
    {
        //edigital_closing c = new edigital_closing();
        //sanatan_closing c = new sanatan_closing();
        ocean_closing c = new ocean_closing();

        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitiateInterval();
            InitiateClosingDate();
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Interval = ddlInterval.SelectedValue;
            string ClosingStartDate = ddlStartDate.SelectedValue + "/" + ddlStartMonth.SelectedValue + "/" + ddlStartYear.SelectedValue;
            string ClosingEndDate = ddlEndDate.SelectedValue + "/" + ddlEndMonth.SelectedValue + "/" + ddlEndYear.SelectedValue;

            DateTime dtClosingStartDate = DateTime.ParseExact(ClosingStartDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture);
            DateTime dtClosingEndDate = DateTime.ParseExact(ClosingEndDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture);

            string closingNumber = hdfClosingNumber.Value;
            string DeleteID = hdfDeleteID.Value;

            int IntClosingNumber = int.Parse(hdfClosingNumberInt.Value);
            int IntDeleteNumber = int.Parse(DeleteID);

            while (dtClosingStartDate <= dtClosingEndDate)
            {
                string StartDate = dtClosingStartDate.ToString("dd/MM/yyyy");   //ddlStartDate.SelectedValue + "/" + ddlStartMonth.SelectedValue + "/" + ddlStartYear.SelectedValue;
                string EndDate = StartDate;                                     // ddlEndDate.SelectedValue + "/" + ddlEndMonth.SelectedValue + "/" + ddlEndYear.SelectedValue;
                DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string ClosingDate = dtToday.ToString("dd/MM/yyyy");
                string Closing_iDate = dtToday.ToString("yyyyMMdd");

                closingNumber = "ClosingNumber-" + (IntClosingNumber).ToString("000");
                DeleteID = (IntDeleteNumber).ToString("000");

                int Start_iDate = int.Parse(dtClosingStartDate.ToString("yyyyMMdd")); //int.Parse(ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + ddlStartDate.SelectedValue);
                int End_iDate = Start_iDate;                                            //int.Parse(ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + ddlEndDate.SelectedValue);

                if (End_iDate >= Start_iDate)
                {
                    bool status = false;
                    if (c.IsClosingInProcess())
                    {
                        if (!c.IsClosingExist(Start_iDate.ToString(), End_iDate.ToString(), Interval))
                        {
                            c.UpdateClosingStatus(closingNumber, "InProcess");
                            status = c.StartClosing(StartDate, EndDate, closingNumber, ClosingDate, Closing_iDate, DeleteID, Interval);
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



                if (Interval == "1")
                {
                    Interval = "2";
                    ddlInterval.SelectedValue = "2";
                }
                else if (Interval == "2")
                {
                    Interval = "3";
                    ddlInterval.SelectedValue = "3";
                }
                else
                {
                    Interval = "1";
                    ddlInterval.SelectedValue = "1";
                    dtClosingStartDate = dtClosingStartDate.AddDays(1);
                }

                IntClosingNumber = IntClosingNumber + 1;
                IntDeleteNumber = IntDeleteNumber + 1;
            }

            
        }

        public void InitiateClosingDate()
        {
            string sql = "select * from closing order by Id desc";
            DataTable dtTemp = imp.FillTable(sql);
            hdfClosingNumber.Value = "ClosingNumber-" + (dtTemp.Rows.Count + 1).ToString("000");
            hdfClosingNumberInt.Value = (dtTemp.Rows.Count + 1).ToString("000");
            hdfDeleteID.Value = "1" + (dtTemp.Rows.Count + 1).ToString("000");
            if (dtTemp.Rows.Count == 0) { lblPreviousClosingDate.Visible = false; }
            else
            {
                string LastClosingDate = dtTemp.Rows[0]["End_date"].ToString();
                int LastClosingInterval = int.Parse(dtTemp.Rows[0]["Interval"].ToString());

                DateTime EndClosingDate = DateTime.ParseExact(LastClosingDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                
                if (LastClosingInterval == 3)
                {
                    DateTime NextClosingStartDate = EndClosingDate.AddDays(1);

                    ddlStartDate.SelectedValue = int.Parse(NextClosingStartDate.ToString("dd")).ToString("00");
                    ddlStartDate.Enabled = false;

                    ddlStartMonth.SelectedValue = int.Parse(NextClosingStartDate.ToString("MM")).ToString("00");
                    ddlStartMonth.Enabled = false;

                    ddlStartYear.SelectedValue = NextClosingStartDate.ToString("yyyy");
                    ddlStartYear.Enabled = false;

                    lblPreviousClosingDate.Visible = true;
                    lblPreviousClosingDate.Text = "Previous Closing Date : " + LastClosingDate + " and Interval : " + LastClosingInterval;
                    ddlInterval.SelectedValue = "1";
                }
                else
                {
                    ddlStartDate.SelectedValue = int.Parse(EndClosingDate.ToString("dd")).ToString("00");
                    ddlStartDate.Enabled = false;

                    ddlStartMonth.SelectedValue = int.Parse(EndClosingDate.ToString("MM")).ToString("00");
                    ddlStartMonth.Enabled = false;

                    ddlStartYear.SelectedValue = EndClosingDate.ToString("yyyy");
                    ddlStartYear.Enabled = false;

                    lblPreviousClosingDate.Visible = true;
                    lblPreviousClosingDate.Text = "Previous Closing Date : " + LastClosingDate + " and Interval : " + LastClosingInterval;

                    ddlInterval.SelectedValue = (LastClosingInterval + 1).ToString();
                }
            }
        }

        public void InitiateInterval()
        {
            string sql = "select Duration as IntervalText, (ID) as IntervalValue from IntervalDetails order by ID ASC";
            DataTable dtInterval = imp.FillTable(sql);

            ddlInterval.DataSource = dtInterval;
            ddlInterval.DataTextField = "IntervalText";
            ddlInterval.DataValueField = "IntervalValue";
            ddlInterval.DataBind();
        }
    }
}







//string Interval = ddlInterval.SelectedValue;
//string ClosingStartDate = ddlStartDate.SelectedValue + "/" + ddlStartMonth.SelectedValue + "/" + ddlStartYear.SelectedValue;
//string ClosingEndDate =  ddlEndDate.SelectedValue + "/" + ddlEndMonth.SelectedValue + "/" + ddlEndYear.SelectedValue;

//DateTime dtClosingStartDate = DateTime.ParseExact(ClosingStartDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture);
//DateTime dtClosingEndDate = DateTime.ParseExact(ClosingEndDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture);

//while (dtClosingStartDate <= dtClosingEndDate)
//{
//    string StartDate = dtClosingStartDate.ToString("dd/MM/yyyy");   //ddlStartDate.SelectedValue + "/" + ddlStartMonth.SelectedValue + "/" + ddlStartYear.SelectedValue;
//    string EndDate = StartDate;                                     // ddlEndDate.SelectedValue + "/" + ddlEndMonth.SelectedValue + "/" + ddlEndYear.SelectedValue;
//    DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);
//    string ClosingDate = dtToday.ToString("dd/MM/yyyy");
//    string Closing_iDate = dtToday.ToString("yyyyMMdd");

//    string closingNumber = hdfClosingNumber.Value;
//    string DeleteID = hdfDeleteID.Value;
//    int Start_iDate = int.Parse(ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + ddlStartDate.SelectedValue);
//    int End_iDate = Start_iDate; //int.Parse(ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + ddlEndDate.SelectedValue);

//    if (End_iDate >= Start_iDate)
//    {
//        bool status = false;
//        if (c.IsClosingInProcess())
//        {
//            if (!c.IsClosingExist(Start_iDate.ToString(), End_iDate.ToString(), Interval))
//            {
//                c.UpdateClosingStatus(closingNumber, "InProcess");
//                status = c.StartClosing(StartDate, EndDate, closingNumber, ClosingDate, Closing_iDate, DeleteID, Interval);
//            }
//            else { lblMessage.Text = "Closing already done."; btnSubmit.Visible = false; return; }
//        }
//        else { lblMessage.Text = "Closing already in process. Please try again after few minutes..."; btnSubmit.Visible = false; return; }

//        if (status) { lblMessage.Text = "Closing successfully done."; btnSubmit.Visible = false; }
//        else { lblMessage.Text = "Sorry, Closing process failed. Try Again."; }

//        //Below commented lines are OK.
//        //bool status = c.StartClosing(StartDate, EndDate, closingNumber, ClosingDate, Closing_iDate, DeleteID);
//        //if (status) { lblMessage.Text = "Closing successfully done."; btnSubmit.Visible = false; }
//        //else { lblMessage.Text = "Sorry, Closing process failed. Try Again."; }
//    }
//    else { lblMessage.Text = "Invalid Date."; }



//    if (Interval == "2")
//    {
//        ddlInterval.SelectedValue = "1";
//        dtClosingStartDate = dtClosingStartDate.AddDays(1);
//    }
//    else { ddlInterval.SelectedValue = "2"; }

//    TempValue = TempValue + 1;
//}