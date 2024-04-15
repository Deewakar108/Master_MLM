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
    public partial class Change_member_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        My mycode = new My();
        protected void btn_change_pwd_Click(object sender, EventArgs e)
        {
            bool mob = mycode.valid_number(txt_membercode.Text);
            if (mob == false)
            {
                lbl_msg.Text = "Please Enter Valid Member Code";
            }
            else
            {
                lbl_msg.Text = "";
                change_password();
            }
            
        }

        private void change_password()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_Login where User_id='" + txt_membercode.Text + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_Login");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

                lbl_membercode.Text = "you had entered wrong membercode.";
            }
            else
            {
                if (txt_new_password.Text == txt_confirm_password.Text)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[2] = txt_confirm_password.Text;
                        SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                        ad.Update(dt);
                        lbl_msg.Text = "You had successfully changed user password";
                        txt_membercode.Text = "";
                        txt_new_password.Text = "";
                        txt_confirm_password.Text = "";
                        lbl_confirmpwd.Text = "";
                        lbl_membercode.Text = "";
                    }


                }
                else
                {

                    lbl_confirmpwd.Text = "Password does not matched";
                }


            }
        }
    }
}
