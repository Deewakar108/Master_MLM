using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Member_1541_profile : System.Web.UI.Page
    {

        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["membercode"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                Response.Write("<script language=javascript>wnd.close();</script>");
                Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
            }
            else
            {
                if (!IsPostBack)
                {
                    string memberid = Session["membercode"].ToString();
                    featch_member_details(memberid);
                }
            }
        }

        private void featch_member_details(string memberid)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + memberid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
            }
            else
            {
                lbl_membercode.Text = memberid;


                lbl_sponser_code.Text = ds.Tables[0].Rows[0][1].ToString();
                lbl_sponcer_name.Text = ds.Tables[0].Rows[0][2].ToString();
                lbl_pincode.Text = ds.Tables[0].Rows[0]["Pin_code"].ToString();
                lblname.Text = ds.Tables[0].Rows[0][4].ToString();
                string date = ds.Tables[0].Rows[0][5].ToString();
                string day, month, year;
                day = date.Substring(0, 2);
                month = date.Substring(3, 2);
                year = date.Substring(6, 4);
                lbl_date.Text = day + "/" + month + "/" + year;

                lbl_email.Text = ds.Tables[0].Rows[0][6].ToString();
                lbl_mobileno.Text = ds.Tables[0].Rows[0][7].ToString();
                lbl_panno.Text = ds.Tables[0].Rows[0]["Pan_number"].ToString();


                lbl_fathername.Text = ds.Tables[0].Rows[0][11].ToString();
                lbl_date_of_birth.Text = ds.Tables[0].Rows[0][12].ToString();
                lbl_gender.Text = ds.Tables[0].Rows[0][13].ToString();
                lbl_address.Text = ds.Tables[0].Rows[0][14].ToString();
                lbl_district.Text = ds.Tables[0].Rows[0][15].ToString();
                lbl_state.Text = ds.Tables[0].Rows[0][16].ToString();
                lbl_nominee_name.Text = ds.Tables[0].Rows[0][17].ToString();
                lbl_nominee_relation.Text = ds.Tables[0].Rows[0][18].ToString();
                lbl_nominee_age.Text = ds.Tables[0].Rows[0][19].ToString();
                lbl_nominee_gender.Text = ds.Tables[0].Rows[0][20].ToString();
                lbl_account_no.Text = ds.Tables[0].Rows[0][21].ToString();
                lbl_bank_name.Text = ds.Tables[0].Rows[0][22].ToString();
                lbl_bank_branch.Text = ds.Tables[0].Rows[0][23].ToString();
                lbl_ifsc_code.Text = ds.Tables[0].Rows[0][24].ToString();
                lbl_payee_name.Text = ds.Tables[0].Rows[0]["Payee_Name_bank"].ToString();

                lbl_acount_type.Text = ds.Tables[0].Rows[0][41].ToString();
                lbl_joining_amount.Text = ds.Tables[0].Rows[0][30].ToString();

                lbl_package.Text = ds.Tables[0].Rows[0]["joining_package"].ToString();
                lbl_verificationdate.Text = ds.Tables[0].Rows[0]["Verification_date"].ToString();
                lblStatus.Text = ds.Tables[0].Rows[0]["Paidstatus"].ToString() == "FREE" ? "Inactive" : "Active";

                Img_member.ImageUrl = ds.Tables[0].Rows[0][29].ToString();
                Session["id"] = ds.Tables[0].Rows[0][31].ToString();
                find_pwd(memberid);
            }
        }

        private void find_pwd(string memberid)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select Pwd from Member_Login where Membercode ='" + memberid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_Login");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                lbl_password.Text = dt.Rows[0][0].ToString();

            }
        }

        protected void imgbtn_upload_Click(object sender, ImageClickEventArgs e)
        {

            string imagepath = uploadimage();
            if (imagepath == "")
            {
                imagepath = Img_member.ImageUrl;
            }
            string memberid = Session["membercode"].ToString();
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);

            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + memberid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {



            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr[29] = imagepath;
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);

                }
                featch_member_details(memberid);
            }
        }

        private string uploadimage()
        {
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd_MM_yyyy");
            string time = dt.ToString("hh_mm_ss_tt");
            string name = time + date;

            string dbfilePath = "";
            Boolean FileOK = false;
            Boolean FileSaved = false;
            int k = 0;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 300000)
                {
                    Session["file1"] = FileUpload1.FileName;
                    String FileExtension = Path.GetExtension(Session["file1"].ToString()).ToLower();
                    Session["file2"] = (Guid.NewGuid() + FileExtension);
                    String[] allowedExtensions = { ".png", ".jpeg", ".jpg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        k++;
                        if (FileExtension == allowedExtensions[i])
                        {
                            FileOK = true;
                            break;
                        }
                    }
                }
                else
                {
                    lbl_message.Text = "Please Upload image Max(300kb)";

                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                    dbfilePath = "Max Size";
                }
            }
            else
            {

            }
            if (FileOK)
            {
                try
                {
                    string path = (Server.MapPath("Master_image")).ToString();
                    FileUpload1.SaveAs(path + "/" + Session["file2"]);
                    FileSaved = true;
                }
                catch (Exception ex)
                {

                    FileSaved = false;
                }
            }
            else
            {

            }
            if (FileSaved)
            {

                string fileName = Path.GetFileName(Session["file2"].ToString());
                dbfilePath = @"Master_image/" + fileName;
            }
            return dbfilePath;
        }
    }
}