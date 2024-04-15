using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Master_MLM;

using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile.print_slip
{
    public partial class print_joining_voucher : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            ////////Session["registrationMemberCode"] = "BMHP1234";
            if (!IsPostBack)
            {
                fill_data();
            }
        }

        private void fill_data()
        {
            if (Session["registrationMemberCode"] != null) 
            {
                string memberCode = Session["registrationMemberCode"].ToString();
                string sql = "select  m.*, l.userName, l.Pwd from Member_registration m join Member_Login l on l.Membercode = m.Member_code where m.Member_code='" + memberCode + "'";
                DataTable dtTemp = imp.FillTable(sql);
                if (dtTemp.Rows.Count != 0)
                {
                    lbl_date.Text = "Date :" + " " + dtTemp.Rows[0]["Date"].ToString();
                    lbl_name0.Text = dtTemp.Rows[0]["Member_name"].ToString();
                    lbl_introcode.Text = dtTemp.Rows[0]["Sponcer_code"].ToString();
                    lbl_sponsorname.Text = dtTemp.Rows[0]["Sponcer_name"].ToString();
                    lbl_code.Text = dtTemp.Rows[0]["Member_code"].ToString();
                    lbl_username.Text = dtTemp.Rows[0]["Member_code"].ToString();
                    lblpassword.Text = dtTemp.Rows[0]["Pwd"].ToString();
                    //lbl_joiningpackage.Text = dtTemp.Rows[0]["pacckage"].ToString();
                    //lbl_amountpaid.Text = dtTemp.Rows[0]["amount"].ToString();
                    lbl_Referralcode.Text = dtTemp.Rows[0]["Referal_code"].ToString();
                    lbl_Referral_name.Text = dtTemp.Rows[0]["Referal_name"].ToString();
                    lblPosition.Text = dtTemp.Rows[0]["position"].ToString();

                    lblPasswordPwd.Text = dtTemp.Rows[0]["Pwd"].ToString();
                    lblUserName.Text = dtTemp.Rows[0]["userName"].ToString();
                    lblMobile.Text = dtTemp.Rows[0]["Mobile_number"].ToString();
                    //lblBankName.Text = dtTemp.Rows[0]["DDBankName"].ToString();
                    //lblDDNumber.Text = dtTemp.Rows[0]["DDNumber"].ToString();
                }
                else { Response.Redirect("~/Member_4235profile/Allocated_pin_list.aspx"); }
                
                Session["registrationMemberCode"] = null;
            }
            else { Response.Redirect("~/Member_4235profile/Allocated_pin_list.aspx"); }
            
           
        }

        private void send_to_save()
        {
             
        }
        protected void btn_print_Click(object sender, EventArgs e)
        {

            Go_to_print();


        }

        private void Go_to_print()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printit", "printit()", true);
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {

            Session["date"] = null;
            Session["name"] = null;
            Session["introcode"] = null;
            Session["intoname"] = null;
            Session["code"] = null;
            if (Session["memberpage"] == null)
            {
                Response.Redirect("~/Member_4235profile/Allocated_pin_list.aspx");
            }
            else
            {
                Response.Redirect("~/Member_4235profile/Allocated_pin_list.aspx");
            }
        }
    }
}