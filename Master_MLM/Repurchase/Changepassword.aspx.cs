using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Repurchase
{
    public partial class Changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_change_pwd_Click(object sender, EventArgs e)
        {
            string userid = Session["repurchase_user"].ToString();
            matche_userid(userid);
        }

        private void matche_userid(string userid)
        {

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_details where Stock_point_code='" + userid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                if (ds.Tables[0].Rows[0][7].ToString() == txt_old_password.Text)
                {
                    if (txt_new_password.Text == txt_confirm_password.Text)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            dr[7] = txt_confirm_password.Text;
                            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                            ad.Update(dt);
                            lbl_message.Text = "You had successfuly changed your password";
                            txt_old_password.Text = "";
                            txt_new_password.Text = "";
                            txt_confirm_password.Text = "";
                            lbl_confirmpwd.Text = "";
                            lbl_oldpwd.Text = "";

                        }
                    }
                    else
                    {
                        lbl_oldpwd.Text = "";
                        lbl_confirmpwd.Text = "Password does not matched";
                    }
                }
                else
                {
                    lbl_confirmpwd.Text = "";
                    lbl_oldpwd.Text = "Password does not matched";
                }


            }
        }
    }
}