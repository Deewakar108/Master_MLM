using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM
{
    public partial class Main : System.Web.UI.MasterPage
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblCompanyEmailID1.Text = imp.EmailID;
                lblCompanyEmailID1.Text = imp.EmailID;
                lblCompanyMobileNo1.Text = imp.MobileNo;
                lblCompanyMobileNo1.Text = imp.MobileNo;
            }
            catch (Exception xe)
            {
            }
            
        }
        protected void btn_sign_in_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            string T = txt_username.Text;
            try
            {

                //Not Allowing Numbers, Underscore or Hash
                char[] UnallowedCharacters = { '-', '#', '\'', '/', '\\', '*', '!', ';', ':', '(', ')', '{', '}', '[', ']', '+', '|', '&', '%', '=' };
                if (textContainsUnallowedCharacter(T, UnallowedCharacters))
                {
                    lbl_message.Text = "Wrong Entry";
                }
                else
                {
                    lbl_message.Text = "Please try again....";
                    Connection con = new Connection();
                    string connectionstring = con.connect_method();
                    SqlConnection conn = new SqlConnection(connectionstring);
                    SqlDataAdapter ad = new SqlDataAdapter("select * from Admin_login where User_id='" + txt_username.Text + "'", conn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "Admin_login");
                    DataTable dt = ds.Tables[0];
                    int rowcount = dt.Rows.Count;
                    if (rowcount == 0)
                    {
                        // lbl_message.Text = "User Name or Password is incorrect.";
                        login_to_member_profile();
                    }
                    else
                    {
                        lbl_message.Text = "";
                        string pwd = dt.Rows[0]["Pwd"].ToString();
                        if (pwd == txt_password.Text)
                        {
                            Session["admin_usermlm"] = dt.Rows[0]["User_id"].ToString();
                            Response.Redirect("Admin/home.aspx");
                        }
                        else
                        {

                            lbl_message.Text = "User Name or Password is incorrect.";
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void login_to_member_profile()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_Login where  userName ='" + txt_username.Text + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                //lbl_message.Text = "User Name or Password is incorrect.";
                login_to_repurchase();
            }
            else
            {
                string pwd = dt.Rows[0][2].ToString();

                if (pwd == txt_password.Text)
                {
                    lbl_message.Text = "";
                    Session["membercode"] = dt.Rows[0][1].ToString();
                    Response.Redirect("Member_4235profile/Member_home.aspx");
                }
                else
                {
                    lbl_message.Text = "User Name or Password is incorrect.";
                } 
            }
        }



        private void login_to_repurchase()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Re_Franchise_details where Stock_point_code='" + txt_username.Text + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message.Text = "User Name or Password is incorrect.";
            }
            else
            {
                int j = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    if (dt.Rows[i][7].ToString() == txt_password.Text)
                    {
                        Session["repurchase_user"] = dt.Rows[i][6].ToString();
                        Response.Redirect("Repurchase/Home.aspx");
                    }
                    else
                    {
                        j++;
                    }
                }
                if (j == rowcount)
                {
                    lbl_message.Text = "Username or Password is incorrect.";
                }

            }
        }


        private bool textContainsUnallowedCharacter(string T, char[] UnallowedCharacters)
        {
            for (int i = 0; i < UnallowedCharacters.Length; i++)

                if (T.Contains(UnallowedCharacters[i]))

                    return true;


            return false;
        }
    }
}