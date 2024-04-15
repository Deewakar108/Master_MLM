using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Welcome_letter : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCompanyName.Text = imp.CompanyName;
            lblCompanyName1.Text = imp.CompanyName;
            lblCompanyName2.Text = imp.CompanyName;
            lblCompanyName3.Text = imp.CompanyName;

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

                    try
                    {

                        string membercode = Session["membercode"].ToString(); ;
                        find_data(membercode);
                    }
                    catch
                    {
                    }

                }
            }

        }



        private void find_data(string membercode)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Member_name,Address,District,Mobile_number,Joining_amount,Date,Level  from Member_registration  where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                lbl_name.Text = dt.Rows[0][0].ToString();
                lbl_name1.Text = dt.Rows[0][0].ToString();
                lbl_address.Text = dt.Rows[0][1].ToString();
                lbl_city.Text = dt.Rows[0][2].ToString();
                lbl_mobileno.Text = dt.Rows[0][3].ToString();
                lbl_joiningamount.Text = dt.Rows[0][4].ToString();
                lbl_date.Text = dt.Rows[0][5].ToString();
                lbl_code.Text = membercode;
                lbl_level.Text = dt.Rows[0][6].ToString();
            }
        }

        protected void Img_back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Member_home.aspx");
        }

        protected void Img_print_Click(object sender, ImageClickEventArgs e)
        {
            Go_to_print();
        }
        private void Go_to_print()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printit", "printit()", true);
        }
    }
}