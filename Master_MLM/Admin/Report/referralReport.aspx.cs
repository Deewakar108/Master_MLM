using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Collections;
using System.Data;

namespace Master_MLM.Admin
{
    public partial class referralReport : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_usermlm"] == null)
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
                    
                }
            }
        }

        My mycode = new My();
        
        protected string hide_string(string str)
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
        
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_memberid.Text == "")
                {
                    lbl_message.Text = "Pelese enter member code";
                    pnl_view.Visible = false;
                }

                else
                {
                    bool chkob = mycode.valid_number(txt_memberid.Text);
                    if (chkob == false)
                    {
                        lbl_message.Text = "Pelese enter valid member code";
                        pnl_view.Visible = false;
                    }
                    else
                    {
                        finddata();
                    }
                }

            }
            catch (Exception ex)
            {
                My.submitException(ex);
            }
        }

        private void finddata()
        {
            if (txt_memberid.Text != "")
            {
                string queiry = "Select * from Member_registration where  Member_code!='" + imp.AdminCode + "' and Referal_code!=Sponcer_code and Referal_code='" + txt_memberid.Text + "'  ORDER BY CONVERT(DATETIME, Date, 103)";
                bind_grid_view(queiry);
            }
            else
            {

                lbl_message.Text = "Invalid Member Code";
            }
        }

        private void bind_grid_view(string queiry)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter(queiry, conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "Member_registration");
            int rowcount = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {

                pnl_view.Visible = false;
                lbl_message.Text = "Sorry Data Not Found";
                grd_view.DataSource = null;
                grd_view.DataBind();

            }
            else
            {
                pnl_view.Visible = true;
                lbl_message.Text = "";
                grd_view.DataSource = ds;
                grd_view.DataBind();


            }
        }
    }
}