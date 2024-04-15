using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Data;
namespace Master_MLM.Member_4235profile
{
    public partial class Print_id : System.Web.UI.Page
    {
        My mycode = new My();
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
                    string membercode = Session["membercode"].ToString();
                    fetch_data(membercode);
                }
            }
            
        }

        private void fetch_data(string code)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter("Select Member_name,Mobile_number,member_imagepath,Date_of_birth,Date,District from Member_registration where Member_code='" + code + "'", conn);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Member_registration");
            DataTable dt6 = ds6.Tables[0];
            int rowcount = dt6.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                lbl_name.Text = dt6.Rows[0]["Member_name"].ToString();
                lbl_mob.Text = dt6.Rows[0]["Mobile_number"].ToString();
                Image1.ImageUrl = dt6.Rows[0]["member_imagepath"].ToString();
                lbl_district.Text = dt6.Rows[0]["District"].ToString();
                lbl_dob.Text = dt6.Rows[0]["Date_of_birth"].ToString();
                lbl_doj.Text = dt6.Rows[0]["Date"].ToString();
                lbl_id.Text = code;// find_id(code);
            }
        }

        private string find_id(string str)
        {
            string val = "";
            if (str != "")
            {
                if (str.Length >= 10)
                {
                    val = str.Substring(0, 2) + "xxxxxxxx" + str.Substring((str.Length) - 2, 2);
                }
            }
            return val;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Print_Member_Id_Card.aspx", false);
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printit", "printit()", true);
        }
    }
}