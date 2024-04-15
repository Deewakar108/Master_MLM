using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Transaction_Verification : System.Web.UI.Page
    {
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
                try
                {
                    string id = Request.QueryString["id"];
                    if (!String.IsNullOrEmpty(id))
                    {
                        hd_url.Value = id;
                    }
                    else
                    {
                        Session.Abandon();
                        Session.Clear();
                        Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                        Response.Write("<script language=javascript>wnd.close();</script>");
                        Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                    }
                }
                catch
                {
                }
            }
        }
        My mycode = new My();
        protected void btn_change_pwd_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = "";
            if (txt_new_password.Text == "")
            {
                lbl_msg.Text = "Please Enter Your  Transaction Password";
            }
            else
            {
                Connection con = new Connection();
                string connectionstring = con.connect_method();
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlDataAdapter ad = new SqlDataAdapter("select * from Member_Login where Membercode='" + Session["membercode"].ToString() + "'", conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Member_Login");
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {

                }
                else
                {

                    string pwd = dt.Rows[0]["Transaction_Password"].ToString();
                    if (pwd == txt_new_password.Text)
                    {
                        string pincode = mycode.Zip(mycode.password());
                        Session["verify"] = pincode;
                        Response.Redirect(hd_url.Value + "?mypage=" + Uri.EscapeDataString(pincode));
                    }
                    else
                    {
                        lbl_msg.Text = "Please Enter Your Valid  Transaction Password";
                    }
                }

            }
        }
    }
}