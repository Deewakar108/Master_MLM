using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Change_Transaction_Password : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            return;
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
            }
        }

        protected void btn_change_pwd_Click(object sender, EventArgs e)
        {
            string membercode = "7856969777"; // Session["membercode"].ToString();
            string pass = txt_old_password.Text;
            string pass1 = txt_new_password.Text;
            string pass2 = txt_confirm_password.Text;
            if (pass == "" || pass1 == "" || pass2 == "") { Alert("Invalid input."); return; }

            matche_admin_userid(membercode);
        }

        private void matche_admin_userid(string membercode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_Login where Membercode='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_Login");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                if (ds.Tables[0].Rows[0][4].ToString() == txt_old_password.Text)
                {
                    if (txt_new_password.Text == txt_confirm_password.Text)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            dr[4] = txt_confirm_password.Text;
                            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                            ad.Update(dt);
                            Alert("You have successfully changed your password.");
                            txt_old_password.Text = "";
                            txt_new_password.Text = "";
                            txt_confirm_password.Text = "";
                        }


                    }
                    else
                    {
                        Alert("Password does not matched.");
                        //lbl_confirmpwd.Text = "Password does not matched";
                    }

                }
                else
                {
                    Alert("Old password is not correct.");
                    //lbl_oldpwd.Text = "Old password is not correct";
                }


            }
        }


        public void Alert(string Message)
        {
            lbl_msg.Text = Message;
            imp.Alert();
        }
    }
}