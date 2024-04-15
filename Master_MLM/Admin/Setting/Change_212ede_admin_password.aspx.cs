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
    public partial class Change_212ede_admin_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btn_change_pwd_Click(object sender, EventArgs e)
        {

            string userid = Session["admin_usermlm"].ToString();
            matche_admin_userid(userid);

        }

        private void matche_admin_userid(string userid)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Admin_Login where User_id='" + userid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Admin_Login");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                if (ds.Tables[0].Rows[0][2].ToString() == txt_old_password.Text)
                {
                    if (txt_new_password.Text == txt_confirm_password.Text)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            dr[2] = txt_confirm_password.Text;
                            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                            ad.Update(dt);
                            lbl_msg.Text = "You had successfully changed your password";
                            txt_old_password.Text = "";
                            txt_new_password.Text = "";
                            txt_confirm_password.Text = "";
                            lbl_confirmpwd.Text = "";
                            lbl_oldpwd.Text = "";

                        }
                    }
                    else
                    {

                        lbl_confirmpwd.Text = "Password does not matched";
                    }
                }
                else
                {
                    lbl_oldpwd.Text = "Password does not matched";
                }


            }
        }
    }
}
