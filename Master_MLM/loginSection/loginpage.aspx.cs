using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.loginSection
{
    public partial class loginpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>firstLogin();</script>", false);
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                admin_login();
            }
            catch (Exception ex)
            {
            }
        }

        private void admin_login()
        {
            string T = txt_userid.Text;

            try
            {
                //Not Allowing Numbers, Underscore or Hash
                char[] UnallowedCharacters = { '-', '#', '\'', '/', '\\', '*', '!', ';', ':', '(', ')', '{', '}', '[', ']', '+', '|', '&', '%', '=' };

                if (textContainsUnallowedCharacter(T, UnallowedCharacters))
                {
                    lbl_msg.Text = "Wrong Entry";
                }
                else
                {
                    Connection con = new Connection();
                    string connectionstring = con.connect_method();
                    SqlConnection conn = new SqlConnection(connectionstring);
                    SqlDataAdapter ad = new SqlDataAdapter("Select * from Admin_Login where User_id='" + txt_userid.Text + "' ", conn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "Admin_Login");
                    DataTable dt = ds.Tables[0];
                    int rowcount = dt.Rows.Count;
                    if (rowcount == 0)
                    {
                        //lbl_msg.Text = "Wrong Entry";
                        memberlogin();
                    }
                    else
                    {
                        if (dt.Rows[0][2].ToString() == txt_pwd.Text)
                        {
                            Session["admin_usermlm"] = txt_userid.Text;
                            Response.Redirect("../Admin/home.aspx");
                        }
                    }
                }
            }
            catch (Exception)
            {
                lbl_msg.Text = "Wrong Entry";
            }
        }

        private void memberlogin()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_Login where  User_id='" + txt_userid.Text + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_Login");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                Repechage_login();
            }
            else
            {
                int j = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    if (dt.Rows[i][2].ToString() == txt_pwd.Text)
                    {
                        Session["membercode"] = dt.Rows[i][0].ToString();
                        Response.Redirect("~/Member_4235profile/Member_home.aspx");
                    }
                    else
                    {
                        j++;
                    }
                }
                if (j == rowcount)
                {
                    lbl_msg.Text = "You enter wrong user-id or password.";
                }
            }
        }

        private void Repechage_login()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Re_Franchise_details where Stock_point_code='" + txt_userid.Text + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_msg.Text = "Username or Password is incorrect.";

            }
            else
            {
                int j = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    if (dt.Rows[i][7].ToString() == txt_pwd.Text)
                    {
                        Session["repurchase_user"] = dt.Rows[i][6].ToString();
                        Response.Redirect("../Repurchase/Home.aspx");
                    }
                    else
                    {
                        j++;
                    }
                }
                if (j == rowcount)
                {
                    lbl_msg.Text = "Username or Password is incorrect.";

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