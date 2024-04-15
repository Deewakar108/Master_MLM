using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace Master_MLM
{
    public partial class forgotPassword : System.Web.UI.Page
    {
        Important imp = new Important();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitPassowrd_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtRetypePassword.Text == "") { lblPasswordMessage.Text = "Invalid Password."; return; }
            if (txtPassword.Text == txtRetypePassword.Text)
            {
                string MemberCode = hdfMemberCode.Value;
                string sql = "update  Member_Login set Pwd='" + txtPassword.Text + "' where Membercode = '" + MemberCode + "'";
                int i = imp.InsertUpdateDelete(sql);
                if (i == 0) { lblPasswordMessage.Text = "Try Again."; return; }
                else { Response.Redirect("loginpage.aspx"); }
            }
            else { lblPasswordMessage.Text = "Password does not match."; return; }
        }

        protected void btnOTPCode_Click(object sender, EventArgs e)
        {
            string MemberCode = hdfMemberCode.Value;
            string OTPCode = txtOTPCode.Text;

            string sql = "select * from forgot_pwd_otp where Member_code = '" + MemberCode + "' and OTP = '" + OTPCode + "'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0)
            {
                pnlVerify.Visible = false;
                pnlReset.Visible = true;
            }
            else { lblOTPMessage.Text = "Invalid OTP Code."; }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string MemberCode = txtMemberCode.Text;
            hdfMemberCode.Value = MemberCode;
            if (MemberCode == "") { lbl_msg.Text = "Invalid Member Code."; }
            else
            {
                string sql = "select * from Member_registration where Member_code = '" + MemberCode + "'";
                DataTable dtTemp = imp.FillTable(sql);
                if (dtTemp.Rows.Count != 0)
                {
                    string mobileNo = dtTemp.Rows[0]["Mobile_number"].ToString();
                    if (mobileNo != "")
                    {
                        string otp = GetOTP(MemberCode);
                        string message = "Your OTP Code is " + otp + ".";
                        sms_sender.send_message(mobileNo, message, MemberCode);

                        pnlVerify.Visible = true;
                        pnlForgot.Visible = false;


                    }
                }
                else { lbl_msg.Text = "Member Code does not exist."; }
            }
        }

        public string GetOTP(string MemberCode)
        {
            string chkotp = find_otp_old(MemberCode);
            if (chkotp == "NO")
            {
                string otp = "";
                bool duplicateid = false;
                Random rn = new Random();
                int i = 10000;
                int j = 99999;
                do
                {
                    int k = rn.Next(i, j);
                    otp = k.ToString();
                    duplicateid = check_dauplicate_id(otp);

                    if (duplicateid == true)
                    {

                    }
                } while (duplicateid == false);

                return otp;
            }
            else
            {
                return chkotp;
            }
        }

        private string find_otp_old(string userid)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_reg = new SqlDataAdapter("select OTP from forgot_pwd_otp where Member_code ='" + userid + "' and Status='Pending'", conn);
            DataSet ds = new DataSet();
            ad_reg.Fill(ds, "forgot_pwd_otp");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {
                return "NO";
            }
            else
            {
                return dt.Rows[0][0].ToString();

            }

        }

        private bool check_dauplicate_id(string otp)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_reg = new SqlDataAdapter("select * from forgot_pwd_otp where OTP =" + otp + "", conn);
            DataSet ds = new DataSet();
            ad_reg.Fill(ds, "forgot_pwd_otp");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {

                DataRow dr = dt.NewRow();
                dr["Member_code"] = txtMemberCode.Text;
                dr["Mobileno"] = "";
                dr["Date"] = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
                dr["Status"] = "Pending";
                dr["OTP"] = otp;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad_reg);
                ad_reg.Update(dt);
                return true;
            }
            else
            {
                return false;

            }
        }




    }
}