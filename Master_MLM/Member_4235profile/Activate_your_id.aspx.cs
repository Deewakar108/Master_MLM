using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Master_MLM.App_Code;
using System.Globalization;

namespace Master_MLM.Member_4235profile
{
    public partial class Activate_your_id : System.Web.UI.Page
    {
        string scrpt;
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;
                if (Session["pin"] != null)
                {
                    string pin = Session["pin"].ToString();
                    txt_epin.Text = pin;
                    txt_epin.Enabled = false;
                    txt_epin.CssClass = "form-control";
                    check_pin_validation();
                }
                else
                {
                    Response.Redirect("Allocated_pin_list.aspx", false);
                }
            }
        }

        protected void btn_activate_Click(object sender, EventArgs e)
        {
            string MemberCode = txtMemberCode.Text;

            string Joining_amount = hdfPackageAmount.Value;
            string joining_package = hdfPackage.Value;
            string Package_id = hdfPackageID.Value;
            string Pinno = txt_epin.Text;
            string MatchingIncome = hdfMatchingIncome.Value;
            string RewardPoint = hdfPackageRewardPoint.Value;

            string BV = hdfRewardBV.Value;
            string RepurchaseBV = hdfRepurchaseBV.Value;


            DateTime dtToday = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            string Verification_date = dtToday.ToString("dd/MM/yyyy");
            string Verification_time = dtToday.ToString("hh:mm:ss tt");
            string Verification_idate = dtToday.ToString("yyyyMMdd");
            string PrevEPin = GetPreviousEPin(MemberCode);
            string NewEPin = Pinno;
            string Interval = GetIntervalValue();

            //For Member Activation
            string sql = "update Member_registration set Status = 'Verified', Paidstatus = 'PAID', Joining_amount = '" + Joining_amount + "', joining_package = '" + joining_package + "', " +
                         "Package_id = '" + Package_id + "', Pinno = '" + Pinno + "', Verification_date = '" + Verification_date + "', Verification_time = '" + Verification_time +
                         "', Verification_idate = '" + Verification_idate + "', MatchingIncome = '" + MatchingIncome + "', RewardPoint = '" + RewardPoint +
                         "', RepurchaseBV = '" + RepurchaseBV + "', RewardBV = '" + BV + "', Interval = '" + Interval +
                         "' where Member_code='" + MemberCode + "'";
            int i1 = imp.InsertUpdateDelete(sql);


            //TopUp
            sql = "insert into TopUpMemberList(MemberCode,PrevEPin,NewEPin,ActivationDate,Activation_iDate,submittedby) values ('" + MemberCode + "','" + PrevEPin + "','" + Pinno +
                       "','" + Verification_date + "','" + Verification_idate + "','" + Session["membercode"].ToString() + "')";
            i1 = imp.InsertUpdateDelete(sql);

            string SponsorCode = GetSponsorCode(MemberCode);
            sql = "update E_PIN_details  set used_by='" + SponsorCode + "', used_date='" + Verification_date + "', Used_to='" + MemberCode + "', Status='USED' where    Epin='" + Pinno + "'";
            int i2 = imp.InsertUpdateDelete(sql);
            if (i1 == 0 || i1 == 0) { AlertMe("Try Again"); }
            else
            {
                string msg = "Member successfully activated.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + msg + "'); window.location='" + Request.ApplicationPath + "Member_4235profile/Allocated_pin_list.aspx';", true);
            }

        }

        private void AlertMe(string Message)
        {
            lbl_msg.Text = Message;
            string scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
        }

        private string GetSponsorCode(string MemberCode)
        {
            string sql = "select * from Member_registration where Member_code='" + MemberCode + "'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0)
            {
                return dtTemp.Rows[0]["Sponcer_code"].ToString();
            }
            return imp.AdminCode;
        }

        private string GetPreviousEPin(string MemberCode)
        {
            string sql = "select * from Member_registration where Member_code='" + MemberCode + "'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0)
            {
                return dtTemp.Rows[0]["Pinno"].ToString();
            }
            return "";
        }

        private string GetIntervalValue()
        {
            DateTime dtCurrent = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            DateTime dtFixed = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 12:00:00 AM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //First Slot
            DateTime dtStart1 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 06:00:00 AM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd1 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 11:59:59 AM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //Second Slot
            DateTime dtStart2 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 12:00:00 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd2 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 05:59:59 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            //Third Slot
            DateTime dtStart3 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 06:00:00 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dtEnd3 = DateTime.ParseExact(dtCurrent.ToString("dd/MM/yyyy") + " 11:59:59 PM", "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            if (dtCurrent >= dtStart1 && dtCurrent <= dtEnd1) { return "1"; }
            if (dtCurrent >= dtStart2 && dtCurrent <= dtEnd2) { return "2"; }
            if (dtCurrent >= dtStart3 && dtCurrent <= dtEnd3) { return "3"; }
            return "1";
        }

        private bool check_pin_validation()
        {
            string IsActivationPackage = "0, 2";
            string sql = "";

            sql = "select * from (select *, isnull((select top 1 IsActivationPackage from Joining_package where Package_name=Package), 0) as IsActivationPackage, " +
                  "isnull((select top 1 BV from Joining_package where Package_name=Package), 0) as BV," +
                  "isnull((select top 1 RepurchaseBV from Joining_package where Package_name=Package), 0) as RepurchaseBV," +
                "isnull((select top 1 Package_amount from Joining_package where Package_name=Package), 0) as package_amount, isnull((select top 1 RewardPoint from " +
                  "Joining_package where Package_name=Package), 0) as RewardPoint, isnull((select top 1 MatchingIncome from Joining_package where Package_name=Package), " +
                  "0) as MatchingIncome from E_PIN_details where Status='GIVEN' and  Epin='" + txt_epin.Text + "') T where  IsActivationPackage in (" +
                  IsActivationPackage + ")";


            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                lblEpinDetails.Text = "Package : " + dt.Rows[0]["Package"].ToString() + ", Amount : " + dt.Rows[0]["package_amount"].ToString();
                hdfPackage.Value = dt.Rows[0]["Package"].ToString();
                hdfPackageAmount.Value = dt.Rows[0]["package_amount"].ToString();
                hdfPackageRewardPoint.Value = dt.Rows[0]["RewardPoint"].ToString();
                hdfMatchingIncome.Value = dt.Rows[0]["MatchingIncome"].ToString();
                hdfPackageID.Value = dt.Rows[0]["Package_id"].ToString();

                hdfRewardBV.Value = dt.Rows[0]["BV"].ToString();
                hdfRepurchaseBV.Value = dt.Rows[0]["RepurchaseBV"].ToString();
                return true;
            }
            else { lblEpinDetails.Text = "Invalid Epin."; return false; }

            //string epin = txt_epin.Text;
            //string sql = "Select * from (Select *, isnull((select Amount from Joining_package where Package_name=Package), 0) as PackageAmount from E_PIN_details where Epin='" + epin + "' and Status ='GIVEN' and Package!='1999/- B' ) T";
            //DataTable dt = imp.FillTable(sql);
            //if (dt.Rows.Count != 0)
            //{
            //    lblEpinDetails.Text = "Package : " + dt.Rows[0]["Package"].ToString() + ", Amount : " + dt.Rows[0]["PackageAmount"].ToString();
            //    return true;
            //}
            //else
            //{
            //    lblEpinDetails.Text = "Invalid Epin.";

            //    return false;
            //}
        }

        protected void btn_member_Click(object sender, EventArgs e)
        {
            try
            {
                find_member();
            }
            catch (Exception ex)
            {
            }
        }

        private void find_member()
        {
            string MemberCode = txtMemberCode.Text;
            string sql = "select * from Member_registration  where   Member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                txt_membername.Text = dt.Rows[0]["Member_name"].ToString();

                btn_activate.Visible = true;
            }
            else { AlertMe("Invalid member selected."); }
        }
    }
}