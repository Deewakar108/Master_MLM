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

namespace Master_MLM.Admin
{
    public partial class Reprint_welcome_letter : System.Web.UI.Page
    {
        Important imp = new Important();
        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        My mycode = new My();
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_membercode.Text == "")
            {
                lbl_message.Text = "Please enter member code.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
               
            }
            else
            {
                if (txt_membercode.Text == imp.AdminCode)
                {
                    lbl_message.Text = "This code is company code. please enter member code.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                  
                }
                else
                {
                    bool chmembercode = true;   //mycode.valid_number(txt_membercode.Text);
                    if (chmembercode == false)
                    {
                        lbl_message.Text = "Please Enter Valid Member Code";
                        scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                    }
                    else
                    {
                        if (checkmembercodeisvalid_or_not(txt_membercode.Text))
                        {
                            lbl_message.Text = "This member code is not valid.";
                            scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                        }
                        else
                        {

                            string path = "Welcome_letter.aspx?membercode=" + txt_membercode.Text;
                            Response.Redirect(path);

                        }
                    }
                }
            }
        }

        private bool checkmembercodeisvalid_or_not(string membercode)
        {
            string status = "Verified";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
