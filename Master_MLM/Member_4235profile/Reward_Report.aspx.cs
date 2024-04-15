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

namespace Master_MLM.Member_4235profile
{
    public partial class Reward_Report : System.Web.UI.Page
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

                if (!IsPostBack)
                {
                    string MemberCode = Session["membercode"].ToString();
                    string query = "select *  from AchievedTable where MemberCode='" + MemberCode + "' order by id desc";
                    bind_grid_view(query);
                }
            }
        }


        My mycode = new My();
        

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
            //if (rowcount == 0)
            //{
            //    grd_view.DataSource = null;
            //    grd_view.DataBind();

            //}
            //else
            //{
            grd_view.DataSource = ds;
            grd_view.DataBind();


            //}
        }


    }
}